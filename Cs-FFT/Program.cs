// Program.cs is one implementation for calculating FFT, 
// the other two files (complex.cs & fourier.cs) are a separate
// implementation for FFTs

using System;
using System.Numerics;
using System.Linq;
using System.Diagnostics;

/* TODO
 * in Main, fill the input array with data from the NoisySignal.txt file, instead of hard coded values
 *      '-> this might mean modifying the rest of the code to only work with real values, not complex
 * add code to measure runtime performance
 */

/* Alternatives:
 * https://www.extremeoptimization.com/QuickStart/CSharp/FourierTransforms.aspx
 * 
 * Comparisons of various FFT implementations
 * https://www.codeproject.com/Articles/1095473/Comparison-of-FFT-Implementations-for-NET
 */

// Fast Fourier Transform in C#
// From http://rosettacode.org/wiki/Fast_Fourier_transform#C.23
//  Information on the algorithm used: https://en.wikipedia.org/wiki/Cooley%E2%80%93Tukey_FFT_algorithm

namespace FFT
{
    public class Program
    {
        /* Performs a Bit Reversal Algorithm on a positive integer
         * for given number of bits
         * e.g. 011 with 3 bits is reversed to 110 */
public static int BitReverse(int n, int bits)
        {
            int reversedN = n;
            int count = bits - 1;

            n >>= 1;
            while (n > 0)
            {
                reversedN = (reversedN << 1) | (n & 1);
                count--;
                n >>= 1;
            }

            return ((reversedN << count) & ((1 << bits) - 1));
        }

        /* Uses Cooley-Tukey iterative in-place algorithm with radix-2 DIT case
         * assumes number of points provided are a power of 2 */
         public static void FFT(Complex[] buffer)
        {
            int bits = (int)Math.Log(buffer.Length, 2);
            for (int j = 1; j < buffer.Length; j++)
            {
                int swapPos = BitReverse(j, bits);
                if (swapPos <= j)
                {
                    continue;
                }
                var temp = buffer[j];
                buffer[j] = buffer[swapPos];
                buffer[swapPos] = temp;
            }

            // First the full length is used and 1011 value is swapped with 1101. Second if new swapPos is less than j
            // then it means that swap was happen when j was the swapPos.

            for (int N = 2; N <= buffer.Length; N <<= 1)
            {
                for (int i = 0; i < buffer.Length; i += N)
                {
                    for (int k = 0; k < N/2; k++)
                    {
                        int evenIndex = i + k;
                        int oddIndex = i + k + (N / 2);
                        var even = buffer[evenIndex];
                        var odd = buffer[oddIndex];

                        double term = -2 * Math.PI * k / (double)N;
                        Complex exp = new Complex(Math.Cos(term), Math.Sin(term)) * odd;

                        buffer[evenIndex] = even + exp;
                        buffer[oddIndex] = even - exp;

                    }
                }
            }
        }
        public static void Main(string[] args)
        {
            Complex[] input = { 1.0, 1.0, 1.0, 1.0, 0.0, 0.0, 0.0, 0.0 };

            FFT(input);

            Console.WriteLine("Results:");
            foreach (Complex c in input)
            {
                Console.WriteLine(c);
            }
        }
    }
}
