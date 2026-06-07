using System;

namespace ModApi.Craft.Program.Instructions
{
	[Serializable]
	public class DisplayMessageInstruction : ProgramInstruction
	{
		public override ProgramInstruction Execute(IThreadContext context)
		{
			string textValue = GetExpression(0).Evaluate(context).TextValue;
			double numberValue = GetExpression(1).Evaluate(context).NumberValue;
			context.Craft.DisplayMessage(textValue, (float)numberValue);
			return base.Execute(context);
		}
	}
}
