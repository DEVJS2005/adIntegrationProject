using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace adIntegrationProject
{
    public partial class SIAD : Form
    {
        
        Thread tPrincipal;
        public SIAD()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if(txbUserAdmin.Text != "")
            {
                string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                StreamWriter command = new StreamWriter(desktop + "\\command.txt");
                command.WriteLine("Enter-PSSession -ComputerName intsmmlnsrv01 -Credential victor.santos");
                command.Close();
                this.Close();
                tPrincipal = new Thread(abrirJanela);
                tPrincipal.SetApartmentState(ApartmentState.STA);
                tPrincipal.Start();
            }
            
        }

        private void abrirJanela(object obj)
        {
            Application.Run(new telaCadUser());
        }
    }
}
