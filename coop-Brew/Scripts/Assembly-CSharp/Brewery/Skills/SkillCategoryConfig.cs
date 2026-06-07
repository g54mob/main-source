using System;
using UnityEngine;

namespace Brewery.Skills
{
	[Serializable]
	public class SkillCategoryConfig
	{
		[Header("Category Identity")]
		[Tooltip("Unique identifier for this category (e.g., 'duration_reduction')")]
		public string categoryId;

		[Tooltip("Display name shown in UI (e.g., 'Processing Speed')")]
		public string displayName;

		[Header("Level Configuration")]
		[Tooltip("Maximum level for skills in this category")]
		[Range(1f, 20f)]
		public int maxLevel;

		[Header("Bonus Configuration")]
		[Tooltip("How the bonus is calculated and applied")]
		public BonusType bonusType;

		[Tooltip("Maximum total bonus at max level (e.g., 0.70 for 70% reduction, 5 for +5 bottles)")]
		public float maxBonus;

		[Tooltip("For DurationReduction: minimum multiplier cap (e.g., 0.30 means duration can't go below 30%)")]
		public float minMultiplierCap;

		[Header("Skill Point Costs")]
		[Tooltip("Cost for each level. Array length should match maxLevel. E.g., [1,1,1,2,2,2,3,3,3,3] for 10 levels")]
		public int[] skillPointCosts;

		[Header("UI Display")]
		[Tooltip("Template for benefit text. Use {level}, {bonus}, {bonusPercent}, {total}")]
		public string benefitTextTemplate;

		public float BonusPerLevel => 0f;

		public int GetCostForLevel(int targetLevel)
		{
			return 0;
		}

		public int GetTotalCostForMaxLevel()
		{
			return 0;
		}

		public float GetBonusAtLevel(int level)
		{
			return 0f;
		}

		public float GetDurationMultiplierAtLevel(int level)
		{
			return 0f;
		}

		public string FormatBenefitText(int level, float baseValue = 0f)
		{
			return null;
		}
	}
}
