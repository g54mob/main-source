using CLanguage.Compiler;
using CLanguage.Types;

namespace CLanguage.Syntax
{
	public class SequenceExpression : Expression
	{
		public Expression First { get; set; }

		public Expression Second { get; set; }

		public SequenceExpression(Expression first, Expression second)
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
	}
}
