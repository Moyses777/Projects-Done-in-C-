using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDApp
{
    /*public class Journal
    {
        private readonly List<string> entries = new List<string>();
        private static int count = 0;

        public int addEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count;
        }

        public void removeEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }

    }

    public class Persistence
    {
        public void SaveToFile(Journal journal, string filename, bool overwrite = false)
        {
            if (overwrite || !System.IO.File.Exists(filename))
            {
                System.IO.File.WriteAllText(filename, journal.ToString());
            } 
        }
    }*/

    public enum Color
    {
        Red, Green, Blue
    }

    public enum Size
    {
        Small, Medium, Large, Huge
    }

    public class product
    {
        private string _name;
        private Color _color;
        private Size _size;

        public string name
        {
            get { return _name; }
            set { if (_name != value) _name = value; }
        }

        public Color color
        {
            get { return _color; }
            set { if (_color != value) _color = value; }
        }

        public Size size
        {
            get { return _size; }
            set { if (_size != value) _size = value; }
        }

        public product(string name, Color color, Size size)
        {
            this._name = name;
            this._color = color;
            this._size = size;
        }

    }

    public class productFilter
    {
        public static IEnumerable<product> FilterBySize(IEnumerable<product> products, Size size)
        {
            foreach (var product in products)
            {
                if (product.size == size)
                {
                    yield return product;
                }
            }
        }
    }

    public interface ISpecification<T>
    {
        bool IsSatisfied(T t);
    }

    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }

    public class SizeAndColorSpecification<T> : ISpecification<T>
    {
        private ISpecification<T> _first, _second;

        public SizeAndColorSpecification(ISpecification<T> first, ISpecification<T> second)
        {
            this._first = first ?? throw new ArgumentNullException(paramName: nameof(first));
            this._second = second ?? throw new ArgumentNullException(paramName: nameof(second));
        }

        public bool IsSatisfied(T t)
        {
            return this._first.IsSatisfied(t) && this._second.IsSatisfied(t);
        }
    }

    public class SizeSpecification : ISpecification<product>
    {
        private Size _size;

        public SizeSpecification(Size size)
        {
            this._size = size;
        } 

        public bool IsSatisfied(product t)
        {
            return this._size == t.size;
        }
    }

    public class ColorSpecification : ISpecification<product>
    {
        private Color _color;

        public ColorSpecification(Color color)
        {
            this._color = color;
        }

        public bool IsSatisfied(product prod)
        {
            return this._color == prod.color;
        }
    }

    public class BetterFilter : IFilter<product>
    {
        public IEnumerable<product> Filter(IEnumerable<product> items, ISpecification<product> spec)
        {
            foreach (var item in items)
            {
                if (spec.IsSatisfied(item))
                {
                    yield return item;
                }
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            /*Journal j = new Journal();
            j.addEntry("I cried");
            j.addEntry("I ate a bug");
            Console.WriteLine(j);
            Console.ReadLine();
            Persistence persistence = new Persistence();
            persistence.SaveToFile(j, @"c:\temp\journal.txt", true);
            System.Diagnostics.Process.Start(@"c:\temp\journal.txt");*/
            product apple = new product("Apple", Color.Red, Size.Small);
            product tree = new product("Tree", Color.Green, Size.Large);
            product house = new product("House", Color.Green, Size.Large);

            product[] products = { apple, tree, house };

            BetterFilter bf = new BetterFilter();
            Console.WriteLine("Green products (new): ");
            foreach (var item in bf.Filter(products, new SizeSpecification(Size.Small)))
            {
                Console.WriteLine($"{item.name} and { item.size } is { item.color }");
            }
            Console.ReadLine();
        }
    }
}
