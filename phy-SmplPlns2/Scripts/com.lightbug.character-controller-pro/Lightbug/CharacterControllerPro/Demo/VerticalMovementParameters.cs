using System;
using Lightbug.Utilities;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Demo
{
	[Serializable]
	public class VerticalMovementParameters
	{
		public enum UnstableJumpMode
		{
			Vertical = 0,
			GroundNormal = 1
		}

		[Header("Gravity")]
		[Tooltip("It enables/disables gravity. The gravity value is calculated based on the jump apex height and duration.")]
		public bool useGravity = true;

		[Header("Jump")]
		public bool canJump = true;

		[Space(10f)]
		[Tooltip("The gravity magnitude and the jump speed will be automatically calculated based on the jump apex height and duration. Set this to false if you want to manually set those values.")]
		public bool autoCalculate = true;

		[Condition("autoCalculate", ConditionAttribute.ConditionType.IsTrue, ConditionAttribute.VisibilityType.NotEditable, 0f)]
		[Tooltip("The height reached at the apex of the jump. The maximum height will depend on the \"jumpCancellationMode\".")]
		[Min(0f)]
		public float jumpApexHeight = 2.25f;

		[Condition("autoCalculate", ConditionAttribute.ConditionType.IsTrue, ConditionAttribute.VisibilityType.NotEditable, 0f)]
		[Tooltip("The amount of time to reach the \"base height\" (apex).")]
		[Min(0f)]
		public float jumpApexDuration = 0.5f;

		[Condition("autoCalculate", ConditionAttribute.ConditionType.IsFalse, ConditionAttribute.VisibilityType.NotEditable, 0f)]
		public float jumpSpeed = 10f;

		[Condition("autoCalculate", ConditionAttribute.ConditionType.IsFalse, ConditionAttribute.VisibilityType.NotEditable, 0f)]
		public float gravity = 10f;

		[Space(10f)]
		[Tooltip("Reduces the vertical velocity when the jump action is canceled.")]
		public bool cancelJumpOnRelease = true;

		[Tooltip("How much the vertical velocity is reduced when canceling the jump (0 = no effect , 1 = zero velocity).")]
		[Range(0f, 1f)]
		public float cancelJumpMultiplier = 0.5f;

		[Tooltip("When canceling the jump (releasing the action), if the jump time is less than this value nothing is going to happen. Only when the timer is greater than this \"min time\" the jump will be affected.")]
		public float cancelJumpMinTime = 0.1f;

		[Tooltip("When canceling the jump (releasing the action), if the jump time is less than this value (and greater than the \"min time\") the velocity will be affected.")]
		public float cancelJumpMaxTime = 0.3f;

		[Space(10f)]
		[Tooltip("This will help to perform the jump action after the actual input has been started. This value determines the maximum time between input and ground detection.")]
		[Min(0f)]
		public float preGroundedJumpTime = 0.2f;

		[Tooltip("If the character is not grounded, and the \"not grounded time\" is less or equal than this value, the jump action will be performed as a grounded jump. This is also known as \"coyote time\".")]
		[Min(0f)]
		public float postGroundedJumpTime = 0.1f;

		[Space(10f)]
		[Min(0f)]
		[Tooltip("Number of jumps available for the character in the air.")]
		public int availableNotGroundedJumps = 1;

		[Space(10f)]
		public bool canJumpOnUnstableGround;

		[Header("Jump Down (One Way Platforms)")]
		public bool canJumpDown = true;

		[Space(10f)]
		public bool filterByTag;

		public string jumpDownTag = "JumpDown";

		[Space(10f)]
		[Min(0f)]
		public float jumpDownDistance = 0.05f;

		[Min(0f)]
		public float jumpDownVerticalVelocity = 0.5f;

		public void UpdateParameters()
		{
			if (autoCalculate)
			{
				gravity = 2f * jumpApexHeight / Mathf.Pow(jumpApexDuration, 2f);
				jumpSpeed = gravity * jumpApexDuration;
			}
		}

		public void OnValidate()
		{
			if (autoCalculate)
			{
				gravity = 2f * jumpApexHeight / Mathf.Pow(jumpApexDuration, 2f);
				jumpSpeed = gravity * jumpApexDuration;
			}
			else
			{
				jumpApexDuration = jumpSpeed / gravity;
				jumpApexHeight = gravity * Mathf.Pow(jumpApexDuration, 2f) / 2f;
			}
		}
	}
}
