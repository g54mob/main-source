using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Stop Move")]
	[Description("Attempts to stop the character from moving")]
	[Category("Characters/Navigation/Stop Move")]
	[Parameter("Priority", "Indicates the priority of this command against others")]
	[Keywords(new string[] { "Constant", "Walk", "Run", "To", "Vector" })]
	[Image(typeof(IconCharacterWalk), ColorTheme.Type.Red, typeof(OverlayCross))]
	public class InstructionCharacterNavigationMoveStop : TInstructionCharacterNavigation
	{
		[SerializeField]
		private PropertyGetInteger m_Priority = GetDecimalInteger.Create(1);

		public override string Title => $"Stop {m_Character} movement";

		protected override Task Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return Instruction.DefaultResult;
			}
			int priority = (int)m_Priority.Get(args);
			character.Motion.StopToDirection(priority);
			return Instruction.DefaultResult;
		}
	}
}
