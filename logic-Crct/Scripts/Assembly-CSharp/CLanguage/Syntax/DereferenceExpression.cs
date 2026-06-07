using CLanguage.Compiler;
using CLanguage.Types;

namespace CLanguage.Syntax
{
	public class DereferenceExpression : Expression
	{
		public Expression InnerExpression { get; }

		public override bool CanEmitPointer => false;

		public DereferenceExpression(Expression innerExpression)
		{
		}

		public override CType GetEvaluatedCType(EmitContext ec)
		{
			return null;
		}

		protected override void DoEmit(EmitContext ec)
		{
		}

		protected override void DoEmitPointer(EmitContext ec)
		{
		}
	}
}
