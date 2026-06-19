using Unity.Mathematics;
using UnityEngine;

public class MeleeAttackStateAuthoring : MonoBehaviour
{
	public float anticipationDuration;

	public float hitDuration;

	public float durationBeforeDamageDeal;

	public float minCooldown;

	public float maxCooldown;

	public float minDistanceToAttemptHit;

	public float hitDistanceInfront;

	public float3 hitOffset;

	public bool hitInDiscreteDirections;

	public bool skipVisibilityCheck;

	public int amountOfHits = 1;

	public float attackPlayerTimeout;

	public bool canOnlyAttackEnemiesAndPlayer;

	[Header("If hitBoxWidth and hitBoxLength > 0 then a box cast will be done instead of sphere cast.")]
	public float hitRadius;

	public float hitBoxHalfWidth;

	public float hitBoxHalfLength;

	[Header("If an AreaLevelAuthoring component exists then stats are calculated from that")]
	public int meleeDamage;

	public float meleeDamageMultiplier = 1f;

	public bool hitTiles;

	public int tileDamage;

	public float tileDamageMultiplier = 1f;

	public float pushForce;

	public float moveForceForward;

	public bool alwaysMoveAtFullForceForward;

	public bool lockOrientationDuringAnticipation;

	public bool lockOrientationDuringHit;

	public ObjectID objectToSpawnOnHitTiles;

	public bool canHitLowTriggers;

	public bool bypassMaxDamagePerHit;

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
				meleeDamage = LevelToDamage(num, meleeDamageMultiplier);
				bool isEnemy = GetComponent<EnemyAuthoring>() != null;
				tileDamage = LevelToTileDamage(num, tileDamageMultiplier, isEnemy);
			}
		}
	}

	public static int LevelToDamage(int level, float multiplier, int additionalBaseDamage = 0)
	{
		return (int)math.round(((float)additionalBaseDamage + math.max(1f, math.pow(level, 1.15f)) * 13f) * multiplier);
	}

	public static int LevelToTileDamage(int level, float multiplier, bool isEnemy)
	{
		return ConditionExtensions.GetConditionValueFromLevel(ConditionEffect.Mining, isNegative: false, level, multiplier, 1f, 1f, isTemporary: false, isHeldInHand: true, isArmor: false, isEnemy);
	}
}
