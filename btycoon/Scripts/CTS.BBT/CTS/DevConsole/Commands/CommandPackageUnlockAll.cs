using System.Collections.Generic;

namespace CTS.DevConsole.Commands
{
	public class CommandPackageUnlockAll : ConsoleCommand, ISubCommand<CommandPackageUnlock>, ISubCommand
	{
		public override string Command => "All";

		public override bool CanHaveNoArguments { get; } = true;

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; }

		protected override void RunCommand(List<object> args, string[] rawArgs)
		{
			UnlockingManager.UnlockAll();
			DeveloperConsole.Log("All Packages unlocked.");
		}

		public override string GetCommandDescription()
		{
			return "Unlocks all the packages.";
		}
	}
}
