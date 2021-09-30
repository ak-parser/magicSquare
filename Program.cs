using System;

namespace MagicSquare
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine()), start, end;
            int halfN = n / 2;
            int length = n + halfN * 2;

            //Initialize array
            int[][] magicSquare = new int[length][];
            for (int i = 0; i < length; i++)
                magicSquare[i] = new int[length];

            //Fill array
            int count = 1;
            for (int i = n - 1; i >= 0; i--)
            {
                int indexI = n - 1 - i;

                for (int j = i; j < i + n; j++)
                {
                    magicSquare[indexI][j] = count;
                    count++;
                    indexI++;
                }
            }

            //top
            start = end = n - 1;
            for (int i = 0; i < halfN; i++)
            {
                for (int j = start; j <= end; j += 2)
                    magicSquare[i + n][j] = magicSquare[i][j];
                start--;
                end++;
            }
            //bottom
            start = end = n - 1;
            for (int i = length - 1; i >= n + halfN; i--)
            {
                for (int j = start; j <= end; j += 2)
                    magicSquare[i - n][j] = magicSquare[i][j];
                start--;
                end++;
            }
            //left
            start = end = n - 1;
            for (int j = 0; j < halfN; j++)
            {
                for (int i = start; i <= end; i += 2)
                    magicSquare[i][j + n] = magicSquare[i][j];
                start--;
                end++;
            }
            //right
            start = end = n - 1;
            for (int j = length - 1; j >= n + halfN; j--)
            {
                for (int i = start; i <= end; i += 2)
                    magicSquare[i][j - n] = magicSquare[i][j];
                start--;
                end++;
            }

            //output
            for (int i = halfN; i < length - halfN; i++)
            {
                for (int j = halfN; j < length - halfN; j++)
                    Console.Write(magicSquare[i][j] + " ");
                Console.WriteLine();
            }
        }
    }
}