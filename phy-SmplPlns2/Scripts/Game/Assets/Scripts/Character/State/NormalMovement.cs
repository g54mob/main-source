using System;
using Assets.Scripts.Multiplayer;
using Lightbug.CharacterControllerPro.Core;
using Lightbug.Utilities;
using UnityEngine;
using WaveHarmonic.Crest;

namespace Assets.Scripts.Character.State
{
	public class NormalMovement : CharacterState
	{
		public enum JumpResult
		{
			Invalid = 0,
			Grounded = 1,
			NotGrounded = 2
		}

		[SerializeField]
		private CrouchParameters crouchParameters = new CrouchParameters();

		[SerializeField]
		private LookingDirectionParameters lookingDirectionParameters = new LookingDirectionParameters();

		[SerializeField]
		private PlanarMovementParameters planarMovementParameters = new PlanarMovementParameters();

		[SerializeField]
		private VerticalMovementParameters verticalMovementParameters = new VerticalMovementParameters();

		[SerializeField]
		private WaterParameters waterParameters = new WaterParameters();

		private NetworkCharacterScript _networkPlayerScript;

		private bool _ragdollQueued;

		private Ragdoll _ragdollState;

		private float _swimLayerWeight;

		private SampleCollisionHelper _sampleWaterHelper;

		private float _timeToGround;

		private float _underwaterPercent;

		private PlanarMovementParameters.PlanarMovementProperties currentMotion;

		private float currentPlanarSpeedLimit;

		[SerializeField]
		private string danceParameter = "Dance";

		private bool groundedJumpAvailable = true;

		[SerializeField]
		private string groundedParameter = "Grounded";

		[SerializeField]
		private string heightParameter = "Height";

		[SerializeField]
		private string horizontalAxisParameter = "HorizontalAxis";

		private bool isAllowedToCancelJump;

		private bool isCrouched;

		private Vector3 jumpDirection;

		private int lastDance = -1;

		[SerializeField]
		private float _linearDrag = 0.25f;

		private int notGroundedJumpsLeft;

		[SerializeField]
		private string planarSpeedParameter = "PlanarSpeed";

		private bool reducedAirControlFlag;

		private float reducedAirControlInitialTime;

		private float reductionDuration = 0.5f;

		[SerializeField]
		private string stableParameter = "Stable";

		[SerializeField]
		private string timeToGroundParameter = "TimeToGround";

		private float targetHeight = 1f;

		private Vector3 targetLookingDirection;

		[SerializeField]
		private string verticalAxisParameter = "VerticalAxis";

		[SerializeField]
		private string verticalSpeedParameter = "VerticalSpeed";

		private bool wantToCrouch;

		private bool wantToRun;

		private float waterHeight = 2f;

		public float HorizontalAxis { get; private set; }

		public CrouchParameters CrouchParameters
		{
			get
			{
				return crouchParameters;
			}
			set
			{
				crouchParameters = value;
			}
		}

		public LookingDirectionParameters LookingDirectionParameters
		{
			get
			{
				return lookingDirectionParameters;
			}
			set
			{
				lookingDirectionParameters = value;
			}
		}

		public PlanarMovementParameters PlanarMovementParameters
		{
			get
			{
				return planarMovementParameters;
			}
			set
			{
				planarMovementParameters = value;
			}
		}

		public VerticalMovementParameters VerticalMovementParameters
		{
			get
			{
				return verticalMovementParameters;
			}
			set
			{
				verticalMovementParameters = value;
			}
		}

		public WaterParameters WaterParameters
		{
			get
			{
				return waterParameters;
			}
			set
			{
				waterParameters = value;
			}
		}

		public int CurrentDance { get; private set; } = -1;

		public int ForceNetworkDanceState { get; set; } = -1;

		public bool IsCrouched => isCrouched;

		public bool IsRemote { get; set; }

		public int SwimLayer { get; private set; } = 1;

		public float SwimLayerWeight => _swimLayerWeight;

		public float TimeToGround => _timeToGround;

		public bool UseGravity
		{
			get
			{
				return VerticalMovementParameters.UseGravity;
			}
			set
			{
				VerticalMovementParameters.UseGravity = value;
			}
		}

