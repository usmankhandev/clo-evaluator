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
    public partial class Form1 : Form
    {
        string connectionString = "Data Source=DESKTOP-OQV6IBM;Initial Catalog=ProjectB;Integrated Security=True;";
        public object Response { get; private set; }
        string StdId;
        public Form1()
        {
            InitializeComponent();
        }

        public Form1(string FirstName,string LastName,string Contact,string Email,string RegistrationNumber ,string Id)
        {
            InitializeComponent();
            textBox1.Text = FirstName;
            textBox2.Text = LastName;
            textBox3.Text = Contact;
            textBox4.Text = Email;
            textBox5.Text = RegistrationNumber;
            StdId = Id;
            button3.Text = "Update Student";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!="" && textBox2.Text!="" && textBox3.Text!="" && textBox4.Text!="" && textBox5.Text!="" && comboBox1.Text!="" )
            { if (button3.Text == "Add Student")
                {
                    SqlConnection conn = new SqlConnection("Data Source=DESKTOP-OQV6IBM;Initial Catalog=ProjectB;Integrated Security=True");
                    conn.Open();
                    int status = 5;
                    if (comboBox1.Text == "Active")
                    {
                        status = 5;
                    }
                    else
                    {
                        status = 6;
                    }
                    string Query = "insert into Student(FirstName,LastName,Contact,Email,RegistrationNumber,Status) values('" + this.textBox1.Text + "','" + this.textBox2.Text + "','" + this.textBox3.Text + "','" + this.textBox4.Text + "','" + this.textBox5.Text + "','" + status + "')";
                    SqlCommand cmd = new SqlCommand(Query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Successfully Added");
                }
                else
                {
                    SqlConnection conn = new SqlConnection("Data Source=DESKTOP-OQV6IBM;Initial Catalog=ProjectB;Integrated Security=True");
                    conn.Open();
                    int status = 5;
                    if (comboBox1.Text == "Active")
                    {
                        status = 5;
                    }
                    else
                    {
                        status = 6;
                    }
                    string Query = "update Student set FirstName='" + this.textBox1.Text + "',LastName='" + this.textBox2.Text + "',Contact='" + this.textBox3.Text + "',Email='" + this.textBox4.Text + "',RegistrationNumber='" + this.textBox5.Text + "',Status='" + status + "' where Id = '" + StdId + "'";
                    SqlCommand cmd = new SqlCommand(Query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Updated Successfuly");

                }
                Form2 f = new Form2();
                this.Hide();
                f.Show();
            }
            else
            {
                MessageBox.Show("Please fill all the fields ");
            }
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 h = new Form2();
            this.Hide();
            h.Show();
           
            


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3Clo h = new Form3Clo();
            this.Hide();
            h.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form3Clo h = new Form3Clo();
            this.Hide();
            h.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            FormRubric h = new FormRubric();
            this.Hide();
            h.Show();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Form2 h = new Form2();
            h.Show();
            this.Hide();
        }
    }
}
