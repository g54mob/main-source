using CLanguage.Compiler;
using CLanguage.Types;

namespace CLanguage.Syntax
{
	public class MemberFromPointerExpression : Expression
	{
		public Expression Left { get; private set; }

		public string MemberName { get; private set; }

		public override bool CanEmitPointer => false;

		public MemberFromPointerExpression(Expression left, string memberName)
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

		public override string ToString()
		{
			return null;
		}
	}
}
