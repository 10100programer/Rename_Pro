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
        private string season = null;           //season var
        private string episode = null;          //episode var
        private string name = null;             //episode name var
        private string extension = null;        //file extension var
        private string final_result = null;     //string for storing final rename
        private string series_name = "unknown"; //
        public void test() { MessageBox.Show("Test Completed!"); }
        public void reset_vars() { return; }//used for reseting all var in the class





        /* Steps for renaming a lynda file
         * File looks like 496951_00_01-Welcome.mp4
         * Step1 --> Chop off first 7 chars
         * File looks like 00_01-Welcome.mp4
         * Step2 --> Store string 0-1 in season var
         * Step3 --> store string 3-4 in episode var
         * Step4 --> Store string 5 until "." is reached or end of filename in Name Var
         * Step5 --> Store string "." until end of filename if no "." is found leave NULL
         * Step6 --> 
    }
}
