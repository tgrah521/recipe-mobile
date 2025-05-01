using Recipes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.Models
{
    public class NewMeal
    {
        public string MealName { get; set; }
        public string Note { get; set; }
        public int Stars { get; set; }
        public List<Ingredient> Ingredients { get; set; }
    }

    public class Meal : NewMeal
    {
        public int Id { get; set; }
    }
}

