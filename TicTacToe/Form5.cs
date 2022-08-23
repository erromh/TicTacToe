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
    public partial class Form5 : Form
    {
        private Button[,] buttons = new Button[5, 5];
        public Form5()
        {
            InitializeComponent();

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Size = new Size(100, 100);
                }
            }
            setButton();
            
        }

        private void setButton()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    buttons[i, j].Location = new Point(5 + 100 * i, 100 + 100 * j);
                    buttons[i, j].Click += button1_Click;
                    buttons[i, j].Font = new Font(new FontFamily("Microsoft Sans Serif"), 50);
                    buttons[i, j].TextAlign = ContentAlignment.TopCenter;

                    this.Controls.Add(buttons[i, j]);

                }
            }
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            sender.GetType().GetProperty("Text").SetValue(sender, "x");
           // calculateBestMove(buttons);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    buttons[i, j].Text = "";
                    buttons[i, j].Enabled = true;
                }
            }
        }

        static void calculateBestMove(Button[,] buttons)
        {
            int bestValue = -100;
            int pointI = 0;
            int pointJ = 0;


            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (buttons[i, j].Text == "O")
                    {
                        buttons[i, j].Text = "";
                        int moveValue = minimax(buttons, false, 1000, -1000);
                        buttons[i, j].Text = "";



                        if (moveValue > bestValue)
                        {
                            pointI = i;
                            pointJ = j;
                            bestValue = moveValue;
                        }
                    }
                }
            }
        }

        public static int evaluate(Button[,] buttons)
        {
            for (int i = 0; i < 5; i++) //Проверка столбцов на победу x, o
            {
                if (buttons[0, i] == buttons[1, i] &&
                    buttons[1, i] == buttons[2, i] &&
                    buttons[2, i] == buttons[3, i] &&
                    buttons[3, i] == buttons[4, i]
                    )
                {
                    if (buttons[0, i].Text == "o") { return 10; }
                    if (buttons[0, i].Text == "x") { return -10; }
                }
            }


            for (int i = 0; i < 5; i++) //Проверка строк на победу x, o
            {
                if (buttons[i, 0] == buttons[i, 1] &&
                    buttons[i, 1] == buttons[i, 2] &&
                    buttons[i, 2] == buttons[i, 3] &&
                    buttons[i, 3] == buttons[i, 4]
                    )
                {
                    if (buttons[i, 0].Text == "o") { return 10; }
                    if (buttons[i, 0].Text == "x") { return -10; }
                }
            }

            if (                                    //проверка диагонали слева направо
                buttons[0, 0] == buttons[1, 1] &&
                buttons[1, 1] == buttons[2, 2] &&
                buttons[2, 2] == buttons[3, 3] &&
                buttons[3, 3] == buttons[4, 4]
                )
            {
                if (buttons[0, 0].Text == "o") { return 10; }
                if (buttons[0, 0].Text == "x") { return -10; }
            }
            if (                                    //проверка диагонали справа налево
                buttons[0, 4] == buttons[1, 3] &&
                buttons[1, 3] == buttons[2, 2] &&
                buttons[2, 2] == buttons[3, 1] &&
                buttons[3, 1] == buttons[4, 0]
                )
            {
                if (buttons[0, 4].Text == "o") { return 10; }
                if (buttons[0, 4].Text == "x") { return -10; }
            }
            return 0;
        }

        static bool isEmptyCellsLeft(Button[,] buttons)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (buttons[i, j].Text == "")
                    {
                        return true;
                    }
                }

            }
            return false;
        }

        static int minimax(Button[,] buttons, Boolean isMax, int alpha, int beta)
        {
            int score = evaluate(buttons);

            if (score == 10) return score;
            if (score == -10) return score;
            if (isEmptyCellsLeft(buttons) == false)
                return 0;


            int value = 0;

            if (isMax)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (buttons[i, j].Text == "")
                        {
                            buttons[i, j].Text = "o";
                            value = minimax(buttons, !isMax, alpha, beta);
                            buttons[i, j].Text = "o";

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
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (buttons[i, j].Text == "")
                        {
                            buttons[i, j].Text = "x";
                            value = minimax(buttons, isMax, alpha, beta);
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
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    /// <summary>
    /// //////////////////////////////////////////////////////////////
    /// </summary>
    public class AI5x5
    {
        public int pointI;
        public int pointJ;

        public static AI5x5 calculateBestMove(char[,] buttons)
        {
            int bestValue = -100;
            AI5x5 aiMove = new AI5x5();


            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (buttons[i, j] == 'z')
                    {
                        buttons[i, j] = 'o';
                        int moveValue = minimax(buttons, false, 1000, -1000);
                        buttons[i, j] = 'z';



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

        public static int evaluate(char[,] buttons)
        {
            for (int i = 0; i < 5; i++) //Проверка столбцов на победу x, o
            {
                if (buttons[0, i] == buttons[1, i] &&
                    buttons[1, i] == buttons[2, i] &&
                    buttons[2, i] == buttons[3, i] &&
                    buttons[3, i] == buttons[4, i]
                    )
                {
                    if (buttons[0, i] == 'o') { return 10; }
                    if (buttons[0, i] == 'x') { return -10; }
                }
            }


            for (int i = 0; i < 5; i++) //Проверка строк на победу x, o
            {
                if (buttons[i, 0] == buttons[i, 1] &&
                    buttons[i, 1] == buttons[i, 2] &&
                    buttons[i, 2] == buttons[i, 3] &&
                    buttons[i, 3] == buttons[i, 4]
                    )
                {
                    if (buttons[i, 0] == 'o') { return 10; }
                    if (buttons[i, 0] == 'x') { return -10; }
                }
            }

            if (                                    //проверка диагонали слева направо
                buttons[0, 0] == buttons[1, 1] &&
                buttons[1, 1] == buttons[2, 2] &&
                buttons[2, 2] == buttons[3, 3] &&
                buttons[3, 3] == buttons[4, 4]
                )
            {
                if (buttons[0, 0] == 'o') { return 10; }
                if (buttons[0, 0] == 'x') { return -10; }
            }
            if (                                    //проверка диагонали справа налево
                buttons[0, 4] == buttons[1, 3] &&
                buttons[1, 3] == buttons[2, 2] &&
                buttons[2, 2] == buttons[3, 1] &&
                buttons[3, 1] == buttons[4, 0]
                )
            {
                if (buttons[0, 4] == 'o') { return 10; }
                if (buttons[0, 4] == 'x') { return -10; }
            }
            return 0;
        }

        static bool isEmptyCellsLeft(char[,] buttons)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (buttons[i, j] == 'z')
                    {
                        return true;
                    }
                }

            }
            return false;
        }

        static int minimax(char[,] buttons, Boolean isMax, int alpha, int beta)
        {
            int score = evaluate(buttons);

            if (score == 10) return score;
            if (score == -10) return score;
            if (isEmptyCellsLeft(buttons) == false)
                return 0;


            int value = 0;
            if (isMax)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (buttons[i, j] == 'z')
                        {
                            buttons[i, j] = 'o';
                            value = minimax(buttons, !isMax, alpha, beta);
                            buttons[i, j] = 'z';

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
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (buttons[i, j] == 'z')
                        {
                            buttons[i, j] = 'x';
                            value = minimax(buttons, isMax, alpha, beta);
                            buttons[i, j] = 'z';


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


    }
}
