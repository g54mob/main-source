using System.Collections.Generic;
using Lightbug.CharacterControllerPro.Implementation;
using Lightbug.Utilities;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Demo
{
	public class RopeClimbing : CharacterState
	{
		[Header("Movement")]
		[SerializeField]
		protected float climbSpeed = 3f;

		[SerializeField]
		protected float angularSpeed = 120f;

		[SerializeField]
		protected float jumpVelocity = 10f;

		[SerializeField]
		protected float verticalAcceleration = 10f;

		[SerializeField]
		protected float angularAcceleration = 10f;

		[Header("Offset")]
		[SerializeField]
		protected float forwardOffset = -0.25f;

		[Header("Animation")]
		[SerializeField]
		protected string verticalVelocityParameter = "VerticalVelocity";

		protected Rope currentRope;

		protected Dictionary<Transform, Rope> ropes = new Dictionary<Transform, Rope>();

		protected Vector3 verticalVelocity;

		protected Vector3 angularVelocity;

		private Vector3 ReferencePosition => base.CharacterActor.Top;

		private Vector3 ClosestVectorToRope => Vector3.ProjectOnPlane(currentRope.TopPosition - base.CharacterActor.Position, currentRope.BottomToTop);

		protected override void Awake()
		{
			base.Awake();
			Rope[] array = Object.FindObjectsByType<Rope>(FindObjectsSortMode.None);
			for (int i = 0; i < array.Length; i++)
			{
				ropes.Add(array[i].transform, array[i]);
			}
		}

		public override void CheckExitTransition()
		{
			if (!currentRope.IsInRange(ReferencePosition) || base.CharacterActions.jump.Started)
			{
				base.CharacterStateController.EnqueueTransition<NormalMovement>();
			}
		}

		public override bool CheckEnterTransition(CharacterState fromState)
		{
			for (int i = 0; i < base.CharacterActor.Triggers.Count; i++)
			{
				Trigger trigger = base.CharacterActor.Triggers[i];
				if (!trigger.firstContact)
				{
					continue;
				}
				Rope orRegisterValue = ropes.GetOrRegisterValue(trigger.transform);
				if (orRegisterValue != null)
				{
					if (!orRegisterValue.IsInRange(ReferencePosition))
					{
						return false;
					}
					currentRope = orRegisterValue;
					return true;
				}
			}
			return false;
		}

		public override void EnterBehaviour(float dt, CharacterState fromState)
		{
			base.CharacterActor.IsKinematic = false;
			base.CharacterActor.alwaysNotGrounded = true;
			base.CharacterActor.UseRootMotion = false;
			base.CharacterActor.Velocity = Vector3.zero;
			Vector3 closestVectorToRope = ClosestVectorToRope;
			base.CharacterActor.SetYaw(closestVectorToRope);
			base.CharacterActor.Position = base.CharacterActor.Position + closestVectorToRope + base.CharacterActor.Forward * forwardOffset;
		}

		public override void ExitBehaviour(float dt, CharacterState toState)
		{
			base.CharacterActor.alwaysNotGrounded = false;
			currentRope = null;
			if (base.CharacterActions.jump.Started)
			{
				if (base.CharacterActions.movement.Detected)
				{
					base.CharacterActor.Velocity = base.CharacterStateController.InputMovementReference * jumpVelocity;
				}
				else
				{
					base.CharacterActor.Velocity = base.CharacterStateController.MovementReferenceForward * jumpVelocity;
				}
				base.CharacterActor.SetYaw(Vector3.Normalize(base.CharacterActor.Velocity));
			}
			else
			{
				base.CharacterActor.Velocity = Vector3.zero;
			}
		}

		public override void UpdateBehaviour(float dt)
		{
			Vector3 position = base.CharacterActor.Position;
			Vector3 target = (CustomUtilities.RotatePointAround(angle: base.CharacterActions.movement.value.x * angularSpeed * dt, point: position, center: position + ClosestVectorToRope, axis: Vector3.Normalize(currentRope.BottomToTop)) - base.CharacterActor.Position) / dt;
			angularVelocity = Vector3.MoveTowards(angularVelocity, target, angularAcceleration * dt);
			Vector3 target2 = base.CharacterActions.movement.value.y * climbSpeed * base.CharacterActor.Up;
			verticalVelocity = Vector3.MoveTowards(verticalVelocity, target2, verticalAcceleration * dt);
			base.CharacterActor.Velocity = verticalVelocity + angularVelocity;
		}

		public override void PostUpdateBehaviour(float dt)
		{
			base.CharacterActor.SetYaw(ClosestVectorToRope);
		}

		public override void PostCharacterSimulation(float dt)
		{
			if (base.CharacterActor.IsAnimatorValid())
			{
				base.CharacterActor.Animator.SetFloat(verticalVelocityParameter, base.CharacterActor.LocalVelocity.y);
			}
		}
	}
}
