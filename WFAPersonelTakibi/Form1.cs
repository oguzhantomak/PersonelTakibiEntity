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
using MetroFramework.Controls;
using MetroFramework;

namespace WFAPersonelTakibi
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cmbDepartment.Items.AddRange(Enum.GetNames(typeof(Department)));
        }

        EmployeeService emp = new EmployeeService();
        private void BtnSave_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            employee.EmployeeName = txtFirstName.Text;
            employee.EmployeeLastName = txtLastName.Text;
            employee.EmployeeBirthDate = dtBirthDate.Value;
            employee.EmployeeMail = txtMail.Text;

            foreach (Control item in metroPanel1.Controls)
            {
                if (item is MetroRadioButton)
                {
                    MetroRadioButton rd = (MetroRadioButton)item;
                    if (rd.Checked)
                    {
                        employee.EmployeeGender = (Gender)Enum.Parse(typeof(Gender), rd.Text);
                    }

                }
            }
            employee.EmployeeAddress = txtAddress.Text;
            employee.EmployeePhone = txtPhone.Text;
            employee.EmployeeDepartment = (Department)Enum.Parse(typeof(Department), cmbDepartment.Text);

            bool result = emp.Add(employee);
            MetroMessageBox.Show(this,result? "Kayıt başarıyla eklendi":"Kayıt ekleme hatası","Kayıt ekleme bildirimi",MessageBoxButtons.OK,result?MessageBoxIcon.Hand:MessageBoxIcon.Error);
        }
    }


}

