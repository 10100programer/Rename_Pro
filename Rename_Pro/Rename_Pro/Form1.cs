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
            listBox1.Items.Clear();
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
                //MessageBox.Show(tempfiletypesearch);
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
               // MessageBox.Show(file_array.Length.ToString()); //stop here to check contents of array
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

        private void button4_Click(object sender, EventArgs e)
        {
            lyndaparse parse = new lyndaparse();//declare new lynda parse
            parse.test();
            parse.populate(textBox3.Text);//sample data
            MessageBox.Show(parse.returnname());

        }

        private void button6_Click(object sender, EventArgs e)
        {
            lyndaparse parse = new lyndaparse();//declare new lynda parse
            int count = 0;
            int indexlength = listBox1.Items.Count -1; //amount of items in box
            MessageBox.Show(listBox1.Items.Count.ToString()); //determines the amount of items in the list box
            while (count<=indexlength)
            {
                parse.populate(listBox1.Items[count].ToString());
                listBox2.Items.Add(parse.returnname());
                vconsole_write(parse.returnname());
                count++;
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
            vconsole_write(old + "-->" + temp2);
            System.IO.File.Move(old, temp2);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            lyndaparse parse = new lyndaparse();//declare new lynda parse
            listBox1.Items.Clear();
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
                    vconsole_write(dir);
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
            MessageBox.Show(listBox1.Items.Count.ToString()); //determines the amount of items in the list box
            while (count <= indexlength)
            {
                parse.populate(listBox1.Items[count].ToString());
                listBox2.Items.Add(parse.returnname());
                vconsole_write(parse.returnname());
                count++;
            }
            //next phase rename
            int count2 = 0;
            int indexlength2 = listBox1.Items.Count - 1;
            while(count2 <= indexlength2)
            {
                //listBox1.Items[count].ToString();
                rename(textBox2.Text,listBox1.Items[count2].ToString(),listBox2.Items[count2].ToString());//renames the files
                count2++;
            }
            
        }
    }
}
