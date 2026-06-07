using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Brewery.Skills
{
	public class SkillManager : MonoBehaviour
	{
		private Dictionary<ulong, PlayerSkillData> playerSkillRegistry;

		public static SkillManager Instance { get; private set; }

		public bool InfiniteSkillPoints => false;

		public event Action OnPlayerSkillDataRegistered
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<int, string> OnSkillPointsAwarded
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		public void RegisterPlayerSkillData(ulong clientId, PlayerSkillData skillData)
		{
		}

		public void UnregisterPlayerSkillData(ulong clientId)
		{
		}

		public PlayerSkillData GetPlayerSkillData(ulong clientId)
		{
			return null;
		}

		public PlayerSkillData GetLocalPlayerSkillData()
		{
			return null;
		}

		public int GetPlayerSkillLevel(ulong clientId, SkillType skill)
		{
			return 0;
		}

		public float GetPlayerDurationMultiplier(ulong clientId, SkillType skill)
		{
			return 0f;
		}

		public float CalculateEffectiveDuration(float baseDuration, ulong operatorClientId, SkillType skill)
		{
			return 0f;
		}

		public int GetMaxSkillLevel()
		{
			return 0;
		}

		public float GetBonusPerLevel()
		{
			return 0f;
		}

		public float GetBonusPerLevelPercent()
		{
			return 0f;
		}

		public int GetMaxLevelForSkill(SkillType skill)
		{
			return 0;
		}

		public int GetMaxLevelForSkillFallback(SkillType skill)
		{
			return 0;
		}

		public int GetSkillPointCost(SkillType skill, int targetLevel)
		{
			return 0;
		}

		public int GetTotalCostToMax(SkillType skill)
		{
			return 0;
		}

		public bool HasBoosterBonus(ulong clientId, SkillType boosterSkill)
		{
			return false;
		}

		public string GetSkillName(SkillType skill)
		{
			return null;
		}

		public string GetSkillDescription(SkillType skill)
		{
			return null;
		}

		public SkillType[] GetBrewingSkills()
		{
			return null;
		}

		[Obsolete("V1 station skills removed")]
		public SkillType[] GetBoilingStationSkills()
		{
			return null;
		}

		[Obsolete("V1 station skills removed")]
		public SkillType[] GetWinemakingStationSkills()
		{
			return null;
		}

		[Obsolete("V1 station skills removed")]
		public SkillType[] GetSpiritsStationSkills()
		{
			return null;
		}

		public SkillType[] GetPreparationStationSkills()
		{
			return null;
		}

		public SkillType[] GetBarrelOutputSkills()
		{
			return null;
		}

		public SkillType[] GetBeerBoosterSkills()
		{
			return null;
		}

		public SkillType[] GetWineBoosterSkills()
		{
			return null;
		}

		public SkillType[] GetSpiritsBoosterSkills()
		{
			return null;
		}

		public SkillType[] GetBarrelTimerSkills()
		{
			return null;
		}

		public SkillType[] GetTradingDiscountSkills()
		{
			return null;
		}

		public SkillType? GetTradingDiscountSkillForProfile(string profileName)
		{
			return null;
		}

		public float GetTradingDiscountMultiplier(ulong clientId, string profileName)
		{
			return 0f;
		}

		public float GetTradingDiscountPercent(ulong clientId, string profileName)
		{
			return 0f;
		}

		public string GetNpcIdForTradingSkill(SkillType skill)
		{
			return null;
		}

		public List<DiscountedItemInfo> GetDiscountedItemsForSkill(SkillType skill)
		{
			return null;
		}

		public SkillType[] GetFactionSellBonusSkills()
		{
			return null;
		}

		public SkillType? GetFactionSellBonusSkill(string factionName)
		{
			return null;
		}

		public float GetFactionSellBonusMultiplier(ulong clientId, string factionName)
		{
			return 0f;
		}

		public float GetFactionSellBonusPercent(ulong clientId, string factionName)
		{
			return 0f;
		}

		public SkillType[] GetBaseTypeValueSkills()
		{
			return null;
		}

		public int GetOriginalBaseValue(string brewType)
		{
			return 0;
		}

		public SkillType? GetBaseValueSkill(string brewType)
		{
			return null;
		}

		public int GetEffectiveBaseValue(ulong clientId, string brewType)
		{
			return 0;
		}

		public int GetBaseValueBonus(ulong clientId, string brewType)
		{
			return 0;
		}

		public SkillType[] GetCatalystBonusSkills()
		{
			return null;
		}

		public SkillType? GetCatalystBonusSkill(string catalystName)
		{
			return null;
		}

		public float GetCatalystBonusAddition(ulong clientId, string catalystName)
		{
			return 0f;
		}

		public SkillType[] GetBarTabSkills()
		{
			return null;
		}

		public SkillType[] GetHousingSkills()
		{
			return null;
		}

		public int GetConstructionMaterialBonus(ulong clientId)
		{
			return 0;
		}

		public float GetBuildEfficiencyMultiplier(ulong clientId)
		{
			return 0f;
		}

		public float GetBuildEfficiencyPercent(ulong clientId)
		{
			return 0f;
		}

		public void AwardSkillPointsToAllPlayers(int amount, string reason)
		{
		}

		public void AwardSkillPointsToPlayer(ulong clientId, int amount, string reason)
		{
		}

		public void AwardProgressToPlayer(ulong clientId, float amount, string reason)
		{
		}

		public void AwardProgressToAllPlayers(float amount, string reason)
		{
		}
	}
}
