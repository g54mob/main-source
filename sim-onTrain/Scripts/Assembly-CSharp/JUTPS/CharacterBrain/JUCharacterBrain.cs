using JUTPS.ActionScripts;
using JUTPS.CameraSystems;
using JUTPS.ExtendedInverseKinematics;
using JUTPS.InventorySystem;
using JUTPS.ItemSystem;
using JUTPS.PhysicsScripts;
using JUTPS.VehicleSystem;
using JUTPS.WeaponSystem;
using Mirror;
using UnityEngine;

namespace JUTPS.CharacterBrain
{
	public class JUCharacterBrain : NetworkBehaviour
	{
		public enum MovementMode
		{
			Free = 0,
			AwaysInFireMode = 1,
			JuTpsClassic = 2,
			TpsFixed = 3
		}

		public enum PressAimMode
		{
			HoldToAim = 0,
			OnePressToAim = 1
		}

		public enum SwitchDirection
		{
			Forward = 0,
			Backward = 1
		}

		[HideInInspector]
		public Vector3 UpDirection = Vector3.zero;

		[HideInInspector]
		public Quaternion UpOrientation;

		[HideInInspector]
		private Quaternion ForwardOrientation = Quaternion.identity;

		[HideInInspector]
		public Animator anim;

		[HideInInspector]
		public NetworkAnimator networkAnimator;

		[HideInInspector]
		public Rigidbody rb;

		[HideInInspector]
		protected Collider coll;

		protected Camera MyCamera;

		[HideInInspector]
		public JUCameraController MyPivotCamera;

		[HideInInspector]
		private Quaternion lastDirectionTransformRotation;

		[HideInInspector]
		protected AdvancedRagdollController Ragdoller;

		[HideInInspector]
		protected JUFootPlacement FootPlacerIK;

		[HideInInspector]
		public JUHealth CharacterHealth;

		[HideInInspector]
		public DriveVehicles DriveVehicleAbility;

		[HideInInspector]
		public JUInventory Inventory;

		[HideInInspector]
		public Damager LeftHandDamager;

		[HideInInspector]
		public Damager RightHandDamager;

		[HideInInspector]
		public Damager LeftFootDamager;

		[HideInInspector]
		public Damager RightFootDamager;

		[HideInInspector]
		public float VelocityMultiplier;

		protected float VerticalY;

		protected float HorizontalX;

		[HideInInspector]
		public Transform DirectionTransform;

		protected float BodyRotation;

		protected float IdleTurn;

		protected Vector3 EulerRotation;

		protected Quaternion DesiredCameraRotation;

		[HideInInspector]
		public Vector3 DesiredDirection;

		protected float LastX;

		protected float LastY;

		protected float LastVelMult;

		[HideInInspector]
		public RaycastHit Step_Hit;

		protected bool AdjustHeight;

		[Header("Movement Settings")]
		public MovementMode LocomotionMode;

		public bool SetRigidbodyVelocity = true;

		public float FireModeMaxTime = 1f;

		public float Speed = 3f;

		public float RotationSpeed = 2f;

		public float JumpForce = 3f;

		public float StoppingSpeed = 2f;

		public float AirInfluenceControll = 0.5f;

		public float MaxWalkableAngle = 45f;

		public bool CurvedMovement = true;

		public bool LerpRotation;

		public bool BodyInclination = true;

		public bool MovementAffectsWeaponAccuracy;

		public float OnMovePrecision = 4f;

		public Vector3 LookAtPosition;

		public bool SprintingSkill = true;

		protected bool CanSprint = true;

		protected bool MaxSprintSpeed;

		protected float SprintSpeedDecrease;

		public bool GroundAngleDesaceleration = true;

		public float GroundAngleDesacelerationMultiplier = 1.5f;

		protected float SlidingVelocity;

		public float GroundAngle;

		public Vector3 GroundNormal;

		public Vector3 GroundPoint;

		public bool RootMotion;

		public float RootMotionSpeed = 1f;

		public bool RootMotionRotation;

		public Vector3 RootMotionDeltaPosition;

		[Header("Death Options")]
		public bool RagdollWhenDie;

		[Header("Ground Check Settings")]
		public LayerMask WhatIsGround;

		public float GroundCheckRadius = 0.1f;

		public float GroundCheckHeighOfsset = 0.1f;

		public float GroundCheckSize = 0.5f;

		[Header("Wall Check Settings")]
		public LayerMask WhatIsWall;

		public float WallRayHeight = 1f;

		public float WallRayDistance = 0.6f;

		[Header("Step Settings")]
		public bool EnableStepCorrection = true;

		public float UpStepSpeed = 5f;

		public LayerMask StepCorrectionMask;

		public float FootstepHeight = 0.4f;

		public float ForwardStepOffset = 0.6f;

		public float StepHeight = 0.02f;

		[Header("Animator Parameters")]
		public JUAnimatorParameters AnimatorParameters;

		[Header("Item Management Settings")]
		public GameObject PivotItemRotation;

		public WeaponAimRotationCenter WeaponHoldingPositions;

		[HideInInspector]
		public HoldableItem HoldableItemInUseRightHand;

		[HideInInspector]
		public HoldableItem HoldableItemInUseLeftHand;

		[HideInInspector]
		public Weapon WeaponInUseRightHand;

		[HideInInspector]
		public Weapon WeaponInUseLeftHand;

		[HideInInspector]
		public MeleeWeapon MeleeWeaponInUseRightHand;

		[HideInInspector]
		public MeleeWeapon MeleeWeaponInUseLeftHand;

		protected int CurrentItemIDRightHand = -1;

		protected int CurrentItemIDLeftHand = -1;

		public PressAimMode AimMode;

		[HideInInspector]
		protected float IsArmedWeight;

		[HideInInspector]
		protected float LegsLayerWeight;

		[HideInInspector]
		protected float BothArmsLayerWeight;

		[HideInInspector]
		protected float RightArmLayerWeight;

		[HideInInspector]
		protected float LeftArmLayerWeight;

		[HideInInspector]
		protected float WeaponSwitchLayerWeight;

		[HideInInspector]
		protected float TorsoLayerWeight;

		[HideInInspector]
		protected float FullBodyLayerWeight;

		[HideInInspector]
		protected float LegsOverrideLayerWeight;

		[HideInInspector]
		protected float WeaponSwitchingCurrentTime;

		[HideInInspector]
		public Transform IKPositionRightHand;

		[HideInInspector]
		public Transform IKPositionLeftHand;

		[HideInInspector]
		private Transform RightHandIKPositionTarget;

		[HideInInspector]
		private Transform LeftHandIKPositionTarget;

		[HideInInspector]
		public Transform HumanoidSpine;

		protected float LookWeightIK;

		protected float ArmsWeightIK;

		public float LeftHandWeightIK;

		public float RightHandWeightIK;

		[HideInInspector]
		public float CurrentTimeToDisableFireMode;

		public Vehicle VehicleInArea;

		public Collider[] CharacterHitBoxes;

		[Header("States")]
		public bool IsDead;

		public bool DisableAllMove;

		public bool CanMove = true;

		public bool CanRotate = true;

		public bool IsMoving;

		public bool IsRunning;

		public bool IsSprinting;

		public bool IsCrouched;

		public bool IsProne;

		public bool CanJump;

		public bool IsJumping;

		public bool IsGrounded = true;

		public bool IsSliding;

		public bool IsMeleeAttacking;

		public bool IsPunching;

		public bool IsItemEquiped;

		public bool IsDualWielding;

		public bool IsAiming;

		public bool FiringMode;

		public bool FiringModeIK = true;

		public bool ToPickupItem;

		public bool IsRolling;

		public bool IsRagdolled;

		public bool IsDriving;

		public bool ToEnterVehicle;

		public bool UsedItem;

		public bool IsReloading;

		public bool WallAHead;

		public bool IsWeaponSwitching;

		public bool InverseKinematics = true;

		public bool IsArtificialIntelligence;

		private float hammerWaitTime = 1f;

		private float waitTimeCounter = 1f;

		[HideInInspector]
		private Vector3 oldEulerAngles;

		private bool UsedRightItem;

		private HoldableItem oldDualItem;

		[HideInInspector]
		protected Transform SpineLookATTransform;

		[HideInInspector]
		protected Quaternion OriginalSpineRotation;

		[HideInInspector]
		protected Vector3 SmoothedSpineLookAtPosition;

		[HideInInspector]
		protected Vector3 TargetSpineLookAtPosition;

		private void OnDestroy()
		{
			if (PivotItemRotation != null)
			{
				Object.Destroy(PivotItemRotation);
			}
		}

		protected virtual void Awake()
		{
			CanMove = true;
			CanRotate = true;
			UpDirection = Vector3.up;
			anim = GetComponent<Animator>();
			networkAnimator = GetComponent<NetworkAnimator>();
			rb = GetComponent<Rigidbody>();
			coll = GetComponent<Collider>();
			if ((int)WhatIsGround == 0)
			{
				WhatIsGround = LayerMask.GetMask("Default", "Terrain", "Walls", "VehicleMeshCollider", "Vehicle", "TrainGround");
			}
			if ((int)WhatIsWall == 0)
			{
				WhatIsWall = LayerMask.GetMask("Default", "Terrain", "Walls", "VehicleMeshCollider", "Vehicle", "TrainGround");
			}
			DirectionTransform = CreateEmptyTransform("Direction Transform", base.transform.position, base.transform.rotation, base.transform, hide: true);
			LeftHandIKPositionTarget = CreateEmptyTransform("Left Hand Target", base.transform.position, base.transform.rotation, base.transform);
			RightHandIKPositionTarget = CreateEmptyTransform("Right Hand Target", base.transform.position, base.transform.rotation, base.transform);
			IKPositionLeftHand = CreateEmptyTransform("Left Hand IK Position", base.transform.position, base.transform.rotation, base.transform, hide: true);
			IKPositionRightHand = CreateEmptyTransform("Right Hand IK Position", base.transform.position, base.transform.rotation, base.transform, hide: true);
			FiringMode = false;
			ArmsWeightIK = 0f;
			CharacterHitBoxes = GetComponentsInChildren<Collider>();
			Collider[] characterHitBoxes = CharacterHitBoxes;
			foreach (Collider collider in characterHitBoxes)
			{
				if (collider != coll)
				{
					Physics.IgnoreCollision(coll, collider);
				}
			}
			PivotItemRotation = GetComponentInChildren<WeaponAimRotationCenter>().gameObject;
			WeaponHoldingPositions = PivotItemRotation.GetComponentInChildren<WeaponAimRotationCenter>();
			CurrentItemIDRightHand = -1;
			WeaponInUseRightHand = null;
			HoldableItemInUseRightHand = null;
			MyPivotCamera = ((!IsArtificialIntelligence) ? Object.FindObjectOfType<JUCameraController>() : null);
			MyCamera = ((MyPivotCamera != null && !IsArtificialIntelligence) ? MyPivotCamera.mCamera : null);
			if (HumanoidSpine == null)
			{
				HumanoidSpine = anim.GetLastSpineBone();
			}
			if (TryGetComponent<JUHealth>(out var component))
			{
				CharacterHealth = component;
				CharacterHealth.OnDeath.AddListener(DisableDamagers);
			}
			if (TryGetComponent<JUInventory>(out var component2))
			{
				Inventory = component2;
			}
			if (TryGetComponent<AdvancedRagdollController>(out var component3))
			{
				Ragdoller = component3;
			}
			if (TryGetComponent<JUFootPlacement>(out var component4))
			{
				FootPlacerIK = component4;
			}
			if (TryGetComponent<DriveVehicles>(out var component5))
			{
				DriveVehicleAbility = component5;
			}
			if (LeftHandDamager == null)
			{
				LeftHandDamager = GetLeftHandDamager();
			}
			if (RightHandDamager == null)
			{
				RightHandDamager = GetRightHandDamager();
			}
			if (LeftFootDamager == null)
			{
				LeftFootDamager = GetLeftFootDamager();
			}
			if (RightFootDamager == null)
			{
				RightFootDamager = GetRightFootDamager();
			}
		}

