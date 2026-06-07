using Lightbug.CharacterControllerPro.Implementation;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Demo
{
	[AddComponentMenu("Character Controller Pro/Demo/Character/States/Jet Pack")]
	public class JetPack : CharacterState
	{
		[Header("Planar movement")]
		[SerializeField]
		protected float targetPlanarSpeed = 5f;

		[Header("Planar movement")]
		[SerializeField]
		protected float targetVerticalSpeed = 5f;

		[SerializeField]
		protected float duration = 1f;

		protected Vector3 smoothDampVelocity = Vector3.zero;

		public override string GetInfo()
		{
			return "This state allows the character to imitate a \"JetPack\" type of movement. Basically the character can ascend towards the up direction, but also move in the local XZ plane.";
		}

		public override void EnterBehaviour(float dt, CharacterState fromState)
		{
			base.CharacterActor.alwaysNotGrounded = true;
			base.CharacterActor.UseRootMotion = false;
			smoothDampVelocity = base.CharacterActor.VerticalVelocity;
		}

		public override void ExitBehaviour(float dt, CharacterState toState)
		{
			base.CharacterActor.alwaysNotGrounded = false;
		}

		public override void UpdateBehaviour(float dt)
		{
			base.CharacterActor.VerticalVelocity = Vector3.SmoothDamp(base.CharacterActor.VerticalVelocity, targetVerticalSpeed * base.CharacterActor.Up, ref smoothDampVelocity, duration);
			base.CharacterActor.PlanarVelocity = Vector3.Lerp(base.CharacterActor.PlanarVelocity, targetPlanarSpeed * base.CharacterStateController.InputMovementReference, 7f * dt);
			base.CharacterActor.SetYaw(base.CharacterActor.PlanarVelocity);
		}

		public override void CheckExitTransition()
		{
			if (base.CharacterActor.Triggers.Count != 0)
			{
				if (base.CharacterActions.interact.Started)
				{
					base.CharacterStateController.EnqueueTransition<LadderClimbing>();
				}
			}
			else if (!base.CharacterActions.jetPack.value)
			{
				base.CharacterStateController.EnqueueTransition<NormalMovement>();
			}
		}
	}
}
