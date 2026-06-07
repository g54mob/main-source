using System;
using System.Collections.Generic;
using Lightbug.Utilities;
using UnityEngine;
using UnityEngine.Serialization;

namespace Lightbug.CharacterControllerPro.Core
{
	[AddComponentMenu("Character Controller Pro/Core/Character Actor")]
	[RequireComponent(typeof(CharacterBody))]
	[DefaultExecutionOrder(10)]
	public class CharacterActor : PhysicsActor
	{
		public enum SizeReferenceType
		{
			Top = 0,
			Center = 1,
			Bottom = 2
		}

		public enum CharacterVelocityMode
		{
			UseInputVelocity = 0,
			UsePreSimulationVelocity = 1,
			UsePostSimulationVelocity = 2
		}

		[Header("One way platforms")]
		[Tooltip("One way platforms are objects that can be contacted by the character feet (bottom sphere) while descending.")]
		public LayerMask oneWayPlatformsLayerMask = 0;

		[Tooltip("This value defines (in degrees) the total arc used by the one way platform detection algorithm (using the bottom part of the capsule). the angle is measured between the up direction and the segment formed by the contact point and the character bottom center (capsule). \nArc = 180 degrees ---> contact point = any point on the bottom sphere.\nArc = 0 degrees ---> contact point = bottom most point")]
		[Range(0f, 179f)]
		public float oneWayPlatformsValidArc = 175f;

		[Header("Stability")]
		[Tooltip("If the character is stable, the ground slope angle must be less than or equal to this value in order to remain \"stable\". The angle is calculated using the \"ground stable normal\".")]
		[Range(1f, 89f)]
		public float slopeLimit = 55f;

		[Tooltip("Objects NOT represented by this layer mask will be considered by the character as \"unstable objects\". If you don't want to define unstable layers, select \"Everything\" (default value).")]
		public LayerMask stableLayerMask = -1;

		[Tooltip("Whether or not to allow other characters to be considered as stable surfaces.")]
		public bool allowCharactersAsStableSurfaces = true;

		[Tooltip("A high planar velocity value (e.g. tight platformer) can be projected onto an unstable surface, causing the character to climb over obstacles it is not supposed to. This option will prevent that by removing all the extra planar velocity.")]
		public bool preventUnstableClimbing = true;

		[Tooltip("This will prevent the character from stepping over an unstable surface (a \"bad\" step). This requires a bit more processing, so if your character does not need this level of precision you can disable it.")]
		public bool preventBadSteps = true;

		[Header("Step handling")]
		[Tooltip("The offset distance applied to the bottom of the character. A higher offset means more walkable surfaces")]
		[Min(0f)]
		public float stepUpDistance = 0.5f;

		[Tooltip("The distance the character is capable of detecting ground. Use this value to clamp (or not) the character to the ground.")]
		[Min(0f)]
		public float stepDownDistance = 0.5f;

		[Header("Grounding")]
		[Tooltip("Prevents the character from enter grounded state (IsGrounded will be false)")]
		public bool alwaysNotGrounded;

		[Condition("alwaysNotGrounded", ConditionAttribute.ConditionType.IsFalse, ConditionAttribute.VisibilityType.Hidden, 0f)]
		[Tooltip("If enabled the character will do an initial ground check (at \"Start\"). If the test fails the starting state will be \"Not grounded\".")]
		public bool forceGroundedAtStart = true;

		[Tooltip("This option will enable a trigger (located at the capsule bottom center) that can be used to generate OnTriggerXXX messages. Normally the character won't generate these messages (OnCollisionXXX/OnTriggerXXX) since the collider is not making direct contact with the ground")]
		public bool useGroundTrigger = true;

		[Tooltip("With this enabled the character bottom sphere (capsule) will be simulated as a cylinder. This works only when the character is standing on an edge.")]
		public bool edgeCompensation;

		[Tooltip("Situation: The character makes contact with the ground and detect a stable edge.\n\n True: the character will enter stable state regardless of the collision contact angle.\n\n\n False: the character will use the contact angle instead (contact normal) in order to determine stability (<= slopeLimit).")]
		public bool useStableEdgeWhenLanding = true;

		[Tooltip("Should the character detect a new (and valid) ground if its vertical velocity is positive?")]
		public bool detectGroundWhileAscending;

		[Header("Dynamic ground")]
		[Tooltip("Should the character be affected by the movement of the ground?")]
		public bool supportDynamicGround = true;

		public LayerMask dynamicGroundLayerMask = -1;

		[Condition("supportDynamicGround", ConditionAttribute.ConditionType.IsTrue, ConditionAttribute.VisibilityType.NotEditable, 0f)]
		[Tooltip("The forward direction of the character will be affected by the rotation of the ground (only yaw motion allowed).")]
		public bool rotateForwardDirection = true;

		[Condition("supportDynamicGround", ConditionAttribute.ConditionType.IsTrue, ConditionAttribute.VisibilityType.NotEditable, 0f)]
		[Tooltip("This is the maximum ground velocity delta (from the previous frame to the current one) tolerated by the character.\n\nIf the ground accelerates too much, then the character will stop moving with it.\n\nImportant: This does not apply to one way platforms.")]
		public float maxGroundVelocityChange = 30f;

		[FormerlySerializedAs("maxForceNotGroundedGroundVelocity")]
		[Condition("supportDynamicGround", ConditionAttribute.ConditionType.IsTrue, ConditionAttribute.VisibilityType.NotEditable, 0f)]
		[Tooltip("When the character becomes \"not grounded\" (after a ForceNotGrounded call) part of the ground velocity can be transferred to its own velocity. This value represents the minimum planar velocity required.")]
		public float inheritedGroundPlanarVelocityThreshold = 2f;

		[Condition("supportDynamicGround", ConditionAttribute.ConditionType.IsTrue, ConditionAttribute.VisibilityType.NotEditable, 0f)]
		[Tooltip("When the character becomes \"not grounded\" (after a ForceNotGrounded call) part of the ground velocity can be transferred to its own velocity. This value represents how much of the planar component is utilized.")]
		public float inheritedGroundPlanarVelocityMultiplier = 1f;

		[FormerlySerializedAs("maxForceNotGroundedGroundVelocity")]
		[Condition("supportDynamicGround", ConditionAttribute.ConditionType.IsTrue, ConditionAttribute.VisibilityType.NotEditable, 0f)]
		[Tooltip("When the character becomes \"not grounded\" (after a ForceNotGrounded call) part of the ground velocity can be transferred to its own velocity. This value represents the minimum vertical velocity required.")]
		public float inheritedGroundVerticalVelocityThreshold = 2f;

		[Condition("supportDynamicGround", ConditionAttribute.ConditionType.IsTrue, ConditionAttribute.VisibilityType.NotEditable, 0f)]
		[Tooltip("When the character becomes \"not grounded\" (after a ForceNotGrounded call) part of the ground velocity can be transferred to its own velocity. This value represents how much of the planar component is utilized.")]
		public float inheritedGroundVerticalVelocityMultiplier = 1f;

		[Header("Velocity")]
		[Tooltip("Whether or not to project the initial velocity (stable) onto walls.")]
		[SerializeField]
		public bool slideOnWalls = true;

		[SerializeField]
		private bool resetVelocityOnTeleport = true;

		[Tooltip("Should the actor re-assign the rigidbody velocity after the simulation is done?\n\nPreSimulationVelocity: the character uses the velocity prior to the simulation (modified by this component).\nPostSimulationVelocity: the character uses the velocity received from the simulation (no re-assignment).\nInputVelocity: the character \"gets back\" its initial velocity (before being modified by this component).")]
		public CharacterVelocityMode stablePostSimulationVelocity = CharacterVelocityMode.UsePostSimulationVelocity;

		[Tooltip("Should the actor re-assign the rigidbody velocity after the simulation is done?\n\nPreSimulationVelocity: the character uses the velocity prior to the simulation (modified by this component).\nPostSimulationVelocity: the character uses the velocity received from the simulation (no re-assignment).\nInputVelocity: the character \"gets back\" its initial velocity (before being modified by this component).")]
		public CharacterVelocityMode unstablePostSimulationVelocity = CharacterVelocityMode.UsePostSimulationVelocity;

