using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRTK
{
	[AddComponentMenu("VRTK/Scripts/Presence/VRTK_BodyPhysics")]
	public class VRTK_BodyPhysics : VRTK_DestinationMarker
	{
		public enum FallingRestrictors
		{
			NoRestriction = 0,
			LeftController = 1,
			RightController = 2,
			EitherController = 3,
			BothControllers = 4,
			AlwaysRestrict = 5
		}

		[Header("Body Collision Settings")]
		[Tooltip("If checked then the body collider and rigidbody will be used to check for rigidbody collisions.")]
		public bool enableBodyCollisions = true;

		[Tooltip("If this is checked then any items that are grabbed with the controller will not collide with the body collider. This is very useful if the user is required to grab and wield objects because if the collider was active they would bounce off the collider.")]
		public bool ignoreGrabbedCollisions = true;

		[Tooltip("An array of GameObjects that will not collide with the body collider.")]
		public GameObject[] ignoreCollisionsWith;

		[Tooltip("The collider which is created for the user is set at a height from the user's headset position. If the collider is required to be lower to allow for room between the play area collider and the headset then this offset value will shorten the height of the generated collider.")]
		public float headsetYOffset = 0.2f;

		[Tooltip("The amount of movement of the headset between the headset's current position and the current standing position to determine if the user is walking in play space and to ignore the body physics collisions if the movement delta is above this threshold.")]
		public float movementThreshold = 0.0015f;

		[Tooltip("The amount of movement of the play area between the play area's current position and the previous position to determine if the user is moving play space.")]
		public float playAreaMovementThreshold = 0.00075f;

		[Tooltip("The maximum number of samples to collect of headset position before determining if the current standing position within the play space has changed.")]
		public int standingHistorySamples = 5;

		[Tooltip("The `y` distance between the headset and the object being leaned over, if object being leaned over is taller than this threshold then the current standing position won't be updated.")]
		public float leanYThreshold = 0.5f;

		[Header("Step Settings")]
		[Tooltip("The maximum height to consider when checking if an object can be stepped upon to.")]
		public float stepUpYOffset = 0.15f;

		[Tooltip("The width/depth of the foot collider in relation to the radius of the body collider.")]
		[Range(0.1f, 0.9f)]
		public float stepThicknessMultiplier = 0.5f;

		[Tooltip("The distance between the current play area Y position and the new stepped up Y position to consider a valid step up. A higher number can help with juddering on slopes or small increases in collider heights.")]
		public float stepDropThreshold = 0.08f;

		[Header("Snap To Floor Settings")]
		[Tooltip("A custom raycaster to use when raycasting to find floors.")]
		public VRTK_CustomRaycast customRaycast;

		[Tooltip("A check to see if the drop to nearest floor should take place. If the selected restrictor is still over the current floor then the drop to nearest floor will not occur. Works well for being able to lean over ledges and look down. Only works for falling down not teleporting up.")]
		public FallingRestrictors fallRestriction;

		[Tooltip("When the `y` distance between the floor and the headset exceeds this distance and `Enable Body Collisions` is true then the rigidbody gravity will be used instead of teleport to drop to nearest floor.")]
		public float gravityFallYThreshold = 1f;

		[Tooltip("The `y` distance between the floor and the headset that must change before a fade transition is initiated. If the new user location is at a higher distance than the threshold then the headset blink transition will activate on teleport. If the new user location is within the threshold then no blink transition will happen, which is useful for walking up slopes, meshes and terrains to prevent constant blinking.")]
		public float blinkYThreshold = 0.15f;

		[Tooltip("The amount the `y` position needs to change by between the current floor `y` position and the previous floor `y` position before a change in floor height is considered to have occurred. A higher value here will mean that a `Drop To Floor` will be less likely to happen if the `y` of the floor beneath the user hasn't changed as much as the given threshold.")]
		public float floorHeightTolerance = 0.001f;

		[Range(1f, 10f)]
		[Tooltip("The amount of rounding on the play area Y position to be applied when checking if falling is occuring.")]
		public int fallCheckPrecision = 5;

		[Header("Custom Settings")]
		[Tooltip("The VRTK Teleport script to use when snapping to floor. If this is left blank then a Teleport script will need to be applied to the same GameObject.")]
		public VRTK_BasicTeleport teleporter;

		[Tooltip("A custom Rigidbody to apply to the play area. If one is not provided, then if an existing rigidbody is found on the play area GameObject it will be used, otherwise a default one will be created.")]
		public Rigidbody customPlayAreaRigidbody;

		[Tooltip("A GameObject to represent a custom body collider container. It should contain a collider component that will be used for detecting body collisions. If one isn't provided then it will be auto generated.")]
		public GameObject customBodyColliderContainer;

		[Tooltip("A GameObject to represent a custom foot collider container. It should contain a collider component that will be used for detecting step collisions. If one isn't provided then it will be auto generated.")]
		public GameObject customFootColliderContainer;

		protected Transform playArea;

		protected Transform headset;

		protected Rigidbody bodyRigidbody;

		protected GameObject bodyColliderContainer;

		protected GameObject footColliderContainer;

		protected CapsuleCollider bodyCollider;

		protected CapsuleCollider footCollider;

		protected VRTK_CollisionTracker collisionTracker;

		protected bool currentBodyCollisionsSetting;

		protected GameObject currentCollidingObject;

		protected GameObject currentValidFloorObject;

		protected float lastFrameFloorY;

		protected float hitFloorYDelta;

		protected bool initialFloorDrop;

		protected bool resetPhysicsAfterTeleport;

		protected bool storedCurrentPhysics;

		protected bool retogglePhysicsOnCanFall;

		protected bool storedRetogglePhysics;

		protected Vector3 lastPlayAreaPosition = Vector3.zero;

		protected Vector2 currentStandingPosition;

		protected List<Vector2> standingPositionHistory = new List<Vector2>();

		protected float playAreaHeightAdjustment = 0.009f;

		protected float bodyMass = 100f;

		protected float bodyRadius = 0.15f;

		protected float leanForwardLengthAddition = 0.05f;

		protected float playAreaPositionThreshold = 0.002f;

		protected float gravityPush = -0.001f;

		protected int decimalPrecision = 3;

		protected bool isFalling;

		protected bool isMoving;

		protected bool isLeaning;

		protected bool onGround = true;

		protected bool preventSnapToFloor;

		protected bool generateRigidbody;

		protected Vector3 playAreaVelocity = Vector3.zero;

		protected string footColliderContainerNameCheck;

		protected const string BODY_COLLIDER_CONTAINER_NAME = "BodyColliderContainer";

		protected const string FOOT_COLLIDER_CONTAINER_NAME = "FootColliderContainer";

		protected bool enableBodyCollisionsStartingValue;

		protected float fallMinTime;

		protected HashSet<GameObject> ignoreCollisionsOnGameObjects = new HashSet<GameObject>();

		protected Transform cachedGrabbedObjectTransform;

		protected VRTK_InteractableObject cachedGrabbedObject;

		protected LayerMask defaultIgnoreLayer = 4;

		protected Coroutine restoreCollisionsRoutine;

		protected bool drawDebugGizmo;

		public event BodyPhysicsEventHandler StartFalling;

		public event BodyPhysicsEventHandler StopFalling;

		public event BodyPhysicsEventHandler StartMoving;

		public event BodyPhysicsEventHandler StopMoving;

		public event BodyPhysicsEventHandler StartColliding;

		public event BodyPhysicsEventHandler StopColliding;

		public event BodyPhysicsEventHandler StartLeaning;

		public event BodyPhysicsEventHandler StopLeaning;

		public event BodyPhysicsEventHandler StartTouchingGround;

		public event BodyPhysicsEventHandler StopTouchingGround;

		public virtual bool ArePhysicsEnabled()
		{
			if (!(bodyRigidbody != null))
			{
				return false;
			}
			return !bodyRigidbody.isKinematic;
		}

		public virtual void ApplyBodyVelocity(Vector3 velocity, bool forcePhysicsOn = false, bool applyMomentum = false)
		{
			if (enableBodyCollisions && forcePhysicsOn)
			{
				TogglePhysics(state: true);
			}
			if (ArePhysicsEnabled())
			{
				Vector3 vector = new Vector3(0f, gravityPush, 0f);
				bodyRigidbody.velocity = velocity + vector;
				ApplyBodyMomentum(applyMomentum);
				StartFall(currentValidFloorObject);
			}
		}

		public virtual void ToggleOnGround(bool state)
		{
			onGround = state;
			if (onGround)
			{
				OnStartTouchingGround(SetBodyPhysicsEvent(currentValidFloorObject, null));
			}
			else
			{
				OnStopTouchingGround(SetBodyPhysicsEvent(null, null));
			}
		}

		public virtual void TogglePreventSnapToFloor(bool state)
		{
			preventSnapToFloor = state;
		}

		public virtual void ForceSnapToFloor()
		{
			TogglePreventSnapToFloor(state: false);
			SnapToNearestFloor();
		}

		public virtual bool IsFalling()
		{
			return isFalling;
		}

		public virtual bool IsMoving()
		{
			return isMoving;
		}

		public virtual bool IsLeaning()
		{
			return isLeaning;
		}

		public virtual bool OnGround()
		{
			return onGround;
		}

		public virtual Vector3 GetVelocity()
		{
			if (!(bodyRigidbody != null))
			{
				return Vector3.zero;
			}
			return bodyRigidbody.velocity;
		}

		public virtual Vector3 GetAngularVelocity()
		{
			if (!(bodyRigidbody != null))
			{
				return Vector3.zero;
			}
			return bodyRigidbody.angularVelocity;
		}

		public virtual void ResetVelocities()
		{
			bodyRigidbody.velocity = Vector3.zero;
			bodyRigidbody.angularVelocity = Vector3.zero;
		}

		public virtual void ResetFalling()
		{
			StopFall();
		}

		public virtual GameObject GetBodyColliderContainer()
		{
			return bodyColliderContainer;
		}

		public virtual GameObject GetFootColliderContainer()
		{
			return footColliderContainer;
		}

		public virtual GameObject GetCurrentCollidingObject()
		{
			return currentCollidingObject;
		}

		public virtual void ResetIgnoredCollisions()
		{
			foreach (GameObject item in new HashSet<GameObject>(ignoreCollisionsOnGameObjects))
			{
				if (item != null)
				{
					Collider[] componentsInChildren = item.GetComponentsInChildren<Collider>();
					for (int i = 0; i < componentsInChildren.Length; i++)
					{
						ManagePhysicsCollider(componentsInChildren[i], state: false);
					}
				}
			}
			ignoreCollisionsOnGameObjects.Clear();
		}

		public virtual bool SweepCollision(Vector3 direction, float maxDistance)
		{
			Vector3 point = bodyCollider.transform.parent.TransformPoint(bodyCollider.transform.localPosition + bodyCollider.center) + Vector3.up * (bodyCollider.height * 0.5f - bodyCollider.radius);
			Vector3 point2 = bodyCollider.transform.parent.TransformPoint(bodyCollider.transform.localPosition + bodyCollider.center) - Vector3.up * (bodyCollider.height * 0.5f - bodyCollider.radius);
			RaycastHit hitData;
			return VRTK_CustomRaycast.CapsuleCast(customRaycast, point, point2, bodyCollider.radius, direction, maxDistance, out hitData, defaultIgnoreLayer, QueryTriggerInteraction.Ignore);
		}

		protected virtual void Awake()
		{
			VRTK_SDKManager.AttemptAddBehaviourToToggleOnLoadedSetupChange(this);
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			SetupPlayArea();
			SetupHeadset();
			footColliderContainerNameCheck = VRTK_SharedMethods.GenerateVRTKObjectName(true, "FootColliderContainer");
			enableBodyCollisionsStartingValue = enableBodyCollisions;
			EnableDropToFloor();
			if (playArea != null)
			{
				EnableBodyPhysics();
			}
			SetupIgnoredCollisions();
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			DisableDropToFloor();
			DisableBodyPhysics();
			ManageCollisionListeners(state: false);
			ResetIgnoredCollisions();
		}

		protected virtual void OnDestroy()
		{
			VRTK_SDKManager.AttemptRemoveBehaviourToToggleOnLoadedSetupChange(this);
		}

		protected virtual void FixedUpdate()
		{
			CheckBodyCollisionsSetting();
			ManageFalling();
			CalculateVelocity();
			UpdateCollider();
			lastPlayAreaPosition = ((playArea != null) ? playArea.position : Vector3.zero);
		}

		protected virtual void OnCollisionEnter(Collision collision)
		{
			if (CheckValidCollision(collision.gameObject))
			{
				CheckStepUpCollision(collision);
				currentCollidingObject = collision.gameObject;
				OnStartColliding(SetBodyPhysicsEvent(currentCollidingObject, collision.collider));
			}
		}

		protected virtual void OnTriggerEnter(Collider collider)
		{
			if (CheckValidCollision(collider.gameObject))
			{
				currentCollidingObject = collider.gameObject;
				OnStartColliding(SetBodyPhysicsEvent(currentCollidingObject, collider));
			}
		}

		protected virtual void OnCollisionExit(Collision collision)
		{
			if (CheckExistingCollision(collision.gameObject))
			{
				OnStopColliding(SetBodyPhysicsEvent(currentCollidingObject, collision.collider));
				currentCollidingObject = null;
			}
		}

		protected virtual void OnTriggerExit(Collider collider)
		{
			if (CheckExistingCollision(collider.gameObject))
			{
				OnStopColliding(SetBodyPhysicsEvent(currentCollidingObject, collider));
				currentCollidingObject = null;
			}
		}

		protected virtual void OnDrawGizmos()
		{
			if (drawDebugGizmo && headset != null)
			{
				Gizmos.color = Color.green;
				Gizmos.DrawSphere(new Vector3(headset.position.x, headset.position.y - 0.3f, headset.position.z), 0.075f);
				Gizmos.color = Color.red;
				Gizmos.DrawSphere(new Vector3(currentStandingPosition.x, headset.position.y - 0.3f, currentStandingPosition.y), 0.05f);
			}
		}

		protected virtual bool CheckValidCollision(GameObject checkObject)
		{
			if (!VRTK_PlayerObject.IsPlayerObject(checkObject))
			{
				if (onGround)
				{
					if (currentValidFloorObject != null)
					{
						return currentValidFloorObject != checkObject;
					}
					return false;
				}
				return true;
			}
			return false;
		}

		protected virtual bool CheckExistingCollision(GameObject checkObject)
		{
			if (currentCollidingObject != null)
			{
				return currentCollidingObject == checkObject;
			}
			return false;
		}

		protected virtual void SetupPlayArea()
		{
			playArea = VRTK_DeviceFinder.PlayAreaTransform();
			if (playArea != null)
			{
				lastPlayAreaPosition = playArea.position;
				collisionTracker = playArea.GetComponent<VRTK_CollisionTracker>();
				if (collisionTracker == null)
				{
					collisionTracker = playArea.gameObject.AddComponent<VRTK_CollisionTracker>();
				}
				ManageCollisionListeners(state: true);
			}
		}

		protected virtual void SetupHeadset()
		{
			headset = VRTK_DeviceFinder.HeadsetTransform();
			if (headset != null)
			{
				currentStandingPosition = new Vector2(headset.position.x, headset.position.z);
			}
		}

		protected virtual void ManageCollisionListeners(bool state)
		{
			if (collisionTracker != null)
			{
				if (state)
				{
					collisionTracker.CollisionEnter += CollisionTracker_CollisionEnter;
					collisionTracker.CollisionExit += CollisionTracker_CollisionExit;
					collisionTracker.TriggerEnter += CollisionTracker_TriggerEnter;
					collisionTracker.TriggerExit += CollisionTracker_TriggerExit;
				}
				else
				{
					collisionTracker.CollisionEnter -= CollisionTracker_CollisionEnter;
					collisionTracker.CollisionExit -= CollisionTracker_CollisionExit;
					collisionTracker.TriggerEnter -= CollisionTracker_TriggerEnter;
					collisionTracker.TriggerExit -= CollisionTracker_TriggerExit;
				}
			}
		}

		protected virtual void CollisionTracker_TriggerExit(object sender, CollisionTrackerEventArgs e)
		{
			OnTriggerExit(e.collider);
		}

		protected virtual void CollisionTracker_TriggerEnter(object sender, CollisionTrackerEventArgs e)
		{
			OnTriggerEnter(e.collider);
		}

		protected virtual void CollisionTracker_CollisionExit(object sender, CollisionTrackerEventArgs e)
		{
			OnCollisionExit(e.collision);
		}

		protected virtual void CollisionTracker_CollisionEnter(object sender, CollisionTrackerEventArgs e)
		{
			OnCollisionEnter(e.collision);
		}

		protected virtual void OnStartFalling(BodyPhysicsEventArgs e)
		{
			if (this.StartFalling != null)
			{
				this.StartFalling(this, e);
			}
		}

		protected virtual void OnStopFalling(BodyPhysicsEventArgs e)
		{
			if (this.StopFalling != null)
			{
				this.StopFalling(this, e);
			}
		}

		protected virtual void OnStartMoving(BodyPhysicsEventArgs e)
		{
			if (this.StartMoving != null)
			{
				this.StartMoving(this, e);
			}
		}

		protected virtual void OnStopMoving(BodyPhysicsEventArgs e)
		{
			if (this.StopMoving != null)
			{
				this.StopMoving(this, e);
			}
		}

		protected virtual void OnStartColliding(BodyPhysicsEventArgs e)
		{
			if (this.StartColliding != null)
			{
				this.StartColliding(this, e);
			}
		}

		protected virtual void OnStopColliding(BodyPhysicsEventArgs e)
		{
			if (this.StopColliding != null)
			{
				this.StopColliding(this, e);
			}
		}

		protected virtual void OnStartLeaning(BodyPhysicsEventArgs e)
		{
			if (this.StartLeaning != null)
			{
				this.StartLeaning(this, e);
			}
		}

		protected virtual void OnStopLeaning(BodyPhysicsEventArgs e)
		{
			if (this.StopLeaning != null)
			{
				this.StopLeaning(this, e);
			}
		}

		protected virtual void OnStartTouchingGround(BodyPhysicsEventArgs e)
		{
			if (this.StartTouchingGround != null)
			{
				this.StartTouchingGround(this, e);
			}
		}

		protected virtual void OnStopTouchingGround(BodyPhysicsEventArgs e)
		{
			if (this.StopTouchingGround != null)
			{
				this.StopTouchingGround(this, e);
			}
		}

		protected virtual BodyPhysicsEventArgs SetBodyPhysicsEvent(GameObject target, Collider collider)
		{
			BodyPhysicsEventArgs result = default(BodyPhysicsEventArgs);
			result.target = target;
			result.collider = collider;
			return result;
		}

		protected virtual void CalculateVelocity()
		{
			playAreaVelocity = ((playArea != null) ? ((playArea.position - lastPlayAreaPosition) / Time.fixedDeltaTime) : Vector3.zero);
		}

		protected virtual void TogglePhysics(bool state)
		{
			if (bodyRigidbody != null)
			{
				bodyRigidbody.isKinematic = !state;
			}
			if (bodyCollider != null)
			{
				bodyCollider.isTrigger = !state;
			}
			if (footCollider != null)
			{
				footCollider.isTrigger = !state;
			}
			currentBodyCollisionsSetting = state;
		}

		protected virtual void ManageFalling()
		{
			if (!isFalling)
			{
				CheckHeadsetMovement();
				SnapToNearestFloor();
			}
			else
			{
				CheckFalling();
			}
		}

		protected virtual void CheckBodyCollisionsSetting()
		{
			if (enableBodyCollisions != currentBodyCollisionsSetting)
			{
				TogglePhysics(enableBodyCollisions);
			}
		}

		protected virtual void CheckFalling()
		{
			if (isFalling && fallMinTime < Time.time && VRTK_SharedMethods.RoundFloat(lastPlayAreaPosition.y, fallCheckPrecision) == VRTK_SharedMethods.RoundFloat(playArea.position.y, fallCheckPrecision))
			{
				StopFall();
			}
		}

		protected virtual void SetCurrentStandingPosition()
		{
			if (playArea != null && playArea.transform.position != lastPlayAreaPosition)
			{
				Vector3 vector = playArea.transform.position - lastPlayAreaPosition;
				currentStandingPosition = new Vector2(currentStandingPosition.x + vector.x, currentStandingPosition.y + vector.z);
			}
		}

		protected virtual void SetIsMoving(Vector2 currentHeadsetPosition)
		{
			float num = Vector2.Distance(currentHeadsetPosition, currentStandingPosition);
			float num2 = ((playArea != null) ? Vector3.Distance(playArea.transform.position, lastPlayAreaPosition) : 0f);
			isMoving = ((num > movementThreshold) ? true : false);
			if (playArea != null && (num2 > playAreaMovementThreshold || !onGround))
			{
				isMoving = false;
			}
		}

		protected virtual void CheckLean()
		{
			if (!(bodyCollider != null))
			{
				return;
			}
			Vector3 vector = ((headset != null) ? new Vector3(currentStandingPosition.x, headset.position.y, currentStandingPosition.y) : Vector3.zero);
			Vector3 direction = ((playArea != null) ? (-playArea.up) : Vector3.zero);
			currentValidFloorObject = (VRTK_CustomRaycast.Raycast(ray: new Ray(vector, direction), customCast: customRaycast, hitData: out var hitData, ignoreLayers: defaultIgnoreLayer, length: float.PositiveInfinity, affectTriggers: QueryTriggerInteraction.Ignore) ? hitData.collider.gameObject : null);
			if (!(headset == null) && !(playArea == null) && enableBodyCollisions)
			{
				Quaternion rotation = headset.rotation;
				headset.rotation = new Quaternion(0f, headset.rotation.y, headset.rotation.z, headset.rotation.w);
				Ray ray = new Ray(headset.position, headset.forward);
				float num = bodyCollider.radius + leanForwardLengthAddition;
				if (!VRTK_CustomRaycast.Raycast(customRaycast, ray, out var _, defaultIgnoreLayer, num, QueryTriggerInteraction.Ignore) && currentValidFloorObject != null)
				{
					CalculateLean(vector, num, hitData.distance);
				}
				headset.rotation = rotation;
			}
		}

		protected virtual void CalculateLean(Vector3 startPosition, float forwardLength, float originalRayDistance)
		{
			Vector3 vector = startPosition + headset.forward * forwardLength;
			vector = new Vector3(vector.x, startPosition.y, vector.z);
			if (VRTK_CustomRaycast.Raycast(ray: new Ray(vector, -playArea.up), customCast: customRaycast, hitData: out var hitData, ignoreLayers: defaultIgnoreLayer, length: float.PositiveInfinity, affectTriggers: QueryTriggerInteraction.Ignore))
			{
				float num = VRTK_SharedMethods.RoundFloat(originalRayDistance - hitData.distance, decimalPrecision);
				float num2 = VRTK_SharedMethods.RoundFloat(Vector3.Distance(playArea.transform.position, lastPlayAreaPosition), decimalPrecision);
				isMoving = (onGround && num2 <= playAreaPositionThreshold && num > 0f) || isMoving;
				isLeaning = ((onGround && num > leanYThreshold) ? true : false);
				if (isLeaning)
				{
					OnStartLeaning(SetBodyPhysicsEvent(hitData.collider.gameObject, hitData.collider));
				}
				else
				{
					OnStopLeaning(SetBodyPhysicsEvent(null, null));
				}
			}
		}

		protected virtual void UpdateStandingPosition(Vector2 currentHeadsetPosition)
		{
			VRTK_SharedMethods.AddListValue(standingPositionHistory, currentHeadsetPosition);
			if (standingPositionHistory.Count <= standingHistorySamples)
			{
				return;
			}
			if (!isLeaning && currentCollidingObject == null)
			{
				bool flag = true;
				for (int i = 0; i < standingHistorySamples; i++)
				{
					flag = Vector2.Distance(standingPositionHistory[i], standingPositionHistory[standingHistorySamples]) <= movementThreshold && flag;
				}
				currentStandingPosition = (flag ? currentHeadsetPosition : currentStandingPosition);
			}
			standingPositionHistory.Clear();
		}

		protected virtual void CheckHeadsetMovement()
		{
			bool num = isMoving;
			Vector2 currentHeadsetPosition = ((headset != null) ? new Vector2(headset.position.x, headset.position.z) : Vector2.zero);
			SetCurrentStandingPosition();
			SetIsMoving(currentHeadsetPosition);
			CheckLean();
			UpdateStandingPosition(currentHeadsetPosition);
			if (enableBodyCollisions)
			{
				TogglePhysics(!isMoving);
			}
			if (num != isMoving)
			{
				MovementChanged(isMoving);
			}
		}

		protected virtual void MovementChanged(bool movementState)
		{
			if (movementState)
			{
				OnStartMoving(SetBodyPhysicsEvent(null, null));
			}
			else
			{
				OnStopMoving(SetBodyPhysicsEvent(null, null));
			}
		}

		protected virtual void EnableDropToFloor()
		{
			initialFloorDrop = false;
			retogglePhysicsOnCanFall = false;
			teleporter = ((teleporter != null) ? teleporter : Object.FindObjectOfType<VRTK_BasicTeleport>());
			if (teleporter != null)
			{
				teleporter.Teleported += Teleported;
			}
		}

		protected virtual void DisableDropToFloor()
		{
			if (teleporter != null)
			{
				teleporter.Teleported -= Teleported;
			}
		}

		protected virtual void Teleported(object sender, DestinationMarkerEventArgs e)
		{
			initialFloorDrop = false;
			StopFall();
			if (resetPhysicsAfterTeleport)
			{
				TogglePhysics(storedCurrentPhysics);
			}
		}

		protected virtual void EnableBodyPhysics()
		{
			currentBodyCollisionsSetting = enableBodyCollisions;
			CreateCollider();
			InitControllerListeners(VRTK_DeviceFinder.GetControllerLeftHand(), state: true);
			InitControllerListeners(VRTK_DeviceFinder.GetControllerRightHand(), state: true);
		}

		protected virtual void DisableBodyPhysics()
		{
			DestroyCollider();
			InitControllerListeners(VRTK_DeviceFinder.GetControllerLeftHand(), state: false);
			InitControllerListeners(VRTK_DeviceFinder.GetControllerRightHand(), state: false);
		}

		protected virtual void SetupIgnoredCollisions()
		{
			ResetIgnoredCollisions();
			if (ignoreCollisionsWith == null)
			{
				return;
			}
			for (int i = 0; i < ignoreCollisionsWith.Length; i++)
			{
				Collider[] componentsInChildren = ignoreCollisionsWith[i].GetComponentsInChildren<Collider>();
				for (int j = 0; j < componentsInChildren.Length; j++)
				{
					ManagePhysicsCollider(componentsInChildren[j], state: true);
				}
				if (componentsInChildren.Length != 0)
				{
					ignoreCollisionsOnGameObjects.Add(ignoreCollisionsWith[i]);
				}
			}
		}

		protected virtual void ManagePhysicsCollider(Collider collider, bool state)
		{
			if (bodyCollider != null)
			{
				Physics.IgnoreCollision(bodyCollider, collider, state);
			}
			if (footCollider != null)
			{
				Physics.IgnoreCollision(footCollider, collider, state);
			}
		}

		protected virtual void CheckStepUpCollision(Collision collision)
		{
			if (!(bodyCollider != null) || !(footCollider != null) || collision.contacts.Length == 0 || !(collision.contacts[0].thisCollider.transform.name == footColliderContainerNameCheck))
			{
				return;
			}
			float num = 0.55f;
			float y = 0.01f;
			Vector3 vector = playArea.TransformPoint(footCollider.center);
			Vector3 center = new Vector3(vector.x, vector.y + CalculateStepUpYOffset() * num, vector.z);
			Vector3 halfExtents = new Vector3(bodyCollider.radius, y, bodyCollider.radius);
			float maxDistance = center.y - playArea.position.y;
			if (VRTK_CustomRaycast.BoxCast(customRaycast, center, halfExtents, Vector3.down, Quaternion.identity, maxDistance, out var hitData, defaultIgnoreLayer, QueryTriggerInteraction.Ignore) && hitData.point.y - playArea.position.y > stepDropThreshold)
			{
				if (teleporter != null && enableTeleport)
				{
					hitFloorYDelta = playArea.position.y - hitData.point.y;
					TeleportFall(hitData.point.y, hitData);
					lastFrameFloorY = hitData.point.y;
				}
				else
				{
					playArea.position = new Vector3(hitData.point.x - (headset.position.x - playArea.position.x), hitData.point.y, hitData.point.z - (headset.position.z - playArea.position.z));
				}
			}
		}

		protected virtual GameObject CreateColliderContainer(string name, Transform parent)
		{
			GameObject obj = new GameObject(VRTK_SharedMethods.GenerateVRTKObjectName(true, name));
			obj.transform.SetParent(parent);
			obj.transform.localPosition = Vector3.zero;
			obj.transform.localRotation = Quaternion.identity;
			obj.transform.localScale = Vector3.one;
			obj.layer = LayerMask.NameToLayer("Ignore Raycast");
			VRTK_PlayerObject.SetPlayerObject(obj, VRTK_PlayerObject.ObjectTypes.Collider);
			return obj;
		}

		protected virtual GameObject InstantiateColliderContainer(GameObject objectToClone, string name, Transform parent)
		{
			GameObject gameObject = Object.Instantiate(objectToClone, parent);
			gameObject.name = VRTK_SharedMethods.GenerateVRTKObjectName(true, name);
			VRTK_PlayerObject.SetPlayerObject(gameObject, VRTK_PlayerObject.ObjectTypes.Collider);
			return gameObject;
		}

		protected virtual void GenerateRigidbody()
		{
			if (customPlayAreaRigidbody != null)
			{
				HasExistingRigidbody();
				bodyRigidbody.mass = customPlayAreaRigidbody.mass;
				bodyRigidbody.drag = customPlayAreaRigidbody.drag;
				bodyRigidbody.angularDrag = customPlayAreaRigidbody.angularDrag;
				bodyRigidbody.useGravity = customPlayAreaRigidbody.useGravity;
				bodyRigidbody.isKinematic = customPlayAreaRigidbody.isKinematic;
				bodyRigidbody.interpolation = customPlayAreaRigidbody.interpolation;
				bodyRigidbody.collisionDetectionMode = customPlayAreaRigidbody.collisionDetectionMode;
				bodyRigidbody.constraints = customPlayAreaRigidbody.constraints;
			}
			else if (!HasExistingRigidbody())
			{
				bodyRigidbody.mass = bodyMass;
				bodyRigidbody.freezeRotation = true;
			}
		}

		protected virtual bool HasExistingRigidbody()
		{
			Rigidbody component = playArea.GetComponent<Rigidbody>();
			if (component != null)
			{
				generateRigidbody = false;
				bodyRigidbody = component;
				return true;
			}
			generateRigidbody = true;
			bodyRigidbody = playArea.gameObject.AddComponent<Rigidbody>();
			return false;
		}

		protected virtual CapsuleCollider GenerateCapsuleCollider(GameObject parent, float setRadius)
		{
			CapsuleCollider capsuleCollider = parent.GetComponent<CapsuleCollider>();
			if (capsuleCollider == null)
			{
				capsuleCollider = parent.AddComponent<CapsuleCollider>();
				capsuleCollider.radius = setRadius;
			}
			return capsuleCollider;
		}

		protected virtual void GenerateBodyCollider()
		{
			if (bodyColliderContainer == null)
			{
				if (customBodyColliderContainer != null)
				{
					bodyColliderContainer = InstantiateColliderContainer(customBodyColliderContainer, "BodyColliderContainer", playArea);
					bodyCollider = bodyColliderContainer.GetComponent<CapsuleCollider>();
				}
				else
				{
					bodyColliderContainer = CreateColliderContainer("BodyColliderContainer", playArea);
					bodyColliderContainer.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
				}
				bodyCollider = GenerateCapsuleCollider(bodyColliderContainer, bodyRadius);
				GenerateFootCollider();
			}
		}

		protected virtual void GenerateFootCollider()
		{
			if (CalculateStepUpYOffset() > 0f)
			{
				if (customFootColliderContainer != null)
				{
					footColliderContainer = InstantiateColliderContainer(customFootColliderContainer, "FootColliderContainer", bodyColliderContainer.transform);
				}
				else
				{
					footColliderContainer = CreateColliderContainer("FootColliderContainer", bodyColliderContainer.transform);
					footColliderContainer.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
				}
				footCollider = GenerateCapsuleCollider(footColliderContainer, 0f);
			}
		}

		protected virtual void CreateCollider()
		{
			generateRigidbody = false;
			if (playArea == null)
			{
				VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.SDK_OBJECT_NOT_FOUND, "PlayArea", "Boundaries SDK"));
				return;
			}
			VRTK_PlayerObject.SetPlayerObject(playArea.gameObject, VRTK_PlayerObject.ObjectTypes.CameraRig);
			GenerateRigidbody();
			GenerateBodyCollider();
			if (playArea.gameObject.layer == 0)
			{
				playArea.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
			}
			TogglePhysics(enableBodyCollisions);
		}

		protected virtual void DestroyCollider()
		{
			if (generateRigidbody && bodyRigidbody != null)
			{
				Object.Destroy(bodyRigidbody);
				bodyRigidbody = null;
			}
			if (bodyColliderContainer != null)
			{
				Object.Destroy(bodyColliderContainer);
				bodyColliderContainer = null;
			}
		}

		protected virtual void UpdateCollider()
		{
			if (bodyCollider != null && headset != null)
			{
				float num = headset.position.y - playArea.position.y - (headsetYOffset + CalculateStepUpYOffset());
				float y = Mathf.Max(num * 0.5f + CalculateStepUpYOffset() + playAreaHeightAdjustment, bodyCollider.radius + playAreaHeightAdjustment);
				bodyCollider.height = Mathf.Max(num, bodyCollider.radius);
				bodyCollider.center = new Vector3(headset.localPosition.x, y, headset.localPosition.z);
				if (footCollider != null)
				{
					float radius = bodyCollider.radius * stepThicknessMultiplier;
					footCollider.radius = radius;
					footCollider.height = CalculateStepUpYOffset();
					footCollider.center = new Vector3(headset.localPosition.x, CalculateStepUpYOffset() * 0.5f, headset.localPosition.z);
				}
			}
		}

		protected virtual float CalculateStepUpYOffset()
		{
			return stepUpYOffset * 2f;
		}

		protected virtual void InitControllerListeners(GameObject mappedController, bool state)
		{
			if (!(mappedController != null))
			{
				return;
			}
			IgnoreCollisions(mappedController.GetComponentsInChildren<Collider>(), state: true);
			VRTK_InteractGrab componentInChildren = mappedController.GetComponentInChildren<VRTK_InteractGrab>();
			if (componentInChildren != null && ignoreGrabbedCollisions)
			{
				if (state)
				{
					componentInChildren.ControllerGrabInteractableObject += OnGrabObject;
					componentInChildren.ControllerUngrabInteractableObject += OnUngrabObject;
				}
				else
				{
					componentInChildren.ControllerGrabInteractableObject -= OnGrabObject;
					componentInChildren.ControllerUngrabInteractableObject -= OnUngrabObject;
				}
			}
		}

		protected virtual IEnumerator RestoreCollisions(GameObject obj)
		{
			yield return new WaitForEndOfFrame();
			if (obj != null)
			{
				VRTK_InteractableObject component = obj.GetComponent<VRTK_InteractableObject>();
				if (component != null && !component.IsGrabbed())
				{
					IgnoreCollisions(obj.GetComponentsInChildren<Collider>(), state: false);
				}
			}
		}

		protected virtual void IgnoreCollisions(Collider[] colliders, bool state)
		{
			if (!(bodyColliderContainer != null))
			{
				return;
			}
			Collider[] componentsInChildren = bodyColliderContainer.GetComponentsInChildren<Collider>();
			foreach (Collider collider in componentsInChildren)
			{
				if (!collider.gameObject.activeInHierarchy)
				{
					continue;
				}
				foreach (Collider collider2 in colliders)
				{
					if (collider2.gameObject.activeInHierarchy)
					{
						Physics.IgnoreCollision(collider, collider2, state);
					}
				}
			}
		}

		protected virtual void OnGrabObject(object sender, ObjectInteractEventArgs e)
		{
			if (e.target != null)
			{
				if (restoreCollisionsRoutine != null)
				{
					StopCoroutine(restoreCollisionsRoutine);
				}
				IgnoreCollisions(e.target.GetComponentsInChildren<Collider>(), state: true);
			}
		}

		protected virtual void OnUngrabObject(object sender, ObjectInteractEventArgs e)
		{
			if (base.gameObject.activeInHierarchy && playArea.gameObject.activeInHierarchy)
			{
				restoreCollisionsRoutine = StartCoroutine(RestoreCollisions(e.target));
			}
		}

		protected virtual bool FloorIsGrabbedObject(RaycastHit collidedObj)
		{
			if (cachedGrabbedObjectTransform != collidedObj.transform)
			{
				cachedGrabbedObjectTransform = collidedObj.transform;
				cachedGrabbedObject = collidedObj.transform.GetComponent<VRTK_InteractableObject>();
			}
			if (cachedGrabbedObject != null)
			{
				return cachedGrabbedObject.IsGrabbed();
			}
			return false;
		}

		protected virtual bool FloorHeightChanged(float currentY)
		{
			return Mathf.Abs(currentY - lastFrameFloorY) > floorHeightTolerance;
		}

		protected virtual bool ValidDrop(bool rayHit, RaycastHit rayCollidedWith, float floorY)
		{
			if (rayHit && teleporter != null && teleporter.ValidLocation(rayCollidedWith.transform, rayCollidedWith.point) && !FloorIsGrabbedObject(rayCollidedWith))
			{
				return FloorHeightChanged(floorY);
			}
			return false;
		}

		protected virtual float ControllerHeightCheck(GameObject controllerObj)
		{
			VRTK_CustomRaycast.Raycast(ray: new Ray(controllerObj.transform.position, -playArea.up), customCast: customRaycast, hitData: out var hitData, ignoreLayers: defaultIgnoreLayer, length: float.PositiveInfinity, affectTriggers: QueryTriggerInteraction.Ignore);
			return controllerObj.transform.position.y - hitData.distance;
		}

		protected virtual bool ControllersStillOverPreviousFloor()
		{
			if (fallRestriction == FallingRestrictors.NoRestriction)
			{
				return false;
			}
			if (fallRestriction == FallingRestrictors.AlwaysRestrict)
			{
				return true;
			}
			float num = 0.05f;
			GameObject controllerRightHand = VRTK_DeviceFinder.GetControllerRightHand();
			GameObject controllerLeftHand = VRTK_DeviceFinder.GetControllerLeftHand();
			float y = playArea.position.y;
			bool flag = controllerRightHand.activeInHierarchy && Mathf.Abs(ControllerHeightCheck(controllerRightHand) - y) < num;
			bool flag2 = controllerLeftHand.activeInHierarchy && Mathf.Abs(ControllerHeightCheck(controllerLeftHand) - y) < num;
			if (fallRestriction == FallingRestrictors.LeftController)
			{
				flag = false;
			}
			if (fallRestriction == FallingRestrictors.RightController)
			{
				flag2 = false;
			}
			if (fallRestriction == FallingRestrictors.BothControllers)
			{
				return flag && flag2;
			}
			return flag || flag2;
		}

		protected virtual void SnapToNearestFloor()
		{
			if (!preventSnapToFloor && (enableBodyCollisions || enableTeleport) && headset != null && headset.transform.position.y > playArea.position.y)
			{
				RaycastHit hitData;
				bool rayHit = VRTK_CustomRaycast.Raycast(ray: new Ray(headset.transform.position, -playArea.up), customCast: customRaycast, hitData: out hitData, ignoreLayers: defaultIgnoreLayer, length: float.PositiveInfinity, affectTriggers: QueryTriggerInteraction.Ignore);
				hitFloorYDelta = playArea.position.y - hitData.point.y;
				if (initialFloorDrop && (ValidDrop(rayHit, hitData, hitData.point.y) || retogglePhysicsOnCanFall))
				{
					storedCurrentPhysics = ArePhysicsEnabled();
					resetPhysicsAfterTeleport = false;
					TogglePhysics(state: false);
					HandleFall(hitData.point.y, hitData);
				}
				initialFloorDrop = true;
				lastFrameFloorY = hitData.point.y;
			}
		}

		protected virtual bool PreventFall(float hitFloorY)
		{
			if (hitFloorY < playArea.position.y)
			{
				return ControllersStillOverPreviousFloor();
			}
			return false;
		}

		protected virtual void HandleFall(float hitFloorY, RaycastHit rayCollidedWith)
		{
			if (PreventFall(hitFloorY))
			{
				if (!retogglePhysicsOnCanFall)
				{
					retogglePhysicsOnCanFall = true;
					storedRetogglePhysics = storedCurrentPhysics;
				}
				return;
			}
			if (retogglePhysicsOnCanFall)
			{
				storedCurrentPhysics = storedRetogglePhysics;
				retogglePhysicsOnCanFall = false;
			}
			if (enableBodyCollisions && (teleporter == null || !enableTeleport || hitFloorYDelta > gravityFallYThreshold))
			{
				GravityFall(rayCollidedWith);
			}
			else if (teleporter != null && enableTeleport)
			{
				TeleportFall(hitFloorY, rayCollidedWith);
			}
		}

		protected virtual void StartFall(GameObject targetFloor)
		{
			if (IsLeaning())
			{
				OnStopLeaning(SetBodyPhysicsEvent(null, null));
			}
			if (OnGround())
			{
				OnStopTouchingGround(SetBodyPhysicsEvent(null, null));
			}
			isFalling = true;
			isMoving = false;
			isLeaning = false;
			onGround = false;
			fallMinTime = Time.time + Time.fixedDeltaTime * 3f;
			OnStartFalling(SetBodyPhysicsEvent(targetFloor, null));
		}

		protected virtual void StopFall()
		{
			bool num = isFalling;
			if (!OnGround())
			{
				OnStartTouchingGround(SetBodyPhysicsEvent(currentValidFloorObject, null));
			}
			isFalling = false;
			onGround = true;
			enableBodyCollisions = enableBodyCollisionsStartingValue;
			if (num)
			{
				OnStopFalling(SetBodyPhysicsEvent(null, null));
			}
		}

		protected virtual void GravityFall(RaycastHit rayCollidedWith)
		{
			StartFall(rayCollidedWith.collider.gameObject);
			TogglePhysics(state: true);
			ApplyBodyVelocity(Vector3.zero);
		}

		protected virtual void TeleportFall(float floorY, RaycastHit rayCollidedWith)
		{
			StartFall(rayCollidedWith.collider.gameObject);
			GameObject gameObject = rayCollidedWith.transform.gameObject;
			Vector3 position = new Vector3(playArea.position.x, floorY, playArea.position.z);
			float blinkTransitionSpeed = teleporter.blinkTransitionSpeed;
			teleporter.blinkTransitionSpeed = ((Mathf.Abs(hitFloorYDelta) > blinkYThreshold) ? blinkTransitionSpeed : 0f);
			OnDestinationMarkerSet(SetDestinationMarkerEvent(rayCollidedWith.distance, gameObject.transform, rayCollidedWith, position, null, forceDestinationPosition: true));
			teleporter.blinkTransitionSpeed = blinkTransitionSpeed;
			resetPhysicsAfterTeleport = true;
		}

		protected virtual void ApplyBodyMomentum(bool applyMomentum = false)
		{
			if (applyMomentum)
			{
				float magnitude = bodyRigidbody.velocity.magnitude;
				Vector3 force = playAreaVelocity / ((magnitude < 1f) ? 1f : magnitude);
				bodyRigidbody.AddRelativeForce(force, ForceMode.VelocityChange);
			}
		}
	}
}
