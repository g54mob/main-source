using MoonSharp.Interpreter.Debugging;
using MoonSharp.Interpreter.Execution;
using MoonSharp.Interpreter.Execution.VM;

namespace MoonSharp.Interpreter.Tree.Statements
{
	internal class ForLoopStatement : Statement
	{
		private RuntimeScopeBlock m_StackFrame;

		private Statement m_InnerBlock;

		private SymbolRef m_VarName;

		private Expression m_Start;

		private Expression m_End;

		private Expression m_Step;

		private SourceRef m_RefFor;

		private SourceRef m_RefEnd;

		public ForLoopStatement(ScriptLoadingContext lcontext, Token nameToken, Token forToken)
			: base(null)
		{
		}

		public override void Compile(ByteCode bc)
		{
		}
	}
}
