using FicLib;
using System.Data;
namespace ControlEscolar
{
    public partial class frmSesionAdmin : Form
    {
        public frmSesionAdmin()
        {
            InitializeComponent();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
           try{
                string cmd = String.Format("SELECT * FROM Administradores WHERE idUsuario = '{0}' AND Contrasena ='{1}'", tbUsuario.Text.Trim(), tbPassword.Text.Trim());

                DataSet DS = Utilidades.Ejecutar(cmd);

                string usuario = DS.Tables[0].Rows[0]["idUsuario"].ToString().Trim();
                string password = DS.Tables[0].Rows[0]["Contrasena"].ToString().Trim();

                if(usuario == tbUsuario.Text.Trim() && password == tbPassword.Text.Trim()){
                    PrincipalAdmin principal = new PrincipalAdmin();
                    this.Hide();
                    principal.Show();
                }
            }
            catch (Exception error){
                MessageBox.Show("Usuario o Contraseña incorrecto" + error);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            Index index = new Index();
            index.Show();
        }

        private void frmSesionAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Index index = new Index();
            index.Show();
        }
    }
}