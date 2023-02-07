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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Class1.GetConnectionString());
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT COUNT(*) FROM USERS WHERE USERNAME =  '"
                + textBox1.Text + "'AND + PASSWORD =  '" + textBox2.Text + "'",con );
            DataTable dt = new DataTable();

            adapter.Fill(dt);

           

            if (dt.Rows[0][0].ToString() == "1") 
            { 
            
                this.Hide();
                Form3 form3 = new Form3();
                form3.Show();
            
            }

            else
            {
                MessageBox.Show("CHECK USERNAME OR PASSWORD");
            }

        }
    }
}

