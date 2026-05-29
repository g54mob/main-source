using System.Collections.Generic;
using UnityEngine;

namespace CTS.DevConsole
{
	public class CommandQuit : ConsoleCommand
	{
		public override string Command => "Quit";

		public override bool CanHaveNoArguments { get; } = true;

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; }

		public override string GetCommandDescription()
		{
			return "Quits the game.";
		}

		protected override void RunCommand(List<object> args, string[] rawArgs)
		{
			Application.Quit();
		}
	}
}
