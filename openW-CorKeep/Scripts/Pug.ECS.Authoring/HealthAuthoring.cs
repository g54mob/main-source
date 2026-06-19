using NaughtyAttributes;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class HealthAuthoring : MonoBehaviour
{
	[Header("If an AreaLevelAuthoring component exists then stats are calculated from that")]
	public bool dontCalculateHealthFromLevel;

	public bool overrideStartHealth;

	[ShowIf("overrideStartHealth")]
	[AllowNesting]
	public float normalizedOverrideStartHealth = 1f;

	public int startHealth;

	public int maxHealth;

	public float maxHealthMultiplier = 1f;

	[Header("Health regeneration")]
	public bool hasHealthRegeneration;

	[ShowIf("hasHealthRegeneration")]
	[AllowNesting]
	public bool healInCombatAsWell;

	[FormerlySerializedAs("healthPercentagePerFifthSecond")]
	[ShowIf("hasHealthRegeneration")]
	[AllowNesting]
	public int healthIncreasePercentPerFiveSeconds = 100;

	[FormerlySerializedAs("startHealDelay")]
	[ShowIf("hasHealthRegeneration")]
	[AllowNesting]
	[InfoBox("If healInCombatAsWell is set to true, this delay will still be applied when first getting damaged", EInfoBoxType.Normal)]
	public float healDelayAfterLeavingCombat = 5f;

	[HideInInspector]
	public AreaLevelAuthoring level;

	private void OnValidate()
	{
		if (!Application.isPlaying)
		{
			if (level == null || level.gameObject != base.gameObject)
			{
				level = GetComponent<AreaLevelAuthoring>();
			}
			if (level != null && !dontCalculateHealthFromLevel)
			{
				int num = level.CalculateLevel();
				maxHealth = LevelToMaxHealth(num, GetComponent<EnemyAuthoring>() != null, GetComponent<BossAuthoring>() != null);
			}
			if (overrideStartHealth)
			{
				startHealth = (int)(normalizedOverrideStartHealth * (float)maxHealth);
			}
			else
			{
				startHealth = maxHealth;
			}
		}
	}

	private int LevelToMaxHealth(int level, bool isEnemy, bool isBoss)
	{
		if (isBoss)
		{
			return math.max(1, (int)math.round(300f * math.pow(level, 2.45f) * maxHealthMultiplier));
		}
		if (isEnemy)
		{
			return math.max(1, (int)math.round((135f + 15f * math.pow(level - 1, 2f)) * maxHealthMultiplier));
		}
		return math.max(1, (int)math.round((100f + 50f * math.pow(level - 1, 1.2f)) * maxHealthMultiplier));
	}

	public int ComputeMaxHealth(bool useHardModeSettings, bool useCasualModeSettings)
	{
		int result = maxHealth;
		EnemyAuthoring component;
		bool flag = TryGetComponent<EnemyAuthoring>(out component) && component.enabled;
		BossAuthoring component2;
		bool isBoss = TryGetComponent<BossAuthoring>(out component2) && component2.enabled;
		AreaLevelAuthoring component3;
		bool flag2 = TryGetComponent<AreaLevelAuthoring>(out component3) && component3.enabled;
		if (!dontCalculateHealthFromLevel && flag2)
		{
			result = LevelToMaxHealth(component3.level, flag, isBoss);
			if (flag)
			{
				if (useHardModeSettings)
				{
					result = (int)math.round((float)maxHealth * 1.5f);
				}
				else if (useCasualModeSettings)
				{
					result = (int)math.round((float)maxHealth * 0.5f);
				}
			}
		}
		return result;
	}
}
