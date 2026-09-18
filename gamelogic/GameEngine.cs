using System;
using TicTacToe.Modells;

namespace gamelogic
{
    public class GameEngine
    {
        private Board board = new Board();
        private Algorithm ai = new Algorithm();
        private bool playerTurn = true;

        public void Run()
        {
            board.Print();

            while (true)
            {
                if (playerTurn)
                    PlayerMove();
                else
                    AiMove();

                board.Print();

                char winner = board.CheckWinner();
                if (winner != ' ')
                {
                    Console.WriteLine(winner == 'X' ? "You won!" : "AI won!");
                    break;
                }
                if (board.IsFull())
                {
                    Console.WriteLine("Draw!");
                    break;
                }

                playerTurn = !playerTurn;
            }
        }

        private void PlayerMove()
        {
            Console.Write("Your turn please choose a field (1-9): ");
            if (!int.TryParse(Console.ReadLine(), out int input) || input < 1 || input > 9)
            {
                Console.WriteLine("False taste!");
                PlayerMove();
                return;
            }

            int row = (input - 1) / 3;
            int col = (input - 1) % 3;

            if (!board.Placemark(row, col, 'X'))
            {
                Console.WriteLine("Field already taken!");
                PlayerMove();
            }
        }

        private void AiMove()
        {
            var (row, col) = ai.FindBestMove(board);
            board.Placemark(row, col, 'O');
        }
    }
}