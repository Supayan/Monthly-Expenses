using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monthly_Expense
{
    public partial class Homepage : Form
    {
        public Homepage()
        {
            InitializeComponent();
        }

        private void btn_mem_Click(object sender, EventArgs e)
        {
            Member m = new Member();
            m.Show();
            m.BringToFront();
            this.Hide();
        }

        private void btn_exp_Click(object sender, EventArgs e)
        {
            Expense ep = new Expense();
            ep.Show();
            ep.BringToFront();
            this.Hide();
        }

        private void Homepage_Load(object sender, EventArgs e)
        {

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
