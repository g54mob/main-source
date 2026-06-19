using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

public struct RangeAttackStateCD : IComponentData, IQueryTypeParameter
{
	public ThreadSafeTimerSimple internalTimer;

	public ThreadSafeTimerSimple shootTimer;

	public ObjectID projectileID;

	public int projectileVariation;

	public float speedMultiplier;

	public float anticipationDuration;

	public float attackDuration;

	public float endDuration;

	public float minCooldown;

	public float maxCooldown;

	public float spawnAtDistanceInfront;

	public float spawnAtDistanceInfrontDeviation;

	public float3 spawnOffset;

	public ProjectileSpawnDirectionType spawnDirectionType;

	public float minDistanceFromTargetToAllowAttack;

	public float maxDistanceFromTargetToAllowAttack;

	public int rangeDamage;

	public float sameFactionHealingPercentage;

	public float meleeDamageRadiusAtEntity;

	public float timeBetweenShots;

	public float startSpreadAngleOffset;

	public float spreadAngle;

	public float maxSpreadAngle;

	public ProjectileSpreadType spreadType;

	public int projectilesPerShot;

	public float aimDegreesMax;

	public float minExtrapolatedAimDistanceSq;

	public float maxExtrapolatedAimDistanceSq;

	[GhostField]
	public float3 aimDirection;

	[GhostField]
	public float3 shootDirection;

	[GhostField]
	public int shotsDone;

	public float3 relativePositionToShootFrom;

	public Entity aimingAtEntity;

	public int animOverride;

	public int animPerShotID;

	public int ceasingToShootID;

	public float2 minMaxBaseSpeedMultiplierByTargetDistance;

	public float2 minMaxDistanceForBaseSpeedMultiplier;

	public bool onlyAttackTargetsWeWantToAttack;

	public bool onlyAttackWhenInCombat;

	public bool projectileFollowsTarget;

	public bool projectileTargetsSelf;

	public bool skipVisibilityCheck;

	public bool shootNewRandomTargetsPerProjectile;

	public bool interruptOnDamageTaken;

	public bool dontAllowReAimingDuringAntipation;

	public bool allowReAimingWhileShooting;

	public bool modifyBaseSpeedByTargetDistance;

	public RangeAttackInternalState internalState;

	public bool isDisabled;
}
