using MoonSharp.Interpreter.Debugging;
using MoonSharp.Interpreter.Execution;
using MoonSharp.Interpreter.Execution.VM;

namespace MoonSharp.Interpreter.Tree.Statements
{
	internal class ScopeBlockStatement : Statement
	{
		private Statement m_Block;

		private RuntimeScopeBlock m_StackFrame;

		private SourceRef m_Do;

		private SourceRef m_End;

		public ScopeBlockStatement(ScriptLoadingContext lcontext)
			: base(null)
		{
		}

		public override void Compile(ByteCode bc)
		{
		}
	}
}
