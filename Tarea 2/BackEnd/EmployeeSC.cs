using System.Linq;
using Tarea_2.DataAccess;

namespace Tarea_2.BackEnd
{
    class EmployeeSC : BaseSC
    {
        public IQueryable<Employee> GetAllEmployees()
        {
            return dbContext.Employees.AsQueryable();
        }
    }
}