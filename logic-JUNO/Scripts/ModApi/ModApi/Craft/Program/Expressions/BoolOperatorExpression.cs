using System;

namespace ModApi.Craft.Program.Expressions
{
	[Serializable]
	public class BoolOperatorExpression : ProgramExpression
	{
		[ProgramNodeProperty]
		private string _op = "and";

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

		public BoolOperatorExpression()
		{
			_result = new ExpressionResult();
		}

		public override ExpressionResult Evaluate(IThreadContext context)
		{
			bool boolValue = ExpressionA.Evaluate(context).BoolValue;
			bool boolValue2 = ExpressionB.Evaluate(context).BoolValue;
			bool boolValue3 = false;
			string op = _op;
			if (!(op == "and"))
			{
				if (op == "or")
				{
					boolValue3 = boolValue || boolValue2;
				}
			}
			else
			{
				boolValue3 = boolValue && boolValue2;
			}
			_result.BoolValue = boolValue3;
			return _result;
		}
	}
}
