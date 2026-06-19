using System.Text;

namespace UnityConsole.Commands
{
	public static class HelpCommand
	{
		public static readonly string Name = "HELP";

		public static readonly string Description = "Display the list of available commands or details about a specific command.";

		public static readonly string Usage = "HELP [command]";

		private static readonly StringBuilder CommandList = new StringBuilder();

		public static ConsoleCommandResult Execute(params string[] args)
		{
			if (args.Length == 0)
			{
				return DisplayAvailableCommands();
			}
			return DisplayCommandDetails(args[0]);
		}

		private static ConsoleCommandResult DisplayAvailableCommands()
		{
			CommandList.Length = 0;
			CommandList.Append("<b>Available Commands</b>\n");
			foreach (ConsoleCommand command in ConsoleCommandsDatabase.Commands)
			{
				CommandList.Append($"    <b>{command.Name}</b> - {command.Description} - {command.Usage}\n");
			}
			CommandList.Append("To display details about a specific command, type 'HELP' followed by the command name.");
			return ConsoleCommandResult.Succeeded(CommandList.ToString());
		}

		private static ConsoleCommandResult DisplayCommandDetails(string commandName)
		{
			string format = "<b>{0} Command</b>\r\n    <b>Description:</b> {1}\r\n    <b>Usage:</b> {2}";
			try
			{
				ConsoleCommand command = ConsoleCommandsDatabase.GetCommand(commandName);
				return ConsoleCommandResult.Succeeded(string.Format(format, command.Name, command.Description, command.Usage));
			}
			catch (NoSuchCommandException ex)
			{
				return ConsoleCommandResult.Failed($"Cannot find help information about {ex.Command}. Are you sure it is a valid command?");
			}
		}
	}
}
