using CLanguage.Compiler;
using CLanguage.Types;

namespace CLanguage.Syntax
{
	public class SizeOfExpression : Expression
	{
		public Expression Query { get; private set; }

		public SizeOfExpression(Expression query)
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
