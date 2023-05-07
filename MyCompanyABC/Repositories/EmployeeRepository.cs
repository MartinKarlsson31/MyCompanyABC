using Microsoft.EntityFrameworkCore;
using MyCompanyABC.Data;
using MyCompanyABC.Models;
using System;

namespace MyCompanyABC.Repositories
{
    internal static class EmployeeRepository
    {
        internal async static Task<List<Employee>> GetEmployeeAsync()
        {
            using (var db = new ApplicationDbContext())
            {
                return await db.Employees.ToListAsync();
            }
        }
        internal async static Task<Employee> GetEmployeeByIdAsync(int employeeId)
        {
            using (var db = new ApplicationDbContext())
            {
                return await db.Employees.FirstOrDefaultAsync(emp => emp.EmployeeId == employeeId);
            }
        }

        internal async static Task<bool> CreateEmployeeAsync(Employee employee)
        {
            using (var db = new ApplicationDbContext())
            {
                try 
                { 
                await db.Employees.AddAsync(employee);
                return await db.SaveChangesAsync() <= 1;
                }
                catch(Exception)
                {
                    return false;
                }
            }
        }

        internal static async Task<bool> UpdateEmployeeAsync(Employee employeeToUpdate)
        {
            using (var db = new ApplicationDbContext())
            {
                try
                {
                    db.Employees.Update(employeeToUpdate);
                    return await db.SaveChangesAsync() <= 1;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        internal static async Task<bool> DeleteEmployeeAsync(int employeeId)
        {
            using (var db = new ApplicationDbContext())
            {
                try
                {
                    Employee employeeToDelete = await GetEmployeeByIdAsync(employeeId);
                    db.Remove(employeeToDelete);
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
