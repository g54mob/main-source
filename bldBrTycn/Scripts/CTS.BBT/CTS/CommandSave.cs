using System;
using System.Collections.Generic;
using CTS.Core;
using CTS.DevConsole;

namespace CTS
{
	public class CommandSave : ConsoleCommand
	{
		public override string Command { get; } = "Save";

		public override bool CanHaveNoArguments { get; } = true;

		public override bool EnableHelpCommand { get; }

		public override object[] ArgumentTypes { get; }

		protected override void RunCommand(List<object> args, string[] rawArgs)
		{
			if (CTSSingleton<ProfileManager>.TryGetInstance(out var outInstance))
			{
				outInstance.Save();
			}
		}

		public override string GetCommandDescription()
		{
			throw new NotImplementedException();
		}
	}
}
