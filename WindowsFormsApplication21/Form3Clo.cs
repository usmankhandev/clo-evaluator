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

namespace WindowsFormsApplication21
{
    public partial class Form3Clo : Form
    {
        string connectionString = "Data Source=DESKTOP-OQV6IBM;Initial Catalog=ProjectB;Integrated Security=True;";
        public object Response { get; private set; }
        string StdId;
        public Form3Clo()
        {
            InitializeComponent();
        }

        public Form3Clo(string name, string Id)
        {
            InitializeComponent();
            textBox1.Text = name;
            StdId = Id;
            button1.Text = "Update Clo's";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!="")
            {
                {
                    if (button1.Text == "Add Clo's")
                    {
                        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-OQV6IBM;Initial Catalog=ProjectB;Integrated Security=True");
                        conn.Open();
                        string Query = "insert into Clo(Name,DateCreated,DateUpdated) values('" + this.textBox1.Text + "','" + DateTime.Now + "','" + DateTime.Now + "')";
                        SqlCommand cmd = new SqlCommand(Query, conn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data Successfully Added");
                    }
                    else
                    {
                        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-OQV6IBM;Initial Catalog=ProjectB;Integrated Security=True");
                        conn.Open();

                        string Query = "update Clo set Name='" + this.textBox1.Text + "',DateUpdated='" + DateTime.Now + "'  where Id = '" + StdId + "'";
                        SqlCommand cmd = new SqlCommand(Query, conn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data Updated Successfully");

                    }
                    DGVClo f = new DGVClo();
                    this.Hide();
                    f.Show();
                }


            }
            else
            {
                MessageBox.Show("Please fill the required fields");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DGVClo h = new DGVClo();
            this.Hide();
            h.Show();
        }

        private void Form3Clo_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DGVClo h = new DGVClo();
            this.Hide();
            h.Show();
        }
    }
}
