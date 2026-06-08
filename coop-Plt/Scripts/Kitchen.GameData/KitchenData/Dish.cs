using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace KitchenData
{
	[CreateAssetMenu(fileName = "Dish", menuName = "Kitchen/Unlock/Dish", order = 3)]
	public class Dish : Unlock, IUpgrade
	{
		[Serializable]
		public struct MenuItem
		{
			public Item Item;

			public MenuPhase Phase;

			public float Weight;

			public DynamicMenuType DynamicMenuType;

			public Item DynamicMenuIngredient;
		}

		[Serializable]
		public struct IngredientUnlock
		{
			public ItemGroup MenuItem;

			public Item Ingredient;
		}

		public DishType Type;

		[Range(0f, 5f)]
		public int Difficulty;

		[Range(0f, 5f)]
		public int RewardOverride;

		public Item UnlockItemOverride;

		public bool HideInfoPanel;

		public bool SkipOwnRecipe;

		public List<Dish> AlsoAddRecipes = new List<Dish>();

		public GameObject IconPrefab;

		public GameObject DisplayPrefab;

		public string ImageKey;

		[SerializeField]
		private List<MenuItem> ResultingMenuItems;

		[NonSerialized]
		public List<MenuItem> UnlocksMenuItems;

		[SerializeField]
		private HashSet<IngredientUnlock> IngredientsUnlocks;

		[NonSerialized]
		public HashSet<IngredientUnlock> UnlocksIngredients;

		public HashSet<IngredientUnlock> ExtraOrderUnlocks;

		public bool IsMainThatDoesNotNeedPlates;

		public List<RestaurantStatus> AddsStatuses;

		public string AchievementName;

		public List<string> StartingNameSet = new List<string>();

		public bool IsSpeedrunDish;

		public HashSet<Item> MinimumIngredients;

		public HashSet<Process> RequiredProcesses;

		public HashSet<Item> BlockProviders;

		public HashSet<Item> BeneficialIngredients = new HashSet<Item>();

		public static readonly float[] EatingTimeBands = new float[5] { -0.5f, 0f, 0.5f, 1f, 1.5f };

		public static readonly float[] DishValueBands = new float[5] { 0f, 3f, 4f, 5f, 6f };

		int IUpgrade.MaximumUpgradeCount => 1;

		string IUpgrade.UpgradeName => base.Name;

		string IUpgrade.UpgradeDescription => base.Description;

		int IUpgrade.ID => ID;

		public bool RequiresCleaning
		{
			get
			{
				foreach (Item minimumIngredient in MinimumIngredients)
				{
					if (minimumIngredient.RequiresCleaning)
					{
						return true;
					}
				}
				return false;
			}
		}

		public override string Icon => "<sprite name=\"food_card\">";

		public bool HasExtendedInfoPanel
		{
			get
			{
				if (UnlocksMenuItems.Count > 0 || UnlockItemOverride != null)
				{
					return !HideInfoPanel;
				}
				return false;
			}
		}

		protected override void InitialiseDefaults()
		{
			base.InitialiseDefaults();
			MinimumIngredients = new HashSet<Item>();
			BeneficialIngredients = new HashSet<Item>();
			UnlocksIngredients = new HashSet<IngredientUnlock>();
			ExtraOrderUnlocks = new HashSet<IngredientUnlock>();
			RequiredProcesses = new HashSet<Process>();
			UnlocksMenuItems = new List<MenuItem>();
			BlockProviders = new HashSet<Item>();
			AlsoAddRecipes = new List<Dish>();
		}

		public override void SetupForGame()
		{
			base.SetupForGame();
			if (ResultingMenuItems == null)
			{
				ResultingMenuItems = new List<MenuItem>();
			}
			if (BlockProviders == null)
			{
				BlockProviders = new HashSet<Item>();
			}
			if (BeneficialIngredients == null)
			{
				BeneficialIngredients = new HashSet<Item>();
			}
			if (IngredientsUnlocks == null)
			{
				IngredientsUnlocks = new HashSet<IngredientUnlock>();
			}
			if (ExtraOrderUnlocks == null)
			{
				ExtraOrderUnlocks = new HashSet<IngredientUnlock>();
			}
			if (AlsoAddRecipes == null)
			{
				AlsoAddRecipes = new List<Dish>();
			}
			UnlocksMenuItems = new List<MenuItem>(ResultingMenuItems);
			UnlocksIngredients = new HashSet<IngredientUnlock>(IngredientsUnlocks);
		}

		private void StartingNamesFromString(string input)
		{
			StartingNameSet = input.Split('/').ToList();
		}

		public bool ProvidesPhase(MenuPhase phase)
		{
			foreach (MenuItem unlocksMenuItem in UnlocksMenuItems)
			{
				if (unlocksMenuItem.Phase == phase)
				{
					return true;
				}
			}
			return false;
		}

		public int EatingTime()
		{
			float num = 0f;
			if (UnlockItemOverride != null)
			{
				num = UnlockItemOverride.EatingTime.Value;
			}
			else
			{
				foreach (MenuItem unlocksMenuItem in UnlocksMenuItems)
				{
					num = Mathf.Max(unlocksMenuItem.Item.EatingTime.Value, num);
				}
			}
			return IntHelpers.Band(num, EatingTimeBands);
		}

		public int RecipeDifficulty()
		{
			return Difficulty;
		}

		public int DishValue()
		{
			float num = 0f;
			if (UnlockItemOverride != null)
			{
				num = UnlockItemOverride.Reward;
			}
			else
			{
				if (RewardOverride > 0)
				{
					return RewardOverride;
				}
				foreach (MenuItem unlocksMenuItem in UnlocksMenuItems)
				{
					num = Mathf.Max(unlocksMenuItem.Item.Reward, num);
				}
			}
			return IntHelpers.Band(num, DishValueBands);
		}
	}
}