		public float VerticalAxis { get; private set; }

		protected bool UnstableGroundedJumpAvailable
		{
			get
			{
				if (!VerticalMovementParameters.CanJumpOnUnstableGround)
				{
					return base.CharacterActor.CurrentState == CharacterActorState.UnstableGrounded;
				}
				return false;
			}
		}

		public event Action<int> OnDanceStateChanged;

		public event Action<bool> OnGroundedJumpPerformed;

		public event Action OnJumpPerformed;

		public event Action<int> OnNotGroundedJumpPerformed;

		public override void CheckExitTransition()
		{
			if (_ragdollQueued && _ragdollState != null)
			{
				base.CharacterStateController.EnqueueTransition<Ragdoll>();
			}
		}

		public override void EnterBehaviour(float dt, CharacterState fromState)
		{
			base.CharacterActor.alwaysNotGrounded = false;
			targetLookingDirection = base.CharacterActor.Forward;
			currentPlanarSpeedLimit = Mathf.Max(base.CharacterActor.PlanarVelocity.magnitude, PlanarMovementParameters.BaseSpeedLimit);
			base.CharacterActor.UseRootMotion = false;
			base.CharacterActor.OnWallHit += CharacterActor_OnWallHit;
			base.CharacterActor.OnHeadHit += CharacterActor_OnHeadHit;
			base.CharacterActor.OnGroundedStateEnter += CharacterActor_OnGroundedStateEnter;
		}

		public override void ExitBehaviour(float dt, CharacterState toState)
		{
			reducedAirControlFlag = false;
			_ragdollQueued = false;
			base.CharacterActor.OnWallHit -= CharacterActor_OnWallHit;
			base.CharacterActor.OnHeadHit -= CharacterActor_OnHeadHit;
			base.CharacterActor.OnGroundedStateEnter -= CharacterActor_OnGroundedStateEnter;
		}

		public override string GetInfo()
		{
			return "This state serves as a multi purpose movement based state. It is responsible for handling gravity and jump, walk and run, crouch, react to the different material properties, etc. Basically it covers all the common movements involved in a typical game, from a 3D platformer to a first person walking simulator.";
		}

		public override void PostCharacterSimulation(float dt)
		{
			if (base.CharacterActor.IsAnimatorValid())
			{
				float y = base.CharacterActor.LocalVelocity.y;
				base.CharacterStateController.Animator.SetFloat(verticalSpeedParameter, y);
				base.CharacterStateController.Animator.SetFloat(planarSpeedParameter, base.CharacterActor.PlanarVelocity.magnitude);
				float num = Mathf.Min((base.CharacterActor.PredictedGround != null) ? base.CharacterActor.PredictedGroundDistance : 40f, base.CharacterActor.Position.y - waterHeight);
				_timeToGround = (base.CharacterActor.IsGrounded ? 0f : 1f);
				if (!base.CharacterActor.IsGrounded && y < 0f)
				{
					_timeToGround = Mathf.Min(num / (0f - base.CharacterActor.LocalVelocity.y), 1f);
				}
				base.CharacterStateController.Animator.SetFloat(timeToGroundParameter, _timeToGround);
			}
		}

		public override void PreCharacterSimulation(float dt)
		{
			if (base.CharacterActor.IsAnimatorValid())
			{
				base.CharacterStateController.Animator.SetBool(groundedParameter, base.CharacterActor.IsGrounded);
				base.CharacterStateController.Animator.SetBool(stableParameter, base.CharacterActor.IsStable);
				if (!IsRemote)
				{
					HorizontalAxis = base.CharacterActions.Movement.value.x;
					VerticalAxis = base.CharacterActions.Movement.value.y;
					base.CharacterStateController.Animator.SetFloat(horizontalAxisParameter, HorizontalAxis);
					base.CharacterStateController.Animator.SetFloat(verticalAxisParameter, VerticalAxis);
				}
				base.CharacterStateController.Animator.SetFloat(heightParameter, base.CharacterActor.BodySize.y);
			}
		}

		public void ReduceAirControl(float reductionDuration = 0.5f)
		{
			reducedAirControlFlag = true;
			reducedAirControlInitialTime = Time.time;
			this.reductionDuration = reductionDuration;
		}

