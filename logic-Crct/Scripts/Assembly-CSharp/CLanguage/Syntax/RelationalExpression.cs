using CLanguage.Compiler;
using CLanguage.Types;

namespace CLanguage.Syntax
{
	public class RelationalExpression : Expression
	{
		public Expression Left { get; private set; }

		public RelationalOp Op { get; private set; }

		public Expression Right { get; private set; }

		public RelationalExpression(Expression left, RelationalOp op, Expression right)
		{
		}

		protected override void DoEmit(EmitContext ec)
		{
		}

		public override Value EvalConstant(EmitContext ec)
		{
			return default(Value);
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
