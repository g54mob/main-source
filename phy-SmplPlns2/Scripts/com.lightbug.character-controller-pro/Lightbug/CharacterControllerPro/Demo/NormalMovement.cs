using System;
using Lightbug.CharacterControllerPro.Core;
using Lightbug.CharacterControllerPro.Implementation;
using Lightbug.Utilities;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Demo
{
	[AddComponentMenu("Character Controller Pro/Demo/Character/States/Normal Movement")]
	public class NormalMovement : CharacterState
	{
		public enum JumpResult
		{
			Invalid = 0,
			Grounded = 1,
			NotGrounded = 2
		}

		[Space(10f)]
		public PlanarMovementParameters planarMovementParameters = new PlanarMovementParameters();

		public VerticalMovementParameters verticalMovementParameters = new VerticalMovementParameters();

		public CrouchParameters crouchParameters = new CrouchParameters();

		public LookingDirectionParameters lookingDirectionParameters = new LookingDirectionParameters();

		[Header("Animation")]
		[SerializeField]
		protected string groundedParameter = "Grounded";

		[SerializeField]
		protected string stableParameter = "Stable";

		[SerializeField]
		protected string verticalSpeedParameter = "VerticalSpeed";

		[SerializeField]
		protected string planarSpeedParameter = "PlanarSpeed";

		[SerializeField]
		protected string horizontalAxisParameter = "HorizontalAxis";

		[SerializeField]
		protected string verticalAxisParameter = "VerticalAxis";

		[SerializeField]
		protected string heightParameter = "Height";

		protected MaterialController materialController;

		protected int notGroundedJumpsLeft;

		protected bool isAllowedToCancelJump;

		protected bool wantToRun;

		protected float currentPlanarSpeedLimit;

		protected bool groundedJumpAvailable = true;

		protected Vector3 jumpDirection;

		protected Vector3 targetLookingDirection;

		protected float targetHeight = 1f;

		protected bool wantToCrouch;

		protected bool isCrouched;

		protected PlanarMovementParameters.PlanarMovementProperties currentMotion;

		private bool reducedAirControlFlag;

		private float reducedAirControlInitialTime;

		private float reductionDuration = 0.5f;

		public bool UseGravity
		{
			get
			{
				return verticalMovementParameters.useGravity;
			}
			set
			{
				verticalMovementParameters.useGravity = value;
			}
		}

		protected bool UnstableGroundedJumpAvailable
		{
			get
			{
				if (!verticalMovementParameters.canJumpOnUnstableGround)
				{
					return base.CharacterActor.CurrentState == CharacterActorState.UnstableGrounded;
				}
				return false;
			}
		}

		public event Action OnJumpPerformed;

		public event Action<bool> OnGroundedJumpPerformed;

		public event Action<int> OnNotGroundedJumpPerformed;

		protected override void Awake()
		{
			base.Awake();
			notGroundedJumpsLeft = verticalMovementParameters.availableNotGroundedJumps;
			materialController = this.GetComponentInBranch<CharacterActor, MaterialController>();
		}

		protected virtual void OnValidate()
		{
			verticalMovementParameters.OnValidate();
		}

		protected override void Start()
		{
			base.Start();
			targetHeight = base.CharacterActor.DefaultBodySize.y;
			float a = base.CharacterActor.BodySize.x / base.CharacterActor.BodySize.y;
			crouchParameters.heightRatio = Mathf.Max(a, crouchParameters.heightRatio);
		}

		protected virtual void OnEnable()
		{
			base.CharacterActor.OnTeleport += OnTeleport;
		}

		protected virtual void OnDisable()
		{
			base.CharacterActor.OnTeleport -= OnTeleport;
		}

		public override string GetInfo()
		{
			return "This state serves as a multi purpose movement based state. It is responsible for handling gravity and jump, walk and run, crouch, react to the different material properties, etc. Basically it covers all the common movements involved in a typical game, from a 3D platformer to a first person walking simulator.";
		}

		private void OnTeleport(Vector3 position, Quaternion rotation)
		{
			targetLookingDirection = base.CharacterActor.Forward;
			isAllowedToCancelJump = false;
		}

		public override void CheckExitTransition()
		{
			if (base.CharacterActions.jetPack.value)
			{
				base.CharacterStateController.EnqueueTransition<JetPack>();
			}
			else if (base.CharacterActions.dash.Started)
			{
				base.CharacterStateController.EnqueueTransition<Dash>();
			}
			else if (base.CharacterActor.Triggers.Count != 0)
			{
				base.CharacterStateController.EnqueueTransition<LadderClimbing>();
				base.CharacterStateController.EnqueueTransition<RopeClimbing>();
			}
			else if (!base.CharacterActor.IsGrounded)
			{
				if (!base.CharacterActions.crouch.value)
				{
					base.CharacterStateController.EnqueueTransition<WallSlide>();
				}
				base.CharacterStateController.EnqueueTransition<LedgeHanging>();
			}
		}

		public override void ExitBehaviour(float dt, CharacterState toState)
		{
			reducedAirControlFlag = false;
		}

		public void ReduceAirControl(float reductionDuration = 0.5f)
		{
			reducedAirControlFlag = true;
			reducedAirControlInitialTime = Time.time;
			this.reductionDuration = reductionDuration;
		}

		private void SetMotionValues(Vector3 targetPlanarVelocity)
		{
			float time = Vector3.Angle(base.CharacterActor.PlanarVelocity, targetPlanarVelocity);
			switch (base.CharacterActor.CurrentState)
			{
			case CharacterActorState.StableGrounded:
				currentMotion.acceleration = planarMovementParameters.stableGroundedAcceleration;
				currentMotion.deceleration = planarMovementParameters.stableGroundedDeceleration;
				currentMotion.angleAccelerationMultiplier = planarMovementParameters.stableGroundedAngleAccelerationBoost.Evaluate(time);
				break;
			case CharacterActorState.UnstableGrounded:
				currentMotion.acceleration = planarMovementParameters.unstableGroundedAcceleration;
				currentMotion.deceleration = planarMovementParameters.unstableGroundedDeceleration;
				currentMotion.angleAccelerationMultiplier = planarMovementParameters.unstableGroundedAngleAccelerationBoost.Evaluate(time);
				break;
			case CharacterActorState.NotGrounded:
				if (reducedAirControlFlag)
				{
					float num = Time.time - reducedAirControlInitialTime;
					if (num <= reductionDuration)
					{
						currentMotion.acceleration = planarMovementParameters.notGroundedAcceleration / reductionDuration * num;
						currentMotion.deceleration = planarMovementParameters.notGroundedDeceleration / reductionDuration * num;
					}
					else
					{
						reducedAirControlFlag = false;
						currentMotion.acceleration = planarMovementParameters.notGroundedAcceleration;
						currentMotion.deceleration = planarMovementParameters.notGroundedDeceleration;
					}
				}
				else
				{
					currentMotion.acceleration = planarMovementParameters.notGroundedAcceleration;
					currentMotion.deceleration = planarMovementParameters.notGroundedDeceleration;
				}
				currentMotion.angleAccelerationMultiplier = planarMovementParameters.notGroundedAngleAccelerationBoost.Evaluate(time);
				break;
			}
			if (materialController != null)
			{
				if (base.CharacterActor.IsGrounded)
				{
					currentMotion.acceleration *= materialController.CurrentSurface.accelerationMultiplier * materialController.CurrentVolume.accelerationMultiplier;
					currentMotion.deceleration *= materialController.CurrentSurface.decelerationMultiplier * materialController.CurrentVolume.decelerationMultiplier;
				}
				else
				{
					currentMotion.acceleration *= materialController.CurrentVolume.accelerationMultiplier;
					currentMotion.deceleration *= materialController.CurrentVolume.decelerationMultiplier;
				}
			}
		}

		protected virtual void ProcessPlanarMovement(float dt)
		{
			float floatValueA = ((materialController != null) ? (materialController.CurrentSurface.speedMultiplier * materialController.CurrentVolume.speedMultiplier) : 1f);
			bool flag = CustomUtilities.Multiply(base.CharacterStateController.InputMovementReference, currentPlanarSpeedLimit).sqrMagnitude >= base.CharacterActor.PlanarVelocity.sqrMagnitude;
			Vector3 vector = default(Vector3);
			switch (base.CharacterActor.CurrentState)
			{
			case CharacterActorState.NotGrounded:
				if (base.CharacterActor.WasGrounded)
				{
					currentPlanarSpeedLimit = Mathf.Max(base.CharacterActor.PlanarVelocity.magnitude, planarMovementParameters.baseSpeedLimit);
				}
				vector = CustomUtilities.Multiply(base.CharacterStateController.InputMovementReference, floatValueA, currentPlanarSpeedLimit);
				break;
			case CharacterActorState.StableGrounded:
				if (planarMovementParameters.runInputMode == InputMode.Toggle)
				{
					if (base.CharacterActions.run.Started)
					{
						wantToRun = !wantToRun;
					}
				}
				else
				{
					wantToRun = base.CharacterActions.run.value;
				}
				if (wantToCrouch || !planarMovementParameters.canRun)
				{
					wantToRun = false;
				}
				if (isCrouched)
				{
					currentPlanarSpeedLimit = planarMovementParameters.baseSpeedLimit * crouchParameters.speedMultiplier;
				}
				else
				{
					currentPlanarSpeedLimit = (wantToRun ? planarMovementParameters.boostSpeedLimit : planarMovementParameters.baseSpeedLimit);
				}
				vector = CustomUtilities.Multiply(base.CharacterStateController.InputMovementReference, floatValueA, currentPlanarSpeedLimit);
				break;
			case CharacterActorState.UnstableGrounded:
				currentPlanarSpeedLimit = planarMovementParameters.baseSpeedLimit;
				vector = CustomUtilities.Multiply(base.CharacterStateController.InputMovementReference, floatValueA, currentPlanarSpeedLimit);
				break;
			}
			SetMotionValues(vector);
			float acceleration = currentMotion.acceleration;
			acceleration = ((!flag) ? currentMotion.deceleration : (acceleration * currentMotion.angleAccelerationMultiplier));
			base.CharacterActor.PlanarVelocity = Vector3.MoveTowards(base.CharacterActor.PlanarVelocity, vector, acceleration * dt);
		}

		protected virtual void ProcessGravity(float dt)
		{
			if (verticalMovementParameters.useGravity)
			{
				verticalMovementParameters.UpdateParameters();
				float num = 1f;
				if (materialController != null)
				{
					num = ((base.CharacterActor.LocalVelocity.y >= 0f) ? materialController.CurrentVolume.gravityAscendingMultiplier : materialController.CurrentVolume.gravityDescendingMultiplier);
				}
				float floatValueA = num * verticalMovementParameters.gravity;
				if (!base.CharacterActor.IsStable)
				{
					base.CharacterActor.VerticalVelocity += CustomUtilities.Multiply(-base.CharacterActor.Up, floatValueA, dt);
				}
			}
		}

		private JumpResult CanJump()
		{
			JumpResult result = JumpResult.Invalid;
			if (!verticalMovementParameters.canJump)
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
				if (base.CharacterActions.jump.StartedElapsedTime <= verticalMovementParameters.preGroundedJumpTime && groundedJumpAvailable)
				{
					result = JumpResult.Grounded;
				}
				break;
			case CharacterActorState.NotGrounded:
				if (base.CharacterActions.jump.Started)
				{
					if (base.CharacterActor.NotGroundedTime <= verticalMovementParameters.postGroundedJumpTime && groundedJumpAvailable)
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
				if (base.CharacterActions.jump.StartedElapsedTime <= verticalMovementParameters.preGroundedJumpTime && verticalMovementParameters.canJumpOnUnstableGround)
				{
					result = JumpResult.Grounded;
				}
				break;
			}
			return result;
		}

		protected virtual void ProcessJump(float dt)
		{
			ProcessRegularJump(dt);
			ProcessJumpDown(dt);
		}

		protected virtual bool ProcessJumpDown(float dt)
		{
			if (!verticalMovementParameters.canJumpDown)
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
			if (verticalMovementParameters.filterByTag && !base.CharacterActor.GroundObject.CompareTag(verticalMovementParameters.jumpDownTag))
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
				return base.CharacterActions.jump.Started;
			}
			return false;
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
			base.CharacterActor.Position -= CustomUtilities.Multiply(base.CharacterActor.Up, 0.1f + verticalMovementParameters.jumpDownDistance + num);
			base.CharacterActor.VerticalVelocity -= CustomUtilities.Multiply(base.CharacterActor.Up, verticalMovementParameters.jumpDownVerticalVelocity);
		}

		protected virtual void ProcessRegularJump(float dt)
		{
			if (base.CharacterActor.IsGrounded)
			{
				notGroundedJumpsLeft = verticalMovementParameters.availableNotGroundedJumps;
				groundedJumpAvailable = true;
			}
			if (isAllowedToCancelJump)
			{
				if (verticalMovementParameters.cancelJumpOnRelease)
				{
					if (base.CharacterActions.jump.StartedElapsedTime >= verticalMovementParameters.cancelJumpMaxTime || base.CharacterActor.IsFalling)
					{
						isAllowedToCancelJump = false;
					}
					else if (!base.CharacterActions.jump.value && base.CharacterActions.jump.StartedElapsedTime >= verticalMovementParameters.cancelJumpMinTime)
					{
						Vector3 vectorValue = Vector3.Project(base.CharacterActor.Velocity, jumpDirection);
						base.CharacterActor.Velocity -= CustomUtilities.Multiply(vectorValue, 1f - verticalMovementParameters.cancelJumpMultiplier);
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
				if (this.OnGroundedJumpPerformed != null)
				{
					this.OnGroundedJumpPerformed(obj: true);
				}
			}
			else if (this.OnNotGroundedJumpPerformed != null)
			{
				this.OnNotGroundedJumpPerformed(notGroundedJumpsLeft);
			}
			if (this.OnJumpPerformed != null)
			{
				this.OnJumpPerformed();
			}
			jumpDirection = SetJumpDirection();
			if (base.CharacterActor.IsGrounded)
			{
				base.CharacterActor.ForceNotGrounded();
			}
			base.CharacterActor.Velocity -= Vector3.Project(base.CharacterActor.Velocity, jumpDirection);
			base.CharacterActor.Velocity += CustomUtilities.Multiply(jumpDirection, verticalMovementParameters.jumpSpeed);
			if (verticalMovementParameters.cancelJumpOnRelease)
			{
				isAllowedToCancelJump = true;
			}
		}

		protected virtual Vector3 SetJumpDirection()
		{
			return base.CharacterActor.Up;
		}

		private void ProcessVerticalMovement(float dt)
		{
			ProcessGravity(dt);
			ProcessJump(dt);
		}

		public override void EnterBehaviour(float dt, CharacterState fromState)
		{
			base.CharacterActor.alwaysNotGrounded = false;
			targetLookingDirection = base.CharacterActor.Forward;
			if (fromState == base.CharacterStateController.GetState<WallSlide>())
			{
				notGroundedJumpsLeft = verticalMovementParameters.availableNotGroundedJumps + 1;
				ReduceAirControl();
			}
			currentPlanarSpeedLimit = Mathf.Max(base.CharacterActor.PlanarVelocity.magnitude, planarMovementParameters.baseSpeedLimit);
			base.CharacterActor.UseRootMotion = false;
		}

		protected virtual void HandleRotation(float dt)
		{
			HandleLookingDirection(dt);
		}

		private void HandleLookingDirection(float dt)
		{
			if (!lookingDirectionParameters.changeLookingDirection)
			{
				return;
			}
			switch (lookingDirectionParameters.lookingDirectionMode)
			{
			case LookingDirectionParameters.LookingDirectionMode.Movement:
				switch (base.CharacterActor.CurrentState)
				{
				case CharacterActorState.NotGrounded:
					SetTargetLookingDirection(lookingDirectionParameters.notGroundedLookingDirectionMode);
					break;
				case CharacterActorState.StableGrounded:
					SetTargetLookingDirection(lookingDirectionParameters.stableGroundedLookingDirectionMode);
					break;
				case CharacterActorState.UnstableGrounded:
					SetTargetLookingDirection(lookingDirectionParameters.unstableGroundedLookingDirectionMode);
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
				targetLookingDirection = lookingDirectionParameters.target.position - base.CharacterActor.Position;
				targetLookingDirection.Normalize();
				break;
			}
			Quaternion b = Quaternion.FromToRotation(base.CharacterActor.Forward, targetLookingDirection);
			Quaternion quaternion = Quaternion.Slerp(Quaternion.identity, b, lookingDirectionParameters.speed * dt);
			if (base.CharacterActor.CharacterBody.Is2D)
			{
				base.CharacterActor.SetYaw(targetLookingDirection);
			}
			else
			{
				base.CharacterActor.SetYaw(quaternion * base.CharacterActor.Forward);
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

		public override void UpdateBehaviour(float dt)
		{
			HandleSize(dt);
			HandleVelocity(dt);
			HandleRotation(dt);
		}

		public override void PreCharacterSimulation(float dt)
		{
			if (base.CharacterActor.IsAnimatorValid())
			{
				base.CharacterStateController.Animator.SetBool(groundedParameter, base.CharacterActor.IsGrounded);
				base.CharacterStateController.Animator.SetBool(stableParameter, base.CharacterActor.IsStable);
				base.CharacterStateController.Animator.SetFloat(horizontalAxisParameter, base.CharacterActions.movement.value.x);
				base.CharacterStateController.Animator.SetFloat(verticalAxisParameter, base.CharacterActions.movement.value.y);
				base.CharacterStateController.Animator.SetFloat(heightParameter, base.CharacterActor.BodySize.y);
			}
		}

		public override void PostCharacterSimulation(float dt)
		{
			if (base.CharacterActor.IsAnimatorValid())
			{
				base.CharacterStateController.Animator.SetFloat(verticalSpeedParameter, base.CharacterActor.LocalVelocity.y);
				base.CharacterStateController.Animator.SetFloat(planarSpeedParameter, base.CharacterActor.PlanarVelocity.magnitude);
			}
		}

		protected virtual void HandleSize(float dt)
		{
			if (crouchParameters.enableCrouch)
			{
				if (crouchParameters.inputMode == InputMode.Toggle)
				{
					if (base.CharacterActions.crouch.Started)
					{
						wantToCrouch = !wantToCrouch;
					}
				}
				else
				{
					wantToCrouch = base.CharacterActions.crouch.value;
				}
				if (!crouchParameters.notGroundedCrouch && !base.CharacterActor.IsGrounded)
				{
					wantToCrouch = false;
				}
				if (base.CharacterActor.IsGrounded && wantToRun)
				{
					wantToCrouch = false;
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

		private void Crouch(float dt)
		{
			CharacterActor.SizeReferenceType sizeReferenceType = (base.CharacterActor.IsGrounded ? CharacterActor.SizeReferenceType.Bottom : crouchParameters.notGroundedReference);
			if (base.CharacterActor.CheckAndInterpolateHeight(base.CharacterActor.DefaultBodySize.y * crouchParameters.heightRatio, crouchParameters.sizeLerpSpeed * dt, sizeReferenceType))
			{
				isCrouched = true;
			}
		}

		private void StandUp(float dt)
		{
			CharacterActor.SizeReferenceType sizeReferenceType = (base.CharacterActor.IsGrounded ? CharacterActor.SizeReferenceType.Bottom : crouchParameters.notGroundedReference);
			if (base.CharacterActor.CheckAndInterpolateHeight(base.CharacterActor.DefaultBodySize.y, crouchParameters.sizeLerpSpeed * dt, sizeReferenceType))
			{
				isCrouched = false;
			}
		}

		protected virtual void HandleVelocity(float dt)
		{
			ProcessVerticalMovement(dt);
			ProcessPlanarMovement(dt);
		}
	}
}
