using PizzaAppBuilderPattern.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaAppBuilderPattern.Interfaces
{
    public interface IBuilder
    {
        IBuilder addBasePreparator(BasePreparator bases);
        IBuilder addIngredients(Ingredient ingredient);
    }
}
