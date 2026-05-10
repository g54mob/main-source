using System.Collections.Generic;
using CTS.DevConsole;
using Newtonsoft.Json;
using UnityEngine;

namespace CTS
{
	public class CommandMacroDelete : ConsoleCommand, ISubCommand<CommandMacro>, ISubCommand
	{
		public override string Command { get; } = "Delete";

		public override bool CanHaveNoArguments { get; }

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; } = new object[1] { typeof(KeyCode) };

		protected override void RunCommand(List<object> args, string[] rawArgs)
		{
			if (args.Count == 1 && args[0] is KeyCode keyCode)
			{
				if (CommandMacro.Macros.ContainsKey(keyCode))
				{
					DeveloperConsole.Log("Deleted " + CommandMacro.Macros[keyCode]);
					CommandMacro.Macros.Remove(keyCode);
					string value = JsonConvert.SerializeObject(CommandMacro.Macros.ToDictionary(), Formatting.None);
					PlayerPrefs.SetString("ConsoleMacros", value);
				}
				else
				{
					DeveloperConsole.LogWarning($"No macro is assigned to {keyCode}");
				}
			}
		}

		public override string GetCommandDescription()
		{
			return "Removes a macro";
		}
	}
}
