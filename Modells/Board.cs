using System.Diagnostics.Contracts;
using System;
using System.Collections.Generic;

namespace TicTacToe.Modells
{
    public class Board
    {
        private char[,] cells = new char[3, 3];

        public Board()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    cells[i, j] = ' ';
        }

        public void Print()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($" {cells[i,0]} | {cells[i,1]} | {cells[i,2]} ");
                if (i < 2)
                    Console.WriteLine("---+---+---");
            }
        }

        public bool Placemark(int row, int col, char mark)
        {
            if (row < 0 || row > 2 || col < 0 || col > 2)
                return false;

            if (cells[row, col] != ' ')
                return false;

            cells[row, col] = mark;
            return true;
        }

        // Zum Zurücknehmen eines Zugs im Minimax - ohne Validierung
        public void ClearCell(int row, int col)
        {
            cells[row, col] = ' ';
        }

        public char GetCell(int row, int col)
        {
            return cells[row, col];
        }

        public bool IsFull()
        {
            foreach (char c in cells)
                if (c == ' ') return false;
            return true;
        }

        public List<(int row, int col)> GetEmptyCells()
        {
            var empty = new List<(int, int)>();
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (cells[i, j] == ' ')
                        empty.Add((i, j));
            return empty;
        }

        public char CheckWinner()
        {
            for (int i = 0; i < 3; i++)
            {
                if (cells[i,0] != ' ' && cells[i,0] == cells[i,1] && cells[i,1] == cells[i,2])
                    return cells[i,0];
                if (cells[0,i] != ' ' && cells[0,i] == cells[1,i] && cells[1,i] == cells[2,i])
                    return cells[0,i];
            }
            if (cells[0,0] != ' ' && cells[0,0] == cells[1,1] && cells[1,1] == cells[2,2])
                return cells[0,0];
            if (cells[0,2] != ' ' && cells[0,2] == cells[1,1] && cells[1,1] == cells[2,0])
                return cells[0,2];
            return ' ';
        }
    }
}