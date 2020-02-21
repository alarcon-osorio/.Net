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

namespace iot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=JEI; Initial Catalog=iot; Integrated Security=True");

        public void logaer(string usuario, string contrasena) {

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT usuario, tipousuario FROM usuarios WHERE usuario= @usuario AND contrasena= @pass", con);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("pass", contrasena);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if(dt.Rows.Count == 1){

                    this.Hide();
                    if (dt.Rows[0][1].ToString() == "Administrador"){
                        new Admin(dt.Rows[0][0].ToString()).Show(); 
                    }
                    
                else if (dt.Rows[0][1].ToString() == "usuario"){
                        new usuario(dt.Rows[0][0].ToString()).Show();
                    }

            } else {
                MessageBox.Show("Usuario y/o Contraseña incorrectos");
            }

        }
        catch (Exception e)
        {
        MessageBox.Show(e.Message);
        }
        finally            
        {
                con.Close();

        }

      }

        private void button1_Click(object sender, EventArgs e)
        {
            logaer(this.textBox1.Text, this.textBox2.Text);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("CREADO POR: JEISON ALARCON OSORIO");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Assign the asterisk to be the password character.
            textBox2.PasswordChar = '*';
        }
    }

}
