using System.Collections.Generic;
using System.Linq;

namespace SickDev.CommandSystem
{
	public class CommandExecuter
	{
		private readonly List<CommandBase> commands;

		private readonly ParsedCommand parsedCommand;

		private List<CommandBase> overloads = new List<CommandBase>();

		private Dictionary<CommandBase, object[]> matches = new Dictionary<CommandBase, object[]>();

		internal CommandExecuter(List<CommandBase> commands, ParsedCommand parsedCommand)
		{
			this.commands = commands;
			this.parsedCommand = parsedCommand;
			FilterOverloads();
			FilterMatches();
		}

		private void FilterOverloads()
		{
			for (int i = 0; i < commands.Count; i++)
			{
				if (commands[i].IsOverloadOf(parsedCommand))
				{
					overloads.Add(commands[i]);
				}
			}
		}

		private void FilterMatches()
		{
			for (int i = 0; i < overloads.Count; i++)
			{
				try
				{
					if (overloads[i].signature.Matches(parsedCommand.args))
					{
						object[] value = overloads[i].signature.Convert(parsedCommand.args);
						matches.Add(overloads[i], value);
					}
				}
				catch (CommandSystemException exception)
				{
					CommandsManager.SendException(exception);
				}
			}
		}

		public bool IsValidCommand()
		{
			return overloads.Count >= 1;
		}

		public bool HasReturnType()
		{
			return matches.Count > 0 && matches.Keys.ToArray()[0].isFunc;
		}

		public object Execute()
		{
			if (matches.Count > 1)
			{
				throw new AmbiguousCommandCallException(parsedCommand.raw, matches.Keys.ToArray());
			}
			if (matches.Count == 0)
			{
				throw new CommandOverloadNotFoundException(parsedCommand);
			}
			Dictionary<CommandBase, object[]>.Enumerator enumerator = matches.GetEnumerator();
			enumerator.MoveNext();
			return enumerator.Current.Key.Execute(enumerator.Current.Value);
		}

		public CommandBase[] GetOverloads()
		{
			return overloads.ToArray();
		}
	}
}
