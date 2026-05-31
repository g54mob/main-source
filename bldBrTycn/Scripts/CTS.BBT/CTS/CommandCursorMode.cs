using System.Collections.Generic;
using CTS.Core;
using CTS.DevConsole;
using CTS.UI;
using UnityEngine;

namespace CTS
{
	public class CommandCursorMode : ConsoleCommand, ISubCommand<CommandCursor>, ISubCommand
	{
		public override string Command { get; } = "Mode";

		public override bool CanHaveNoArguments { get; } = true;

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; } = new object[1] { typeof(CursorMode) };

		protected override void RunCommand(List<object> args, string[] rawArgs)
		{
			if (args.Count != 1)
			{
				DeveloperConsole.Log("Current cursor mode: " + ((MonoSingleton<CursorManager>.Instance.CursorMode == CursorMode.Auto) ? "Auto" : "Software"));
			}
			if (args[0] is CursorMode cursorMode)
			{
				MonoSingleton<CursorManager>.Instance.SetCursorMode(cursorMode);
			}
		}

		public override string GetCommandDescription()
		{
			return "Changes the cursor mode between Auto and Forced Software";
		}
	}
}
