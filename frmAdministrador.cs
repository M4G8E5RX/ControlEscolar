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
    public partial class frmAdministrador : Form
    {
        public frmAdministrador()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            frmConsultaAdmins frmConsultaAdmins = new frmConsultaAdmins();
            frmConsultaAdmins.Show();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string id = "Admin" + DateTime.Now.ToString("yydhhss");
            try{
                string cmd = string.Format("EXEC SP_AgregarAdministrador '{0}', '{1}','{2}'", id, tbNombre.Text, tbPassword.Text);
                Utilidades.Ejecutar(cmd);
                MessageBox.Show("Administrador agregado. Tu ID es: " + id);
            }
            catch(Exception error){
                MessageBox.Show("Error: " + error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try{
                string cmd = string.Format("EXEC SP_EliminarAdministrador '{0}', '{1}'", tbId.Text, tbNombre.Text);
                if(tbNombre.Text != ""){
                    if (MessageBox.Show("¿Seguro que desea eliminar al usuario?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes){
                        Utilidades.Ejecutar(cmd);
                        MessageBox.Show("Usuario eliminado");
                    }
                }
                else{
                    MessageBox.Show("Campo Nombre vacio", "Campo vacio");
                }
            }
            catch(Exception error){
                MessageBox.Show("Error: " + error);
            }

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
