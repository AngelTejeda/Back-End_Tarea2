using System.Collections.Generic;
using System.Linq;
using Tarea_2.BackEnd;
using Tarea_2.DataAccess;
using Tarea_2.Models;

namespace Tarea_2
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeSC employeeSC = new EmployeeSC();

            //Consulta original reescrita.
            List<EmployeeBasicDataDTO> empleados = employeeSC
                .GetAllEmployees()
                .Select(employee => new EmployeeBasicDataDTO(employee))
                .ToList();


            #region Liskov Substitution Principle

            EmployeeDTO basicInfoEmployee = new EmployeeBasicDataDTO()
            {
                Nombre = "Pedro",
                Apellido = "Hernandez",
                Puesto = "Programador"
            };

            EmployeeDTO contactInfoEmployee = new EmployeeContactDataDTO()
            {
                Nombre = "Melisa",
                Apellido = "Perez",
                Ciudad = "Monterrey",
                Pais = "México",
                Direccion = "Anáhuac",
                Telefono = "8182838485"
            };

            #endregion

            #region Open-Closed

            employeeSC.AddNewEmployee(basicInfoEmployee);
            employeeSC.AddNewEmployee(contactInfoEmployee);

            #endregion
        }
    }
}