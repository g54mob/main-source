using System;
using Lightbug.CharacterControllerPro.Core;
using Lightbug.CharacterControllerPro.Implementation;
using Lightbug.Utilities;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Demo
{
	[AddComponentMenu("Character Controller Pro/Demo/Character/States/Dash")]
	public class Dash : CharacterState
	{
		[Min(0f)]
		[SerializeField]
		protected float initialVelocity = 12f;

		[Min(0f)]
		[SerializeField]
		protected float duration = 0.4f;

		[SerializeField]
		protected AnimationCurve movementCurve = AnimationCurve.Linear(0f, 1f, 1f, 0f);

		[Min(0f)]
		[SerializeField]
		protected int availableNotGroundedDashes = 1;

		[SerializeField]
		protected bool ignoreSpeedMultipliers;

		[SerializeField]
		protected bool forceNotGrounded = true;

		[Tooltip("Should the dash stop when we hit an obstacle (wall collision)?")]
		[SerializeField]
		protected bool cancelOnContact = true;

		protected MaterialController materialController;

		protected int airDashesLeft;

		protected float dashCursor;

		protected Vector3 dashDirection = Vector2.right;

		protected bool isDone = true;

		protected float currentSpeedMultiplier = 1f;

		public event Action<Vector3> OnDashStart;

		public event Action<Vector3> OnDashEnd;

		private void OnEnable()
		{
			base.CharacterActor.OnGroundedStateEnter += OnGroundedStateEnter;
		}

		private void OnDisable()
		{
			base.CharacterActor.OnGroundedStateEnter -= OnGroundedStateEnter;
		}

		public override string GetInfo()
		{
			return "This state is entirely based on particular movement, the \"dash\". This movement is normally a fast impulse along the forward direction. In this case the movement can be defined by using an animation curve (time vs velocity)";
		}

		private void OnGroundedStateEnter(Vector3 localVelocity)
		{
			airDashesLeft = availableNotGroundedDashes;
		}

		private bool EvaluateCancelOnContact()
		{
			return base.CharacterActor.WallContacts.Count != 0;
		}

		protected override void Awake()
		{
			base.Awake();
			materialController = this.GetComponentInBranch<CharacterActor, MaterialController>();
			airDashesLeft = availableNotGroundedDashes;
		}

		public override bool CheckEnterTransition(CharacterState fromState)
		{
			if (!base.CharacterActor.IsGrounded && airDashesLeft <= 0)
			{
				return false;
			}
			return true;
		}

		public override void CheckExitTransition()
		{
			if (isDone)
			{
				if (this.OnDashEnd != null)
				{
					this.OnDashEnd(dashDirection);
				}
				base.CharacterStateController.EnqueueTransition<NormalMovement>();
			}
		}

		public override void EnterBehaviour(float dt, CharacterState fromState)
		{
			if (forceNotGrounded)
			{
				base.CharacterActor.alwaysNotGrounded = true;
			}
			base.CharacterActor.UseRootMotion = false;
			if (base.CharacterActor.IsGrounded)
			{
				if (!ignoreSpeedMultipliers)
				{
					currentSpeedMultiplier = ((materialController != null) ? (materialController.CurrentSurface.speedMultiplier * materialController.CurrentVolume.speedMultiplier) : 1f);
				}
			}
			else
			{
				if (!ignoreSpeedMultipliers)
				{
					currentSpeedMultiplier = ((materialController != null) ? materialController.CurrentVolume.speedMultiplier : 1f);
				}
				airDashesLeft--;
			}
			dashDirection = base.CharacterActor.Forward;
			ResetDash();
			this.OnDashStart?.Invoke(dashDirection);
		}

		public override void ExitBehaviour(float dt, CharacterState toState)
		{
			if (forceNotGrounded)
			{
				base.CharacterActor.alwaysNotGrounded = false;
			}
		}

		public override void UpdateBehaviour(float dt)
		{
			Vector3 velocity = initialVelocity * currentSpeedMultiplier * movementCurve.Evaluate(dashCursor) * dashDirection;
			base.CharacterActor.Velocity = velocity;
			float num = dt / duration;
			dashCursor += num;
			if (dashCursor >= 1f)
			{
				isDone = true;
				dashCursor = 0f;
			}
		}

		public override void PostUpdateBehaviour(float dt)
		{
			if (cancelOnContact)
			{
				isDone |= EvaluateCancelOnContact();
			}
		}

		public virtual void ResetDash()
		{
			base.CharacterActor.Velocity = Vector3.zero;
			isDone = false;
			dashCursor = 0f;
		}
	}
}
