using Pug.UnityExtensions;
using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct WallBossCD : IComponentData, IQueryTypeParameter
{
	public WallBossInternalState internalState;

	public float distanceFromCore;

	public float segmentRadius;

	public int totalSegments;

	public float totalWidth;

	public float attackTimer;

	public float attackDuration;

	public float attackCooldown;

	public float slitheringFrequencyMultiplier;

	public float slitheringWavelengthMultiplier;

	public float slitheringWaveHeightMultiplier;

	public float slitherElapsedTime;

	public int prevHealth;

	public float headOffset;

	public float bulbOffset;

	[GhostField]
	public Entity mainEntity;

	[GhostField]
	public bool isMainEntity;

	[GhostField]
	public Entity leftEntity;

	[GhostField]
	public Entity rightEntity;

	[GhostField]
	public int segmentNumber;

	public float pauseBeforeBulbsEmergeDuration;

	public float pauseBeforeHeadEmergesDuration;

	public float vulnerableDuration;

	public float vulnerableOnDamageMaxDuration;

	public float healthRatioOnEnteringVulnerableState;

	public ThreadSafeTimerSimple vulnerableTimer;

	public ThreadSafeTimerSimple pauseTimer;

	public int currentAliveTargets;

	[GhostField]
	public WallBossMovementState movementState;

	public ThreadSafeTimerSimple decelerationTimer;

	public float currentDecelerationSpeed;

	public float currentAccelerationSpeed;

	[GhostField]
	public float currentSpeed;

	public float currentMaxSpeed;

	public float baseSpeed;

	public float maxSpeed;

	public ThreadSafeTimerSimple healthRegenTimer;
}
