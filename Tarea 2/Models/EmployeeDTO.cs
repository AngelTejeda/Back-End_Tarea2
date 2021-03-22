using Tarea_2.DataAccess;

namespace Tarea_2.Models
{
    abstract class EmployeeDTO
    {
        public abstract Employee GetDataBaseEmployeeObject();
        public abstract void ModifyDataBaseEmployee(Employee dataBaseEmployee);
    }
}