using System.Collections.Generic;
using CTS.Core;
using CTS.DevConsole;
using UnityEngine.Scripting;

namespace CTS
{
	[Preserve]
	public class CommandUnlockLevelAll : ConsoleCommand, ISubCommand<CommandUnlockLevel>, ISubCommand
	{
		public override string Command { get; } = "All";

		public override bool CanHaveNoArguments { get; } = true;

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; }

		protected override void RunCommand(List<object> args, string[] rawArgs)
		{
			if (!(CTSSingleton<ProfileManager>.Instance.CurrentProfile is CareerProfile careerProfile))
			{
				DeveloperConsole.LogError("Current profile isn't a career");
			}
			else
			{
				careerProfile.UnlockAll();
			}
		}

		public override string GetCommandDescription()
		{
			return "Unlocks all levels. *USE INSIDE A LEVEL*";
		}
	}
}
