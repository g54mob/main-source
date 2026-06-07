using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace ECM2
{
	[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
	public sealed class CharacterMovement : MonoBehaviour
	{
		[Flags]
		private enum DepenetrationBehaviour
		{
			IgnoreNone = 0,
			IgnoreStatic = 1,
			IgnoreDynamic = 2,
			IgnoreKinematic = 4
		}

		[Serializable]
		public struct Advanced
		{
			[Tooltip("The minimum move distance of the character controller. If the character tries to move less than this distance, it will not move at all. This can be used to reduce jitter. In most situations this value should be left at 0.")]
			public float minMoveDistance;

			[Tooltip("Max number of iterations used during movement.")]
			public int maxMovementIterations;

			[Tooltip("Max number of iterations used to resolve penetrations.")]
			public int maxDepenetrationIterations;

			[Space(15f)]
			[Tooltip("If enabled, the character will interact with dynamic rigidbodies when walking into them.")]
			public bool enablePhysicsInteraction;

			[Tooltip("If enabled, the character will interact with other characters when walking into them.")]
			public bool allowPushCharacters;

			[Tooltip("If enabled, the character will move with the moving platform it is standing on.")]
			public bool impartPlatformMovement;

			[Tooltip("If enabled, the character will rotate (yaw-only) with the moving platform it is standing on.")]
			public bool impartPlatformRotation;

			[Tooltip("If enabled, impart the platform's velocity when jumping or falling off it.")]
			public bool impartPlatformVelocity;

			public float minMoveDistanceSqr => 0f;

			public void Reset()
			{
			}

			public void OnValidate()
			{
			}
		}

		public struct MovingPlatform
		{
			public Rigidbody lastPlatform;

			public Rigidbody platform;

			public Vector3 position;

			public Vector3 localPosition;

			public Vector3 deltaPosition;

			public Quaternion rotation;

			public Quaternion localRotation;

			public Quaternion deltaRotation;

			public Vector3 platformVelocity;
		}

		public delegate bool ColliderFilterCallback(Collider collider);

		public delegate CollisionBehaviour CollisionBehaviourCallback(Collider collider);

		public delegate void CollisionResponseCallback(ref CollisionResult inCollisionResult, ref Vector3 characterImpulse, ref Vector3 otherImpulse);

		public delegate void CollidedEventHandler(ref CollisionResult collisionResult);

		public delegate void FoundGroundEventHandler(ref FindGroundResult foundGround);

		private const float kKindaSmallNumber = 0.0001f;

		private const float kHemisphereLimit = 0.01f;

		private const int kMaxCollisionCount = 16;

		private const int kMaxOverlapCount = 16;

		private const float kSweepEdgeRejectDistance = 0.0015f;

		private const float kMinGroundDistance = 0.019f;

		private const float kMaxGroundDistance = 0.024f;

		private const float kAvgGroundDistance = 0.021499999f;

		private const float kMinWalkableSlopeLimit = 1f;

		private const float kMaxWalkableSlopeLimit = 0.017452f;

		private const float kPenetrationOffset = 0.00125f;

		private const float kContactOffset = 0.01f;

		private const float kSmallContactOffset = 0.001f;

		[Space(15f)]
		[Tooltip("Allow to constrain the Character so movement along the locked axis is not possible.")]
		[SerializeField]
		private PlaneConstraint _planeConstraint;

		[Space(15f)]
		[SerializeField]
		[Tooltip("The root transform in the avatar.")]
		private Transform _rootTransform;

		[SerializeField]
		[Tooltip("The root transform will be positioned at this offset from foot position.")]
		private Vector3 _rootTransformOffset;

		[Space(15f)]
		[Tooltip("The Character's capsule collider radius.")]
		[SerializeField]
		private float _radius;

		[Tooltip("The Character's capsule collider height")]
		[SerializeField]
		private float _height;

		[Space(15f)]
		[Tooltip("The maximum angle (in degrees) for a walkable surface.")]
		[SerializeField]
		private float _slopeLimit;

		[Tooltip("The maximum height (in meters) for a valid step.")]
		[SerializeField]
		private float _stepOffset;

		[Tooltip("Allow a Character to perch on the edge of a surface if the horizontal distance from the Character's position to the edge is closer than this.\nNote that characters will not fall off if they are within stepOffset of a walkable surface below.")]
		[SerializeField]
		private float _perchOffset;

		[Tooltip("When perching on a ledge, add this additional distance to stepOffset when determining how high above a walkable ground we can perch.\nNote that we still enforce stepOffset to start the step up, this just allows the Character to hang off the edge or step slightly higher off the ground.")]
		[SerializeField]
		private float _perchAdditionalHeight;

		[Space(15f)]
		[Tooltip("If enabled, colliders with SlopeLimitBehaviour component will be able to override this slope limit.")]
		[SerializeField]
		private bool _slopeLimitOverride;

		[Tooltip("When enabled, will treat head collisions as if the character is using a shape with a flat top.")]
		[SerializeField]
		private bool _useFlatTop;

		[Tooltip("Performs ground checks as if the character is using a shape with a flat base.This avoids the situation where characters slowly lower off the side of a ledge (as their capsule 'balances' on the edge).")]
		[SerializeField]
		private bool _useFlatBaseForGroundChecks;

		[Space(15f)]
		[Tooltip("Character collision layers mask.")]
		[SerializeField]
		private LayerMask _collisionLayers;

		[Tooltip("Overrides the global Physics.queriesHitTriggers to specify whether queries (raycast, spherecast, overlap tests, etc.) hit Triggers by default. Use Ignore for queries to ignore trigger Colliders.")]
		[SerializeField]
		private QueryTriggerInteraction _triggerInteraction;

		[Space(15f)]
		[SerializeField]
		private Advanced _advanced;

		private Transform _transform;

		private Rigidbody _rigidbody;

		private CapsuleCollider _capsuleCollider;

		private Vector3 _capsuleCenter;

		private Vector3 _capsuleTopCenter;

		private Vector3 _capsuleBottomCenter;

		private readonly HashSet<Rigidbody> _ignoredRigidbodies;

		private readonly HashSet<Collider> _ignoredColliders;

		private readonly RaycastHit[] _hits;

		private readonly Collider[] _overlaps;

		private int _collisionCount;

		private readonly CollisionResult[] _collisionResults;

		[SerializeField]
		[HideInInspector]
		private float _minSlopeLimit;

		private bool _detectCollisions;

		private bool _isConstrainedToGround;

		private float _unconstrainedTimer;

		private Vector3 _constraintPlaneNormal;

		private Vector3 _characterUp;

		private Vector3 _transformedCapsuleCenter;

		private Vector3 _transformedCapsuleTopCenter;

		private Vector3 _transformedCapsuleBottomCenter;

		private Vector3 _velocity;

		private Vector3 _pendingForces;

		private Vector3 _pendingImpulses;

		private Vector3 _pendingLaunchVelocity;

		private float _pushForceScale;

		private bool _hasLanded;

		private FindGroundResult _foundGround;

		private FindGroundResult _currentGround;

		private Rigidbody _parentPlatform;

		private MovingPlatform _movingPlatform;

		public new Transform transform => null;

		public Rigidbody rigidbody => null;

		public RigidbodyInterpolation interpolation
		{
			get
			{
				return default(RigidbodyInterpolation);
			}
			set
			{
			}
		}

		public Collider collider => null;

		public Transform rootTransform
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Vector3 rootTransformOffset
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Vector3 position
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Quaternion rotation
		{
			get
			{
				return default(Quaternion);
			}
			set
			{
			}
		}

		public Vector3 worldCenter => default(Vector3);

		public Vector3 updatedPosition { get; private set; }

		public Quaternion updatedRotation { get; private set; }

		public ref Vector3 velocity
		{
			get
			{
				throw null;
			}
		}

		public float speed => 0f;

		public float forwardSpeed => 0f;

		public float sidewaysSpeed => 0f;

		public float radius
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float height
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float slopeLimit
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float stepOffset
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float perchOffset
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float perchAdditionalHeight
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool slopeLimitOverride
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool useFlatTop
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool useFlatBaseForGroundChecks
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public LayerMask collisionLayers
		{
			get
			{
				return default(LayerMask);
			}
			set
			{
			}
		}

		public QueryTriggerInteraction triggerInteraction
		{
			get
			{
				return default(QueryTriggerInteraction);
			}
			set
			{
			}
		}

		public bool detectCollisions
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public CollisionFlags collisionFlags { get; private set; }

		public bool isConstrainedToPlane => false;

		public bool constrainToGround
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool isConstrainedToGround => false;

		public bool isGroundConstraintPaused => false;

		public float unconstrainedTimer => 0f;

		public bool wasOnGround { get; private set; }

		public bool isOnGround => false;

		public bool wasOnWalkableGround { get; private set; }

		public bool isOnWalkableGround => false;

		public bool wasGrounded { get; private set; }

		public bool isGrounded => false;

		public float groundDistance => 0f;

		public Vector3 groundPoint => default(Vector3);

		public Vector3 groundNormal => default(Vector3);

		public Vector3 groundSurfaceNormal => default(Vector3);

		public Collider groundCollider => null;

		public Transform groundTransform => null;

		public Rigidbody groundRigidbody => null;

		public FindGroundResult currentGround => default(FindGroundResult);

		public MovingPlatform movingPlatform => default(MovingPlatform);

		public Vector3 landedVelocity { get; private set; }

		public bool fastPlatformMove { get; set; }

		public bool impartPlatformMovement
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool impartPlatformRotation
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool impartPlatformVelocity
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool enablePhysicsInteraction
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool physicsInteractionAffectsCharacters
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float pushForceScale
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public ColliderFilterCallback colliderFilterCallback { get; set; }

		public CollisionBehaviourCallback collisionBehaviourCallback { get; set; }

		public CollisionResponseCallback collisionResponseCallback { get; set; }

		public event CollidedEventHandler Collided
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event FoundGroundEventHandler FoundGround
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private void OnCollided()
		{
		}

		private void OnFoundGround()
		{
		}

		private Vector3 FindOpposingNormal(Vector3 sweepDirDenorm, ref RaycastHit inHit)
		{
			return default(Vector3);
		}

		private static Vector3 FindBoxOpposingNormal(Vector3 sweepDirDenorm, ref RaycastHit inHit)
		{
			return default(Vector3);
		}

		private static Vector3 FindBoxOpposingNormal(Vector3 displacement, Vector3 hitNormal, Transform hitTransform)
		{
			return default(Vector3);
		}

		private static Vector3 FindTerrainOpposingNormal(ref RaycastHit inHit)
		{
			return default(Vector3);
		}

		private Vector3 FindGeomOpposingNormal(Vector3 sweepDirDenorm, ref RaycastHit inHit)
		{
			return default(Vector3);
		}

		public static bool IsFinite(float value)
		{
			return false;
		}

		public static bool IsFinite(Vector3 value)
		{
			return false;
		}

		private static Vector3 ApplyVelocityBraking(Vector3 currentVelocity, float friction, float deceleration, float deltaTime)
		{
			return default(Vector3);
		}

		private static float ComputeAnalogInputModifier(Vector3 desiredVelocity, float maxSpeed)
		{
			return 0f;
		}

		private static Vector3 CalcVelocity(Vector3 currentVelocity, Vector3 desiredVelocity, float maxSpeed, float acceleration, float deceleration, float friction, float brakingFriction, float deltaTime)
		{
			return default(Vector3);
		}

		private static Vector3 GetRigidbodyVelocity(Rigidbody rigidbody, Vector3 worldPoint)
		{
			return default(Vector3);
		}

		private static bool IsWalkable(CollisionBehaviour behaviourFlags)
		{
			return false;
		}

		private static bool IsNotWalkable(CollisionBehaviour behaviourFlags)
		{
			return false;
		}

		private static bool CanPerchOn(CollisionBehaviour behaviourFlags)
		{
			return false;
		}

		private static bool CanNotPerchOn(CollisionBehaviour behaviourFlags)
		{
			return false;
		}

		private static bool CanStepOn(CollisionBehaviour behaviourFlags)
		{
			return false;
		}

		private static bool CanNotStepOn(CollisionBehaviour behaviourFlags)
		{
			return false;
		}

		private static bool CanRideOn(CollisionBehaviour behaviourFlags)
		{
			return false;
		}

		private static bool CanNotRideOn(CollisionBehaviour behaviourFlags)
		{
			return false;
		}

		private static void MakeCapsule(float radius, float height, out Vector3 center, out Vector3 bottomCenter, out Vector3 topCenter)
		{
			center = default(Vector3);
			bottomCenter = default(Vector3);
			topCenter = default(Vector3);
		}

		public void SetDimensions(float characterRadius, float characterHeight)
		{
		}

		public void SetHeight(float characterHeight)
		{
		}

		private void CacheComponents()
		{
		}

		public Vector3 GetPlaneConstraintNormal()
		{
			return default(Vector3);
		}

		public void SetPlaneConstraint(PlaneConstraint constrainAxis, Vector3 planeNormal)
		{
		}

		public Vector3 ConstrainDirectionToPlane(Vector3 direction)
		{
			return default(Vector3);
		}

		public Vector3 ConstrainVectorToPlane(Vector3 vector)
		{
			return default(Vector3);
		}

		private void ResetCollisionFlags()
		{
		}

		private void UpdateCollisionFlags(HitLocation hitLocation)
		{
		}

		private HitLocation ComputeHitLocation(Vector3 inNormal)
		{
			return default(HitLocation);
		}

		private bool IsWalkable(Collider inCollider, Vector3 inNormal)
		{
			return false;
		}

		private Vector3 ComputeBlockingNormal(Vector3 inNormal, bool isWalkable)
		{
			return default(Vector3);
		}

		private bool ShouldFilter(Collider otherCollider)
		{
			return false;
		}

		public void CapsuleIgnoreCollision(Collider otherCollider, bool ignore = true)
		{
		}

		public void IgnoreCollision(Collider otherCollider, bool ignore = true)
		{
		}

		public void IgnoreCollision(Rigidbody otherRigidbody, bool ignore = true)
		{
		}

		private void ClearCollisionResults()
		{
		}

		private void AddCollisionResult(ref CollisionResult collisionResult)
		{
		}

		public int GetCollisionCount()
		{
			return 0;
		}

		public CollisionResult GetCollisionResult(int index)
		{
			return default(CollisionResult);
		}

		private bool ComputeInflatedMTD(Vector3 characterPosition, Quaternion characterRotation, float mtdInflation, Collider hitCollider, Transform hitTransform, out Vector3 mtdDirection, out float mtdDistance)
		{
			mtdDirection = default(Vector3);
			mtdDistance = default(float);
			return false;
		}

		private bool ComputeMTD(Vector3 characterPosition, Quaternion characterRotation, Collider hitCollider, Transform hitTransform, out Vector3 mtdDirection, out float mtdDistance)
		{
			mtdDirection = default(Vector3);
			mtdDistance = default(float);
			return false;
		}

		private void ResolveOverlaps(DepenetrationBehaviour depenetrationBehaviour = DepenetrationBehaviour.IgnoreNone)
		{
		}

		public int OverlapTest(Vector3 characterPosition, Quaternion characterRotation, float testRadius, float testHeight, int layerMask, Collider[] results, QueryTriggerInteraction queryTriggerInteraction)
		{
			return 0;
		}

		public Collider[] OverlapTest(Vector3 characterPosition, Quaternion characterRotation, float testRadius, float testHeight, int layerMask, QueryTriggerInteraction queryTriggerInteraction, out int overlapCount)
		{
			overlapCount = default(int);
			return null;
		}

		public Collider[] OverlapTest(int layerMask, QueryTriggerInteraction queryTriggerInteraction, out int overlapCount)
		{
			overlapCount = default(int);
			return null;
		}

		public bool CheckCapsule()
		{
			return false;
		}

		public bool CheckHeight(float testHeight)
		{
			return false;
		}

		public bool IsWithinEdgeTolerance(Vector3 characterPosition, Vector3 inPoint, float testRadius)
		{
			return false;
		}

		private bool ShouldCheckForValidLandingSpot(ref CollisionResult inCollision)
		{
			return false;
		}

		private bool IsValidLandingSpot(Vector3 characterPosition, ref CollisionResult inCollision)
		{
			return false;
		}

		public bool Raycast(Vector3 origin, Vector3 direction, float distance, int layerMask, out RaycastHit hitResult, float thickness = 0f)
		{
			hitResult = default(RaycastHit);
			return false;
		}

		private bool CapsuleCast(Vector3 characterPosition, float castRadius, Vector3 castDirection, float castDistance, int layerMask, out RaycastHit hitResult, out bool startPenetrating)
		{
			hitResult = default(RaycastHit);
			startPenetrating = default(bool);
			return false;
		}

		private static void SortArray(RaycastHit[] array, int length)
		{
		}

		private bool CapsuleCastEx(Vector3 characterPosition, float castRadius, Vector3 castDirection, float castDistance, int layerMask, out RaycastHit hitResult, out bool startPenetrating, out Vector3 recoverDirection, out float recoverDistance, bool ignoreNonBlockingOverlaps = false)
		{
			hitResult = default(RaycastHit);
			startPenetrating = default(bool);
			recoverDirection = default(Vector3);
			recoverDistance = default(float);
			return false;
		}

		private bool SweepTest(Vector3 sweepOrigin, float sweepRadius, Vector3 sweepDirection, float sweepDistance, int sweepLayerMask, out RaycastHit hitResult, out bool startPenetrating)
		{
			hitResult = default(RaycastHit);
			startPenetrating = default(bool);
			return false;
		}

		private bool SweepTestEx(Vector3 sweepOrigin, float sweepRadius, Vector3 sweepDirection, float sweepDistance, int sweepLayerMask, out RaycastHit hitResult, out bool startPenetrating, out Vector3 recoverDirection, out float recoverDistance, bool ignoreBlockingOverlaps = false)
		{
			hitResult = default(RaycastHit);
			startPenetrating = default(bool);
			recoverDirection = default(Vector3);
			recoverDistance = default(float);
			return false;
		}

		private bool ResolvePenetration(Vector3 displacement, Vector3 proposedAdjustment)
		{
			return false;
		}

		private bool MovementSweepTest(Vector3 characterPosition, Vector3 inVelocity, Vector3 displacement, out CollisionResult collisionResult)
		{
			collisionResult = default(CollisionResult);
			return false;
		}

		public bool MovementSweepTest(Vector3 characterPosition, Vector3 sweepDirection, float sweepDistance, out CollisionResult collisionResult)
		{
			collisionResult = default(CollisionResult);
			return false;
		}

		private Vector3 HandleSlopeBoosting(Vector3 slideResult, Vector3 displacement, Vector3 inNormal)
		{
			return default(Vector3);
		}

		private Vector3 ComputeSlideVector(Vector3 displacement, Vector3 inNormal, bool isWalkable)
		{
			return default(Vector3);
		}

		private int SlideAlongSurface(int iteration, Vector3 inputDisplacement, ref Vector3 inVelocity, ref Vector3 displacement, ref CollisionResult inHit, ref Vector3 prevNormal)
		{
			return 0;
		}

		private void PerformMovement(float deltaTime)
		{
		}

		private bool CanPerchOn(Collider otherCollider)
		{
			return false;
		}

		private float GetPerchRadiusThreshold()
		{
			return 0f;
		}

		private float GetValidPerchRadius(Collider otherCollider)
		{
			return 0f;
		}

		private bool ShouldComputePerchResult(Vector3 characterPosition, ref RaycastHit inHit)
		{
			return false;
		}

		private bool CapsuleCast(Vector3 point1, Vector3 point2, float castRadius, Vector3 castDirection, float castDistance, int castLayerMask, out RaycastHit hitResult, out bool startPenetrating)
		{
			hitResult = default(RaycastHit);
			startPenetrating = default(bool);
			return false;
		}

		private bool BoxCast(Vector3 center, Vector3 halfExtents, Quaternion orientation, Vector3 castDirection, float castDistance, int castLayerMask, out RaycastHit hitResult, out bool startPenetrating)
		{
			hitResult = default(RaycastHit);
			startPenetrating = default(bool);
			return false;
		}

		private bool GroundSweepTest(Vector3 characterPosition, float capsuleRadius, float capsuleHalfHeight, float sweepDistance, out RaycastHit hitResult, out bool startPenetrating)
		{
			hitResult = default(RaycastHit);
			startPenetrating = default(bool);
			return false;
		}

		public void ComputeGroundDistance(Vector3 characterPosition, float sweepRadius, float sweepDistance, float castDistance, out FindGroundResult outGroundResult)
		{
			outGroundResult = default(FindGroundResult);
		}

		private bool ComputePerchResult(Vector3 characterPosition, float testRadius, float inMaxGroundDistance, ref RaycastHit inHit, out FindGroundResult perchGroundResult)
		{
			perchGroundResult = default(FindGroundResult);
			return false;
		}

		public void FindGround(Vector3 characterPosition, out FindGroundResult outGroundResult)
		{
			outGroundResult = default(FindGroundResult);
		}

		private void AdjustGroundHeight()
		{
		}

		private bool CanStepUp(Collider otherCollider)
		{
			return false;
		}

		private bool StepUp(ref CollisionResult inCollision, out CollisionResult stepResult)
		{
			stepResult = default(CollisionResult);
			return false;
		}

		public void PauseGroundConstraint(float unconstrainedTime = 0.1f)
		{
		}

		private void UpdateCurrentGround(ref FindGroundResult inGroundResult)
		{
		}

		private int SlideAlongSurface(int iteration, Vector3 inputDisplacement, ref Vector3 displacement, ref CollisionResult inHit, ref Vector3 prevNormal)
		{
			return 0;
		}

		private void MoveAndSlide(Vector3 displacement)
		{
		}

		private bool CanRideOn(Collider otherCollider)
		{
			return false;
		}

		private void IgnoreCurrentPlatform(bool ignore)
		{
		}

		public void AttachTo(Rigidbody parent)
		{
		}

		private void UpdateCurrentPlatform()
		{
		}

		private void UpdatePlatformMovement(float deltaTime)
		{
		}

		private void ComputeDynamicCollisionResponse(ref CollisionResult inCollisionResult, out Vector3 characterImpulse, out Vector3 otherImpulse)
		{
			characterImpulse = default(Vector3);
			otherImpulse = default(Vector3);
		}

		private void ResolveDynamicCollisions()
		{
		}

		public void SetPosition(Vector3 newPosition, bool updateGround = false)
		{
		}

		public Vector3 GetPosition()
		{
			return default(Vector3);
		}

		public Vector3 GetFootPosition()
		{
			return default(Vector3);
		}

		public void SetRotation(Quaternion newRotation)
		{
		}

		public Quaternion GetRotation()
		{
			return default(Quaternion);
		}

		public void SetPositionAndRotation(Vector3 newPosition, Quaternion newRotation, bool updateGround = false)
		{
		}

		public void RotateTowards(Vector3 worldDirection, float maxDegreesDelta, bool updateYawOnly = true)
		{
		}

		private void UpdateCachedFields()
		{
		}

		public void ClearAccumulatedForces()
		{
		}

		public void AddForce(Vector3 force, ForceMode forceMode = ForceMode.Force)
		{
		}

		public void AddExplosionForce(float strength, Vector3 origin, float radius, ForceMode forceMode = ForceMode.Force)
		{
		}

		public void LaunchCharacter(Vector3 launchVelocity, bool overrideVerticalVelocity = false, bool overrideLateralVelocity = false)
		{
		}

		private void UpdateVelocity(Vector3 newVelocity, float deltaTime)
		{
		}

		public CollisionFlags Move(Vector3 newVelocity, float deltaTime)
		{
			return default(CollisionFlags);
		}

		public CollisionFlags Move(float deltaTime)
		{
			return default(CollisionFlags);
		}

		public CollisionFlags SimpleMove(Vector3 desiredVelocity, float maxSpeed, float acceleration, float deceleration, float friction, float brakingFriction, Vector3 gravity, bool onlyHorizontal, float deltaTime)
		{
			return default(CollisionFlags);
		}

		[ContextMenu("Init Collision Layers from Collision Matrix")]
		private void InitCollisionMask()
		{
		}

		public void SetState(Vector3 inPosition, Quaternion inRotation, Vector3 inVelocity, bool inConstrainedToGround, float inUnconstrainedTimer, bool inHitGround, bool inIsWalkable)
		{
		}

		private void Reset()
		{
		}

		private void OnValidate()
		{
		}

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}
	}
}
