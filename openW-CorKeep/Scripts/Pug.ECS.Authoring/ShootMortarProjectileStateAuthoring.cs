using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(BehaviourTagsAuthoring))]
public class ShootMortarProjectileStateAuthoring : MonoBehaviour
{
	public ObjectID mortarProjectileID;

	public string overrideAnimID;

	public bool playAttackFireAnimation;

	[Header("State Timings")]
	public float anticipationDuration;

	public float attackDuration;

	[Header("Fire Conditions")]
	public bool dontInterruptOtherAttackStates;

	public bool onlyShootWhenInCombat;

	public bool skipVisibilityCheck;

	public float minDistanceToShoot;

	[FormerlySerializedAs("minDistanceToTargetToShoot")]
	public float maxDistanceToTargetToShoot = 15f;

	public float minCooldown;

	public float maxCooldown;

	[Header("Mortar Timings")]
	public float goUpTime;

	public float airTime;

	public float goDownTime;

	public float explodeTime;

	[Header("Spawn Pattern")]
	public bool shootAtSelf;

	public int minAmountOfProjectiles = 1;

	public int maxAmountOfProjectiles = 1;

	public int maxProjectilesShotPerWave = 1;

	public float maxProjectilesShotPerWaveMultiplier = 1f;

	public float timeBetweenProjectiles;

	public int keepShootingUntilTakingDamageXTimes;

	public float minRandomSpreadDistance;

	public float maxRandomSpreadDistance;

	public float maxHealthRatioToShoot = 1f;

	public bool dontAllowOverlappingShots;

	public bool lineFromShooterToTarget;

	public bool lineBendTowardTarget;

	public float lineLengthMultiplier;

	[Header("If an AreaLevelAuthoring component exists then stats are calculated from that")]
	public int mortarDamage;

	public float damageMultiplier = 1f;

	public bool hitTiles;

	public int mortarTileDamage;

	public float tileDamageMultiplier = 1f;

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
				mortarDamage = LevelToDamage(num, damageMultiplier);
				mortarTileDamage = MeleeAttackStateAuthoring.LevelToTileDamage(num, tileDamageMultiplier, isEnemy: true);
			}
		}
	}

	public static int LevelToDamage(int level, float damageMultiplier)
	{
		return (int)math.round((float)(math.max(1, level) * 10) * damageMultiplier);
	}
}
