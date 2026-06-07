using CLanguage.Compiler;
using CLanguage.Types;

namespace CLanguage.Syntax
{
	public class LogicExpression : Expression
	{
		public Expression Left { get; private set; }

		public LogicOp Op { get; private set; }

		public Expression Right { get; private set; }

		public LogicExpression(Expression left, LogicOp op, Expression right)
		{
		}

		protected override void DoEmit(EmitContext ec)
		{
		}

		public override CType GetEvaluatedCType(EmitContext ec)
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
