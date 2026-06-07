using CLanguage.Compiler;
using CLanguage.Types;

namespace CLanguage.Syntax
{
	public class ArrayElementExpression : Expression
	{
		public Expression Array { get; private set; }

		public Expression ElementIndex { get; private set; }

		public override bool CanEmitPointer => false;

		public ArrayElementExpression(Expression array, Expression elementIndex)
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

		protected override void DoEmitPointer(EmitContext ec)
		{
		}
	}
}
