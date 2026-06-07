using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Reset Game")]
	[Description("Resets the current game to its default values")]
	[Category("Storage/Reset Game")]
	[Keywords(new string[] { "Load", "Save", "Profile", "Slot", "Game", "Session" })]
	[Image(typeof(IconDiskOutline), ColorTheme.Type.TextLight, typeof(OverlayCross))]
	public class InstructionCommonResetGame : Instruction
	{
		public override string Title => "Reset game";

		protected override async Task Run(Args args)
		{
			await Singleton<SaveLoadManager>.Instance.Restart(0);
		}
	}
}
