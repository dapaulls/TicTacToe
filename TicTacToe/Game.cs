﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Game
    {
        /*
         * Properties & fields - There are 2 players (human & computer) and a board.
         *                       The board has 9 squares.
         *                       Each square can either be empty or contain an 'X' or an 'O'.
         */
        
        private char[] board;
        private char human;
        private char computer;
        private char player1 = 'X';
        private char player2 = 'O';
        private char empty = ' ';
        int numSquares = 9;        
        
        public char[] Board
        {
            get { return board; }
            set { board = value; }
        }
        public char Human
        {
            get { return human; }
            set { human = value; }
        }    
        public char Computer
        {
            get { return computer; }
            set { computer = value; }
        }
        public char Player1
        {
            get { return player1; }
            set { player1 = value; }
        }
        public char Player2
        {
            get { return player2; }
            set { player2 = value; }
        }
        public char Empty
        {
            get { return empty; }
            set { empty = value; }
        }
        
                

        // Public Methods
        public void DisplayInstructions()
        {
            Console.WriteLine("How to play...\n");
            Console.WriteLine("Get three of your pieces in a row to win.");
            Console.WriteLine("Make a move by entering a number 1-9.");
            Console.WriteLine("The numbers correspond to the squares on the board as so:\n");
            Console.WriteLine("\t 1 | 2 | 3");
            Console.WriteLine("\t-----------");
            Console.WriteLine("\t 4 | 5 | 6");
            Console.WriteLine("\t-----------");
            Console.WriteLine("\t 7 | 8 | 9");
        }

        public char AssignHumanPiece()
        {
            string response = "";
            while (response != "y" && response != "n")
            {
                Console.Write("\nDo you want to go first? (y/n): ");
                response = Console.ReadLine().ToLower();
            }
            if (response == "y")
            {
                human = player1;
                Console.WriteLine("Your pieces are '" + player1.ToString() + "'. Press any key to start.");
                Console.ReadLine();
            }
            else 
            {
                human = player2;
                Console.WriteLine("Your pieces are '" + player2.ToString() + "'. Press any key to start.");
                Console.ReadLine();
            }
            return human;
        }

        public char AssignComputerPiece(char human)
        {
            if (human == player1)
            {
                computer = player2;
            }
            else
            {
                computer = player1;
            }
            return computer;
        }

        public char[] CreateBoard()
        {
            char[] board = new char[numSquares];
            for (int i = 0; i < numSquares; i++)
            {
                board[i] = empty;
            }
            return board;
        }

        public void DisplayBoard(char[] board)        
        {
            Console.Clear();
            Console.WriteLine("\n\t " + board[0] + " | " + board[1] + " | " + board[2]);
            Console.WriteLine("\t-----------");
            Console.WriteLine("\t " + board[3] + " | " + board[4] + " | " + board[5]);
            Console.WriteLine("\t-----------");
            Console.WriteLine("\t " + board[6] + " | " + board[7] + " | " + board[8]);
        }

        public int HumanMove(char[] board)
        {
            ArrayList legalMoves = validMoves(board);
            int move;
            bool response;
            do
            {
                Console.WriteLine("\nInput your move (1-9): ");
                response = int.TryParse(Console.ReadLine(), out move);
            }
            while (!legalMoves.Contains(move - 1) || !response);
            return move - 1;                        
        }

        public int ComputerMove(char[] board)
        {
            ArrayList legalMoves = validMoves(board);
            int move = -1;            
            int[] bestMoves = { 4, 0, 2, 6, 8, 1, 3, 5, 7 };

            char[] copyOfBoard = board;
            // Check to see if the computer can win
            foreach (int number in legalMoves)
            {
                copyOfBoard[number] = computer;
                string message = CheckForWinner(copyOfBoard);
                if (message == "winner")
                {
                    move = number;
                    return move;
                }
                else
                {
                    copyOfBoard[number] = empty;
                }
            }

            // If the computer can't win, check to see if a human win can be blocked
            foreach (int number in legalMoves)
            {
                copyOfBoard[number] = human;
                string message = CheckForWinner(copyOfBoard);
                if (message == "winner")
                {
                    move = number;
                    return move;
                }
                else
                {
                    copyOfBoard[number] = empty;
                }
            }

            // Otherwise play the next best move
            foreach (int number in bestMoves)
            {
                if (legalMoves.Contains(number))
                {
                    move = number;
                    return move;
                }                
            }            
            return move;     
        }

        public string CheckForWinner(char[] board)
        {
            string message = "";

            ArrayList winningLines = new ArrayList();
            int[] line1 = { 0, 1, 2 };
            int[] line2 = { 3, 4, 5 };
            int[] line3 = { 6, 7, 8 };
            int[] line4 = { 0, 3, 6 };
            int[] line5 = { 1, 4, 7 };
            int[] line6 = { 2, 5, 8 };
            int[] line7 = { 0, 4, 8 };
            int[] line8 = { 2, 4, 6 };

            winningLines.Add(line1);
            winningLines.Add(line2);
            winningLines.Add(line3);
            winningLines.Add(line4);
            winningLines.Add(line5);
            winningLines.Add(line6);
            winningLines.Add(line7);
            winningLines.Add(line8);

            foreach (int[] line in winningLines)
            {
                if ((board[line[0]] == board[line[1]]) && (board[line[0]] == board[line[2]]) && (board[line[0]] != empty))
                {
                    message = "winner";
                }
            }

            if (message != "winner")
            {
                if (!board.Contains(empty))
                {
                    message = "tie";
                }

                else
                {
                    message = "keep playing";
                }
            }

            return message;
        }

        public char SwapTurns(char turn)
        {
            if (turn == human)
            {
                turn = computer;
            }
            else
            {
                turn = human;
            }
            return turn;
        }

        private ArrayList validMoves(char[] board)
        {
            ArrayList moves = new ArrayList();
            for (int i = 0; i < numSquares; i++)
            {
                if (board[i] == empty)
                {
                    moves.Add(i);
                }
            }
            return moves;
        }
    }
}