		[Header("Rotation")]
		[Tooltip("Should this component define the character \"Up\" direction?")]
		public bool constraintRotation = true;

		[Condition("constraintRotation", ConditionAttribute.ConditionType.IsTrue, ConditionAttribute.VisibilityType.NotEditable, 0f)]
		public Transform upDirectionReference;

		[Condition(new string[] { "constraintRotation", "upDirectionReference" }, new ConditionAttribute.ConditionType[]
		{
			ConditionAttribute.ConditionType.IsTrue,
			ConditionAttribute.ConditionType.IsNotNull
		}, new float[] { 0f, 0f }, ConditionAttribute.VisibilityType.Hidden)]
		public VerticalAlignmentSettings.VerticalReferenceMode upDirectionReferenceMode = VerticalAlignmentSettings.VerticalReferenceMode.Away;

		[Condition(new string[] { "constraintRotation", "upDirectionReference" }, new ConditionAttribute.ConditionType[]
		{
			ConditionAttribute.ConditionType.IsTrue,
			ConditionAttribute.ConditionType.IsNull
		}, new float[] { 0f, 0f }, ConditionAttribute.VisibilityType.Hidden)]
		[Tooltip("The desired up direction.")]
		public Vector3 constraintUpDirection = Vector3.up;

		[Header("Physics")]
		public bool canPushDynamicRigidbodies = true;

		[Condition("canPushDynamicRigidbodies", ConditionAttribute.ConditionType.IsTrue, ConditionAttribute.VisibilityType.NotEditable, 0f)]
		public LayerMask pushableRigidbodyLayerMask = -1;

		public bool applyWeightToGround = true;

		[Condition("applyWeightToGround", ConditionAttribute.ConditionType.IsTrue, ConditionAttribute.VisibilityType.NotEditable, 0f)]
		public LayerMask applyWeightLayerMask = -1;

		[Condition("applyWeightToGround", ConditionAttribute.ConditionType.IsTrue, ConditionAttribute.VisibilityType.NotEditable, 0f)]
		public float weightGravity = 9.8f;

		private Vector3 groundToCharacter;

		private bool forceNotGroundedFlag;

		private int forceNotGroundedFrames;

		private bool inheritVelocityFlag;

		private Quaternion preSimulationGroundRotation;

		private Vector3 preSimulationPosition;

		private RigidbodyComponent groundRigidbodyComponent;

		private CircleCollider2D groundTriggerCollider2D;

		private SphereCollider groundTriggerCollider3D;

		private float unstableGroundContactTime;

		private ColliderComponent.PenetrationDelegate _removePenetrationAction;

		protected CharacterCollisionInfo characterCollisionInfo;

		private Dictionary<Transform, Terrain> terrains = new Dictionary<Transform, Terrain>();

		private Dictionary<Transform, RigidbodyComponent> groundRigidbodyComponents = new Dictionary<Transform, RigidbodyComponent>();

		private HitFilterDelegate _collisionHitFilter;

		public float StepOffset => stepUpDistance - BodySize.x / 2f;

		public override RigidbodyComponent RigidbodyComponent => CharacterBody.RigidbodyComponent;

		public ColliderComponent ColliderComponent => CharacterBody.ColliderComponent;

		public PhysicsComponent PhysicsComponent => CharacterCollisions.PhysicsComponent;

		public CharacterBody CharacterBody { get; private set; }

		public CharacterActorState CurrentState
		{
			get
			{
				if (IsGrounded)
				{
					if (!IsStable)
					{
						return CharacterActorState.UnstableGrounded;
					}
					return CharacterActorState.StableGrounded;
				}
				return CharacterActorState.NotGrounded;
			}
		}

		public CharacterActorState PreviousState
		{
			get
			{
				if (WasGrounded)
				{
					if (!WasStable)
					{
						return CharacterActorState.UnstableGrounded;
					}
					return CharacterActorState.StableGrounded;
				}
				return CharacterActorState.NotGrounded;
			}
		}

		public LayerMask ObstaclesLayerMask => (int)PhysicsComponent.CollisionLayerMask | (int)oneWayPlatformsLayerMask;

		public LayerMask ObstaclesWithoutOWPLayerMask => (int)PhysicsComponent.CollisionLayerMask & ~(int)oneWayPlatformsLayerMask;

		public bool IsOnEdge => characterCollisionInfo.isOnEdge;

		public float EdgeAngle => characterCollisionInfo.edgeAngle;

		public bool IsGrounded { get; private set; }

		public float GroundSlopeAngle => characterCollisionInfo.groundSlopeAngle;

		public Vector3 GroundContactPoint => characterCollisionInfo.groundContactPoint;

		public Vector3 GroundContactNormal => characterCollisionInfo.groundContactNormal;

		public Vector3 GroundStableNormal
		{
			get
			{
				if (!IsStable)
				{
					return Up;
				}
				return characterCollisionInfo.groundStableNormal;
			}
		}

		public GameObject GroundObject => characterCollisionInfo.groundObject;

		public Transform GroundTransform
		{
			get
			{
				if (!(GroundObject != null))
				{
					return null;
				}
				return GroundObject.transform;
			}
		}

		public Collider2D GroundCollider2D => characterCollisionInfo.groundCollider2D;

		public Collider GroundCollider3D => characterCollisionInfo.groundCollider3D;

		public Rigidbody2D GroundRigidbody2D => characterCollisionInfo.groundRigidbody2D;

		public Rigidbody GroundRigidbody3D => characterCollisionInfo.groundRigidbody3D;

		public bool WallCollision => characterCollisionInfo.wallCollision;

		public float WallAngle => characterCollisionInfo.wallAngle;

		public Contact WallContact => characterCollisionInfo.wallContact;

		public bool HeadCollision => characterCollisionInfo.headCollision;

		public float HeadAngle => characterCollisionInfo.headAngle;

		public Contact HeadContact => characterCollisionInfo.headContact;

		public bool IsStable { get; private set; }

		public bool IsOnUnstableGround
		{
			get
			{
				if (IsGrounded)
				{
					return characterCollisionInfo.groundSlopeAngle > slopeLimit;
				}
				return false;
			}
		}

		public bool WasGrounded { get; private set; }

		public bool WasStable { get; private set; }

		public bool HasBecomeGrounded { get; private set; }

		public bool HasBecomeStable { get; private set; }

		public bool HasBecomeNotGrounded { get; private set; }

		public bool HasBecomeUnstable { get; private set; }

		public RigidbodyComponent GroundRigidbodyComponent
		{
			get
			{
				if (!IsStable)
				{
					groundRigidbodyComponent = null;
				}
				return groundRigidbodyComponent;
			}
		}

		public Vector3 GroundPosition
		{
			get
			{
				if (!base.Is2D)
				{
					return GroundRigidbody3D.position;
				}
				return new Vector3(GroundRigidbody2D.position.x, GroundRigidbody2D.position.y, GroundTransform.position.z);
			}
		}

		public Quaternion GroundRotation
		{
			get
			{
				if (!base.Is2D)
				{
					return GroundRigidbody3D.rotation;
				}
				return Quaternion.Euler(0f, 0f, GroundRigidbody2D.rotation);
			}
		}

		public bool IsGroundARigidbody
		{
			get
			{
				if (!base.Is2D)
				{
					return characterCollisionInfo.groundRigidbody3D != null;
				}
				return characterCollisionInfo.groundRigidbody2D != null;
			}
		}

		public bool IsGroundAKinematicRigidbody
		{
			get
			{
				if (!base.Is2D)
				{
					return characterCollisionInfo.groundRigidbody3D.isKinematic;
				}
				return characterCollisionInfo.groundRigidbody2D.bodyType == RigidbodyType2D.Kinematic;
			}
		}

		public CharacterCollisionInfo CharacterCollisionInfo => characterCollisionInfo;

		public float GroundedTime { get; private set; }

