using System;
//using System.Collections.Generic;
//using System.Text;

namespace FFT
{
    class complex
    {
        public double real = 0.0;   // 11/13/2019 Replaced float with double
        public double imag = 0.0;   // 11/13/2019 Replaced float with double
        //Empty constructor
        public complex()
        {
        }
        public complex(double real, double im)   // 11/13/2019 Replaced floats with doubles
        {
            this.real = real;
            this.imag = im;
        }
        public string ToString()
        {
            string data = real.ToString() + " " + imag.ToString() + "i";
            return data;
        }
        
        //Convert from polar to rectangular
        public static complex from_polar(double r, double radians)
        {
            complex data = new complex(r * Math.Cos(radians), r * Math.Sin(radians));
            return data;
        }
        //Override addition operator
        public static complex operator +(complex a, complex b)
        {
            complex data = new complex(a.real + b.real, a.imag + b.imag);
            return data;
        }
        //Override subtraction operator
        public static complex operator -(complex a, complex b)
        {
            complex data = new complex(a.real - b.real, a.imag - b.imag);
            return data;
        }
        //Override multiplication operator
        public static complex operator *(complex a, complex b)
        {
            complex data = new complex((a.real * b.real) - (a.imag * b.imag),
           (a.real * b.imag + (a.imag * b.real)));
            return data;
        }
        //Return magnitude of complex number
        public double magnitude   // 11/13/2019 Replaced float with double
        {
            get
            {
                return Math.Sqrt(Math.Pow(real, 2) + Math.Pow(imag, 2));
            }
        }
        public double phase   // 11/13/2019 Replaced float with double
        {
            get
            {
                return Math.Atan(imag / real);
            }
        }
    }
}
