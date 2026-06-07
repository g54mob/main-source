using Lightbug.CharacterControllerPro.Implementation;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Demo
{
	public class ZeroGravity : CharacterState
	{
		[Header("Movement")]
		public float baseSpeed = 10f;

		public float acceleration = 20f;

		public float deceleration = 20f;

		[Header("Pitch")]
		public bool invertPitch;

		public float pitchAngularSpeed = 180f;

		[Min(0f)]
		public float pitchLerpAcceleration = 5f;

		[Header("Roll")]
		public bool invertRoll;

		public float rollAngularSpeed = 180f;

		[Min(0f)]
		public float rollLerpAcceleration = 5f;

		private float pitchModifier = 1f;

		private float rollModifier = 1f;

		private Vector3 targetVerticalVelocity;

		private float pitchValue;

		private float rollValue;

		protected override void Awake()
		{
			base.Awake();
			pitchModifier = 0f - (invertPitch ? 1f : (-1f));
			rollModifier = (invertRoll ? 1f : (-1f));
		}

		public override void EnterBehaviour(float dt, CharacterState fromState)
		{
			base.CharacterActor.alwaysNotGrounded = true;
			base.CharacterActor.UseRootMotion = false;
			base.CharacterActor.constraintRotation = false;
			targetVerticalVelocity = base.CharacterActor.VerticalVelocity;
		}

		public override void UpdateBehaviour(float dt)
		{
			ProcessRotation(dt);
			ProcessVelocity(dt);
		}

		private void ProcessRotation(float dt)
		{
			pitchValue = Mathf.Lerp(pitchValue, pitchModifier * base.CharacterActions.pitch.value * pitchAngularSpeed * dt, pitchLerpAcceleration * dt);
			rollValue = Mathf.Lerp(rollValue, rollModifier * base.CharacterActions.roll.value * rollAngularSpeed * dt, rollLerpAcceleration * dt);
			base.CharacterActor.RotatePitch(pitchValue, base.CharacterActor.Center);
			base.CharacterActor.RotateRoll(rollValue, base.CharacterActor.Center);
			Vector3 yaw = Vector3.Lerp(base.CharacterActor.Forward, Vector3.ProjectOnPlane(base.CharacterStateController.ExternalReference.forward, base.CharacterActor.Up), 5f * dt);
			base.CharacterActor.SetYaw(yaw);
		}

		private void ProcessVelocity(float dt)
		{
			Vector3 target = base.CharacterStateController.InputMovementReference * baseSpeed;
			base.CharacterActor.Velocity = Vector3.MoveTowards(base.CharacterActor.Velocity, target, (base.CharacterActions.movement.Detected ? acceleration : deceleration) * dt);
			if (base.CharacterActions.jump.value)
			{
				targetVerticalVelocity = base.CharacterActor.Up * baseSpeed;
				base.CharacterActor.VerticalVelocity = Vector3.MoveTowards(base.CharacterActor.VerticalVelocity, targetVerticalVelocity, acceleration * dt);
			}
			else if (base.CharacterActions.crouch.value)
			{
				targetVerticalVelocity = -base.CharacterActor.Up * baseSpeed;
				base.CharacterActor.VerticalVelocity = Vector3.MoveTowards(base.CharacterActor.VerticalVelocity, targetVerticalVelocity, acceleration * dt);
			}
		}
	}
}
