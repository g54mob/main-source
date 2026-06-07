using System;
using Lightbug.CharacterControllerPro.Core;
using Lightbug.Utilities;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Demo
{
	[Serializable]
	public class CrouchParameters
	{
		public bool enableCrouch = true;

		public bool notGroundedCrouch;

		[Tooltip("This multiplier represents the crouch ratio relative to the default height.")]
		[Condition("enableCrouch", ConditionAttribute.ConditionType.IsTrue, ConditionAttribute.VisibilityType.NotEditable, 0f)]
		[Min(0f)]
		public float heightRatio = 0.75f;

		[Tooltip("How much the crouch action affects the movement speed?.")]
		[Condition("enableCrouch", ConditionAttribute.ConditionType.IsTrue, ConditionAttribute.VisibilityType.NotEditable, 0f)]
		[Min(0f)]
		public float speedMultiplier = 0.3f;

		[Tooltip("\"Toggle\" will activate/deactivate the action when the input is \"pressed\". On the other hand, \"Hold\" will activate the action when the input is pressed, and deactivate it when the input is \"released\".")]
		[Condition("enableCrouch", ConditionAttribute.ConditionType.IsTrue, ConditionAttribute.VisibilityType.NotEditable, 0f)]
		public InputMode inputMode = InputMode.Hold;

		[Tooltip("This field determines an anchor point in space (top, center or bottom) that can be used as a reference during size changes. For instance, by using \"top\" as a reference, the character will shrink/grow my moving only the bottom part of the body.")]
		public CharacterActor.SizeReferenceType notGroundedReference;

		[Min(0f)]
		public float sizeLerpSpeed = 8f;
	}
}
