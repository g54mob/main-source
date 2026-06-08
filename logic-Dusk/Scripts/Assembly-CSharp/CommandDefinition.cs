using System.Collections.Generic;

public class CommandDefinition
{
	public const ConsoleCommandTarget DEFAULT_TARGET = ConsoleCommandTarget.Undefined;

	public string CommandName { get; set; }

	public string CommandNameLower { get; private set; }

	public string Description { get; set; }

	public string Example { get; set; }

	public ConsoleCommandTarget CommandTarget { get; set; }

	public List<ConsoleMessage> DetailedDescription { get; set; }

	public List<CommandMod> ModList { get; set; }

	public bool DeveloperCommand { get; set; }

	public bool ShortcutCmd { get; set; }

	public bool InternalCmd { get; set; }

	public bool HideFromManual { get; set; }

	public bool HideFromAutoComplete { get; set; }

	public bool IsHelpOnly { get; set; }

	public string Tag { get; set; }

	public bool IsAdvanced { get; set; }

	public CommandDefinition(ExecutedCommand command)
		: this(command.Command.CommandName, command.Command.Description, command.Command.Example, command.Command.CommandTarget)
	{
	}

	public CommandDefinition(string name, string description)
		: this(name, description, string.Empty)
	{
	}

	public CommandDefinition(string name, string description, string example)
		: this(name, description, example, ConsoleCommandTarget.Undefined)
	{
	}

	public CommandDefinition(string name, string description, string example, ConsoleCommandTarget target)
	{
		CommandName = name;
		CommandNameLower = name.ToLower();
		Description = description;
		Example = example;
		CommandTarget = target;
		DetailedDescription = new List<ConsoleMessage>();
	}

	public CommandDefinition(string name, string description, string example, string targetNumberString, string developerCommandString, string internalCmdString, string shortcutString, string tag, string isAdvancedString, string hideFromManualString, string isHelpOnlyString, string hideFromAutoCompleteString)
		: this(name, description, example, ConsoleCommandTarget.Undefined)
	{
		Tag = tag;
		DetailedDescription = new List<ConsoleMessage>();
		CommandTarget = CommonMethods.GetEnumFromString(targetNumberString, ConsoleCommandTarget.Undefined);
		bool result;
		if (bool.TryParse(developerCommandString, out result))
		{
			DeveloperCommand = result;
		}
		bool result2;
		if (bool.TryParse(internalCmdString, out result2))
		{
			InternalCmd = result2;
		}
		bool result3;
		if (bool.TryParse(shortcutString, out result3))
		{
			ShortcutCmd = result3;
		}
		bool result4;
		if (bool.TryParse(isAdvancedString, out result4))
		{
			IsAdvanced = result4;
		}
		bool result5;
		if (bool.TryParse(hideFromManualString, out result5))
		{
			HideFromManual = result5;
		}
		bool result6;
		if (bool.TryParse(hideFromAutoCompleteString, out result6))
		{
			HideFromAutoComplete = result6;
		}
		bool result7;
		if (bool.TryParse(isHelpOnlyString, out result7))
		{
			IsHelpOnly = result7;
		}
	}

	public override string ToString()
	{
		return "command: " + CommandName;
	}
}
