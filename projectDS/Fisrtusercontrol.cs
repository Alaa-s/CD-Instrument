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
    public partial class Fisrtusercontrol : UserControl
    {
        public Fisrtusercontrol()
        {
            InitializeComponent();
        }


        //Add Client
        private void button1_Click_1(object sender, EventArgs e)
        {
            IDictionary<string, string> acc = new Dictionary<string, string>();

            using (StreamReader sr = new StreamReader("accounts.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string line; line = sr.ReadLine();
                    string[] arr = line.Split(' ');
                    acc.Add(arr[0], arr[1]);
                }
            }

            string first, second; first = textBox1.Text; second = textBox2.Text;
            bool sign = false;

            foreach (KeyValuePair<string, string> iteam in acc)
            {
                if (iteam.Key == first)
                {
                    MessageBox.Show("Enter another username");
                    sign = true;
                }
            }

            if (sign == false)
            {
                acc.Add(first, second);
                MessageBox.Show("Client Added");
            }

            using (StreamWriter sw = new StreamWriter("accounts.txt"))
            {
                foreach (KeyValuePair<string, string> iteam in acc)
                {
                    sw.Write(iteam.Key + ' ' + iteam.Value + Environment.NewLine);
                }

            }
        }
        //Add CD

        private void button2_Click(object sender, EventArgs e)
        {
            int count = Int32.Parse(textBox5.Text);

            List<KeyValuePair<string, string>> data = new List<KeyValuePair<string,string>>();

            using (StreamReader SR = new StreamReader("waitinglist.txt"))
            {
                using (StreamWriter h = new StreamWriter("History.txt", append: true))
                {
                    using (StreamWriter sw = new StreamWriter("Acceptance.txt", append: true))
                    {
                        string line;
                        while ((line = SR.ReadLine()) != null)
                        {
                            string[] ar = line.Split(' ');
                            if (ar[1] == textBox3.Text)
                            {
                              
                                if (count > 0)
                                {
                                    count--;
                                    sw.Write(ar[0] + " " + ar[1] + Environment.NewLine);
                                    h.Write(ar[0] + " " + "Rented CD" + " " + ar[1] + Environment.NewLine);

                                }
                                else {
                                    KeyValuePair<string, string> kvp = new KeyValuePair<string, string>(ar[0],ar[1]);
                                    data.Add(kvp);
                                }
                            }
                            else
                            {
                                KeyValuePair<string, string> kvp = new KeyValuePair<string, string>(ar[0], ar[1]);
                                       data.Add(kvp); }
                        }
                    }
                }
            }

            using (StreamWriter ss = new StreamWriter("waitinglist.txt"))
            {
                foreach (KeyValuePair<string, string> item in data)
                {
                    ss.Write(item.Key + ' ' + item.Value + Environment.NewLine);
                }

            }
       

            IDictionary<string, KeyValuePair<string, int>> d = new Dictionary<string, KeyValuePair<string, int>>();
            int count2;

            using (StreamReader sr = new StreamReader("CD.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string name, code, count1;
                    string[] ar = line.Split(' ');
                    name = ar[0];
                    code = ar[1];
                    count1 = ar[2];
                    count2 = Int32.Parse(count1);
                    KeyValuePair<string, int> kvp = new KeyValuePair<string, int>(code, count2);
                    d.Add(name, kvp);

                }
            }
             

                int c = 0;

                foreach (KeyValuePair<string, KeyValuePair<string, int>> item in d)
                {
                    if (item.Key == textBox3.Text)
                    {
                        c = count + item.Value.Value;
                    }
                }

                if (c == 0)
                {
                    if (count > 0)
                    {
                        KeyValuePair<string, int> kvp = new KeyValuePair<string, int>(textBox4.Text, count);
                        d[textBox3.Text] = kvp;
                    }

                    MessageBox.Show("CD Added");
                }
                else
                {
                    KeyValuePair<string, int> kvp = new KeyValuePair<string, int>(textBox4.Text, c);
                    d[textBox3.Text] = kvp;

                    MessageBox.Show("CD Added");
                }


                using (StreamWriter ss = new StreamWriter("CD.txt"))
                {
                    string line2;

                    foreach (KeyValuePair<string, KeyValuePair<string, int>> item in d)
                    {
                        line2 = item.Key + ' ' + item.Value.Key + ' ' + item.Value.Value + Environment.NewLine;
                        ss.Write(line2);
                    }

                }
            }



        //Add Instrument
        private void button3_Click(object sender, EventArgs e)
        {
            int count = Int32.Parse(textBox8.Text);
            List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();

            using (StreamReader SR = new StreamReader("waitinglist.txt"))
            {
                using (StreamWriter h = new StreamWriter("History.txt", append: true))
                {
                    using (StreamWriter sw = new StreamWriter("Acceptance.txt", append: true))
                    {
                        string line;
                        while ((line = SR.ReadLine()) != null)
                        {
                            string[] ar = line.Split(' ');
                            if (ar[1] == textBox6.Text)
                            {
                  
                                if (count > 0)
                                {
                                    count--;
                                    sw.Write(ar[0] + " " + ar[1] + Environment.NewLine);
                                    h.Write(ar[0] + "Rented Instrument" + " " + ar[1] + Environment.NewLine);
                                }

                                else
                                {
                                    KeyValuePair<string, string> kvp = new KeyValuePair<string, string>(ar[0], ar[1]);
                                    data.Add(kvp);
                                }
                            }

                            else
                            {
                                KeyValuePair<string, string> kvp = new KeyValuePair<string, string>(ar[0], ar[1]);
                                data.Add(kvp);
                            }
                        }
                    }
                }
            }


            using (StreamWriter ss = new StreamWriter("waitinglist.txt"))
            {
                foreach (KeyValuePair<string, string> item in data)
                {
                    ss.Write(item.Key + ' ' + item.Value + Environment.NewLine);
                }
             
            }
           

            IDictionary<string, KeyValuePair<string, int>> d = new Dictionary<string, KeyValuePair<string, int>>();
            int count2;

            using (StreamReader sr = new StreamReader("Instrument.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string name, code, count1;
                    string[] ar = line.Split(' ');
                    name = ar[0];
                    code = ar[1];
                    count1 = ar[2];
                    count2 = Int32.Parse(count1);
                    KeyValuePair<string, int> kvp = new KeyValuePair<string, int>(code, count2);
                    d.Add(name, kvp);

                }
            }

                int c = 0;

                foreach (KeyValuePair<string, KeyValuePair<string, int>> item in d)
                {
                    if (item.Key == textBox6.Text)
                    {
                        c = count + item.Value.Value;
                    }
                }
                if (c == 0)
                {

                    if (count > 0)
                    {
                        KeyValuePair<string, int> kvp = new KeyValuePair<string, int>(textBox7.Text, count);
                        d[textBox6.Text] = kvp;
                    }

                    MessageBox.Show("Instrument Added");
                }
                else
                {
                    KeyValuePair<string, int> kvp = new KeyValuePair<string, int>(textBox7.Text, c);
                    d[textBox6.Text] = kvp;

                    MessageBox.Show("Instrument Added");
                }

                using (StreamWriter ss = new StreamWriter("Instrument.txt"))
                {
                    string line2;

                    foreach (KeyValuePair<string, KeyValuePair<string, int>> item in d)
                    {
                        line2 = item.Key + ' ' + item.Value.Key + ' ' + item.Value.Value + Environment.NewLine;
                        ss.Write(line2);
                    }

                }
            }
        }
    }
 