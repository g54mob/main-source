using System;
using ModApi.Craft.Program.Craft;

namespace ModApi.Craft.Program.Instructions
{
	[Serializable]
	public class ActivateStageInstruction : ProgramInstruction
	{
		public override ProgramInstruction Execute(IThreadContext context)
		{
			if (context.Craft.TimeMode >= TimeModeType.TimeWarp1)
			{
				context.Craft.TimeMode = TimeModeType.Normal;
			}
			context.Craft?.ActivateNextStage();
			context.BreakExecution(BreakExecutionType.Wait);
			return base.Execute(context);
		}
	}
}
