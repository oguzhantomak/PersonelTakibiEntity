using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using WFAPersonelTakibi.Models;

namespace WFAPersonelTakibi
{
    public partial class Form4 : MetroForm
    {
        public Form4()
        {
            InitializeComponent();
        }

        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeLastName { get; set; }
        public DateTime EmployeeBirthDate { get; set; }
        public string EmployeeMail { get; set; }
        public Gender EmployeeGender { get; set; }
        public string EmployeeAddress { get; set; }
        public string EmployeePhone { get; set; }
        public Department EmployeeDepartment { get; set; }
        public string EmployeeImageUrl { get; set; }

        private void Form4_Load(object sender, EventArgs e)
        {
            cmbDepartment.Items.AddRange(Enum.GetNames(typeof(Department)));

            txtFirstName.Text = EmployeeName;
            txtLastName.Text = EmployeeLastName;
            dtBirthDate.Value = EmployeeBirthDate;
            txtMail.Text = EmployeeMail;
            //Gender
            txtAddress.Text = EmployeeAddress;
            txtPhone.Text = EmployeePhone;
            
            cmbDepartment.SelectedItem = EmployeeDepartment;
            //image




            #region Denemeler


            //Employee emp1 = new Employee();
            //txtFirstName.Text = emp1.EmployeeName;
            //txtLastName.Text = emp1.EmployeeLastName;
            //dtBirthDate.Value = emp1.EmployeeBirthDate;
            //txtMail.Text = emp1.EmployeeMail;
            ////Gender eklenecek
            //txtAddress.Text = emp1.EmployeeAddress;
            //txtPhone.Text = emp1.EmployeePhone;
            //cmbDepartment.SelectedItem = emp1.EmployeeDepartment;





            //DataGridViewRow row = dgvEmployees.CurrentRow;
            //txtFirstName.Text = row.Cells["EmployeeID"].Value.ToString;


            //txtFirstName.Text;
            //txtLastName.Text;
            //dtBirthDate.Value;
            //txtMail.Text;
            //// Buraya radio button seçimi gelicek
            //txtAddress.Text;
            //txtPhone.Text;
            //cmbDepartment.SelectedItem; // veya cmbDepartment.Text yaparken bakıcam hangisi kullanacağımı. 
            #endregion
        }
        MyContext db = new MyContext();
        Employee emp2 = new Employee();
        EmployeeService emps = new EmployeeService();
        private void btnSave_Click(object sender, EventArgs e)
        {
            Employee emp2 = new Employee();

            emp2.EmployeeName = txtFirstName.Text;
            emp2.EmployeeLastName = txtLastName.Text;
            emp2.EmployeeBirthDate = dtBirthDate.Value;
            emp2.EmployeeMail = txtMail.Text;
            emp2.EmployeeAddress = txtAddress.Text;
            emp2.EmployeePhone = txtPhone.Text;
            emp2.EmployeeDepartment = (Department)Enum.Parse(typeof(Department), cmbDepartment.Text);

            emps.Update(emp2);

            
        }

        private void metroLink1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            this.Hide();
            frm.ShowDialog();
        }
    }
}
