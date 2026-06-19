using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;

public struct ShootMortarProjectileStateCD : IComponentData, IQueryTypeParameter
{
	public ObjectID mortarProjectileID;

	public bool onlyShootWhenInCombat;

	public bool shootAtSelf;

	public bool skipVisibilityCheck;

	public float anticipationDuration;

	public float attackDuration;

	public float2 minMaxDistanceToTargetToShootSqr;

	public float minCooldown;

	public float maxCooldown;

	public float goUpTime;

	public float airTime;

	public float airTimeAdditionBetweenProjectiles;

	public float goDownTime;

	public float explodeTime;

	public int mortarDamage;

	public bool hitTiles;

	public int mortarTileDamage;

	public int minAmountOfProjectiles;

	public int maxAmountOfProjectiles;

	public int maxProjectilesShotPerWave;

	public float maxProjectilesShotPerWaveMultiplier;

	public float timeBetweenProjectiles;

	public int projectilesToSpawn;

	public int projectilesSpawned;

	public int waveCount;

	public float minRandomSpreadDistance;

	public float maxRandomSpreadDistance;

	public int keepShootingUntilTakingDamageXTimes;

	public int damageTakenCountOnStartingToShoot;

	public float maxHealthRatioToShoot;

	public int internalState;

	public float3 shootPosition;

	public float3 initialShootPosition;

	public Entity aimingAtEntity;

	public bool overridePositionToShootAt;

	public float3 overrideShootPosition;

	public ThreadSafeTimerSimple internalTimer;

	public ThreadSafeTimerSimple cooldownTimer;

	public bool isDisabled;

	public bool dontAllowOverlappingShots;

	public bool lineFromShooterToTarget;

	public bool lineBendTowardTarget;

	public float lineLengthMultiplier;

	public float lineLengthStartPositionPadding;

	public float lineScatterMultiplier;

	public int overrideAnimID;

	public bool playAttackFireAnimation;

	public bool canShootOnWaterAndPits;

	public bool destroyProjectilesWhenNotInState;

	public bool dontInterruptOtherAttackStates;
}
