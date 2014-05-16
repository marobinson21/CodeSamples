using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape baseshape = new Shape("Box");
            Polygon newpolygon = new Polygon("Pentagon", 5);

            Console.WriteLine(baseshape);
            Console.WriteLine(newpolygon);

            baseshape = newpolygon;

            Console.WriteLine(baseshape);
            Console.WriteLine(newpolygon);

            Quadrilateral newquad = new Quadrilateral("Square",new int[] {4,4,4,4});

            Console.WriteLine(newquad);

            try
            {
                Quadrilateral notworkingquad = new Quadrilateral("Triangle", new int[] { 4, 4, 4 });
            }
            catch(PolygonException)
            {
                Console.WriteLine("Error: object is not a polygon!");
            }

            Console.ReadLine();
        }
    }

    class Shape
    {
        private string name;

        public Shape(string inName)
        {
            this.name = inName;
        }

        public override string ToString()
        {
            return "Name: " + this.name;
        }
    }

    class Polygon : Shape
    {
        private int numsides;

        public Polygon(string inName,int inSides) : base(inName)
        {
            numsides = inSides;
        }

        public override string ToString()
        {
            return base.ToString() + " Sides: " + numsides.ToString();
        }

        public int getSides()
        {
            return numsides;
        }
    }

    class Quadrilateral : Polygon
    {
        private int[] sides;
        public Quadrilateral(string inName,int[] inSides) : base(inName,4)
        {
            if(inSides.Length != 4)
            {
                throw new PolygonException();
            }
            sides = new int[4];
            for(int i=0;i<4;i++)
            {
                sides[i] = inSides[i];
            }
        }

        public int perimeter()
        {
            int total = 0;
            foreach(int side in sides)
            {
                total += side;
            }

            return total;
        }

        public override string ToString()
        {
            return base.ToString() + " Perimeter: " + this.perimeter();
        }
    }

    public class PolygonException : Exception
    {
        public PolygonException()
        {

        }

        public PolygonException(string message) : base(message)
        {

        }

        public PolygonException(string message, Exception inner) : base(message,inner)
        {

        }
    }
}
