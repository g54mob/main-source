using MoonSharp.Interpreter.Debugging;
using MoonSharp.Interpreter.Execution;
using MoonSharp.Interpreter.Execution.VM;

namespace MoonSharp.Interpreter.Tree.Statements
{
	internal class ReturnStatement : Statement
	{
		private Expression m_Expression;

		private SourceRef m_Ref;

		public ReturnStatement(ScriptLoadingContext lcontext, Expression e, SourceRef sref)
			: base(null)
		{
		}

		public ReturnStatement(ScriptLoadingContext lcontext)
			: base(null)
		{
		}

		public override void Compile(ByteCode bc)
		{
		}
	}
}
