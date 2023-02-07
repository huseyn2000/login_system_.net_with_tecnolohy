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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        public void ADD_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Class1.GetConnectionString());
            con.Open();


            SqlCommand cmd = new SqlCommand("INSERT INTO CONTACTS " +
                "VALUES(@name,@surname,@company,@code_countryy,@prefix,@number,@INSERT_USER)", con);


            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@surname", textBox2.Text);
            cmd.Parameters.AddWithValue("@company", textBox3.Text);

            cmd.Parameters.AddWithValue("@code_countryy", textBox4.Text);
            cmd.Parameters.AddWithValue("@prefix", textBox5.Text);
            cmd.Parameters.AddWithValue("@number", textBox6.Text);
      
            cmd.Parameters.AddWithValue("@INSERT_USER",tut)


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            try
            {
                cmd.ExecuteNonQuery();

                MessageBox.Show("Success");

            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
                return;
            }

            finally
            {

                con.Close();
                con.Dispose(); //garbage collector

                Form3 frm3 = new Form3();
                frm3.Show();
                this.Hide();



            }
            //update, insert, delete - ExecuteNonQuery()

            //ExecuteScalar() - select
            //ExecuteReader() - select

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
