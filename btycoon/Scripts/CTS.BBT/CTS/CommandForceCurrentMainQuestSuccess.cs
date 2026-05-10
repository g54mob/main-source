using System.Collections.Generic;
using CTS.DevConsole;

namespace CTS
{
	public class CommandForceCurrentMainQuestSuccess : ConsoleCommand
	{
		public override string Command => "CurrentMainQuestForceSuccess";

		public override bool CanHaveNoArguments { get; } = true;

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; }

		protected override void RunCommand(List<object> args, string[] rawArgs)
		{
			QuestChain.ForceSuccessCurrentMainQuest();
		}

		public override string GetCommandDescription()
		{
			return "Force current Main quest success";
		}
	}
}
