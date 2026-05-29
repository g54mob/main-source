using System.Collections.Generic;
using CTS.Core;
using CTS.DevConsole;

namespace CTS
{
	public class CommandBankrupt : ConsoleCommand
	{
		public override string Command { get; } = "Bankrupt";

		public override bool CanHaveNoArguments { get; } = true;

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; }

		protected override void RunCommand(List<object> args, string[] rawArgs)
		{
			if (MonoSingleton<BankruptcyHandlers>.TryGetInstance(out var outInstance))
			{
				outInstance.DeclareBankruptcy();
			}
		}

		public override string GetCommandDescription()
		{
			return "Automatic Game Over.";
		}
	}
}
