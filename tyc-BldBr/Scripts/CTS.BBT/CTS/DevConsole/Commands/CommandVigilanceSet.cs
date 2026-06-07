using System.Collections.Generic;
using CTS.Core;

namespace CTS.DevConsole.Commands
{
	public class CommandVigilanceSet : ConsoleCommand, ISubCommand<CommandVigilance>, ISubCommand
	{
		public override string Command { get; } = "Set";

		public override bool CanHaveNoArguments { get; }

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; } = new object[1] { EArgType.Int };

		public override string GetCommandDescription()
		{
			return "Sets the current vigilance.";
		}

		protected override void RunCommand(List<object> args, string[] rawArgs)
		{
			if (!(args[0] is int num))
			{
				throw ConsoleCommand.ErrorBadArgument(rawArgs[0], "[Int]");
			}
			if (num < 0)
			{
				num = 0;
			}
			MonoSingleton<VigilanceHandlers>.Instance.SetVigilanceTo(num);
			DeveloperConsole.Log($"Set Vigilance to {num}");
		}
	}
}
