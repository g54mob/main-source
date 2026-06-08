using System.Collections.Generic;
using UnityEngine;

namespace KitchenData
{
	public class DishTemplate : KitchenObject
	{
		public Unlock.RewardLevel ExpReward = Unlock.RewardLevel.Medium;

		public bool IsUnlockable = true;

		public UnlockGroup UnlockGroup;

		public CardType CardType;

		public int MinimumFranchiseTier;

		public bool IsSpecificFranchiseTier;

		public DishCustomerChange CustomerMultiplier;

		public float SelectionBias;

		public DishType Type;

		public HashSet<Item> MinimumIngredients;

		public HashSet<Process> RequiredProcesses;

		public HashSet<Item> BlockProviders;

		public GameObject IconPrefab;

		public GameObject DisplayPrefab;

		public void Apply(Dish dish)
		{
			dish.ExpReward = ExpReward;
			dish.IsUnlockable = IsUnlockable;
			dish.UnlockGroup = UnlockGroup;
			dish.CardType = CardType;
			dish.MinimumFranchiseTier = MinimumFranchiseTier;
			dish.IsSpecificFranchiseTier = IsSpecificFranchiseTier;
			dish.CustomerMultiplier = CustomerMultiplier;
			dish.SelectionBias = SelectionBias;
			dish.Type = Type;
			dish.MinimumIngredients = MinimumIngredients;
			dish.RequiredProcesses = RequiredProcesses;
			dish.BlockProviders = BlockProviders;
			dish.IconPrefab = IconPrefab;
			dish.DisplayPrefab = DisplayPrefab;
		}

		public void FromDish(Dish dish)
		{
			ExpReward = dish.ExpReward;
			IsUnlockable = dish.IsUnlockable;
			UnlockGroup = dish.UnlockGroup;
			CardType = dish.CardType;
			MinimumFranchiseTier = dish.MinimumFranchiseTier;
			IsSpecificFranchiseTier = dish.IsSpecificFranchiseTier;
			CustomerMultiplier = dish.CustomerMultiplier;
			SelectionBias = dish.SelectionBias;
			Type = dish.Type;
			MinimumIngredients = dish.MinimumIngredients;
			RequiredProcesses = dish.RequiredProcesses;
			BlockProviders = dish.BlockProviders;
			IconPrefab = dish.IconPrefab;
			DisplayPrefab = dish.DisplayPrefab;
		}
	}
}
