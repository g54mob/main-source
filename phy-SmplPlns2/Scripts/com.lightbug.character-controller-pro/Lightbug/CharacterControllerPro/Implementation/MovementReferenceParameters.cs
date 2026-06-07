using System;
using Lightbug.CharacterControllerPro.Core;
using Lightbug.Utilities;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Implementation
{
	[Serializable]
	public class MovementReferenceParameters
	{
		public enum MovementReferenceMode
		{
			World = 0,
			External = 1,
			Character = 2
		}

		[Tooltip("Select what type of movement reference the player should be using. Should the character use its own transform, the world coordinates, or an external transform?")]
		public MovementReferenceMode movementReferenceMode;

		[Tooltip("The Transform component used by the \"External\" movement reference.")]
		public Transform externalReference;

		private CharacterActor characterActor;

		private Vector3 characterInitialForward;

		private Vector3 characterInitialRight;

		public Vector3 InputMovementReference { get; private set; }

		public Vector3 MovementReferenceForward { get; private set; }

		public Vector3 MovementReferenceRight { get; private set; }

		public void Initialize(CharacterActor characterActor)
		{
			if (characterActor == null)
			{
				Debug.Log("CharacterActor component is null!");
				return;
			}
			this.characterActor = characterActor;
			characterInitialForward = this.characterActor.Forward;
			characterInitialRight = this.characterActor.Right;
		}

		public void UpdateData(Vector2 movementInput)
		{
			UpdateMovementReferenceData();
			if (characterActor.Is2D)
			{
				InputMovementReference = CustomUtilities.Multiply(MovementReferenceRight, movementInput.x);
				return;
			}
			Vector3 vector = CustomUtilities.Multiply(MovementReferenceRight, movementInput.x) + CustomUtilities.Multiply(MovementReferenceForward, movementInput.y);
			InputMovementReference = Vector3.ClampMagnitude(vector, 1f);
		}

		private void UpdateMovementReferenceData()
		{
			switch (movementReferenceMode)
			{
			case MovementReferenceMode.World:
				MovementReferenceForward = Vector3.forward;
				MovementReferenceRight = Vector3.right;
				break;
			case MovementReferenceMode.Character:
				MovementReferenceForward = characterInitialForward;
				MovementReferenceRight = characterInitialRight;
				break;
			case MovementReferenceMode.External:
				if (externalReference != null)
				{
					MovementReferenceForward = Vector3.Normalize(Vector3.ProjectOnPlane(externalReference.forward, characterActor.Up));
					MovementReferenceRight = Vector3.Normalize(Vector3.ProjectOnPlane(externalReference.right, characterActor.Up));
				}
				else
				{
					Debug.Log("CharacterStateController: the external reference is null! assign a Transform.");
				}
				break;
			}
		}
	}
}
