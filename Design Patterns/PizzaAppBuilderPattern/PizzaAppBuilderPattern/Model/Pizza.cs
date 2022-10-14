using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaAppBuilderPattern.Model
{
    public class Pizza
    {
        public List<Ingredient> ingredients { get { return ingredients; } private set { if (ingredients != value) ingredients = value; } }
        public List<BasePreparator> bases { get { return bases; } private set { if (bases != value) bases = value; } }

        public Pizza(List<Ingredient> ingredients, List<BasePreparator> bases)
        {
            this.bases = bases;
            this.ingredients = ingredients;
        }
    }
}
