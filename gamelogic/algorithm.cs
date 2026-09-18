using TicTacToe.Modells;

namespace gamelogic
{
    public class Algorithm
    {
        private const char AI = 'O';
        private const char Human = 'X';

        public (int row, int col) FindBestMove(Board board)
        {
            int bestScore = int.MinValue;
            (int, int) bestMove = (-1, -1);

            foreach (var (row, col) in board.GetEmptyCells())
            {
                board.Placemark(row, col, AI);
                int score = Minimax(board, 0, false);
                board.Placemark(row, col, ' ');

                if (score > bestScore)
                {
                    bestScore = score;
                    bestMove = (row, col);
                }
            }
            return bestMove;
        }

        private int Minimax(Board board, int depth, bool isMaximizing)
        {
            char winner = board.CheckWinner();
            if (winner == AI) return 10 - depth;
            if (winner == Human) return depth - 10;
            if (board.IsFull()) return 0;

            if (isMaximizing)
            {
                int best = int.MinValue;
                foreach (var (row, col) in board.GetEmptyCells())
                {
                    board.Placemark(row, col, AI);
                    best = Math.Max(best, Minimax(board, depth + 1, false));
                    board.Placemark(row, col, ' ');
                }
                return best;
            }
            else
            {
                int best = int.MaxValue;
                foreach (var (row, col) in board.GetEmptyCells())
                {
                    board.Placemark(row, col, Human);
                    best = Math.Min(best, Minimax(board, depth + 1, true));
                    board.Placemark(row, col, ' ');
                }
                return best;
            }
        }
    }
}