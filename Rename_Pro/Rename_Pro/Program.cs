using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rename_Pro
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
    class lyndaparse
    {
        private bool noexteion = false;
        private string season = null;           //season var
        private string episode = null;          //episode var
        private string name = null;             //episode name var
        private string extension = null;        //file extension var
        private string final_result = null;     //string for storing final rename
        private string series_name = "unknown"; //series name defaults to unkown if not specified
        public void test() { MessageBox.Show("Test Completed!"); }
        public void reset_vars() { return; }//used for reseting all var in the class
        public void populate(string filename)
        {
            string tempstring=null;
            int indexcts = 0; //index count
            filename    = filename.Remove   (0, 7);//Step 1 works
            season      = filename.Substring(0, 2);//step 2 works
            filename    = filename.Remove   (0, 3);//Step 2 works
            episode     = filename.Substring(0, 2);//step 3 works
            filename    = filename.Remove   (0, 3);//Step 3 works 

            while (true)//step 4 works!
            {
                if (filename.ElementAt(indexcts) == '.' || filename.Length <= indexcts)//cuts loop at end of string or at .
                {
                    if(filename.Length <= indexcts) { noexteion = true; }// sets no extension to true
                    break;//leave loop
                }
               tempstring = tempstring + filename.ElementAt(indexcts);//builds tempstring with name
               indexcts++;//index addition
            }
            name = tempstring;//completes step 4
            filename=filename.Remove(0, indexcts);//removes everything except file extension
            if(noexteion != true)
            {
                extension = filename;
            }
        }
        public string returnname()
        {
            string tempstring = null;
            tempstring = series_name;
            tempstring = tempstring + " - ";
            tempstring = tempstring + "s" + season + "e" + episode;
            tempstring = tempstring + " - ";
            tempstring = tempstring + extension;
        
            return tempstring;
        }



        /* Steps for renaming a lynda file
         * File looks like 496951_00_01-Welcome.mp4
         * Step1 --> Chop off first 7 chars
         * File looks like 00_01-Welcome.mp4
         * Step2 --> Store string 0-1 in season var
         * Step3 --> store string 3-4 in episode var
         * Step4 --> Store string 5 until "." is reached or end of filename in Name Var
         * Step5 --> Store string "." until end of filename if no "." is found leave NULL
         * Step6 --> 
         * 
         * */
        }
    }
