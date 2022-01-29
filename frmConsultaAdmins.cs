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
    public partial class frmConsultaAdmins : Form
    {
        public frmConsultaAdmins()
        {
            InitializeComponent();
        }

        public DataSet LlenarDataGrid(string tabla){
            DataSet DS;
            string cmd = string.Format("SELECT * FROM " + tabla);

            DS = Utilidades.Ejecutar(cmd);

            return DS;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count == 0){
                return;
            }else{
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void frmConsultaAdmins_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = LlenarDataGrid("Administradores").Tables[0];
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbBusqueda.Text.Trim()) == false){
                try{
                    DataSet DS;
                    string cmd = string.Format("SELECT * FROM Administradores WHERE Nombre LIKE('%" + tbBusqueda.Text.Trim() + "%')");

                    DS = Utilidades.Ejecutar(cmd);

                    dataGridView1.DataSource = DS.Tables[0];
                }
                catch(Exception){
                    MessageBox.Show("Usuario no encontrado");
                }
            }
        }
    }
}
