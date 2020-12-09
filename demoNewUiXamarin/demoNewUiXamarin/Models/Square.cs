using System;
using System.Collections.Generic;
using System.Text;

namespace demoNewUiXamarin.Models
{
    public struct Square
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public double Area { get; private set; }

        public Square(double width, double height)
        {
            Width = width;
            Height = height;
            Area = width * width;
        }
    }
}
