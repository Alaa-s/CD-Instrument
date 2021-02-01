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
    public partial class Rent : UserControl
    {
        public Rent()
        {
            InitializeComponent();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            IDictionary<string, KeyValuePair<string, int>> data = new Dictionary<string, KeyValuePair<string, int>>();


            if (radioButton1.Checked == true)
            {
                bool ans = false;
                using (StreamReader sr = new StreamReader("CD.txt"))
                {
                        using (StreamWriter h = new StreamWriter("History.txt", append: true))
                        {
                            using (StreamWriter w = new StreamWriter("waitinglist.txt", append: true))
                            {
                                string line;
                                while (!sr.EndOfStream)
                                {
                                    line = sr.ReadLine();
                                    string[] arr = line.Split(' ');
                                    int count = Int32.Parse(arr[2]);
                                    if (textBox1.Text == arr[0])
                                    {
                                        h.Write(username.name + ' ' + "Rented CD" + ' ' + textBox1.Text + Environment.NewLine);
                                        count--;
                                        MessageBox.Show("CD Rented");
                                        ans = true;
                                    }
                                    if (count > 0)
                                    {
                                        KeyValuePair<string, int> pair = new KeyValuePair<string, int>(arr[1], count);
                                        data.Add(arr[0], pair);
                                    }
                                }
                                if (ans == false)
                                {
                                    w.Write(username.name + ' ' + textBox1.Text + Environment.NewLine);
                                    MessageBox.Show("You Are On WaitingList");
                                }
                            }
                        }
                    }

                using (StreamWriter ss = new StreamWriter("CD.txt"))
                {
                    string line2;

                    foreach (KeyValuePair<string, KeyValuePair<string, int>> item in data)
                    {
                        line2 = item.Key + ' ' + item.Value.Key + ' ' + item.Value.Value + Environment.NewLine;
                        ss.Write(line2);
                    }

                }
            }
            //
            //
            //
            else
            {
                bool check = false;
                using (StreamReader sr = new StreamReader("Instrument.txt"))
                {
                    using (StreamWriter h = new StreamWriter("History.txt", append: true))
                    {
                        using (StreamWriter w = new StreamWriter("waitinglist.txt", append: true))
                        {
                            string line;
                            while (!sr.EndOfStream)
                            {
                                line = sr.ReadLine();
                                string[] arr = line.Split(' ');
                                int count = Int32.Parse(arr[2]);
                                if (textBox1.Text == arr[0] )
                                {
                                    h.WriteLine(username.name + ' ' + "Rented Instrument" + ' ' + textBox1.Text);
                                    count--;
                                    check = true;
                                    MessageBox.Show("Instrument Rented");
                                }
                                if (count > 0)
                                {
                                    KeyValuePair<string, int> pair = new KeyValuePair<string, int>(arr[1], count);
                                    data.Add(arr[0], pair);
                                }
                            }
                            if (check == false)
                            {
                                w.WriteLine(username.name + ' ' + textBox1.Text);
                                MessageBox.Show("You Are On WaitingList");
                            }
                        }

                    }
                }
           
                using (StreamWriter ss = new StreamWriter("Instrument.txt"))
                {
                    string line2;

                    foreach (KeyValuePair<string, KeyValuePair<string, int>> item in data)
                    {
                        line2 = item.Key + ' ' + item.Value.Key + ' ' + item.Value.Value + Environment.NewLine;
                        ss.Write(line2);
                    }

                }
            }
        }
    }
}