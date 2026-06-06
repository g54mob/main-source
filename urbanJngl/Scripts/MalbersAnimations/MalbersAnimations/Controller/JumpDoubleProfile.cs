using System;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Controller
{
	[Serializable]
	public struct JumpDoubleProfile
	{
		[Tooltip("Name to identify the Jump Profile")]
		public string name;

		[Header("Double Jump")]
		[Tooltip("Multiple Jump Number (Is it a Double or a Triple Jump. Default is 2 for Double Jump. This is the Value for the [Enter State Status]")]
		public int JumpNumber;

		[Tooltip("Duration of the Jump logic")]
		public float JumpTime;

		[Tooltip("How High the animal can Jump")]
		public FloatReference Height;

		[Tooltip("Multiplier for the Gravity")]
		public FloatReference GravityPower;

		[Tooltip("Higher value makes the Jump more Arcady")]
		public int StartGravityTime;

		[Tooltip("Can the Animal be controlled while is on the Air")]
		public BoolReference AirControl;

		[Space]
		[Tooltip("Wait for the Animation to Activate the Jump Logic\n Use [void ActivateJump()] on the Animator with a Messsage Behavior")]
		public bool WaitForAnimation;
	}
}
