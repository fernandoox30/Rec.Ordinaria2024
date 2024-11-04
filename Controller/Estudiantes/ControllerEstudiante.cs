using Refuerzo2024.Model.DAO;
using Refuerzo2024.View.Estudiantes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Refuerzo2024.Controller.Estudiantes
{
    internal class ControllerEstudiante
    {
        ViewEstudiantes objEstudiantes;

        public ControllerEstudiante(ViewEstudiantes objEstudiantes)
        {
            this.objEstudiantes = objEstudiantes;
            //Manejar eventos que surjan en la vista
            objEstudiantes.Load += new EventHandler(CargaInicial);
            objEstudiantes.btnAgregar.Click += new EventHandler(RegistrarEstudiante);
            objEstudiantes.dgvEstudiantes.CellClick += new DataGridViewCellEventHandler(SeleccionarDato);
            objEstudiantes.btnActualizar.Click += new EventHandler(ActualizarEstudiante);
            objEstudiantes.btnEliminar.Click += new EventHandler(EliminarEstudiante);
            objEstudiantes.btnBuscar.Click += new EventHandler(BuscarEstudiante);
        }

        public void SeleccionarDato(object sender, DataGridViewCellEventArgs e)
        {
            //Capturar la fila a la que se le dió click
            int pos = objEstudiantes.dgvEstudiantes.CurrentRow.Index;
            //Enviar los datos del DataGridView hacia los controles
            objEstudiantes.txtID.Text = objEstudiantes.dgvEstudiantes[0, pos].Value.ToString();
            objEstudiantes.txtNombres.Text = objEstudiantes.dgvEstudiantes[1, pos].Value.ToString();
            objEstudiantes.txtApellidos.Text = objEstudiantes.dgvEstudiantes[2, pos].Value.ToString();
            objEstudiantes.dtNacimiento.Text = objEstudiantes.dgvEstudiantes[3, pos].Value.ToString();
            objEstudiantes.txtTelefono.Text = objEstudiantes.dgvEstudiantes[4, pos].Value.ToString();
            objEstudiantes.txtCorreo.Text = objEstudiantes.dgvEstudiantes[5, pos].Value.ToString();
            objEstudiantes.txtDocumento.Text = objEstudiantes.dgvEstudiantes[6, pos].Value.ToString();
            objEstudiantes.cmbEspecialidad.Text = objEstudiantes.dgvEstudiantes[7, pos].Value.ToString();
        }

        public void CargaInicial(object sender, EventArgs e)
        {
            LlenarComboEspecialidades();
            LlenarDataGridViewEstudiantes();
        }

        private void LlenarComboEspecialidades()
        {
            //Se crea objeto del DAOEstudiantes para accesar a todos los metodos contenidos en la clase.
            DAOEstudiantes obj = new DAOEstudiantes();
            //Se crea un DataSet que almacenará los valores que retorne el metodo.
            DataSet ds = obj.ObtenerEspecialidades();
            //Llenamos el combobox
            objEstudiantes.cmbEspecialidad.DataSource = ds.Tables["Especialidades"];
            //Se indica que campo se mostrará al usuario
            objEstudiantes.cmbEspecialidad.DisplayMember = "nombreEspecialidad";
            //Se indica que valor será seleccionado dependiendo de lo que elija el usuario
            objEstudiantes.cmbEspecialidad.ValueMember = "idEspecialidad";
        }

        private void LlenarDataGridViewEstudiantes()
        {
            //Se crea objeto del DAOEstudiantes para accesar a todos los metodos contenidos en la clase.
            DAOEstudiantes obj = new DAOEstudiantes();
            //Se crea un DataSet que almacenará los valores que retorne el metodo.
            DataSet ds = obj.ObtenerEstudiantes();
            //Llenamos el combobox
            objEstudiantes.dgvEstudiantes.DataSource = ds.Tables["ViewEstudiante"];
        }

        public void RegistrarEstudiante(object sender, EventArgs e)
        {
            DAOEstudiantes data = new DAOEstudiantes();
            //Guardar en los atributos del DTO todos los valores contenidos en los componentes del formulario
            data.NombreEstudiante = objEstudiantes.txtNombres.Text.Trim();
            data.ApellidoEstudiante = objEstudiantes.txtApellidos.Text.Trim();
            data.FechaNacimiento = objEstudiantes.dtNacimiento.Value.Date;
            data.Telefono = objEstudiantes.txtTelefono.Text.Trim();
            data.Correo = objEstudiantes.txtCorreo.Text.Trim();
            data.Dui = objEstudiantes.txtDocumento.Text.Trim();
            data.IdEspecialidad = (int)objEstudiantes.cmbEspecialidad.SelectedValue;
            //Se invoca al metodo RegistrarEstudiante y se verifica si su retorno es TRUE, de ser así significa que los datos pudieron ser registrados correctamente, de lo contrario, no se pudo registrar los valores.
            if (data.RegistrarEstudiante() == true)
            {
                MessageBox.Show("Datos registrados correctamente", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo guardar los datos", "Proceso incompleto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ActualizarEstudiante(object sender, EventArgs e)
        {
            DAOEstudiantes data = new DAOEstudiantes();
            //Guardar en los atributos del DTO todos los valores contenidos en los componentes del formulario
            data.IdEstudiante = int.Parse(objEstudiantes.txtID.Text.Trim().ToString());
            data.NombreEstudiante = objEstudiantes.txtNombres.Text.Trim();
            data.ApellidoEstudiante = objEstudiantes.txtApellidos.Text.Trim();
            data.FechaNacimiento = objEstudiantes.dtNacimiento.Value.Date;
            data.Telefono = objEstudiantes.txtTelefono.Text.Trim();
            data.Correo = objEstudiantes.txtCorreo.Text.Trim();
            data.Dui = objEstudiantes.txtDocumento.Text.Trim();
            data.IdEspecialidad = (int)objEstudiantes.cmbEspecialidad.SelectedValue;
            if (data.ActualizarEstudiante() == true)
            {
                MessageBox.Show("Los datos fueron actualizados correctamente", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LlenarDataGridViewEstudiantes();
            }
            else
            {
                MessageBox.Show("Los datos no pudieron ser actualizados.", "Proceso interrumpido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void EliminarEstudiante(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(objEstudiantes.txtID.Text.Trim()))
            {
                MessageBox.Show("Seleccione un registro", "Seleccione un valor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else
            {
                DAOEstudiantes data = new DAOEstudiantes();
                data.IdEstudiante = int.Parse(objEstudiantes.txtID.Text);
                if (MessageBox.Show("¿Desea eliminar el registro seleccionado?","Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (data.EliminarEstudiante() == true)
                    {
                        MessageBox.Show("El dato fue eliminado correctamente", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LlenarDataGridViewEstudiantes();
                    }
                    else
                    {
                        MessageBox.Show("El registro no pudo ser eliminado", "Proceso interrumpido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void BuscarEstudiante(object sender, EventArgs e)
        {
            DAOEstudiantes data = new DAOEstudiantes();
            DataSet ds = data.BuscarEstudiante(objEstudiantes.txtBuscar.Text.Trim());
            objEstudiantes.dgvEstudiantes.DataSource = ds.Tables["ViewEstudiante"];
        }
    }
}
