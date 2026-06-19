using System;
using System.Collections.Generic;
using UnityEngine;

namespace UniversalInventorySystem
{
	[Serializable]
	[AddComponentMenu("UniversalInventorySystem/RecipeGroup")]
	[CreateAssetMenu(fileName = "RecipeGroup", menuName = "UniversalInventorySystem/RecipeGroup", order = 10)]
	public class RecipeGroup : ScriptableObject
	{
		public List<Recipe> recipesList = new List<Recipe>();

		public List<PatternRecipe> receipePatternsList = new List<PatternRecipe>();

		[Space]
		public string strId;

		public int id;

		public Recipe GetRecipeAtIndex(int index)
		{
			return recipesList[index];
		}

		public Recipe GetRecipeWithName(string _key)
		{
			foreach (Recipe recipes in recipesList)
			{
				if (recipes.key == _key)
				{
					return recipes;
				}
			}
			return null;
		}

		public Recipe GetRecipeWithID(int _id)
		{
			foreach (Recipe recipes in recipesList)
			{
				if (recipes.id == _id)
				{
					return recipes;
				}
			}
			return null;
		}

		public List<Recipe> OrderRecipeById()
		{
			return RecipeInsertionSort(recipesList);
		}

		private static List<Recipe> RecipeInsertionSort(List<Recipe> inputArray)
		{
			for (int i = 0; i < inputArray.Count - 1; i++)
			{
				for (int num = i + 1; num > 0; num--)
				{
					if (inputArray[num - 1].id > inputArray[num].id)
					{
						int num2 = inputArray[num - 1].id;
						inputArray[num - 1].id = inputArray[num].id;
						inputArray[num].id = num2;
					}
				}
			}
			return inputArray;
		}

		public PatternRecipe GetRecipePatternAtIndex(int index)
		{
			return receipePatternsList[index];
		}

		public PatternRecipe GetRecipePatternWithKey(string _key)
		{
			foreach (PatternRecipe receipePatterns in receipePatternsList)
			{
				if (receipePatterns.key == _key)
				{
					return receipePatterns;
				}
			}
			return null;
		}

		public PatternRecipe GetRecipePatternWithID(int _id)
		{
			foreach (PatternRecipe receipePatterns in receipePatternsList)
			{
				if (receipePatterns.id == _id)
				{
					return receipePatterns;
				}
			}
			return null;
		}

		public List<PatternRecipe> OrderRecipePatternById()
		{
			return RecipePatternInsertionSort(receipePatternsList);
		}

		private static List<PatternRecipe> RecipePatternInsertionSort(List<PatternRecipe> inputArray)
		{
			for (int i = 0; i < inputArray.Count - 1; i++)
			{
				for (int num = i + 1; num > 0; num--)
				{
					if (inputArray[num - 1].id > inputArray[num].id)
					{
						int num2 = inputArray[num - 1].id;
						inputArray[num - 1].id = inputArray[num].id;
						inputArray[num].id = num2;
					}
				}
			}
			return inputArray;
		}
	}
}
