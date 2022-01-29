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
    public partial class frmDocente : Form
    {
        public frmDocente()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(tbNombre.Text != "" && tbApellidoPaterno.Text != "" && tbPassword.Text != ""){
                try
                {
                    string id = tbNombre.Text.Substring(0, 3) + DateTime.Now.ToString("yyhhss");
                    string cmd = string.Format("EXEC SP_AgregarProfesor '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}'", id.ToUpper(), tbNombre.Text.ToUpper(), tbApellidoPaterno.Text.ToUpper(), tbApellidoMaterno.Text.ToUpper(), tbTelefono.Text.ToString(), tbEmail.Text.ToUpper(), tbPassword.Text);
                    Utilidades.Ejecutar(cmd);
                    tbNombre.Text = "";
                    tbApellidoPaterno.Text = "";
                    tbApellidoMaterno.Text = "";
                    tbTelefono.Text = "";
                    tbEmail.Text = "";
                    tbPassword.Text = "";
                    MessageBox.Show("Profesor agregado. Tu ID es: " + id);
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error: " + error);
                }
            }
            else
            {
                MessageBox.Show("Campo nombre, apellido o contrasesña vacio");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string cmd = string.Format("EXEC SP_EliminarProfesor '{0}'", tbIdProfesor.Text.ToUpper());
                if (tbIdProfesor.Text != "")
                {
                    if (MessageBox.Show("¿Seguro que desea eliminar al usuario?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        Utilidades.Ejecutar(cmd);
                        tbIdProfesor.Text = "";
                        MessageBox.Show("Usuario eliminado");
                    }
                }
                else
                {
                    MessageBox.Show("Campo ID vacio", "Campo vacio");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error);
            }
        }
    }
}
