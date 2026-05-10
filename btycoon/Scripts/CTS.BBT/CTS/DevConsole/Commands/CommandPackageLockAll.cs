using System.Collections.Generic;

namespace CTS.DevConsole.Commands
{
	public class CommandPackageLockAll : ConsoleCommand, ISubCommand<CommandPackageLock>, ISubCommand
	{
		public override string Command => "All";

		public override bool CanHaveNoArguments { get; } = true;

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; }

		protected override void RunCommand(List<object> args, string[] rawArgs)
		{
			UnlockingManager.ClearAll();
			DeveloperConsole.Log("All Packages locked.");
		}

		public override string GetCommandDescription()
		{
			return "Locks all the packages.";
		}
	}
}
