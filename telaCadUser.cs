using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace adIntegrationProject
{
    public partial class telaCadUser : Form
    {
        public telaCadUser()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            StreamWriter command = File.AppendText(desktop + "\\command.txt");
            string complet_name = txboxFirstN.Text + " " + txboxSecondN.Text;
            command.WriteLine(string.Format("New-ADUser -SamAccountName \"{0}\" -Name \"{1}\" -GivenName \"{2}\" -Surname \"{3}\" -EmailAddress \"{4}\" -AccountPassword (ConvertTo-SecureString -AsPlainText \"ints@2023\" -Force) -Enabled $true -ChangePasswordAtLogon $true -Path \"OU=MMLN,OU=USUARIO,DC=mmln,DC=ints\" -Title \"{5}\" -Department \"{6}\" -Description \"{7}\"",txboxUser.Text,complet_name,txboxFirstN.Text,txboxSecondN.Text,txboxEmail.Text,txboxFunc.Text,txboxDepartament.Text, txboxFunc.Text));
            command.WriteLine("Add-ADGroupMember -Identity NomeDoGrupo -Members NovoUsuario");
            command.WriteLine("Exit-PSSession");
            command.Close();

            string oldFile = desktop + "\\command.txt";
            string newFile = desktop + "\\command.ps1";

            File.Move(oldFile,newFile);

            this.Close();
        }
    }
}
