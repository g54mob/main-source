using CLanguage.Compiler;
using CLanguage.Types;

namespace CLanguage.Syntax
{
	public class BinaryExpression : Expression
	{
		public Expression Left { get; private set; }

		public Binop Op { get; private set; }

		public Expression Right { get; private set; }

		public BinaryExpression(Expression left, Binop op, Expression right)
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

		public override Value EvalConstant(EmitContext ec)
		{
			return default(Value);
		}
	}
}
