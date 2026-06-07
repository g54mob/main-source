using System.Collections.Generic;
using UnityEngine;

namespace Data.Variables.Recipes
{
	[CreateAssetMenu(menuName = "Variables/Recipe/Recipe Database", fileName = "RecipeDatabase", order = 1)]
	public class RecipeDatabase : ScriptableObject
	{
		[SerializeField]
		private List<RecipeData> recipes;

		public List<RecipeData> Recipes => recipes;

		public RecipeData TryGetRecipeDataByID(RecipeID recipeID)
		{
			foreach (RecipeData recipe in recipes)
			{
				if (recipeID == recipe.RecipeID)
				{
					return recipe;
				}
			}
			return null;
		}
	}
}
