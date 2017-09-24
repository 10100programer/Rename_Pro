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

namespace Rename_Pro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] file_array = new string[1024]; //declare array
            try
            {
                int tempcts = 0;
                // Only get files that begin with the letter "c."
                string tempfiletypesearch = "";
                if(textBox1.TextLength<1)
                {
                    tempfiletypesearch = "*"; //defaults to all files
                }
                tempfiletypesearch = textBox1.Text;
                MessageBox.Show(tempfiletypesearch);
                string[] dirs = Directory.GetFiles(textBox2.Text, tempfiletypesearch);//need to figure out why replacing * with tempfiletype search didnt work;
                Console.WriteLine("The number of files starting with c is {0}.", dirs.Length);
                foreach (string dir in dirs)
                {
                    Console.WriteLine(dir);
                    vconsole_write(dir);
                    file_array[tempcts] = dir;//dumps file names to array
                    listBox1.Items.Add(dir);
                    tempcts++;

                }
                MessageBox.Show(file_array.Length.ToString()); //stop here to check contents of array
            }
            catch (Exception ex)
            {
                Console.WriteLine("The process failed: {0}", ex.ToString());
            }
        }
        void vconsole_write(string input)
        {
            richTextBox1.AppendText(input + "\n");//input + newline
        }
        void dump_array()
        {
            //fill in with code to dump array to vconsole
        }

        private void button2_Click(object sender, EventArgs e)
        {
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    textBox2.Text = folderBrowserDialog1.SelectedPath;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
    }
}
