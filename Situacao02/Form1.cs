using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Situacao02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void AtualizaListbox() {

            LBlista.Items.Clear();

            foreach (var item in importador)
            {
               LBlista.Items.Add(item.Cliente);
            }
        
        }
        class Importer
        {

            public string Cliente;
            public string Data;
            public string CPF;
            public string email;
            public string ID;
        }
        List<Importer> importador = new List<Importer>();
        private void button1_Click(object sender, EventArgs e)
        {
            openFile.ShowDialog();

            
        }

        private void openFile_FileOk(object sender, CancelEventArgs e)
        {
            using (StreamReader leitor = new StreamReader(openFile.FileName))
            {
               string line;
               leitor.ReadLine();
                while ((line = leitor.ReadLine()) != null)
                {               
                    string[] dados = line.Split(';');
                    Importer tipos = new Importer();
                    tipos.Cliente = dados[0];
                    tipos.CPF = dados[1];
                    tipos.Data = dados[2];
                    tipos.email = dados[3];
                    tipos.ID = dados[4];
                    importador.Add(tipos);

                }
                AtualizaListbox();

            }
        }

        private void LBlista_SelectedIndexChanged(object sender, EventArgs e)
        {
           foreach (var item in importador)
	        {
                if (item.Cliente == LBlista.SelectedItem)
                {
                    MessageBox.Show("CPF: " + item.CPF + "|" + "Data De Registro: " + item.Data + "|" + "Email: " + item.email + "|" + "ID: " + item.ID + "|");
                }
           }          
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

            using (StreamWriter writer = new StreamWriter(saveFile.FileName, false))
            {
                foreach (Importer item in importador)
                {
                    string aux = item.Cliente;
                    if (checkBox1.Checked)
                    {
                        aux += ";" + item.CPF;
                    }
                    if (checkBox2.Checked)
                    {
                        aux += ";" + item.email;
                    }
                    if (checkBox3.Checked)
                    {
                        aux += ";" + item.Data;
                    }
                    if (checkBox4.Checked)
                    {
                        aux += ";" + item.ID;
                    }
                    writer.WriteLine(aux);

                }
            }
             
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFile.ShowDialog();
        }

        private void CheckedBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           
                

            }
            
        
    } 
}
