using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenData
{
	public abstract class Unlock : LocalisedGameDataObject<UnlockInfo>, ICard
	{
		public enum RewardLevel
		{
			None = 0,
			Small = 50,
			Medium = 100,
			Large = 200
		}

		[Serializable]
		public struct ItemReward
		{
			public Item Item;

			public int RewardAmount;
		}

		public RewardLevel ExpReward = RewardLevel.Medium;

		public DishCustomerChange CustomerMultiplier;

		public bool IsUnlockable = true;

		public bool HasSubOptions;

		public Unlock OptionCard1;

		public Unlock OptionCard2;

		public Unlock ParentOption;

		public UnlockGroup UnlockGroup;

		public CardType CardType;

		public int MinimumFranchiseTier;

		public bool IsSpecificFranchiseTier;

		public float SelectionBias;

		[SerializeField]
		private List<Unlock> HardcodedRequirements;

		[SerializeField]
		private List<Unlock> HardcodedBlockers;

		[NonSerialized]
		public List<Unlock> Requires;

		[NonSerialized]
		public List<Unlock> BlockedBy;

		public bool BlocksAllOtherFood;

		public List<Unlock> AllowedFoods = new List<Unlock>();

		public RestaurantSetting ForceFranchiseSetting;

		public List<ItemReward> ItemRewards = new List<ItemReward>();

		public string Name
		{
			get
			{
				if (!(Localisation != null))
				{
					return "?";
				}
				return Localisation.Name;
			}
		}

		public string Description
		{
			get
			{
				if (!(Localisation != null))
				{
					return "";
				}
				return Localisation.Description;
			}
		}

		RewardLevel ICard.ExpReward => ExpReward;

		int ICard.CardID => ID;

		CardType ICard.CardType => CardType;

		public string FlavourText
		{
			get
			{
				if (!(Localisation != null))
				{
					return "";
				}
				return Localisation.FlavourText;
			}
		}

		public virtual string Icon
		{
			get
			{
				switch (CardType)
				{
				case CardType.Default:
					return "<sprite name=\"star_small\">";
				case CardType.FranchiseTier:
					return "<sprite name=\"franchise_tier\">";
				case CardType.Contract:
					return "<sprite name=\"star_small\">";
				case CardType.ThemeUnlock:
					return "<sprite name=\"franchise\">";
				case CardType.HalloweenTreat:
				case CardType.HalloweenTrick:
					return "<sprite name=\"halloween\">";
				case CardType.Setting:
					return "<sprite name=\"map\">";
				default:
					return "";
				}
			}
		}

		public virtual Color Colour
		{
			get
			{
				switch (CardType)
				{
				case CardType.HalloweenTreat:
				case CardType.HalloweenTrick:
					return new Color(1f, 0.62f, 0.09f);
				case CardType.Setting:
					return new Color(0.18f, 0.74f, 0.35f);
				case CardType.FranchiseTier:
					return new Color(1f, 0.84f, 0.38f);
				case CardType.ThemeUnlock:
					return new Color(1f, 0.57f, 0.58f);
				default:
					if (!(this is CustomerGroup))
					{
						if (!(this is Dish dish))
						{
							if (this is UnlockCard)
							{
								return new Color(0.62f, 0.34f, 0.71f);
							}
							return new Color(0.72f, 0.4f, 0.46f);
						}
						return dish.Type switch
						{
							DishType.Starter => new Color(0.42f, 0.69f, 0.62f), 
							DishType.Dessert => new Color(0.42f, 0.69f, 0.62f), 
							DishType.Side => new Color(0.42f, 0.69f, 0.62f), 
							DishType.Extra => new Color(0.55f, 0.47f, 0.83f), 
							_ => new Color(0.41f, 0.63f, 0.7f), 
						};
					}
					return new Color(1f, 0.51f, 0.08f);
				}
			}
		}

		private IEnumerable EditorGUIRewards()
		{
			return EnumHelpers.ListFromEnum<RewardLevel>();
		}

		private IEnumerable EditorCustomerMultiplier()
		{
			return EnumHelpers.ListFromEnum((DishCustomerChange d) => $"{d.Value()}");
		}

		private void FixChildren()
		{
			OptionCard1.ParentOption = this;
			OptionCard2.ParentOption = this;
		}

		protected override void InitialiseDefaults()
		{
			HardcodedRequirements = new List<Unlock>();
			HardcodedBlockers = new List<Unlock>();
		}

		public override void SetupForGame()
		{
			if (HardcodedRequirements == null)
			{
				HardcodedRequirements = new List<Unlock>();
			}
			Requires = new List<Unlock>(HardcodedRequirements);
			if (HardcodedBlockers == null)
			{
				HardcodedBlockers = new List<Unlock>();
			}
			BlockedBy = new List<Unlock>(HardcodedBlockers);
			if (AllowedFoods == null)
			{
				AllowedFoods = new List<Unlock>();
			}
		}

		protected override void ProcessLocalisation(StringSubstitutor subs)
		{
			Localisation.Name = subs.Parse(Localisation.Name);
			Localisation.Description = subs.Parse(Localisation.Description);
			Localisation.FlavourText = subs.Parse(Localisation.FlavourText);
		}
	}
}
