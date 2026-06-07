using System;

namespace ModApi.Craft.Program.Instructions
{
	[Serializable]
	public class LogMessageInstruction : ProgramInstruction
	{
		public override ProgramInstruction Execute(IThreadContext context)
		{
			string textValue = GetExpression(0).Evaluate(context).TextValue;
			context.Log.Log(textValue);
			return base.Execute(context);
		}
	}
}
