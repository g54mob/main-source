using System.Collections.Generic;

namespace CTS.DevConsole.Commands
{
	public class CommandTutorial : ConsoleCommand
	{
		public override string Command { get; } = "Tutorial";

		public override bool CanHaveNoArguments { get; } = true;

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; } = new object[1] { EArgType.Bool };

		protected override void RunCommand(List<object> args, string[] rawArgs)
		{
			if (rawArgs.Length == 0)
			{
				DeveloperConsole.Log($"Tutorial Enabled: {TutorialEnabler.Enabled}");
				return;
			}
			if (!(args[0] is bool enabled))
			{
				throw ConsoleCommand.ErrorBadArgument(rawArgs[0], "[True/False]");
			}
			TutorialEnabler.Enabled = enabled;
			DeveloperConsole.Log($"Tutorial Enabled: {TutorialEnabler.Enabled}");
		}

		public override string GetCommandDescription()
		{
			return "Enables or Disables the tutorial";
		}
	}
}
