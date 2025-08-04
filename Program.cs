using System;

namespace TicTacToeGame
{
    class Program
    {
        static char[] board = {'1','2','3','4','5','6','7','8','9'};
        static int player = 1;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Tic-Tac-Toe!");
            
            do
            {
                PlayGame();
                Console.Write("\nPlay again? (y/n): ");
            }
            while (Console.ReadLine()?.ToLower() == "y");
            
            Console.WriteLine("Thanks for playing!");
        }
        
        static void PlayGame()
        {
            // Reset game
            board = new char[] {'1','2','3','4','5','6','7','8','9'};
            player = 1;
            int gameStatus = 0;
            
            do
            {
                Console.Clear();
                Console.WriteLine("Player 1: X, Player 2: O\n");
                ShowBoard();
                
                Console.Write($"Player {player}, enter position (1-9): ");
                
                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= 9)
                {
                    if (board[choice - 1] != 'X' && board[choice - 1] != 'O')
                    {
                        board[choice - 1] = (player == 1) ? 'X' : 'O';
                        gameStatus = CheckWin();
                        player = (player == 1) ? 2 : 1;
                    }
                    else
                    {
                        Console.WriteLine("Position taken! Press Enter...");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input! Press Enter...");
                    Console.ReadLine();
                }
            }
            while (gameStatus == 0);
            
            Console.Clear();
            ShowBoard();
            
            if (gameStatus == 1)
                Console.WriteLine($"\nPlayer {(player == 1 ? 2 : 1)} WINS!");
            else
                Console.WriteLine("\nIt's a DRAW!");
        }
        
        static void ShowBoard()
        {
            Console.WriteLine($" {board[0]} | {board[1]} | {board[2]} ");
            Console.WriteLine("---|---|---");
            Console.WriteLine($" {board[3]} | {board[4]} | {board[5]} ");
            Console.WriteLine("---|---|---");
            Console.WriteLine($" {board[6]} | {board[7]} | {board[8]} ");
        }
        
        static int CheckWin()
        {
            // Win patterns
            int[][] wins = {
                new int[] {0,1,2}, new int[] {3,4,5}, new int[] {6,7,8}, // rows
                new int[] {0,3,6}, new int[] {1,4,7}, new int[] {2,5,8}, // columns  
                new int[] {0,4,8}, new int[] {2,4,6}  // diagonals
            };
            
            // Check wins
            foreach (var win in wins)
            {
                if (board[win[0]] == board[win[1]] && board[win[1]] == board[win[2]])
                    return 1;
            }
            
            // Check draw
            foreach (char c in board)
            {
                if (c != 'X' && c != 'O')
                    return 0; // continue
            }
            
            return -1; // draw
        }
    }
}