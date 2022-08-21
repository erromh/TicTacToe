using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Resources
{


    public class AI5x5
    {
        public int pointI;
        public int pointJ;

        public static AI5x5 calculateBestMove(char[,] board)
        {
            int bestValue = -100;
            AI5x5 aiMove = new AI5x5();


            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (board[i, j] == 'z')
                    {
                        board[i, j] = 'o';
                        int moveValue = minimax(board, false, 1000, -1000);
                        board[i, j] = 'z';



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



        public static int evaluate(char[,] board)
        {
            for (int i = 0; i < 5; i++) //Проверка столбцов на победу x, o
            {
                if (board[0, i] == board[1, i] &&
                    board[1, i] == board[2, i] &&
                    board[2, i] == board[3, i] &&
                    board[3, i] == board[4, i]
                    )
                {
                    if (board[0, i] == 'o') { return 10; }
                    if (board[0, i] == 'x') { return -10; }
                }
            }


            for (int i = 0; i < 5; i++) //Проверка строк на победу x, o
            {
                if (board[i, 0] == board[i, 1] &&
                    board[i, 1] == board[i, 2] &&
                    board[i, 2] == board[i, 3] &&
                    board[i, 3] == board[i, 4]
                    )
                {
                    if (board[i, 0] == 'o') { return 10; }
                    if (board[i, 0] == 'x') { return -10; }
                }
            }

            if (                                    //проверка диагонали слева направо
                board[0, 0] == board[1, 1] &&
                board[1, 1] == board[2, 2] &&
                board[2, 2] == board[3, 3] &&
                board[3, 3] == board[4, 4]
                )
            {
                if (board[0, 0] == 'o') { return 10; }
                if (board[0, 0] == 'x') { return -10; }
            }
            if (                                    //проверка диагонали справа налево
                board[0, 4] == board[1, 3] &&
                board[1, 3] == board[2, 2] &&
                board[2, 2] == board[3, 1] &&
                board[3, 1] == board[4, 0]
                )
            {
                if (board[0, 4] == 'o') { return 10; }
                if (board[0, 4] == 'x') { return -10; }
            }
            return 0;
        }

        static bool isEmptyCellsLeft(char[,] board)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (board[i, j] == 'z')
                    {
                        return true;
                    }
                }

            }
            return false;
        }

        static int minimax(char[,] board, Boolean isMax, int alpha, int beta)
        {
            int score = evaluate(board);

            if (score == 10) return score;
            if (score == -10) return score;
            if (isEmptyCellsLeft(board) == false)
                return 0;


            int value = 0;
            if (isMax)
            {

                for (int i = 0; i < 5; i++)
                {

                    for (int j = 0; j < 5; j++)
                    {
                        if (board[i, j] == 'z')
                        {
                            board[i, j] = 'o';
                            value = minimax(board, !isMax, alpha, beta);
                            board[i, j] = 'z';

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
                        if (board[i, j] == 'z')
                        {
                            board[i, j] = 'x';
                            value = minimax(board, isMax, alpha, beta);
                            board[i, j] = 'z';


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