		public void SetRemoteCrouched(bool crouched)
		{
			wantToCrouch = crouched;
		}

		public void SetRemoteGroundedProperties(bool grounded, bool stable)
		{
			if (base.CharacterActor.IsAnimatorValid())
			{
				base.CharacterStateController.Animator.SetBool(groundedParameter, grounded);
				base.CharacterStateController.Animator.SetBool(stableParameter, stable);
			}
		}

		public void SetRemoteLayerWeight(int layer, float layerWeight)
		{
			if (base.CharacterActor.IsAnimatorValid())
			{
				base.CharacterStateController.Animator.SetLayerWeight(layer, layerWeight);
				switch (layer)
				{
				case 1:
					base.CharacterStateController.Animator.SetLayerWeight(2, 0f);
					break;
				case 2:
					base.CharacterStateController.Animator.SetLayerWeight(1, 0f);
					break;
				}
			}
		}

		public void SetRemoteSpeedProperties(float verticalSpeed, float planarSpeed, float horizontalAxis, float verticalAxis, float timeToGround)
		{
			if (base.CharacterActor.IsAnimatorValid())
			{
				base.CharacterStateController.Animator.SetFloat(heightParameter, base.CharacterActor.BodySize.y);
				base.CharacterStateController.Animator.SetFloat(verticalSpeedParameter, verticalSpeed);
				base.CharacterStateController.Animator.SetFloat(planarSpeedParameter, planarSpeed);
				base.CharacterStateController.Animator.SetFloat(timeToGroundParameter, timeToGround);
				base.CharacterStateController.Animator.SetFloat(horizontalAxisParameter, horizontalAxis);
				base.CharacterStateController.Animator.SetFloat(verticalAxisParameter, verticalAxis);
			}
		}

		public override void UpdateBehaviour(float dt)
		{
			HandleSize(dt);
			HandleDance(dt);
			if (!IsRemote)
			{
				HandleVelocity(dt);
			}
			HandleRotation(dt);
		}

		protected override void Awake()
		{
			base.Awake();
			notGroundedJumpsLeft = VerticalMovementParameters.AvailableNotGroundedJumps;
			_networkPlayerScript = GetComponentInParent<NetworkCharacterScript>();
			_ragdollState = GetComponent<Ragdoll>();
			_sampleWaterHelper = new SampleCollisionHelper();
		}

		protected virtual void HandleRotation(float dt)
		{
			HandleLookingDirection(dt);
		}

		protected virtual void HandleSize(float dt)
		{
			if (CrouchParameters.EnableCrouch)
			{
				if (!IsRemote)
				{
					if (CrouchParameters.InputMode == InputMode.Toggle)
					{
						if (base.CharacterActions.Crouch.Started)
						{
							wantToCrouch = !wantToCrouch;
						}
					}
					else
					{
						wantToCrouch = base.CharacterActions.Crouch.value;
					}
					if (!CrouchParameters.NotGroundedCrouch && !base.CharacterActor.IsGrounded)
					{
						wantToCrouch = false;
					}
					if (base.CharacterActor.IsGrounded && wantToRun)
					{
						wantToCrouch = false;
					}
				}
			}
			else
			{
				wantToCrouch = false;
			}
			if (wantToCrouch)
			{
				Crouch(dt);
			}
			else
			{
				StandUp(dt);
			}
		}

		protected virtual void HandleVelocity(float dt)
		{
			ProcessWater(dt);
			ProcessRigidbodyDrag(dt);
			ProcessVerticalMovement(dt);
			ProcessPlanarMovement(dt);
		}

		protected virtual void JumpDown(float dt)
		{
			float num = 0f;
			Vector3 vector = CustomUtilities.Multiply(base.CharacterActor.GroundVelocity, dt);
			if (!base.CharacterActor.IsGroundAscending)
			{
				num = vector.magnitude;
			}
			base.CharacterActor.ForceNotGrounded();
			base.CharacterActor.Position -= CustomUtilities.Multiply(base.CharacterActor.Up, 0.1f + VerticalMovementParameters.JumpDownDistance + num);
			base.CharacterActor.VerticalVelocity -= CustomUtilities.Multiply(base.CharacterActor.Up, VerticalMovementParameters.JumpDownVerticalVelocity);
		}

