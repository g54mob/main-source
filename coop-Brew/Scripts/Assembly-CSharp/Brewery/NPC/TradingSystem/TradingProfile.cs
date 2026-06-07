using System.Collections.Generic;
using UnityEngine;

namespace Brewery.NPC.TradingSystem
{
	[CreateAssetMenu(fileName = "TradingProfile", menuName = "Brewery/Trading/Trading Profile", order = 1)]
	public class TradingProfile : ScriptableObject
	{
		[Header("NPC Identity")]
		[Tooltip("Unique identifier for this NPC (e.g., 'bobby')")]
		public string npcId;

		[Tooltip("Display name shown in UI (e.g., 'Bobby')")]
		public string displayName;

		[Tooltip("Portrait image shown in UI")]
		public Sprite portrait;

		[Tooltip("Description of this NPC's trading specialty")]
		[TextArea(3, 5)]
		public string description;

		[Header("Localization")]
		[SerializeField]
		private string displayNameKey;

		[SerializeField]
		private string descriptionKey;

		[Header("Available Trades")]
		[Tooltip("List of trades this NPC offers (references to TradeOffer ScriptableObjects)")]
		public List<TradeOffer> availableTrades;

		[Header("Locked Trades (Special Rewards)")]
		[Tooltip("Special one-time trades that unlock after meeting requirements (e.g., quest completion, reputation)")]
		public List<LockedTrade> lockedTrades;

		[Header("Spawn Configuration")]
		[Tooltip("Home location ID for spawning (e.g., 'RequestNPC_House_1')")]
		public string homeLocationId;

		[Tooltip("Prefab to spawn for this NPC")]
		public GameObject npcPrefab;

		[Tooltip("Name of the QuestSpawnPoint to use for spawning overflow trade rewards (when inventory is full)")]
		public string rewardSpawnPointName;

		[Header("Grid Spawning Settings")]
		[Tooltip("Spacing between items when spawning in a grid (meters)")]
		[Min(0.5f)]
		public float gridSpacing;

		[Tooltip("Maximum items per row in the grid")]
		[Range(1f, 10f)]
		public int gridRowSize;

		[Header("Catalyst Preferences")]
		[Tooltip("Catalyst IDs this NPC prefers for catalyzed drink trades (e.g., 'cocaine_powder', 'snake_venom')")]
		public List<string> preferredCatalystIds;

		[Tooltip("Global tier (1-4) determines catalyst complexity: Tier 3 = 1-2 catalysts, Tier 4 = 2-3 catalysts")]
		[Range(1f, 4f)]
		public int globalTier;

		public string GetDisplayName()
		{
			return null;
		}

		public string GetLocalizedDescription()
		{
			return null;
		}

		public bool IsValid(out string error)
		{
			error = null;
			return false;
		}

		public string GetSummary()
		{
			return null;
		}

		public TradeOffer GetTradeById(string tradeId)
		{
			return null;
		}
	}
}
