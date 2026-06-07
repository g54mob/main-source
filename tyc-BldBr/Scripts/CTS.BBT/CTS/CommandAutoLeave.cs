using System.Collections.Generic;
using CTS.BBT.AI;
using CTS.DevConsole;

namespace CTS
{
	public class CommandAutoLeave : ConsoleCommand
	{
		public override string Command { get; } = "AutoLeave";

		public override bool CanHaveNoArguments { get; } = true;

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; } = new object[1] { EArgType.Bool };

		protected override void RunCommand(List<object> args, string[] rawArgs)
		{
			if (args.Count == 0)
			{
				DeveloperConsole.Log($"Auto-leave: {AutonomousActionLeave.AutoLeaveWhenClosed}");
			}
			else if (args[0] is bool autoLeaveWhenClosed)
			{
				AutonomousActionLeave.AutoLeaveWhenClosed = autoLeaveWhenClosed;
				DeveloperConsole.Log($"Auto-leave: {AutonomousActionLeave.AutoLeaveWhenClosed}");
			}
		}

		public override string GetCommandDescription()
		{
			return "Sets whether or not the customers should leave the bar when closed.";
		}
	}
}
