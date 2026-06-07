using System;

namespace ModApi.Craft.Program.Instructions
{
	[Serializable]
	public class ElseIfInstruction : IfInstruction
	{
		public override ProgramInstruction Execute(IThreadContext context)
		{
			return base.Execute(context);
		}
	}
}
