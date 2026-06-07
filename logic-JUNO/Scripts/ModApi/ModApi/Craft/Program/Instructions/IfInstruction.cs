using System;

namespace ModApi.Craft.Program.Instructions
{
	[Serializable]
	public class IfInstruction : ProgramInstruction
	{
		public ProgramExpression Expression => GetExpression(0);

		public override bool SupportsChildren => true;

		public override ProgramInstruction Execute(IThreadContext context)
		{
			bool boolValue = Expression.Evaluate(context).BoolValue;
			ProgramInstruction nextInstruction = GetNextInstruction(boolValue);
			if (boolValue)
			{
				context.PushStackFrame(nextInstruction);
				return base.FirstChild;
			}
			return nextInstruction;
		}

		private ProgramInstruction GetNextInstruction(bool expressionValue)
		{
			if (expressionValue)
			{
				ProgramInstruction next = base.Next;
				while (next is ElseIfInstruction || next is CommentInstruction)
				{
					next = next.Next;
				}
				return next;
			}
			return base.Next;
		}
	}
}
