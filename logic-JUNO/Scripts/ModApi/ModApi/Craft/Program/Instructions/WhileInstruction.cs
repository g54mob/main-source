using System;

namespace ModApi.Craft.Program.Instructions
{
	[Serializable]
	public class WhileInstruction : LoopInstruction
	{
		public ProgramExpression Expression => GetExpression(0);

		public override ProgramInstruction Execute(IThreadContext context)
		{
			if (Expression.Evaluate(context).BoolValue)
			{
				context.PushStackFrame(this);
				return base.FirstChild;
			}
			return base.Next;
		}
	}
}
