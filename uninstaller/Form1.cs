using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uninstaller
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //global declerations
        string selected = "";
        string uninstallPath = "";
        string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"; //reg key for installed programs subkeys
        int i = 0;
        //end of global decs.

        private void Form1_Load(object sender, EventArgs e)
        {
            using (Microsoft.Win32.RegistryKey key = Registry.LocalMachine.OpenSubKey(registry_key))
            {
                foreach (string subkey_name in key.GetSubKeyNames())
                {
                    using (RegistryKey subkey = key.OpenSubKey(subkey_name))
                    {
                        Console.WriteLine(subkey.GetValue("DisplayName")); //debug.
                        try
                        {
                            listBox1.Items.Add(subkey.GetValue("DisplayName"));
                            i ++;
                        }
                        catch
                        {
                            continue; //value is assumed null
                        }
                    }
                }
                label1.Text = i.ToString();
            }
        }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            selected = listBox1.SelectedItem.ToString();
            MessageBox.Show(selected);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
