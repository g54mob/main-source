using CLanguage.Compiler;
using CLanguage.Types;

namespace CLanguage.Syntax
{
	public class ConditionalExpression : Expression
	{
		public Expression Condition { get; set; }

		public Expression TrueValue { get; set; }

		public Expression FalseValue { get; set; }

		public ConditionalExpression(Expression condition, Expression trueValue, Expression falseValue)
		{
		}

		public override CType GetEvaluatedCType(EmitContext ec)
		{
			return null;
		}

		protected override void DoEmit(EmitContext ec)
		{
		}
	}
}
