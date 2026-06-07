using System.Collections.Generic;
using Brewery.Core;
using UnityEngine;

namespace Brewery.NPC.TradingSystem
{
	[CreateAssetMenu(fileName = "TradeOffer", menuName = "Brewery/Trading/Trade Offer", order = 0)]
	public class TradeOffer : ScriptableObject
	{
		[Header("Identity")]
		[Tooltip("Unique identifier for this trade (e.g., 'bobby_hops_trade')")]
		public string tradeId;

		[Tooltip("Display name shown in UI (e.g., 'Cascade Hops Trade')")]
		public string displayName;

		[Tooltip("Description shown in UI")]
		[TextArea(2, 4)]
		public string description;

		[Header("Cost - What Player Gives")]
		[Tooltip("Base money required (0 = no money needed)")]
		[Min(0f)]
		public int baseMoneyRequired;

		[Tooltip("Items required from player (drinks/other items)")]
		public List<ItemRequirement> itemsRequired;

		[Header("Reward - What Player Gets")]
		[Tooltip("Base money reward (0 = no money given)")]
		[Min(0f)]
		public int baseMoneyReward;

		[Tooltip("Items given to player (catalysts, ingredients, etc.)")]
		public List<ItemReward> itemRewards;

		[Header("Daily Settings")]
		[Tooltip("Maximum number of times this trade can be completed per day")]
		[Min(0f)]
		public int maxCompletionsPerDay;

		[HideInInspector]
		public float dailyVariationRange;

		[Header("Quest Requirements")]
		[Tooltip("Quest chain IDs that must be completed to access this trade (empty = always available)")]
		public string[] requiredQuestChainIds;

		[Header("Catalyzed Drink Requirements")]
		[Tooltip("If true, this trade requires catalyzed drinks (catalysts selected daily from NPC preferences)")]
		public bool requiresCatalyzedDrinks;

		[Tooltip("Base type of drink required when requiresCatalyzedDrinks is true")]
		public BaseType requiredDrinkType;

		[Tooltip("Quantity of catalyzed drinks required")]
		[Min(1f)]
		public int catalyzedDrinkQuantity;

		[HideInInspector]
		public int requiredReputationLevel;

		[HideInInspector]
		public bool ignoreReputationBonus;

		public bool HasQuestRequirement => false;

		public bool IsValid(out string error)
		{
			error = null;
			return false;
		}

		public string GetSummary()
		{
			return null;
		}

		public bool MeetsQuestRequirement()
		{
			return false;
		}

		public string GetQuestRequirementText()
		{
			return null;
		}
	}
}
