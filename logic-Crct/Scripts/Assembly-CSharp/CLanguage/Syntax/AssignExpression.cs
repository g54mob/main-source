using CLanguage.Compiler;
using CLanguage.Types;

namespace CLanguage.Syntax
{
	public class AssignExpression : Expression
	{
		public Expression Left { get; private set; }

		public Expression Right { get; private set; }

		public AssignExpression(Expression left, Expression right)
		{
		}

		public override CType GetEvaluatedCType(EmitContext ec)
		{
			return null;
		}

		private void DoEmitStructureAssignment(StructureExpression sexpr, EmitContext ec)
		{
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