		protected virtual void OnDisable()
		{
			base.CharacterActor.OnTeleport -= OnTeleport;
		}

		protected virtual void OnEnable()
		{
			base.CharacterActor.OnTeleport += OnTeleport;
		}

		protected virtual void OnValidate()
		{
			VerticalMovementParameters.OnValidate();
		}

		protected virtual void ProcessGravity(float dt)
		{
			if (VerticalMovementParameters.UseGravity)
			{
				VerticalMovementParameters.UpdateParameters();
				float num = 1f;
				if (_underwaterPercent >= WaterParameters.MinDepthThreshold)
				{
					float num2 = WaterParameters.PreferredSurfaceSwimDepth - _underwaterPercent;
					num = ((!(num2 > 0f)) ? (num2 / (1f - WaterParameters.PreferredSurfaceSwimDepth) * WaterParameters.BuoyancyMultiplier) : (num2 / WaterParameters.PreferredSurfaceSwimDepth));
				}
				float floatValueA = num * VerticalMovementParameters.Gravity;
				if (!base.CharacterActor.IsStable)
				{
					base.CharacterActor.VerticalVelocity += CustomUtilities.Multiply(-base.CharacterActor.Up, floatValueA, dt);
				}
			}
		}

		protected virtual void ProcessJump(float dt)
		{
			ProcessRegularJump(dt);
			ProcessJumpDown(dt);
		}

		protected virtual bool ProcessJumpDown(float dt)
		{
			if (!VerticalMovementParameters.CanJumpDown)
			{
				return false;
			}
			if (!base.CharacterActor.IsStable)
			{
				return false;
			}
			if (!base.CharacterActor.IsGroundAOneWayPlatform)
			{
				return false;
			}
			if (VerticalMovementParameters.FilterByTag && !base.CharacterActor.GroundObject.CompareTag(VerticalMovementParameters.JumpDownTag))
			{
				return false;
			}
			if (!ProcessJumpDownAction())
			{
				return false;
			}
			JumpDown(dt);
			return true;
		}

		protected virtual bool ProcessJumpDownAction()
		{
			if (isCrouched)
			{
				return base.CharacterActions.Jump.Started;
			}
			return false;
		}

		protected virtual void ProcessPlanarMovement(float dt)
		{
			bool flag = CustomUtilities.Multiply(base.CharacterStateController.InputMovementReference, currentPlanarSpeedLimit).sqrMagnitude >= base.CharacterActor.PlanarVelocity.sqrMagnitude;
			Vector3 vector = default(Vector3);
			if (PlanarMovementParameters.RunInputMode == InputMode.Toggle)
			{
				if (base.CharacterActions.Run.Started && PlanarMovementParameters.CanRun)
				{
					wantToRun = !wantToRun;
				}
			}
			else if (PlanarMovementParameters.CanRun)
			{
				wantToRun = base.CharacterActions.Run.value;
			}
			else
			{
				wantToRun = false;
			}
			if (_underwaterPercent < waterParameters.SwimDepthThreshold)
			{
				switch (base.CharacterActor.CurrentState)
				{
				case CharacterActorState.NotGrounded:
					if (base.CharacterActor.WasGrounded)
					{
						currentPlanarSpeedLimit = Mathf.Max(base.CharacterActor.PlanarVelocity.magnitude, PlanarMovementParameters.BaseSpeedLimit);
					}
					vector = CustomUtilities.Multiply(base.CharacterStateController.InputMovementReference, 1f, currentPlanarSpeedLimit);
					break;
				case CharacterActorState.StableGrounded:
					if (wantToCrouch || !PlanarMovementParameters.CanRun)
					{
						wantToRun = false;
					}
					if (isCrouched)
					{
						currentPlanarSpeedLimit = PlanarMovementParameters.BaseSpeedLimit * CrouchParameters.SpeedMultiplier;
					}
					else
					{
						currentPlanarSpeedLimit = (wantToRun ? PlanarMovementParameters.BoostSpeedLimit : PlanarMovementParameters.BaseSpeedLimit);
					}
					vector = CustomUtilities.Multiply(base.CharacterStateController.InputMovementReference, 1f, currentPlanarSpeedLimit);
					break;
				case CharacterActorState.UnstableGrounded:
					currentPlanarSpeedLimit = PlanarMovementParameters.BaseSpeedLimit;
					vector = CustomUtilities.Multiply(base.CharacterStateController.InputMovementReference, 1f, currentPlanarSpeedLimit);
					break;
				}
			}
			else
			{
				currentPlanarSpeedLimit = (wantToRun ? WaterParameters.BoostSpeedLimit : WaterParameters.BaseSpeedLimit);
				vector = CustomUtilities.Multiply(base.CharacterStateController.InputMovementReference, 1f, currentPlanarSpeedLimit);
			}
			if (_underwaterPercent > waterParameters.MinDepthThreshold && _underwaterPercent < waterParameters.SwimDepthThreshold)
			{
				vector *= waterParameters.WalkSpeedDepthMuliplier.Evaluate(_underwaterPercent);
			}
			SetMotionValues(vector);
			float acceleration = currentMotion.Acceleration;
			acceleration = ((!flag) ? currentMotion.Deceleration : (acceleration * currentMotion.AngleAccelerationMultiplier));
			base.CharacterActor.PlanarVelocity = Vector3.MoveTowards(base.CharacterActor.PlanarVelocity, vector, acceleration * dt);
		}

