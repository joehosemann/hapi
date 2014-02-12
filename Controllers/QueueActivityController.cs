using hapiservice.Models;
using hapiservice.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;
using Dapper;
using System.Text;
using System.Web.Mvc;
using Mvc.JQuery.Datatables;

namespace hapiservice.Controllers
{
    public class QueueActivityController : ApiController
    {
        public IEnumerable<QueueActivityModel> Get([FromUri] string extension)
        {
            var isValidParams = false;
            int intExtension = Utilities.TryIntParse(extension);

            if (intExtension > 0)
            {
                isValidParams = true;
            }

            var sbQuery = new StringBuilder();

            sbQuery.Append(@"SELECT DISTINCT tP.FirstName + ' ' + tP.LastName AS NAME
	                        ,CASE tART.AgentState
		                        WHEN 2
			                        THEN 'Not Ready'
		                        WHEN 3
			                        THEN 'Ready'
		                        WHEN 4
			                        THEN 'Talking'
		                        WHEN 5
			                        THEN 'Work Not Ready'
		                        WHEN 6
			                        THEN 'Work Ready'
		                        WHEN 10
			                        THEN 'Hold'
		                        ELSE 'Unknown'
		                        END AS AgentState
	                        ,CASE tRC.ReasonText
		                        WHEN 'Undefined'
			                        THEN ''
		                        ELSE tRC.ReasonText
		                        END AS Reason
	                        ,convert(VARCHAR, DATEADD(s, datediff(s, tART.DateTimeLastStateChange, getdate()), 0), 108) AS TimeInStatus
                        FROM t_Agent_Real_Time tART WITH (NOLOCK)
                        JOIN t_Person tP WITH (NOLOCK) ON tART.Extension = tP.LoginName
                        JOIN t_Agent_Skill_Group_Real_Time tASGRT WITH (NOLOCK) ON tASGRT.SkillTargetID = tART.SkillTargetID
                        LEFT JOIN t_Reason_Code tRC WITH (NOLOCK) ON tRC.ReasonCode = tART.ReasonCode
                        JOIN (
	                        SELECT tASGRTind.SkillGroupSkillTargetID
	                        FROM t_Agent_Skill_Group_Real_Time tASGRTind WITH (NOLOCK)
	                        JOIN t_Agent_Real_Time tARTind WITH (NOLOCK) ON tARTind.SkillTargetID = tASGRTind.SkillTargetID
	                        WHERE tASGRTind.SkillGroupSkillTargetID NOT IN ('5000','5124')
		                        AND tARTind.Extension = @extension
	                        ) bla ON bla.SkillGroupSkillTargetID = tASGRT.SkillGroupSkillTargetID");
            if (isValidParams == false)
            {
                return null;
            }
            else
            {
                using (var connection = Helpers.SqlHelper.GetOpenConnectionEZView())
                {
                    return connection.Query<QueueActivityModel>(sbQuery.ToString(), new { extension = intExtension.ToString() });
                }
            }


        }
    }
}
