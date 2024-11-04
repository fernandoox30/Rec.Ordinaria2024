using Refuerzo2024.Controller.Dashboard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Refuerzo2024.View.Dashboard
{
    public partial class ViewDashboard : Form
    {
        public ViewDashboard()
        {
            InitializeComponent();
            ControllerDashboard next = new ControllerDashboard(this);
        }
    }
}