		protected virtual void ProcessRegularJump(float dt)
		{
			if (base.CharacterActor.IsGrounded)
			{
				notGroundedJumpsLeft = VerticalMovementParameters.AvailableNotGroundedJumps;
				groundedJumpAvailable = true;
			}
			if (isAllowedToCancelJump)
			{
				if (VerticalMovementParameters.CancelJumpOnRelease)
				{
					if (base.CharacterActions.Jump.StartedElapsedTime >= VerticalMovementParameters.CancelJumpMaxTime || base.CharacterActor.IsFalling)
					{
						isAllowedToCancelJump = false;
					}
					else if (!base.CharacterActions.Jump.value && base.CharacterActions.Jump.StartedElapsedTime >= VerticalMovementParameters.CancelJumpMinTime)
					{
						Vector3 vectorValue = Vector3.Project(base.CharacterActor.Velocity, jumpDirection);
						base.CharacterActor.Velocity -= CustomUtilities.Multiply(vectorValue, 1f - VerticalMovementParameters.CancelJumpMultiplier);
						isAllowedToCancelJump = false;
					}
				}
				return;
			}
			switch (CanJump())
			{
			case JumpResult.Grounded:
				groundedJumpAvailable = false;
				break;
			case JumpResult.NotGrounded:
				notGroundedJumpsLeft--;
				break;
			case JumpResult.Invalid:
				return;
			}
			if (base.CharacterActor.IsGrounded)
			{
				this.OnGroundedJumpPerformed?.Invoke(obj: true);
			}
			else
			{
				this.OnNotGroundedJumpPerformed?.Invoke(notGroundedJumpsLeft);
			}
			this.OnJumpPerformed?.Invoke();
			jumpDirection = SetJumpDirection();
			if (base.CharacterActor.IsGrounded)
			{
				base.CharacterActor.ForceNotGrounded();
			}
			base.CharacterActor.Velocity -= Vector3.Project(base.CharacterActor.Velocity, jumpDirection);
			base.CharacterActor.Velocity += CustomUtilities.Multiply(jumpDirection, VerticalMovementParameters.JumpSpeed);
			if (VerticalMovementParameters.CancelJumpOnRelease)
			{
				isAllowedToCancelJump = true;
			}
		}

		protected virtual Vector3 SetJumpDirection()
		{
			return base.CharacterActor.Up;
		}

		protected override void Start()
		{
			base.Start();
			targetHeight = base.CharacterActor.DefaultBodySize.y;
			float a = base.CharacterActor.BodySize.x / base.CharacterActor.BodySize.y;
			CrouchParameters.HeightRatio = Mathf.Max(a, CrouchParameters.HeightRatio);
		}

