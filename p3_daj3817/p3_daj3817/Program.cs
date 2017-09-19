/*
 * Author:      Dante Jones
 * CLID:        daj3817
 * Class:       CMPS 358
 * Assignment:  Project 3
 * Due Date:    11:55pm / 30 March 2017
 * Description: I am using a windows form in this project to create a whack a mole game.
 * I cerifty that this program was done by myself.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace p3_daj3817
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
}
