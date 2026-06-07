using System;
using UnityEngine;

namespace UMA.Examples
{
	public class UMARecipeMixer : MonoBehaviour
	{
		public enum SelectionType
		{
			IncludeOne = 0,
			IncludeSome = 1,
			IncludeAll = 2,
			IncludeNone = 3
		}

		[Serializable]
		public class RecipeSection
		{
			public string name;

			public SelectionType selectionRule;

			public UMARecipeBase[] recipes;
		}

		public RaceData raceData;

		public RecipeSection[] recipeSections;

		public UMARecipeBase[] additionalRecipes;

		public void FillUMARecipe(UMAData.UMARecipe umaRecipe, UMAContextBase context)
		{
		}

		private void IncludeRecipe(UMARecipeBase recipe, UMAData.UMARecipe umaRecipe, UMAContextBase context, bool dontSerialize)
		{
		}
	}
}
