using MoonSharp.Interpreter.Execution;
using MoonSharp.Interpreter.Execution.VM;

namespace MoonSharp.Interpreter.Tree.Expressions
{
	internal class DynamicExprExpression : Expression
	{
		private Expression m_Exp;

		public DynamicExprExpression(Expression exp, ScriptLoadingContext lcontext)
			: base(null)
		{
		}

		public override DynValue Eval(ScriptExecutionContext context)
		{
			return null;
		}

		public override void Compile(ByteCode bc)
		{
		}

		public override SymbolRef FindDynamic(ScriptExecutionContext context)
		{
			return null;
		}
	}
}
