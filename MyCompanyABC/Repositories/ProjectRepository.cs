using Microsoft.EntityFrameworkCore;
using MyCompanyABC.Data;
using MyCompanyABC.Models;
using System;

namespace MyCompanyABC.Repositories
{
    internal static class ProjectRepository
    {
        internal async static Task<List<Project>> GetProjectAsync()
        {
            using (var db = new ApplicationDbContext())
            {
                return await db.Projects.ToListAsync();
            }
        }

        internal async static Task<Project> GetProjectByIdAsync(int projectId)
        {
            using (var db = new ApplicationDbContext())
            {
                return await db.Projects.FirstOrDefaultAsync(emp => emp.ProjectId == projectId);
            }
        }

        internal async static Task<bool> CreateProjectAsync(Project project)
        {
            using (var db = new ApplicationDbContext())
            {
                try
                {
                    await db.Projects.AddAsync(project);
                    return await db.SaveChangesAsync() <= 1;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        internal static async Task<bool> UpdateProjectAsync(Project projectToUpdate)
        {
            using (var db = new ApplicationDbContext())
            {
                try
                {
                    db.Projects.Update(projectToUpdate);
                    return await db.SaveChangesAsync() <= 1;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        internal static async Task<bool> DeleteProjectAsync(int projectId)
        {
            using (var db = new ApplicationDbContext())
            {
                try
                {
                    Project projectToDelete = await GetProjectByIdAsync(projectId);
                    db.Remove(projectToDelete);
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
