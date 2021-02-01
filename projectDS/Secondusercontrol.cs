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
    public partial class Secondusercontrol : UserControl
    {
        public Secondusercontrol()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IDictionary<string, KeyValuePair<string, int>> d = new Dictionary<string, KeyValuePair<string, int>>();

            using (StreamReader sr = new StreamReader("CD.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string name, code, count1;
                    string[] words = line.Split(' ');
                    name = words[0];
                    code = words[1];
                    count1 = words[2];
                    int count2 = Int32.Parse(count1);
                    KeyValuePair<string, int> kvp = new KeyValuePair<string, int>(code, count2);
                    d.Add(name, kvp);

                }
            }

                int c = 0;
                bool s = false;
                foreach (KeyValuePair<string, KeyValuePair<string, int>> item in d)
                {
                    if (item.Key == textBox4.Text)
                    {
                        s = true;
                        c = item.Value.Value - Int32.Parse(textBox1.Text);
                    }

                }
                if (c == 0 && s==true)
                {
                    d.Remove(textBox4.Text);
                    MessageBox.Show("CD Removed");
                }
                else if (s == false)
                {
                    MessageBox.Show("CD doesn't exist");
                }
                else if (c < 0)
                {
                    int abs1 = Math.Abs(c);
                    d.Remove(textBox4.Text);
                    MessageBox.Show(abs1+" CDs can't be removed"+Environment.NewLine+"CD Doesn't exist");
                }
                else if(c>0)
                {
                    KeyValuePair<string, int> kvp = new KeyValuePair<string, int>(textBox3.Text, c);
                    d[textBox4.Text] = kvp;
                    MessageBox.Show("CD Removed");
                }

                using (StreamWriter sw = new StreamWriter("CD.txt"))
                {
                    string line2;

                    foreach (KeyValuePair<string, KeyValuePair<string, int>> item in d)
                    {
                        line2 = item.Value.Key + ' ' + item.Key + ' ' + item.Value.Value + Environment.NewLine;
                        sw.Write(line2);
                    }

                }
            }
        
       
        private void button3_Click(object sender, EventArgs e)
        {
            IDictionary<string, KeyValuePair<string, int>> d = new Dictionary<string, KeyValuePair<string, int>>();

            using (StreamReader sr = new StreamReader("Instrument.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string name, code, count1;
                    string[] words = line.Split(' ');
                    name = words[0];
                    code = words[1];
                    count1 = words[2];
                    int count2 = Int32.Parse(count1);
                    KeyValuePair<string, int> kvp = new KeyValuePair<string, int>(code, count2);
                    d.Add(name, kvp);

                }
            }

                int c = 0;
                bool s = false;
                foreach (KeyValuePair<string, KeyValuePair<string, int>> item in d)
                {
                    if (item.Key == textBox8.Text)
                    {
                        s = true;
                        c = item.Value.Value - Int32.Parse(textBox2.Text);
                    }

                }
                if (c == 0 && s == true)
                {
                    d.Remove(textBox8.Text);
                    MessageBox.Show("Instrument Removed");
                }
                else if (s == false)
                {
                    MessageBox.Show("Instrument doesn't exist");
                }
                else if (c < 0)
                {
                    int abs1 = Math.Abs(c);
                    d.Remove(textBox8.Text);
                    MessageBox.Show(abs1 + " Instruments can't be removed" + Environment.NewLine + "Instrument Doesn't exist");
                }
                else if (c > 0)
                {
                    KeyValuePair<string, int> kvp = new KeyValuePair<string, int>(textBox7.Text, c);
                    d[textBox8.Text] = kvp;
                    MessageBox.Show("Instrument Removed");
                }


                using (StreamWriter sw = new StreamWriter("Instrument.txt"))
                {
                    string line2;

                    foreach (KeyValuePair<string, KeyValuePair<string, int>> item in d)
                    {
                        line2 = item.Value.Key + ' ' + item.Key + ' ' + item.Value.Value + Environment.NewLine;
                        sw.Write(line2);
                    }

                }
            }
        
        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Secondusercontrol_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
