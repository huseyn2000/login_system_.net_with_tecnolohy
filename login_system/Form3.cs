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


namespace login_system
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            var frm = this.Owner;

            var ctl = frm.Controls.Find("textboxOnform1", true).FirstOrDefault() as
    Control;
            TextBox Txt = (TextBox)ctl;

            //And then you can use It 
            textboxt1.Text = Txt.Text;

        }


        public void doldur()
        {
            #region connected get reader
            SqlConnection con = new SqlConnection();
            con = new SqlConnection(Class1.GetConnectionString());
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("Select * from CONTACTS", con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlDataReader dr = cmd.ExecuteReader();

            DataTable dt = new DataTable();

            dt.Load(dr);

            dataGridView1.DataSource = dt;

            con.Close();
            #endregion connected 
        }


        private void aDDToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form4 form4 = new Form4();
            form4.Show();


        }

        private void uPDATEToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewRow Row = dataGridView1.CurrentRow;


            textBox1.Tag = Row.Cells["ID"].Value.ToString();

            textBox1.Text = Row.Cells["NAME"].Value.ToString();
            textBox2.Text = Row.Cells["SURNAME"].Value.ToString();
            textBox3.Text = Row.Cells["BIRTHPLACE"].Value.ToString();
            textBox4.Text = Row.Cells["IDENTITYNO"].Value.ToString();
            textBox5.Text = Row.Cells["IDENTITYPINCODE"].Value.ToString();




        }
    }
}