		public float NotGroundedTime { get; private set; }

		public float StableElapsedTime { get; private set; }

		public float UnstableElapsedTime { get; private set; }

		public Vector2 BodySize { get; private set; }

		public Vector2 DefaultBodySize => CharacterBody.BodySize;

		public Vector3 StableVelocity
		{
			get
			{
				return CustomUtilities.ProjectOnTangent(base.Velocity, GroundStableNormal, Up);
			}
			set
			{
				base.Velocity = CustomUtilities.ProjectOnTangent(value, GroundStableNormal, Up);
			}
		}

		public Vector3 LastGroundedVelocity { get; private set; }

		public Vector3 Center => GetCenter(base.Position);

		public Vector3 Top => GetTop(base.Position);

		public Vector3 Bottom => GetBottom(base.Position);

		public Vector3 TopCenter => GetTopCenter(base.Position);

		public Vector3 BottomCenter => GetBottomCenter(base.Position);

		public Vector3 OffsettedBottomCenter => GetBottomCenter(base.Position, StepOffset);

		public CharacterCollisions CharacterCollisions { get; private set; }

		public List<Contact> Contacts
		{
			get
			{
				if (PhysicsComponent == null)
				{
					return null;
				}
				return PhysicsComponent.Contacts;
			}
		}

		public Trigger CurrentTrigger
		{
			get
			{
				if (PhysicsComponent.Triggers.Count == 0)
				{
					return default(Trigger);
				}
				return PhysicsComponent.Triggers[PhysicsComponent.Triggers.Count - 1];
			}
		}

		public List<Trigger> Triggers => PhysicsComponent.Triggers;

		public Vector3 InputVelocity { get; private set; }

		public Vector3 LocalInputVelocity => base.transform.InverseTransformDirection(InputVelocity);

		public Vector3 PreSimulationVelocity { get; private set; }

		public Vector3 PostSimulationVelocity { get; private set; }

		public Vector3 ExternalVelocity { get; private set; }

		public List<Contact> WallContacts { get; private set; } = new List<Contact>(10);

		public List<Contact> HeadContacts { get; private set; } = new List<Contact>(10);

		public List<Contact> GroundContacts { get; private set; } = new List<Contact>(10);

		public Vector3 GroundVelocity { get; private set; }

		public Vector3 PreviousGroundVelocity { get; private set; }

		public Vector3 GroundDeltaVelocity => GroundVelocity - PreviousGroundVelocity;

		public Vector3 GroundAcceleration => (GroundVelocity - PreviousGroundVelocity) / Time.fixedDeltaTime;

		public bool IsGroundAscending => base.transform.InverseTransformVectorUnscaled(Vector3.Project(CustomUtilities.Multiply(GroundVelocity, Time.deltaTime), Up)).y > 0f;

		public Terrain CurrentTerrain { get; private set; }

		public bool IsOnTerrain => CurrentTerrain != null;

		public Vector3 GroundProbingDisplacement { get; private set; }

		public Vector3 PreGroundProbingPosition { get; private set; }

		public Vector3 PostGroundProbingPosition { get; private set; }

		public bool IsGroundAOneWayPlatform
		{
			get
			{
				if (GroundObject == null)
				{
					return false;
				}
				return CustomUtilities.BelongsToLayerMask(GroundObject.layer, oneWayPlatformsLayerMask);
			}
		}

		public bool CanEnterGroundedState
		{
			get
			{
				if (!alwaysNotGrounded)
				{
					return forceNotGroundedFrames == 0;
				}
				return false;
			}
		}

		public GameObject PredictedGround { get; private set; }

		public float PredictedGroundDistance { get; private set; }

		public event Action<Contact> OnHeadHit;

		public event Action<Contact> OnWallHit;

		public event Action<Vector3> OnGroundedStateEnter;

		public event Action OnGroundedStateExit;

		public event Action OnNewGroundEnter;

		public event Action<Vector3> OnStableStateEnter;

		public event Action OnStableStateExit;

		public void OnValidate()
		{
			if (CharacterBody == null)
			{
				CharacterBody = GetComponent<CharacterBody>();
			}
			stepUpDistance = Mathf.Clamp(stepUpDistance, 0.1f + CharacterBody.BodySize.x / 2f, CharacterBody.BodySize.y - CharacterBody.BodySize.x / 2f);
			CustomUtilities.SetPositive(ref maxGroundVelocityChange);
			CustomUtilities.SetPositive(ref inheritedGroundPlanarVelocityThreshold);
			CustomUtilities.SetPositive(ref inheritedGroundPlanarVelocityMultiplier);
			CustomUtilities.SetPositive(ref inheritedGroundVerticalVelocityThreshold);
			CustomUtilities.SetPositive(ref inheritedGroundVerticalVelocityMultiplier);
		}

		public void SetUpRootMotion(bool updateRootPosition = true, bool updateRootRotation = true)
		{
			UseRootMotion = true;
			UpdateRootPosition = updateRootPosition;
			UpdateRootRotation = updateRootRotation;
		}

		public void SetUpRootMotion(bool updateRootPosition = true, RootMotionVelocityType rootMotionVelocityType = RootMotionVelocityType.SetVelocity, bool updateRootRotation = true, RootMotionRotationType rootMotionRotationType = RootMotionRotationType.AddRotation)
		{
			UseRootMotion = true;
			UpdateRootPosition = updateRootPosition;
			base.rootMotionVelocityType = rootMotionVelocityType;
			UpdateRootRotation = updateRootRotation;
			base.rootMotionRotationType = rootMotionRotationType;
		}

		public Vector3 GetGroundPointVelocity(Vector3 point)
		{
			if (!IsGroundARigidbody)
			{
				return Vector3.zero;
			}
			if (!base.Is2D)
			{
				return characterCollisionInfo.groundRigidbody3D.GetPointVelocity(point);
			}
			return characterCollisionInfo.groundRigidbody2D.GetPointVelocity(point);
		}

		public string GetCharacterInfo()
		{
			if (!Application.isPlaying)
			{
				return "";
			}
			string text = "";
			for (int i = 0; i < Triggers.Count; i++)
			{
				GameObject gameObject = Triggers[i].gameObject;
				if (!(gameObject == null))
				{
					text = text + " - " + gameObject.name + "\n";
				}
			}
			return "Ground : \n" + "──────────────────\n" + "Is Grounded : " + IsGrounded + '\n' + "Is Stable : " + IsStable + '\n' + "Slope Angle : " + characterCollisionInfo.groundSlopeAngle + '\n' + "Is On Edge : " + characterCollisionInfo.isOnEdge + '\n' + "Edge Angle : " + characterCollisionInfo.edgeAngle + '\n' + "Object Name : " + ((characterCollisionInfo.groundObject != null) ? characterCollisionInfo.groundObject.name : " ---- ") + '\n' + "Layer : " + LayerMask.LayerToName(characterCollisionInfo.groundLayer) + '\n' + "Rigidbody Type: " + ((!(GroundRigidbodyComponent != null)) ? " ---- " : (GroundRigidbodyComponent.IsKinematic ? "Kinematic" : "Dynamic")) + '\n' + "Dynamic Ground : " + ((GroundRigidbodyComponent != null) ? "Yes" : "No") + "\n\n" + "Wall : \n" + "──────────────────\n" + "Wall Collision : " + characterCollisionInfo.wallCollision + '\n' + "Wall Angle : " + characterCollisionInfo.wallAngle + "\n\n" + "Head : \n" + "──────────────────\n" + "Head Collision : " + characterCollisionInfo.headCollision + '\n' + "Head Angle : " + characterCollisionInfo.headAngle + "\n\n" + "Triggers : \n" + "──────────────────\n" + "Current : " + ((CurrentTrigger.gameObject != null) ? CurrentTrigger.gameObject.name : " ---- ") + '\n' + text;
		}

		public Vector3 GetCenter(Vector3 position)
		{
			return position + CustomUtilities.Multiply(Up, BodySize.y / 2f);
		}

		public Vector3 GetTop(Vector3 position)
		{
			return position + CustomUtilities.Multiply(Up, BodySize.y - 0.005f);
		}

