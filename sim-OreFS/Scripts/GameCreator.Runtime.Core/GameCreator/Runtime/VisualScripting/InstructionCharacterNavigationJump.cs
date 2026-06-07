using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Jump")]
	[Description("Instructs the Character to jump")]
	[Category("Characters/Navigation/Jump")]
	[Keywords(new string[] { "Hop", "Leap", "Reach" })]
	[Image(typeof(IconCharacterJump), ColorTheme.Type.Blue)]
	public class InstructionCharacterNavigationJump : TInstructionCharacterNavigation
	{
		public override string Title => $"Jump {m_Character}";

		protected override Task Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return Instruction.DefaultResult;
			}
			character.Jump.Do();
			return Instruction.DefaultResult;
		}
	}
}
