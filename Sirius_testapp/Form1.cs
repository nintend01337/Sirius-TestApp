using Sirius_testapp.Database;
using System.Configuration;
using System.Data.Common;
using System.Windows.Forms;

namespace Sirius_testapp
{
    public partial class Form1 : Form
    {
     

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            textBox1.Text = ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString;
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            var con = new DBConnector(textBox1.Text);
            con.TestConnection();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            var con = new DBConnector(textBox1.Text);
            con.TestConnection();

            Form2 f = new Form2(con);
            f.Show();
            this.Hide();

        }

        private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
        {
            textBox1.Enabled = !checkBox1.Checked;
        }
    }
}
