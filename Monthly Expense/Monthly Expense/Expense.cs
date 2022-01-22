using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using System.Globalization;

namespace Monthly_Expense
{
    public partial class Expense : Form
    {
        MySqlConnection sqlConn = new MySqlConnection();
        MySqlCommand sqlCmd = new MySqlCommand();
        DataTable sqldt1 = new DataTable();
        DataTable sqldt2 = new DataTable();
        string sqlQuery;
        MySqlDataAdapter DtA = new MySqlDataAdapter();
        MySqlDataReader sqlRd;
        DataSet DS = new DataSet();
        String server = "127.0.0.1";
        String username = "Rocky";
        String password = "Supayan@020109";
        String database = "monthly_expenses";
        String Name;
        String tot, mop, cur;
        public Expense()
        {
            InitializeComponent();
        }


        private void uploadData()
        {
            
            sqlConn.ConnectionString = "Server = " + server + ";" + "user Id = " + username + ";" + "password  = " + password + ";" + "database = " + database;
           
            sqldt1.Clear();
            sqlConn.Open();
            sqlCmd.Connection = sqlConn;
            
            sqlCmd.CommandText = "SELECT * FROM monthly_expenses.exp_details;";

            sqlRd = sqlCmd.ExecuteReader();
            sqldt1.Load(sqlRd);
            sqlRd.Close();
            sqlConn.Close();
           
            dtv_dis1.DataSource = sqldt1;
        }
        private void showdata()
        {
            sqlConn.ConnectionString = "Server = " + server + ";" + "user Id = " + username + ";" + "password  = " + password + ";" + "database = " + database;

            sqlConn.Open();
            sqlCmd.Connection = sqlConn;
            sqlCmd.CommandText = "SELECT * FROM monthly_expenses.exp_mast;";

            sqlRd = sqlCmd.ExecuteReader();
            sqldt2.Load(sqlRd);
            sqlRd.Close();
            sqlConn.Close();
            dtv_dis2.DataSource = null;
            dtv_dis2.DataSource = sqldt2;
        }
        private void Expense_Load(object sender, EventArgs e)
        {
            dtp_date.Format = DateTimePickerFormat.Custom;
            dtp_date.CustomFormat = "yyyy-MM-dd";
            dtp_date.Value = DateTime.Today;
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Homepage hp = new Homepage();
            hp.Show();
            hp.BringToFront();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txt_name.Clear();
            txt_amt.Clear();
            txt_remarks.Clear();
            if ((rb_dom.Checked = true) || (rb_in.Checked = true))
            {
                rb_dom.Checked = false;
                rb_in.Checked = false;
            }
            if ((rb_doller.Checked = true) || (rb_euro.Checked = true) || (rb_Rupees.Checked = true))
            {
                rb_doller.Checked = false;
                rb_euro.Checked = false;
                rb_Rupees.Checked = false;
            }
            if ((rb_cc.Checked = true) || (rb_csh.Checked = true) || (rb_nb.Checked = true))
            {
                rb_cc.Checked = false;
                rb_csh.Checked = false;
                rb_nb.Checked = false;
            }
            dtp_date.Value = DateTime.Today;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            sqlConn.ConnectionString = "Server = " + server + ";" + "user Id = " + username + ";" + "password  = " + password + ";" + "database = " + database;
            try
            {
                sqlConn.Open();
                sqlQuery = "select `Unique_ID` from exp_mast where `First_Name` = '" + txt_name.Text + "'";
                sqlCmd = new MySqlCommand(sqlQuery, sqlConn);
                sqlRd = sqlCmd.ExecuteReader();
                sqlRd.Read();
                Name = sqlRd.GetString("Unique_ID");
                sqlConn.Close();
                MessageBox.Show("Selected !");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                txt_id.Text = Name;
                sqlConn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sqlConn.ConnectionString = "Server = " + server + ";" + "user Id = " + username + ";" + "password  = " + password + ";" + "database = " + database;
            
            try
            {
                if (rb_in.Checked == true)
                {
                    tot = "International";
                }
                else
                {
                    tot = "Domestic";
                }

                if (rb_doller.Checked == true)
                {
                    cur = "Doller";
                }
                else if (rb_euro.Checked == true)
                {
                    cur = "Euro";
                }
                else
                {
                    cur = "Rupees";
                }

                if (rb_cc.Checked == true)
                {
                    mop = "Credit Card";
                }
                else if (rb_csh.Checked == true)
                {
                    mop = "Cash";
                }
                else
                {
                    mop = "Net Banking";
                }
                
                sqlConn.Open();
                sqlQuery = "INSERT INTO monthly_expenses.exp_details (`Unique_ID`, `Date`, `TOT`, `Currency`, `MOP`, `Remarks`, `Amount`)" + "VALUES ('" + txt_id.Text.ToUpper() + "', '" + dtp_date.Text + "', '" + tot + "', '" + cur + "', '" + mop + "', '" + txt_remarks.Text + "', '" + txt_amt.Text + "')";
                sqlCmd = new MySqlCommand(sqlQuery, sqlConn);
                sqlRd = sqlCmd.ExecuteReader();
                sqlConn.Close();

                MessageBox.Show("Data Entry Successful");
                txt_name.Clear();
                txt_amt.Clear();
                txt_remarks.Clear();
                if ((rb_dom.Checked = true) || (rb_in.Checked = true))
                {
                    rb_dom.Checked = false;
                    rb_in.Checked = false;
                }
                if ((rb_doller.Checked = true) || (rb_euro.Checked = true) || (rb_Rupees.Checked = true))
                {
                    rb_doller.Checked = false;
                    rb_euro.Checked = false;
                    rb_Rupees.Checked = false;
                }
                if ((rb_cc.Checked = true) || (rb_csh.Checked = true) || (rb_nb.Checked = true))
                {
                    rb_cc.Checked = false;
                    rb_csh.Checked = false;
                    rb_nb.Checked = false;
                }
                dtp_date.Value = DateTime.Today;
            }
            catch (Exception ex)
            {
                string message;
                message = ex.Message;
                if(message == "Cannot add or update a child row: a foreign key constraint fails (`monthly_expense`.`exp_details`, CONSTRAINT `Unique ID` FOREIGN KEY (`Unique_ID`) REFERENCES `exp_mast` (`Unique_ID`))")
                {
                    MessageBox.Show("Unique ID not present");
                }
                else
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                txt_name.Clear();
                txt_amt.Clear();
                txt_remarks.Clear();
                if ((rb_dom.Checked = true) || (rb_in.Checked = true))
                {
                    rb_dom.Checked = false;
                    rb_in.Checked = false;
                }
                if ((rb_doller.Checked = true) || (rb_euro.Checked = true) || (rb_Rupees.Checked = true))
                {
                    rb_doller.Checked = false;
                    rb_euro.Checked = false;
                    rb_Rupees.Checked = false;
                }
                if ((rb_cc.Checked = true) || (rb_csh.Checked = true) || (rb_nb.Checked = true))
                {
                    rb_cc.Checked = false;
                    rb_csh.Checked = false;
                    rb_nb.Checked = false;
                }
                dtp_date.Value = DateTime.Today;
                txt_id.Clear();
                sqlConn.Close();
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            uploadData();
            dtv_dis1.Columns[1].DefaultCellStyle.Format = "yyyy-MM-dd";

        }

        private void button5_Click(object sender, EventArgs e)
        {
            showdata();
        }

        private void dtv_dis1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txt_id.Text = dtv_dis1.SelectedRows[0].Cells[0].Value.ToString();
            txt_amt.Text = dtv_dis1.SelectedRows[0].Cells[6].Value.ToString();
            txt_remarks.Text = dtv_dis1.SelectedRows[0].Cells[5].Value.ToString();
            String date = dtv_dis1.SelectedRows[0].Cells[1].Value.ToString();
            DateTime dt = Convert.ToDateTime(date);
            dtp_date.Value = dt;
            tot = dtv_dis1.SelectedRows[0].Cells[2].Value.ToString();
            mop = dtv_dis1.SelectedRows[0].Cells[4].Value.ToString();
            cur = dtv_dis1.SelectedRows[0].Cells[3].Value.ToString();
            if (tot == "Domestic")
            {
                rb_dom.Checked = true;
            }
            else
            {
                rb_in.Checked = true;
            }
            if (mop == "Cash")
            {
                rb_csh.Checked = true;
            }
            else if (mop == "Credit Card")
            {
                rb_cc.Checked = true;
            }
            else
            {
                rb_nb.Checked = true;
            }
            if (cur == "Doller")
            {
                rb_doller.Checked = true;
            }
            else if (cur == "Euro")
            {
                rb_euro.Checked = true;
            }
            else
            {
                rb_Rupees.Checked = true;
            }

        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            sqlConn.ConnectionString = "Server = " + server + ";" + "user Id = " + username + ";" + "password  = " + password + ";" + "database = " + database;
            try
            {
                sqlConn.Open();
                sqlCmd.Connection = sqlConn;
                sqlQuery = "Delete From monthly_expenses.exp_details where `Unique_ID` = '" + txt_id.Text + "'";
                sqlCmd = new MySqlCommand(sqlQuery, sqlConn);
                sqlRd = sqlCmd.ExecuteReader();
                textBox1.Text = txt_id.Text;
                sqlConn.Close();
                MessageBox.Show("Successfully Deleted");

            }
            catch (Exception ex)
            {
                if (MessageBox.Show("Records related to this Unique ID is Present in Record Master. Delete Those Record Before.", "Alert", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Text = Name;
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            sqlConn.ConnectionString = "Server = " + server + ";" + "user Id = " + username + ";" + "password  = " + password + ";" + "database = " + database;
            sqlConn.Open();


            try
            {
                MySqlCommand sqlCmd = new MySqlCommand();
                sqlCmd.Connection = sqlConn;
                sqlCmd.CommandText = "UPDATE `monthly_expenses`.`exp_details` SET `Unique_Id`=@UniqueID,`Date`=@date,`TOT`=@tot,`Currency`=@cur,`MOP`=@mop,`Remarks`=@rem,`Amount`=@amt  WHERE(`Unique_ID` = @UniqueID)";
                if (rb_in.Checked == true)
                {
                    tot = "International";
                }
                else
                {
                    tot = "Domestic";
                }

                if (rb_doller.Checked == true)
                {
                    cur = "Doller";
                }
                else if (rb_euro.Checked == true)
                {
                    cur = "Euro";
                }
                else
                {
                    cur = "Rupees";
                }

                if (rb_cc.Checked == true)
                {
                    mop = "Credit Card";
                }
                else if (rb_csh.Checked == true)
                {
                    mop = "Cash";
                }
                else
                {
                    mop = "Net Banking";
                }


                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@UniqueID", txt_id.Text);
                sqlCmd.Parameters.AddWithValue("@date", dtp_date.Text);
                sqlCmd.Parameters.AddWithValue("@tot",tot);
                sqlCmd.Parameters.AddWithValue("@cur", cur);
                sqlCmd.Parameters.AddWithValue("@mop", mop);
                sqlCmd.Parameters.AddWithValue("@rem", txt_remarks.Text);
                sqlCmd.Parameters.AddWithValue("@amt", txt_amt.Text);
                
                sqlCmd.ExecuteNonQuery();
                sqlConn.Close();
                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                txt_name.Clear();
                txt_amt.Clear();
                txt_remarks.Clear();
                if ((rb_dom.Checked = true) || (rb_in.Checked = true))
                {
                    rb_dom.Checked = false;
                    rb_in.Checked = false;
                }
                if ((rb_doller.Checked = true) || (rb_euro.Checked = true) || (rb_Rupees.Checked = true))
                {
                    rb_doller.Checked = false;
                    rb_euro.Checked = false;
                    rb_Rupees.Checked = false;
                }
                if ((rb_cc.Checked = true) || (rb_csh.Checked = true) || (rb_nb.Checked = true))
                {
                    rb_cc.Checked = false;
                    rb_csh.Checked = false;
                    rb_nb.Checked = false;
                }
                dtp_date.Value = DateTime.Today;
                txt_id.Clear();
                sqlConn.Close();
            }
        }
    }
}
