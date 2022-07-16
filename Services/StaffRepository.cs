using GEH.Database;
using GEH.Database.Entities;

namespace GEH.Services;

public class StaffRepository : IStaffRepository
{
    public IEnumerable<Employee> GetAllEmployees()
    {
        return StaffDatabase.GetAllEmployees();
    }

    public Employee LoadIrakli()
    {
        return StaffDatabase.GetAllEmployees().FirstOrDefault(x => x.Name == "Irakli");
    }
}