using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Game
    {
        // Public Properties
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
        
        // Private Properties
        private char[] board;
        private char human;
        private char computer;
        private char player1 = 'X';
        private char player2 = 'O';
        private char empty = ' ';
        int numSquares = 9;        

        // Public Methods
        public void DisplayInstructions()
        {
            Console.WriteLine("How to play...");
        }

        public char AssignHumanPiece()
        {
            string response = "";
            while (response != "y" && response != "n")
            {
                Console.WriteLine("Do you want to go first? (y/n): ");
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
            Console.WriteLine(" " + board[0] + " | " + board[1] + " | " + board[2]);
            Console.WriteLine("-----------");
            Console.WriteLine(" " + board[3] + " | " + board[4] + " | " + board[5]);
            Console.WriteLine("-----------");
            Console.WriteLine(" " + board[6] + " | " + board[7] + " | " + board[8]);
        }

        public int HumanMove(char[] board)
        {
            ArrayList legalMoves = validMoves(board);
            int move;
            bool response;
            do
            {
                Console.WriteLine("Input your move (0-8): ");
                response = int.TryParse(Console.ReadLine(), out move);
            }
            while (!legalMoves.Contains(move) || !response);
            return move;                        
        }

        public int ComputerMove(char[] board)
        {
            ArrayList legalMoves = validMoves(board);
            int move = -1;
            for (int i = 0; i < legalMoves.Count; i++)
            {
                move = (int)legalMoves[i];                
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
                if (board[i] == ' ')
                {
                    moves.Add(i);
                }
            }
            return moves;
        }
    }
}
