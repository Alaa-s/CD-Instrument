﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace projectDS
{
    public partial class Form1 : Form
    {
      
        public Form1(){
        
         
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name, pass, email, file;
            name = US.Text;
            username.name = name;
            pass = textBox2.Text;
            email = name + " " + pass;
            using (StreamReader sr = new StreamReader("accounts.txt"))
            {
                bool s = false;
                while (!sr.EndOfStream)
                {
                    file = sr.ReadLine();
                    if (file == email)
                    {
                        s = true;
                        Form3 F3 = new Form3();
                        F3.Show();
                    }
                }
                if (s == false)
                {
                MessageBox.Show("Check your username or password!");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (US.Text == "ADMIN" && textBox2.Text == "123456")
            {
                Form2 F2 = new Form2();
                F2.Show();
            }
            else
            {
                MessageBox.Show("Check your username or password!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void US_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
