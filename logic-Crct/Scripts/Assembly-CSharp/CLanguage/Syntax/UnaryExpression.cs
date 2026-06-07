using CLanguage.Compiler;
using CLanguage.Types;

namespace CLanguage.Syntax
{
	public class UnaryExpression : Expression
	{
		public Unop Op { get; private set; }

		public Expression Right { get; private set; }

		public UnaryExpression(Unop op, Expression right)
		{
		}

		public override CType GetEvaluatedCType(EmitContext ec)
		{
			return null;
		}

		protected override void DoEmit(EmitContext ec)
		{
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
