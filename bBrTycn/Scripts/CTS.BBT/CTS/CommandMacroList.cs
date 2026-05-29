using System.Collections.Generic;
using CTS.DevConsole;
using UnityEngine;

namespace CTS
{
	public class CommandMacroList : ConsoleCommand, ISubCommand<CommandMacro>, ISubCommand
	{
		private readonly Dictionary<KeyCode, string> tempDict = new Dictionary<KeyCode, string>();

		public override string Command { get; } = "List";

		public override bool CanHaveNoArguments { get; } = true;

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; }

		protected override void RunCommand(List<object> args, string[] rawArgs)
		{
			CommandMacro.Macros.ToDictionary(tempDict);
			string text = "";
			foreach (KeyValuePair<KeyCode, string> item in tempDict)
			{
				text += $"Key [{item.Key}]: \t'{item.Value}' \n";
			}
			DeveloperConsole.Log("All macros: -->", text);
			DeveloperConsole.OpenLastLog();
		}

		public override string GetCommandDescription()
		{
			return "Lists all assigned macros.";
		}
	}
}
