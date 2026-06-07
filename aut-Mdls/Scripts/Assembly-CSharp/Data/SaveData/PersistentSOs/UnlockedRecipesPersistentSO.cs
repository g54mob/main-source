#define ENABLE_DEBUG_ERRORS
using System;
using System.Collections.Generic;
using System.Linq;
using Data.Variables.Recipes;
using UnityEngine;
using Utils;

namespace Data.SaveData.PersistentSOs
{
	[CreateAssetMenu(menuName = "PersistentSOs/Unlocked Recipes", fileName = "UnlockedRecipesPersistentSO")]
	public class UnlockedRecipesPersistentSO : AbstractPersistentSO
	{
		[SerializeField]
		private List<RecipeData> _defaultUnlockedRecipes;

		[SerializeField]
		private RecipeDatabase _recipeDatabase;

		private List<RecipeData> _unlockedRecipes = new List<RecipeData>();

		public event Action OnUnlockedRecipesChanged = delegate
		{
		};

		public bool IsRecipeUnlocked(RecipeData recipeData)
		{
			if (recipeData != null)
			{
				return _unlockedRecipes.Contains(recipeData);
			}
			return false;
		}

		public void TryUnlockRecipe(RecipeData recipeData)
		{
			if (recipeData == null)
			{
				this.LogError("Can't unlock null recipe!", "TryUnlockRecipe", 29);
				return;
			}
			if (IsRecipeUnlocked(recipeData))
			{
				this.LogError("Recipe " + recipeData.name + " is already unlocked!", "TryUnlockRecipe", 35);
				return;
			}
			_unlockedRecipes.Add(recipeData);
			this.OnUnlockedRecipesChanged();
		}

		protected override void ApplyLoadedSaveData(AbstractSaveData saveData)
		{
			UnlockedRecipesSaveData obj = saveData as UnlockedRecipesSaveData;
			List<RecipeData> list = new List<RecipeData>();
			foreach (RecipeID unlockedRecipesID in obj.UnlockedRecipesIDs)
			{
				RecipeData recipeData = _recipeDatabase.TryGetRecipeDataByID(unlockedRecipesID);
				if (recipeData == null)
				{
					this.LogError("Savegame contained a recipeData that was null!", "ApplyLoadedSaveData", 54);
				}
				else
				{
					list.Add(recipeData);
				}
			}
			_unlockedRecipes = list;
			this.OnUnlockedRecipesChanged();
		}

		public override void ResetToDefaults()
		{
			List<RecipeData> list = new List<RecipeData>();
			foreach (RecipeData defaultUnlockedRecipe in _defaultUnlockedRecipes)
			{
				list.Add(defaultUnlockedRecipe);
			}
			_unlockedRecipes.Clear();
			_unlockedRecipes.AddRange(list);
			this.OnUnlockedRecipesChanged();
		}

		public override AbstractSaveData GetSaveData()
		{
			return new UnlockedRecipesSaveData(_unlockedRecipes.Select((RecipeData recipe) => recipe.RecipeID).ToList());
		}

		public override bool TryLoadSaveData(string fullPath)
		{
			return TryLoadSaveDataInternal<UnlockedRecipesSaveData>(fullPath);
		}
	}
}
