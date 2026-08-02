using MoonSharp.Interpreter.Debugging;
using MoonSharp.Interpreter.Execution;
using MoonSharp.Interpreter.Execution.VM;

namespace MoonSharp.Interpreter.Tree.Statements
{
	internal class BreakStatement : Statement
	{
		private SourceRef m_Ref;

		public BreakStatement(ScriptLoadingContext lcontext)
			: base(null)
		{
		}

		public override void Compile(ByteCode bc)
		{
		}
	}
}
