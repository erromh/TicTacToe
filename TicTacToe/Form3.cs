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
    public partial class Form3 : Form
    {
        private Button[,] buttons = new Button[3, 3];
        public Form3()
        {
            InitializeComponent();

            for (int i = 0; i < buttons.Length / 3; i++)
            {
                for (int j = 0; j < buttons.Length / 3; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Size = new Size(150, 150);
                }
            }
            setButton();
            
        }

        private void setButton()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    buttons[i, j].Location = new Point(10 + 150 * i, 150 + 150 * j);
                    buttons[i, j].Click += button1_Click;
                    buttons[i, j].Font = new Font(new FontFamily("Microsoft Sans Serif"), 100);
                    buttons[i, j].TextAlign = ContentAlignment.TopCenter;

                    this.Controls.Add(buttons[i, j]);

                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            sender.GetType().GetProperty("Text").SetValue(sender, "X");
           // CalculateBestMove(buttons);
        }

        private void checkWin()
        {

            if (buttons[0, 0].Text == buttons[0, 1].Text && buttons[0, 1].Text == buttons[0, 2].Text)
            {

                if (buttons[0, 0].Text != "")
                {
                    MessageBox.Show("You win");
                    return;
                }
            }

            if (buttons[1, 0].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[1, 2].Text)
            {
                if (buttons[1, 0].Text != "")
                {
                    MessageBox.Show("You win");
                    return;
                }
            }

            if (buttons[2, 0].Text == buttons[2, 1].Text && buttons[2, 1].Text == buttons[2, 2].Text)
            {
                if (buttons[2, 0].Text != "")
                    MessageBox.Show("You win");
            }

            if (buttons[0, 0].Text == buttons[1, 0].Text && buttons[1, 0].Text == buttons[2, 0].Text)
            {
                if (buttons[0, 0].Text != "")
                    MessageBox.Show("You win");
            }

            if (buttons[0, 1].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[2, 1].Text)
            {
                if (buttons[0, 1].Text != "")
                    MessageBox.Show("You win");
            }

            if (buttons[0, 2].Text == buttons[1, 2].Text && buttons[1, 2].Text == buttons[2, 2].Text)
            {
                if (buttons[0, 2].Text != "")
                    MessageBox.Show("You win");
            }

            if (buttons[0, 0].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[2, 2].Text)
            {
                if (buttons[0, 0].Text != "")
                    MessageBox.Show("You win");
            }

            if (buttons[2, 0].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[0, 2].Text)
            {
                if (buttons[2, 0].Text != "")
                    MessageBox.Show("You win");
            }
        }



        static bool isEmptyCellsLeft(Button[,] buttons)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (buttons[i, j].Text == "")
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        static int MinMax(Button[,] buttons, bool isMax)
        {
            int score = evaluate(buttons);

            if (score == 10)
            {
                return score;
            }

            if (score == -10)
            {
                return score;
            }

            if (isEmptyCellsLeft(buttons) == false)
            {
                return 0;
            }

            if (isMax)
            {
                int best = -100;

                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (buttons[i, j].Text == "")
                        {
                            buttons[i, j].Text = "O";
                            best = Math.Max(best, MinMax(buttons, !isMax));
                            buttons[i, j].Text = "";
                        }
                    }
                }
                return best;
            }

            else
            {
                int best = 100;

                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        buttons[i, j].Text = "X";
                        best = Math.Min(best, MinMax(buttons, !isMax));
                        buttons[i, j].Text = "";
                    }
                }
                return best;
            }

        }

        private static int evaluate(Button[,] buttons)
        {
            if (buttons[0, 0].Text == buttons[0, 1].Text && buttons[0, 1].Text == buttons[0, 2].Text ||
                buttons[1, 0].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[1, 2].Text ||
                buttons[2, 0].Text == buttons[2, 1].Text && buttons[2, 1].Text == buttons[2, 2].Text ||
                buttons[0, 0].Text == buttons[1, 0].Text && buttons[1, 0].Text == buttons[2, 0].Text ||
                buttons[0, 1].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[2, 1].Text ||
                buttons[0, 2].Text == buttons[1, 2].Text && buttons[1, 2].Text == buttons[2, 2].Text ||
                buttons[0, 0].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[2, 2].Text ||
                buttons[2, 0].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[0, 2].Text)
            {
                return +10;
            }

            else
            {
                return -10;
            }

        }

        static int CalculateBestMove(Button[,] buttons)
        {
            int bestValue = -100;

            int aiMove = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    buttons[i, j].Text = "O";
                    int moveValue = MinMax(buttons, false);
                    //buttons[i, j].Text = "";

                    if (moveValue > bestValue) 
                    {
                        aiMove = i;
                        bestValue = moveValue;
                    }
                }
            }

            return aiMove;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
