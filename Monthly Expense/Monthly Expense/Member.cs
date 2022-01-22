using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Monthly_Expense
{
    public partial class Member : Form
    {
        MySqlConnection sqlConn = new MySqlConnection();
        MySqlCommand sqlCmd = new MySqlCommand();
        DataTable sqldt = new DataTable();
        string sqlQuery;
        MySqlDataAdapter DtA = new MySqlDataAdapter();
        MySqlDataReader sqlRd;
        DataSet DS = new DataSet();
        String server = "127.0.0.1";
        String username = "Rocky";
        String password = "Supayan@020109";
        String database = "monthly_expenses";
        string gen;
        public Member()
        {
            InitializeComponent();
        }
        private void uploadData()
        {
            sqlConn.ConnectionString = "Server = " + server + ";" + "user Id = " + username + ";" + "password  = " + password + ";" + "database = " + database;

            sqlConn.Open();
            sqlCmd.Connection = sqlConn;
            sqlCmd.CommandText = "SELECT * FROM monthly_expenses.exp_mast;";

            sqlRd = sqlCmd.ExecuteReader();
            sqldt.Load(sqlRd);
            sqlRd.Close();
            sqlConn.Close();

            dtv_Display.DataSource = sqldt;
        }
        private void btn_home_Click(object sender, EventArgs e)
        {
            Homepage hp = new Homepage();
            hp.Show();
            hp.BringToFront();
            this.Close();

        }
        private void btn_sub_Click(object sender, EventArgs e)
        {
            sqlConn.ConnectionString = "Server = " + server + ";" + "user Id = " + username + ";" + "password  = " + password + ";" + "database = " + database;
            try
            {
                if (rb_male.Checked)
                {
                    gen = "Male";
                }
                else
                {
                    gen = "Female";
                }
                sqlConn.Open();
                sqlQuery = "INSERT INTO `monthly_expenses`.`exp_mast` (`Unique_ID`, `First_Name`, `Last_Name`, `Address`, `Cont_No`,`Alt_Cont`, `Gender`)" + "VALUES ('" + txt_id.Text + "', '" + txt_fstn.Text + "', '" + txt_lstn.Text + "', '" + txt_loc.Text + "', '" + txt_cont.Text + "', '" + txt_altcont.Text + "', '" + gen + "')";
                sqlCmd = new MySqlCommand(sqlQuery,sqlConn);
                sqlRd = sqlCmd.ExecuteReader();
                sqlConn.Close();
                MessageBox.Show("Data Entry Successful");


                txt_fstn.Clear();
                txt_lstn.Clear();
                txt_loc.Clear();
                txt_cont.Clear();
                txt_altcont.Clear();
                if (rb_male.Checked)
                {
                    rb_male.Checked = false;
                }
                else
                {
                    rb_Female.Checked = false;
                }
                txt_id.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(txt_altcont.Text);
            }
            finally
            {
                sqlConn.Close();
               
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            uploadData();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            sqlConn.ConnectionString = "Server = " + server + ";" + "user Id = " + username + ";" + "password  = " + password + ";" + "database = " + database;
            sqlConn.Open();


            try
            {
                MySqlCommand sqlCmd=new MySqlCommand();
                sqlCmd.Connection = sqlConn;
                sqlCmd.CommandText = "UPDATE `monthly_expenses`.`exp_mast` SET `First_Name` = @FirstName, `Last_Name` = @LastName, `Address` = @Address, `Cont_No` = @ContactNumber, `Alt_Cont` = @AltNumber, `Gender` = @gen WHERE(`Unique_ID` = @UniqueID)";
                
                if (rb_male.Checked == true)
                {
                    gen = "Male";
                }
                else
                {
                    gen = "Female";
                }
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@UniqueID", txt_id.Text);
                sqlCmd.Parameters.AddWithValue("@FirstName", txt_fstn.Text);
                sqlCmd.Parameters.AddWithValue("@LastName", txt_lstn.Text);
                sqlCmd.Parameters.AddWithValue("@Address", txt_loc.Text);
                sqlCmd.Parameters.AddWithValue("@ContactNumber", txt_cont.Text);
                sqlCmd.Parameters.AddWithValue("@AltNumber", txt_altcont.Text);
                sqlCmd.Parameters.AddWithValue("@gen", gen);
                sqlCmd.ExecuteNonQuery();
                sqlConn.Close();
                MessageBox.Show("Done");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

                txt_fstn.Clear();
                txt_lstn.Clear();
                txt_loc.Clear();
                txt_cont.Clear();
                txt_altcont.Clear();
                if (rb_male.Checked)
                {
                    rb_male.Checked = false;
                }
                else
                {
                    rb_Female.Checked = false;
                }
                txt_id.Clear();
                sqlConn.Close();
            }
        }

        private void dtv_Display_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_id.Text = dtv_Display.SelectedRows[0].Cells[0].Value.ToString();
            txt_fstn.Text = dtv_Display.SelectedRows[0].Cells[1].Value.ToString();
            txt_lstn.Text = dtv_Display.SelectedRows[0].Cells[2].Value.ToString();
            txt_loc.Text = dtv_Display.SelectedRows[0].Cells[3].Value.ToString();
            txt_cont.Text = dtv_Display.SelectedRows[0].Cells[4].Value.ToString();
            txt_altcont.Text = dtv_Display.SelectedRows[0].Cells[5].Value.ToString();
            gen= dtv_Display.SelectedRows[0].Cells[6].Value.ToString();
            if (gen == "Male")
            {
                rb_male.Checked = true;
            }
            else
            {
                rb_Female.Checked = true;
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            sqlConn.ConnectionString = "Server = " + server + ";" + "user Id = " + username + ";" + "password  = " + password + ";" + "database = " + database;
            try
            {
                sqlConn.Open();
                sqlCmd.Connection = sqlConn;
                sqlQuery = "Delete From monthly_expenses.exp_mast where `Unique_ID` = '"+txt_id.Text+"'";
                sqlCmd = new MySqlCommand(sqlQuery, sqlConn);
                sqlRd = sqlCmd.ExecuteReader();
                textBox1.Text = txt_id.Text;
                sqlConn.Close();
                MessageBox.Show("Successfully Deleted");

            }
            catch(Exception ex)
            {
                if(MessageBox.Show("Records related to this Unique ID is Present in Record Master. Delete Those Record Before.", "Alert", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    Expense ep = new Expense();
                    ep.Show();
                    ep.BringToFront();
                    this.Hide();
                }
                
            }
            finally
            {
                sqlConn.Close();
            }
        }

        private void Member_Load(object sender, EventArgs e)
        {

        }
    }
}