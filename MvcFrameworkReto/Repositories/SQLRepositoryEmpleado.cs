using MvcFrameworkReto.Data;
using MvcFrameworkReto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MvcFrameworkReto.Repositories {
    public class SQLRepositoryEmpleado {

        private HospitalContext context;

        public SQLRepositoryEmpleado(HospitalContext context) {
            this.context = context;
        }

        public Empleado FindEmpleado(int idEmpleado) {
            var consulta = from data in this.context.Empleados
                           where data.IdEmpleado == idEmpleado
                           select data;
            return consulta.ToList().FirstOrDefault();
        }

        public List<Empleado> GetEmpleados() {
            var consulta = from data in this.context.Empleados
                           select data;
            return consulta.ToList();
        }

        public async Task DeleteEmpleadoAsync(int id) {
            Empleado empleado = this.FindEmpleado(id);
            this.context.Empleados.Remove(empleado);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateEmpleado(int idEmpleado, int salario, string oficio) {
            Empleado empleado = this.FindEmpleado(idEmpleado);
            empleado.Salario = salario;
            empleado.Oficio = oficio;
            await this.context.SaveChangesAsync();
        }

    }
}