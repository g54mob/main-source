using NSEipix.Base;

namespace NSMedieval.DevConsole
{
	public class CommandHelp : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandHelp()
		{
			Command = "help";
			Description = "Shows full description of command";
			Help = "Use this command with some command name as parameter to show its full description \n help *command name* ";
		}

		private void CommandMethod(string commandName)
		{
			ConsoleCommand command = MonoSingleton<DeveloperConsoleController>.Instance.GetCommand(commandName);
			if (command == null)
			{
				MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult($"({commandName}) command not recognized.", ConsoleMessageType.Error);
			}
			else
			{
				MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult(command.Help);
			}
		}
	}
}
