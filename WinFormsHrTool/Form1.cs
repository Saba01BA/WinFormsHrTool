// Needed for SAVING the Data.
using System.Text.Json;
// Needed for BindingList — lives in System.ComponentModel
using System.ComponentModel; 
namespace WinFormsHrTool
{


    public partial class Form1 : Form
    {
        // BindingList is like List<Employee> but automatically updates the UI
        // when items are added or removed — perfect for DataGridView binding
        BindingList<Employee> employees = new BindingList<Employee>();


        public Form1()
        {

            InitializeComponent();
            this.Text = "HR Management Tool";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;
            this.BackColor = ColorTranslator.FromHtml("#2b2b2b");
            // TextBoxes
            foreach (Control c in this.Controls)
            {
                if (c is TextBox tb)
                {
                    tb.BackColor = ColorTranslator.FromHtml("#3c3c3c");
                    tb.ForeColor = ColorTranslator.FromHtml("#ffffff");
                    tb.BorderStyle = BorderStyle.FixedSingle;
                }
                if (c is Label lbl)
                {
                    lbl.ForeColor = ColorTranslator.FromHtml("#ffffff");
                }
                if (c is Button btn)
                {
                    btn.BackColor = ColorTranslator.FromHtml("#0078d4");
                    btn.ForeColor = ColorTranslator.FromHtml("#ffffff");
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                }
            }

            // DataGridView styling
            dataGridView1.BackgroundColor = ColorTranslator.FromHtml("#2b2b2b");
            dataGridView1.GridColor = ColorTranslator.FromHtml("#555555");
            dataGridView1.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#3c3c3c");
            dataGridView1.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff");
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#0078d4");
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff");
            dataGridView1.EnableHeadersVisualStyles = false;
            this.Font = new Font("Segoe UI", 10f, FontStyle.Regular);
            // Bind the employees list to the grid on startup
            // From now on, any change to employees automatically reflects in the grid
            dataGridView1.DataSource = employees;

            // Check if a save file exists before trying to read it
            if (File.Exists("employees.json"))
            {
                // Read the raw JSON text from the file
                string json = File.ReadAllText("employees.json");

                // Convert the JSON string back into a List<Employee>
                var list = JsonSerializer.Deserialize<List<Employee>>(json);

                // Add each employee from the file into our BindingList
                foreach (var item in list)
                {
                    employees.Add(item);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string department = txtDepartment.Text;
            decimal salary = decimal.Parse(txtSalary.Text);

            Employee emp = new Employee();
            emp.Name = name;
            emp.Salary = salary;
            emp.Department = department;

            employees.Add(emp);


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {    // Check if a row is actually selected to avoid crashes
            if (dataGridView1.CurrentRow != null)
            {
                // Remove the employee at the selected rows position in the list
                employees.RemoveAt(dataGridView1.CurrentRow.Index);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                dataGridView1.DataSource = employees;
            }

            else
            {
                // Filter the employees list — keep only those whose Name contains the search text
                // Where() loops through each employee (x) and checks the condition
                var search = employees.Where(x => x.Name.Contains(txtSearch.Text));

                // Convert the filtered result to a List and bind it to the grid
                // ToList() is needed because DataSource expects a List, not a raw query
                dataGridView1.DataSource = search.ToList();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Serialize the entire employees list into a JSON string
            string json = JsonSerializer.Serialize(employees);

            // Write the JSON string to a file — saved in the same folder as the app
            File.WriteAllText("employees.json", json);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                var toChange = employees[dataGridView1.CurrentRow.Index];
                txtName.Text = toChange.Name;
                txtDepartment.Text = toChange.Department;
                txtSalary.Text = Convert.ToString(toChange.Salary);
                btnSave.Enabled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var toChange = employees[dataGridView1.CurrentRow.Index];
            toChange.Name = txtName.Text;
            toChange.Department = txtDepartment.Text;
            toChange.Salary = decimal.Parse(txtSalary.Text);
            btnSave.Enabled = false;
            txtName.Text = "";
            txtSalary.Text = "";
            txtDepartment.Text = "";
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string csv = "Name,Department,Salary\n";
            foreach (var emp in employees)
            {
                csv += emp.Name + "," + emp.Department + "," + emp.Salary+"\n";
                File.WriteAllText("employees.csv", csv);
            }
        }
    }
}
