using System;

namespace ModApi.Craft.Program.Instructions
{
	[Serializable]
	public class WaitUntilInstruction : ProgramInstruction
	{
		public override ProgramInstruction Execute(IThreadContext context)
		{
			if (!GetExpression(0).Evaluate(context).BoolValue)
			{
				context.BreakExecution(BreakExecutionType.Wait);
				return this;
			}
			return base.Next;
		}
	}
}
