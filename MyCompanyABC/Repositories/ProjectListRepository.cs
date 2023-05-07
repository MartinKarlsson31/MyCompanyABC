using Microsoft.EntityFrameworkCore;
using MyCompanyABC.Data;
using MyCompanyABC.Models;

namespace MyCompanyABC.Repositories
{
    internal static class ProjectListRepository
    {
        internal async static Task<List<ProjectList>> GetProjectListAsync()
        {
            using (var db = new ApplicationDbContext())
            {
                return await db.ProjectLists.ToListAsync();
            }
        }

        internal async static Task<bool> CreateProjectListAsync(ProjectList project)
        {
            using (var db = new ApplicationDbContext())
            {
                try
                {
                    await db.ProjectLists.AddAsync(project);
                    return await db.SaveChangesAsync() <= 1;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        internal static async Task<bool> UpdateProjectListAsync(ProjectList projectListToUpdate)
        {
            using (var db = new ApplicationDbContext())
            {
                try
                {
                    db.ProjectLists.Update(projectListToUpdate);
                    return await db.SaveChangesAsync() <= 1;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
