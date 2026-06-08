using MoonSharp.Interpreter.Execution;
using MoonSharp.Interpreter.Execution.VM;

namespace MoonSharp.Interpreter.Tree.Expressions
{
	internal class LiteralExpression : Expression
	{
		private DynValue m_Value;

		public DynValue Value => null;

		public LiteralExpression(ScriptLoadingContext lcontext, DynValue value)
			: base(null)
		{
		}

		public LiteralExpression(ScriptLoadingContext lcontext, Token t)
			: base(null)
		{
		}

		public override void Compile(ByteCode bc)
		{
		}

		public override DynValue Eval(ScriptExecutionContext context)
		{
			return null;
		}
	}
}
