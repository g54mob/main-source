using Lightbug.CharacterControllerPro.Core;
using Lightbug.CharacterControllerPro.Implementation;
using Lightbug.Utilities;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Demo
{
	[AddComponentMenu("Character Controller Pro/Demo/Character/States/Ledge Hanging")]
	public class LedgeHanging : CharacterState
	{
		public enum LedgeHangingState
		{
			Idle = 0,
			TopUp = 1
		}

		[Header("Filter")]
		[SerializeField]
		protected LayerMask layerMask = 0;

		[SerializeField]
		protected bool filterByTag;

		[SerializeField]
		protected string tagName = "Untagged";

		[SerializeField]
		protected bool detectRigidbodies;

		[Header("Detection")]
		[SerializeField]
		protected bool groundedDetection;

		[Tooltip("How far the hands are from the character along the forward direction.")]
		[Min(0f)]
		[SerializeField]
		protected float forwardDetectionOffset = 0.5f;

		[Tooltip("How far the hands are from the character along the up direction.")]
		[Min(0.05f)]
		[SerializeField]
		protected float upwardsDetectionOffset = 1.8f;

		[Min(0.05f)]
		[SerializeField]
		protected float separationBetweenHands = 1f;

		[Tooltip("The distance used by the raycast methods.")]
		[Min(0.05f)]
		[SerializeField]
		protected float ledgeDetectionDistance = 0.05f;

		[Header("Offset")]
		[SerializeField]
		protected float verticalOffset;

		[SerializeField]
		protected float forwardOffset;

		[Header("Movement")]
		public float ledgeJumpVelocity = 10f;

		[SerializeField]
		protected bool autoClimbUp = true;

		[Tooltip("If the previous state (\"fromState\") is contained in this list the autoClimbUp flag will be triggered.")]
		[SerializeField]
		protected CharacterState[] forceAutoClimbUpStates;

		[Header("Animation")]
		[SerializeField]
		protected string topUpParameter = "TopUp";

		protected const float MaxLedgeVerticalAngle = 50f;

		protected LedgeHangingState state;

		protected bool forceExit;

		protected bool forceAutoClimbUp;

		private HitInfo leftHitInfo;

		private HitInfo rightHitInfo;

		private Vector3 initialPosition;

		private bool ledgeJumpFlag;

		protected override void Awake()
		{
			base.Awake();
		}

		protected override void Start()
		{
			base.Start();
			if (base.CharacterActor.Animator == null)
			{
				Debug.Log("The LadderClimbing state needs the character to have a reference to an Animator component. Destroying this state...");
				Object.Destroy(this);
			}
		}

		public override void CheckExitTransition()
		{
			if (forceExit)
			{
				base.CharacterStateController.EnqueueTransition<NormalMovement>();
			}
		}

		public override bool CheckEnterTransition(CharacterState fromState)
		{
			if (!groundedDetection && base.CharacterActor.IsAscending)
			{
				return false;
			}
			if (!groundedDetection && base.CharacterActor.IsGrounded)
			{
				return false;
			}
			if (!IsValidLedge(base.CharacterActor.Position))
			{
				return false;
			}
			return true;
		}

		public override void EnterBehaviour(float dt, CharacterState fromState)
		{
			forceExit = false;
			initialPosition = base.CharacterActor.Position;
			base.CharacterActor.alwaysNotGrounded = true;
			base.CharacterActor.Velocity = Vector3.zero;
			base.CharacterActor.IsKinematic = true;
			base.CharacterActor.SetSize(base.CharacterActor.DefaultBodySize, CharacterActor.SizeReferenceType.Top);
			base.CharacterActor.SetYaw(Vector3.ProjectOnPlane(-base.CharacterActor.WallContact.normal, base.CharacterActor.Up));
			Vector3 vector = Vector3.Project(0.5f * (leftHitInfo.point + rightHitInfo.point) - base.CharacterActor.Top, base.CharacterActor.Up) + verticalOffset * base.CharacterActor.Up + forwardOffset * base.CharacterActor.Forward;
			base.CharacterActor.Position = base.CharacterActor.Position + vector;
			state = LedgeHangingState.Idle;
			for (int i = 0; i < forceAutoClimbUpStates.Length; i++)
			{
				CharacterState characterState = forceAutoClimbUpStates[i];
				if (fromState == characterState)
				{
					forceAutoClimbUp = true;
					break;
				}
			}
		}

		public override void ExitBehaviour(float dt, CharacterState toState)
		{
			base.CharacterActor.IsKinematic = false;
			base.CharacterActor.alwaysNotGrounded = false;
			forceAutoClimbUp = false;
			if (ledgeJumpFlag)
			{
				ledgeJumpFlag = false;
				base.CharacterActor.Position = initialPosition;
				base.CharacterActor.Velocity = base.CharacterActor.Up * ledgeJumpVelocity;
			}
			else
			{
				base.CharacterActor.Velocity = Vector3.zero;
			}
		}

		private bool CheckValidClimb()
		{
			HitInfoFilter hitInfoFilter = new HitInfoFilter(layerMask, ignoreRigidbodies: false, ignoreTriggers: true);
			return !base.CharacterActor.CharacterCollisions.CheckOverlap((leftHitInfo.point + rightHitInfo.point) / 2f, base.CharacterActor.StepOffset, in hitInfoFilter);
		}

		public override void UpdateBehaviour(float dt)
		{
			switch (state)
			{
			case LedgeHangingState.Idle:
				if (base.CharacterActions.jump.Started)
				{
					forceExit = true;
					ledgeJumpFlag = true;
				}
				else if (base.CharacterActions.movement.Up || autoClimbUp || forceAutoClimbUp)
				{
					if (CheckValidClimb())
					{
						state = LedgeHangingState.TopUp;
						base.CharacterActor.SetUpRootMotion(updateRootPosition: true, PhysicsActor.RootMotionVelocityType.SetVelocity, updateRootRotation: false);
						base.CharacterActor.Animator.SetTrigger(topUpParameter);
					}
				}
				else if (base.CharacterActions.movement.Down)
				{
					forceExit = true;
				}
				break;
			case LedgeHangingState.TopUp:
				if (base.CharacterActor.Animator.GetCurrentAnimatorStateInfo(0).IsName("Exit"))
				{
					forceExit = true;
					base.CharacterActor.ForceGrounded();
				}
				break;
			}
		}

		private bool IsValidLedge(Vector3 characterPosition)
		{
			if (!base.CharacterActor.WallCollision)
			{
				return false;
			}
			DetectLedge(characterPosition, out leftHitInfo, out rightHitInfo);
			if (!leftHitInfo.hit || !rightHitInfo.hit)
			{
				return false;
			}
			if (filterByTag && (!leftHitInfo.transform.CompareTag(tagName) || !rightHitInfo.transform.CompareTag(tagName)))
			{
				return false;
			}
			Vector3 to = Vector3.Normalize(leftHitInfo.normal + rightHitInfo.normal);
			if (Vector3.Angle(base.CharacterActor.Up, to) > 50f)
			{
				return false;
			}
			return true;
		}

		private void DetectLedge(Vector3 position, out HitInfo leftHitInfo, out HitInfo rightHitInfo)
		{
			HitInfoFilter filter = new HitInfoFilter(layerMask, !detectRigidbodies, ignoreTriggers: true);
			leftHitInfo = default(HitInfo);
			rightHitInfo = default(HitInfo);
			Vector3 vector = (base.CharacterActor.WallCollision ? (-base.CharacterActor.WallContact.normal) : base.CharacterActor.Forward);
			Vector3 vector2 = Vector3.Cross(base.CharacterActor.Up, vector);
			Vector3 vector3 = position + base.CharacterActor.Up * upwardsDetectionOffset;
			base.CharacterActor.PhysicsComponent.Raycast(out var hitInfo, base.CharacterActor.Center, vector3 - base.CharacterActor.Center, in filter);
			if (!hitInfo.hit)
			{
				Vector3 vector4 = vector3 + vector * forwardDetectionOffset;
				Vector3 origin = vector4 - vector2 * (separationBetweenHands / 2f);
				Vector3 origin2 = vector4 + vector2 * (separationBetweenHands / 2f);
				base.CharacterActor.PhysicsComponent.Raycast(out leftHitInfo, origin, -base.CharacterActor.Up * ledgeDetectionDistance, in filter);
				base.CharacterActor.PhysicsComponent.Raycast(out rightHitInfo, origin2, -base.CharacterActor.Up * ledgeDetectionDistance, in filter);
			}
		}
	}
}
