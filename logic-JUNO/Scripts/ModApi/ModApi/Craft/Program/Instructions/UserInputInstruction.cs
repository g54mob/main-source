using System;
using ModApi.Craft.Program.Craft;

namespace ModApi.Craft.Program.Instructions
{
	[Serializable]
	public class UserInputInstruction : ProgramInstruction
	{
		private UserInputRequest _inputRequest;

		public ProgramExpression Time => GetExpression(0);

		public override ProgramInstruction Execute(IThreadContext context)
		{
			Variable variable = default(Variable);
			if (_inputRequest == null)
			{
				GetVariable();
				_inputRequest = context.Craft.RequestUserInput(GetExpression(1).Evaluate(context).TextValue, variable.Value.TextValue);
			}
			UserInputRequest inputRequest = _inputRequest;
			if (inputRequest != null && inputRequest.IsComplete)
			{
				GetVariable();
				if (variable != null)
				{
					ExpressionResult expressionResult = new ExpressionResult();
					expressionResult.TextValue = _inputRequest.Result;
					variable.Value.Set(expressionResult);
				}
				_inputRequest = null;
				return base.Execute(context);
			}
			context.BreakExecution(BreakExecutionType.Wait);
			return this;
			void GetVariable()
			{
				bool flag = false;
				string name;
				if (GetExpression(0) is VariableExpression variableExpression)
				{
					name = variableExpression.VariableName;
					flag = variableExpression.IsLocal;
				}
				else
				{
					name = GetExpression(0).Evaluate(context).TextValue;
				}
				if (flag)
				{
					variable = context.GetLocalVariable(name);
				}
				else
				{
					variable = context.GetOrCreateGlobalVariable(name);
				}
			}
		}
	}
}
