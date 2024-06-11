using Sirius_testapp.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Sirius_testapp
{
    public partial class Form2 : Form
    {
        private DBConnector _connector;
        private QueryExecutor _executor;
        private DataSet _ds;
        private DataTable _dt;
        private string _filtered_by = "FIO";
        Dictionary<int, string> statusList;

        public Form2(DBConnector connector)
        {
            InitializeComponent();
            _connector = connector;
            _executor = new QueryExecutor(_connector);
            Dictionary<int, string> statusList = new Dictionary<int, string>();
            LoadData();
            LoadStatusList();
            tb_filter.KeyDown += tb_filer_keyDown;
        }

        private void LoadStatusList()
        {
            statusList = _executor.GetStatusList();
            comboBoxStatus.DataSource = new BindingSource(statusList, null);
            comboBoxStatus.DisplayMember = "Value";
            comboBoxStatus.ValueMember = "Key";
        }

        private void LoadData()
        {
            try
            {
                _ds = _executor.GetDataSetFromStoredProcedure("dbo.GetEmployeeList1");
                dataGridView1.DataSource = _ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load data: {ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tb_filter.Text = "";
            dataGridView1.DataSource = _ds.Tables[0];
        }

        private void tb_filer_keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                string searchText = tb_filter.Text;

                var query = from DataRow row in _ds.Tables[0].AsEnumerable()
                            where row.Field<string>(_filtered_by).Contains(searchText)
                            select row;

                try
                {
                    _dt = query.CopyToDataTable();
                    dataGridView1.DataSource = _dt;
                }
                catch (Exception)
                {
                    MessageBox.Show("Не найдено значений");
                }

            }
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            _filtered_by = "FIO";
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            _filtered_by = "status_name";
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            _filtered_by = "department_name";
        }

        private void radioButton4_Click(object sender, EventArgs e)
        {
            _filtered_by = "post_name";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int selectedStatus = ((KeyValuePair<int, string>)comboBoxStatus.SelectedItem).Key;
            DateTime startDate = dateTimePickerStart.Value;
            DateTime endDate = dateTimePickerEnd.Value;
            bool isEmployed = radioButtonEmployed.Checked;

            _dt = _executor.GetEmployeeStatistics(selectedStatus, startDate, endDate, isEmployed);
            dataGridView1.DataSource = _dt;
        }

        private void radioButtonUnEmployed_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonEmployed.Checked = false;
        }

        private void radioButtonEmployed_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonUnEmployed.Checked = false;
        }

    }
}
