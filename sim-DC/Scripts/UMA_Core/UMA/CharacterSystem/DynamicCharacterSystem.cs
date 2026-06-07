using System;
using System.Collections.Generic;
using UnityEngine;

namespace UMA.CharacterSystem
{
	public class DynamicCharacterSystem : DynamicCharacterSystemBase
	{
		public Dictionary<string, UMATextRecipe> RecipeIndex;

		public Dictionary<string, Dictionary<string, List<UMATextRecipe>>> Recipes;

		public Dictionary<string, string> CharacterRecipes;

		public bool initializeOnAwake;

		[NonSerialized]
		[HideInInspector]
		public bool initialized;

		private bool isInitializing;

		public bool dynamicallyAddFromResources;

		[Tooltip("Limit the Global Library search to the following folders (no starting slash and seperate multiple entries with a comma)")]
		public string resourcesCharactersFolder;

		[Tooltip("Limit the Global Library search to the following folders (no starting slash and seperate multiple entries with a comma)")]
		public string resourcesRecipesFolder;

		public bool dynamicallyAddFromAssetBundles;

		[Tooltip("Limit the AssetBundles search to the following bundles (no starting slash and seperate multiple entries with a comma)")]
		public string assetBundlesForCharactersToSearch;

		[Tooltip("Limit the AssetBundles search to the following bundles (no starting slash and seperate multiple entries with a comma)")]
		public string assetBundlesForRecipesToSearch;

		[Tooltip("If true will automatically scan and add all UMATextRecipes from any downloaded bundles.")]
		public bool addAllRecipesFromDownloadedBundles;

		[HideInInspector]
		public UMAContextBase context;

		public Dictionary<string, List<string>> assetBundlesUsedDict;

		[NonSerialized]
		[HideInInspector]
		public bool downloadAssetsEnabled;

		public override void Awake()
		{
		}

		public override void Start()
		{
		}

		public override void Init()
		{
		}

		public void EnsureRaceKey(string race)
		{
		}

		public void RefreshRaceKeys()
		{
		}

		public override void Refresh(bool forceUpdateRaceLibrary = true, string bundleToGather = "")
		{
		}

		private void AddCharacterRecipes(TextAsset[] characterRecipes)
		{
		}

		public void AddRecipesFromAB(UMATextRecipe[] uparts)
		{
		}

		public void AddRecipe(UMATextRecipe upart)
		{
		}

		public void AddRecipes(UMATextRecipe[] uparts, string filename = "")
		{
		}

		public UMATextRecipe GetRecipe(string filename, bool dynamicallyAdd = true)
		{
			return null;
		}

		public string GetOriginatingAssetBundle(string recipeName)
		{
			return null;
		}

		public override List<string> GetRecipeNamesForRaceSlot(string race, string slot)
		{
			return null;
		}

		public override List<UMARecipeBase> GetRecipesForRaceSlot(string race, string slot)
		{
			return null;
		}

		public override UMARecipeBase GetBaseRecipe(string filename, bool dynamicallyAdd = true)
		{
			return null;
		}
	}
}
