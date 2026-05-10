using System.Collections.Generic;

namespace CTS.DevConsole.Commands
{
	public class CommandMap : ConsoleCommand
	{
		public override string Command => "Map";

		public override bool CanHaveNoArguments => false;

		public override bool EnableHelpCommand => false;

		public override object[] ArgumentTypes => null;

		public override string GetCommandDescription()
		{
			return "";
		}

		protected override void RunCommand(List<object> args, string[] rawArgs)
		{
		}
	}
}
