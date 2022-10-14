using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaAppBuilderPattern.Model
{
    public class Chef
    {
        public Chef()
        {

        }

        public Pizza buildPizza()
        {
            PizzaBuilder pizza = new PizzaBuilder();
            pizza.addIngredients(new Ingredient
            {
                name = "Peperoni",
                cook = true,
                kindOf = "Diet",
                quantity = 8
            }).addBasePreparator(new BasePreparator
            {
                name = "Mough",
                kindOf = "Diet",
                quantity = 1
            });
            return pizza.build();
        }
    }
}
