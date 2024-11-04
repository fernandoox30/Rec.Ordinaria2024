using Refuerzo2024.Model.Conexion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refuerzo2024.Model.DTO
{
    internal class DTOEstudiantes : dbContext
    {
        private int idEstudiante;
        private string nombreEstudiante;
        private string apellidoEstudiante;
        private DateTime fechaNacimiento;
        private string telefono;
        private string correo;
        private string dui;
        private int idEspecialidad;

        public int IdEstudiante { get => idEstudiante; set => idEstudiante = value; }
        public string NombreEstudiante { get => nombreEstudiante; set => nombreEstudiante = value; }
        public string ApellidoEstudiante { get => apellidoEstudiante; set => apellidoEstudiante = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Dui { get => dui; set => dui = value; }
        public int IdEspecialidad { get => idEspecialidad; set => idEspecialidad = value; }
    }
}
