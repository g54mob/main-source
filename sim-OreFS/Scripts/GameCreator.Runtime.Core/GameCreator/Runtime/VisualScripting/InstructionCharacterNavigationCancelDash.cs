using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Cancel Dash")]
	[Description("Cancels any existing Dash on the chosen Character")]
	[Category("Characters/Navigation/Cancel Dash")]
	[Keywords(new string[] { "Leap", "Blink", "Roll", "Flash" })]
	[Image(typeof(IconCharacterDash), ColorTheme.Type.TextLight, typeof(OverlayCross))]
	public class InstructionCharacterNavigationCancelDash : TInstructionCharacterNavigation
	{
		public override string Title => $"Cancel Dash on {m_Character}";

		protected override Task Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return Instruction.DefaultResult;
			}
			character.Dash.Cancel();
			return Instruction.DefaultResult;
		}
	}
}
