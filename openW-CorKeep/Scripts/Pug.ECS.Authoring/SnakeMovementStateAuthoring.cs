using UnityEngine;

public class SnakeMovementStateAuthoring : MonoBehaviour
{
	[Tooltip("This means that each segment can be damaged and killed by the player instead of hurting one entity as a single unit")]
	public bool treatSegmentsAsIndividualParts;

	public int initialLength;

	public float spread = 1f;

	public float additionalHorizontalSpread = 1.6f;

	public float turnDuration = 3f;

	public float distanceToTargetToChangeTarget = 5f;

	public float attackRadius = 1f;

	public Vector3 attackOffset;

	public float pushbackForce = 10f;

	public SnakeMovementTilePlacementType tilePlacementType;

	public float tilePlacementRadiusMultiplier = 1f;

	public float wavinessTurnTime;

	public float wavinessAmplitude;

	public float distanceToAttackPlayer = 15f;

	public float distanceAllowedToMoveAwayFromCombatStartPosition = 30f;

	public float tooCloseDistanceForAttack = 1f;

	public bool dontDropLootFromObjectsBeingDestroyed;

	public ObjectID cantHitSpecificObject;

	public SnakeTargetingType targetingType;

	public bool descendIntoPits;

	public ObjectID tailObjectId;

	public bool disableDamage;

	public bool usePhysVelocity = true;

	public float playerTargetCooldownMin;

	public float playerTargetCooldownMax;

	public bool slowDownForWalls = true;

	public bool playMoveAnimation;

	[Header("If an AreaLevelAuthoring component exists then stats are calculated from that")]
	public int damage;

	public float damageMultiplier = 1f;

	[Header("Caterpillar Movement Settings")]
	[Tooltip("The worm segments stretch and contract as they move, giving the appearance of a caterpillar")]
	public bool useCaterpillarMovement;

	public float stretchOutStrength = 0.8f;

	public float stretchBackStrength = 0.8f;

	public float stretchFrequency = 10f;

	public float stretchSpread = 2.5f;

	[Header("Chaotic mode - less predictable movement")]
	public bool chaoticMovement;
}
