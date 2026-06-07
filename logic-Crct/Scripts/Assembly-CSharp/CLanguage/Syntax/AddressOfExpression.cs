using CLanguage.Compiler;
using CLanguage.Types;

namespace CLanguage.Syntax
{
	public class AddressOfExpression : Expression
	{
		public Expression InnerExpression { get; }

		public AddressOfExpression(Expression innerExpression)
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
