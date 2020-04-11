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

namespace LoginForm
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=localhost\sqlexpress;Initial Catalog=userLogin;Integrated Security=True");
            string query = "select * from logins where username='" + textBox1.Text.Trim() + "'and password='" + textBox2.Text.Trim()+"'";

            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dtb1 = new DataTable();
            sda.Fill(dtb1);
            if (dtb1.Rows.Count == 1)
            {
                frmLoggedIn objfrmLoggedIn = new frmLoggedIn();
                this.Hide();
                objfrmLoggedIn.Show();
            }
            else
            {
                MessageBox.Show("Please check your username and password");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
