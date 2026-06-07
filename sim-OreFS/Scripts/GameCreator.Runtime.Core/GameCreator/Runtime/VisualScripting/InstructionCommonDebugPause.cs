using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Pause Editor")]
	[Description("Pauses the Editor. This has no effect on standalone applications")]
	[Category("Debug/Pause Editor")]
	[Keywords(new string[] { "Debug", "Break", "Pause", "Stop" })]
	[Image(typeof(IconPause), ColorTheme.Type.TextLight)]
	public class InstructionCommonDebugPause : Instruction
	{
		public override string Title => "Pause Editor";

		protected override Task Run(Args args)
		{
			return Instruction.DefaultResult;
		}
	}
}
