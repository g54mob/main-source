using System.Collections.Generic;

public class SoderPermUpgrade : BaseShipUpgrade
{
	private static List<CommandDefinition> commandList;

	public override ShipUpgradeType UpgradeType
	{
		get
		{
			return ShipUpgradeType.PermSolder;
		}
	}

	public override bool IsPermanentUpgrade
	{
		get
		{
			return true;
		}
	}

	public override string Name
	{
		get
		{
			return "Soder";
		}
	}

	public override string Description
	{
		get
		{
			return "Soder or breaks open doors and airlocks";
		}
	}

	public override string CommandValue
	{
		get
		{
			return "soder";
		}
	}

	public SoderPermUpgrade(int id)
		: base(id)
	{
	}

	public override List<CommandDefinition> QueryAvailableCommands()
	{
		if (commandList == null)
		{
			commandList = new List<CommandDefinition>(CommandHelper.GetCommands("PermShipUpgradeSoder"));
		}
		return commandList;
	}

	public override void ExecuteCommand(ExecutedCommand command, bool partOfMultiCommand)
	{
		switch (command.Command.CommandName)
		{
		case "solder":
			if (!GlobalSettings.MissionStarted)
			{
				SendConsoleResponseMessage("Cannot use the Soder upgrade until after mission starts", ConsoleMessageType.Warning);
				command.Handled = true;
				return;
			}
			if (command.Arguments.Count == 1)
			{
				string text = command.Arguments[0];
				Corridor corridor = null;
				int num = DungeonManager.Instance.corridors.Length;
				for (int i = 0; i < num; i++)
				{
					if (DungeonManager.Instance.corridors[i].door.Label.ToString() == text)
					{
						corridor = DungeonManager.Instance.corridors[i];
						break;
					}
				}
				if (corridor == null)
				{
					SendConsoleResponseMessage("Specified door or airlock not found: " + text, ConsoleMessageType.Warning);
				}
				else
				{
					bool flag = true;
					if (corridor.door.state == DoorState.Open)
					{
						flag = corridor.door.close(true);
					}
					if (flag)
					{
						corridor.door.WeldClosed();
					}
					else
					{
						SendConsoleResponseMessage("Unable to close door to solder it: " + text, ConsoleMessageType.Error);
					}
				}
			}
			else
			{
				SendConsoleResponseMessage("Invalid or missing parameters.  Ex: 'solder r4'", ConsoleMessageType.Error);
			}
			command.Handled = true;
			break;
		}
		base.ExecuteCommand(command, partOfMultiCommand);
	}
}