		public Vector3 GetBottom(Vector3 position)
		{
			return position + CustomUtilities.Multiply(Up, 0.005f);
		}

		public Vector3 GetTopCenter(Vector3 position)
		{
			return position + CustomUtilities.Multiply(Up, BodySize.y - BodySize.x / 2f);
		}

		public Vector3 GetTopCenter(Vector3 position, Vector2 bodySize)
		{
			return position + CustomUtilities.Multiply(Up, bodySize.y - bodySize.x / 2f);
		}

		public Vector3 GetBottomCenter(Vector3 position, float bottomOffset = 0f)
		{
			return position + CustomUtilities.Multiply(Up, BodySize.x / 2f + bottomOffset);
		}

		public Vector3 GetBottomCenter(Vector3 position, Vector2 bodySize)
		{
			return position + CustomUtilities.Multiply(Up, bodySize.x / 2f);
		}

		public Vector3 GetBottomCenterToTopCenter()
		{
			return CustomUtilities.Multiply(Up, BodySize.y - BodySize.x);
		}

		public Vector3 GetBottomCenterToTopCenter(Vector2 bodySize)
		{
			return CustomUtilities.Multiply(Up, bodySize.y - bodySize.x);
		}

		protected override void Awake()
		{
			base.Awake();
			CharacterBody = GetComponent<CharacterBody>();
			BodySize = CharacterBody.BodySize;
			CharacterCollisions = CharacterCollisions.CreateInstance(base.gameObject);
			RigidbodyComponent.IsKinematic = false;
			RigidbodyComponent.UseGravity = false;
			RigidbodyComponent.Mass = CharacterBody.Mass;
			RigidbodyComponent.LinearDrag = 0f;
			RigidbodyComponent.AngularDrag = 0f;
			RigidbodyComponent.Constraints = RigidbodyConstraints.FreezeRotation;
			if (base.Is2D)
			{
				groundTriggerCollider2D = base.gameObject.AddComponent<CircleCollider2D>();
				groundTriggerCollider2D.hideFlags = HideFlags.NotEditable;
				groundTriggerCollider2D.isTrigger = true;
				groundTriggerCollider2D.radius = BodySize.x / 2f;
				groundTriggerCollider2D.offset = Vector2.up * (BodySize.x / 2f - 0.05f);
				Physics2D.IgnoreCollision(GetComponent<CapsuleCollider2D>(), groundTriggerCollider2D, ignore: true);
			}
			else
			{
				groundTriggerCollider3D = base.gameObject.AddComponent<SphereCollider>();
				groundTriggerCollider3D.hideFlags = HideFlags.NotEditable;
				groundTriggerCollider3D.isTrigger = true;
				groundTriggerCollider3D.radius = BodySize.x / 2f;
				groundTriggerCollider3D.center = Vector3.up * (BodySize.x / 2f - 0.05f);
				Physics.IgnoreCollision(GetComponent<CapsuleCollider>(), groundTriggerCollider3D, ignore: true);
			}
			_removePenetrationAction = RemovePenetrationAction;
			_collisionHitFilter = CollisionHitFilter;
		}

		protected override void Start()
		{
			base.Start();
			HitInfoFilter hitInfoFilter = new HitInfoFilter(ObstaclesLayerMask, ignoreRigidbodies: false, ignoreTriggers: true, oneWayPlatformsLayerMask);
			CharacterCollisions.CheckOverlap(base.Position, 0f, in hitInfoFilter, _collisionHitFilter);
			if (forceGroundedAtStart && !alwaysNotGrounded)
			{
				ForceGrounded();
			}
			SetColliderSize();
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			base.OnTeleport += OnTeleportMethod;
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			base.OnTeleport -= OnTeleportMethod;
		}

		private void OnTeleportMethod(Vector3 position, Quaternion rotation)
		{
			if (resetVelocityOnTeleport)
			{
				base.Velocity = Vector3.zero;
			}
		}

		protected virtual void ApplyWeight(Vector3 contactPoint)
		{
			if (!applyWeightToGround || GroundObject == null || !CustomUtilities.BelongsToLayerMask(GroundObject.layer, applyWeightLayerMask))
			{
				return;
			}
			if (base.Is2D)
			{
				if (!(GroundCollider2D?.attachedRigidbody == null))
				{
					GroundCollider2D.attachedRigidbody.AddForceAtPosition(CustomUtilities.Multiply(-Up, CharacterBody.Mass, weightGravity), contactPoint);
				}
			}
			else if (!(GroundCollider3D?.attachedRigidbody == null))
			{
				GroundCollider3D.attachedRigidbody.AddForceAtPosition(CustomUtilities.Multiply(-Up, CharacterBody.Mass, weightGravity), contactPoint);
			}
		}

		private void HandleRotation()
		{
			if (constraintRotation)
			{
				if (upDirectionReference != null)
				{
					Vector3 position = base.Position;
					float floatValue = ((upDirectionReferenceMode == VerticalAlignmentSettings.VerticalReferenceMode.Towards) ? 1f : (-1f));
					Vector3 vectorValue = (base.Is2D ? Vector3.ProjectOnPlane(upDirectionReference.position - position, Vector3.forward) : (upDirectionReference.position - position));
					vectorValue.Normalize();
					constraintUpDirection = CustomUtilities.Multiply(vectorValue, floatValue);
				}
				Up = constraintUpDirection;
			}
		}

		private void GetContactsInformation()
		{
			bool wallCollision = characterCollisionInfo.wallCollision;
			bool headCollision = characterCollisionInfo.headCollision;
			GroundContacts.Clear();
			WallContacts.Clear();
			HeadContacts.Clear();
			for (int i = 0; i < Contacts.Count; i++)
			{
				Contact item = Contacts[i];
				float num = Vector3.Angle(Up, item.normal);
				if (CustomUtilities.isCloseTo(num, 90f, 10f))
				{
					WallContacts.Add(item);
				}
				if (num >= 100f)
				{
					HeadContacts.Add(item);
				}
				if (num <= 89f)
				{
					GroundContacts.Add(item);
				}
			}
			if (WallContacts.Count == 0)
			{
				characterCollisionInfo.ResetWallInfo();
			}
			else
			{
				Contact contact = WallContacts[0];
				characterCollisionInfo.SetWallInfo(in contact, this);
				if (!wallCollision)
				{
					this.OnWallHit?.Invoke(contact);
				}
			}
			if (HeadContacts.Count == 0)
			{
				characterCollisionInfo.ResetHeadInfo();
				return;
			}
			Contact contact2 = HeadContacts[0];
			characterCollisionInfo.SetHeadInfo(in contact2, this);
			if (!headCollision)
			{
				this.OnHeadHit?.Invoke(contact2);
			}
		}

		protected override void PreSimulationUpdate(float dt)
		{
			UpdateStabilityFlags();
			PhysicsComponent.ClearContacts();
			InputVelocity = base.Velocity;
			if (alwaysNotGrounded && WasGrounded)
			{
				ForceNotGrounded();
			}
			if (!base.IsKinematic)
			{
				ProcessVelocity(dt);
			}
			SetColliderSize();
			PreSimulationVelocity = base.Velocity;
			preSimulationPosition = base.Position;
			if (base.Is2D)
			{
				groundTriggerCollider2D.enabled = useGroundTrigger;
			}
			else
			{
				groundTriggerCollider3D.enabled = useGroundTrigger;
			}
		}

		protected override void PostSimulationUpdate(float dt)
		{
			HandleRotation();
			GetContactsInformation();
			PostSimulationVelocity = base.Velocity;
			ExternalVelocity = PostSimulationVelocity - PreSimulationVelocity;
			Vector3 preGroundProbingPosition = (PostGroundProbingPosition = base.Position);
			PreGroundProbingPosition = preGroundProbingPosition;
			if (!base.IsKinematic)
			{
				if (!IsStable)
				{
					Vector3 position2 = base.Position;
					UnstableProbeGround(ref position2, dt);
					SetDynamicGroundData(position2);
					base.Position = position2;
				}
				if (IsStable)
				{
					ProcessDynamicGroundMovement(dt);
					PreGroundProbingPosition = base.Position;
					ProbeGround(dt);
					PostGroundProbingPosition = base.Position;
				}
			}
			GroundProbingDisplacement = PostGroundProbingPosition - PreGroundProbingPosition;
			PostSimulationVelocityUpdate();
			UpdateTimers(dt);
			UpdatePostSimulationFlags();
		}

