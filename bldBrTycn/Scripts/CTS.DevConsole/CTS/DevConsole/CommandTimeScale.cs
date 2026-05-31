using System;
using System.Collections.Generic;
using UnityEngine;

namespace CTS.DevConsole
{
	public class CommandTimeScale : ConsoleCommand
	{
		public override string Command => "TimeScale";

		public override object[] ArgumentTypes { get; } = new object[1] { EArgType.Float };

		public override bool CanHaveNoArguments { get; } = true;

		public override bool EnableHelpCommand { get; } = true;

		public override string GetCommandDescription()
		{
			return "Displays or sets the time scale to a specified speed.";
		}

		protected override void RunCommand(List<object> args, string[] rawArgs)
		{
			if (rawArgs.Length == 0)
			{
				DeveloperConsole.Log($"Time scale: {Time.timeScale}");
				return;
			}
			if (!(args[0] is float val))
			{
				throw ConsoleCommand.ErrorNotANumber(rawArgs[0]);
			}
			float timeScale = Math.Max(val, 0f);
			Time.timeScale = timeScale;
		}
	}
}