		public Vector3 GetLookPosition()
		{
			if (MyCamera == null)
			{
				return LookAtPosition;
			}
			if (LookAtPosition != Vector3.zero)
			{
				return LookAtPosition;
			}
			return MyCamera.transform.position + MyCamera.transform.forward * 100f;
		}

		public Vector3 GetLookDirectionEulerAngles()
		{
			Vector3 eulerAngles = Quaternion.LookRotation(LookAtPosition - PivotItemRotation.transform.position).eulerAngles;
			if (MyCamera != null && LookAtPosition == Vector3.zero)
			{
				eulerAngles = MyCamera.transform.eulerAngles;
			}
			return eulerAngles;
		}

		public Vector3 GetCurrentWeaponLookDirection(bool RightHand = true)
		{
			Vector3 result = Vector3.up;
			if (RightHand)
			{
				if (WeaponInUseRightHand != null)
				{
					result = (GetLookPosition() - WeaponInUseRightHand.Shoot_Position.position).normalized;
				}
			}
			else if (WeaponInUseLeftHand != null)
			{
				result = (GetLookPosition() - WeaponInUseLeftHand.Shoot_Position.position).normalized;
			}
			return result;
		}

		public void SetForwardOrientation(Quaternion forwardRotation)
		{
			ForwardOrientation = forwardRotation;
		}

		public Quaternion GetForwardOrientation()
		{
			Quaternion result = ((MyCamera == null || ForwardOrientation != Quaternion.identity) ? ForwardOrientation : MyCamera.transform.rotation);
			if (IsArtificialIntelligence && MyPivotCamera != null)
			{
				MyPivotCamera = null;
				MyCamera = null;
				result = ForwardOrientation;
			}
			return result;
		}

		public virtual void ResetDefaultLayersWeight(float Speed = 0f, bool LegLayerException = false, bool RightArmLayerException = false, bool LeftArmLayerException = false, bool BothArmsLayerException = false, bool WeaponSwitchLayerException = false)
		{
			if (Speed == 0f)
			{
				if (!LegLayerException)
				{
					LegsLayerWeight = 0f;
				}
				if (!RightArmLayerException)
				{
					RightArmLayerWeight = 0f;
				}
				if (!LeftArmLayerException)
				{
					LeftArmLayerWeight = 0f;
				}
				if (!BothArmsLayerException)
				{
					BothArmsLayerWeight = 0f;
				}
				if (!WeaponSwitchLayerException)
				{
					WeaponSwitchLayerWeight = 0f;
				}
			}
			else
			{
				if (!LegLayerException)
				{
					LegsLayerWeight = Mathf.Lerp(LegsLayerWeight, 0f, Speed * Time.deltaTime);
				}
				if (!RightArmLayerException)
				{
					RightArmLayerWeight = Mathf.Lerp(RightArmLayerWeight, 0f, Speed * Time.deltaTime);
				}
				if (!LeftArmLayerException)
				{
					LeftArmLayerWeight = Mathf.Lerp(LeftArmLayerWeight, 0f, Speed * Time.deltaTime);
				}
				if (!BothArmsLayerException)
				{
					BothArmsLayerWeight = Mathf.Lerp(BothArmsLayerWeight, 0f, Speed * Time.deltaTime);
				}
				if (!WeaponSwitchLayerException)
				{
					WeaponSwitchLayerWeight = Mathf.Lerp(WeaponSwitchLayerWeight, 0f, Speed * Time.deltaTime);
				}
			}
		}

		public virtual void SetDefaultAnimatorsLayersWeight(JUAnimatorParameters parameters, float LegsWeight, float RightArmWeight, float LeftArmWeight, float BothArmsWeight, float WeaponSwitchWeight, float TorsoLayerWeight, float LegsOverrideLayerWeight, float FullBodyLayerWeight)
		{
			anim.SetLayerWeight(parameters._LegsLayerIndex, LegsWeight);
			anim.SetLayerWeight(parameters._RightArmLayerIndex, RightArmWeight);
			anim.SetLayerWeight(parameters._LeftArmLayerIndex, LeftArmWeight);
			anim.SetLayerWeight(parameters._BothArmsLayerIndex, BothArmsWeight);
			anim.SetLayerWeight(parameters._SwitchWeaponLayerIndex, WeaponSwitchWeight);
			anim.SetLayerWeight(parameters._torsoLayerIndex, TorsoLayerWeight);
			anim.SetLayerWeight(parameters._legsOverrideLayerIndex, LegsOverrideLayerWeight);
			anim.SetLayerWeight(parameters._fullBodyLayerIndex, FullBodyLayerWeight);
		}

		public Transform GetLastSpineBone()
		{
			if (anim == null)
			{
				return null;
			}
			return anim.GetBoneTransform(HumanBodyBones.Head).parent.parent;
		}

		private Damager GetRightHandDamager()
		{
			if (RightHandDamager != null)
			{
				return RightHandDamager;
			}
			Damager result = null;
			Damager[] componentsInChildren = GetComponentsInChildren<Damager>();
			foreach (Damager damager in componentsInChildren)
			{
				if (damager.transform.parent == anim.GetBoneTransform(HumanBodyBones.RightLowerArm))
				{
					result = damager;
				}
			}
			return result;
		}

		private Damager GetLeftHandDamager()
		{
			if (LeftHandDamager != null)
			{
				return LeftHandDamager;
			}
			Damager result = null;
			Damager[] componentsInChildren = GetComponentsInChildren<Damager>();
			foreach (Damager damager in componentsInChildren)
			{
				if (damager.transform.parent == anim.GetBoneTransform(HumanBodyBones.LeftLowerArm))
				{
					result = damager;
				}
			}
			return result;
		}

		private Damager GetLeftFootDamager()
		{
			if (LeftFootDamager != null)
			{
				return LeftFootDamager;
			}
			Damager result = null;
			Damager[] componentsInChildren = GetComponentsInChildren<Damager>();
			foreach (Damager damager in componentsInChildren)
			{
				if (damager.transform.parent == anim.GetBoneTransform(HumanBodyBones.LeftUpperLeg))
				{
					result = damager;
				}
			}
			return result;
		}

		private Damager GetRightFootDamager()
		{
			if (RightFootDamager != null)
			{
				return RightFootDamager;
			}
			Damager result = null;
			Damager[] componentsInChildren = GetComponentsInChildren<Damager>();
			foreach (Damager damager in componentsInChildren)
			{
				if (damager.transform.parent == anim.GetBoneTransform(HumanBodyBones.RightUpperLeg))
				{
					result = damager;
				}
			}
			return result;
		}

		public void DisableDamagers()
		{
			if (LeftFootDamager != null)
			{
				LeftFootDamager.gameObject.SetActive(value: false);
			}
			if (RightFootDamager != null)
			{
				RightFootDamager.gameObject.SetActive(value: false);
			}
			if (LeftHandDamager != null)
			{
				LeftHandDamager.gameObject.SetActive(value: false);
			}
			if (RightHandDamager != null)
			{
				RightHandDamager.gameObject.SetActive(value: false);
			}
		}

		public void PhysicalIgnore(GameObject GameObjectToIgnore, bool ignore)
		{
			Collider[] componentsInChildren = GameObjectToIgnore.GetComponentsInChildren<Collider>(includeInactive: true);
			if (componentsInChildren.Length == 0)
			{
				Debug.Log("There is not colliders in " + GameObjectToIgnore.name + " to ignore");
				return;
			}
			if (componentsInChildren.Length == 1)
			{
				PhysicalIgnore(componentsInChildren[0], ignore);
				return;
			}
			Collider[] array = componentsInChildren;
			foreach (Collider collider in array)
			{
				Collider[] characterHitBoxes = CharacterHitBoxes;
				foreach (Collider collider2 in characterHitBoxes)
				{
					Physics.IgnoreCollision(collider, collider2, ignore);
				}
			}
		}

		public void PhysicalIgnore(Collider col, bool ignore)
		{
			Collider[] characterHitBoxes = CharacterHitBoxes;
			foreach (Collider collider in characterHitBoxes)
			{
				Physics.IgnoreCollision(col, collider, ignore);
			}
		}

		protected Transform CreateEmptyTransform(string name = "New Transform", Vector3 position = default(Vector3), Quaternion rotation = default(Quaternion), Transform parent = null, bool hide = false)
		{
			Transform transform = new GameObject(name).transform;
			transform.position = position;
			transform.rotation = rotation;
			transform.parent = parent;
			if (hide)
			{
				transform.hideFlags = HideFlags.HideInHierarchy;
				transform.gameObject.hideFlags = HideFlags.HideAndDontSave;
			}
			return transform;
		}

		public void SetMoveInput(float HorizontalInput, float VerticalInput, float Smooth = -1f)
		{
			if (Smooth <= 0f)
			{
				HorizontalX = HorizontalInput;
				VerticalY = VerticalInput;
			}
			else
			{
				HorizontalX = Mathf.Lerp(HorizontalX, HorizontalInput, Smooth * Time.deltaTime);
				VerticalY = Mathf.Lerp(VerticalY, VerticalInput, Smooth * Time.deltaTime);
			}
		}