		private void UpdateStabilityFlags()
		{
			HasBecomeGrounded = IsGrounded && !WasGrounded;
			HasBecomeStable = IsStable && !WasStable;
			HasBecomeNotGrounded = !IsGrounded && WasGrounded;
			HasBecomeUnstable = !IsStable && WasStable;
			WasGrounded = IsGrounded;
			WasStable = IsStable;
		}

		private void UpdatePostSimulationFlags()
		{
			Vector3 localInputVelocity = LocalInputVelocity;
			if (HasBecomeGrounded)
			{
				this.OnGroundedStateEnter?.Invoke(localInputVelocity);
			}
			if (HasBecomeNotGrounded)
			{
				this.OnGroundedStateExit?.Invoke();
			}
			if (HasBecomeStable)
			{
				this.OnStableStateEnter?.Invoke(localInputVelocity);
			}
			if (HasBecomeUnstable)
			{
				this.OnStableStateExit?.Invoke();
			}
			if (forceNotGroundedFrames != 0)
			{
				forceNotGroundedFrames--;
			}
			forceNotGroundedFlag = false;
			inheritVelocityFlag = false;
		}

		private void UpdateTimers(float dt)
		{
			if (IsStable)
			{
				StableElapsedTime += dt;
				UnstableElapsedTime = 0f;
			}
			else
			{
				StableElapsedTime = 0f;
				UnstableElapsedTime += dt;
			}
			if (IsGrounded)
			{
				NotGroundedTime = 0f;
				GroundedTime += dt;
			}
			else
			{
				NotGroundedTime += dt;
				GroundedTime = 0f;
			}
		}

		private bool IsAllowedToFollowRigidbodyReference()
		{
			if (!supportDynamicGround)
			{
				return false;
			}
			if (!IsStable)
			{
				return false;
			}
			if (GroundObject == null)
			{
				return false;
			}
			if (!CustomUtilities.BelongsToLayerMask(GroundObject.layer, dynamicGroundLayerMask))
			{
				return false;
			}
			if (base.Is2D)
			{
				if (characterCollisionInfo.groundRigidbody2D == null)
				{
					return false;
				}
				if (characterCollisionInfo.groundRigidbody2D.bodyType == RigidbodyType2D.Static)
				{
					return false;
				}
			}
			else if (characterCollisionInfo.groundRigidbody3D == null)
			{
				return false;
			}
			return true;
		}

		private void SetDynamicGroundData(Vector3 position)
		{
			if (IsAllowedToFollowRigidbodyReference())
			{
				preSimulationGroundRotation = GroundRotation;
				groundToCharacter = position - GroundPosition;
			}
		}

		private void ApplyGroundMovement(ref Vector3 position, ref Quaternion rotation, float dt)
		{
			Quaternion quaternion = GroundRotation * Quaternion.Inverse(preSimulationGroundRotation);
			position = GroundPosition + quaternion * groundToCharacter;
			if (!base.Is2D && rotateForwardDirection)
			{
				Vector3 vector = quaternion * Forward;
				vector = Vector3.ProjectOnPlane(vector, Up);
				vector.Normalize();
				rotation = Quaternion.LookRotation(vector, Up);
			}
		}

		private void UpdateGroundVelocity()
		{
			PreviousGroundVelocity = GroundVelocity;
			GroundVelocity = GetGroundPointVelocity(GroundContactPoint);
		}

		private void ProcessDynamicGroundMovement(float dt)
		{
			if (!IsAllowedToFollowRigidbodyReference())
			{
				return;
			}
			IgnoreGroundResponse();
			Vector3 position = base.Position;
			Quaternion rotation = base.Rotation;
			ApplyGroundMovement(ref position, ref rotation, dt);
			if (!WasGrounded)
			{
				Vector3 vector = Vector3.Project(base.PlanarVelocity, GetGroundPointVelocity(GroundContactPoint));
				base.PlanarVelocity -= vector;
			}
			if (!IsGroundAOneWayPlatform && GroundDeltaVelocity.magnitude > maxGroundVelocityChange)
			{
				if (Vector3.Angle(Vector3.Normalize(GroundVelocity), Up) < 45f)
				{
					ForceNotGrounded();
				}
				Vector3 vectorValue = (base.Velocity = PreviousGroundVelocity);
				base.Position += CustomUtilities.Multiply(vectorValue, dt);
				base.Rotation = rotation;
				return;
			}
			base.Position = position;
			Vector3 position2 = base.Position;
			bool num = RemovePenetration(ref position2);
			base.Position = position2;
			if (!num)
			{
				base.Rotation = rotation;
			}
		}

		private void ProcessInheritedVelocity()
		{
			if (forceNotGroundedFlag && inheritVelocityFlag)
			{
				Vector3 vector = base.transform.InverseTransformVectorUnscaled(GroundVelocity);
				Vector3 vectorValue = Vector3.ProjectOnPlane(GroundVelocity, Up);
				Vector3 vectorValue2 = Vector3.Project(GroundVelocity, Up);
				Vector3 zero = Vector3.zero;
				if (vectorValue.magnitude >= inheritedGroundPlanarVelocityThreshold)
				{
					zero += CustomUtilities.Multiply(vectorValue, inheritedGroundPlanarVelocityMultiplier);
				}
				if (vectorValue2.magnitude >= inheritedGroundVerticalVelocityThreshold && base.LocalVelocity.y > 0f - vector.y)
				{
					zero += CustomUtilities.Multiply(vectorValue2, inheritedGroundVerticalVelocityMultiplier);
				}
				base.Velocity += zero;
				GroundVelocity = Vector3.zero;
				PreviousGroundVelocity = Vector3.zero;
			}
		}

		protected bool RemovePenetration(ref Vector3 position)
		{
			int num = 0;
			bool flag = false;
			bool flag2 = false;
			Quaternion rotation = base.Rotation;
			do
			{
				flag = ColliderComponent.ComputePenetration(ref position, ref rotation, _removePenetrationAction);
				flag2 = flag2 || flag;
				num++;
			}
			while (num < 2 && flag);
			return flag2;
		}

		private void RemovePenetrationAction(ref Vector3 bodyPosition, ref Quaternion bodyRotation, Transform otherColliderTransform, Vector3 penetrationDirection, float penetrationDistance)
		{
			if (CustomUtilities.BelongsToLayerMask(otherColliderTransform.gameObject.layer, oneWayPlatformsLayerMask))
			{
				PhysicsComponent.IgnoreCollision(otherColliderTransform, ignore: true);
				return;
			}
			Vector3 vector = penetrationDirection * penetrationDistance;
			if (IsStable)
			{
				vector = Vector3.ProjectOnPlane(vector, GroundStableNormal).normalized * penetrationDistance;
			}
			CustomUtilities.AddMagnitude(ref vector, 0.005f);
			bodyPosition += vector;
		}

		private void PostSimulationVelocityUpdate()
		{
			if (IsStable)
			{
				switch (stablePostSimulationVelocity)
				{
				case CharacterVelocityMode.UseInputVelocity:
					base.Velocity = InputVelocity;
					break;
				case CharacterVelocityMode.UsePreSimulationVelocity:
					base.Velocity = PreSimulationVelocity;
					if (WasStable)
					{
						base.PlanarVelocity = CustomUtilities.Multiply(Vector3.Normalize(base.PlanarVelocity), base.Velocity.magnitude);
					}
					break;
				case CharacterVelocityMode.UsePostSimulationVelocity:
					if (WasStable)
					{
						base.PlanarVelocity = CustomUtilities.Multiply(Vector3.Normalize(base.PlanarVelocity), base.Velocity.magnitude);
					}
					break;
				}
				UpdateGroundVelocity();
			}
			else
			{
				switch (unstablePostSimulationVelocity)
				{
				case CharacterVelocityMode.UseInputVelocity:
					base.Velocity = InputVelocity;
					break;
				case CharacterVelocityMode.UsePreSimulationVelocity:
					base.Velocity = PreSimulationVelocity;
					break;
				}
			}
			if (IsGrounded)
			{
				LastGroundedVelocity = base.Velocity;
			}
		}

