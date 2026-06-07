using System;

namespace ModApi.Craft.Program.Instructions
{
	[Serializable]
	public class BreakInstruction : ProgramInstruction
	{
		public override ProgramInstruction Execute(IThreadContext context)
		{
			StackFrame stackFrame = context.PopStackFrame();
			while (context.CallStackSize > 0 && (stackFrame?.ReturnInstruction == null || !stackFrame.ReturnInstruction.StopBreakPropagation))
			{
				stackFrame = context.PopStackFrame();
			}
			return stackFrame?.ReturnInstruction?.Next;
		}
	}
}
