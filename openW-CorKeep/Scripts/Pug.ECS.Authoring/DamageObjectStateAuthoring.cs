using Unity.Mathematics;
using UnityEngine;

public class DamageObjectStateAuthoring : MonoBehaviour
{
	public int maxAllowedDamagesWithoutGoal;

	public float hitDuration;

	public float anticipationTime;

	public float hitDistanceInfront;

	public float hitRadius;

	public bool bypassCantAttackBehaviourWhileChasing;

	[Header("If an AreaLevelAuthoring component exists then stats are calculated from that")]
	public int damage;

	public float damageMultiplier = 1f;

	public int meleeDamage;

	public float meleeDamageMultiplier = 1f;

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
				bool isEnemy = GetComponent<EnemyAuthoring>() != null;
				damage = LevelToTileDamage(num, damageMultiplier, isEnemy);
				meleeDamage = MeleeAttackStateAuthoring.LevelToDamage(num, meleeDamageMultiplier);
			}
		}
	}

	public static int LevelToTileDamage(int level, float multiplier, bool isEnemy)
	{
		return (int)math.round((float)ConditionExtensions.GetConditionValueFromLevel(ConditionEffect.Mining, isNegative: false, level, multiplier, 1f, 1f, isTemporary: false, isHeldInHand: true, isArmor: false, isEnemy) * 1.2f);
	}
}
