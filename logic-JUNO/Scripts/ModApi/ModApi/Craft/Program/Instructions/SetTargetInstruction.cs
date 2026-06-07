using System;

namespace ModApi.Craft.Program.Instructions
{
	[Serializable]
	public class SetTargetInstruction : ProgramInstruction
	{
		public override ProgramInstruction Execute(IThreadContext context)
		{
			ExpressionResult expressionResult = GetExpression(0).Evaluate(context);
			if (expressionResult.IsVectorOrVectorAsText)
			{
				context.Craft.SetTargetVector(expressionResult.VectorValue);
			}
			else
			{
				context.Craft.SetTargetNode(expressionResult.TextValue);
			}
			return base.Execute(context);
		}
	}
}
