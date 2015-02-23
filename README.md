# TicTacToe

Pseudocode:
  1. Display game instructions
  2. Determine who goes first
  3. Create an empty board
  4. Display the board
  5. While nobody's won and it's not a tie
     5a. if it's the human turn
          get the human's move
          update the board
      else
        calculate the computer's move
          if the computer can win, choose that move
          else if the computer can block the human winning, choose that move
          else choose the next best square
        update the board
      5b.  Display the board
      5c.  Switch turns
  6. Congratulate the winner or declare a tie.
