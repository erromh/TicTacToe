using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class AI3x3
    {
        public int point;

        static int calculateBestMove(char[] board)
        {
            int bestValue = -100;

            AI3x3 aiMove = new AI3x3();

            for (int i = 0; i < 9; i++)
            {
                if (board[i] == 'z')
                {
                    board[i] = 'o';
                    int moveValue = Minimax(board, false);
                    board[i] = 'z';

                    if (moveValue > bestValue)
                    {
                        aiMove.point = i;
                        bestValue = moveValue;
                    }
                }
            }
            return aiMove.point;
        }



        public static int evaluate(char[] board)
        {

            if (
        (board[0] == 'o' && board[1] == 'o' && board[2] == 'o') ||
        (board[3] == 'o' && board[4] == 'o' && board[5] == 'o') ||
        (board[6] == 'o' && board[7] == 'o' && board[8] == 'o') ||
        (board[0] == 'o' && board[3] == 'o' && board[6] == 'o') ||
        (board[1] == 'o' && board[4] == 'o' && board[7] == 'o') ||
        (board[2] == 'o' && board[5] == 'o' && board[8] == 'o') ||
        (board[0] == 'o' && board[4] == 'o' && board[8] == 'o') ||
        (board[2] == 'o' && board[4] == 'o' && board[6] == 'o')
)
            {
                return +10;
            }
            else
            {
                return -10;
            }

            return 0;
        }

        static bool isEmptyCellsLeft(char[] board)
        {
            for (int i = 0; i <= 8; i++)
            {
                if (board[i] == 'z')
                {
                    return true;
                }
            }
            return false;
        }

        static int Minimax(char[] board, Boolean isMax)
        {
            int score = evaluate(board);
            if (score == 10) return score;
            if (score == -10) return score;
            if (isEmptyCellsLeft(board) == false)
                return 0;
            if (isMax)
            {
                int best = -100;

                for (int i = 0; i < 8; i++)
                {
                    if (board[i] == 'z')
                    {
                        board[i] = 'o';
                        best = Math.Max(best, Minimax(board, !isMax));
                        board[i] = 'z';
                    }
                }
                return best;
            }

            else
            {
                int best = 100;

                for (int i = 0; i < 8; i++)
                {
                    if (board[i] == 'z')
                    {
                        board[i] = 'x';
                        best = Math.Min(best, Minimax(board, !isMax));
                        board[i] = 'z';
                    }
                }
                return best;
            }

        }

    }

}
