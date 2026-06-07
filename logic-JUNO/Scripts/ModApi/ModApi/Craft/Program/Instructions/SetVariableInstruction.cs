using System;

namespace ModApi.Craft.Program.Instructions
{
	[Serializable]
	public class SetVariableInstruction : ProgramInstruction
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
			((!flag) ? context.GetOrCreateGlobalVariable(text) : context.GetLocalVariable(text))?.Value.Set(GetExpression(1).Evaluate(context));
			return base.Execute(context);
		}
	}
}
