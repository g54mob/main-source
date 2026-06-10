using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Tools;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;

namespace NSMedieval.DevConsole
{
	public class CommandList : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandList()
		{
			Command = "list";
			Description = "Lists all commands, or search along commands.";
			Help = "Usage: list <searchTerm:string, optional>";
		}

		private static IEnumerable<string> ListAllCommands(string searchTerm = null)
		{
			using PooledList<string> commands = ListPool<string>.GetJanitor();
			foreach (ConsoleCommand value in MonoSingleton<DeveloperConsoleController>.Instance.Commands.Values)
			{
				string text = value.Command + " - " + value.Description;
				if (searchTerm != null)
				{
					if (text.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
					{
						commands.Add(TextFormatting.HighlightOccurrences(text, searchTerm));
					}
				}
				else
				{
					commands.Add(text);
				}
			}
			if (commands.Count == 0)
			{
				yield return "No Commands found with '<color=red>" + searchTerm + "</color>' in their name or description.";
			}
			commands.Sort(string.CompareOrdinal);
			foreach (string item in commands)
			{
				yield return item;
			}
		}

		private void CommandMethod()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult(string.Join("\n", ListAllCommands()));
		}

		private void CommandMethod(string searchTerm)
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult(string.Join("\n", ListAllCommands(searchTerm)));
		}
	}
}
