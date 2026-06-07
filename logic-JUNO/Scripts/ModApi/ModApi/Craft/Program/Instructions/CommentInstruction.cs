using System;

namespace ModApi.Craft.Program.Instructions
{
	[Serializable]
	public class CommentInstruction : ProgramInstruction
	{
		public override ProgramInstruction Execute(IThreadContext context)
		{
			return base.Execute(context);
		}
	}
}
