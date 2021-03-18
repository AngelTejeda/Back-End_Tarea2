using System.Linq;
using Tarea_2.BackEnd;

namespace Tarea_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var empleados = new EmployeeSC().GetAllEmployees().Select(s => new
            {
                Nombre = s.FirstName,
                Apellidos = s.LastName,
                Puesto = s.Title
            }
            ).ToList();
        }
    }
}