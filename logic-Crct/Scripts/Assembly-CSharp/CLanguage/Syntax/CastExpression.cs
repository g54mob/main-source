using CLanguage.Compiler;
using CLanguage.Types;

namespace CLanguage.Syntax
{
	public class CastExpression : Expression
	{
		public TypeName TypeName { get; }

		public Expression InnerExpression { get; }

		public CastExpression(TypeName typeName, Expression innerExpression)
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
