using Lightbug.CharacterControllerPro.Core;
using Lightbug.CharacterControllerPro.Implementation;
using Lightbug.Utilities;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Demo
{
	[AddComponentMenu("Character Controller Pro/Demo/Character/States/Wall Slide")]
	public class WallSlide : CharacterState
	{
		[Header("Filter")]
		[SerializeField]
		protected bool filterByTag = true;

		[Condition("filterByTag", ConditionAttribute.ConditionType.IsTrue, ConditionAttribute.VisibilityType.Hidden, 0f)]
		[SerializeField]
		protected string wallTag = "WallSlide";

		[Header("Slide")]
		[SerializeField]
		protected float slideAcceleration = 10f;

		[Range(0f, 1f)]
		[SerializeField]
		protected float initialIntertia = 0.4f;

		[Header("Grab")]
		public bool enableGrab = true;

		public bool enableClimb = true;

		[Condition("enableClimb", ConditionAttribute.ConditionType.IsTrue, ConditionAttribute.VisibilityType.Hidden, 0f)]
		public float wallClimbHorizontalSpeed = 1f;

		[Condition("enableClimb", ConditionAttribute.ConditionType.IsTrue, ConditionAttribute.VisibilityType.Hidden, 0f)]
		public float wallClimbVerticalSpeed = 3f;

		[Condition("enableClimb", ConditionAttribute.ConditionType.IsTrue, ConditionAttribute.VisibilityType.Hidden, 0f)]
		public float wallClimbAcceleration = 10f;

		[Header("Size")]
		[SerializeField]
		protected bool modifySize = true;

		[Condition("modifySize", ConditionAttribute.ConditionType.IsTrue, ConditionAttribute.VisibilityType.Hidden, 0f)]
		[SerializeField]
		protected float height = 1.5f;

		[Header("Jump")]
		[SerializeField]
		protected float jumpNormalVelocity = 5f;

		[SerializeField]
		protected float jumpVerticalVelocity = 10f;

		[Header("Animation")]
		[SerializeField]
		protected string horizontalVelocityParameter = "HorizontalVelocity";

		[SerializeField]
		protected string verticalVelocityParameter = "VerticalVelocity";

		[SerializeField]
		protected string grabParameter = "Grab";

		[SerializeField]
		protected string movementDetectedParameter = "MovementDetected";

		protected bool wallJump;

		protected Vector2 initialSize = Vector2.zero;

		protected bool IsGrabbing
		{
			get
			{
				if (base.CharacterActions.run.value)
				{
					return enableGrab;
				}
				return false;
			}
		}

		public override void CheckExitTransition()
		{
			if (base.CharacterActions.crouch.value || base.CharacterActor.IsGrounded || !base.CharacterActor.WallCollision || !CheckCenterRay())
			{
				base.CharacterStateController.EnqueueTransition<NormalMovement>();
			}
			else if (base.CharacterActions.jump.Started)
			{
				wallJump = true;
				base.CharacterStateController.EnqueueTransition<NormalMovement>();
			}
			else
			{
				base.CharacterStateController.EnqueueTransition<LedgeHanging>();
			}
		}

		public override bool CheckEnterTransition(CharacterState fromState)
		{
			if (base.CharacterActor.IsAscending)
			{
				return false;
			}
			if (!base.CharacterActor.WallCollision)
			{
				return false;
			}
			if (filterByTag && !base.CharacterActor.WallContact.gameObject.CompareTag(wallTag))
			{
				return false;
			}
			if (!CheckCenterRay())
			{
				return false;
			}
			return true;
		}

		protected virtual bool CheckCenterRay()
		{
			HitInfoFilter filter = new HitInfoFilter(base.CharacterActor.PhysicsComponent.CollisionLayerMask, ignoreRigidbodies: true, ignoreTriggers: true);
			base.CharacterActor.PhysicsComponent.Raycast(out var hitInfo, base.CharacterActor.Center, -base.CharacterActor.WallContact.normal * 1.2f * base.CharacterActor.BodySize.x, in filter);
			if (hitInfo.hit)
			{
				return hitInfo.transform.gameObject == base.CharacterActor.WallContact.gameObject;
			}
			return false;
		}

		public override void EnterBehaviour(float dt, CharacterState fromState)
		{
			base.CharacterActor.UseRootMotion = false;
			base.CharacterActor.Velocity *= initialIntertia;
			base.CharacterActor.SetYaw(-base.CharacterActor.WallContact.normal);
			if (modifySize)
			{
				initialSize = base.CharacterActor.BodySize;
				base.CharacterActor.SetSize(new Vector2(initialSize.x, height), CharacterActor.SizeReferenceType.Center);
			}
		}

		public override void ExitBehaviour(float dt, CharacterState toState)
		{
			if (wallJump)
			{
				wallJump = false;
				base.CharacterActor.TurnAround();
				base.CharacterActor.Velocity = jumpVerticalVelocity * base.CharacterActor.Up + jumpNormalVelocity * base.CharacterActor.WallContact.normal;
			}
			if (modifySize)
			{
				CharacterActor.SizeReferenceType sizeReferenceType = (base.CharacterActor.IsGrounded ? CharacterActor.SizeReferenceType.Bottom : CharacterActor.SizeReferenceType.Top);
				base.CharacterActor.SetSize(initialSize, sizeReferenceType);
			}
		}

		public override void UpdateBehaviour(float dt)
		{
			if (IsGrabbing)
			{
				Vector3 vector = Vector3.ProjectOnPlane(base.CharacterStateController.MovementReferenceRight, base.CharacterActor.WallContact.normal);
				vector.Normalize();
				Vector3 up = base.CharacterActor.Up;
				Vector3 target = (enableClimb ? (base.CharacterActions.movement.value.x * vector * wallClimbHorizontalSpeed + base.CharacterActions.movement.value.y * up * wallClimbVerticalSpeed) : Vector3.zero);
				base.CharacterActor.Velocity = Vector3.MoveTowards(base.CharacterActor.Velocity, target, wallClimbAcceleration * dt);
			}
			else
			{
				base.CharacterActor.VerticalVelocity += -base.CharacterActor.Up * slideAcceleration * dt;
			}
		}

		public override void PostUpdateBehaviour(float dt)
		{
			if (base.CharacterActor.IsAnimatorValid())
			{
				base.CharacterActor.Animator.SetFloat(horizontalVelocityParameter, base.CharacterActor.LocalVelocity.x);
				base.CharacterActor.Animator.SetFloat(verticalVelocityParameter, base.CharacterActor.LocalVelocity.y);
				base.CharacterActor.Animator.SetBool(grabParameter, IsGrabbing);
				base.CharacterActor.Animator.SetBool(movementDetectedParameter, base.CharacterActions.movement.Detected);
			}
		}

		public override void UpdateIK(int layerIndex)
		{
			if (base.CharacterActor.IsAnimatorValid())
			{
				if (IsGrabbing && base.CharacterActions.movement.Detected)
				{
					base.CharacterActor.Animator.SetLookAtWeight(Mathf.Clamp01(base.CharacterActor.Velocity.magnitude), 0f, 0.2f);
					base.CharacterActor.Animator.SetLookAtPosition(base.CharacterActor.Position + base.CharacterActor.Velocity);
				}
				else
				{
					base.CharacterActor.Animator.SetLookAtWeight(0f);
				}
			}
		}
	}
}
