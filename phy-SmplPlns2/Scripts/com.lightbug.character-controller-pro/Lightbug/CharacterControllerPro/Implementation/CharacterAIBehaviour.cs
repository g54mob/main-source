using Lightbug.CharacterControllerPro.Core;
using Lightbug.Utilities;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Implementation
{
	public abstract class CharacterAIBehaviour : MonoBehaviour
	{
		public CharacterActions characterActions;

		public CharacterActor CharacterActor { get; private set; }

		public virtual void EnterBehaviour(float dt)
		{
		}

		public abstract void UpdateBehaviour(float dt);

		public virtual void ExitBehaviour(float dt)
		{
		}

		protected virtual void Awake()
		{
			CharacterActor = this.GetComponentInBranch<CharacterActor>();
		}

		protected void SetMovementAction(Vector3 direction)
		{
			Vector3 vector = Vector3.ProjectOnPlane(direction, CharacterActor.Up);
			vector.Normalize();
			vector.y = vector.z;
			vector.z = 0f;
			characterActions.movement.value = vector;
		}
	}
}