		private JumpResult CanJump()
		{
			JumpResult result = JumpResult.Invalid;
			if (!VerticalMovementParameters.CanJump)
			{
				return result;
			}
			if (isCrouched)
			{
				return result;
			}
			switch (base.CharacterActor.CurrentState)
			{
			case CharacterActorState.StableGrounded:
				if (base.CharacterActions.Jump.StartedElapsedTime <= VerticalMovementParameters.PreGroundedJumpTime && groundedJumpAvailable)
				{
					result = JumpResult.Grounded;
				}
				break;
			case CharacterActorState.NotGrounded:
				if (base.CharacterActions.Jump.Started)
				{
					if (base.CharacterActor.NotGroundedTime <= VerticalMovementParameters.PostGroundedJumpTime && groundedJumpAvailable)
					{
						result = JumpResult.Grounded;
					}
					else if (notGroundedJumpsLeft != 0)
					{
						result = JumpResult.NotGrounded;
					}
				}
				break;
			case CharacterActorState.UnstableGrounded:
				if (base.CharacterActions.Jump.StartedElapsedTime <= VerticalMovementParameters.PreGroundedJumpTime && VerticalMovementParameters.CanJumpOnUnstableGround)
				{
					result = JumpResult.Grounded;
				}
				break;
			}
			return result;
		}

		private void CharacterActor_OnGroundedStateEnter(Vector3 localLinearVelocity)
		{
			if (!(_ragdollState == null))
			{
				float num = Vector3.Dot(localLinearVelocity, base.CharacterActor.GroundContactNormal);
				if (Vector3.Dot(localLinearVelocity, base.CharacterActor.LocalPlanarVelocity) > 1200f || num < -20f)
				{
					_ragdollQueued = true;
				}
			}
		}

		private void CharacterActor_OnHeadHit(Contact contact)
		{
			ProcessContact(contact, 2f);
		}

		private void CharacterActor_OnWallHit(Contact contact)
		{
			ProcessContact(contact);
		}

		private void Crouch(float dt)
		{
			CharacterActor.SizeReferenceType sizeReferenceType = (base.CharacterActor.IsGrounded ? CharacterActor.SizeReferenceType.Bottom : CrouchParameters.NotGroundedReference);
			if (base.CharacterActor.CheckAndInterpolateHeight(base.CharacterActor.DefaultBodySize.y * CrouchParameters.HeightRatio, CrouchParameters.SizeLerpSpeed * dt, sizeReferenceType))
			{
				isCrouched = true;
			}
		}

		private void HandleDance(float dt)
		{
			if (ForceNetworkDanceState < 0)
			{
				if (base.CharacterActions.Dance.value && base.CharacterActions.Dance.ActiveTime > 0.25f && base.CharacterActor.IsGrounded && base.CharacterActor.IsStable)
				{
					CurrentDance = (int)CharacterManager.Instance.SelectedCharacter.Dance;
				}
				else
				{
					CurrentDance = -1;
				}
			}
			else
			{
				CurrentDance = ForceNetworkDanceState;
			}
			if (CurrentDance != lastDance)
			{
				base.CharacterStateController.Animator.SetInteger(danceParameter, CurrentDance);
				this.OnDanceStateChanged?.Invoke(CurrentDance);
				lastDance = CurrentDance;
			}
		}

		private void HandleLookingDirection(float dt)
		{
			if (!LookingDirectionParameters.ChangeLookingDirection)
			{
				return;
			}
			switch (LookingDirectionParameters.LookDirectionMode)
			{
			case LookingDirectionParameters.LookingDirectionMode.Movement:
				switch (base.CharacterActor.CurrentState)
				{
				case CharacterActorState.NotGrounded:
					SetTargetLookingDirection(LookingDirectionParameters.NotGroundedLookingDirectionMode);
					break;
				case CharacterActorState.StableGrounded:
					SetTargetLookingDirection(LookingDirectionParameters.StableGroundedLookingDirectionMode);
					break;
				case CharacterActorState.UnstableGrounded:
					SetTargetLookingDirection(LookingDirectionParameters.UnstableGroundedLookingDirectionMode);
					break;
				}
				break;
			case LookingDirectionParameters.LookingDirectionMode.ExternalReference:
				if (!base.CharacterActor.CharacterBody.Is2D)
				{
					targetLookingDirection = base.CharacterStateController.MovementReferenceForward;
				}
				break;
			case LookingDirectionParameters.LookingDirectionMode.Target:
				targetLookingDirection = LookingDirectionParameters.Target.position - base.CharacterActor.Position;
				targetLookingDirection.Normalize();
				break;
			}
			Quaternion b = Quaternion.FromToRotation(base.CharacterActor.Forward, targetLookingDirection);
			Quaternion quaternion = Quaternion.Slerp(Quaternion.identity, b, LookingDirectionParameters.Speed * dt);
			if (base.CharacterActor.CharacterBody.Is2D)
			{
				base.CharacterActor.SetYaw(targetLookingDirection);
			}
			else
			{
				base.CharacterActor.SetYaw(quaternion * base.CharacterActor.Forward);
			}
		}

