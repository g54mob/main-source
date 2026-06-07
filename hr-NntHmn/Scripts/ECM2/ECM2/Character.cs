using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace ECM2
{
	[RequireComponent(typeof(CharacterMovement))]
	public class Character : MonoBehaviour
	{
		public enum MovementMode
		{
			None = 0,
			Walking = 1,
			Falling = 2,
			Flying = 3,
			Swimming = 4,
			Custom = 5
		}

		public enum RotationMode
		{
			None = 0,
			OrientRotationToMovement = 1,
			OrientRotationToViewDirection = 2,
			OrientWithRootMotion = 3,
			Custom = 4
		}

		public delegate void PhysicsVolumeChangedEventHandler(PhysicsVolume newPhysicsVolume);

		public delegate void MovementModeChangedEventHandler(MovementMode prevMovementMode, int prevCustomMode);

		public delegate void CustomMovementModeUpdateEventHandler(float deltaTime);

		public delegate void CustomRotationModeUpdateEventHandler(float deltaTime);

		public delegate void BeforeSimulationUpdateEventHandler(float deltaTime);

		public delegate void AfterSimulationUpdateEventHandler(float deltaTime);

		public delegate void CharacterMovementUpdateEventHandler(float deltaTime);

		public delegate void CollidedEventHandler(ref CollisionResult collisionResult);

		public delegate void FoundGroundEventHandler(ref FindGroundResult foundGround);

		public delegate void LandedEventHandled(Vector3 landingVelocity);

		public delegate void CrouchedEventHandler();

		public delegate void UnCrouchedEventHandler();

		public delegate void JumpedEventHandler();

		public delegate void ReachedJumpApexEventHandler();

		[CompilerGenerated]
		private sealed class _003CLateFixedUpdate_003Ed__466 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Character _003C_003E4__this;

			private WaitForFixedUpdate _003CwaitTime_003E5__2;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CLateFixedUpdate_003Ed__466(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[Space(15f)]
		[Tooltip("The Character's current rotation mode.")]
		[SerializeField]
		private RotationMode _rotationMode;

		[Tooltip("Change in rotation per second (Deg / s).\nUsed when rotation mode is OrientRotationToMovement or OrientRotationToViewDirection.")]
		[SerializeField]
		private float _rotationRate;

		[Space(15f)]
		[Tooltip("The Character's default movement mode. Used at player startup.")]
		[SerializeField]
		private MovementMode _startingMovementMode;

		[Space(15f)]
		[Tooltip("The maximum ground speed when walking.\nAlso determines maximum lateral speed when falling.")]
		[SerializeField]
		private float _maxWalkSpeed;

		[Tooltip("The ground speed that we should accelerate up to when walking at minimum analog stick tilt.")]
		[SerializeField]
		private float _minAnalogWalkSpeed;

		[Tooltip("Max Acceleration (rate of change of velocity).")]
		[SerializeField]
		private float _maxAcceleration;

		[Tooltip("Deceleration when walking and not applying acceleration.\nThis is a constant opposing force that directly lowers velocity by a constant value.")]
		[SerializeField]
		private float _brakingDecelerationWalking;

		[Tooltip("Setting that affects movement control.\nHigher values allow faster changes in direction.\nIf useSeparateBrakingFriction is false, also affects the ability to stop more quickly when braking (whenever acceleration is zero).")]
		[SerializeField]
		private float _groundFriction;

		[Space(15f)]
		[Tooltip("Is the character able to crouch ?")]
		[SerializeField]
		private bool _canEverCrouch;

		[Tooltip("If canEverCrouch == true, determines the character height when crouched.")]
		[SerializeField]
		private float _crouchedHeight;

		[Tooltip("If canEverCrouch == true, determines the character height when un crouched.")]
		[SerializeField]
		private float _unCrouchedHeight;

		[Tooltip("The maximum ground speed while crouched.")]
		[SerializeField]
		private float _maxWalkSpeedCrouched;

		[Space(15f)]
		[Tooltip("The maximum vertical velocity a Character can reach when falling. Eg: Terminal velocity.")]
		[SerializeField]
		private float _maxFallSpeed;

		[Tooltip("Lateral deceleration when falling and not applying acceleration.")]
		[SerializeField]
		private float _brakingDecelerationFalling;

		[Tooltip("Friction to apply to lateral movement when falling. \nIf useSeparateBrakingFriction is false, also affects the ability to stop more quickly when braking (whenever acceleration is zero).")]
		[SerializeField]
		private float _fallingLateralFriction;

		[Range(0f, 1f)]
		[Tooltip("When falling, amount of lateral movement control available to the Character.\n0 = no control, 1 = full control at max acceleration.")]
		[SerializeField]
		private float _airControl;

		[Space(15f)]
		[Tooltip("Is the character able to jump ?")]
		[SerializeField]
		private bool _canEverJump;

		[Tooltip("Can jump while crouching ?")]
		[SerializeField]
		private bool _canJumpWhileCrouching;

		[Tooltip("The max number of jumps the Character can perform.")]
		[SerializeField]
		private int _jumpMaxCount;

		[Tooltip("Initial velocity (instantaneous vertical velocity) when jumping.")]
		[SerializeField]
		private float _jumpImpulse;

		[Tooltip("The maximum time (in seconds) to hold the jump. eg: Variable height jump.")]
		[SerializeField]
		private float _jumpMaxHoldTime;

		[Tooltip("How early before hitting the ground you can trigger a jump (in seconds).")]
		[SerializeField]
		private float _jumpMaxPreGroundedTime;

		[Tooltip("How long after leaving the ground you can trigger a jump (in seconds).")]
		[SerializeField]
		private float _jumpMaxPostGroundedTime;

		[Space(15f)]
		[Tooltip("The maximum flying speed.")]
		[SerializeField]
		private float _maxFlySpeed;

		[Tooltip("Deceleration when flying and not applying acceleration.")]
		[SerializeField]
		private float _brakingDecelerationFlying;

		[Tooltip("Friction to apply to movement when flying.")]
		[SerializeField]
		private float _flyingFriction;

		[Space(15f)]
		[Tooltip("The maximum swimming speed.")]
		[SerializeField]
		private float _maxSwimSpeed;

		[Tooltip("Deceleration when swimming and not applying acceleration.")]
		[SerializeField]
		private float _brakingDecelerationSwimming;

		[Tooltip("Friction to apply to movement when swimming.")]
		[SerializeField]
		private float _swimmingFriction;

		[Tooltip("Water buoyancy ratio. 1 = Neutral Buoyancy, 0 = No Buoyancy.")]
		[SerializeField]
		private float _buoyancy;

		[Tooltip("This Character's gravity.")]
		[Space(15f)]
		[SerializeField]
		private Vector3 _gravity;

		[Tooltip("The degree to which this object is affected by gravity.\nCan be negative allowing to change gravity direction.")]
		[SerializeField]
		private float _gravityScale;

		[Space(15f)]
		[Tooltip("Should animation determines the Character's movement ?")]
		[SerializeField]
		private bool _useRootMotion;

		[Space(15f)]
		[Tooltip("Whether the Character moves with the moving platform it is standing on.")]
		[SerializeField]
		private bool _impartPlatformMovement;

		[Tooltip("Whether the Character receives the changes in rotation of the platform it is standing on.")]
		[SerializeField]
		private bool _impartPlatformRotation;

		[Tooltip("If true, impart the platform's velocity when jumping or falling off it.")]
		[SerializeField]
		private bool _impartPlatformVelocity;

		[Space(15f)]
		[Tooltip("If enabled, the player will interact with dynamic rigidbodies when walking into them.")]
		[SerializeField]
		private bool _enablePhysicsInteraction;

		[Tooltip("Should apply push force to characters when walking into them ?")]
		[SerializeField]
		private bool _applyPushForceToCharacters;

		[Tooltip("Should apply a downward force to rigidbodies we stand on ?")]
		[SerializeField]
		private bool _applyStandingDownwardForce;

		[Space(15f)]
		[Tooltip("This Character's mass (in Kg).Determines how the character interact against other characters or dynamic rigidbodies if enablePhysicsInteraction == true.")]
		[SerializeField]
		private float _mass;

		[Tooltip("Force applied to rigidbodies when walking into them (due to mass and relative velocity) is scaled by this amount.")]
		[SerializeField]
		private float _pushForceScale;

		[Tooltip("Force applied to rigidbodies we stand on (due to mass and gravity) is scaled by this amount.")]
		[SerializeField]
		private float _standingDownwardForceScale;

		[Space(15f)]
		[Tooltip("Reference to the Player's Camera.\nIf assigned, the Character's movement will be relative to this camera, otherwise movement will be relative to world axis.")]
		[SerializeField]
		private Camera _camera;

		protected readonly List<PhysicsVolume> _physicsVolumes;

		private Coroutine _lateFixedUpdateCoroutine;

		private bool _enableAutoSimulation;

		private Transform _transform;

		private CharacterMovement _characterMovement;

		private Animator _animator;

		private RootMotionController _rootMotionController;

		private Transform _cameraTransform;

		private MovementMode _movementMode;

		private int _customMovementMode;

		private bool _useSeparateBrakingFriction;

		private float _brakingFriction;

		private bool _useSeparateBrakingDeceleration;

		private float _brakingDeceleration;

		private Vector3 _movementDirection;

		private Vector3 _rotationInput;

		private Vector3 _desiredVelocity;

		protected bool _isCrouched;

		protected bool _isJumping;

		private float _jumpInputHoldTime;

		private float _jumpForceTimeRemaining;

		private int _jumpCurrentCount;

		protected float _fallingTime;

		public Camera camera
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Transform cameraTransform => null;

		public new Transform transform => null;

		public CharacterMovement characterMovement => null;

		public Animator animator => null;

		public RootMotionController rootMotionController => null;

		public float rotationRate
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public RotationMode rotationMode
		{
			get
			{
				return default(RotationMode);
			}
			set
			{
			}
		}

		public float maxWalkSpeed
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float minAnalogWalkSpeed
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float maxAcceleration
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float brakingDecelerationWalking
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float groundFriction
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool canEverCrouch
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float crouchedHeight
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float unCrouchedHeight
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float maxWalkSpeedCrouched
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool crouchInputPressed { get; protected set; }

		public float maxFallSpeed
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float brakingDecelerationFalling
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float fallingLateralFriction
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float fallingTime => 0f;

		public float airControl
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool canEverJump
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool canJumpWhileCrouching
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public int jumpMaxCount
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public float jumpImpulse
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float jumpMaxHoldTime
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float jumpMaxPreGroundedTime
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float jumpMaxPostGroundedTime
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float jumpInputHoldTime
		{
			get
			{
				return 0f;
			}
			protected set
			{
			}
		}

		public float jumpForceTimeRemaining
		{
			get
			{
				return 0f;
			}
			protected set
			{
			}
		}

		public int jumpCurrentCount
		{
			get
			{
				return 0;
			}
			protected set
			{
			}
		}

		public bool notifyJumpApex { get; set; }

		public bool jumpInputPressed { get; protected set; }

		public float maxFlySpeed
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float brakingDecelerationFlying
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float flyingFriction
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float maxSwimSpeed
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float brakingDecelerationSwimming
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float swimmingFriction
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float buoyancy
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool useSeparateBrakingFriction
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float brakingFriction
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool useSeparateBrakingDeceleration
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float brakingDeceleration
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Vector3 gravity
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public float gravityScale
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool useRootMotion
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

		public bool applyPushForceToCharacters
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool applyStandingDownwardForce
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float mass
		{
			get
			{
				return 0f;
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

		public float standingDownwardForceScale
		{
			get
			{
				return 0f;
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

		public Vector3 position => default(Vector3);

		public Quaternion rotation => default(Quaternion);

		public Vector3 velocity => default(Vector3);

		public float speed => 0f;

		public float radius => 0f;

		public float height => 0f;

		public MovementMode movementMode => default(MovementMode);

		public int customMovementMode => 0;

		public PhysicsVolume physicsVolume { get; protected set; }

		public bool enableAutoSimulation
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool isPaused { get; private set; }

		public bool IsRunningAvailable { get; set; }

		private bool IsRunKeyPressed { get; set; }

		public event PhysicsVolumeChangedEventHandler PhysicsVolumeChanged
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

		public event MovementModeChangedEventHandler MovementModeChanged
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

		public event CustomMovementModeUpdateEventHandler CustomMovementModeUpdated
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

		public event CustomRotationModeUpdateEventHandler CustomRotationModeUpdated
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

		public event BeforeSimulationUpdateEventHandler BeforeSimulationUpdated
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

		public event AfterSimulationUpdateEventHandler AfterSimulationUpdated
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

		public event CharacterMovementUpdateEventHandler CharacterMovementUpdated
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

		public event LandedEventHandled Landed
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

		public event CrouchedEventHandler Crouched
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

		public event UnCrouchedEventHandler UnCrouched
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

		public event JumpedEventHandler Jumped
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

		public event ReachedJumpApexEventHandler ReachedJumpApex
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

		protected virtual void OnCustomMovementMode(float deltaTime)
		{
		}

		protected virtual void OnCustomRotationMode(float deltaTime)
		{
		}

		protected virtual void OnBeforeSimulationUpdate(float deltaTime)
		{
		}

		protected virtual void OnAfterSimulationUpdate(float deltaTime)
		{
		}

		protected virtual void OnCharacterMovementUpdated(float deltaTime)
		{
		}

		protected virtual void OnCollided(ref CollisionResult collisionResult)
		{
		}

		protected virtual void OnFoundGround(ref FindGroundResult foundGround)
		{
		}

		protected virtual void OnLanded(Vector3 landingVelocity)
		{
		}

		protected virtual void OnCrouched()
		{
		}

		protected virtual void OnUnCrouched()
		{
		}

		protected virtual void OnJumped()
		{
		}

		protected virtual void OnReachedJumpApex()
		{
		}

		public Vector3 GetGravityVector()
		{
			return default(Vector3);
		}

		public Vector3 GetGravityDirection()
		{
			return default(Vector3);
		}

		public float GetGravityMagnitude()
		{
			return 0f;
		}

		public void SetGravityVector(Vector3 newGravityVector)
		{
		}

		private void EnableAutoSimulationCoroutine(bool enable)
		{
		}

		protected virtual void CacheComponents()
		{
		}

		protected virtual void SetPhysicsVolume(PhysicsVolume newPhysicsVolume)
		{
		}

		protected virtual void OnPhysicsVolumeChanged(PhysicsVolume newPhysicsVolume)
		{
		}

		protected virtual void UpdatePhysicsVolume(PhysicsVolume newPhysicsVolume)
		{
		}

		protected virtual void AddPhysicsVolume(Collider other)
		{
		}

		protected virtual void RemovePhysicsVolume(Collider other)
		{
		}

		protected virtual void UpdatePhysicsVolumes()
		{
		}

		public virtual bool IsInWaterPhysicsVolume()
		{
			return false;
		}

		public void AddForce(Vector3 force, ForceMode forceMode = ForceMode.Force)
		{
		}

		public void AddExplosionForce(float forceMagnitude, Vector3 origin, float explosionRadius, ForceMode forceMode = ForceMode.Force)
		{
		}

		public void LaunchCharacter(Vector3 launchVelocity, bool overrideVerticalVelocity = false, bool overrideLateralVelocity = false)
		{
		}

		public void DetectCollisions(bool detectCollisions)
		{
		}

		public void IgnoreCollision(Collider otherCollider, bool ignore = true)
		{
		}

		public void IgnoreCollision(Rigidbody otherRigidbody, bool ignore = true)
		{
		}

		public void CapsuleIgnoreCollision(Collider otherCollider, bool ignore = true)
		{
		}

		public void PauseGroundConstraint(float seconds = 0.1f)
		{
		}

		public void EnableGroundConstraint(bool enable)
		{
		}

		public bool WasOnGround()
		{
			return false;
		}

		public bool IsOnGround()
		{
			return false;
		}

		public bool WasOnWalkableGround()
		{
			return false;
		}

		public bool IsOnWalkableGround()
		{
			return false;
		}

		public bool WasGrounded()
		{
			return false;
		}

		public bool IsGrounded()
		{
			return false;
		}

		public CharacterMovement GetCharacterMovement()
		{
			return null;
		}

		public Animator GetAnimator()
		{
			return null;
		}

		public RootMotionController GetRootMotionController()
		{
			return null;
		}

		public PhysicsVolume GetPhysicsVolume()
		{
			return null;
		}

		public Vector3 GetPosition()
		{
			return default(Vector3);
		}

		public void SetPosition(Vector3 position, bool updateGround = false)
		{
		}

		public void TeleportPosition(Vector3 newPosition, bool interpolating = true, bool updateGround = false)
		{
		}

		public Quaternion GetRotation()
		{
			return default(Quaternion);
		}

		public void SetRotation(Quaternion newRotation)
		{
		}

		public void TeleportRotation(Quaternion newRotation, bool interpolating = true)
		{
		}

		public virtual Vector3 GetUpVector()
		{
			return default(Vector3);
		}

		public virtual Vector3 GetRightVector()
		{
			return default(Vector3);
		}

		public virtual Vector3 GetForwardVector()
		{
			return default(Vector3);
		}

		public virtual void RotateTowards(Vector3 worldDirection, float deltaTime, bool updateYawOnly = true)
		{
		}

		protected virtual void RotateWithRootMotion()
		{
		}

		public Vector3 GetVelocity()
		{
			return default(Vector3);
		}

		public void SetVelocity(Vector3 newVelocity)
		{
		}

		public float GetSpeed()
		{
			return 0f;
		}

		public float GetRadius()
		{
			return 0f;
		}

		public float GetHeight()
		{
			return 0f;
		}

		public Vector3 GetMovementDirection()
		{
			return default(Vector3);
		}

		public void SetMovementDirection(Vector3 movementDirection)
		{
		}

		public virtual void SetYaw(float yaw)
		{
		}

		public float GetYaw()
		{
			return 0f;
		}

		public virtual void AddYawInput(float value)
		{
		}

		public virtual void AddPitchInput(float value)
		{
		}

		public virtual void AddRollInput(float value)
		{
		}

		protected virtual void ConsumeRotationInput()
		{
		}

		public MovementMode GetMovementMode()
		{
			return default(MovementMode);
		}

		public int GetCustomMovementMode()
		{
			return 0;
		}

		public void SetMovementMode(MovementMode newMovementMode, int newCustomMode = 0)
		{
		}

		protected virtual void OnMovementModeChanged(MovementMode prevMovementMode, int prevCustomMode)
		{
		}

		public virtual bool IsWalking()
		{
			return false;
		}

		public virtual bool IsFalling()
		{
			return false;
		}

		public virtual bool IsFlying()
		{
			return false;
		}

		public virtual bool IsSwimming()
		{
			return false;
		}

		public virtual float GetMaxSpeed()
		{
			return 0f;
		}

		public void StartRunning()
		{
		}

		public void StopRunning()
		{
		}

		public virtual float GetMinAnalogSpeed()
		{
			return 0f;
		}

		public virtual float GetMaxAcceleration()
		{
			return 0f;
		}

		public virtual float GetMaxBrakingDeceleration()
		{
			return 0f;
		}

		protected virtual float ComputeAnalogInputModifier(Vector3 desiredVelocity)
		{
			return 0f;
		}

		public virtual Vector3 ApplyVelocityBraking(Vector3 velocity, float friction, float maxBrakingDeceleration, float deltaTime)
		{
			return default(Vector3);
		}

		public virtual Vector3 CalcVelocity(Vector3 velocity, Vector3 desiredVelocity, float friction, bool isFluid, float deltaTime)
		{
			return default(Vector3);
		}

		public virtual Vector3 ConstrainInputVector(Vector3 inputVector)
		{
			return default(Vector3);
		}

		protected virtual void CalcDesiredVelocity(float deltaTime)
		{
		}

		public virtual Vector3 GetDesiredVelocity()
		{
			return default(Vector3);
		}

		public float GetSignedSlopeAngle()
		{
			return 0f;
		}

		protected virtual void ApplyDownwardsForce()
		{
		}

		protected virtual void WalkingMovementMode(float deltaTime)
		{
		}

		public virtual bool IsCrouched()
		{
			return false;
		}

		public virtual void Crouch()
		{
		}

		public virtual void UnCrouch()
		{
		}

		public void ChangeCrouchState()
		{
		}

		protected virtual bool IsCrouchAllowed()
		{
			return false;
		}

		protected virtual bool CanUnCrouch()
		{
			return false;
		}

		protected virtual void CheckCrouchInput()
		{
		}

		protected virtual void FallingMovementMode(float deltaTime)
		{
		}

		public virtual bool IsJumping()
		{
			return false;
		}

		public virtual void Jump()
		{
		}

		public virtual void StopJumping()
		{
		}

		protected virtual void ResetJumpState()
		{
		}

		public virtual bool IsJumpProvidingForce()
		{
			return false;
		}

		public virtual float GetMaxJumpHeight()
		{
			return 0f;
		}

		public virtual float GetMaxJumpHeightWithJumpTime()
		{
			return 0f;
		}

		protected virtual bool IsJumpAllowed()
		{
			return false;
		}

		protected virtual bool CanJump()
		{
			return false;
		}

		protected virtual bool DoJump()
		{
			return false;
		}

		protected virtual void CheckJumpInput()
		{
		}

		protected virtual void UpdateJumpTimers(float deltaTime)
		{
		}

		protected virtual void NotifyJumpApex()
		{
		}

		protected virtual void FlyingMovementMode(float deltaTime)
		{
		}

		public virtual float CalcImmersionDepth()
		{
			return 0f;
		}

		protected virtual void SwimmingMovementMode(float deltaTime)
		{
		}

		protected virtual void CustomMovementMode(float deltaTime)
		{
		}

		public RotationMode GetRotationMode()
		{
			return default(RotationMode);
		}

		public void SetRotationMode(RotationMode rotationMode)
		{
		}

		protected virtual void UpdateRotation(float deltaTime)
		{
		}

		protected virtual void CustomRotationMode(float deltaTime)
		{
		}

		private void BeforeSimulationUpdate(float deltaTime)
		{
		}

		private void SimulationUpdate(float deltaTime)
		{
		}

		private void AfterSimulationUpdate(float deltaTime)
		{
		}

		private void CharacterMovementUpdate(float deltaTime)
		{
		}

		public void Simulate(float deltaTime)
		{
		}

		private void OnLateFixedUpdate()
		{
		}

		public bool IsPaused()
		{
			return false;
		}

		public void Pause(bool pause, bool clearState = true)
		{
		}

		protected virtual void Reset()
		{
		}

		protected virtual void OnValidate()
		{
		}

		protected virtual void Awake()
		{
		}

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}

		protected virtual void Start()
		{
		}

		protected virtual void OnTriggerEnter(Collider other)
		{
		}

		protected virtual void OnTriggerExit(Collider other)
		{
		}

		[IteratorStateMachine(typeof(_003CLateFixedUpdate_003Ed__466))]
		private IEnumerator LateFixedUpdate()
		{
			return null;
		}
	}
}