		private bool IgnoreGroundResponse()
		{
			for (int i = 0; i < Contacts.Count; i++)
			{
				Contact contact = Contacts[i];
				if (!contact.isRigidbody || !contact.isKinematicRigidbody)
				{
					continue;
				}
				if (base.Is2D)
				{
					if (contact.collider2D.attachedRigidbody == GroundRigidbody2D)
					{
						base.Velocity = PreSimulationVelocity;
						return true;
					}
				}
				else if (contact.collider3D.attachedRigidbody == GroundRigidbody3D)
				{
					base.Velocity = PreSimulationVelocity;
					return true;
				}
			}
			return false;
		}

		private void ProcessVelocity(float dt)
		{
			Vector3 position = base.Position;
			if (IsStable)
			{
				ProcessStableMovement(dt, ref position);
			}
			else
			{
				ProcessUnstableMovement(dt, ref position);
			}
			base.Velocity = (position - base.Position) / dt;
		}

		private void ProcessStableMovement(float dt, ref Vector3 position)
		{
			ApplyWeight(GroundContactPoint);
			base.VerticalVelocity = Vector3.zero;
			Vector3 displacement = CustomUtilities.ProjectOnTangent(CustomUtilities.Multiply(base.Velocity, dt), GroundStableNormal, Up);
			StableCollideAndSlide(ref position, displacement, useFullBody: false);
			SetDynamicGroundData(position);
			if (!IsStable)
			{
				CurrentTerrain = null;
				groundRigidbodyComponent = null;
			}
		}

		private void ProcessUnstableMovement(float dt, ref Vector3 position)
		{
			ProcessInheritedVelocity();
			Vector3 displacement = CustomUtilities.Multiply(base.Velocity, dt);
			UnstableCollideAndSlide(ref position, displacement, dt);
		}

		protected override void UpdateDynamicRootMotionPosition()
		{
			Vector3 vector = base.Animator.deltaPosition / Time.deltaTime;
			switch (rootMotionVelocityType)
			{
			case RootMotionVelocityType.SetVelocity:
				base.Velocity = vector;
				break;
			case RootMotionVelocityType.SetPlanarVelocity:
				base.PlanarVelocity = vector;
				break;
			case RootMotionVelocityType.SetVerticalVelocity:
				base.VerticalVelocity = vector;
				break;
			}
		}

		private Vector3 GetSizeOffsetPosition(Vector2 size, float heightAnchorRatio)
		{
			float floatValue = (BodySize.y - size.y) * heightAnchorRatio;
			return base.Position + CustomUtilities.Multiply(Up, floatValue);
		}

		public void SetSize(Vector2 size, SizeReferenceType sizeReferenceType)
		{
			float heightAnchorRatio = 0f;
			switch (sizeReferenceType)
			{
			case SizeReferenceType.Top:
				heightAnchorRatio = 1f;
				break;
			case SizeReferenceType.Center:
				heightAnchorRatio = 0.5f;
				break;
			}
			base.Position = GetSizeOffsetPosition(size, heightAnchorRatio);
			BodySize = size;
			SetColliderSize();
		}

		public bool CheckAndSetSize(Vector2 size, SizeReferenceType sizeReferenceType = SizeReferenceType.Bottom)
		{
			if (!CheckSize(base.Position, size))
			{
				return false;
			}
			SetSize(size, sizeReferenceType);
			return true;
		}

		public bool CheckSize(Vector3 position, Vector2 size, in HitInfoFilter filter)
		{
			return CharacterCollisions.CheckBodySize(size, position, in filter, _collisionHitFilter);
		}

		public bool CheckSize(Vector3 position, Vector2 size)
		{
			HitInfoFilter hitInfoFilter = new HitInfoFilter(ObstaclesWithoutOWPLayerMask, ignoreRigidbodies: true, ignoreTriggers: true);
			return CharacterCollisions.CheckBodySize(size, position, in hitInfoFilter, _collisionHitFilter);
		}

		public bool CheckSize(Vector2 size, in HitInfoFilter filter)
		{
			return CharacterCollisions.CheckBodySize(size, base.Position, in filter, _collisionHitFilter);
		}

		public bool CheckSize(Vector2 size)
		{
			HitInfoFilter hitInfoFilter = new HitInfoFilter(ObstaclesWithoutOWPLayerMask, ignoreRigidbodies: true, ignoreTriggers: true);
			return CharacterCollisions.CheckBodySize(size, base.Position, in hitInfoFilter, _collisionHitFilter);
		}

		[Obsolete]
		public bool SetBodySize(Vector2 size)
		{
			HitInfoFilter hitInfoFilter = new HitInfoFilter(ObstaclesWithoutOWPLayerMask, ignoreRigidbodies: true, ignoreTriggers: true);
			if (!CharacterCollisions.CheckBodySize(size, base.Position, in hitInfoFilter, _collisionHitFilter))
			{
				return false;
			}
			SetSize(size, SizeReferenceType.Bottom);
			return true;
		}

		public bool CheckAndInterpolateSize(Vector2 targetSize, float lerpFactor, SizeReferenceType sizeReferenceType)
		{
			bool num = CheckSize(targetSize);
			if (num)
			{
				Vector2 size = Vector2.Lerp(BodySize, targetSize, lerpFactor);
				SetSize(size, sizeReferenceType);
			}
			return num;
		}

		public bool CheckAndInterpolateHeight(float targetHeight, float lerpFactor, SizeReferenceType sizeReferenceType)
		{
			return CheckAndInterpolateSize(new Vector2(DefaultBodySize.x, targetHeight), lerpFactor, SizeReferenceType.Bottom);
		}

		private void SetColliderSize()
		{
			float num = (IsStable ? Mathf.Max(StepOffset, 0.1f) : 0f);
			float num2 = BodySize.x / 2f;
			float num3 = BodySize.y - num;
			ColliderComponent.Size = new Vector2(2f * num2, num3);
			ColliderComponent.Offset = CustomUtilities.Multiply(Vector2.up, num + num3 / 2f);
		}

		public void SweepAndTeleport(Vector3 destination)
		{
			SweepAndTeleport(destination, new HitInfoFilter(ObstaclesWithoutOWPLayerMask, ignoreRigidbodies: false, ignoreTriggers: true));
		}

		public void SweepAndTeleport(Vector3 destination, in HitInfoFilter filter)
		{
			Vector3 displacement = destination - base.Position;
			CollisionInfo collisionInfo = CharacterCollisions.CastBody(base.Position, displacement, 0f, in filter, allowOverlaps: false, _collisionHitFilter);
			base.Position += collisionInfo.displacement;
		}

		public void ForceGrounded()
		{
			if (CanEnterGroundedState)
			{
				HitInfoFilter hitInfoFilter = new HitInfoFilter(ObstaclesLayerMask, ignoreRigidbodies: false, ignoreTriggers: true, oneWayPlatformsLayerMask);
				CollisionInfo collisionInfo = CharacterCollisions.CheckForGround(base.Position, BodySize.y * 0.8f, stepDownDistance, in hitInfoFilter, _collisionHitFilter);
				if (collisionInfo.hitInfo.hit && Vector3.Angle(Up, GetGroundSlopeNormal(collisionInfo)) <= slopeLimit)
				{
					base.Position += collisionInfo.displacement;
					SetGroundInfo(collisionInfo);
					SetDynamicGroundData(base.Position);
				}
			}
		}

