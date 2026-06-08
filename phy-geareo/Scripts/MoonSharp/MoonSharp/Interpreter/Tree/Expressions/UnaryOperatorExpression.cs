using MoonSharp.Interpreter.Execution;
using MoonSharp.Interpreter.Execution.VM;

namespace MoonSharp.Interpreter.Tree.Expressions
{
	internal class UnaryOperatorExpression : Expression
	{
		private Expression m_Exp;

		private string m_OpText;

		public UnaryOperatorExpression(ScriptLoadingContext lcontext, Expression subExpression, Token unaryOpToken)
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
