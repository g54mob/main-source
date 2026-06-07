using System;

namespace ModApi.Craft.Program.Instructions
{
	[Serializable]
	public class SetActivationGroupInstruction : ProgramInstruction
	{
		public override ProgramInstruction Execute(IThreadContext context)
		{
			int activationGroup = (int)GetExpression(0).Evaluate(context).NumberValue;
			bool boolValue = GetExpression(1).Evaluate(context).BoolValue;
			context.Craft.SetActivationGroupState(activationGroup, boolValue);
			return base.Execute(context);
		}
	}
}
