using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Reset Vertical Velocity")]
	[Description("Changes the Character's vertical velocity to zero")]
	[Category("Characters/Properties/Reset Vertical Velocity")]
	[Keywords(new string[] { "Fall", "Speed" })]
	[Image(typeof(IconFall), ColorTheme.Type.Yellow)]
	public class InstructionCharacterResetVerticalVelocity : TInstructionCharacterProperty
	{
		public override string Title => $"Reset {m_Character} Vertical Velocity";

		protected override Task Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character != null)
			{
				character.Driver.ResetVerticalVelocity();
			}
			return Instruction.DefaultResult;
		}
	}
}
