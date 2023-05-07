
using Microsoft.OpenApi.Models;
using MyCompanyABC.Models;
using MyCompanyABC.Repositories;

namespace MyCompanyABC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();           
            builder.Services.AddSwaggerGen(swaggerGenOptions =>
            {
                swaggerGenOptions.SwaggerDoc(name: "v1", info: new OpenApiInfo { Title = "Asp.Net Core Swagger API", Version = "v1" });
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseSwaggerUI(swaggerUiOptions =>
            {
                swaggerUiOptions.DocumentTitle = "Learning minimal API";
                swaggerUiOptions.SwaggerEndpoint("/swagger/v1/swagger.json", name: "Api that gives you a possibility to learn.");
                swaggerUiOptions.RoutePrefix = string.Empty;

            });
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapGet("/get-all-employees", async () => await EmployeeRepository.GetEmployeeAsync())
            .WithTags("Employees endpoint");

            app.MapGet("/get-employee-by-id/{employeeId}", handler: async (int employeeId) =>
            {
                Employee employee = await EmployeeRepository.GetEmployeeByIdAsync(employeeId);
                if (employee != null)
                {
                    return Results.Ok(employee);
                }
                else 
                { 
                    return Results.BadRequest();
                }
            }).WithTags("Employees endpoint");

            //
            app.MapPost("/create-employee", handler: async (Employee employee) =>
            {
                bool createSuccess = await EmployeeRepository.CreateEmployeeAsync(employee);
                if (createSuccess)
                {
                    return Results.Ok("Employee Created successfully");
                }
                else
                {
                    return Results.BadRequest();
                }
            }).WithTags("Employees endpoint");
            //

            app.MapPut(pattern: "/update-employee", handler: async (Employee employeeToUpdate) =>
            {
                bool updateSuccessful = await EmployeeRepository.UpdateEmployeeAsync(employeeToUpdate);
                if (updateSuccessful)
                {
                    return Results.Ok(value: "Updating an employee was successful");
                }
                else
                {
                    return Results.BadRequest();
                }
            }).WithTags("Employees endpoint");

            //

            app.MapDelete(pattern: "/delete-employee-by-id/{employeeId}", handler: async (int employeeId) =>
            {
                bool deleteSuccessful = await EmployeeRepository.DeleteEmployeeAsync(employeeId);
                if (deleteSuccessful)
                {
                    return Results.Ok(value: "Deleting an employee was successful");
                }
                else
                {
                    return Results.BadRequest();
                }
            }).WithTags("Employees endpoint");

            //***********************************************************************

            // Below is code for the Project model


            app.MapGet("/get-all-projects", async () => await ProjectRepository.GetProjectAsync())
            .WithTags("Projects endpoint");

            //

            app.MapGet(pattern: "/get-project-by-id/{projectId}", handler: async (int projectId) =>
            {
                Project projectToReturn = await ProjectRepository.GetProjectByIdAsync(projectId);
                if (projectToReturn != null)
                {
                    return Results.Ok(value: projectToReturn);
                }
                else
                {
                    return Results.BadRequest();
                }
            }).WithTags("Projects endpoint");

            //

            app.MapPost(pattern: "/create-project", handler: async (Project projectToCreate) =>
            {
                bool createSuccessful = await ProjectRepository.CreateProjectAsync(projectToCreate);
                if (createSuccessful)
                {
                    return Results.Ok(value: "Project Createed successfully");
                }
                else
                {
                    return Results.BadRequest();
                }
            }).WithTags("Projects endpoint");

            //

            app.MapPut(pattern: "/update-project", handler: async (Project projectToUpdate) =>
            {
                bool updateSuccessful = await ProjectRepository.UpdateProjectAsync(projectToUpdate);
                if (updateSuccessful)
                {
                    return Results.Ok(value: "Updating a project was successful");
                }
                else
                {
                    return Results.BadRequest();
                }
            }).WithTags("Projects endpoint");

            //

            app.MapDelete(pattern: "/delete-project-by-id/{projectId}", handler: async (int projectId) =>
            {
                bool deleteSuccessful = await ProjectRepository.DeleteProjectAsync(projectId);
                if (deleteSuccessful)
                {
                    return Results.Ok(value: "Deleting an project was successful");
                }
                else
                {
                    return Results.BadRequest();
                }
            }).WithTags("Projects endpoint");

            //************************************************************

            // Below is code for the ProjectList Model

            app.MapGet("/get-all-projectlists", async () => await ProjectListRepository.GetProjectListAsync())
                .WithTags("ProjectLists Endpoint");

            //

            app.MapPost(pattern: "/create-projectlist", handler: async (ProjectList projectListToCreate) =>
            {
                bool createSuccessful = await ProjectListRepository.CreateProjectListAsync(projectListToCreate);
                if (createSuccessful)
                {
                    return Results.Ok(value: "ProjectList Createed successfully");
                }
                else
                {
                    return Results.BadRequest();
                }
            }).WithTags("ProjectLists Endpoint");

            //

            app.MapPut(pattern: "/update-projectlist", handler: async (ProjectList projectListToUpdate) =>
            {
                bool updateSuccessful = await ProjectListRepository.UpdateProjectListAsync(projectListToUpdate);
                if (updateSuccessful)
                {
                    return Results.Ok(value: "Updating an employee was successful");
                }
                else
                {
                    return Results.BadRequest();
                }
            }).WithTags("ProjectLists Endpoint");

            app.Run();

            
            


        }
    }
}