		private void OnTeleport(Vector3 position, Quaternion rotation)
		{
			targetLookingDirection = base.CharacterActor.Forward;
			isAllowedToCancelJump = false;
		}

		private void ProcessContact(Contact contact, float forceMultiplier = 1f)
		{
			if (!(_ragdollState == null))
			{
				float num = Mathf.Abs(Vector3.Dot(contact.normal, contact.relativeVelocity));
				Rigidbody rigidbody = contact.collider3D?.attachedRigidbody;
				if (rigidbody != null && rigidbody.mass < base.CharacterActor.RigidbodyComponent.Mass)
				{
					num *= rigidbody.mass / base.CharacterActor.RigidbodyComponent.Mass;
				}
				int num2 = 10;
				Debug.Log(num);
				if (num > (float)num2 / forceMultiplier)
				{
					_ragdollQueued = true;
				}
			}
		}

		private void ProcessRigidbodyDrag(float dt)
		{
			base.CharacterActor.RigidbodyComponent.LinearDrag = Mathf.Lerp(_linearDrag, WaterParameters.UnderwaterDrag, _underwaterPercent);
		}

		private void ProcessVerticalMovement(float dt)
		{
			ProcessGravity(dt);
			ProcessJump(dt);
		}

		private void ProcessWater(float dt)
		{
			if (!_sampleWaterHelper.SampleHeight(base.CharacterActor.Position, out var height, base.CharacterActor.BodySize.x))
			{
				return;
			}
			waterHeight = height;
			_underwaterPercent = Mathf.Clamp01((height - base.CharacterActor.Position.y) / base.CharacterActor.BodySize.y);
			SwimLayer = ((LookingDirectionParameters.LookDirectionMode == LookingDirectionParameters.LookingDirectionMode.ExternalReference) ? 1 : 2);
			int layerIndex = ((SwimLayer != 1) ? 1 : 2);
			if (_underwaterPercent >= WaterParameters.SwimDepthThreshold)
			{
				if (_swimLayerWeight < 1f)
				{
					_swimLayerWeight = Mathf.Clamp01(_swimLayerWeight + dt / waterParameters.SwimTransitionTime);
				}
				if (base.CharacterActor.IsGrounded)
				{
					base.CharacterActor.ForceNotGrounded();
				}
				if (!base.CharacterActor.alwaysNotGrounded)
				{
					base.CharacterActor.alwaysNotGrounded = true;
				}
				if (_underwaterPercent < 0.99f)
				{
					notGroundedJumpsLeft = WaterParameters.JumpsAvailableNearSurface;
				}
				else
				{
					notGroundedJumpsLeft = 0;
				}
			}
			else
			{
				if (_swimLayerWeight > 0f)
				{
					_swimLayerWeight = Mathf.Clamp01(_swimLayerWeight - dt / waterParameters.SwimTransitionTime);
				}
				if (base.CharacterActor.alwaysNotGrounded)
				{
					base.CharacterActor.alwaysNotGrounded = false;
				}
			}
			base.CharacterStateController.Animator.SetLayerWeight(SwimLayer, _swimLayerWeight);
			base.CharacterStateController.Animator.SetLayerWeight(layerIndex, 0f);
		}

