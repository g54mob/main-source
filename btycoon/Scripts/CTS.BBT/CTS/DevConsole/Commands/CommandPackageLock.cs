using System.Collections.Generic;

namespace CTS.DevConsole.Commands
{
	public class CommandPackageLock : ConsoleCommand, ISubCommand<CommandPackages>, ISubCommand
	{
		public override string Command => "Lock";

		public override bool CanHaveNoArguments { get; }

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; } = new object[1] { typeof(EUnlockKey) };

		protected override void RunCommand(List<object> args, string[] rawArgs)
		{
			foreach (object arg in args)
			{
				if (arg is EUnlockKey)
				{
					UnlockingManager.RemoveUnlockKey((EUnlockKey)arg);
					DeveloperConsole.Log($"Package locked: {(EUnlockKey)arg}");
				}
			}
		}

		public override string GetCommandDescription()
		{
			return "Locks the specified packages.";
		}
	}
}
