using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FicLib;

namespace ControlEscolar
{
    public partial class frmSesionAlumno : Form
    {
        public frmSesionAlumno()
        {
            InitializeComponent();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                string cmd = String.Format("SELECT * FROM Alumnos WHERE Usuario = '{0}' AND Contrasena ='{1}'", tbUsuario.Text.Trim(), tbPassword.Text.Trim());

                DataSet DS = Utilidades.Ejecutar(cmd);

                string usuario = DS.Tables[0].Rows[0]["Usuario"].ToString().Trim();
                string password = DS.Tables[0].Rows[0]["Contrasena"].ToString().Trim();

                if (usuario == tbUsuario.Text.Trim() && password == tbPassword.Text.Trim())
                {
                    MessageBox.Show("Sesión Iniciada");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Usuario o Contraseña incorrecto");
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            Index index = new Index();
            index.Show();
        }

        private void frmSesionAlumno_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Index index = new Index();
            index.Show();
        }
    }
}
