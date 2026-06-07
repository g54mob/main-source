using System;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Controller
{
	[Serializable]
	public struct JumpBasicProfile
	{
		[Tooltip("Name to identify the Jump Profile")]
		public string name;

		[Tooltip("Last State the animal was before making the Jump")]
		public StateID LastState;

		[Tooltip("Minimal Vertical Speed to Activate this Profile")]
		public float VerticalSpeed;

		[Tooltip("Extra Force to push the animal forward ??")]
		public float ForwardPush;

		[Tooltip("Duration of the Jump logic")]
		public float JumpTime;

		[Tooltip("How High the animal can Jump")]
		public FloatReference Height;

		[Tooltip("Multiplier for the Gravity")]
		public FloatReference GravityPower;

		[Tooltip("The Jump can be interrupted if a ground is found in the middle of the jump. This is the multiplier to cast the Ray using the Animal Height.")]
		public FloatReference JumpInterruptRay;

		[Tooltip("Higher value makes the Jump more Arcady")]
		public int StartGravityTime;

		[Tooltip("Can the Animal be controlled while is on the Air")]
		public BoolReference AirControl;

		[Tooltip("Wait for the Animation to Activate the Jump Logic\n Use [void ActivateJump()] on the Animator with a Messsage Behavior")]
		public bool WaitForAnimation;

		[Tooltip("If the Jump input is pressed, the Animal will keep going Up while the Jump Animation is Playing")]
		public BoolReference JumpPressed;

		[Tooltip("Clamp the Speed Forward when jumping (Jumping Often Causes the character to accelerate)")]
		public float ClampForward;
	}
}
