using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        private int player;
        public Form1()
        {
            InitializeComponent();
            player = 1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                switch (player)
                {
                    case 0:
                        sender.GetType().GetProperty("Text").SetValue(sender, "O");
                        player = 1;
                        break;

                    case 1:
                        sender.GetType().GetProperty("Text").SetValue(sender, "X");
                        player = 0;
                    break;
                }

            sender.GetType().GetProperty("Enabled").SetValue(sender, false);
            check_winner();
            show_move();

        }

        private void show_move()
        { 
            if (player != 1) 
            {
                label3.Text = "-";
                label4.Text = "+";

            }
            else
            {
                label3.Text = "+";
                label4.Text = "-";
            }

        }
        private void check_winner()
        {
            // условия выирыша по гориизонтали
            if (button1.Text==button2.Text && button2.Text == button3.Text)
            {
                if (button1.Text != "")
                {
                    MessageBox.Show("You win");
                    return;
                }
            }

            if (button4.Text == button5.Text && button5.Text == button6.Text)
            {
                if (button4.Text != "")
                {
                    MessageBox.Show("You win");
                    return;
                }
            }

            if (button7.Text == button8.Text && button8.Text == button9.Text)
            {
                if (button7.Text != "")
                {
                    MessageBox.Show("You win");
                    return;
                }
            }

            // условия выигрыша по диагонали 
            if (button1.Text == button5.Text && button5.Text == button9.Text)
            {
                if (button1.Text != "")
                {
                    MessageBox.Show("You win");
                    return;
                }
            }

            if (button3.Text == button5.Text && button5.Text == button7.Text)
            {
                if (button3.Text != "")
                {
                    MessageBox.Show("You win");
                    return;
                }
            }

            // условия выигрыша по вертикали 
            if (button1.Text == button4.Text && button4.Text == button7.Text)
            {
                if (button1.Text != "")
                {
                    MessageBox.Show("You win");
                    return;
                }
            }

            if (button2.Text == button5.Text && button5.Text == button8.Text)
            {
                if (button2.Text != "")
                {
                    MessageBox.Show("You win");
                    return;
                }
            }

            if (button3.Text == button6.Text && button6.Text == button9.Text)
            {
                if (button3.Text != "")
                {
                    MessageBox.Show("You win");
                    return;
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            button1.Text = "";
            button1.Enabled = true;

            button2.Text = "";
            button2.Enabled = true;

            button3.Text = "";
            button3.Enabled = true;


            button4.Text = "";
            button4.Enabled = true;

            button5.Text = "";
            button5.Enabled = true;

            button6.Text = "";
            button6.Enabled = true;


            button7.Text = "";
            button7.Enabled = true;

            button8.Text = "";
            button8.Enabled = true;

            button9.Text = "";
            button9.Enabled = true;

        }
    }
}
