using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 0, 1)]
	[Title("Restart Instructions")]
	[Description("Stops executing the current list of Instructions and starts again from the top")]
	[Category("Visual Scripting/Restart Instructions")]
	[Keywords(new string[] { "Reset", "Call", "Again" })]
	[Image(typeof(IconInstructions), ColorTheme.Type.Yellow, typeof(OverlayArrowUp))]
	public class InstructionLogicRestartInstructions : Instruction
	{
		public override string Title => "Restart Instructions";

		protected override Task Run(Args args)
		{
			base.NextInstruction = -base.Parent.RunningIndex;
			return Instruction.DefaultResult;
		}
	}
}
