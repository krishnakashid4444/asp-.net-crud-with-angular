using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace crud_dotnet_api.Data
{
    public class EmployeeRepository
    {
        private readonly AppDbContext _appDbContext;
        public EmployeeRepository(AppDbContext appDbContext) 
        {
           _appDbContext = appDbContext;
        }

        public async Task AddEmployeeAsync(Employee employee) 
        {
            await _appDbContext.Set<Employee>().AddAsync(employee);
           await _appDbContext.SaveChangesAsync();
        
        }

        public async Task<List<Employee>> GetAllEmployeeAsync() 
        {

            return await _appDbContext.Employees.ToListAsync();
        
        }
        
        public async Task<Employee> GetEmployeeByIdAsync(int id) 
        {
            return await _appDbContext.Employees.FindAsync(id);
           
        
        }

        public async Task UpdateEmployeeAsync(int id , Employee model) 
        {
            var employee = await _appDbContext.Employees.FindAsync(id);
            if (employee == null)
            {
                throw new Exception("Employee is not found");
            
            }
            employee.Name = model.Name;
            employee.Email = model.Email;
            employee.Phone = model.Phone;
            employee.Age = model.Age;
            employee.salary = model.salary;
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(int id) 
        {

            var employee = await _appDbContext.Employees.FindAsync(id);
            if (employee == null)
            {
                throw new Exception("Employee is not found");

            }
             _appDbContext.Employees.Remove(employee);
            await _appDbContext.SaveChangesAsync();

        }

        
        
    }
}   
