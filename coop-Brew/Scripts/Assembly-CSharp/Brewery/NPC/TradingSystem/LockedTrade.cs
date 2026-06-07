using Brewery.Quest;
using InventorySystem;
using UnityEngine;

namespace Brewery.NPC.TradingSystem
{
	[CreateAssetMenu(fileName = "LockedTrade", menuName = "Brewery/Trading/Locked Trade", order = 2)]
	public class LockedTrade : ScriptableObject
	{
		[Header("Identity")]
		[Tooltip("Unique identifier for this locked trade")]
		public string tradeId;

		[Tooltip("Display name shown in UI")]
		public string displayName;

		[SerializeField]
		private string displayNameKey;

		[Tooltip("Description shown in UI")]
		[TextArea(2, 4)]
		public string description;

		[SerializeField]
		private string descriptionKey;

		[Header("Cost")]
		[Tooltip("Money required to purchase (0 = free)")]
		[Min(0f)]
		public int moneyCost;

		[Header("Expansion Trade")]
		[Tooltip("If true, this trade can be purchased multiple times. Price doubles per NPC after each purchase. Used for stations, storage, etc.")]
		public bool isExpansionTrade;

		[Header("Reward")]
		[Tooltip("If true, this trade only unlocks access (e.g., doors/gates) and doesn't spawn a prefab")]
		public bool isUnlockOnly;

		[Tooltip("Prefab to spawn when purchased (e.g., vehicle). Not required if isUnlockOnly is true.")]
		public GameObject rewardPrefab;

		[Tooltip("Item ScriptableObject for inventory-based rewards. If set and the item has a boxPrefab, the reward goes directly to the player's inventory instead of spawning in the world.")]
		public Item rewardItem;

		[Tooltip("Icon to display in UI")]
		public Sprite rewardIcon;

		[Tooltip("Display name for the reward (if different from displayName)")]
		public string rewardDisplayName;

		[Header("Spawn Settings")]
		[Tooltip("Name of a spawn point in the scene. Takes priority over NPC spawning.")]
		public string spawnPointName;

		[Tooltip("NPC ID to spawn near. Used if spawnPointName is empty.")]
		public string spawnNearNpcId;

		[Tooltip("Offset from spawn location")]
		public Vector3 spawnOffset;

		[Header("Unlock Requirements")]
		[Tooltip("Type of requirement to unlock this trade")]
		public LockedTradeUnlockType unlockType;

		[Tooltip("Quest chain IDs that must be completed to unlock this trade")]
		public string[] requiredQuestChainIds;

		[Header("Post-Purchase Quest")]
		[Tooltip("Quest chain to automatically start when this locked trade is purchased. Used for exploration quests (e.g., 'Go find the barn').")]
		public QuestChain questChainToStart;

		[HideInInspector]
		public int requiredReputationLevel;

		public string GetLocalizedDisplayName()
		{
			return null;
		}

		public string GetLocalizedDescription()
		{
			return null;
		}

		public Sprite GetRewardIcon()
		{
			return null;
		}

		public string GetDisplayName()
		{
			return null;
		}

		public string GetUnlockRequirementText()
		{
			return null;
		}

		private string GetQuestChainRequirementText()
		{
			return null;
		}

		public bool IsValid(out string error)
		{
			error = null;
			return false;
		}
	}
}
