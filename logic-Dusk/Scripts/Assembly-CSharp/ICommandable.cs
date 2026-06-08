using System.Collections.Generic;

public interface ICommandable
{
	string CommandHeader { get; }

	bool IsPrimaryCommandContext { get; set; }

	List<CommandDefinition> QueryAvailableCommands();

	List<CommandDefinition> QueryContextCommands();

	void ExecuteCommand(ExecutedCommand command, bool partOfMultiCommand);

	List<CommandDefinition> QueryDeveloperSpecialCaseCommands();
}
