using System.Collections.Generic;
using CTS.Core;

namespace CTS.DevConsole.Commands
{
	public class CommandVigilanceClear : ConsoleCommand, ISubCommand<CommandVigilance>, ISubCommand
	{
		public override string Command { get; } = "Clear";

		public override bool CanHaveNoArguments { get; } = true;

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; }

		public override string GetCommandDescription()
		{
			return "Clear the current vigilance.";
		}

		protected override void RunCommand(List<object> args, string[] rawArgs)
		{
			MonoSingleton<VigilanceHandlers>.Instance.SetVigilanceTo(0);
			DeveloperConsole.Log($"Set Vigilance to {0}");
		}
	}
}
