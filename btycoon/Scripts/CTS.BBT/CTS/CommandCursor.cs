using System;
using System.Collections.Generic;
using CTS.DevConsole;

namespace CTS
{
	public class CommandCursor : ConsoleCommand
	{
		public override string Command { get; } = "Cursor";

		public override bool CanHaveNoArguments { get; }

		public override bool EnableHelpCommand { get; }

		public override object[] ArgumentTypes { get; }

		protected override void RunCommand(List<object> args, string[] rawArgs)
		{
			throw new NotImplementedException();
		}

		public override string GetCommandDescription()
		{
			throw new NotImplementedException();
		}
	}
}
