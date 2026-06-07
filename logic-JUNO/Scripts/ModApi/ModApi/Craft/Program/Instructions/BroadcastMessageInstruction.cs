using System;
using ModApi.Craft.Program.Craft;

namespace ModApi.Craft.Program.Instructions
{
	[Serializable]
	public class BroadcastMessageInstruction : ProgramInstruction
	{
		[ProgramNodeProperty]
		private bool _global;

		[ProgramNodeProperty]
		private bool _local = true;

		public override ProgramInstruction Execute(IThreadContext context)
		{
			string textValue = GetExpression(0).Evaluate(context).TextValue;
			ExpressionResult expressionResult = new ExpressionResult();
			expressionResult.Set(GetExpression(1).Evaluate(context));
			BroadcastScope scope = (_global ? BroadcastScope.AllCrafts : ((!_local) ? BroadcastScope.Craft : BroadcastScope.Program));
			context.Craft.BroadcastMessage(scope, textValue, expressionResult);
			return base.Execute(context);
		}
	}
}
