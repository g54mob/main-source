using System.Collections.Generic;
using System.Linq;

public class CannonPermUpgrade : BaseShipUpgrade, IStorageUpgrade
{
	private static List<CommandDefinition> commandList;

	public override ShipUpgradeType UpgradeType
	{
		get
		{
			return ShipUpgradeType.PermCannon;
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
			return "Cannon";
		}
	}

	public override string Description
	{
		get
		{
			return "Heavy-duty cannon to puncture rooms";
		}
	}

	public override string CommandValue
	{
		get
		{
			return "cannon";
		}
	}

	public int Capacity
	{
		get
		{
			return 2;
		}
	}

	public int Quantity { get; private set; }

	public CannonPermUpgrade(int id)
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
			commandList = new List<CommandDefinition>(CommandHelper.GetCommands("PermShipUpgradeCannon"));
		}
		return commandList;
	}

	public override void ExecuteCommand(ExecutedCommand command, bool partOfMultiCommand)
	{
		switch (command.Command.CommandName)
		{
		case "cannon":
			if (!GlobalSettings.MissionStarted)
			{
				SendConsoleResponseMessage("Cannot fire until mission starts", ConsoleMessageType.Warning);
				command.Handled = true;
				return;
			}
			if (Quantity > 0)
			{
				if (command.Arguments.Count == 1)
				{
					string text = command.Arguments.First().ToLower();
					Room room = null;
					bool flag = false;
					int num = DungeonManager.Instance.rooms.Length;
					for (int i = 0; i < num; i++)
					{
						if (DungeonManager.Instance.rooms[i].Label.ToString() == text)
						{
							if (!DungeonManager.Instance.rooms[i].boardingVessel)
							{
								room = DungeonManager.Instance.rooms[i];
							}
							else
							{
								flag = true;
							}
							break;
						}
					}
					if (room == null)
					{
						if (!flag)
						{
							SendConsoleResponseMessage("Specified room not found: " + text, ConsoleMessageType.Error);
						}
						else
						{
							SendConsoleResponseMessage("Can't fire on your own boarding ship.", ConsoleMessageType.Warning);
						}
					}
					else
					{
						room.DestroyByImpact("due to cannon fire", 50, 30, 0);
						GameAudio.Play2DSFX(GameAudio.SoundEnum.ShipCannon);
						Quantity -= 1;
						SchematicViewShipPanel.Instance.SetData();
					}
				}
				else
				{
					SendConsoleResponseMessage("Invalid or missing parameters.  Ex: 'canon r4'", ConsoleMessageType.Error);
				}
			}
			else
			{
				SendConsoleResponseMessage("Cannon is empty.", ConsoleMessageType.Error);
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
