using hapiservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Builder;

namespace hapiservice
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            //config.EnableSystemDiagnosticsTracing();

            ODataModelBuilder modelBuilder = new ODataConventionModelBuilder();
            modelBuilder.EntitySet<QueueModel>("Queues");
            modelBuilder.EntitySet<QueueDetailModel>("QueueDetails");
            //modelBuilder.EntitySet<TestModel>("Test");
            modelBuilder.EntitySet<CaseModel>("Cases");
            modelBuilder.EntitySet<CaseSummaryModel>("CasesSummary");
            modelBuilder.EntitySet<CaseNotesModel>("CasesNotes");
            modelBuilder.EntitySet<IssueWIModel>("IssueWI");
            modelBuilder.EntitySet<QueueActivityModel>("QueueActivity");
            modelBuilder.EntitySet<EmployeeDetailModel>("EmployeeDetails");
            
            Microsoft.Data.Edm.IEdmModel model = modelBuilder.GetEdmModel();            
            config.Routes.MapODataRoute("OdataRoute", "hapi", model);
            config.EnableQuerySupport();

        }
    }
}
