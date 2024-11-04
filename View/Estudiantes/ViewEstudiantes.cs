using Refuerzo2024.Controller.Estudiantes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Refuerzo2024.View.Estudiantes
{
    public partial class ViewEstudiantes : Form
    {
        //Constructor
        public ViewEstudiantes()
        {
            InitializeComponent();
            ControllerEstudiante next = new ControllerEstudiante(this);
        }
    }
}