		public virtual void Rotate(float HorizontalX, float VerticalY)
		{
			if (IsDriving || !CanRotate)
			{
				return;
			}
			DesiredCameraRotation = GetForwardOrientation();
			DesiredDirection = new Vector3(HorizontalX, 0f, VerticalY);
			Vector3 localEulerAngles = base.transform.localEulerAngles;
			if (IsMoving)
			{
				if (Mathf.Abs(HorizontalX) > 0.01f || Mathf.Abs(VerticalY) > 0.01f)
				{
					DirectionTransform.rotation = DesiredCameraRotation * Quaternion.LookRotation(DesiredDirection.normalized);
					if (Vector3.Dot(base.transform.up, Vector3.up) < -0.989f)
					{
						DirectionTransform.rotation = lastDirectionTransformRotation;
					}
					else
					{
						lastDirectionTransformRotation = DirectionTransform.rotation;
					}
				}
				if (LerpRotation)
				{
					localEulerAngles.y = Mathf.LerpAngle(localEulerAngles.y, DirectionTransform.eulerAngles.y, ((IsProne || IsCrouched) ? 0.5f : 1f) * RotationSpeed * Time.deltaTime);
				}
				else
				{
					localEulerAngles.y = Mathf.MoveTowardsAngle(localEulerAngles.y, DirectionTransform.eulerAngles.y, ((IsProne || IsCrouched) ? 0.5f : 1f) * 100f * RotationSpeed * Time.deltaTime);
				}
			}
			bool flag = HoldableItemInUseRightHand != null && HoldableItemInUseRightHand.BlockFireMode;
			if (LocomotionMode == MovementMode.TpsFixed)
			{
				LookRotationToAimPosition((LookAtPosition != Vector3.zero) ? LookAtPosition : (MyCamera.transform.position + MyCamera.transform.forward * 100f), RotationSpeed, UpOrientation * Vector3.up);
			}
			else if (FiringMode && !flag && !IsRolling)
			{
				if (MyCamera != null)
				{
					LookRotationToAimPosition((LookAtPosition != Vector3.zero) ? LookAtPosition : (MyCamera.transform.position + MyCamera.transform.forward * 100f), RotationSpeed, UpOrientation * Vector3.up);
				}
				else
				{
					LookRotationToAimPosition(LookAtPosition, RotationSpeed, UpOrientation * Vector3.up);
				}
			}
			else if (!RootMotionRotation || !RootMotion)
			{
				if (CurvedMovement)
				{
					base.transform.localEulerAngles = localEulerAngles;
				}
				else if (Mathf.Abs(HorizontalX) > 0.01f || Mathf.Abs(VerticalY) > 0.01f)
				{
					DirectionTransform.rotation = Quaternion.FromToRotation(DirectionTransform.up, UpDirection) * DirectionTransform.rotation;
					base.transform.rotation = Quaternion.Lerp(base.transform.rotation, DirectionTransform.rotation, (IsRolling ? (1.5f * RotationSpeed) : RotationSpeed) * Time.deltaTime);
				}
			}
			Quaternion quaternion = Quaternion.FromToRotation(base.transform.up, IsProne ? GroundNormal : UpDirection);
			UpDirection = ((GroundNormal == Vector3.zero) ? Vector3.up : UpDirection);
			UpOrientation = Quaternion.Lerp(base.transform.rotation, quaternion * base.transform.rotation, IsGrounded ? (8f * Time.deltaTime) : (2f * Time.deltaTime));
			base.transform.rotation = UpOrientation;
			DirectionTransform.rotation = Quaternion.FromToRotation(DirectionTransform.up, UpDirection) * DirectionTransform.rotation;
			Debug.DrawRay(DirectionTransform.position, DirectionTransform.forward);
		}

		public virtual void DoLookAt(Vector3 targetPosition = default(Vector3), float RotationSpeedMultiplier = 1f, bool FreezeUpDirection = true)
		{
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, Quaternion.LookRotation(targetPosition - base.transform.position), RotationSpeedMultiplier * RotationSpeed * Time.deltaTime);
			if (FreezeUpDirection)
			{
				base.transform.rotation = Quaternion.FromToRotation(base.transform.up, UpDirection) * base.transform.rotation;
			}
		}

		public virtual void MoveForward(float SpeedMultiplier)
		{
			if (SetRigidbodyVelocity)
			{
				Vector3 vector = base.transform.InverseTransformDirection(rb.velocity);
				rb.velocity = base.transform.forward * SpeedMultiplier * Speed + base.transform.up * vector.y;
				rb.velocity = rb.velocity;
			}
			else
			{
				base.transform.Translate(Vector3.forward * SpeedMultiplier * Speed * Time.deltaTime, Space.Self);
			}
		}

		public virtual void Move(Vector3 Movement, float SpeedMultiplier)
		{
			if (SetRigidbodyVelocity)
			{
				rb.velocity = Movement * SpeedMultiplier * Speed;
			}
			else
			{
				base.transform.Translate(Movement * SpeedMultiplier * Speed * Time.deltaTime, Space.World);
			}
		}

		public virtual void Move(Transform DirectionMovement, float SpeedMultiplier)
		{
			if (SetRigidbodyVelocity)
			{
				Vector3 vector = DirectionMovement.InverseTransformDirection(rb.velocity);
				rb.velocity = DirectionMovement.forward * SpeedMultiplier * Speed + base.transform.up * vector.y;
			}
			else
			{
				base.transform.Translate(DirectionMovement.forward * SpeedMultiplier * Speed * Time.deltaTime, Space.World);
			}
		}

		public virtual void MoveDirectional(float SpeedMultiplier)
		{
			if (SetRigidbodyVelocity)
			{
				Vector3 vector = base.transform.InverseTransformDirection(rb.velocity);
				rb.velocity = DirectionTransform.forward * SpeedMultiplier * Speed + base.transform.up * vector.y;
			}
			else
			{
				base.transform.Translate(DirectionTransform.forward * SpeedMultiplier * Speed * Time.deltaTime, Space.World);
			}
		}

		public void InAirMovementControl(bool JumpInert = true)
		{
			if (IsGrounded)
			{
				if (JumpInert)
				{
					LastX = HorizontalX;
					LastY = VerticalY;
					LastVelMult = VelocityMultiplier;
					CanMove = true;
				}
				return;
			}
			base.transform.Translate(0f, -0.2f * Time.deltaTime, 0f);
			if (SetRigidbodyVelocity)
			{
				if (IsMoving)
				{
					rb.AddForce(DirectionTransform.forward * AirInfluenceControll * 10f, ForceMode.Force);
				}
			}
			else if (IsMoving)
			{
				base.transform.Translate(DirectionTransform.forward * AirInfluenceControll / 10f * Time.deltaTime, Space.World);
			}
		}

		protected virtual void LookRotationToAimPosition(Vector3 Position = default(Vector3), float RotationSpeed = 10f, Vector3 Up_Direction = default(Vector3))
		{
			if (!IsRolling)
			{
				Vector3 normalized = (Position - base.transform.position).normalized;
				base.transform.rotation = Quaternion.Lerp(base.transform.rotation, Quaternion.FromToRotation(base.transform.forward, normalized) * base.transform.rotation, 3f * RotationSpeed * Time.fixedDeltaTime);
				base.transform.rotation = Quaternion.FromToRotation(base.transform.up, (Up_Direction != Vector3.zero) ? Up_Direction : Vector3.up) * base.transform.rotation;
			}
		}

		protected virtual void FireModeTimer(bool ShotInput, bool AimInput)
		{
			if (CurrentTimeToDisableFireMode < 20f && FiringMode && !IsMeleeAttacking && !IsReloading && !ShotInput && !AimInput)
			{
				CurrentTimeToDisableFireMode += Time.deltaTime;
				if (CurrentTimeToDisableFireMode >= FireModeMaxTime)
				{
					FiringMode = false;
					FiringModeIK = false;
					CurrentTimeToDisableFireMode = 0f;
				}
				if (IsAiming)
				{
					CurrentTimeToDisableFireMode = 0f;
				}
			}
			else
			{
				CurrentTimeToDisableFireMode = 0f;
			}
		}

		protected virtual void DoFireModeMovement(bool FiringMode, bool isFixedTpsActive = false)
		{
			if (!IsDriving && (FiringMode || isFixedTpsActive) && !IsRolling)
			{
				if (CanMove && IsGrounded)
				{
					MoveDirectional(VelocityMultiplier);
				}
				IsArmedWeight = Mathf.Lerp(IsArmedWeight, 1f, 5f * Time.deltaTime);
				if (IsRunning && !IsSprinting && !WallAHead && IsGrounded && IsMoving)
				{
					VelocityMultiplier = Mathf.Lerp(VelocityMultiplier, 1.3f - GroundAngleDesacelerationValue(), 5f * Time.deltaTime);
				}
				if (!IsRunning && !IsSprinting && !WallAHead && IsGrounded && IsMoving)
				{
					VelocityMultiplier = Mathf.Lerp(VelocityMultiplier, 0.5f - GroundAngleDesacelerationValue(), 5f * Time.deltaTime);
				}
				if (!IsMoving)
				{
					VelocityMultiplier = Mathf.Lerp(VelocityMultiplier, 0f, 5f * Time.deltaTime);
				}
				MaxSprintSpeed = false;
				CanSprint = true;
				SprintSpeedDecrease = 0f;
				IsSprinting = false;
			}
		}

		protected virtual void DoFreeMovement(bool FiringMode, bool isFixedTpsActive = false)
		{
			if (IsDriving || FiringMode || isFixedTpsActive)
			{
				return;
			}
			IsArmedWeight = Mathf.Lerp(IsArmedWeight, 0f, 3f * Time.deltaTime);
			if (IsGrounded && CanMove && !RootMotion)
			{
				if (CurvedMovement)
				{
					MoveForward(VelocityMultiplier);
				}
				else
				{
					Move(DirectionTransform, VelocityMultiplier);
				}
			}
			Sprinting();
			if (IsMoving && !IsMeleeAttacking && !IsPunching)
			{
				if (IsRunning && !WallAHead)
				{
					VelocityMultiplier = Mathf.Lerp(VelocityMultiplier, 1.4f - GroundAngleDesacelerationValue(), 6f * Time.deltaTime);
				}
				else if (!WallAHead)
				{
					VelocityMultiplier = Mathf.Lerp(VelocityMultiplier, 0.5f - GroundAngleDesacelerationValue(), 6f * Time.deltaTime);
					IsSprinting = false;
					SprintSpeedDecrease = Mathf.Lerp(SprintSpeedDecrease, 0f, 6f * Time.deltaTime);
				}
				return;
			}
			if (IsGrounded)
			{
				VelocityMultiplier = Mathf.MoveTowards(VelocityMultiplier, 0f, (StoppingSpeed + Mathf.Lerp(0f, 0.5f, VelocityMultiplier)) * Time.deltaTime);
			}
			IsRunning = false;
			IsSprinting = false;
			MaxSprintSpeed = false;
			SprintSpeedDecrease = Mathf.MoveTowards(SprintSpeedDecrease, 0f, 3f * Time.deltaTime);
			CanSprint = true;
		}

