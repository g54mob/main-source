using NaughtyAttributes;
using Unity.Mathematics;
using UnityEngine;

public class AttackContinuouslyAuthoring : MonoBehaviour
{
	[Header("If a LevelCDAuthoring component exists then damage is calculated from that.")]
	public int damage = 10;

	public DamageEffectType damageEffectType;

	public float damageMultiplier = 1f;

	public bool ignoreDamageReduction;

	public bool canHitLowTriggers;

	public float pushback;

	public float hitRadius = 0.5f;

	public bool hitRadiusGrowOverTime;

	[AllowNesting]
	[ShowIf("hitRadiusGrowOverTime")]
	public float hitRadiusAfterGrowth = 1f;

	[AllowNesting]
	[ShowIf("hitRadiusGrowOverTime")]
	public float hitRadiusGrowthRate = 2f;

	public float attackTime = 1f;

	public float cooldownAfterHit = 1f;

	public string triggerAnimationOnHit = "attack";

	public bool triggerIdleAnimationOnEnteringState;

	public bool requiresElectricity;

	public bool breakAfterSuccessfulHit;

	public float breakDelay;

	public bool cantDamageObjectsHangingOnWalls;

	public bool canDamageOnlyEnemyAndPlayer;

	public bool isStatic;

	public bool canOnlyHitCertainNonEnemyObjects;

	public bool skipLootDropIfDestroyPlants;

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
			if (level != null)
			{
				int num = level.CalculateLevel();
				damage = LevelToDamage(num, damageMultiplier);
			}
		}
	}

	public static int LevelToDamage(int level, float damageMultiplier)
	{
		return (int)math.round((float)(math.max(1, level) * 20) * damageMultiplier);
	}
}
