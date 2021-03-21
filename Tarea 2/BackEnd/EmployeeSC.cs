using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Tarea_2.DataAccess;
using Tarea_2.Models;

namespace Tarea_2.BackEnd
{
    class EmployeeSC : BaseSC
    {
        public IQueryable<Employee> GetAllEmployees()
        {
            return dbContext.Employees.AsQueryable();
        }

        public Employee GetEmployeeById(int id)
        {
            try
            {
                return GetAllEmployees().First(employee => employee.EmployeeId == id);
            }
            catch (Exception)
            {
                throw new Exception("No existe un empleado con el ID especificado.");
            }
        }

        public void AddNewEmployee(EmployeeDTO newEmployee)
        {
            try
            {
                Employee dataBaseEmployee = new Employee()
                {
                    FirstName = newEmployee.Nombre,
                    LastName = newEmployee.Apellido,
                    Title = newEmployee.Puesto,
                    HomePhone = newEmployee.Telefono,
                    HireDate = DateTime.Today
                };

                dbContext.Employees.Add(dataBaseEmployee);

                dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("No se ha podido agregar al empleado.");
            }
        }

        public void UpdateEmployee(int id, EmployeeDTO modifiedEmployee)
        {
            try
            {
                Employee dataBaseEmployee = GetEmployeeById(id);

                dataBaseEmployee.FirstName = modifiedEmployee.Nombre;
                dataBaseEmployee.LastName = modifiedEmployee.Apellido;
                dataBaseEmployee.Title = modifiedEmployee.Puesto;
                dataBaseEmployee.HomePhone = modifiedEmployee.Telefono;

                dbContext.SaveChanges();
            }
            catch (Exception ex) when (
                ex is DbUpdateException || ex is DbUpdateConcurrencyException
            )
            {
                throw new Exception("No se ha podido actualizar al empleado.");
            }
        }

        public void DeleteEmployee(int id)
        {
            try
            {
                Employee dataBaseEmployee = GetEmployeeById(id);

                dbContext.Employees.Remove(dataBaseEmployee);

                dbContext.SaveChanges();
            }
            catch (Exception ex) when (
                ex is DbUpdateException || ex is DbUpdateConcurrencyException
            )
            {
                throw new Exception("No se ha podido eliminar al empleado.");
            }
        }
    }
}