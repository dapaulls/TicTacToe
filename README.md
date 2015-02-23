# TicTacToe

After each move by the human player, the computer chooses an 'intelligent' move by...
  1. Checking the board to see if there is a move that would result in the computer winning. If so, that move is made.
  2. Checking the board to see if there is a move that would block the human from winning. If so, that move is made.
  3. Else, choose the best remaining square in the order 4, 0, 2, 6, 8, 1, 3, 5, 7.