		private void SetMotionValues(Vector3 targetPlanarVelocity)
		{
			float time = Vector3.Angle(base.CharacterActor.PlanarVelocity, targetPlanarVelocity);
			if (_underwaterPercent < WaterParameters.SwimDepthThreshold)
			{
				switch (base.CharacterActor.CurrentState)
				{
				case CharacterActorState.StableGrounded:
					currentMotion.Acceleration = PlanarMovementParameters.StableGroundedAcceleration;
					currentMotion.Deceleration = PlanarMovementParameters.StableGroundedDeceleration;
					currentMotion.AngleAccelerationMultiplier = PlanarMovementParameters.StableGroundedAngleAccelerationBoost.Evaluate(time);
					break;
				case CharacterActorState.UnstableGrounded:
					currentMotion.Acceleration = PlanarMovementParameters.UnstableGroundedAcceleration;
					currentMotion.Deceleration = PlanarMovementParameters.UnstableGroundedDeceleration;
					currentMotion.AngleAccelerationMultiplier = PlanarMovementParameters.UnstableGroundedAngleAccelerationBoost.Evaluate(time);
					break;
				case CharacterActorState.NotGrounded:
					if (reducedAirControlFlag)
					{
						float num = Time.time - reducedAirControlInitialTime;
						if (num <= reductionDuration)
						{
							currentMotion.Acceleration = PlanarMovementParameters.NotGroundedAcceleration / reductionDuration * num;
							currentMotion.Deceleration = PlanarMovementParameters.NotGroundedDeceleration / reductionDuration * num;
						}
						else
						{
							reducedAirControlFlag = false;
							currentMotion.Acceleration = PlanarMovementParameters.NotGroundedAcceleration;
							currentMotion.Deceleration = PlanarMovementParameters.NotGroundedDeceleration;
						}
					}
					else
					{
						currentMotion.Acceleration = PlanarMovementParameters.NotGroundedAcceleration;
						currentMotion.Deceleration = PlanarMovementParameters.NotGroundedDeceleration;
					}
					currentMotion.AngleAccelerationMultiplier = PlanarMovementParameters.NotGroundedAngleAccelerationBoost.Evaluate(time);
					break;
				}
			}
			else
			{
				currentMotion.Acceleration = WaterParameters.SwimAcceleration;
				currentMotion.Deceleration = WaterParameters.SwimDeceleration;
				currentMotion.AngleAccelerationMultiplier = PlanarMovementParameters.StableGroundedAngleAccelerationBoost.Evaluate(time);
			}
			if (_underwaterPercent > waterParameters.MinDepthThreshold && _underwaterPercent < waterParameters.SwimDepthThreshold)
			{
				currentMotion.Acceleration *= waterParameters.WalkSpeedDepthMuliplier.Evaluate(_underwaterPercent);
				currentMotion.Deceleration /= waterParameters.WalkSpeedDepthMuliplier.Evaluate(_underwaterPercent);
			}
		}

		private void SetTargetLookingDirection(LookingDirectionParameters.LookingDirectionMovementSource lookingDirectionMode)
		{
			if (lookingDirectionMode == LookingDirectionParameters.LookingDirectionMovementSource.Input)
			{
				if (base.CharacterStateController.InputMovementReference != Vector3.zero)
				{
					targetLookingDirection = base.CharacterStateController.InputMovementReference;
				}
				else
				{
					targetLookingDirection = base.CharacterActor.Forward;
				}
			}
			else if (base.CharacterActor.PlanarVelocity != Vector3.zero)
			{
				targetLookingDirection = Vector3.ProjectOnPlane(base.CharacterActor.PlanarVelocity, base.CharacterActor.Up);
			}
			else
			{
				targetLookingDirection = base.CharacterActor.Forward;
			}
		}

		private void StandUp(float dt)
		{
			CharacterActor.SizeReferenceType sizeReferenceType = (base.CharacterActor.IsGrounded ? CharacterActor.SizeReferenceType.Bottom : CrouchParameters.NotGroundedReference);
			if (base.CharacterActor.CheckAndInterpolateHeight(base.CharacterActor.DefaultBodySize.y, CrouchParameters.SizeLerpSpeed * dt, sizeReferenceType))
			{
				isCrouched = false;
			}
		}
	}
}
