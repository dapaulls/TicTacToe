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
            do
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
                        Console.WriteLine("\nWell done. You won!");
                    }
                    else
                    {
                        Console.WriteLine("\nHa! Ha! I won!");
                    }
                }
                else
                {
                    Console.WriteLine("\nIt's a tie!");
                }

                Console.Write("Would you like to play again? (y/n):");
            }
            while (Console.ReadLine().ToLower() == "y");
        }
    }
}
