using System;

namespace ModApi.Craft.Program.Instructions
{
	[Serializable]
	public class SwitchCraftInstruction : ProgramInstruction
	{
		public override ProgramInstruction Execute(IThreadContext context)
		{
			int num = (int)GetExpression(0).Evaluate(context).NumberValue;
			ICraftNode craftNode = context.Craft.GetCraftNode(num);
			if (craftNode != null)
			{
				context.Craft.SwitchToCraftNode(craftNode);
			}
			else
			{
				context.Log.LogError($"Could not find Craft Node with ID {num}");
			}
			return base.Execute(context);
		}
	}
}
