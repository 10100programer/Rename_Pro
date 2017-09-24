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
            try
            {
                // Only get files that begin with the letter "c."
                string[] dirs = Directory.GetFiles(@"c:\", "*");
                Console.WriteLine("The number of files starting with c is {0}.", dirs.Length);
                foreach (string dir in dirs)
                {
                    Console.WriteLine(dir);
                    vconsole_write(dir);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("The process failed: {0}", ex.ToString());
            }
        }
        void vconsole_write(string input)
        {
            richTextBox1.AppendText(input + "\n");
        }
    }
}
