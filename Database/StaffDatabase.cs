using GEH.Database.Entities;

namespace GEH.Database;

public static class StaffDatabase
{
    public static List<Employee> GetAllEmployees()
    {
        return new List<Employee>
        {
            new Employee() { Id = 1, Name = "Giorgi", Salary = 1000 },
            new Employee() { Id = 2, Name = "Malkhaz", Salary = 500 },
            new Employee() { Id = 3, Name = "Irakli", Salary = 10000 }
        };
    }
}