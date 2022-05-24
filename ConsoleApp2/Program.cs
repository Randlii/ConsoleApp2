using System;
using System.IO;
namespace Box
{
    struct Point
    {
        public int X;
        public int Y;
    }
    class Box
    {
        public int xl;
        public int yl;
        public int h;
        int w;

        public int W
        {
            get
            {
                return w;
            }
            set
            {
                w = value;
            }
        }

        public Box()
        {

        }
        public Box(int x, int y, int height, int width)
        {
            xl = x;
            yl = y;
            h = height;
            w = width;

        }
        public virtual void Display()
        {
            Console.WriteLine("Box was displayed:");
            Console.WriteLine(xl);
            Console.WriteLine(yl);
            Console.WriteLine(h);
            Console.WriteLine(w);
        }
        public bool Test(Point pt)
        {
            int res = yl - h;
            int res2 = xl + w;
            if (pt.Y <= yl && pt.Y >= res && pt.X >= xl && pt.X <= res2)
            {
                return true;
            }
            return false;


        }
        public static Box operator +(Box b1, Box b2)
        {
            int x11 = b1.xl;
            int x12 = b1.xl + b1.w;
            int y11 = b1.yl;
            int y12 = b1.yl - b1.h;
            int x21 = b2.xl;
            int x22 = b2.xl + b2.w;
            int y21 = b2.yl;
            int y22 = b2.yl - b2.h;

            int x31 = Math.Max(x11, x21);
            int x32 = Math.Min(x12, x22);
            int y31 = Math.Min(y11, y21);
            int y32 = Math.Max(y12, y22);

            return new Box(x31, y31, y31 - y32, x32 - x31);
        }

    }
    class TextBox : Box
    {
        public string text;

        public TextBox()
        {

        }

        public TextBox(string t)
        {
            text = t;
        }

        public override void Display()
        {
            Console.WriteLine(text);
        }

        public void WriteInFile(string path)
        {
            StreamWriter writer = new StreamWriter(path, true);
            writer.WriteLine(text);
            writer.Close();

        }
    }



    class MainClass
    {
        public static void Main(string[] args)
        {
            Box b = new Box(1, 2, 3, 5);
            TextBox tb = new TextBox("box");
            tb.Display();
            b.Display();
            Box b2 = new Box(1, 1, 7, 5);
            Box b3 = b + b2;
            tb.WriteInFile("index.txt");
            b3.Display();
            Box[] ArrayBox = { b, b2, b3 };

            ;










        }
    }
}