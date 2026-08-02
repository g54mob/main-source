using System.Collections.Generic;
using MoonSharp.Interpreter.Execution;
using MoonSharp.Interpreter.Execution.VM;

namespace MoonSharp.Interpreter.Tree
{
	internal class Loop : ILoop
	{
		public RuntimeScopeBlock Scope;

		public List<Instruction> BreakJumps;

		public void CompileBreak(ByteCode bc)
		{
		}

		public bool IsBoundary()
		{
			return false;
		}
	}
}
