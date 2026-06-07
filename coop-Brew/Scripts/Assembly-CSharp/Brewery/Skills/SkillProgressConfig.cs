using UnityEngine;

namespace Brewery.Skills
{
	[CreateAssetMenu(fileName = "SkillProgressConfig", menuName = "Brewery/Skills/Skill Progress Config")]
	public class SkillProgressConfig : ScriptableObject
	{
		[Header("Progress Settings")]
		[Tooltip("Total progress needed to earn 1 skill point")]
		[Min(1f)]
		public int progressPerLevel;

		[Header("Brewery Stations (on collect)")]
		[Tooltip("Progress for collecting from Boiling Station")]
		[Min(0f)]
		public float boilingStationCollect;

		[Tooltip("Progress for collecting from Corn Grinding Station")]
		[Min(0f)]
		public float cornGrindingCollect;

		[Tooltip("Progress for collecting from Winemaking Station")]
		[Min(0f)]
		public float winemakingCollect;

		[Tooltip("Progress for collecting from Stomping Station")]
		[Min(0f)]
		public float stompingCollect;

		[Header("Catalyst")]
		[Tooltip("Progress for discovering a new recipe at the Catalyst Station")]
		[Min(0f)]
		public float catalystDiscovery;

		[Header("Sales")]
		[Tooltip("Progress for making a sale at the Stand")]
		[Min(0f)]
		public float standSale;

		[Tooltip("Progress for making a sale at the Bar")]
		[Min(0f)]
		public float barSale;

		[Header("Combat")]
		[Tooltip("Progress for killing a thief")]
		[Min(0f)]
		public float thiefKill;

		[Tooltip("Progress for killing a scarecrow/sentinel")]
		[Min(0f)]
		public float scarecrowKill;

		[Header("Property")]
		[Tooltip("Progress for collecting rent from a house")]
		[Min(0f)]
		public float rentCollect;

		[Header("Quests & Favors")]
		[Tooltip("Progress for completing a quest (awarded to ALL players)")]
		[Min(0f)]
		public float questComplete;

		[Tooltip("Progress for completing a favor (per player)")]
		[Min(0f)]
		public float favorComplete;

		[Header("Resurrection")]
		[Tooltip("Progress for successfully reviving an NPC")]
		[Min(0f)]
		public float resurrection;

		[Header("Farming")]
		[Tooltip("Progress for harvesting corn (can be spammed, consider 0.5)")]
		[Min(0f)]
		public float cornHarvest;

		[Header("Employees")]
		[Tooltip("Progress for hiring an employee")]
		[Min(0f)]
		public float employeeHire;

		[Tooltip("Progress for paying an employee salary")]
		[Min(0f)]
		public float employeePay;

		[Tooltip("Progress for upgrading an employee")]
		[Min(0f)]
		public float employeeUpgrade;

		[Header("Trading")]
		[Tooltip("Progress for purchasing a locked trade reward (quest-unlocked items from NPCs)")]
		[Min(0f)]
		public float lockedTradePurchase;

		[Header("Collectables")]
		[Tooltip("Progress for collecting a hidden skill star in the world")]
		[Min(0f)]
		public float starCollect;

		private static SkillProgressConfig _instance;

		public static SkillProgressConfig Instance => null;
	}
}
