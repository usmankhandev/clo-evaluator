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
    public partial class FormRubric : Form
    {
        string connectionString = "Data Source=DESKTOP-OQV6IBM;Initial Catalog=ProjectB;Integrated Security=True;";
        public object Response { get; private set; }
        string StdId;
        public FormRubric()
        {
            InitializeComponent();
        }
        public FormRubric(string Details, string Id)
        {
            InitializeComponent();
            richTextBox1.Text = Details;
            StdId = Id;
            button1.Text = "Update Rubrics";
        }

        private void FormRubric_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-OQV6IBM;Initial Catalog=ProjectB;Integrated Security=True");
            conn.Open();
            string query1 = "Select * from Clo";
            SqlCommand command = new SqlCommand(query1, conn);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    ComboboxItem item = new ComboboxItem();
                    item.Text = Convert.ToString(reader["Name"]);
                    item.Value = Convert.ToString(reader["Id"]);

                    comboBox1.Items.Add(item);

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text!="" && comboBox1.Text!="")
            {


                string CloId = (comboBox1.SelectedItem as ComboboxItem).Value.ToString();
                if (button1.Text == "Add Rubrics")
                {
                    SqlConnection conn = new SqlConnection("Data Source=DESKTOP-OQV6IBM;Initial Catalog=ProjectB;Integrated Security=True");
                    conn.Open();
                    string Query = "insert into Rubric(Details,CloId) values('" + this.richTextBox1.Text + "','" + CloId + "')";
                    SqlCommand cmd = new SqlCommand(Query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Rubrics Successfully Added");
                }
                else
                {
                    SqlConnection conn = new SqlConnection("Data Source=DESKTOP-OQV6IBM;Initial Catalog=ProjectB;Integrated Security=True");
                    conn.Open();
                    string Query = "update Rubric set Details='" + this.richTextBox1.Text + "',CloId='" + CloId + "' where Id = '" + StdId + "'";
                    SqlCommand cmd = new SqlCommand(Query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Rubrics Updated Successfuly");

                }
                RubricsGV h = new RubricsGV();
                this.Hide();
                h.Show();
            }
            else
            {
                MessageBox.Show("Please fill all the required fields");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            RubricsGV h = new RubricsGV();
            this.Hide();
            h.Show();
        }
    }
}
