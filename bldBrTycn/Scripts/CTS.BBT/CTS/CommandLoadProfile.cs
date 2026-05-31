using System;
using System.Collections.Generic;
using CTS.DevConsole;

namespace CTS
{
	public class CommandLoadProfile : ConsoleCommand, ISubCommand<CommandLoad>, ISubCommand
	{
		public override string Command { get; } = "Profile";

		public override bool CanHaveNoArguments { get; }

		public override bool EnableHelpCommand { get; }

		public override object[] ArgumentTypes { get; } = new object[1] { EArgType.Int };

		protected override void RunCommand(List<object> args, string[] rawArgs)
		{
		}

		public override string GetCommandDescription()
		{
			throw new NotImplementedException();
		}
	}
}
