﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int wylosowana = 0,liczba =0,proby = 0,bledy = 0;

        TimeSpan time;
        double timer = 0;


        static int Losuj(int min, int max)
        {
            if (min > max)
            {
                int temp = max;
                max = min;
                min = temp;
            }

            Random generator = new Random();
            return generator.Next(min, max + 1);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                wylosowana = Losuj(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
                button1.Enabled = false;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                button2.Enabled = true;
                textBox3.Enabled = true;
                bledy = 0;
                pictureBox1.Image = Properties.Resources.hp_full;
                pictureBox2.Image = Properties.Resources.hp_full;
                pictureBox3.Image = Properties.Resources.hp_full;
                label4.Text = "";
                label5.Text = "Gra rozpoczęta ! ";
                label6.Text = "Czas : ";
                label8.Text = "Liczba prób : ";
                timer = 0;
                proby = 0;
                timer1.Enabled = true;
            } catch
            {
                MessageBox.Show("Nieprawidłowe liczby !");
            }
        }

        private void Check(int b) {
      
           switch (b)
            {
                case 1:
                    pictureBox3.Image = Properties.Resources.hp_half;
                        break;
                case 2:
                    pictureBox3.Image = Properties.Resources.hp_none;
                    break;
                case 3: pictureBox2.Image = Properties.Resources.hp_half; break;
                case 4: pictureBox2.Image = Properties.Resources.hp_none; break;
                case 5 : pictureBox1.Image = Properties.Resources.hp_half; break;
                case 6 :
                    pictureBox1.Image = Properties.Resources.hp_none;
                    timer1.Enabled = false;
                    button1.Enabled = true;
                    textBox1.Enabled = true;
                    textBox2.Enabled = true;
                    button2.Enabled = false;
                    textBox3.Enabled = false;
                    Form2 newForm = new Form2();
                    newForm.label1.Text = "Przejebales downie";
                    newForm.pictureBox1.Image = pictureBox1.Image;
                    newForm.pictureBox2.Image = pictureBox2.Image;
                    newForm.pictureBox3.Image = pictureBox3.Image;
                    newForm.label2.Text = "  Czas : " + time.ToString("mm':'ss':'f");
                    newForm.BackColor = Color.Red;
                    newForm.ShowDialog();
                    break;
            }
            }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                liczba = Convert.ToInt32(textBox3.Text);
                if(liczba == wylosowana)
                {
                    button1.Enabled = true;
                    textBox1.Enabled = true;
                    textBox2.Enabled = true;
                    button2.Enabled = false;
                    textBox3.Enabled = false;
                    label4.ForeColor = Color.Green;
                    //label4.Text = "Trafiłeś";
                    timer1.Enabled = false;
                    //label5.Text = "Gra zakończona ! ";

                    Form2 newForm = new Form2();
                    newForm.label1.Text = "Wygrałeś downie";
                    newForm.BackColor = Color.Green;
                    newForm.pictureBox1.Image = pictureBox1.Image;
                    newForm.pictureBox2.Image = pictureBox2.Image;
                    newForm.pictureBox3.Image = pictureBox3.Image;
                    newForm.label2.Text = "  Czas : " + time.ToString("mm':'ss':'f");
                    newForm.ShowDialog();

                } else if(liczba > wylosowana)
                {
                    label4.ForeColor = Color.Red;
                    label4.Text = "Za dużo !";
                    bledy++;
                    Check(bledy);
                } else if (liczba < wylosowana)
                {
                    label4.ForeColor = Color.Red;
                    label4.Text = "Za mało !";
                    bledy++;
                    Check(bledy);
                }
                proby++;
                label8.Text = "Liczba prób : " + proby.ToString();

            } catch
            {
                MessageBox.Show("Nieprawidłowe liczby !");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer += timer1.Interval;
            time = TimeSpan.FromMilliseconds(timer);
            label6.Text = "Czas : " + time.ToString("mm':'ss':'f");
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}