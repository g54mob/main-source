using MoonSharp.Interpreter.Execution;
using MoonSharp.Interpreter.Execution.VM;

namespace MoonSharp.Interpreter.Tree.Expressions
{
	internal class AdjustmentExpression : Expression
	{
		private Expression expression;

		public AdjustmentExpression(ScriptLoadingContext lcontext, Expression exp)
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
