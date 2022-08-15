using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Board
    {
        char[] board;
        public void ChooseBoardSize(int sizeBoard)
        {
            
            switch (sizeBoard)
            {
                case 3:
                    board = new char[9] { 'z', 'z', 'z', 'z', 'z', 'z', 'z', 'z', 'z' };
                    break;
                case 5:
                    board = new char[25] { 'z', 'z', 'z', 'z', 'z',
                                         'z', 'z', 'z', 'z', 'z',
                                         'z', 'z', 'z', 'z', 'z',
                                         'z', 'z', 'z', 'z', 'z',
                                         'z', 'z', 'z', 'z', 'z'};
                    break;
                default:
                    break;

            }

        }







        
    }
    
}