		protected Vector3 WordSpaceToBlendTreeSpace(Vector3 LookAtPosition, Transform DirectionTransform)
		{
			Vector3 vector = default(Vector3);
			vector = DirectionTransform.forward;
			float num = 0f;
			if (vector.magnitude > 0f)
			{
				Vector3 rhs = LookAtPosition - base.transform.position;
				rhs.Normalize();
				num = Mathf.Clamp(Vector3.Dot(vector, rhs), -1f, 1f);
				new Vector3(rhs.z, 0f, 0f - rhs.x);
				return new Vector3(Mathf.Clamp(Vector3.Dot(vector, base.transform.right), -1f, 1f), 0f, num).normalized;
			}
			return vector;
		}

		protected virtual void CalculateBodyRotation(ref float bodyRotation)
		{
			if (IsMoving && BodyInclination && CanMove && !WallAHead)
			{
				if (IsGrounded)
				{
					bodyRotation = Mathf.LerpAngle(bodyRotation, DesiredRotationAngle() / 180f, 2.5f * Time.deltaTime);
					if (Mathf.Abs(DesiredRotationAngle()) < 10f)
					{
						bodyRotation = Mathf.LerpAngle(bodyRotation, 0f, 2f * Time.deltaTime);
					}
				}
				else
				{
					bodyRotation = Mathf.Lerp(bodyRotation, 0f, 8f * Time.deltaTime);
				}
			}
			else
			{
				bodyRotation = Mathf.Lerp(bodyRotation, 0f, 8f * Time.deltaTime);
			}
		}

		public void CalculateRotationIntensity(ref float RotationIntensity, float Multiplier = 2f)
		{
			float b = Multiplier * Vector3.SignedAngle(base.transform.forward, Quaternion.Euler(oldEulerAngles) * Vector3.forward, base.transform.up);
			RotationIntensity = Mathf.LerpAngle(RotationIntensity, b, 5f * Time.deltaTime);
			oldEulerAngles = base.transform.eulerAngles;
		}

		protected float DesiredRotationAngle()
		{
			return Vector3.SignedAngle(base.transform.forward, DirectionTransform.forward, base.transform.up);
		}

		protected virtual void Sprinting()
		{
			if (!SprintingSkill)
			{
				return;
			}
			if (IsSprinting && !IsPunching)
			{
				if (VelocityMultiplier < 2f && !MaxSprintSpeed)
				{
					if (SprintSpeedDecrease < 10f)
					{
						SprintSpeedDecrease += 2f * Time.deltaTime;
					}
					VelocityMultiplier += (SprintSpeedDecrease - GroundAngleDesacelerationValue() * 10f) * Time.deltaTime;
					if (GroundAngleDesaceleration)
					{
						if (VelocityMultiplier > 1.9f || GroundAngle > 20f)
						{
							MaxSprintSpeed = true;
						}
					}
					else if (VelocityMultiplier > 1.9f)
					{
						MaxSprintSpeed = true;
					}
				}
				if (MaxSprintSpeed)
				{
					SprintSpeedDecrease -= 0.6f * Time.deltaTime;
					VelocityMultiplier += (SprintSpeedDecrease - GroundAngleDesacelerationValue() * 10f) * Time.deltaTime;
					if (VelocityMultiplier < 1.4f)
					{
						CanSprint = false;
						IsSprinting = false;
						MaxSprintSpeed = false;
					}
				}
			}
			if (IsRunning && CanSprint && !IsSprinting)
			{
				IsSprinting = true;
			}
		}

		protected virtual void GroundCheck()
		{
			if (!IsDriving)
			{
				if (Physics.OverlapBox(base.transform.position + base.transform.up * GroundCheckHeighOfsset, new Vector3(GroundCheckRadius, GroundCheckSize, GroundCheckRadius), base.transform.rotation, WhatIsGround).Length != 0 && !IsJumping)
				{
					IsGrounded = true;
				}
				else if (IsGrounded)
				{
					if (!SetRigidbodyVelocity)
					{
						rb.AddForce(DirectionTransform.forward * LastVelMult * rb.mass * Speed, ForceMode.Impulse);
					}
					IsGrounded = false;
				}
			}
			if (Physics.Raycast(base.transform.position + base.transform.up * 0.5f, -base.transform.up, out var hitInfo, 2f, WhatIsGround))
			{
				GroundAngle = Vector3.Angle(Vector3.up, hitInfo.normal);
				GroundNormal = hitInfo.normal;
				GroundPoint = hitInfo.point;
			}
			else
			{
				GroundNormal = Vector3.zero;
				GroundAngle = 0f;
				GroundPoint = Vector3.zero;
			}
		}

		protected Vector3 GetGroundPoint()
		{
			if (Physics.Raycast(base.transform.position + base.transform.up * 0.5f, -base.transform.up, out var hitInfo, 1000f, WhatIsGround))
			{
				GroundPoint = hitInfo.point;
			}
			else
			{
				GroundPoint = Vector3.zero;
			}
			return GroundPoint;
		}

		protected virtual void WallAHeadCheck()
		{
			if (Physics.Raycast(base.transform.position + base.transform.up * WallRayHeight, DirectionTransform.forward, out var hitInfo, WallRayDistance, WhatIsWall))
			{
				WallAHead = true;
				Debug.DrawLine(hitInfo.point, base.transform.position + base.transform.up * WallRayHeight);
			}
			else
			{
				WallAHead = false;
			}
			if (WallAHead)
			{
				VelocityMultiplier = Mathf.Lerp(VelocityMultiplier, 0f, 10f * Time.deltaTime);
				SprintSpeedDecrease = 0f;
			}
		}

		protected virtual void SlopeSlide()
		{
			if (GroundAngle > MaxWalkableAngle)
			{
				if (!IsSliding)
				{
					IsSliding = true;
				}
				else if (MaxWalkableAngle > 0f)
				{
					SlidingVelocity += 2f * Physics.gravity.y * Time.deltaTime;
					base.transform.Translate(-GroundNormal * SlidingVelocity * Time.deltaTime, Space.World);
					base.transform.Translate(Vector3.up * SlidingVelocity * Time.deltaTime, Space.World);
				}
			}
			else
			{
				SlidingVelocity = -10f;
				IsSliding = false;
			}
		}

		protected float StepAngle()
		{
			float result = 0f;
			if (Step_Hit.point != Vector3.zero)
			{
				result = Vector3.Angle(base.transform.up, Step_Hit.normal);
			}
			return result;
		}

		public float GroundAngleDesacelerationValue()
		{
			if (GroundAngleDesaceleration && !IsProne)
			{
				float num = Mathf.Clamp(GroundAngle, 0f, 60f);
				float num2 = ((!IsRunning) ? (num / 700f) : (num / 200f));
				return num2 * GroundAngleDesacelerationMultiplier;
			}
			return 0f;
		}

		protected virtual void StepCorrectionCalculation()
		{
			if (IsDriving || !CanMove)
			{
				return;
			}
			if (IsMoving && EnableStepCorrection)
			{
				if (Physics.Raycast(base.transform.position + base.transform.up * FootstepHeight + DirectionTransform.forward * ForwardStepOffset, -Vector3.up, out Step_Hit, FootstepHeight - StepHeight, WhatIsGround) && !AdjustHeight)
				{
					if (Step_Hit.point.y > base.transform.position.y && StepAngle() < 10f)
					{
						AdjustHeight = true;
					}
				}
				else
				{
					Step_Hit.point = base.transform.position;
					AdjustHeight = false;
				}
			}
			else
			{
				AdjustHeight = false;
				Step_Hit.point = base.transform.position;
			}
			if (!AdjustHeight)
			{
				Step_Hit.point = base.transform.position;
			}
		}

		protected virtual void StepCorrectionMovement()
		{
			if (AdjustHeight && IsMoving && !IsDriving)
			{
				base.transform.position += base.transform.up * (UpStepSpeed / 2f + UpStepSpeed / 2f * VelocityMultiplier) * Time.fixedDeltaTime;
				rb.AddForce(base.transform.up * rb.mass / 8f * UpStepSpeed, ForceMode.Impulse);
				if (Step_Hit.point.y < base.transform.position.y - 1E-05f)
				{
					Step_Hit.point = base.transform.position;
					AdjustHeight = false;
				}
			}
		}

		protected virtual void ApplyRootMotionOnLocomotion()
		{
			if (RootMotion && IsGrounded && !IsJumping && !FiringMode && !IsDriving && (!(Ragdoller != null) || Ragdoller.State == AdvancedRagdollController.RagdollState.Animated))
			{
				anim.updateMode = AnimatorUpdateMode.AnimatePhysics;
				RootMotionDeltaPosition = anim.deltaPosition * Time.fixedDeltaTime;
				RootMotionDeltaPosition.y = 0f;
				if (Time.timeScale == 1f)
				{
					rb.velocity = RootMotionDeltaPosition * 5000f * RootMotionSpeed + Vector3.up * rb.velocity.y;
				}
				else if (CurvedMovement)
				{
					rb.velocity = base.transform.forward * VelocityMultiplier * Speed + Vector3.up * rb.velocity.y;
				}
				else
				{
					rb.velocity = DirectionTransform.forward * VelocityMultiplier * Speed + Vector3.up * rb.velocity.y;
				}
				if (RootMotionRotation)
				{
					base.transform.Rotate(0f, anim.deltaRotation.y * 160f, 0f);
				}
			}
		}

		protected virtual void UseRightHandItem(bool ShotInput, bool ShotDownInput)
		{
			if (HoldableItemInUseRightHand == null || HoldableItemInUseRightHand is Weapon || HoldableItemInUseRightHand is MeleeWeapon || !IsItemEquiped || IsRolling)
			{
				return;
			}
			IsAiming = false;
			bool flag = false;
			if (HoldableItemInUseRightHand is ThrowableItem && ShotDownInput)
			{
				anim.SetTrigger((HoldableItemInUseRightHand as ThrowableItem).AnimationTriggerParameterName);
				return;
			}
			if (HoldableItemInUseRightHand.ContinuousUseItem)
			{
				if (ShotInput)
				{
					if (!IsRolling && !IsDriving && HoldableItemInUseRightHand.CanUseItem)
					{
						UseEquipedItem();
					}
					else
					{
						HoldableItemInUseRightHand.StopUseItem();
					}
				}
				else
				{
					HoldableItemInUseRightHand.StopUseItem();
				}
			}
			else
			{
				if (ShotInput && !HoldableItemInUseRightHand.IsUsingItem)
				{
					if (!IsRolling && !IsDriving && flag)
					{
						UseEquipedItem();
					}
					else
					{
						HoldableItemInUseRightHand.StopUseItem();
					}
				}
				else
				{
					HoldableItemInUseRightHand.StopUseItem();
				}
				HoldableItemInUseRightHand.StopUseItem();
			}
			if (!HoldableItemInUseRightHand.ContinuousUseItem)
			{
				flag = !ShotInput;
			}
		}

