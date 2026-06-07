using System;
using UnityEngine;

namespace ModApi.Craft.Program.Instructions
{
	[Serializable]
	public class CallCustomInstruction : ProgramInstruction
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

		public override ProgramInstruction Execute(IThreadContext context)
		{
			CustomInstruction customInstruction = context.GetCustomInstruction(_call);
			if (customInstruction == null)
			{
				throw new ProgramException("Could not find custom expression " + _call);
			}
			ExpressionResult[] array = new ExpressionResult[customInstruction.LocalVariables.Count];
			for (int i = 0; i < customInstruction.LocalVariables.Count; i++)
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
			context.PushStackFrame(base.Next);
			for (int j = 0; j < customInstruction.LocalVariables.Count; j++)
			{
				LocalVariableDefinition localVariableDefinition = customInstruction.LocalVariables[j];
				if (j < base.Expressions.Count)
				{
					context.CreateLocalVariable(localVariableDefinition.Name).Value.Set(array[j]);
				}
			}
			return customInstruction.Next;
		}
	}
}
