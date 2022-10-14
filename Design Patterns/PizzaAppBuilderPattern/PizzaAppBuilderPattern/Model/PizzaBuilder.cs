using PizzaAppBuilderPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaAppBuilderPattern.Model
{
    class PizzaBuilder : IBuilder
    {
        private Pizza _pizza;
        private List<BasePreparator> _bases;
        private List<Ingredient> _ingredients;

        public PizzaBuilder()
        {
            _bases = new List<BasePreparator>();
            _ingredients = new List<Ingredient>();
        }

        public IBuilder addBasePreparator(BasePreparator bases)
        {
            _bases.Add(bases);
            return this;
        }

        public IBuilder addIngredients(Ingredient ingredient)
        {
            _ingredients.Add(ingredient);
            return this;
        }

        public Pizza build()
        {
            _pizza = new Pizza(_ingredients, _bases);
            return _pizza;
        }

        public void clean()
        {
            _bases.Clear();
            _ingredients.Clear();
        }
    }
}
