using UnityEngine;

namespace Data.Variables.Recipes
{
	[CreateAssetMenu(menuName = "Variables/Recipe/Recipe Data", fileName = "RecipeData", order = 0)]
	public class RecipeData : ScriptableObject
	{
		[SerializeField]
		private RecipeID recipeRecipeID;

		[SerializeField]
		private ResourceRecipe _recipe;

		public ResourceRecipe Recipe => _recipe;

		public RecipeID RecipeID => recipeRecipeID;
	}
}
