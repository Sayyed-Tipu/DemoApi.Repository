
using DemoApi.Dal;
using DemoApi.Data;
using DemoApi.Repository;
using Microsoft.EntityFrameworkCore;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly AppDBContext _context;
    public EmployeeRepository(AppDBContext context)
    {
        _context = context;
    }

    public async Task AddEmployee(Employee employee)
    {
        _context.Employyes.Add(employee);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteEmployee(int id)
    {
        var delobj = await _context.Employyes.FindAsync(id);
        if (delobj != null)
        {
            _context.Employyes.Remove(delobj);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<Employee> GEtEmployeeById(int id)
    {
        return await _context.Employyes.FindAsync(id);
    }

    public async Task<IEnumerable<Employee>> GetEmployees()
    {
        return await _context.Employyes.ToListAsync();
    }

    public async Task UpdateEmployee(int id, Employee employee)
    {
        var empobj = await _context.Employyes.FindAsync(id);
        if (empobj != null)
        {
            _context.Entry(empobj).CurrentValues.SetValues(employee);
            await _context.SaveChangesAsync();
        }
    }
}