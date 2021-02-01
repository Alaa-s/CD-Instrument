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
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();
        }
        private void Home_Load(object sender, EventArgs e)
        {
    
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();
            using (StreamReader SR = new StreamReader("Acceptance.txt"))
            {
                string line;
                while ((line = SR.ReadLine()) != null)
                {
                    string[] ar = line.Split(' ');
                    if (ar[0] == username.name)
                    {
                        richTextBox1.Text += "You are accepted for "+ar[1] + Environment.NewLine;

                    }
                    else
                    {
                        KeyValuePair<string, string> kvp = new KeyValuePair<string, string>(ar[0], ar[1]);
                        data.Add(kvp);
                    }
                }
            }
            using (StreamWriter sw = new StreamWriter("Acceptance.txt"))
            {
                foreach (KeyValuePair<string, string> item in data)
                {
                    sw.Write(item.Key + " " + item.Value + Environment.NewLine);
                }
            }
        }

        
    }
}
