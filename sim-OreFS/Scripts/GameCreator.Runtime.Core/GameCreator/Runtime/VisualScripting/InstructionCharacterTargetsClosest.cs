using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Cycle Closest Target")]
	[Description("Cycles to the closest candidate target to the character from the Targets list")]
	[Category("Characters/Combat/Targeting/Cycle Closest Target")]
	[Parameter("Character", "The Character that attempts to change its candidate target")]
	[Keywords(new string[] { "Character", "Combat", "Focus", "Pick", "Candidate", "Targets" })]
	[Image(typeof(IconBullsEye), ColorTheme.Type.Yellow, typeof(OverlayDot))]
	public class InstructionCharacterTargetsClosest : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		public override string Title => $"Cycle Closest Target from {m_Character}";

		protected override Task Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return Instruction.DefaultResult;
			}
			CycleTargets.Closest(character);
			return Instruction.DefaultResult;
		}
	}
}
