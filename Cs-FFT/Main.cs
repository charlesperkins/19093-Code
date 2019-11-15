/* @Brief
 * Measures runtime performance of FFT function, using fourier.cs & complex.cs
 *
 * @Description 
 * 
 * @TODO
 *  read first line of data to find # of rows?
 * 
 * Data Input Structure
 * [ r1 i1 ]  Each row is one element for a complex array
 * [ r2 i2 ]  1st column for real component
 * [ r3 i3 ]  2nd column for imaginary component
 * [ . . . ]
 */

using System;

namespace FFT
{
    class Main
    {
        public static void Main(string[] args)
        {
        // Open and read noisySignal.txt file
        String input = File.ReadAllText( @"C:\Libraries\OneDrive\Documents\MATLAB\Senior Design\noisySignal.txt" );
        
        // Reading text file line by line to reduce memory usage with large text files
        int i = 0, j = 0;
        double[,] result = new double[row, 2]
        
        // Put contents into complex array
        Complex[] data = { };
        
        // Start timer!
        // Call fft method
        fft(input);
        
        // Return fft into a new file
        // End timer!
        
        
        }
    }
}
