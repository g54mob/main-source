using System;
using Lightbug.Utilities;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Demo
{
	[Serializable]
	public class LookingDirectionParameters
	{
		public enum LookingDirectionMode
		{
			Movement = 0,
			Target = 1,
			ExternalReference = 2
		}

		public enum LookingDirectionMovementSource
		{
			Velocity = 0,
			Input = 1
		}

		public bool changeLookingDirection = true;

		[Header("Lerp properties")]
		public float speed = 10f;

		[Header("Target Direction")]
		public LookingDirectionMode lookingDirectionMode;

		[Condition("lookingDirectionMode", ConditionAttribute.ConditionType.IsEqualTo, ConditionAttribute.VisibilityType.Hidden, 1f)]
		[Space(5f)]
		public Transform target;

		[Space(5f)]
		[Condition("lookingDirectionMode", ConditionAttribute.ConditionType.IsEqualTo, ConditionAttribute.VisibilityType.Hidden, 0f)]
		public LookingDirectionMovementSource stableGroundedLookingDirectionMode = LookingDirectionMovementSource.Input;

		[Condition("lookingDirectionMode", ConditionAttribute.ConditionType.IsEqualTo, ConditionAttribute.VisibilityType.Hidden, 0f)]
		public LookingDirectionMovementSource unstableGroundedLookingDirectionMode;

		[Condition("lookingDirectionMode", ConditionAttribute.ConditionType.IsEqualTo, ConditionAttribute.VisibilityType.Hidden, 0f)]
		public LookingDirectionMovementSource notGroundedLookingDirectionMode = LookingDirectionMovementSource.Input;
	}
}
