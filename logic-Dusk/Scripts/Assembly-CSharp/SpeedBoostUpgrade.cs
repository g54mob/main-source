using System.Collections.Generic;

public class SpeedBoostUpgrade : BaseDroneUpgrade
{
	private const string COMMAND_VALUE = "speedboost";

	private static List<CommandDefinition> commandList;

	public override string CommandValue
	{
		get
		{
			return "speedboost";
		}
	}

	public SpeedBoostUpgrade(DroneUpgradeDefinition definition)
		: base(definition)
	{
	}

	public override List<CommandDefinition> QueryAvailableCommands()
	{
		if (commandList == null)
		{
			commandList = new List<CommandDefinition>(CommandHelper.GetCommands("SpeedboostUpgrade"));
		}
		return commandList;
	}
}
