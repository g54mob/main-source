using CLanguage.Compiler;
using CLanguage.Types;

namespace CLanguage.Syntax
{
	public class VariableExpression : Expression
	{
		public string VariableName { get; private set; }

		public override bool CanEmitPointer => false;

		public VariableExpression(string val, Location loc, Location endLoc)
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

		public override Value EvalConstant(EmitContext ec)
		{
			return default(Value);
		}
	}
}
