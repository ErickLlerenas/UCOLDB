using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MaterialSkin;
using MaterialSkin.Controls;

namespace UdeCDB
{
    public partial class mainForm : MaterialForm
    {
        static String cadena = "Data Source=DESKTOP-4Q6316A\\SQLEXPRESS;Initial Catalog=escuela;Integrated Security=True";
        SqlConnection conn = new SqlConnection(cadena);

        public mainForm()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Green800, Primary.Green900, Primary.Green500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            String query = "SELECT * FROM users WHERE usuario = '" + txtUser.Text + "' AND pass = '" + txtPass.Text + "'";

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.Read())
                {
                    MessageBox.Show("Usuario Autenticado");
                    menuForm mF = new menuForm();
                    this.Hide();
                    mF.Show();
                }
                else
                {
                    MessageBox.Show("Revisa los datos. Usuario y/o Contraseña Incorrectos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_new_user_Click(object sender, EventArgs e)
        {
            /*String query = "INSERT INTO users (usuario,pass) VALUES ('" + txtUser.Text + "' , '" + txtPass.Text + "'";

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter sdr = cmd.ExecuteReader();

                if (sdr.Read())
                {
                    MessageBox.Show("Usuario Agregado");
                }
                else
                {
                    MessageBox.Show("Usuario no Agregado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }*/
        }
    }
}
