using System.Collections.Generic;

namespace CTS.DevConsole.Commands
{
	public class CommandPackageUnlock : ConsoleCommand, ISubCommand<CommandPackages>, ISubCommand
	{
		public override string Command => "Unlock";

		public override bool CanHaveNoArguments { get; }

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; } = new object[1] { typeof(EUnlockKey) };

		protected override void RunCommand(List<object> args, string[] rawArgs)
		{
			foreach (object arg in args)
			{
				if (arg is EUnlockKey)
				{
					UnlockingManager.AddUnlockKey((EUnlockKey)arg);
					DeveloperConsole.Log($"Package unlocked: {(EUnlockKey)arg}");
				}
			}
		}

		public override string GetCommandDescription()
		{
			return "Unlocks the specified packages.";
		}
	}
}
