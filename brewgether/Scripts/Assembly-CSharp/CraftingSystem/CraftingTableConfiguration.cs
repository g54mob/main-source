using System.Collections.Generic;
using UnityEngine;

namespace CraftingSystem
{
	[CreateAssetMenu(fileName = "NewCraftingTableConfig", menuName = "Crafting/Table Configuration", order = 0)]
	public class CraftingTableConfiguration : ScriptableObject
	{
		[Header("Table Identity")]
		public CraftingTableType tableType;

		public string displayName;

		[TextArea]
		public string description;

		[Header("Localization")]
		[SerializeField]
		private string displayNameKey;

		public Sprite icon;

		[Header("Capacity")]
		[Min(1f)]
		public int inputSlots;

		[Min(1f)]
		public int outputSlots;

		[Header("UI")]
		public Color themeColor;

		public Sprite backgroundSprite;

		[Header("Supported Recipes")]
		public List<CraftingRecipe> supportedRecipes;

		[Header("Special Properties")]
		public bool allowAutoOutput;

		public bool requiresPower;

		[Min(0.0001f)]
		public float baseCraftingSpeedMultiplier;

		public string GetDisplayName()
		{
			return null;
		}
	}
}
