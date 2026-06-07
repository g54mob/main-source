using System;
using System.Collections.Generic;
using UMA.CharacterSystem;
using UnityEngine;

namespace UMA
{
	public class UMATextRecipe : UMAPackedRecipeBase, IUMAIndexOptions
	{
		private class DCSRecipeChecker
		{
			public string packedRecipeType;

			public List<WardrobeSettings> wardrobeRecipesJson;

			public List<WardrobeSettings> wardrobeSet;

			public List<WardrobeSettings> checkedWardrobeSet => null;
		}

		[Serializable]
		public class DCSPackRecipe
		{
			public string packedRecipeType;

			public string name;

			public string race;

			public List<UMAPackedDna> dna;

			public List<PackedOverlayColorDataV3> characterColors;

			public List<WardrobeSettings> wardrobeSet;

			public string raceAnimatorController;

			private OverlayColorData[] _sharedColors;

			public OverlayColorData[] sharedColors => null;

			public DCSPackRecipe()
			{
			}

			public DCSPackRecipe(DynamicCharacterAvatar dcaToSave, string recipeName, string pRecipeType, DynamicCharacterAvatar.SaveOptions saveOptions, params string[] slotsToSave)
			{
			}

			public DCSPackRecipe(UMAPackRecipe umaPackRecipe, string recipeName = "", string pRecipeType = "Standard", List<WardrobeSettings> wardrobeSetToSave = null)
			{
			}
		}

		[Serializable]
		public class DCSUniversalPackRecipe : UMAPackRecipe
		{
			[SerializeField]
			public List<WardrobeSettings> wardrobeSet;

			public string packedRecipeType;

			private OverlayColorData[] _sharedColors;

			public OverlayColorData[] sharedColors => null;

			public DCSUniversalPackRecipe()
			{
			}

			public DCSUniversalPackRecipe(UMAPackRecipe umaPackRecipe, string pRecipeType = "Standard")
			{
			}

			public DCSUniversalPackRecipe(DCSPackRecipe dcsPackRecipe)
			{
			}

			public DCSUniversalPackRecipe(UMAData.UMARecipe recipeToSave, Dictionary<string, UMATextRecipe> wardrobeRecipes = null, string pRecipeType = "DynamicCharacterAvatar")
			{
			}

			public UMADnaBase[] GetAllDna()
			{
				return null;
			}
		}

		public string recipeType;

		[SerializeField]
		public string DisplayValue;

		[SerializeField]
		public List<string> compatibleRaces;

		[SerializeField]
		public List<WardrobeRecipeThumb> wardrobeRecipeThumbs;

		public string wardrobeSlot;

		[SerializeField]
		public bool Appended;

		[SerializeField]
		public List<string> Hides;

		[SerializeField]
		public List<string> HideTags;

		[SerializeField]
		public List<string> suppressWardrobeSlots;

		[SerializeField]
		public List<WardrobeSettings> activeWardrobeSet;

		[SerializeField]
		public List<MeshHideAsset> MeshHideAssets;

		[SerializeField]
		public List<MeshModifier> MeshModifiers;

		[SerializeField]
		public UMAPredefinedDNA OverrideDNA;

		[SerializeField]
		public bool disabled;

		public string recipeString;

		public bool forceKeep;

		public bool labelLocalFiles;

		[Tooltip("When true, this will not be automatically added to the index when all items are scanned.")]
		public bool noAutoAdd;

		public bool LabelLocalFiles
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool ForceKeep
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool NoAutoAdd
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public OverlayColorData[] SharedColors => null;

		public Sprite GetWardrobeRecipeThumbFor(string racename)
		{
			return null;
		}

		public static List<WardrobeSettings> GenerateWardrobeSet(Dictionary<string, UMATextRecipe> wardrobeRecipes, Dictionary<string, UMAWardrobeCollection> wardrobeCollections, Dictionary<string, List<UMATextRecipe>> addlrecipes, params string[] slotsToSave)
		{
			return null;
		}

		public static List<WardrobeSettings> GenerateWardrobeSet(Dictionary<string, List<UMATextRecipe>> addlRecipes, params string[] slotsToSave)
		{
			return null;
		}

		public static List<WardrobeSettings> GenerateWardrobeSet(Dictionary<string, UMATextRecipe> wardrobeRecipes, params string[] slotsToSave)
		{
			return null;
		}

		public override void Load(UMAData.UMARecipe umaRecipe, UMAContextBase context = null, bool loadSlots = true)
		{
		}

		protected DCSUniversalPackRecipe PackedLoadDCSInternal(UMAContextBase context)
		{
			return null;
		}

		public static DCSUniversalPackRecipe PackedLoadDCS(UMAContextBase context, string recipeToUnpack, UMATextRecipe targetUTR = null)
		{
			return null;
		}

		public void Save(UMAData.UMARecipe umaRecipe, UMAContextBase context, Dictionary<string, UMATextRecipe> wardrobeRecipes, bool backwardsCompatible = true)
		{
		}

		public override void Save(UMAData.UMARecipe umaRecipe, UMAContextBase context)
		{
		}

		public void SaveDCS(DynamicCharacterAvatar dcaToSave, string recipeName, DynamicCharacterAvatar.SaveOptions saveOptions)
		{
		}

		public static string GetRecipesType(string recipeString)
		{
			return null;
		}

		public static bool RecipeHasWardrobeSet(string recipeString)
		{
			return false;
		}

		public static List<WardrobeSettings> GetRecipesWardrobeSet(string recipeString)
		{
			return null;
		}

		public override UMAPackRecipe PackedLoad(UMAContextBase context = null)
		{
			return null;
		}

		public override void PackedSave(UMAPackRecipe packedRecipe, UMAContextBase context)
		{
		}

		public override string GetInfo()
		{
			return null;
		}

		public override byte[] GetBytes()
		{
			return null;
		}

		public override void SetBytes(byte[] data)
		{
		}

		public UMAData.UMARecipe GetUMARecipe()
		{
			return null;
		}
	}
}
