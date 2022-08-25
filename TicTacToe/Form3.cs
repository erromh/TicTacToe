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

        public class AiMove 
        {
            public int pointI;
            public int pointJ;
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
                    buttons[i, j].Text = "";
                    this.Controls.Add(buttons[i, j]);
                    
                     
                }
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Text = "X";
            button.Enabled = false;
            checkWin();
            makeAiTurn(buttons);
            checkWin();
            
        }

        static void makeAiTurn(Button[,] buttons)
        {
            if (isEmptyCellsLeft(buttons))
            {
                AiMove aiMove = calculateBestMove(buttons);
                buttons[aiMove.pointI, aiMove.pointJ].Text = "O";
                buttons[aiMove.pointI, aiMove.pointJ].Enabled = false;
            }
        } 

        private void checkWin()
        {
            if (buttons[0, 0].Text == buttons[0, 1].Text && buttons[0, 1].Text == buttons[0, 2].Text)
            {

                if (buttons[0, 0].Text == "X")
                {
                    MessageBox.Show("You win");
                    return;
                }

                else if (buttons[0, 0].Text == "O")
                {
                    MessageBox.Show("You lose");
                    return;
                }
            }

            if (buttons[1, 0].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[1, 2].Text)
            {
                if (buttons[1, 0].Text == "X")
                {
                    MessageBox.Show("You win");
                    return;
                }

                else if (buttons[1, 0].Text == "O")
                {
                    MessageBox.Show("You lose");
                    return;
                }
            }

            if (buttons[2, 0].Text == buttons[2, 1].Text && buttons[2, 1].Text == buttons[2, 2].Text)
            {
                if (buttons[2, 0].Text == "X") 
                { 
                    MessageBox.Show("You win");
                    return;
                }

                else if (buttons[2, 0].Text == "O")
                {
                    MessageBox.Show("You lose");
                    return;
                }

            }

            if (buttons[0, 0].Text == buttons[1, 0].Text && buttons[1, 0].Text == buttons[2, 0].Text)
            {
                if (buttons[0, 0].Text == "X")
                { 
                    MessageBox.Show("You win");
                    return;
                }

                else if(buttons[0, 0].Text == "O")
                {
                    MessageBox.Show("You lose");
                    return;
                }
            }

            if (buttons[0, 1].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[2, 1].Text)
            {
                if (buttons[0, 1].Text == "X")
                {
                    MessageBox.Show("You win");
                    return;
                }

                else if (buttons[0, 1].Text == "O")
                {
                    MessageBox.Show("You lose");
                    return;
                }
            }

            if (buttons[0, 2].Text == buttons[1, 2].Text && buttons[1, 2].Text == buttons[2, 2].Text)
            {
                if (buttons[0, 2].Text == "X")
                {
                    MessageBox.Show("You win");
                    return;
                }

                else if (buttons[0, 2].Text == "O")
                {
                    MessageBox.Show("You lose");
                    return;
                }
            }

            if (buttons[0, 0].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[2, 2].Text)
            {
                if (buttons[0, 0].Text == "X")
                {
                    MessageBox.Show("You win");
                    return;
                }

                else if (buttons[0, 0].Text == "O")
                {
                    MessageBox.Show("You lose");
                    return;
                }
            }

            if (buttons[2, 0].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[0, 2].Text)
            {
                if (buttons[2, 0].Text == "X")
                {
                    MessageBox.Show("You win");
                    return;
                }

                else if (buttons[2, 0].Text == "O")
                {
                    MessageBox.Show("You lose");
                    return;
                }
            }
        }

        void turnOffTheButtons(Button[,] buttons)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    buttons[i, j].Enabled = false;
                }
            }
        }

        static bool isEmptyCellsLeft(Button[,] buttons)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (buttons[i, j].Text == "")
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        static int minmax(Button[,] buttons, Boolean isMax, int alpha, int beta)
        {
            int score = evaluate(buttons);

            if (score == 10) return score;
            if (score == -10) return score;
            if (isEmptyCellsLeft(buttons) == false)
                return 0;


            
            if (isMax)
            {
                int value = -1000;
                for (int i = 0; i < 3; i++)
                {

                    for (int j = 0; j < 3; j++)
                    {
                        if (buttons[i, j].Text == "")
                        {
                            buttons[i, j].Text = "O";
                            value = Math.Max(value, minmax(buttons, !isMax, alpha, beta));
                            buttons[i, j].Text = "";

                            if (beta <= alpha)
                            {
                                break;
                            }


                            if (value >= beta)
                            {
                                return value;
                            }
                        }
                    }

                }
                return value;
            }


            else
            {
                int value = 1000;

                for (int i = 0; i < 3; i++)
                {

                    for (int j = 0; j < 3; j++)
                    {
                        if (buttons[i, j].Text == "")
                        {
                            buttons[i, j].Text = "X";
                            value = Math.Min(value, minmax(buttons, isMax, alpha, beta));
                            buttons[i, j].Text = "";

                            if (value <= alpha)
                            {
                                return value;
                            }

                            if (value < beta)
                            {
                                beta = value;
                            }
                        }
                    }
                }
                return value;
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
                return 10;
            }

            else
            {
                return -10;
            }

        }

        static AiMove calculateBestMove(Button[,] buttons)
        {
            int bestValue = -100;
            AiMove aiMove = new AiMove();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {

                    if(buttons[i, j].Text == "")
                    {
                        buttons[i, j].Text = "O";
                        int moveValue = minmax(buttons, false, 1000, -1000);
                        buttons[i, j].Text = "";

                        if (moveValue > bestValue)
                        {
                            aiMove.pointI = i;
                            aiMove.pointJ = j;
                            bestValue = moveValue;
                        }
                    }
                }
            }

            return aiMove;
        }


        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
