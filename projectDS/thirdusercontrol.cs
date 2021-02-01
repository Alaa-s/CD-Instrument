using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace projectDS
{
    public partial class thirdusercontrol : UserControl
    {
        public thirdusercontrol()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string line;
            string un = username.name;

            using (StreamReader sr = new StreamReader("History.txt"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    string first = "", second = "";
                    bool b = false;
                    for (int i = 0; i < line.Length; i++)
                    {
                        if (line[i] == ' ') { b = true; }
                        else if (b == false) { first += line[i]; }
                        else
                        {
                            second += line[i];
                        }
                    }
                    if (first == un) { richTextBox1.Text += line + Environment.NewLine; }
                }
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
