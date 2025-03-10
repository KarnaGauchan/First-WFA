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
namespace Login
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(Localdb)\mssqllocaldb;Initial Catalog=UserRegistrationDB;Integrated Security=True;Pooling=False";
            SqlConnection sqlcon = new SqlConnection(connectionString);
            sqlcon.Open();
            string query="select * from tblUser where Username ='" + txtUsername.Text.Trim() + "' and password = '" + txtPassword.Text.Trim()+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dtb = new DataTable();
            sda.Fill(dtb);
            if(dtb.Rows.Count==1)
            {
                dashBoardForm dashForm = new dashBoardForm();
                this.Hide();
                dashForm.Show();
            }
            else
            {
                MessageBox.Show("Invalid Login");
            }
        }
    }
}