		public Vector3 GetGroundSlopeNormal(CollisionInfo collisionInfo)
		{
			if (IsOnTerrain)
			{
				return collisionInfo.hitInfo.normal;
			}
			float num = Vector3.Angle(Up, collisionInfo.hitInfo.normal);
			if (collisionInfo.isAnEdge)
			{
				if (num < slopeLimit && collisionInfo.edgeUpperSlopeAngle <= slopeLimit && collisionInfo.edgeLowerSlopeAngle <= slopeLimit)
				{
					return Up;
				}
				if (collisionInfo.edgeUpperSlopeAngle <= slopeLimit)
				{
					return collisionInfo.edgeUpperNormal;
				}
				if (collisionInfo.edgeLowerSlopeAngle <= slopeLimit)
				{
					return collisionInfo.edgeLowerNormal;
				}
				return collisionInfo.hitInfo.normal;
			}
			return collisionInfo.hitInfo.normal;
		}

		private bool EvaluateGroundStability(Transform groundTransform)
		{
			if (!CustomUtilities.BelongsToLayerMask(groundTransform.gameObject.layer, stableLayerMask))
			{
				return false;
			}
			if (!allowCharactersAsStableSurfaces && groundTransform.TryGetComponent<CharacterActor>(out var _))
			{
				return false;
			}
			return true;
		}

		private void ProbeGround(float dt)
		{
			Vector3 position = base.Position;
			HitInfoFilter hitInfoFilter = new HitInfoFilter(ObstaclesLayerMask, ignoreRigidbodies: false, ignoreTriggers: true);
			HitInfoFilter hitInfoFilter2 = new HitInfoFilter(ObstaclesWithoutOWPLayerMask, ignoreRigidbodies: false, ignoreTriggers: true);
			CollisionInfo collisionInfo = CharacterCollisions.CheckForGround(position, StepOffset, stepDownDistance, in hitInfoFilter, _collisionHitFilter);
			if (!collisionInfo.hitInfo.hit)
			{
				ForceNotGrounded();
				ProcessInheritedVelocity();
				return;
			}
			bool flag = Vector3.Angle(Up, GetGroundSlopeNormal(collisionInfo)) <= slopeLimit && EvaluateGroundStability(collisionInfo.hitInfo.transform);
			position += collisionInfo.displacement;
			if (edgeCompensation && IsAStableEdge(collisionInfo))
			{
				Vector3 vector = Vector3.Project(collisionInfo.hitInfo.point - position, Up);
				position += vector;
			}
			float y = base.transform.InverseTransformDirection(position - base.Position).y;
			bool flag2 = false;
			if (y > 0.005f)
			{
				flag2 = CharacterCollisions.CheckOverlap(position, StepOffset, in hitInfoFilter2, _collisionHitFilter);
			}
			if ((0u | ((!flag) ? 1u : 0u) | (flag2 ? 1u : 0u)) != 0)
			{
				if (preventBadSteps && WasGrounded)
				{
					Vector3 vector2 = CustomUtilities.Multiply(GroundVelocity, dt);
					Vector3 vector3 = preSimulationPosition + vector2;
					position = vector3;
					Vector3 displacement = CustomUtilities.ProjectOnTangent(CustomUtilities.Multiply(InputVelocity, dt), GroundStableNormal, Up);
					StableCollideAndSlide(ref position, displacement, useFullBody: true);
					if (base.Is2D)
					{
						base.Velocity = (position - vector3) / dt;
					}
				}
				collisionInfo = CharacterCollisions.CheckForGroundRay(position, in hitInfoFilter, _collisionHitFilter);
				SetGroundInfo(collisionInfo);
			}
			else
			{
				SetGroundInfo(collisionInfo);
			}
			if (IsStable)
			{
				base.Position = position;
			}
		}

		public void ForceNotGrounded(int ignoreGroundContactFrames = 3, bool? inheritGroundVelocityOverride = null)
		{
			forceNotGroundedFrames = ignoreGroundContactFrames;
			if (inheritGroundVelocityOverride.HasValue)
			{
				inheritVelocityFlag = inheritGroundVelocityOverride.Value;
			}
			else
			{
				inheritVelocityFlag = IsAllowedToFollowRigidbodyReference();
			}
			UpdateStabilityFlags();
			ResetGroundInfo();
			forceNotGroundedFlag = true;
		}

		private bool IsAStableEdge(CollisionInfo collisionInfo)
		{
			if (collisionInfo.isAnEdge)
			{
				return collisionInfo.edgeUpperSlopeAngle <= slopeLimit;
			}
			return false;
		}

		private bool CollisionHitFilter(Transform hitTransform)
		{
			GameObject gameObject = hitTransform.gameObject;
			if (!CheckOneWayPlatformLayerMask(gameObject) && !CharacterCollisions.PhysicsComponent.CheckCollisionsWith(gameObject))
			{
				return false;
			}
			return true;
		}

		protected void StableCollideAndSlide(ref Vector3 position, Vector3 displacement, bool useFullBody)
		{
			Vector3 groundPlaneNormal = GroundStableNormal;
			Vector3 slidingPlaneNormal = Vector3.zero;
			HitInfoFilter hitInfoFilter = new HitInfoFilter(ObstaclesLayerMask, ignoreRigidbodies: false, ignoreTriggers: true, oneWayPlatformsLayerMask);
			int num = 0;
			while (num < 3)
			{
				num++;
				CollisionInfo collisionInfo = CharacterCollisions.CastBody(position, displacement, useFullBody ? 0f : StepOffset, in hitInfoFilter, allowOverlaps: false, _collisionHitFilter);
				if (collisionInfo.hitInfo.hit)
				{
					if (CheckOneWayPlatformLayerMask(collisionInfo))
					{
						PhysicsComponent.IgnoreCollision(in collisionInfo.hitInfo, ignore: true);
						position += displacement;
						break;
					}
					if (canPushDynamicRigidbodies && collisionInfo.hitInfo.IsRigidbody && collisionInfo.hitInfo.IsDynamicRigidbody)
					{
						bool flag = false;
						if (base.Is2D)
						{
							if (GroundCollider2D != null && GroundCollider2D.attachedRigidbody != null && GroundCollider2D.attachedRigidbody != collisionInfo.hitInfo.rigidbody2D)
							{
								flag = true;
							}
						}
						else if (GroundCollider3D != null && GroundCollider3D.attachedRigidbody != null && GroundCollider3D.attachedRigidbody == collisionInfo.hitInfo.rigidbody3D)
						{
							flag = true;
						}
						if (!flag && CustomUtilities.BelongsToLayerMask(collisionInfo.hitInfo.layer, pushableRigidbodyLayerMask))
						{
							position += displacement;
							break;
						}
					}
					if (slideOnWalls && !base.Is2D)
					{
						position += collisionInfo.displacement;
						displacement -= collisionInfo.displacement;
						UpdateCollideAndSlideData(collisionInfo, ref slidingPlaneNormal, ref groundPlaneNormal, ref displacement);
						continue;
					}
					if (!WallCollision)
					{
						position += collisionInfo.displacement;
					}
					break;
				}
				position += displacement;
				break;
			}
		}

		public bool CheckOneWayPlatformLayerMask(GameObject gameObject)
		{
			return CustomUtilities.BelongsToLayerMask(gameObject.layer, oneWayPlatformsLayerMask);
		}

		public bool CheckOneWayPlatformLayerMask(CollisionInfo collisionInfo)
		{
			return CustomUtilities.BelongsToLayerMask(collisionInfo.hitInfo.layer, oneWayPlatformsLayerMask);
		}

		public bool CheckOneWayPlatformCollision(Vector3 contactPoint, Vector3 characterPosition)
		{
			Vector3 vector = GetBottomCenter(characterPosition) - contactPoint;
			return (base.Is2D ? Vector2.Angle(Up, vector) : Vector3.Angle(Up, vector)) <= 0.5f * oneWayPlatformsValidArc;
		}

