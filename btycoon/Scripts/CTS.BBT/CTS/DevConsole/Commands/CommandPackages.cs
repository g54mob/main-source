using System.Collections.Generic;

namespace CTS.DevConsole.Commands
{
	public class CommandPackages : ConsoleCommand
	{
		public override string Command => "Packages";

		public override bool CanHaveNoArguments { get; } = true;

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; }

		protected override void RunCommand(List<object> args, string[] rawArgs)
		{
			DeveloperConsole.Log($"Packages currently unlocked: {UnlockingManager.UnlockKey}");
		}

		public override string GetCommandDescription()
		{
			return "Displays the packages currently unlocked.";
		}
	}
}
