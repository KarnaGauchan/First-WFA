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
namespace ContactApp
{
    public partial class Form1 : Form
    {
        SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\JaishankarShetty\source\repos\First WFA\ContactApp\ContactDB.mdf;Integrated Security=True;Connect Timeout=30");
        int ContactId = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(sqlCon.State==ConnectionState.Closed)
                {
                    sqlCon.Open();
                    if (btnSave.Text == "Save")
                    {
                        SqlCommand sqlCmd = new SqlCommand("AddOrEditContact", sqlCon);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@mode", "Add");
                        sqlCmd.Parameters.AddWithValue("@ContactId", ContactId);
                        sqlCmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@MobileNumber", txtMobileNumber.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                        sqlCmd.ExecuteNonQuery();
                        MessageBox.Show("Saved Successfully");
                        Reset();
                        getContactDetails();
                    }
                    else
                    {
                        SqlCommand sqlCmd = new SqlCommand("AddOrEditContact", sqlCon);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@mode", "Edit");
                        sqlCmd.Parameters.AddWithValue("@ContactId", ContactId);
                        sqlCmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@MobileNumber", txtMobileNumber.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                        sqlCmd.ExecuteNonQuery();
                        MessageBox.Show("Updated Successfully");
                        Reset();
                        getContactDetails();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Error occured");
            }
            finally
            {
                sqlCon.Close();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                getContactDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Record not found");
                throw;
            }
            
        }

        private void getContactDetails()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlAd = new SqlDataAdapter("ContactSearchOrView", sqlCon);
            sqlAd.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlAd.SelectCommand.Parameters.AddWithValue("@Name", txtSearchName.Text.Trim());
            DataTable dt = new DataTable();
            sqlAd.Fill(dt);
            dgvContacts.DataSource = dt;
            dgvContacts.Columns[0].Visible = false;
            sqlCon.Close();
        }

        private void dgvContacts_DoubleClick(object sender, EventArgs e)
        {
            if (dgvContacts.CurrentRow.Index!=-1)
            {
                ContactId =Convert.ToInt32( dgvContacts.CurrentRow.Cells[0].Value.ToString());
                txtName.Text = dgvContacts.CurrentRow.Cells[1].Value.ToString();
                txtMobileNumber.Text = dgvContacts.CurrentRow.Cells[2].Value.ToString();
                txtAddress.Text = dgvContacts.CurrentRow.Cells[3].Value.ToString();
                btnSave.Text = "Update";
                btnDelete.Enabled = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if(sqlCon.State==ConnectionState.Closed)
                {
                    sqlCon.Open();
                }
                SqlCommand sqlCmd = new SqlCommand("ContactDelete", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ContactId", ContactId);
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Record Deleted");
                Reset();
                getContactDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Record not found");
                throw;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
            getContactDetails();
        }

        private void Reset()
        {
            txtAddress.Text = txtMobileNumber.Text = txtName.Text = txtSearchName.Text = "";
            btnSave.Text = "Save";
            ContactId = 0;
            btnDelete.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Reset();
            getContactDetails();
        }
    }
}
