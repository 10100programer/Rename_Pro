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
    public partial class mainform : Form
    {
        public mainform()
        {
            InitializeComponent();
        }

        private void mainform_Load(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            lyndaparse parse = new lyndaparse();//declare new lynda parse
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            parse.set_series_name(textBox3.Text);
            try
            {
                int tempcts = 0;
                // Only get files that begin with the letter "c."
                string tempfiletypesearch = "";
                if (textBox1.TextLength < 1)
                {
                    tempfiletypesearch = "*"; //defaults to all files
                }
                tempfiletypesearch = textBox1.Text;
                //MessageBox.Show(tempfiletypesearch);
                string[] dirs = Directory.GetFiles(textBox2.Text, tempfiletypesearch);
                foreach (string dir in dirs)
                {
                    Console.WriteLine(dir);
                    //vconsole_write(dir);
                    listBox1.Items.Add(dir);
                    tempcts++;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("The process failed: {0}", ex.ToString());
            }
            //files are in next phase
            int count = 0;
            int indexlength = listBox1.Items.Count - 1; //amount of items in box
            //MessageBox.Show(listBox1.Items.Count.ToString()); //determines the amount of items in the list box
            while (count <= indexlength)
            {
                parse.populate(listBox1.Items[count].ToString());
                listBox2.Items.Add(parse.returnname());
                //vconsole_write(parse.returnname());
                count++;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            int count2 = 0;
            int indexlength2 = listBox1.Items.Count - 1;
            while (count2 <= indexlength2)
            {
                //listBox1.Items[count].ToString();
                rename(textBox2.Text, listBox1.Items[count2].ToString(), listBox2.Items[count2].ToString());//renames the files
                count2++;
            }
        }
        void rename(string path_folder, string old, string new_name)
        {
            //string temp = null;
            string temp2 = null;
            // temp = path_folder + "\\";
            // temp = temp + old;
            temp2 = path_folder + "\\";
            temp2 = temp2 + new_name;
            //vconsole_write(old + "-->" + temp2);
            System.IO.File.Move(old, temp2);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox();
            ab.Show();
        }

        private void debugFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 debugform = new Form1();
            debugform.Show();
        }
    }
}
