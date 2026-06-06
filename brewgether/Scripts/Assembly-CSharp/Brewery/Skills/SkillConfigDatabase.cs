using System.Collections.Generic;
using UnityEngine;

namespace Brewery.Skills
{
	[CreateAssetMenu(fileName = "SkillConfigDatabase", menuName = "Brewery/Skills/Skill Config Database")]
	public class SkillConfigDatabase : ScriptableObject
	{
		private static SkillConfigDatabase s_Instance;

		[Header("Category Configurations")]
		[SerializeField]
		private List<SkillCategoryConfig> m_Categories;

		[Header("Skill Definitions")]
		[SerializeField]
		private List<SkillDefinition> m_Skills;

		private Dictionary<string, SkillCategoryConfig> m_CategoryLookup;

		private Dictionary<SkillType, SkillDefinition> m_SkillLookup;

		private Dictionary<SkillType, SkillCategoryConfig> m_SkillToCategoryLookup;

		private bool m_CachesBuilt;

		public static SkillConfigDatabase Instance => null;

		private void OnEnable()
		{
		}

		public void BuildCaches()
		{
		}

		public void InvalidateCaches()
		{
		}

		public SkillCategoryConfig GetCategory(string categoryId)
		{
			return null;
		}

		public SkillCategoryConfig GetCategoryForSkill(SkillType skillType)
		{
			return null;
		}

		public string GetCategoryName(SkillType skillType)
		{
			return null;
		}

		public IReadOnlyList<SkillCategoryConfig> GetAllCategories()
		{
			return null;
		}

		public SkillDefinition GetSkillDefinition(SkillType skillType)
		{
			return null;
		}

		public string GetSkillName(SkillType skillType)
		{
			return null;
		}

		public string GetSkillDescription(SkillType skillType)
		{
			return null;
		}

		public IReadOnlyList<SkillDefinition> GetAllSkills()
		{
			return null;
		}

		public int GetMaxLevel(SkillType skillType)
		{
			return 0;
		}

		public int GetSkillPointCost(SkillType skillType, int targetLevel)
		{
			return 0;
		}

		public int GetTotalCostToMax(SkillType skillType)
		{
			return 0;
		}

		public bool CanAffordUpgrade(SkillType skillType, int currentLevel, int availablePoints)
		{
			return false;
		}

		public BonusType GetBonusType(SkillType skillType)
		{
			return default(BonusType);
		}

		public float GetBonusPerLevel(SkillType skillType)
		{
			return 0f;
		}

		public float GetMaxBonus(SkillType skillType)
		{
			return 0f;
		}

		public float GetBonusAtLevel(SkillType skillType, int level)
		{
			return 0f;
		}

		public float CalculateDurationMultiplier(SkillType skillType, int level)
		{
			return 0f;
		}

		public float CalculateDiscountMultiplier(SkillType skillType, int level)
		{
			return 0f;
		}

		public float CalculateSellBonusMultiplier(SkillType skillType, int level)
		{
			return 0f;
		}

		public float CalculateCatalystBonus(SkillType skillType, int level)
		{
			return 0f;
		}

		public int CalculateFlatBonus(SkillType skillType, int level)
		{
			return 0;
		}

		public bool IsBinarySkillUnlocked(SkillType skillType, int level)
		{
			return false;
		}

		public Sprite GetSkillIcon(SkillType skillType)
		{
			return null;
		}

		public string GetBenefitText(SkillType skillType, int level)
		{
			return null;
		}

		public string GetSkillAssociationId(SkillType skillType)
		{
			return null;
		}

		public bool ValidateDatabase()
		{
			return false;
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void Initialize()
		{
		}
	}
}
