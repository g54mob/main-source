using System;
using System.Collections.Generic;
using Data.Variables.Recipes;

namespace Data.SaveData.PersistentSOs
{
	[Serializable]
	public class UnlockedRecipesSaveData : AbstractSaveData
	{
		public const int CurrentVersion = 0;

		public List<RecipeID> UnlockedRecipesIDs;

		public UnlockedRecipesSaveData(List<RecipeID> unlockedRecipesIDs)
			: base(0)
		{
			UnlockedRecipesIDs = unlockedRecipesIDs;
		}
	}
}
