using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ScheduleOne.DevUtilities;
using ScheduleOne.Map;
using ScheduleOne.Tools;
using ScheduleOne.Vehicles;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScheduleOne.PlayerScripts
{
	public class PlayerMovement : PlayerSingleton<PlayerMovement>
	{
		[CompilerGenerated]
		private sealed class _003CLerpPlayerRotation_Process_003Ed__150 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PlayerMovement _003C_003E4__this;

			public Quaternion endRotation;

			public float lerpTime;

			private Quaternion _003CstartRot_003E5__2;

			private float _003Ci_003E5__3;

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
			public _003CLerpPlayerRotation_Process_003Ed__150(int _003C_003E1__state)
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

		public const float DevSprintMultiplier = 1f;

		public const float WalkSpeed = 3.25f;

		public static float StaticMoveSpeedMultiplier;

		public const float InputSensitivity = 7f;

		public const float InputDeadZone = 0.001f;

		public const float SlipperyMovementMultiplier = 0.98f;

		public const float GroundedThreshold = 0.05f;

		public const float SlopeThreshold = 5f;

		public const float SlopeForce = 1f;

		public const float SlopeForceRayLength = 1.5f;

		public const float ControllerRadius = 0.35f;

		public const float DefaultCharacterControllerHeight = 1.85f;

		public const float CrouchHeightMultiplier = 0.65f;

		public const float CrouchTime = 0.2f;

		public const float CrouchSpeedMultipler = 0.6f;

		public const float CrouchedVigIntensity = 0.35f;

		public const float CrouchedVigSmoothness = 0.7f;

		public const bool SprintingRequiresStamina = false;

		public const float SprintChangeRate = 4f;

		public const float SprintMultiplier = 1.9f;

		public const float StaminaDrainRate = 12.5f;

		public const float StaminaRestoreRate = 25f;

		public const float StaminaRestoreDelay = 1f;

		public static float StaminaReserveMax;

		public const float JumpForce = 5.25f;

		public static float JumpMultiplier;

		public static float GravityMultiplier;

		public const float BaseGravityMultiplier = 1.4f;

		public const float VerticalLadderSpeedMultiplier = 1.2f;

		public const float LateralLadderSpeedMultiplier = 0.5f;

		public const float LadderTopBuffer = 0.15f;

		public const float LadderPitchAdjustment = 60f;

		public const float DismountForce = 7f;

		public const float DismountForceDuration = 0.5f;

		[Header("References")]
		public Player Player;

		public CharacterController Controller;

		[Header("Jump/fall settings")]
		[FormerlySerializedAs("groundDetectionMask")]
		public LayerMask GroundDetectionMask;

		public readonly FloatStack MoveSpeedMultiplierStack;

		public Action<float> onStaminaReserveChanged;

		public Action onJump;

		public Action onLand;

		public Action onCrouch;

		public Action onUncrouch;

		private Vector3 movement;

		private Vector3 lastFrameMovement;

		private float movementY;

		private float timeOnLadderDismount;

		private Vector3 ladderDismountDir;

		private float horizontalAxis;

		private float verticalAxis;

		private Dictionary<int, MotionEvent> movementEvents;

		private float timeSinceStaminaDrain;

		private bool sprintActive;

		private bool sprintReleased;

		private List<string> sprintBlockers;

		private Vector3 residualVelocityDirection;

		private float residualVelocityForce;

		private float residualVelocityDuration;

		private float residualVelocityTimeRemaining;

		private bool teleport;

		private Vector3 teleportPosition;

		private float playerLadderYPosOnLastClimbSound;

		private Coroutine playerRotCoroutine;

		public bool CanMove { get; set; }

		public bool CanJump { get; set; }

		public Vector3 Movement => default(Vector3);

		public bool IsJumping { get; private set; }

		public float TimeAirborne { get; private set; }

		public float TimeGrounded { get; private set; }

		public bool IsGrounded { get; private set; }

		public bool IsCrouched { get; private set; }

		public float StandingScale { get; private set; }

		public bool IsRagdolled { get; private set; }

		public bool IsSprinting { get; private set; }

		public bool ForceSprint { get; set; }

		public float CurrentStaminaReserve { get; private set; }

		public float CurrentSprintMultiplier { get; private set; }

		public LandVehicle CurrentVehicle { get; protected set; }

		public Ladder CurrentLadder { get; set; }

		public bool IsOnLadder => false;

		public float MoveSpeedMultiplier => 0f;

		protected override void Awake()
		{
		}

		protected override void Start()
		{
		}

		private void Update()
		{
		}

		private void FixedUpdate()
		{
		}

		private void LateUpdate()
		{
		}

		private void Move()
		{
		}

		private void ClampMovement()
		{
		}

		private float GetSurfaceAngle()
		{
			return 0f;
		}

		private bool GetIsGrounded()
		{
			return false;
		}

		public void Teleport(Vector3 position, bool alignFeetToPosition = false)
		{
		}

		public void SetResidualVelocity(Vector3 dir, float force, float time)
		{
		}

		public void WarpToNavMesh(bool clearVelocity = false)
		{
		}

		private void UpdateHorizontalAxis()
		{
		}

		private void UpdateVerticalAxis()
		{
		}

		public void Jump()
		{
		}

		public void SetCrouched(bool c)
		{
		}

		private void TryToggleCrouch()
		{
		}

		private bool CanStand()
		{
			return false;
		}

		private void UpdateCrouchVignetteEffect()
		{
		}

		private void UpdatePlayerHeight()
		{
		}

		public void LerpPlayerRotation(Quaternion rotation, float lerpTime)
		{
		}

		[IteratorStateMachine(typeof(_003CLerpPlayerRotation_Process_003Ed__150))]
		private IEnumerator LerpPlayerRotation_Process(Quaternion endRotation, float lerpTime)
		{
			return null;
		}

		public void SetPlayerRotation(Quaternion rotation)
		{
		}

		private void EnterVehicle(LandVehicle vehicle)
		{
		}

		private void ExitVehicle(LandVehicle veh, Transform exitPoint)
		{
		}

		public void RegisterMovementEvent(int threshold, Action action)
		{
		}

		public void DeregisterMovementEvent(Action action)
		{
		}

		private void UpdateMovementEvents()
		{
		}

		public void ChangeStamina(float change, bool notify = true)
		{
		}

		public void SetStamina(float value, bool notify = true)
		{
		}

		public void AddSprintBlocker(string tag)
		{
		}

		public void RemoveSprintBlocker(string tag)
		{
		}

		public void MountLadder(Ladder ladder)
		{
		}

		public void DismountLadder()
		{
		}

		private void LadderMove()
		{
		}

		private void PlayLadderClimbSound()
		{
		}
	}
}
