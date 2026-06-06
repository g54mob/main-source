using UnityEngine;

namespace Brewery.Stand
{
	[CreateAssetMenu(fileName = "NewStandUpgrade", menuName = "Brewery/Stand/Upgrade Data")]
	public class StandUpgradeData : ScriptableObject
	{
		[Header("Identity")]
		[Tooltip("Display name for the upgrade")]
		public string upgradeName;

		[Tooltip("Description shown in UI")]
		[TextArea(2, 4)]
		public string description;

		[Header("Localization")]
		[SerializeField]
		private string upgradeNameKey;

		[SerializeField]
		private string upgradeDescKey;

		[Tooltip("Cost to purchase")]
		public int cost;

		[Header("Stat Bonuses (cumulative)")]
		[Tooltip("Additional shelf slots (0 if N/A)")]
		public int shelfCapacityBonus;

		[Tooltip("Patience multiplier (1.0 = no change, 1.25 = +25%)")]
		public float patienceMultiplier;

		[Tooltip("Price multiplier (1.0 = no change, 1.2 = +20%)")]
		public float priceMultiplier;

		[Tooltip("Added to NPC detection range (meters)")]
		public float detectionRadiusBonus;

		[Tooltip("Added to max queue length")]
		public int maxQueueLengthBonus;

		[Tooltip("Added to NPC visit probability (0.3 = +30%)")]
		public float visitChanceBonus;

		[Tooltip("Game-hour until which stand attracts NPCs (0 = use default)")]
		public float extendedHoursUntil;

		[Tooltip("Whether this upgrade enables VIP customers")]
		public bool enableVIPCustomers;

		public string GetDisplayName()
		{
			return null;
		}

		public string GetLocalizedDescription()
		{
			return null;
		}
	}
}
