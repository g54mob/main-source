using UnityEngine;

namespace Brewery.Employee
{
	[CreateAssetMenu(fileName = "MasterySettings", menuName = "Brewery/Mastery Settings")]
	public class BreweryMasterySettingsSO : ScriptableObject
	{
		[Header("Mastery Progression")]
		[Tooltip("Maximum mastery level an employee can reach")]
		public int maxMasteryLevel;

		[Tooltip("Maximum number of perks an employee can equip")]
		public int maxPerks;

		[Tooltip("Movement speed bonus per mastery level (0.01 = +1%)")]
		public float masterySpeedBonusPerLevel;

		[Tooltip("Processing time reduction per mastery level (0.005 = -0.5%)")]
		public float masteryEfficiencyBonusPerLevel;

		[Tooltip("XP multiplier when task matches employee specialization")]
		public float specializationXpMultiplier;

		[Tooltip("XP formula multiplier: XP = xpPerLevelMultiplier * level * (level + 1)")]
		public int xpPerLevelMultiplier;

		[Tooltip("Mastery levels at which perk slots unlock (up to 3 entries)")]
		public int[] perkUnlockLevels;

		[Header("XP Awards Per Task")]
		public int xpBottleBarrel;

		public int xpCollectStationOutput;

		public int xpStartStationProcessing;

		public int xpFetchAndLoadStation;

		public int xpCatalyzeFromShelf;

		[Header("Perk: Careful Handler")]
		[Tooltip("Bonus bottles added per barrel")]
		public int carefulHandlerBonusBottles;

		[Header("Perk: Night Owl")]
		[Tooltip("Extra work hours added to shift end")]
		public int nightOwlExtraHours;

		[Header("Perk: Speed Demon")]
		[Tooltip("Flat movement speed bonus added (0.15 = +15%)")]
		public float speedDemonSpeedBonus;

		[Header("Perk: Quality Eye")]
		[Tooltip("Bonus bottles added per barrel")]
		public int qualityEyeBonusBottles;

		[Header("Perk: Eager Worker")]
		[Tooltip("Processing time reduction (0.20 = -20%)")]
		public float eagerWorkerProcessingReduction;

		[Header("Perk: Loyal Worker")]
		[Tooltip("Extra grace days before going on strike")]
		public int loyalWorkerExtraGraceDays;

		[Header("Perk Display Data")]
		[Tooltip("Display names and descriptions for each perk (indexed by bit position 0-7)")]
		public PerkDisplayData[] perkDisplayData;

		[Header("Mastery Titles")]
		[Tooltip("Title displayed for each mastery level (index 0 = level 0, etc.)")]
		public string[] masteryTitles;

		public string GetLocalizedMasteryTitle(int level)
		{
			return null;
		}
	}
}
