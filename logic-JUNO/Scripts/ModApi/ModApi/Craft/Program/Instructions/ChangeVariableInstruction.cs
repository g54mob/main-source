using System;

namespace ModApi.Craft.Program.Instructions
{
	[Serializable]
	public class ChangeVariableInstruction : ProgramInstruction
	{
		public override ProgramInstruction Execute(IThreadContext context)
		{
			string text = null;
			VariableExpression variableExpression = GetExpression(0) as VariableExpression;
			bool flag = false;
			if (variableExpression != null)
			{
				text = variableExpression.VariableName;
				flag = variableExpression.IsLocal;
			}
			else
			{
				text = GetExpression(0).Evaluate(context).TextValue;
			}
			Variable variable = null;
			variable = ((!flag) ? context.GetOrCreateGlobalVariable(text) : context.GetLocalVariable(text));
			if (variable != null)
			{
				if (variable.Value.IsVectorOrVectorAsText)
				{
					variable.Value.VectorValue += GetExpression(1).Evaluate(context).VectorValue;
				}
				else
				{
					variable.Value.NumberValue += GetExpression(1).Evaluate(context).NumberValue;
				}
			}
			return base.Execute(context);
		}
	}
}
