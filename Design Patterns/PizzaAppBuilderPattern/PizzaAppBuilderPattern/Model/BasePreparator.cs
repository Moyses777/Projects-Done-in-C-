using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaAppBuilderPattern.Model
{
    public class BasePreparator
    {
        private string _name;
        private string _kindOf;
        private int _quantity;

        public string name { get { return _name; } set { if (_name != value) _name = value; } }
        public string kindOf { get { return _kindOf; } set { if (_kindOf != value) _kindOf = value; } }
        public int quantity { get { return _quantity; } set { if (_quantity != value) _quantity = value; } }

    }
}
