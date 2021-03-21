using System.Collections.Generic;
using System.Linq;
using Tarea_2.BackEnd;
using Tarea_2.Models;

namespace Tarea_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<EmployeeDTO> empleados = new EmployeeSC()
                .GetAllEmployees()
                .Select(s => new EmployeeDTO()
                {
                    Nombre = s.FirstName,
                    Apellido = s.LastName,
                    Puesto = s.Title,
                    Telefono = s.HomePhone
                }
                ).ToList();
        }
    }
}