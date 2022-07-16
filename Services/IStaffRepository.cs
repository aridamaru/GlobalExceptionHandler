using GEH.Database.Entities;

namespace GEH.Services;

public interface IStaffRepository
{
    public IEnumerable<Employee> GetAllEmployees();
    public Employee LoadIrakli();
}