using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDAppLiskovPrinciple
{
    /*public class rectangle
    {
        private int _width;
        private int _height;

        public virtual int width
        {
            get { return _width; }
            set { if (_width != value) _width = value; }
        }

        public virtual int height
        {
            get { return _height; }
            set { if (_height != value) _height = value; }
        }

        public rectangle()
        {

        }

        public rectangle(int width, int height)
        {
            this._width = width;
            this._height = height;
        }

        public override string ToString()
        {
            return $"{ nameof(_width) }: { _width }, { nameof(_height) }: { _height }";
        }

    }

    public class square : rectangle
    {
        public override int width { set { base.width = base.height = value; } }
        public override int height { set { base.height = base.width = value; } }


    }*/

    public class document
    {

    }

    public interface IMachine : IPrinter, IScanner, IFax
    {

    }

    public class multiFunctionalPrinter : IMachine
    {
        public void fax(document d)
        {
            throw new NotImplementedException();
        }

        public void print(document d)
        {
            throw new NotImplementedException();
        }

        public void scan(document d)
        {
            throw new NotImplementedException();
        }
    }

    public interface IPrinter
    {
        void print(document d);
    }

    public interface IScanner
    {
        void scan(document d);
    }

    public interface IFax
    {
        void fax(document d);
    }

    class Program
    {
        //public static int Area(rectangle rc) => rc.width * rc.height;

        public static void Main(string[] args)
        {
            /*rectangle rc = new rectangle(3, 8);
            Console.WriteLine($"{ rc } has area { Area(rc) }");
            Console.ReadLine();*/
        }
    }
}
