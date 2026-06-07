using Lightbug.CharacterControllerPro.Core;
using Lightbug.Utilities;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Demo
{
	public class PositionAndRotationModifier : CharacterDetector
	{
		public enum CallbackType
		{
			Enter = 0,
			Exit = 1
		}

		public enum RotationMode
		{
			ModifyUp = 0,
			AlignWithObject = 1
		}

		[Header("Callbacks")]
		public CallbackType callbackType;

		[Header("Position")]
		public bool teleport;

		[Condition("teleport", ConditionAttribute.ConditionType.IsTrue, ConditionAttribute.VisibilityType.NotEditable, 0f)]
		public Transform teleportTarget;

		[Header("Rotation")]
		public bool rotate;

		[Condition("rotate", ConditionAttribute.ConditionType.IsTrue, ConditionAttribute.VisibilityType.Hidden, 0f)]
		public RotationMode rotationMode;

		[Condition("rotationMode", ConditionAttribute.ConditionType.IsEqualTo, ConditionAttribute.VisibilityType.Hidden, 0f)]
		[Tooltip("The target Transform.up vector to use.")]
		public Transform referenceTransform;

		[Condition(new string[] { "rotationMode", "rotate" }, new ConditionAttribute.ConditionType[]
		{
			ConditionAttribute.ConditionType.IsEqualTo,
			ConditionAttribute.ConditionType.IsTrue
		}, new float[] { 1f, 0f }, ConditionAttribute.VisibilityType.Hidden)]
		[Tooltip("The target transform to use as the reference.")]
		public Transform verticalAlignmentReference;

		[Condition(new string[] { "rotationMode", "rotate" }, new ConditionAttribute.ConditionType[]
		{
			ConditionAttribute.ConditionType.IsEqualTo,
			ConditionAttribute.ConditionType.IsTrue
		}, new float[] { 1f, 0f }, ConditionAttribute.VisibilityType.Hidden)]
		public VerticalAlignmentSettings.VerticalReferenceMode upDirectionReferenceMode = VerticalAlignmentSettings.VerticalReferenceMode.Away;

		private void Teleport(CharacterActor characterActor)
		{
			if (teleport && !(teleportTarget == null))
			{
				Vector3 position = teleportTarget.position;
				if (characterActor.Is2D)
				{
					position.z = characterActor.transform.position.z;
				}
				characterActor.Teleport(position);
			}
		}

		private void Rotate(CharacterActor characterActor)
		{
			if (!rotate)
			{
				return;
			}
			switch (rotationMode)
			{
			case RotationMode.ModifyUp:
				if (referenceTransform != null)
				{
					characterActor.Up = referenceTransform.up;
				}
				if (characterActor.constraintRotation)
				{
					characterActor.upDirectionReference = null;
					characterActor.constraintUpDirection = characterActor.Up;
				}
				break;
			case RotationMode.AlignWithObject:
				characterActor.constraintRotation = true;
				characterActor.upDirectionReference = verticalAlignmentReference;
				characterActor.upDirectionReferenceMode = upDirectionReferenceMode;
				characterActor.constraintUpDirection = characterActor.Up;
				break;
			}
		}

		protected override void ProcessEnterAction(CharacterActor characterActor)
		{
			if (callbackType == CallbackType.Enter)
			{
				Teleport(characterActor);
				Rotate(characterActor);
			}
		}

		protected override void ProcessExitAction(CharacterActor characterActor)
		{
			if (callbackType == CallbackType.Exit)
			{
				Teleport(characterActor);
				Rotate(characterActor);
			}
		}
	}
}
