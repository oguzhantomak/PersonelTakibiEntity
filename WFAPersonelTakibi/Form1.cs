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

        #region Temizleme Metodu
        public void Clean()
        {
            foreach (Control item in groupBox1.Controls)
            {
                if (item is MetroTextBox)
                {
                    item.Text = "";
                }
                foreach (Control itemx in metroPanel1.Controls)
                {
                    if (itemx is MetroRadioButton)
                    {
                        rdMale.Checked = false;
                        rdFemale.Checked = false;
                        rdRandom.Checked = false;
                    }
                }
                if (item is MetroDateTime)
                {
                    dtBirthDate.Value = DateTime.Now;
                }
                if (item is MetroComboBox)
                {
                    cmbDepartment.SelectedItem = default;
                }
            }
        } 
        #endregion


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
            MetroMessageBox.Show(this, result ? "Kayıt başarıyla eklendi" : "Kayıt ekleme hatası", "Kayıt ekleme bildirimi", MessageBoxButtons.OK, result ? MessageBoxIcon.Hand : MessageBoxIcon.Error);

            Clean();

        }

        private void mlPersonelListesi_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            this.Hide();
            frm.ShowDialog();
        }
    }


}

