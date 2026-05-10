using System.Collections.Generic;
using CTS.Core;
using CTS.DevConsole;

namespace CTS
{
	public class CommandForceSelectedQuestSuccess : ConsoleCommand
	{
		public override string Command => "SelectedQuestForceSuccess";

		public override bool CanHaveNoArguments { get; } = true;

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; }

		protected override void RunCommand(List<object> args, string[] rawArgs)
		{
			if ((bool)CTSSingleton<QuestTrackerManager>.Instance.CurrentlySelectedQuest)
			{
				CTSSingleton<QuestTrackerManager>.Instance.CurrentlySelectedQuest.ForceQuestSuccess();
			}
		}

		public override string GetCommandDescription()
		{
			return "Force selected quest success";
		}
	}
}
