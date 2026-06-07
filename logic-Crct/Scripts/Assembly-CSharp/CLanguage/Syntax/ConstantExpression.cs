using CLanguage.Compiler;
using CLanguage.Types;

namespace CLanguage.Syntax
{
	public class ConstantExpression : Expression
	{
		public static readonly ConstantExpression Zero;

		public static readonly ConstantExpression One;

		public static readonly ConstantExpression NegativeOne;

		public static readonly ConstantExpression True;

		public static readonly ConstantExpression False;

		public object Value { get; private set; }

		public CType ConstantType { get; private set; }

		public ConstantExpression(object val, CType type)
		{
		}

		public ConstantExpression(object val)
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

		public override Value EvalConstant(EmitContext ec)
		{
			return default(Value);
		}
	}
}
