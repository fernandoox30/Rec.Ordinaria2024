using Refuerzo2024.Model.Conexion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refuerzo2024.Model.DTO
{
    internal class DTOAsignatura : dbContext
    {
        private int idAsignaturas;
        private string nombreAsignaturas;
        private string codigoAsignatura;
        private string Facultad;
        private int idEspecilidad;

        public int IdAsignaturas { get => idAsignaturas; set => idAsignaturas = value; }
        public string NombreAsignaturas { get => nombreAsignaturas; set => nombreAsignaturas = value; }
        public string CodigoAsignatura { get => codigoAsignatura; set => codigoAsignatura = value; }
        public string Facultad1 { get => Facultad; set => Facultad = value; }
        public int IdEspecilidad { get => idEspecilidad; set => idEspecilidad = value; }
    }
}
