using System;

namespace ModApi.Craft.Program.Instructions
{
	[Serializable]
	public class WaitSecondsInstruction : ProgramInstruction
	{
		public ProgramExpression Time => GetExpression(0);

		public override ProgramInstruction Execute(IThreadContext context)
		{
			double instructionState = context.GetInstructionState(this);
			bool flag = instructionState == 0.0;
			instructionState += context.DeltaTime;
			context.SetInstructionState(this, instructionState);
			if (instructionState < Time.Evaluate(context).NumberValue)
			{
				context.BreakExecution(BreakExecutionType.Wait);
				return this;
			}
			if (flag)
			{
				context.BreakExecution(BreakExecutionType.Wait);
			}
			return base.Next;
		}
	}
}
