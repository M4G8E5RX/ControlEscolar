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
    public partial class PrincipalAdmin : Form
    {
        public PrincipalAdmin()
        {
            InitializeComponent();
        }

        private void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                Index index = new Index();
                index.Show();
            }
            else{
                e.Cancel = true;
            }
        }

        private void docenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdministrador frmAdministrador = new frmAdministrador();
            frmAdministrador.TopLevel = false;
            panel1.Controls.Clear();
            frmAdministrador.Show();

            panel1.Controls.Add(frmAdministrador);
        }

        private void alumnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDocente frmDocente = new frmDocente();
            frmDocente.TopLevel = false;
            panel1.Controls.Clear();
            frmDocente.Show();
            panel1.Controls.Add(frmDocente);
        }
    }
}
