using System;

namespace ModApi.Craft.Program.Expressions
{
	[Serializable]
	public class ActivationGroupExpression : ProgramExpression
	{
		private ExpressionResult _result;

		public override bool IsBoolean => true;

		public ActivationGroupExpression()
		{
			_result = new ExpressionResult();
		}

		public override ExpressionResult Evaluate(IThreadContext context)
		{
			int activationGroup = (int)GetExpression(0).Evaluate(context).NumberValue;
			_ = GetExpression(0).Evaluate(context).BoolValue;
			_result.BoolValue = context.Craft.GetActivationGroupState(activationGroup);
			return _result;
		}
	}
}
