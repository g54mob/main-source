using System;
using System.Collections.Generic;
using Gh.Tk.Story;
using UnityEngine;

namespace Gh.Tk
{
	[RequireComponent(typeof(Prop))]
	[RequireComponent(typeof(Inventory))]
	public abstract class CraftProcess : AttachedBehaviour, IEquatable<CraftProcess>
	{
		public bool autoGenerateRecipes;

		public bool canOrderInLarder;

		public bool isVisibleInLarderOverview;

		public string verb;

		public bool requiresStaff;

		public float hours;

		public CraftSlot[] slots;

		public string outputType;

		public string outputName;

		public int OutputAmount;

		public string OutputVisualKey;

		[Header("attribute modifier is applied to flavor")]
		public FlavorProfilePart primaryAttribute;

		public int attributeEffect;

		[Header("flavor bonus multiplier")]
		public float flavorBonusMultiplier;

		[DropDownChoice(typeof(ItemCategories), "GetAllItemCategories")]
		public string resultCategory;

		[DropDownChoice(typeof(StoryHelper), "GetIngredientTraits")]
		[Header("Traits")]
		public string[] addTraits;

		private static CraftProcess[] _craftProcesses;

		private static readonly Dictionary<string, string[]> _prefabTypeIdentifiersForProcess;

		private static readonly Dictionary<string, string[]> _displayNamesForProcess;

		public string OutputNameKey => null;

		public bool IsUnlocked()
		{
			return false;
		}

		private RecipeInput[] FetchRealIngredients(RecipeInput[] input)
		{
			return null;
		}

		public virtual Ingredient Simulate(RecipeInput[] input)
		{
			return null;
		}

		protected void ExecuteTraits(RecipeInput[] input, Ingredient ingredient)
		{
		}

		protected virtual void CheckInput(RecipeInput[] input)
		{
		}

		protected abstract void SimulateInternal(Ingredient target, RecipeInput[] input);

		private static void SetFlavorProfilePart(Ingredient ingredient, FlavorProfilePart part, int value)
		{
		}

		public override void Start()
		{
		}

		private void OnStockableItemAdded(object sender, EventArgs<string> e)
		{
		}

		private void GenerateRecipes()
		{
		}

		private void OnBuildable_PostBuiltEvent(object sender, EventArgs e)
		{
		}

		private void OnIsBrokenChanged(object sender, EventArgs<bool> e)
		{
		}

		public override void OnDestroy()
		{
		}

		public static IEnumerable<CraftProcess> GetAllCraftProcesses()
		{
			return null;
		}

		public static IEnumerable<string> GetPrefabTypeIdentifiersForProcess(CraftProcess process)
		{
			return null;
		}

		public static IEnumerable<string> GetPrefabTypeIdentifiersForProcess(string verb)
		{
			return null;
		}

		public static IEnumerable<string> GetGoxDisplayNamesForProcess(string verb)
		{
			return null;
		}

		public bool Equals(CraftProcess other)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public static bool operator ==(CraftProcess left, CraftProcess right)
		{
			return false;
		}

		public static bool operator !=(CraftProcess left, CraftProcess right)
		{
			return false;
		}

		public override void Awake()
		{
		}
	}
}
