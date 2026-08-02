using MoonSharp.Interpreter.Debugging;
using MoonSharp.Interpreter.Execution;
using MoonSharp.Interpreter.Execution.VM;

namespace MoonSharp.Interpreter.Tree.Statements
{
	internal class RepeatStatement : Statement
	{
		private Expression m_Condition;

		private Statement m_Block;

		private RuntimeScopeBlock m_StackFrame;

		private SourceRef m_Repeat;

		private SourceRef m_Until;

		public RepeatStatement(ScriptLoadingContext lcontext)
			: base(null)
		{
		}

		public override void Compile(ByteCode bc)
		{
		}
	}
}