		protected virtual void UseLeftHandItem(bool ShotInput, bool ShotDownInput)
		{
			if (HoldableItemInUseLeftHand == null || HoldableItemInUseLeftHand is Weapon || HoldableItemInUseLeftHand is MeleeWeapon)
			{
				return;
			}
			Debug.Log("Is Left Hand Holdable Item selected");
			if (!FiringMode || !IsItemEquiped || IsRolling)
			{
				return;
			}
			IsAiming = false;
			bool flag = false;
			if (HoldableItemInUseLeftHand is ThrowableItem && ShotDownInput)
			{
				anim.SetTrigger((HoldableItemInUseLeftHand as ThrowableItem).AnimationTriggerParameterName);
				return;
			}
			if (HoldableItemInUseLeftHand.ContinuousUseItem)
			{
				if (ShotInput)
				{
					if (!IsRolling && !IsDriving && ArmsWeightIK > 0.7f && HoldableItemInUseLeftHand.CanUseItem)
					{
						UseEquipedItem();
					}
					else
					{
						HoldableItemInUseLeftHand.StopUseItem();
					}
				}
				else
				{
					HoldableItemInUseLeftHand.StopUseItem();
				}
			}
			else
			{
				if (ShotInput && !HoldableItemInUseLeftHand.IsUsingItem)
				{
					if (!IsRolling && !IsDriving && ArmsWeightIK > 0.7f && flag)
					{
						UseEquipedItem();
					}
					else
					{
						HoldableItemInUseLeftHand.StopUseItem();
					}
				}
				else
				{
					HoldableItemInUseLeftHand.StopUseItem();
				}
				HoldableItemInUseLeftHand.StopUseItem();
			}
			if (!HoldableItemInUseLeftHand.ContinuousUseItem)
			{
				flag = !ShotInput;
			}
		}

		public virtual void UseMeleeWeapons(bool AttackInputDown)
		{
			if (HoldableItemInUseRightHand == null && HoldableItemInUseLeftHand == null)
			{
				IsMeleeAttacking = false;
			}
			else
			{
				if ((HoldableItemInUseRightHand != null && !(HoldableItemInUseRightHand is MeleeWeapon)) || (HoldableItemInUseLeftHand != null && !(HoldableItemInUseLeftHand is MeleeWeapon)))
				{
					return;
				}
				IsMeleeAttacking = MeleeWeaponInUseLeftHand != null && MeleeWeaponInUseLeftHand.IsUsingItem;
				IsMeleeAttacking = MeleeWeaponInUseRightHand != null && MeleeWeaponInUseRightHand.IsUsingItem;
				if (!AttackInputDown)
				{
					return;
				}
				if (MeleeWeaponInUseLeftHand != null && MeleeWeaponInUseRightHand == null)
				{
					if (MeleeWeaponInUseLeftHand.randomAnimCount > 0)
					{
						for (int i = 1; i < MeleeWeaponInUseRightHand.randomAnimCount + 1; i++)
						{
							if (!MeleeWeaponInUseLeftHand.isBlockedToUse)
							{
								networkAnimator.ResetTrigger(MeleeWeaponInUseLeftHand.AttackAnimatorParameterName + i);
							}
						}
						if (!MeleeWeaponInUseLeftHand.isBlockedToUse)
						{
							networkAnimator.SetTrigger(MeleeWeaponInUseLeftHand.AttackAnimatorParameterName + Random.Range(1, MeleeWeaponInUseLeftHand.randomAnimCount + 1));
						}
					}
					else if (!MeleeWeaponInUseLeftHand.isBlockedToUse)
					{
						networkAnimator.SetTrigger(MeleeWeaponInUseLeftHand.AttackAnimatorParameterName);
					}
				}
				if (!(MeleeWeaponInUseRightHand != null))
				{
					return;
				}
				if (MeleeWeaponInUseRightHand.randomAnimCount > 0)
				{
					for (int j = 1; j < MeleeWeaponInUseRightHand.randomAnimCount + 1; j++)
					{
						if (!MeleeWeaponInUseRightHand.isBlockedToUse)
						{
							networkAnimator.ResetTrigger(MeleeWeaponInUseRightHand.AttackAnimatorParameterName + j);
						}
					}
					if (!MeleeWeaponInUseRightHand.isBlockedToUse)
					{
						networkAnimator.SetTrigger(MeleeWeaponInUseRightHand.AttackAnimatorParameterName + Random.Range(1, MeleeWeaponInUseRightHand.randomAnimCount + 1));
					}
				}
				else if (!MeleeWeaponInUseRightHand.isBlockedToUse)
				{
					networkAnimator.SetTrigger(MeleeWeaponInUseRightHand.AttackAnimatorParameterName);
				}
			}
		}

		public virtual void UseWeaponRightHand(bool ShotInput, bool ShotInputDown, bool AimInput, bool AimInputDown)
		{
			if (!(HoldableItemInUseRightHand is Weapon))
			{
				WeaponInUseRightHand = null;
				return;
			}
			if (!FiringMode || IsRolling || IsDead || IsDriving || IsReloading)
			{
				IsAiming = false;
				return;
			}
			if (MovementAffectsWeaponAccuracy)
			{
				WeaponInUseRightHand.ShotErrorProbability += VelocityMultiplier * WeaponInUseRightHand.Precision * Time.fixedDeltaTime / (8f * OnMovePrecision);
			}
			bool flag = false;
			flag = ((!WeaponInUseRightHand.ContinuousUseItem) ? ShotInputDown : HoldableItemInUseRightHand.CanUseItem);
			if (JUGameManager.IsMobile)
			{
				if (AimInputDown)
				{
					IsAiming = !IsAiming;
				}
			}
			else
			{
				if (AimMode == PressAimMode.OnePressToAim && AimInputDown)
				{
					IsAiming = !IsAiming;
				}
				if (ArmsWeightIK > 0.4f)
				{
					if (AimMode == PressAimMode.HoldToAim)
					{
						IsAiming = AimInput;
					}
				}
				else
				{
					IsAiming = false;
				}
			}
			if (HoldableItemInUseLeftHand != null && HoldableItemInUseRightHand != null)
			{
				IsAiming = false;
			}
			if (WeaponInUseRightHand.FireMode != Weapon.WeaponFireMode.SemiAuto)
			{
				if (ShotInput && ArmsWeightIK > 0.4f && flag)
				{
					UseEquipedItem();
				}
				else
				{
					WeaponInUseRightHand.StopUseItemDelayed(0.09f);
				}
				return;
			}
			if (ShotInput && ArmsWeightIK > 0.4f && flag)
			{
				UseEquipedItem();
			}
			else
			{
				WeaponInUseRightHand.StopUseItemDelayed(0.09f);
			}
			if (ShotInputDown && !IsRolling && !IsDriving && ArmsWeightIK > 0.4f && WeaponInUseRightHand.BulletsAmounts > 0 && WeaponInUseRightHand.IsUsingItem && WeaponInUseRightHand.CurrentFireRateToShoot > 0.09f)
			{
				WeaponInUseRightHand.Shot();
			}
		}

		public virtual void UseWeaponLeftHand(bool ShotInput, bool ShotInputDown, bool AimInput, bool AimInputDown)
		{
			if (!(HoldableItemInUseLeftHand is Weapon))
			{
				WeaponInUseLeftHand = null;
				return;
			}
			if (!FiringMode || IsRolling || IsDead || IsDriving || IsReloading)
			{
				IsAiming = false;
				return;
			}
			if (MovementAffectsWeaponAccuracy)
			{
				WeaponInUseLeftHand.ShotErrorProbability += VelocityMultiplier * WeaponInUseLeftHand.Precision * Time.fixedDeltaTime / (8f * OnMovePrecision);
			}
			bool flag = false;
			flag = ((!WeaponInUseLeftHand.ContinuousUseItem) ? ShotInputDown : HoldableItemInUseLeftHand.CanUseItem);
			if (JUGameManager.IsMobile)
			{
				if (AimInput)
				{
					IsAiming = !IsAiming;
				}
			}
			else
			{
				if (AimMode == PressAimMode.OnePressToAim && AimInputDown)
				{
					IsAiming = !IsAiming;
				}
				if (ArmsWeightIK > 0.4f)
				{
					if (AimMode == PressAimMode.HoldToAim)
					{
						IsAiming = AimInput;
					}
				}
				else
				{
					IsAiming = false;
				}
			}
			if (HoldableItemInUseLeftHand != null && HoldableItemInUseLeftHand != null)
			{
				IsAiming = false;
			}
			if (WeaponInUseLeftHand.FireMode != Weapon.WeaponFireMode.SemiAuto)
			{
				if (ShotInput && ArmsWeightIK > 0.4f && flag)
				{
					UseEquipedItem(RightHand: false);
				}
				else
				{
					WeaponInUseLeftHand.StopUseItemDelayed(0.09f);
				}
				return;
			}
			if (ShotInput && ArmsWeightIK > 0.4f && flag)
			{
				UseEquipedItem(RightHand: false);
			}
			else
			{
				WeaponInUseLeftHand.StopUseItemDelayed(0.09f);
			}
			if (ShotInputDown && !IsRolling && !IsDriving && ArmsWeightIK > 0.4f && WeaponInUseLeftHand.BulletsAmounts > 0 && WeaponInUseLeftHand.IsUsingItem && WeaponInUseLeftHand.CurrentFireRateToShoot > 0.09f)
			{
				WeaponInUseLeftHand.Shot();
			}
		}

