using System;
using System.Collections.Generic;
using System.Linq;

public abstract class CommandManagerModel<T> : BaseModel where T : struct, IComparable, IFormattable, IConvertible
{
	public const string CommandRevertedEvent = "CommandManagerModel.CommandRevertedEvent";

	public const string LastRevertedCommandExecutedEvent = "CommandManagerModel.LastRevertedCommandExecutedEvent";

	public const string ClearedAllCommandsEvent = "CommandManagerModel.ClearedAllCommandsEvent";

	protected List<Command<T>> allExecutedCommands;

	protected List<Command<T>> allRevertedCommands;

	public CommandManagerModel()
	{
		allExecutedCommands = new List<Command<T>>();
		allRevertedCommands = new List<Command<T>>();
	}

	public abstract T ExecuteNewCommand(Command<T> command);

	public void RevertLastCommand()
	{
		if (allExecutedCommands.Count > 0)
		{
			Command<T> command = allExecutedCommands.Last();
			command.Revert();
			allExecutedCommands.Remove(command);
			allRevertedCommands.Add(command);
			NotifyChange("CommandManagerModel.CommandRevertedEvent", allExecutedCommands.Count, allRevertedCommands.Count);
		}
	}

	public void ExecuteLastRevertedCommand()
	{
		if (allRevertedCommands.Count > 0)
		{
			Command<T> command = allRevertedCommands.Last();
			command.Execute();
			allExecutedCommands.Add(command);
			allRevertedCommands.Remove(command);
			NotifyChange("CommandManagerModel.LastRevertedCommandExecutedEvent", allExecutedCommands.Count, allRevertedCommands.Count);
		}
	}

	public void ClearAllCommands()
	{
		allExecutedCommands.Clear();
		allRevertedCommands.Clear();
		NotifyChange("CommandManagerModel.ClearedAllCommandsEvent", allExecutedCommands.Count, allRevertedCommands.Count);
	}
}
