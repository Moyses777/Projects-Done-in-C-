using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InherenceExampleBuilderPattern
{
    public class Ingredient
    {
        private string _name;
        private int _quantity;
        private string _kind;

        public string name { get { return _name; } set { if (_name != value) _name = value; } }
        public int quantity { get { return _quantity; } set { if (_quantity != value) _quantity = value; } }
        public string kind { get { return _kind; } set { if (_kind != value) _kind = value; } }
    }

    public abstract class IngredientBuilder
    {
        protected Ingredient ingredient = new Ingredient();

        public Ingredient Build() => ingredient;
    }

    public class Base
    {
        private string _name;
        private string _kind;
        private int _quantity;

        public string name { get { return _name; } set { if (_name != value) _name = value; } }
        public int quantity { get { return _quantity; } set { if (_quantity != value) _quantity = value; } }
        public string kind { get { return _kind; } set { if (_kind != value) _kind = value; } }
    }

    public class Food
    {
        private string _name;
        private List<Ingredient> _ingredients = new List<Ingredient>();
        private Base _base = new Base();

        public class Builder : NamefoodBuilder<Builder>
        {

        }

        public static Builder New => new Builder();

        public string name { get { return _name; } set { if (_name != value) _name = value; } }
        public List<Ingredient> ingredients { get { return _ingredients; } set { if (_ingredients != value) _ingredients = value; } }
        public Base bases { get { return _base; } set { if (_base != value) _base = value; } }
    }

    public abstract class FoodBuilder
    {
        protected Food food = new Food();

        public Food Build()
        {
            return food;
        }
    }

    public class TemperatureFoodBuilder<SELF> : FoodBuilder where SELF : TemperatureFoodBuilder<SELF>
    {
        public SELF AddTemperatureBuildFood(string basesName, string bases, int quantity = 1)
        {
            this.food.bases.name = basesName;
            this.food.bases.kind = bases;
            this.food.bases.quantity = quantity;
            return (SELF) this;
        }
    }

    public class IngredientsFoodBuilder<SELF> : TemperatureFoodBuilder<IngredientsFoodBuilder<SELF>> where SELF : IngredientsFoodBuilder<SELF> 
    {
        public SELF AddIngredient(Ingredient ingredient)
        {
            this.food.ingredients.Add(ingredient);
            return (SELF) this;
        }
    }

    public class NamefoodBuilder<SELF> : IngredientsFoodBuilder<NamefoodBuilder<SELF>> where SELF : NamefoodBuilder<SELF>
    {
        public SELF AddNameFood(string name)
        {
            this.food.name = name;
            return (SELF) this;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var newFood = Food.New.AddTemperatureBuildFood("Mough", "HOT")
                .AddIngredient(new Ingredient
                {
                    name = "Meat",
                    kind = "meat",
                    quantity = 1
                })
                .AddIngredient(new Ingredient
                {
                    name = "Cheese",
                    kind = "Milk",
                    quantity = 5
                })
                .AddNameFood("Pizza").Build();
            Console.WriteLine($"Food name { newFood.name } and food base is { newFood.bases.name } base kind is { newFood.bases.kind } and ingredients are { newFood.ingredients[0].name }");
            Console.ReadKey();
        }
    }
}
