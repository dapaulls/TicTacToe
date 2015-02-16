using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Tic Tac Toe");
            Console.WriteLine("===========\n");

            Game newGame = new Game();
            newGame.DisplayInstructions();
            char human = newGame.AssignHumanPiece();
            char computer = newGame.AssignComputerPiece(newGame.Human);
            char turn = newGame.Player1;
            char[] board = newGame.CreateBoard();
            newGame.DisplayBoard(board);

            while (newGame.CheckForWinner(board) == "keep playing")
            {
                if (turn == human)
                {
                    int move = newGame.HumanMove(board);
                    board[move] = human;
                }
                else
                {
                    int move = newGame.ComputerMove(board);
                    board[move] = computer;
                }
                newGame.DisplayBoard(board);
                turn = newGame.SwapTurns(turn);
            }

            string theWinner = newGame.CheckForWinner(board);
            if (theWinner == "winner")
            {
                if (turn == computer)
                {
                    Console.WriteLine("Well done. You won!");
                }
                else
                {
                    Console.WriteLine("Ha! Ha! I won!");
                }
            }
            else
            {
                Console.WriteLine("Its a tie!");
            }
               
            Console.ReadLine();
        }
    }
}
