using System;

namespace ModApi.Craft.Program.Expressions
{
	[Serializable]
	public class ComparisonExpression : ProgramExpression
	{
		[ProgramNodeProperty]
		private string _op = "=";

		private ExpressionResult _result;

		public ProgramExpression ExpressionA => GetExpression(0);

		public ProgramExpression ExpressionB => GetExpression(1);

		public override bool IsBoolean => true;

		public string Operator
		{
			get
			{
				return _op;
			}
			set
			{
				_op = value;
			}
		}

		public ComparisonExpression()
		{
			_result = new ExpressionResult();
		}

		public override ExpressionResult Evaluate(IThreadContext context)
		{
			double numberValue = ExpressionA.Evaluate(context).NumberValue;
			double numberValue2 = ExpressionB.Evaluate(context).NumberValue;
			bool boolValue = false;
			switch (_op)
			{
			case "=":
				boolValue = numberValue == numberValue2;
				break;
			case "l":
				boolValue = numberValue < numberValue2;
				break;
			case "g":
				boolValue = numberValue > numberValue2;
				break;
			case "le":
				boolValue = numberValue <= numberValue2;
				break;
			case "ge":
				boolValue = numberValue >= numberValue2;
				break;
			}
			_result.BoolValue = boolValue;
			return _result;
		}
	}
}
