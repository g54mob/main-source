using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Stop Following")]
	[Description("Instructs a Character to stop following a game object")]
	[Category("Characters/Navigation/Stop Following")]
	[Keywords(new string[] { "Cancel", "Lead", "Pursue", "Chase" })]
	[Image(typeof(IconCharacterIdle), ColorTheme.Type.Red)]
	public class InstructionCharacterNavigationFollowStop : TInstructionCharacterNavigation
	{
		public override string Title => $"{m_Character} Stop Following";

		protected override Task Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return Instruction.DefaultResult;
			}
			character.Motion.StopFollowingTarget();
			return Instruction.DefaultResult;
		}
	}
}
