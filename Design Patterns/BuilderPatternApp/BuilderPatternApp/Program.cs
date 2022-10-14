using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPatternApp
{
    public class HtmlElement
    {
        public string Name, Text;
        public List<HtmlElement> Elements = new List<HtmlElement>();
        private const int indentSize = 2;

        public HtmlElement()
        {

        }

        public HtmlElement(string name, string text)
        {
            this.Name = name ?? throw new ArgumentNullException(paramName: nameof(name));
            this.Text = text ?? throw new ArgumentNullException(paramName: nameof(text));
        }

        private string ToStringImpl(int indent)
        {
            var sb = new StringBuilder();
            var i = new string(' ', indentSize * indent);
            sb.AppendLine($"{ i }<{ Name }>");
            if(!string.IsNullOrEmpty(Text))
            {
                sb.Append(new string(' ', indentSize * (indent +1)));
                sb.AppendLine(Text);
            }

            foreach(var item in Elements)
            {
                sb.Append(item.ToStringImpl(indent + 1));
            }
            sb.AppendLine($"{ i }</{ Name }>");

            return sb.ToString();
        }

        public override string ToString()
        {
            return ToStringImpl(0);
        }

    }

    public class HtmlBuilder
    {
        HtmlElement root = new HtmlElement();
        private readonly string _rootName;

        public HtmlBuilder(string rootName)
        {
            this._rootName = rootName;
            root.Name = rootName;
        }

        public void addChild(string childName, string childText)
        {
            var e = new HtmlElement(childName, childText);
            root.Elements.Add(e);
        }

        public override string ToString()
        {
            return root.ToString();
        }

        public void Clear()
        {
            root = new HtmlElement { Name = this._rootName };
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var builder = new HtmlBuilder("ul");
            builder.addChild("li", "Hello world");
            builder.addChild("li", "Goodbye world :'v");
            Console.WriteLine(builder.ToString());
            Console.ReadKey();
        }
    }
}
