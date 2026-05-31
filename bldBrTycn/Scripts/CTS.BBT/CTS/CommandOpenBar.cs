using System.Collections.Generic;
using CTS.BBT;
using CTS.Core;
using CTS.DevConsole;

namespace CTS
{
	public class CommandOpenBar : ConsoleCommand
	{
		public override string Command { get; } = "OpenBar";

		public override bool CanHaveNoArguments { get; } = true;

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; } = new object[1] { EArgType.Bool };

		protected override void RunCommand(List<object> args, string[] rawArgs)
		{
			if (args.Count <= 0)
			{
				DeveloperConsole.Log($"Bar open: {CTSSingleton<LevelParameters>.Instance.IsOpen}");
			}
			else if (args[0] is bool opened)
			{
				CTSSingleton<LevelParameters>.Instance.SetOpened(opened);
				DeveloperConsole.Log($"Bar open: {CTSSingleton<LevelParameters>.Instance.IsOpen}");
			}
		}

		public override string GetCommandDescription()
		{
			return "Sets whether the bar is open or not";
		}
	}
}
