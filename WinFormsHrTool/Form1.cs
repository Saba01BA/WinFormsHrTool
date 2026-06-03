using System.ComponentModel;
namespace WinFormsHrTool
{


    public partial class Form1 : Form
    {
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
        {
            if(dataGridView1.CurrentRow != null)
            {
                employees.RemoveAt(dataGridView1.CurrentRow.Index);
            }
        }
    }
}