		public virtual void _ThrowCurrentThrowableItem()
		{
			if (HoldableItemInUseRightHand != null && HoldableItemInUseRightHand is ThrowableItem)
			{
				if (LookAtPosition == Vector3.zero && MyCamera != null && FiringMode)
				{
					ThrowableItem throwableItem = HoldableItemInUseRightHand as ThrowableItem;
					throwableItem.DirectionToThrow = base.transform.InverseTransformDirection(MyCamera.transform.forward);
					throwableItem.ThrowThis(throwableItem.ThrowForce, throwableItem.ThrowUpForce, throwableItem.PositionToThrow, base.transform.InverseTransformDirection(MyCamera.transform.forward), throwableItem.RotationForce);
				}
				else
				{
					HoldableItemInUseRightHand.UseItem();
				}
			}
			if (HoldableItemInUseLeftHand != null && HoldableItemInUseLeftHand is ThrowableItem)
			{
				if (LookAtPosition == Vector3.zero && MyCamera != null && FiringMode)
				{
					ThrowableItem throwableItem2 = HoldableItemInUseLeftHand as ThrowableItem;
					throwableItem2.DirectionToThrow = base.transform.InverseTransformDirection(MyCamera.transform.forward);
					throwableItem2.ThrowThis(throwableItem2.ThrowForce, throwableItem2.ThrowUpForce, throwableItem2.PositionToThrow, base.transform.InverseTransformDirection(MyCamera.transform.forward), throwableItem2.RotationForce);
				}
				else
				{
					HoldableItemInUseLeftHand.UseItem();
				}
			}
		}

		public virtual void _ReloadEquipedWeapons(bool ReloadInput)
		{
			if (WeaponInUseRightHand != null && ReloadInput && WeaponInUseRightHand.BulletsAmounts < WeaponInUseRightHand.BulletsPerMagazine && WeaponInUseRightHand.TotalBullets > 0)
			{
				_ReloadWeaponRightHandWeapon();
			}
			if (WeaponInUseLeftHand != null && ReloadInput && WeaponInUseLeftHand.BulletsAmounts < WeaponInUseLeftHand.BulletsPerMagazine && WeaponInUseLeftHand.TotalBullets > 0)
			{
				_ReloadWeaponLeftHandWeapon();
			}
		}

		public virtual void _ReloadWeaponRightHandWeapon()
		{
			if (!(WeaponInUseRightHand == null) && WeaponInUseRightHand.BulletsAmounts < WeaponInUseRightHand.BulletsPerMagazine && WeaponInUseRightHand.TotalBullets > 0)
			{
				networkAnimator.SetTrigger(AnimatorParameters.ReloadRightWeapon);
				IsReloading = true;
			}
		}

		public virtual void _ReloadWeaponLeftHandWeapon()
		{
			if (!(WeaponInUseLeftHand == null) && WeaponInUseLeftHand.BulletsAmounts < WeaponInUseLeftHand.BulletsPerMagazine && WeaponInUseLeftHand.TotalBullets > 0)
			{
				networkAnimator.SetTrigger(AnimatorParameters.ReloadLeftWeapon);
				IsReloading = true;
			}
		}

		public virtual void _AutoReload(bool ShotInput = true)
		{
			if (WeaponInUseLeftHand != null && WeaponInUseRightHand != null)
			{
				if (ShotInput && WeaponInUseRightHand.BulletsAmounts <= 0 && WeaponInUseRightHand.TotalBullets > 0 && WeaponInUseLeftHand.BulletsAmounts <= 0 && WeaponInUseLeftHand.TotalBullets > 0)
				{
					_ReloadWeaponRightHandWeapon();
					_ReloadWeaponLeftHandWeapon();
				}
				return;
			}
			if (WeaponInUseRightHand != null && ShotInput && WeaponInUseRightHand.BulletsAmounts == 0 && WeaponInUseRightHand.TotalBullets > 0)
			{
				_ReloadWeaponRightHandWeapon();
			}
			if (WeaponInUseLeftHand != null && ShotInput && WeaponInUseLeftHand.BulletsAmounts == 0 && WeaponInUseLeftHand.TotalBullets > 0)
			{
				_ReloadWeaponLeftHandWeapon();
			}
		}

		public virtual void _Move(float HorizontalInput, float VerticalInput, bool Running)
		{
			HorizontalX = HorizontalInput;
			VerticalY = VerticalInput;
			IsRunning = Running;
		}

		public virtual void SetFishingPose(bool isOn)
		{
			anim.SetBool("FishingPose", isOn);
		}

