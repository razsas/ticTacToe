using System.Data.Common;

namespace ticTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputRow, inputColumn,turncount=0,move;
            bool over=false,turnDone=true;
            char[] ticTacToe;
            ticTacToe = new char[16];
            ticTacToe[0] = ' ';
            ticTacToe[1] = '1';
            ticTacToe[2] = '2';
            ticTacToe[3] = '3';
            ticTacToe[4] = '1';
            ticTacToe[8] = '2';
            ticTacToe[12] = '3';
            for (int i = 5; i < 16; i++)
                if (i == 8 || i == 12) ;
                else
                    ticTacToe[i] = '-';
            printBoard (ticTacToe);
            while(!over)
            {
                turnDone = true;
                inputRow = legalInput("please choose the row (just one number please)");
                inputColumn = legalInput("please choose the Column (just one number please)");
                if (validLoc(inputRow, inputColumn, ticTacToe))
                    ticTacToe[(inputRow * 4 + inputColumn)] = 'X';
                else
                {
                    Console.WriteLine("location is occupied, please try another location");
                    turnDone = false;
                }
                over=winCondition(ticTacToe);
                if (over)
                    Console.WriteLine("the game is over, thank you for playing");
                if (turnDone)
                {
                    turncount++;
                    if (turncount == 1)
                    {
                        move = firstTurn(ticTacToe);
                        ticTacToe[move] = 'O';
                    }
                    else
                        ticTacToe= computersTurn(ticTacToe); 
                }
                printBoard(ticTacToe);
                over = winCondition(ticTacToe);
                if (over)
                    Console.WriteLine("you cant win :) :)");
            }
        }
        static void printBoard(char[] ticTacToe)
        {
            for (int i1 = 0; i1 < 16; i1++)
            {
                Console.Write(ticTacToe[i1]);
                Console.Write("  ");
                if (i1 == 3 || i1 == 7 || i1 == 11 || i1==15)
                    Console.WriteLine();
            }

        }
        static int legalInput(string message)
        {
            bool legal;
            string input;
            do 
            {
                Console.WriteLine(message);
                input = Console.ReadLine();
                legal = true;
                if (input.Length > 1)
                    legal = false;
                if (input == "")
                    legal = false;
                if (legal && input[0] != '1' && input[0] != '2' && input[0] != '3' )
                    legal = false;
                if (!legal)
                    Console.WriteLine("input is worng, please try again");
            } while (!legal);
            return int.Parse(input);
        }
        static bool validLoc(int row,int Column, char[] ticTacToe)
        {
            bool valid=false;
            if (ticTacToe[(row * 4 + Column)] == '-')
                valid = true;
            return valid;
        }
        static bool winCondition(char [] ticTacToe)
        {
            bool win=false;
            if (ticTacToe[5] == 'X' && ticTacToe[6] == 'X' && ticTacToe[7] == 'X')
                win = true;
            if (ticTacToe[9] == 'X' && ticTacToe[10] == 'X' && ticTacToe[11] == 'X')
                win = true;
            if (ticTacToe[13] == 'X' && ticTacToe[14] == 'X' && ticTacToe[15] == 'X')
                win = true;
            if (ticTacToe[5] == 'X' && ticTacToe[9] == 'X' && ticTacToe[13] == 'X')
                win = true;
            if (ticTacToe[6] == 'X' && ticTacToe[10] == 'X' && ticTacToe[14] == 'X')
                win = true;
            if (ticTacToe[7] == 'X' && ticTacToe[11] == 'X' && ticTacToe[15] == 'X')
                win = true;
            if (ticTacToe[5] == 'X' && ticTacToe[10] == 'X' && ticTacToe[15] == 'X')
                win = true;
            if (ticTacToe[7] == 'X' && ticTacToe[10] == 'X' && ticTacToe[13] == 'X')
                win = true;
            if (ticTacToe[5] == 'O' && ticTacToe[6] == 'O' && ticTacToe[7] == 'O')
                win = true;
            if (ticTacToe[9] == 'O' && ticTacToe[10] == 'O' && ticTacToe[11] == 'O')
                win = true;
            if (ticTacToe[13] == 'O' && ticTacToe[14] == 'O' && ticTacToe[15] == 'O')
                win = true;
            if (ticTacToe[5] == 'O' && ticTacToe[9] == 'O' && ticTacToe[13] == 'O')
                win = true;
            if (ticTacToe[6] == 'O' && ticTacToe[10] == 'O' && ticTacToe[14] == 'O')
                win = true;
            if (ticTacToe[7] == 'O' && ticTacToe[11] == 'O' && ticTacToe[15] == 'O')
                win = true;
            if (ticTacToe[5] == 'O' && ticTacToe[10] == 'O' && ticTacToe[15] == 'O')
                win = true;
            if (ticTacToe[7] == 'O' && ticTacToe[10] == 'O' && ticTacToe[13] == 'O')
                win = true;
            if (ticTacToe[5] != '-' && ticTacToe[6] != '-' && ticTacToe[7] != '-' && ticTacToe[9] != '-' && ticTacToe[10] != '-' && ticTacToe[11] != '-' && ticTacToe[13] != '-' && ticTacToe[14] != '-' && ticTacToe[15] != '-')
                win = true;
            return win;
        }
        static char[] computersTurn(char[] ticTacToe)
        {
            if ((ticTacToe[6] == 'O' && ticTacToe[7] == 'O' && ticTacToe[5] == '-') || (ticTacToe[9] == 'O' && ticTacToe[13] == 'O' && ticTacToe[5] == '-') || (ticTacToe[10] == 'O' && ticTacToe[15] == 'O' && ticTacToe[5] == '-'))
            {
                ticTacToe[5] = 'O';
                return ticTacToe;
            }
            if ((ticTacToe[5] == 'O' && ticTacToe[7] == 'O' && ticTacToe[6] == '-') || (ticTacToe[10] == 'O' && ticTacToe[14] == 'O' && ticTacToe[6] == '-'))
            {
                ticTacToe[6] = 'O';
                return ticTacToe;
            }
            if ((ticTacToe[5] == 'O' && ticTacToe[6] == 'O' && ticTacToe[7] == '-') || (ticTacToe[11] == 'O' && ticTacToe[15] == 'O' && ticTacToe[7] == '-') || (ticTacToe[10] == 'O' && ticTacToe[13] == 'O' && ticTacToe[7] == '-'))
            {
                ticTacToe[7] = 'O';
                return ticTacToe;
            }
            if ((ticTacToe[10] == 'O' && ticTacToe[11] == 'O' && ticTacToe[9] == '-') || (ticTacToe[5] == 'O' && ticTacToe[13] == 'O' && ticTacToe[9] == '-'))
            {
                ticTacToe[9] = 'O';
                return ticTacToe;
            }
            if ((ticTacToe[10] == 'O' && ticTacToe[9] == 'O' && ticTacToe[11] == '-') || (ticTacToe[7] == 'O' && ticTacToe[15] == 'O' && ticTacToe[11] == '-'))
            {
                ticTacToe[11] = 'O';
                return ticTacToe;
            }
            if ((ticTacToe[14] == 'O' && ticTacToe[15] == 'O' && ticTacToe[13] == '-') || (ticTacToe[5] == 'O' && ticTacToe[9] =='O' && ticTacToe[13] == '-') || (ticTacToe[10] == 'O' && ticTacToe[7] == 'O' && ticTacToe[13] == '-'))
            {
                ticTacToe[13] = 'O';
                return ticTacToe;
            }
            if ((ticTacToe[13] == 'O' && ticTacToe[15] == 'O' && ticTacToe[14] == '-') || (ticTacToe[6] == 'O' && ticTacToe[10] == 'O' && ticTacToe[14] == '-'))
            {
                ticTacToe[14] = 'O';
                return ticTacToe;
            }
            if ((ticTacToe[14] == 'O' && ticTacToe[13] == 'O' && ticTacToe[15] == '-') || (ticTacToe[7] == 'O' && ticTacToe[11] == 'O' && ticTacToe[15] == '-') || (ticTacToe[10] == 'O' && ticTacToe[5] == 'O' && ticTacToe[15] == '-'))
            {
                ticTacToe[15] = 'O';
                return ticTacToe;
            }
            if ((ticTacToe[6] == 'X' && ticTacToe[7] == 'X' && ticTacToe[5] == '-') || (ticTacToe[9] == 'X' && ticTacToe[13] == 'X' && ticTacToe[5] == '-') || (ticTacToe[10] == 'X' && ticTacToe[15] == 'X' && ticTacToe[5] == '-'))
            {
                ticTacToe[5] = 'O';
                return ticTacToe;
            }
            if ((ticTacToe[5] == 'X' && ticTacToe[7] == 'X' && ticTacToe[6] == '-') || (ticTacToe[10] == 'X' && ticTacToe[14] == 'X' && ticTacToe[6] == '-'))
            {
                ticTacToe[6] = 'O';
                return ticTacToe;
            }
            if ((ticTacToe[5] == 'X' && ticTacToe[6] == 'X' && ticTacToe[7] == '-') || (ticTacToe[11] == 'X' && ticTacToe[15] == 'X' && ticTacToe[7] == '-') || (ticTacToe[10] == 'X' && ticTacToe[13] == 'X' && ticTacToe[7] == '-'))
            {
                ticTacToe[7] = 'O';
                return ticTacToe;
            }
            if ((ticTacToe[10] == 'X' && ticTacToe[11] == 'X' && ticTacToe[9] == '-') || (ticTacToe[5] == 'X' && ticTacToe[13] == 'X' && ticTacToe[9] == '-'))
            {
                ticTacToe[9] = 'O';
                return ticTacToe;
            }
            if ((ticTacToe[10] == 'X' && ticTacToe[9] == 'X' && ticTacToe[11] == '-') || (ticTacToe[7] == 'X' && ticTacToe[15] == 'X' && ticTacToe[11] == '-'))
            {
                ticTacToe[11] = 'O';
                return ticTacToe;
            }
            if ((ticTacToe[14] == 'X' && ticTacToe[15] == 'X' && ticTacToe[13] == '-') || (ticTacToe[5] == 'X' && ticTacToe[9] == 'X' && ticTacToe[13] == '-') || (ticTacToe[10] == 'X' && ticTacToe[7] == 'X' && ticTacToe[13] == '-'))
            {
                ticTacToe[13] = 'O';
                return ticTacToe;
            }
            if ((ticTacToe[13] == 'X' && ticTacToe[15] == 'X' && ticTacToe[14] == '-') || (ticTacToe[6] == 'X' && ticTacToe[10] == 'X' && ticTacToe[14] == '-'))
            {
                ticTacToe[14] = 'O';
                return ticTacToe;
            }
            if ((ticTacToe[14] == 'X' && ticTacToe[13] == 'X' && ticTacToe[15] == '-') || (ticTacToe[7] == 'X' && ticTacToe[11] == 'X' && ticTacToe[15] == '-') || (ticTacToe[10] == 'X' && ticTacToe[5] == 'X' && ticTacToe[15] == '-'))
            {
                ticTacToe[15] = 'O';
                return ticTacToe;
            }
            if ((ticTacToe[6] == 'X' && ticTacToe[9] == 'X' && ticTacToe[5] == '-') || (ticTacToe[9] == 'X' && ticTacToe[7] == 'X' && ticTacToe[5] == '-') || (ticTacToe[13] == 'X' && ticTacToe[6] == 'X' && ticTacToe[5] == '-') || (ticTacToe[13] == 'X' && ticTacToe[7] == 'X' && ticTacToe[5] == '-'))
            {
                ticTacToe[5] = 'O';
                return ticTacToe;
            }
            if ((ticTacToe[6] == 'X' && ticTacToe[11] == 'X' && ticTacToe[7] == '-') || (ticTacToe[5] == 'X' && ticTacToe[11] == 'X' && ticTacToe[7] == '-') || (ticTacToe[5] == 'X' && ticTacToe[15] == 'X' && ticTacToe[7] == '-') || (ticTacToe[15] == 'X' && ticTacToe[6] == 'X' && ticTacToe[7] == '-'))
            {
                ticTacToe[7] = 'O';
                return ticTacToe;
            }
            if ((ticTacToe[14] == 'X' && ticTacToe[9] == 'X' && ticTacToe[13] == '-') || (ticTacToe[9] == 'X' && ticTacToe[15] == 'X' && ticTacToe[13] == '-') || (ticTacToe[14] == 'X' && ticTacToe[5] == 'X' && ticTacToe[13] == '-') || (ticTacToe[15] == 'X' && ticTacToe[5] == 'X' && ticTacToe[13] == '-'))
            {
                ticTacToe[13] = 'O';
                return ticTacToe;
            }
            if ((ticTacToe[13] == 'X' && ticTacToe[7] == 'X' && ticTacToe[15] == '-') || (ticTacToe[11] == 'X' && ticTacToe[13] == 'X' && ticTacToe[15] == '-') || (ticTacToe[14] == 'X' && ticTacToe[7] == 'X' && ticTacToe[15] == '-') || (ticTacToe[11] == 'X' && ticTacToe[14] == 'X' && ticTacToe[15] == '-'))
            {
                ticTacToe[15] = 'O';
                return ticTacToe;
            }
            if (ticTacToe[15] == 'X' && ticTacToe[5] == '-') 
            {
                ticTacToe[5] = 'O';
                return ticTacToe;
            }
            if (ticTacToe[13] == 'X' && ticTacToe[7] == '-')
            {
                ticTacToe[7] = 'O';
                return ticTacToe;
            }
            if (ticTacToe[7] == 'X' && ticTacToe[13] == '-')
            {
                ticTacToe[13] = 'O';
                return ticTacToe;
            }
            if (ticTacToe[5] == 'X' && ticTacToe[15] == '-')
            {
                ticTacToe[15] = 'O';
                return ticTacToe;
            }
            if (ticTacToe[5] == '-')
            {
                ticTacToe[5] = 'O';
                return ticTacToe;
            }
            if (ticTacToe[7] == '-')
            {
                ticTacToe[7] = 'O';
                return ticTacToe;
            }
            if (ticTacToe[13] == '-')
            {
                ticTacToe[13] = 'O';
                return ticTacToe;
            }
            if (ticTacToe[15] == '-')
            {
                ticTacToe[15] = 'O';
                return ticTacToe;
            }
            if (ticTacToe[6] == '-')
            {
                ticTacToe[6] = 'O';
                return ticTacToe;
            }
            if (ticTacToe[9] == '-')
            {
                ticTacToe[9] = 'O';
                return ticTacToe;
            }
            if (ticTacToe[11] == '-')
            {
                ticTacToe[11] = 'O';
                return ticTacToe;
            }
            else
            {
                ticTacToe[14] = 'O';
                return ticTacToe;
            }
        }
  
        static int firstTurn(char[] ticTacToe)
        {
            int move;
            if (ticTacToe[10] == '-')
                move = 10;
            else
                move = 5;
            return move;
        }

    }
}