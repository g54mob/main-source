using System.Collections.Generic;
using CTS.Core;

namespace CTS.DevConsole.Commands
{
	public class CommandVigilanceAdd : ConsoleCommand, ISubCommand<CommandVigilance>, ISubCommand
	{
		public override string Command { get; } = "Add";

		public override bool CanHaveNoArguments { get; }

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; } = new object[1] { EArgType.Int };

		public override string GetCommandDescription()
		{
			return "Add value to current vigilance.";
		}

		protected override void RunCommand(List<object> args, string[] rawArgs)
		{
			if (!(args[0] is int num))
			{
				throw ConsoleCommand.ErrorBadArgument(rawArgs[0], "[Int]");
			}
			int num2 = num + MonoSingleton<VigilanceHandlers>.Instance.CurrentVigilance;
			if (num2 < 0)
			{
				num2 = 0;
			}
			if (num2 > 100)
			{
				num2 = 100;
			}
			MonoSingleton<VigilanceHandlers>.Instance.SetVigilanceTo(num2);
			DeveloperConsole.Log($"Set Vigilance to {num2}");
		}
	}
}
