using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct SnakeMovementStateCD : IComponentData, IQueryTypeParameter
{
	public float spread;

	public float additionalHorizontalSpread;

	public float turnDuration;

	public float distanceToTargetToChangeTarget;

	public SnakeMovementTilePlacementType tilePlacementType;

	public float tilePlacementRadiusMultiplier;

	[GhostField]
	public Entity headRef;

	public ThreadSafeTimerSimple changeDirectionTimer;

	public float playerTargetCooldownMin;

	public float playerTargetCooldownMax;

	public ThreadSafeTimerSimple playerTargetCooldownTimer;

	public int initialLength;

	public quaternion currentRotation;

	public quaternion previousRotation;

	public quaternion targetRotation;

	public int targetPointIndex;

	public float3 targetPoint;

	public Entity targetEntity;

	public float3 externallyRequestedTargetPoint;

	public bool disableDamage;

	public ObjectID tailObjectId;

	[GhostField]
	public float3 currentDirection;

	public float3 facingDirection;

	[GhostField]
	public SnakeMovementPhaseType currentPhase;

	public SnakeMovementPhaseType externallyRequestedPhase;

	public float3 phase2Position;

	public SnakeMovementTurnType currentTurnType;

	public float rotationLerpAlpha;

	public int internalState;

	public int damage;

	public float3 attackOffset;

	public float pushbackForce;

	public float attackRadius;

	public float wavinessTurnTime;

	public float wavinessAmplitude;

	public bool dontDealDamage;

	public float movementSpeedMultiplier;

	public float distanceSqToAttackPlayer;

	public float distanceSqAllowedToMoveAwayFromCombatStartPosition;

	public float tooCloseDistanceForAttack;

	public bool dontDropLootFromObjectsBeingDestroyed;

	public ObjectID cantHitSpecificObject;

	public SnakeTargetingType targetingType;

	public ThreadSafeTimerSimple pauseMovementTimer;

	public bool usePhysVelocity;

	public bool slowDownForWalls;

	public bool hasSetEnteredWallTime;

	public double enteredWallTime;

	public ThreadSafeTimerSimple leaveWallTimer;

	public float leaveWallAlpha;

	public ThreadSafeTimerSimple speedBoostTimer;

	public float enterWallAlpha;

	public bool triggeredEnterWallTimer;

	public ThreadSafeTimerSimple enterWallTimer;

	public bool useCaterpillarMovement;

	public float stretchOutStrength;

	public float stretchBackStrength;

	public float stretchFrequency;

	public float stretchSpread;

	public bool chaoticMovement;

	public bool isDisabled;

	public bool IsHead(Entity entity)
	{
		return headRef == entity;
	}
}
