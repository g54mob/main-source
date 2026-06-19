using System.Collections.Generic;

namespace SickDev.CommandSystem
{
	public class CommandsManager
	{
		public delegate void OnExceptionThrown(CommandSystemException exception);

		public delegate void OnMessage(string message);

		public delegate void OnCommandAdded(CommandBase command);

		private List<CommandBase> commands;

		private Config config;

		public event OnCommandAdded onCommandAdded;

		public static event OnExceptionThrown onExceptionThrown;

		public static event OnMessage onMessage;

		public CommandsManager()
		{
			commands = new List<CommandBase>();
			config = new Config();
		}

		public void Load()
		{
			CommandAttributeLoader commandAttributeLoader = new CommandAttributeLoader(config);
			Add(commandAttributeLoader.LoadCommands());
		}

		public void Add(CommandBase[] commands)
		{
			for (int i = 0; i < commands.Length; i++)
			{
				Add(commands[i]);
			}
		}

		public void Add(CommandBase command)
		{
			if (!commands.Contains(command))
			{
				commands.Add(command);
				if (this.onCommandAdded != null)
				{
					this.onCommandAdded(command);
				}
			}
		}

		public CommandBase[] GetCommands()
		{
			return commands.ToArray();
		}

		public CommandExecuter GetCommandExecuter(string text)
		{
			ParsedCommand parsedCommand = new ParsedCommand(text);
			return GetCommandExecuter(parsedCommand);
		}

		public CommandExecuter GetCommandExecuter(ParsedCommand parsedCommand)
		{
			return new CommandExecuter(commands, parsedCommand);
		}

		internal static void SendException(CommandSystemException exception)
		{
			if (CommandsManager.onExceptionThrown != null)
			{
				CommandsManager.onExceptionThrown(exception);
			}
		}

		internal static void SendMessage(string message)
		{
			if (CommandsManager.onMessage != null)
			{
				CommandsManager.onMessage(message);
			}
		}

		public void AddAssemblyWithCommands(string assemblyName)
		{
			config.AddAssemblyWithCommands(assemblyName);
		}
	}
}
