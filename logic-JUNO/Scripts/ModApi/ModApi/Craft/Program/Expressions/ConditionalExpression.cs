using System;

namespace ModApi.Craft.Program.Expressions
{
	[Serializable]
	public class ConditionalExpression : ProgramExpression
	{
		private ExpressionResult _result;

		public override bool IsBoolean => false;

		public ConditionalExpression()
		{
			_result = new ExpressionResult();
		}

		public override ExpressionResult Evaluate(IThreadContext context)
		{
			int index = (GetExpression(0).Evaluate(context).BoolValue ? 1 : 2);
			_result.Set(GetExpression(index).Evaluate(context));
			return _result;
		}
	}
}
