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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = employees;

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
            // Filter the employees list — keep only those whose Name contains the search text
            // Where() loops through each employee (x) and checks the condition
            var search = employees.Where(x => x.Name.Contains(txtSearch.Text));

            // Convert the filtered result to a List and bind it to the grid
            // ToList() is needed because DataSource expects a List, not a raw query
            dataGridView1.DataSource = search.ToList();
        }
    }
}
