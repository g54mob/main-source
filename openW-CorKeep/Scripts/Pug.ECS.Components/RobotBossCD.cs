using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

public struct RobotBossCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public RobotBossInternalState internalState;

	public float legXOffset;

	public float legZOffset;

	public float downLifeCheckBuffer;

	public bool triggeredPhase2;

	[GhostField]
	public bool fellInLava;

	public float lavaHealthDrainTimer;

	public int partsDropsRemaining;

	[GhostField]
	public bool animateTheLegs;

	[GhostField]
	public int legBrokenTime;

	[GhostField]
	public bool legsAreVulnerable;

	[GhostField]
	public bool isActuallyMoving;

	public bool fireLargeProjectile;

	public float chainedDelayBetweenAttacks;

	public int numberOfAttacksInChain;

	public int rangeAttackIndex;

	public bool hasSetFiringPatternForNextAttack;

	public int chainedAttackCounter;

	[GhostField]
	public RobotBossAttackPattern rangeAttackPattern;

	[GhostField]
	public float3 rangeAttackDirection;

	public bool hasDisabledAttacks;

	public float stepHeightProgressMultiplier;

	public float distanceToTriggerLegMovement;

	public float legMovementSpeed;

	public float maxStepHeight;

	public float startDistance;

	public float stepForwardDistance;

	public float legStepCooldownTimer;

	public float legStepCooldownDuration;

	public int currentLegPairWalking;

	public ThreadSafeTimerSimple phase1ToPhase2Timer;

	public ThreadSafeTimerSimple walkingButDownTimer;

	public ThreadSafeTimerSimple walkingGetBackUpTimer;

	public ThreadSafeTimerSimple pauseWalkDuringShootingimer;
}
