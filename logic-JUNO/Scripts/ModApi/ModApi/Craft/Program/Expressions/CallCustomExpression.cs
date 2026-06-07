using System;
using UnityEngine;

namespace ModApi.Craft.Program.Expressions
{
	[Serializable]
	public class CallCustomExpression : ProgramExpression
	{
		[ProgramNodeProperty]
		private string _call = string.Empty;

		public string Call
		{
			get
			{
				return _call;
			}
			set
			{
				_call = value;
			}
		}

		public override bool IsBoolean => false;

		public override ExpressionResult Evaluate(IThreadContext context)
		{
			CustomExpression customExpression = context.GetCustomExpression(_call);
			if (customExpression == null)
			{
				throw new ProgramException("Could not find custom expression " + _call);
			}
			ExpressionResult[] array = new ExpressionResult[customExpression.LocalVariables.Count];
			for (int i = 0; i < customExpression.LocalVariables.Count; i++)
			{
				if (i < base.Expressions.Count)
				{
					array[i] = GetExpression(i).Evaluate(context);
				}
				else
				{
					Debug.LogError("Not enough arguments passed to custom expression");
				}
			}
			context.PushStackFrame(null);
			for (int j = 0; j < customExpression.LocalVariables.Count; j++)
			{
				LocalVariableDefinition localVariableDefinition = customExpression.LocalVariables[j];
				if (j < base.Expressions.Count)
				{
					context.CreateLocalVariable(localVariableDefinition.Name).Value.Set(array[j]);
				}
			}
			ExpressionResult result = customExpression.Evaluate(context);
			context.PopStackFrame();
			return result;
		}
	}
}
