using System;

namespace ModApi.Craft.Program.Instructions
{
	[Serializable]
	public class LoopInstruction : ProgramInstruction
	{
		public override bool StopBreakPropagation => true;

		public override bool SupportsChildren => true;
	}
}