		protected void UnstableCollideAndSlide(ref Vector3 position, Vector3 displacement, float dt)
		{
			HitInfoFilter hitInfoFilter = new HitInfoFilter(ObstaclesLayerMask, forceNotGroundedFrames != 0, ignoreTriggers: true, oneWayPlatformsLayerMask);
			Vector3 vector = Vector3.zero;
			Vector3 vector2 = Vector3.zero;
			int num = 0;
			while (num < 3 || displacement == Vector3.zero)
			{
				num++;
				CollisionInfo collisionInfo = CharacterCollisions.CastBody(position, displacement, 0f, in hitInfoFilter, allowOverlaps: false, _collisionHitFilter);
				if (collisionInfo.hitInfo.hit)
				{
					float num2 = Vector3.Angle(Up, collisionInfo.hitInfo.normal);
					bool flag = num2 <= slopeLimit;
					bool flag2 = num2 < 90f;
					if (CheckOneWayPlatformLayerMask(collisionInfo))
					{
						PhysicsComponent.IgnoreCollision(in collisionInfo.hitInfo, ignore: true);
						Vector3 characterPosition = position + collisionInfo.displacement;
						if (CheckOneWayPlatformCollision(collisionInfo.hitInfo.point, characterPosition))
						{
							position += collisionInfo.displacement;
							SetGroundInfo(collisionInfo);
							SetDynamicGroundData(position);
							base.Position = position;
							displacement -= collisionInfo.displacement;
							displacement = Vector3.ProjectOnPlane(displacement, collisionInfo.hitInfo.normal);
							position += displacement;
						}
						else
						{
							position += displacement;
						}
						break;
					}
					if (collisionInfo.hitInfo.IsRigidbody)
					{
						if (collisionInfo.hitInfo.IsKinematicRigidbody)
						{
							position += displacement;
							break;
						}
						if (canPushDynamicRigidbodies && collisionInfo.hitInfo.IsDynamicRigidbody && CustomUtilities.BelongsToLayerMask(collisionInfo.hitInfo.layer, pushableRigidbodyLayerMask))
						{
							position += displacement;
							break;
						}
					}
					position += collisionInfo.displacement;
					displacement -= collisionInfo.displacement;
					if (vector == Vector3.zero)
					{
						displacement = ((!(preventUnstableClimbing && flag2) || flag) ? Vector3.ProjectOnPlane(displacement, collisionInfo.hitInfo.normal) : ((!(base.transform.InverseTransformVectorUnscaled(Vector3.Project(displacement, Up)).y > 0f)) ? Vector3.ProjectOnPlane(displacement, collisionInfo.hitInfo.normal) : Vector3.Project(displacement, Up)));
						vector = collisionInfo.hitInfo.normal;
					}
					else if (vector2 == Vector3.zero)
					{
						vector2 = collisionInfo.hitInfo.normal;
						Vector3 onNormal = Vector3.Cross(vector, vector2);
						onNormal.Normalize();
						displacement = Vector3.Project(displacement, onNormal);
					}
					continue;
				}
				position += displacement;
				break;
			}
		}

		private void UnstableProbeGround(ref Vector3 position, float dt)
		{
			if (!CanEnterGroundedState)
			{
				unstableGroundContactTime = 0f;
				PredictedGround = null;
				PredictedGroundDistance = 0f;
				ResetGroundInfo();
				return;
			}
			HitInfoFilter hitInfoFilter = new HitInfoFilter(ObstaclesWithoutOWPLayerMask, ignoreRigidbodies: false, ignoreTriggers: true);
			CollisionInfo collisionInfo = CharacterCollisions.CheckForGround(position, StepOffset, 40f, in hitInfoFilter, _collisionHitFilter);
			if (collisionInfo.hitInfo.hit)
			{
				PredictedGround = collisionInfo.hitInfo.transform.gameObject;
				PredictedGroundDistance = collisionInfo.displacement.magnitude;
				if (CheckOneWayPlatformLayerMask(collisionInfo))
				{
					PhysicsComponent.IgnoreCollision(in collisionInfo.hitInfo, ignore: true);
				}
				if (PredictedGroundDistance <= 0.1f)
				{
					unstableGroundContactTime += dt;
					if (CanPerformUnstableGroundDetection(in collisionInfo.hitInfo))
					{
						position += collisionInfo.displacement;
						SetGroundInfo(collisionInfo);
					}
				}
				else
				{
					unstableGroundContactTime = 0f;
					ResetGroundInfo();
				}
			}
			else
			{
				unstableGroundContactTime = 0f;
				PredictedGround = null;
				PredictedGroundDistance = 0f;
				ResetGroundInfo();
			}
			GroundProbingDisplacement = Vector3.zero;
		}

		protected bool CanPerformUnstableGroundDetection(in HitInfo hitInfo)
		{
			if (detectGroundWhileAscending)
			{
				return true;
			}
			if (!(base.LocalVelocity.y <= 0f) && !(unstableGroundContactTime >= 0.25f))
			{
				return hitInfo.IsRigidbody;
			}
			return true;
		}

		private void SetGroundInfo(CollisionInfo collisionInfo)
		{
			ProcessNewGround(collisionInfo.hitInfo.transform);
			characterCollisionInfo.SetGroundInfo(in collisionInfo, this);
			SetStableState(collisionInfo);
		}

		private void SetStableState(CollisionInfo collisionInfo)
		{
			IsGrounded = collisionInfo.hitInfo.hit;
			IsStable = false;
			if (IsGrounded && EvaluateGroundStability(characterCollisionInfo.groundObject.transform))
			{
				if (WasStable)
				{
					IsStable = characterCollisionInfo.groundSlopeAngle <= slopeLimit;
					return;
				}
				if (useStableEdgeWhenLanding)
				{
					IsStable = characterCollisionInfo.groundSlopeAngle <= slopeLimit;
					return;
				}
				float num = Vector3.Angle(Up, characterCollisionInfo.groundContactNormal);
				IsStable = num <= slopeLimit;
			}
		}

		private void ResetGroundInfo()
		{
			characterCollisionInfo.ResetGroundInfo();
			IsGrounded = false;
			IsStable = false;
		}

		private void ProcessNewGround(Transform newGroundTransform)
		{
			if (newGroundTransform != GroundTransform)
			{
				CurrentTerrain = terrains.GetOrRegisterValue(newGroundTransform);
				groundRigidbodyComponent = groundRigidbodyComponents.GetOrRegisterValue(newGroundTransform);
				this.OnNewGroundEnter?.Invoke();
			}
		}

		private bool UpdateCollideAndSlideData(CollisionInfo collisionInfo, ref Vector3 slidingPlaneNormal, ref Vector3 groundPlaneNormal, ref Vector3 displacement)
		{
			Vector3 normal = collisionInfo.hitInfo.normal;
			if (collisionInfo.contactSlopeAngle > slopeLimit || !EvaluateGroundStability(collisionInfo.hitInfo.transform))
			{
				if (slidingPlaneNormal != Vector3.zero)
				{
					if (Vector3.Dot(normal, slidingPlaneNormal) > 0f)
					{
						displacement = CustomUtilities.DeflectVector(displacement, groundPlaneNormal, normal);
					}
					else
					{
						displacement = Vector3.zero;
					}
				}
				else
				{
					displacement = CustomUtilities.DeflectVector(displacement, groundPlaneNormal, normal);
				}
				slidingPlaneNormal = normal;
			}
			else
			{
				displacement = CustomUtilities.ProjectOnTangent(displacement, normal, Up);
				groundPlaneNormal = normal;
				slidingPlaneNormal = Vector3.zero;
			}
			return displacement == Vector3.zero;
		}

		private void OnDrawGizmos()
		{
			if (CharacterBody == null)
			{
				CharacterBody = GetComponent<CharacterBody>();
			}
			Gizmos.color = new Color(1f, 1f, 1f, 0.2f);
			Gizmos.matrix = base.transform.localToWorldMatrix;
			Gizmos.DrawWireCube(CustomUtilities.Multiply(Vector3.up, stepUpDistance), new Vector3(1.1f * CharacterBody.BodySize.x, 0.02f, 1.1f * CharacterBody.BodySize.x));
			Gizmos.matrix = Matrix4x4.identity;
		}
	}
}
