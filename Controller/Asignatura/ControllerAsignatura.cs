using Refuerzo2024.Model.DAO;
using Refuerzo2024.View.Asignaturas;
using Refuerzo2024.View.Estudiantes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Refuerzo2024.Controller.Asignatura
{
    internal class ControllerAsignatura
    {
        ViewAsigntura objAsignatura;


        public ControllerAsignatura(ViewAsigntura objAsignatura)
        {
            this.objAsignatura = objAsignatura;
            //Manejar eventos que surjan en la vista
            objAsignatura.Load += new EventHandler(CargaInicial);
            objAsignatura.btnAgregar.Click += new EventHandler(RegistrarAsignatura);
            objAsignatura.dvgAsignaturas.CellClick += new DataGridViewCellEventHandler(SeleccionarDato);
            objAsignatura.btnActualizar.Click += new EventHandler(ActualizarAsignatura);
            objAsignatura.btnEliminar.Click += new EventHandler(EliminarAsignatura);
            objAsignatura.btnBuscar.Click += new EventHandler(BuscarAsigntura);
        }

        public void SeleccionarDato(object sender, DataGridViewCellEventArgs e)
        {
            //Capturar la fila a la que se le dió click
            int pos = objAsignatura.dvgAsignaturas.CurrentRow.Index;
            //Enviar los datos del DataGridView hacia los controles
            objAsignatura.txtID.Text = objAsignatura.dvgAsignaturas[0, pos].Value.ToString();
            objAsignatura.txtNombre.Text = objAsignatura.dvgAsignaturas[1, pos].Value.ToString();
            objAsignatura.txtCodigo.Text = objAsignatura.dvgAsignaturas[2, pos].Value.ToString();
            objAsignatura.txtFacultad.Text = objAsignatura.dvgAsignaturas[3, pos].Value.ToString();
            objAsignatura.cmbEspecialidad.Text = objAsignatura.dvgAsignaturas[4, pos].Value.ToString();
        }

        public void CargaInicial(object sender, EventArgs e)
        {
            LlenarComboEspecialidades();
            LlenarDataGridViewAsignaturas();
        }


        private void LlenarComboEspecialidades()
        {
            //Se crea objeto del DAOEstudiantes para accesar a todos los metodos contenidos en la clase.
            DAOAsignatura obj = new DAOAsignatura();
            //Se crea un DataSet que almacenará los valores que retorne el metodo.
            DataSet ds = obj.ObtenerEspecialidades();
            //Llenamos el combobox
            objAsignatura.cmbEspecialidad.DataSource = ds.Tables["Especialidades"];
            //Se indica que campo se mostrará al usuario
            objAsignatura.cmbEspecialidad.DisplayMember = "nombreEspecialidad";
            //Se indica que valor será seleccionado dependiendo de lo que elija el usuario
            objAsignatura.cmbEspecialidad.ValueMember = "idEspecialidad";
        }


        private void LlenarDataGridViewAsignaturas()
        {
            //Se crea objeto del DAOEstudiantes para accesar a todos los metodos contenidos en la clase.
            DAOAsignatura obj = new DAOAsignatura();
            //Se crea un DataSet que almacenará los valores que retorne el metodo.
            DataSet ds = obj.ObtenerAsignatura();
            //Llenamos el combobox
            objAsignatura.dvgAsignaturas.DataSource = ds.Tables["ViewAsignatura"];
        }

        public void RegistrarAsignatura(object sender, EventArgs e)
        {
            DAOAsignatura data = new DAOAsignatura();
            //Guardar en los atributos del DTO todos los valores contenidos en los componentes del formulario
            data.NombreAsignaturas = objAsignatura.txtNombre.Text.Trim();
            data.CodigoAsignatura = objAsignatura.txtCodigo.Text.Trim();
            data.Facultad1 = objAsignatura.txtFacultad.Text.Trim();
            data.IdEspecilidad = (int)objAsignatura.cmbEspecialidad.SelectedValue;
            //Se invoca al metodo RegistrarEstudiante y se verifica si su retorno es TRUE, de ser así significa que los datos pudieron ser registrados correctamente, de lo contrario, no se pudo registrar los valores.
            if (data.RegistrarAsignatura() == true)
            {
                MessageBox.Show("Datos registrados correctamente", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo guardar los datos", "Proceso incompleto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void ActualizarAsignatura(object sender, EventArgs e)
        {
            DAOAsignatura data = new DAOAsignatura();
            //Guardar en los atributos del DTO todos los valores contenidos en los componentes del formulario
            data.IdAsignaturas = int.Parse(objAsignatura.txtID.Text.Trim().ToString());
            data.NombreAsignaturas = objAsignatura.txtNombre.Text.Trim();
            data.CodigoAsignatura = objAsignatura.txtCodigo.Text.Trim();
            data.Facultad1 = objAsignatura.txtFacultad.Text.Trim();
            data.IdEspecilidad = (int)objAsignatura.cmbEspecialidad.SelectedValue;
            if (data.ActualizarAsignatura() == true)
            {
                MessageBox.Show("Los datos fueron actualizados correctamente", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LlenarDataGridViewAsignaturas();
            }
            else
            {
                MessageBox.Show("Los datos no pudieron ser actualizados.", "Proceso interrumpido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void EliminarAsignatura(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(objAsignatura.txtID.Text.Trim()))
            {
                MessageBox.Show("Seleccione un registro", "Seleccione un valor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DAOAsignatura data = new DAOAsignatura();
                data.IdAsignaturas = int.Parse(objAsignatura.txtID.Text);
                if (MessageBox.Show("¿Desea eliminar el registro seleccionado?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (data.EliminarAsignatura() == true)
                    {
                        MessageBox.Show("El dato fue eliminado correctamente", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LlenarDataGridViewAsignaturas();
                    }
                    else
                    {
                        MessageBox.Show("El registro no pudo ser eliminado", "Proceso interrumpido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        //PROBANDO 
        public void BuscarAsigntura(object sender, EventArgs e)
        {
            DAOAsignatura data = new DAOAsignatura();
            DataSet ds = data.BuscarAsignatura(objAsignatura.txtBuscar.Text.Trim());
            objAsignatura.dvgAsignaturas.DataSource = ds.Tables["ViewAsignatura"];
        }


    }
}
