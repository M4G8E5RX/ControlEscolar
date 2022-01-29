using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlEscolar
{
    public partial class Index : Form
    {
        public Index()
        {
            InitializeComponent();
        }

        private void btnAdministrador_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmSesionAdmin frmSesionAdmin = new frmSesionAdmin();
            frmSesionAdmin.Show();
        }

        private void btnDocente_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmSesionDocente frmSesionDocente = new frmSesionDocente();
            frmSesionDocente.Show();
        }

        private void btnAlumno_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmSesionAlumno frmSesionAlumno = new frmSesionAlumno();
            frmSesionAlumno.Show();
        }

        private void Index_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
