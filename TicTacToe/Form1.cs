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
        }

        private void check_winner()
        {
            if (button1.Text==button2.Text && button2.Text == button3.Text)
            {
                MessageBox.Show("You win");
            }

        }
    }
}
