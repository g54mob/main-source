using System;
using System.Collections.Generic;
using CTS.DevConsole;

namespace CTS
{
	public class CommandLoad : ConsoleCommand
	{
		public override string Command { get; } = "Load";

		public override bool CanHaveNoArguments { get; }

		public override bool EnableHelpCommand { get; }

		public override object[] ArgumentTypes { get; }

		protected override void RunCommand(List<object> args, string[] rawArgs)
		{
		}

		public override string GetCommandDescription()
		{
			throw new NotImplementedException();
		}
	}
}