		public virtual void _Jump()
		{
			if (!IsGrounded || IsJumping || IsRolling || IsDriving || !CanJump || IsProne || IsRagdolled)
			{
				_GetUp();
			}
			else if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Prone Free Locomotion BlendTree") && !anim.GetCurrentAnimatorStateInfo(0).IsName("CrouchToProne") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Prone FireMode BlendTree") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Prone To Crouch"))
			{
				IsGrounded = false;
				IsJumping = true;
				CanJump = false;
				IsCrouched = false;
				rb.AddForce(base.transform.up * 200f * JumpForce, ForceMode.Impulse);
				if (!SetRigidbodyVelocity)
				{
					rb.AddForce(DirectionTransform.forward * LastVelMult * rb.mass * Speed, ForceMode.Impulse);
					VelocityMultiplier = 0f;
				}
				Invoke("_disablejump", 0.3f);
			}
		}

		public virtual void _NewJumpDelay(float Delay = 0.3f, bool JumpDecreaseSpeed = false)
		{
			if (!CanJump && !IsJumping && IsGrounded && !IsInvoking("_enableCanJump"))
			{
				if (JumpDecreaseSpeed)
				{
					VelocityMultiplier /= 4f;
				}
				Invoke("_enableCanJump", Delay);
			}
		}

		public virtual void _Crouch()
		{
			if (IsGrounded && !IsDriving)
			{
				if (IsProne)
				{
					IsProne = false;
				}
				IsCrouched = true;
			}
		}

		public virtual void _Prone()
		{
			if (IsGrounded && !IsDriving)
			{
				IsCrouched = true;
				IsProne = true;
			}
		}

		public virtual void _GetUp()
		{
			if (IsProne)
			{
				IsCrouched = true;
				IsProne = false;
			}
			else
			{
				IsCrouched = false;
				IsProne = false;
			}
		}

		public virtual void _Roll()
		{
			if (IsGrounded && !IsRolling && !IsProne)
			{
				anim.SetTrigger(AnimatorParameters.Roll);
				Invoke("stopRolling", 1f);
			}
		}

		public virtual void _DoPunch()
		{
			if (AnimatorParameters.Punch != "")
			{
				networkAnimator.SetTrigger(AnimatorParameters.Punch);
				IsPunching = true;
			}
		}

		public virtual void DefaultUseOfAllItems(bool ShotInput, bool ShotInputDown = false, bool ReloadInput = false, bool AimInput = false, bool AimInputDown = false, bool MeleeAttackInput = false)
		{
			waitTimeCounter += Time.deltaTime;
			if (HoldableItemInUseLeftHand != null || HoldableItemInUseRightHand != null)
			{
				UseLeftHandItem(ShotInput, ShotInputDown);
				UseRightHandItem(ShotInput, ShotInputDown);
				if (RightHandWeightIK > 0.5f)
				{
					UseWeaponLeftHand(ShotInput, ShotInputDown, AimInput, AimInputDown);
				}
				if (RightHandWeightIK > 0.5f)
				{
					UseWeaponRightHand(ShotInput, ShotInputDown, AimInput, AimInputDown);
				}
				if (HoldableItemInUseRightHand.ContinuousUseItem && waitTimeCounter > hammerWaitTime)
				{
					waitTimeCounter = 0f;
					UseMeleeWeapons(ShotInput);
				}
				else
				{
					UseMeleeWeapons(ShotInputDown);
				}
				_ReloadEquipedWeapons(ReloadInput);
				_AutoReload();
			}
			else if (MeleeAttackInput)
			{
				_DoPunch();
			}
		}

		public virtual void _AimScope()
		{
			IsAiming = !IsAiming;
		}

		public void reloadRightHandWeapon()
		{
			if (WeaponInUseRightHand != null)
			{
				WeaponInUseRightHand.Reload();
			}
			networkAnimator.ResetTrigger(AnimatorParameters.ReloadRightWeapon);
			IsReloading = false;
		}

		public void reloadLeftHandWeapon()
		{
			if (WeaponInUseLeftHand != null)
			{
				WeaponInUseLeftHand.Reload();
			}
			networkAnimator.ResetTrigger(AnimatorParameters.ReloadLeftWeapon);
			IsReloading = false;
		}

		public void emitBulletShell()
		{
			if (WeaponInUseRightHand != null && WeaponInUseRightHand.BulletCasingPrefab != null)
			{
				WeaponInUseRightHand.EmitBulletShell();
			}
			if (WeaponInUseLeftHand != null && WeaponInUseLeftHand.BulletCasingPrefab != null)
			{
				WeaponInUseLeftHand.EmitBulletShell();
			}
		}

		public void disableMove()
		{
			CanMove = false;
		}

		public void enableMove()
		{
			CanMove = true;
			DisableAllMove = false;
			CanMove = true;
		}

		public void disableRotation()
		{
			CanRotate = false;
		}

		public void enableRotation()
		{
			CanRotate = true;
		}

		public void disableFireModeIK()
		{
			FiringModeIK = false;
		}

		public void enableFireModeIK()
		{
			FiringModeIK = true;
		}

		public void stopRolling()
		{
			CanMove = true;
			IsRolling = false;
			enableFireModeIK();
		}

		public void startRolling()
		{
			IsRolling = true;
			CanMove = false;
			disableFireModeIK();
		}

		private void _disablejump()
		{
			IsJumping = false;
		}

		private void _disableroll()
		{
			IsRolling = false;
		}

		private void _enableCanJump()
		{
			CanJump = true;
		}

		protected void DrivingCheck()
		{
			if (DriveVehicleAbility == null)
			{
				IsDriving = false;
				return;
			}
			IsDriving = DriveVehicleAbility.IsDriving;
			VehicleInArea = DriveVehicleAbility.VehicleToDrive;
		}

		protected void HealthCheck()
		{
			if (!(CharacterHealth == null))
			{
				if (CharacterHealth.Health <= 0f && !IsDead)
				{
					KillCharacter();
				}
				if (IsDead)
				{
					CanMove = false;
					IsRunning = false;
					IsCrouched = false;
					IsJumping = false;
					IsGrounded = false;
					IsItemEquiped = false;
					IsRolling = false;
					IsDriving = false;
					UsedItem = false;
					WallAHead = false;
					FiringModeIK = false;
					ResetDefaultLayersWeight();
					coll.isTrigger = true;
					coll.enabled = true;
					rb.isKinematic = true;
					rb.constraints = (RigidbodyConstraints)122;
					base.gameObject.layer = 2;
					base.transform.position = GetGroundPoint();
				}
			}
		}

		protected void PickUpCheck()
		{
			if (Inventory == null)
			{
				ToPickupItem = false;
				return;
			}
			if (Inventory.ItemToPickUp != null)
			{
				ToPickupItem = true;
			}
			else if (ToPickupItem && Inventory.ItemToPickUp == null && !IsInvoking("DisableToPickUpItemBoolean"))
			{
				Invoke("DisableToPickUpItemBoolean", 0.3f);
			}
			ToPickupItem = !(Inventory.ItemToPickUp == null);
		}

		private void DisableToPickUpItemBoolean()
		{
			ToPickupItem = false;
		}

		public virtual void TakeDamage(float Damage, Vector3 hitPosition = default(Vector3))
		{
			if (CharacterHealth == null)
			{
				CharacterHealth = GetComponent<JUHealth>();
				if (CharacterHealth == null)
				{
					return;
				}
			}
			CharacterHealth.DoDamage(Damage, hitPosition);
		}

		public virtual void KillCharacter()
		{
			if (CharacterHealth == null)
			{
				Debug.LogWarning("Unable to kill the character as there is no JU Health component attached to it.");
				return;
			}
			ResetDefaultLayersWeight();
			if (RagdollWhenDie && Ragdoller != null)
			{
				Ragdoller.State = AdvancedRagdollController.RagdollState.Ragdolled;
				Ragdoller.TimeToGetUp = 900f;
			}
			CharacterHealth.Health = 0f;
			IsDead = true;
		}

		public virtual void RessurectCharacter(float health = 100f)
		{
			if (IsDead)
			{
				if (Object.FindObjectOfType<TPSCameraController>() != null)
				{
					Object.FindObjectOfType<TPSCameraController>().mCamera.transform.localEulerAngles = Vector3.zero;
				}
				if (Ragdoller != null)
				{
					anim.GetBoneTransform(HumanBodyBones.Hips).SetParent(Ragdoller.HipsParent);
					Ragdoller.State = AdvancedRagdollController.RagdollState.BlendToAnim;
					Ragdoller.TimeToGetUp = 2f;
					Ragdoller.BlendAmount = 0f;
					Ragdoller.SetActiveRagdoll(Enabled: false);
				}
				DisableAllMove = false;
				CanMove = true;
				if (CharacterHealth != null)
				{
					CharacterHealth.Health = health;
					CharacterHealth.IsDead = false;
					CharacterHealth.CheckHealthState();
				}
				IsDead = false;
				coll.isTrigger = false;
				rb.useGravity = true;
				rb.isKinematic = false;
				rb.velocity = base.transform.up * rb.velocity.y;
				base.enabled = true;
				anim.enabled = true;
				anim.Play("WalkingBlend", 0);
				anim.SetLayerWeight(1, 0f);
				anim.SetLayerWeight(2, 0f);
				anim.SetLayerWeight(3, 0f);
				anim.SetLayerWeight(4, 0f);
				anim.SetLayerWeight(5, 0f);
				Debug.Log("Player has respawned");
			}
		}

		public void UseEquipedItem(bool RightHand = true)
		{
			if (HoldableItemInUseRightHand != null && HoldableItemInUseLeftHand == null && RightHand)
			{
				HoldableItemInUseRightHand.UseItem();
			}
			if (HoldableItemInUseLeftHand != null)
			{
				if (WeaponInUseRightHand == null)
				{
					if (!RightHand)
					{
						HoldableItemInUseLeftHand.UseItem();
					}
					if (HoldableItemInUseRightHand != null && RightHand)
					{
						HoldableItemInUseRightHand.UseItem();
					}
				}
				else if (WeaponInUseLeftHand != null)
				{
					if (WeaponInUseRightHand.CurrentFireRateToShoot >= WeaponInUseRightHand.Fire_Rate)
					{
						_ = WeaponInUseLeftHand.CurrentFireRateToShoot;
						_ = WeaponInUseLeftHand.Fire_Rate;
					}
					if (RightHand && !UsedRightItem)
					{
						HoldableItemInUseRightHand.UseItem();
						WeaponInUseLeftHand.CurrentFireRateToShoot = 0f;
						UsedRightItem = true;
					}
					if (!RightHand && UsedRightItem)
					{
						HoldableItemInUseLeftHand.UseItem();
						UsedRightItem = false;
					}
				}
				else
				{
					HoldableItemInUseLeftHand.UseItem();
					HoldableItemInUseRightHand.UseItem();
				}
			}
			if (WeaponInUseLeftHand != null && (WeaponInUseLeftHand.FireMode == Weapon.WeaponFireMode.BoltAction || WeaponInUseLeftHand.FireMode == Weapon.WeaponFireMode.Shotgun))
			{
				Invoke("PullWeaponBolt", 0.3f);
			}
			if (WeaponInUseRightHand != null && (WeaponInUseRightHand.FireMode == Weapon.WeaponFireMode.BoltAction || WeaponInUseRightHand.FireMode == Weapon.WeaponFireMode.Shotgun))
			{
				Invoke("PullWeaponBolt", 0.4f);
			}
		}

		public int GetWieldingID()
		{
			int result = -1;
			if (HoldableItemInUseRightHand == null && HoldableItemInUseLeftHand == null)
			{
				result = 0;
			}
			if (HoldableItemInUseRightHand != null && HoldableItemInUseLeftHand == null)
			{
				result = 1;
			}
			if (HoldableItemInUseRightHand == null && HoldableItemInUseLeftHand != null)
			{
				result = 2;
			}
			if (HoldableItemInUseRightHand != null && HoldableItemInUseLeftHand != null)
			{
				result = 3;
			}
			return result;
		}

		public void SwitchToNextItem(bool RightHand = true)
		{
			SwitchItens(SwitchDirection.Forward, RightHand);
		}

		public void SwitchToPreviousItem(bool RightHand = true)
		{
			SwitchItens(SwitchDirection.Backward, RightHand);
		}

		public void SwitchToItem(int id = -1, bool RightHand = true)
		{
			if (Inventory == null)
			{
				return;
			}
			IsAiming = false;
			UsedItem = false;
			if (JUPauseGame.Paused || IsReloading || IsReloading || IsDead || IsDriving || IsRagdolled || DisableAllMove)
			{
				return;
			}
			if (oldDualItem != null)
			{
				Inventory.SwitchToItem(-1, RightHand: false);
				oldDualItem.gameObject.SetActive(value: false);
				oldDualItem = null;
			}
			Inventory.SwitchToItem(id, RightHand);
			CurrentItemIDRightHand = Inventory.CurrentRightHandItemID;
			CurrentItemIDLeftHand = Inventory.CurrentLeftHandItemID;
			HoldableItemInUseLeftHand = Inventory.HoldableItemInUseInLeftHand;
			HoldableItemInUseRightHand = Inventory.HoldableItemInUseInRightHand;
			WeaponInUseLeftHand = Inventory.WeaponInUseInLeftHand;
			WeaponInUseRightHand = Inventory.WeaponInUseInRightHand;
			MeleeWeaponInUseRightHand = Inventory.MeleeWeaponInUseInRightHand;
			MeleeWeaponInUseLeftHand = Inventory.MeleeWeaponInUseInLeftHand;
			IsItemEquiped = Inventory.IsItemSelected;
			IsDualWielding = Inventory.DualWielding;
			if (RightHand)
			{
				if (HoldableItemInUseRightHand != null)
				{
					if (HoldableItemInUseRightHand.ForceDualWielding && HoldableItemInUseRightHand.DualItemToWielding != null)
					{
						SwitchToItem(HoldableItemInUseRightHand.DualItemToWielding.ItemSwitchID, RightHand: false);
						oldDualItem = HoldableItemInUseRightHand.DualItemToWielding;
					}
				}
				else
				{
					SwitchToItem(-1, RightHand: false);
					oldDualItem = null;
				}
			}
			else if (HoldableItemInUseLeftHand != null)
			{
				if (HoldableItemInUseLeftHand.ForceDualWielding && HoldableItemInUseLeftHand.DualItemToWielding != null)
				{
					SwitchToItem(HoldableItemInUseLeftHand.DualItemToWielding.ItemSwitchID);
					oldDualItem = HoldableItemInUseLeftHand.DualItemToWielding;
				}
			}
			else
			{
				oldDualItem = null;
			}
			if (HoldableItemInUseRightHand != null || HoldableItemInUseLeftHand != null)
			{
				IsWeaponSwitching = true;
				WeaponSwitchingCurrentTime = 0f;
				PlayWeaponSwitchAnimation();
				ArmsWeightIK = 0f;
				if (CurrentItemIDRightHand != -1)
				{
					BothArmsLayerWeight = 0f;
				}
			}
		}

		public virtual void SwitchItens(SwitchDirection Direction, bool RightHand = true)
		{
			IsAiming = false;
			UsedItem = false;
			if (JUPauseGame.Paused || IsReloading || IsReloading || IsDead || IsDriving || IsRagdolled || DisableAllMove)
			{
				return;
			}
			switch (Direction)
			{
			case SwitchDirection.Forward:
				if (RightHand)
				{
					CurrentItemIDRightHand = Inventory.GetNextUnlockedItemID(CurrentItemIDRightHand);
				}
				else
				{
					CurrentItemIDLeftHand = Inventory.GetNextUnlockedItemID(CurrentItemIDLeftHand, base.transform, RightHand: false);
				}
				break;
			case SwitchDirection.Backward:
				if (RightHand)
				{
					CurrentItemIDRightHand = Inventory.GetPreviousUnlockedItemID(CurrentItemIDRightHand);
				}
				else
				{
					CurrentItemIDLeftHand = Inventory.GetPreviousUnlockedItemID(CurrentItemIDLeftHand, base.transform, RightHand: false);
				}
				break;
			}
			SwitchToItem(RightHand ? CurrentItemIDRightHand : CurrentItemIDLeftHand, RightHand);
		}

		protected virtual void PlayWeaponSwitchAnimation()
		{
			if (HoldableItemInUseRightHand != null)
			{
				if (HoldableItemInUseRightHand.PushItemFrom == HoldableItem.ItemSwitchPosition.Back)
				{
					anim.Play("Weapon Switch Back", 5, 0f);
				}
				else
				{
					anim.Play("Weapon Switch Hips", 5, 0f);
				}
			}
		}

		public virtual void PullWeaponBolt()
		{
			if (!(WeaponInUseRightHand == null) && WeaponInUseRightHand.FireMode == Weapon.WeaponFireMode.BoltAction && WeaponInUseRightHand.IsUsingItem)
			{
				IsAiming = false;
				anim.SetTrigger(AnimatorParameters.PullWeaponSlider);
			}
		}

		public void DoHandPositioningNoSmoothing()
		{
			IKPositionLeftHand.position = LeftHandIKPositionTarget.position;
			IKPositionRightHand.position = RightHandIKPositionTarget.position;
			IKPositionLeftHand.rotation = LeftHandIKPositionTarget.rotation;
			IKPositionRightHand.rotation = RightHandIKPositionTarget.rotation;
		}

		public void SmoothRightHandPosition(float Speed = 8f)
		{
			if (HoldableItemInUseLeftHand == null)
			{
				IKPositionRightHand.parent = base.transform;
				if (HoldableItemInUseRightHand != null)
				{
					Quaternion rotation = WeaponHoldingPositions.WeaponPositionTransform[HoldableItemInUseRightHand.ItemWieldPositionID].rotation;
					Vector3 position = WeaponHoldingPositions.WeaponPositionTransform[HoldableItemInUseRightHand.ItemWieldPositionID].position;
					SetRightHandIKPosition(position, rotation);
					IKPositionRightHand.position = Vector3.Lerp(IKPositionRightHand.position, RightHandIKPositionTarget.position, Speed * Time.deltaTime);
					IKPositionRightHand.rotation = Quaternion.Lerp(IKPositionRightHand.rotation, RightHandIKPositionTarget.rotation, Speed * Time.deltaTime);
				}
			}
			else if (HoldableItemInUseLeftHand.OppositeHandPosition != null && HoldableItemInUseRightHand == null)
			{
				IKPositionRightHand.parent = HoldableItemInUseLeftHand.OppositeHandPosition.transform;
				if (IKPositionRightHand.position != HoldableItemInUseLeftHand.OppositeHandPosition.transform.position || RightHandIKPositionTarget.position != HoldableItemInUseLeftHand.OppositeHandPosition.transform.position)
				{
					IKPositionRightHand.position = HoldableItemInUseLeftHand.OppositeHandPosition.transform.position;
					IKPositionRightHand.rotation = HoldableItemInUseLeftHand.OppositeHandPosition.rotation;
					RightHandIKPositionTarget.position = HoldableItemInUseLeftHand.OppositeHandPosition.transform.position;
					RightHandIKPositionTarget.rotation = HoldableItemInUseLeftHand.OppositeHandPosition.rotation;
				}
			}
			else
			{
				IKPositionRightHand.parent = base.transform;
				if (HoldableItemInUseRightHand != null)
				{
					Quaternion rotation2 = WeaponHoldingPositions.WeaponPositionTransform[HoldableItemInUseRightHand.ItemWieldPositionID].rotation;
					Vector3 position2 = WeaponHoldingPositions.WeaponPositionTransform[HoldableItemInUseRightHand.ItemWieldPositionID].position;
					SetRightHandIKPosition(position2, rotation2);
					IKPositionRightHand.position = Vector3.Lerp(IKPositionRightHand.position, RightHandIKPositionTarget.position, Speed * Time.deltaTime);
					IKPositionRightHand.rotation = Quaternion.Lerp(IKPositionRightHand.rotation, RightHandIKPositionTarget.rotation, Speed * Time.deltaTime);
				}
			}
			RightHandIKPositionTarget.parent = IKPositionRightHand.parent;
		}

		public void SmoothLeftHandPosition(float Speed = 8f)
		{
			if (HoldableItemInUseRightHand == null)
			{
				IKPositionLeftHand.parent = base.transform;
				if (HoldableItemInUseLeftHand != null)
				{
					Quaternion rotation = WeaponHoldingPositions.WeaponPositionTransform[HoldableItemInUseLeftHand.ItemWieldPositionID].rotation;
					Vector3 position = WeaponHoldingPositions.WeaponPositionTransform[HoldableItemInUseLeftHand.ItemWieldPositionID].position;
					SetLeftHandIKPosition(position, rotation);
					IKPositionLeftHand.position = Vector3.Lerp(IKPositionLeftHand.position, LeftHandIKPositionTarget.position, Speed * Time.deltaTime);
					IKPositionLeftHand.rotation = Quaternion.Lerp(IKPositionLeftHand.rotation, LeftHandIKPositionTarget.rotation, Speed * Time.deltaTime);
				}
			}
			else if (HoldableItemInUseRightHand.OppositeHandPosition != null && HoldableItemInUseLeftHand == null)
			{
				IKPositionLeftHand.parent = HoldableItemInUseRightHand.OppositeHandPosition.transform;
				if (IKPositionLeftHand.position != HoldableItemInUseRightHand.OppositeHandPosition.transform.position || LeftHandIKPositionTarget.position != HoldableItemInUseRightHand.OppositeHandPosition.transform.position)
				{
					IKPositionLeftHand.position = HoldableItemInUseRightHand.OppositeHandPosition.transform.position;
					IKPositionLeftHand.rotation = HoldableItemInUseRightHand.OppositeHandPosition.rotation;
					LeftHandIKPositionTarget.position = HoldableItemInUseRightHand.OppositeHandPosition.transform.position;
					LeftHandIKPositionTarget.rotation = HoldableItemInUseRightHand.OppositeHandPosition.rotation;
				}
			}
			else
			{
				IKPositionLeftHand.parent = base.transform;
				if (HoldableItemInUseLeftHand != null)
				{
					Quaternion rotation2 = WeaponHoldingPositions.WeaponPositionTransform[HoldableItemInUseLeftHand.ItemWieldPositionID].rotation;
					Vector3 position2 = WeaponHoldingPositions.WeaponPositionTransform[HoldableItemInUseLeftHand.ItemWieldPositionID].position;
					SetLeftHandIKPosition(position2, rotation2);
					IKPositionLeftHand.position = Vector3.Lerp(IKPositionLeftHand.position, LeftHandIKPositionTarget.position, Speed * Time.deltaTime);
					IKPositionLeftHand.rotation = Quaternion.Lerp(IKPositionLeftHand.rotation, LeftHandIKPositionTarget.rotation, Speed * Time.deltaTime);
				}
			}
			LeftHandIKPositionTarget.parent = IKPositionLeftHand.parent;
		}

		public void SetRightHandWieldingPositionAndSpace(Transform targetTransform, Transform parent)
		{
			RightHandIKPositionTarget.parent = parent;
			if (targetTransform != null && RightHandIKPositionTarget.position != targetTransform.position)
			{
				RightHandIKPositionTarget.position = targetTransform.position;
				RightHandIKPositionTarget.rotation = targetTransform.rotation;
			}
			IKPositionRightHand.parent = parent;
		}

		public void SetLeftHandWieldingPositionAndSpace(Transform targetTransform, Transform parent)
		{
			LeftHandIKPositionTarget.parent = parent;
			if (targetTransform != null && LeftHandIKPositionTarget.position != targetTransform.position)
			{
				LeftHandIKPositionTarget.position = targetTransform.position;
				LeftHandIKPositionTarget.rotation = targetTransform.rotation;
			}
			IKPositionRightHand.parent = parent;
		}

		public void SetRightHandIKPosition(Vector3 Position, Quaternion Rotation)
		{
			RightHandIKPositionTarget.position = Position;
			RightHandIKPositionTarget.rotation = Rotation;
		}

		public void SetLeftHandIKPosition(Vector3 Position, Quaternion Rotation)
		{
			LeftHandIKPositionTarget.position = Position;
			LeftHandIKPositionTarget.rotation = Rotation;
		}

		public void RightHandToRespectiveIKPosition(float IKWeight, float ElbowAdjustWeight = 0f)
		{
			if (IKWeight != 0f)
			{
				anim.SetIKRotationWeight(AvatarIKGoal.RightHand, IKWeight);
				anim.SetIKPositionWeight(AvatarIKGoal.RightHand, IKWeight);
				anim.SetIKPosition(AvatarIKGoal.RightHand, IKPositionRightHand.position);
				anim.SetIKRotation(AvatarIKGoal.RightHand, IKPositionRightHand.rotation);
				if (ElbowAdjustWeight != 0f)
				{
					anim.SetIKHintPositionWeight(AvatarIKHint.RightElbow, ElbowAdjustWeight);
					Vector3 hintPosition = PivotItemRotation.transform.position + PivotItemRotation.transform.right * 2f + PivotItemRotation.transform.forward * 1f - PivotItemRotation.transform.up * 3f;
					anim.SetIKHintPosition(AvatarIKHint.RightElbow, hintPosition);
				}
			}
		}

		public void LeftHandToRespectiveIKPosition(float IKWeight, float ElbowAdjustWeight = 0f)
		{
			if (IKWeight != 0f)
			{
				anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, IKWeight);
				anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, IKWeight);
				anim.SetIKPosition(AvatarIKGoal.LeftHand, IKPositionLeftHand.position);
				anim.SetIKRotation(AvatarIKGoal.LeftHand, IKPositionLeftHand.rotation);
				if (ElbowAdjustWeight != 0f)
				{
					anim.SetIKHintPositionWeight(AvatarIKHint.LeftElbow, ElbowAdjustWeight);
					Vector3 hintPosition = PivotItemRotation.transform.position - PivotItemRotation.transform.right * 2f + PivotItemRotation.transform.forward * 1f - PivotItemRotation.transform.up * 3f;
					anim.SetIKHintPosition(AvatarIKHint.LeftElbow, hintPosition);
				}
			}
		}

		public void LookAtIK(Vector3 position, float IKWeight = 1f, float BodyIKWeight = 0.5f, float HeadIKWeight = 1f)
		{
			anim.NormalLookAt(position, HeadIKWeight, BodyIKWeight, IKWeight);
		}

		public void SpineLookAt(Vector3 position, float GlobalWeight, float WorldUpWeight = 0.2f, float SpineInclination = 0f, float SmoothTime = 5f)
		{
			TargetSpineLookAtPosition = position;
			SmoothedSpineLookAtPosition = Vector3.Lerp(SmoothedSpineLookAtPosition, TargetSpineLookAtPosition, SmoothTime * Time.deltaTime);
			if (SpineLookATTransform == null)
			{
				SpineLookATTransform = new GameObject("SpineIKDirection").transform;
				SpineLookATTransform.position = anim.GetBoneTransform(HumanBodyBones.Spine).position;
				SpineLookATTransform.rotation = anim.GetBoneTransform(HumanBodyBones.Spine).rotation;
				SpineLookATTransform.SetParent(anim.GetBoneTransform(HumanBodyBones.Spine).parent);
				return;
			}
			SpineLookATTransform.LookAt(position, Vector3.Lerp(anim.GetBoneTransform(HumanBodyBones.Spine).up + anim.GetBoneTransform(HumanBodyBones.Spine).right * GlobalWeight * SpineInclination, Vector3.up, WorldUpWeight));
			Quaternion rotation = Quaternion.Lerp(OriginalSpineRotation, SpineLookATTransform.localRotation, GlobalWeight);
			if (SpineInclination == 0f)
			{
				rotation.z = OriginalSpineRotation.z;
			}
			anim.SetBoneLocalRotation(HumanBodyBones.Spine, rotation);
		}

		public override bool Weaved()
		{
			return true;
		}
	}
}
