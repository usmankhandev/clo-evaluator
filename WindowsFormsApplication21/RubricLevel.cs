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
    public partial class RubricLevel : Form
    {
        string connectionString = "Data Source=DESKTOP-OQV6IBM;Initial Catalog=ProjectB;Integrated Security=True;";
        public object Response { get; private set; }
        string StdId;
        public RubricLevel()
        {
            InitializeComponent();
        }

        public RubricLevel(string Details, string Id)
        {
            InitializeComponent();
            richTextBox1.Text = Details;
            StdId = Id;
            button1.Text = "Update RubricLevel";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            RubricLevelGV h = new RubricLevelGV();
            this.Hide();
            h.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "" && comboBox1.Text != "")
            {


                string RubricId = (comboBox1.SelectedItem as ComboboxItem).Value.ToString();
                if (button1.Text == "Add RubricLevel")
                {
                    SqlConnection conn = new SqlConnection("Data Source=DESKTOP-OQV6IBM;Initial Catalog=ProjectB;Integrated Security=True");
                    conn.Open();
                    string Query = "insert into RubricLevel(Details,RubricId,MeasurementLevel) values('" + this.richTextBox1.Text + "','" + RubricId + "','" + this.textBox1.Text + "')";
                    SqlCommand cmd = new SqlCommand(Query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("RubricLevel Successfully Added");
                }
                else
                {
                    SqlConnection conn = new SqlConnection("Data Source=DESKTOP-OQV6IBM;Initial Catalog=ProjectB;Integrated Security=True");
                    conn.Open();
                    string Query = "update RubricLevel set Details='" + this.richTextBox1.Text + "',RubricId='" + RubricId + "',MeasurementLevel = '"+ this.textBox1.Text + "'  where Id = '" + StdId + "'";
                    SqlCommand cmd = new SqlCommand(Query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("RubricLevel Updated Successfuly");

                }
                RubricLevelGV h = new RubricLevelGV();
                this.Hide();
                h.Show();
            }
            else
            {
                MessageBox.Show("Please fill all the required fields");
            }
        }

        private void RubricLevel_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-OQV6IBM;Initial Catalog=ProjectB;Integrated Security=True");
            conn.Open();
            string query1 = "Select * from Rubric";
            SqlCommand command = new SqlCommand(query1, conn);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    ComboboxItem item = new ComboboxItem();
                    item.Text = Convert.ToString(reader["Details"]);
                    item.Value = Convert.ToString(reader["Id"]);

                    comboBox1.Items.Add(item);

                }
            }
        }
    }
}
