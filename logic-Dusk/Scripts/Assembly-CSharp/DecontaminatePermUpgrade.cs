using System.Collections.Generic;

public class DecontaminatePermUpgrade : BaseShipUpgrade, IStorageUpgrade
{
	private static List<CommandDefinition> commandList;

	public override ShipUpgradeType UpgradeType
	{
		get
		{
			return ShipUpgradeType.PermDecontaminate;
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
			return "Decontaminate";
		}
	}

	public override string Description
	{
		get
		{
			return "Decontaminate room";
		}
	}

	public override string CommandValue
	{
		get
		{
			return "decontaminate";
		}
	}

	public int Capacity
	{
		get
		{
			return 3;
		}
	}

	public int Quantity { get; private set; }

	public DecontaminatePermUpgrade(int id)
		: base(id)
	{
		int num = UniverseSaveFile.Get(GroupKey, "QTY", -1);
		if (num == -1)
		{
			Quantity = Capacity;
		}
		else
		{
			Quantity = num;
		}
	}

	public override List<CommandDefinition> QueryAvailableCommands()
	{
		if (commandList == null)
		{
			commandList = new List<CommandDefinition>(CommandHelper.GetCommands("PermShipUpgradeDecontainate"));
		}
		return commandList;
	}

	public override void ExecuteCommand(ExecutedCommand command, bool partOfMultiCommand)
	{
		switch (command.Command.CommandName)
		{
		case "decontaminate":
			if (!GlobalSettings.MissionStarted)
			{
				SendConsoleResponseMessage("Cannot decontaminate a room until after mission starts", ConsoleMessageType.Warning);
				command.Handled = true;
				return;
			}
			if (command.Arguments.Count > 0)
			{
				foreach (string argument in command.Arguments)
				{
					if (Quantity > 0)
					{
						Room room = null;
						int num = DungeonManager.Instance.rooms.Length;
						for (int i = 0; i < num; i++)
						{
							if (DungeonManager.Instance.rooms[i].Label.ToString() == argument)
							{
								room = DungeonManager.Instance.rooms[i];
								break;
							}
						}
						if (room == null)
						{
							SendConsoleResponseMessage("Specified room not found: " + argument, ConsoleMessageType.Warning);
						}
						else if (room.IsRadiated || room.IsFillingWithRadiation)
						{
							room.BeginDecontaminate();
							GameAudio.Play2DSFX(GameAudio.SoundEnum.ShipDecontaminate);
							Quantity -= 1;
							SchematicViewShipPanel.Instance.SetData();
						}
						else
						{
							SendConsoleResponseMessage("No radiation detected in room: " + argument, ConsoleMessageType.Warning);
						}
						continue;
					}
					SendConsoleResponseMessage("Decontaminate is empty.", ConsoleMessageType.Error);
					break;
				}
			}
			else
			{
				SendConsoleResponseMessage("Invalid or missing parameters.  Ex: 'decontaminate r4'", ConsoleMessageType.Error);
			}
			command.Handled = true;
			break;
		}
		base.ExecuteCommand(command, partOfMultiCommand);
	}

	public void AddItem(int count)
	{
		Quantity += count;
		if (Quantity > Capacity)
		{
			Quantity = Capacity;
		}
	}

	public void OverrideQuantity(int qty)
	{
		if (qty < Capacity)
		{
			Quantity = qty;
		}
		else
		{
			Quantity = Capacity;
		}
	}
}
