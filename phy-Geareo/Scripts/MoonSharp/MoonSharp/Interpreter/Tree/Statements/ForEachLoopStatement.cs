using MoonSharp.Interpreter.Debugging;
using MoonSharp.Interpreter.Execution;
using MoonSharp.Interpreter.Execution.VM;

namespace MoonSharp.Interpreter.Tree.Statements
{
	internal class ForEachLoopStatement : Statement
	{
		private RuntimeScopeBlock m_StackFrame;

		private SymbolRef[] m_Names;

		private IVariable[] m_NameExps;

		private Expression m_RValues;

		private Statement m_Block;

		private SourceRef m_RefFor;

		private SourceRef m_RefEnd;

		public ForEachLoopStatement(ScriptLoadingContext lcontext, Token firstNameToken, Token forToken)
			: base(null)
		{
		}

		public override void Compile(ByteCode bc)
		{
		}
	}
}
