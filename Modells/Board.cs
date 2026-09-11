using System;
using System.Diagnostics.Contracts;

namespace TicTacToe.Modells
{
    public class Board
    {
        private char [,] cells = new char [3,3];

        public Board()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    cells[i, j] = ' ';
                }
            }

        }

        public void Print()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($" {cells[i,0]} | {cells[i,1]} | {cells[i,2]} ");
                if (i < 2)
                    Console.WriteLine("---+---+---"); //Field
            }

        }


            public bool Placemark(int row, int col, int mark)
        {
            if (row < 0 || row > 2 || col < 0 || col > 2)
                return false;

            if (cells[row, col] != ' ')
                return false;

            cells[row, col] = mark;
            return true;

        }

        public char GetCell(int row, int col)
        {
            return cells[row, col];
        }

        public bool IsFull()
        {
            foreach (char c in cells)
            {
                if (c == ' ') return false; // looking for a free spot
            }
            return true;
        }

    }





}