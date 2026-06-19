using Pug.UnityExtensions;
using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct CoreBossCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public bool hasObtainedSouls;

	public float introTimeDuration;

	public int beamIdCounter;

	public StateID previousState;

	public StateID currentState;

	public int orbCount;

	public int orbsAlive;

	public float orbRotationSpeed;

	public float orbMinDistance;

	public float orbMaxDistance;

	public int whirlwindProjectileDamage;

	public int homingTriangleProjectileDamage;

	public int obtainSoulOrbsState;

	public ThreadSafeTimerSimple obtainSoulOrbsTimer;

	[GhostField]
	public CoreBossPhase phase;

	public float orbRotation;

	public ThreadSafeTimerSimple resetOrbsHealthTimer;

	public bool wasInPhaseTransitionPrevFrame;

	public int attackCounter;

	public double lastAttackTime;

	public double lastRangeAttackTime;

	public double lastWhirlwindRangeAttackTime;

	public double lastHomingTriangleRangeAttackTime;

	public double lastBeamAttackTime;

	public double lastVoidZoneAttackTime;

	public ThreadSafeTimerSimple reviveOrbMovementCooldownTimer;
}
