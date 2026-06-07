using System;

namespace ModApi.Craft.Program.Expressions
{
	[Serializable]
	public class NotExpression : ProgramExpression
	{
		private ExpressionResult _result;

		public ProgramExpression Expression => GetExpression(0);

		public override bool IsBoolean => true;

		public NotExpression()
		{
			_result = new ExpressionResult();
		}

		public override ExpressionResult Evaluate(IThreadContext context)
		{
			_result.BoolValue = !Expression.Evaluate(context).BoolValue;
			return _result;
		}
	}
}
