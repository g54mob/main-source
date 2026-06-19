using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct HydraBossCD : IComponentData, IQueryTypeParameter
{
	public HydraBossType hydraType;

	public int patternCounter;

	public bool hasPreparedNextMortarShots;

	[GhostField]
	public bool isShootingBeam;

	[GhostField(Smoothing = SmoothingAction.Interpolate)]
	public float3 beamTargetPoint;

	public Entity vulnerableEntityPrefab;

	public int internalState;

	public Entity targetPlayerEntity;

	public float3 startPointWhenMovingToPlayer;

	public float3 targetPointAroundPlayer;

	public ThreadSafeTimerSimple goingToPlayerCooldownTimer;

	public int pointsAroundPlayerCount;

	[GhostField]
	public float3 pointToLookAt;

	public ThreadSafeTimerSimple spawnOtherHydrasTimer;

	[GhostField]
	public bool isGhost;

	[GhostField]
	public bool isVoid;

	public int beamDamage;

	public int stalactiteMortarDamage;

	public int shockwaveDamage;

	public int iceShardMortarDamage;

	public int lavaMortarDamage;

	public int nilipedeMortarDamage;
}
