using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(1, 0, 0)]
	[Title("Crouch")]
	[Category("Characters/Navigation/Crouch")]
	[Description("Changes the character's crouching state")]
	[Keywords(new string[] { "Toggle", "Stand", "Crouch" })]
	[Image(typeof(IconCharacterCrouch), ColorTheme.Type.Blue)]
	[Example("\r\n    Use this instruction to toggle the character's crouching state using the current locomotion animator blend tree configuration.\r\n    Since it already have all the animations transitions set up, you can just call this instruction and the character will automatically transition between Land and Stand blend trees.\r\n\r\n    It's also possible to combine this instruction with a custom press/release input event to leave crouch when the input is release.\r\n    ")]
	[Parameter("Mode", "The crouching behavior to use. Toggle will toggle between Crouch and Stand. Crouch will force the character to crouch and Stand will force the character to stand")]
	[Parameter("SmoothTime", "The smooth time until the character reaches the target stand level")]
	public class InstructionCharacterNavigationToggleCrouch : TInstructionCharacterNavigation
	{
		private enum CrouchMode
		{
			Toggle = 0,
			Crouch = 1,
			Stand = 2
		}

		private const float CROUCH_LOCOMOTION_THRESHOLD = 0.5f;

		private const float STAND_LOCOMOTION_THRESHOLD = 1f;

		[SerializeField]
		private CrouchMode m_Mode;

		[SerializeField]
		private float m_SmoothTime = 0.1f;

		public override string Title => $"Crouch {m_Character}";

		protected override Task Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return Instruction.DefaultResult;
			}
			float target = character.Motion.StandLevel.Target;
			character.Motion.StandLevel.Smooth = m_SmoothTime;
			switch (m_Mode)
			{
			case CrouchMode.Toggle:
			{
				bool flag = target >= 1f;
				character.Motion.StandLevel.Target = (flag ? 0.5f : 1f);
				break;
			}
			case CrouchMode.Crouch:
				character.Motion.StandLevel.Target = 0.5f;
				break;
			case CrouchMode.Stand:
				character.Motion.StandLevel.Target = 1f;
				break;
			}
			return Instruction.DefaultResult;
		}
	}
}
