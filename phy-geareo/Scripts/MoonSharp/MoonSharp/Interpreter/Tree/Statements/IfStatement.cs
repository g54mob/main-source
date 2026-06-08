using System.Collections.Generic;
using MoonSharp.Interpreter.Debugging;
using MoonSharp.Interpreter.Execution;
using MoonSharp.Interpreter.Execution.VM;

namespace MoonSharp.Interpreter.Tree.Statements
{
	internal class IfStatement : Statement
	{
		private class IfBlock
		{
			public Expression Exp;

			public Statement Block;

			public RuntimeScopeBlock StackFrame;

			public SourceRef Source;
		}

		private List<IfBlock> m_Ifs;

		private IfBlock m_Else;

		private SourceRef m_End;

		public IfStatement(ScriptLoadingContext lcontext)
			: base(null)
		{
		}

		private IfBlock CreateIfBlock(ScriptLoadingContext lcontext)
		{
			return null;
		}

		private IfBlock CreateElseBlock(ScriptLoadingContext lcontext)
		{
			return null;
		}

		public override void Compile(ByteCode bc)
		{
		}
	}
}
