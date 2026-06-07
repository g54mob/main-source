using System;

namespace ModApi.Craft.Program.Instructions
{
	[Serializable]
	public class RepeatInstruction : LoopInstruction
	{
		public ProgramExpression Expression => GetExpression(0);

		public override bool SupportsChildren => true;

		public override ProgramInstruction Execute(IThreadContext context)
		{
			double instructionState = context.GetInstructionState(this);
			if ((int)instructionState < (int)Expression.Evaluate(context).NumberValue)
			{
				context.SetInstructionState(this, instructionState += 1.0);
				context.PushStackFrame(this);
				return base.FirstChild;
			}
			return base.Next;
		}
	}
}
