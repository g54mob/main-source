using System.Collections.Generic;
using UnityEngine;

public class ScannerUpgrade : BaseDroneUpgrade
{
	private const string COMMAND_VALUE = "scan";

	private static List<CommandDefinition> commandList;

	public override string CommandValue
	{
		get
		{
			return "scan";
		}
	}

	public ScannerUpgrade(DroneUpgradeDefinition definition)
		: base(definition)
	{
	}

	public override List<CommandDefinition> QueryAvailableCommands()
	{
		if (commandList == null)
		{
			commandList = new List<CommandDefinition>(CommandHelper.GetCommands("ScannerUpgrade"));
		}
		return commandList;
	}

	public override void ExecuteCommand(ExecutedCommand command, bool partOfMultiCommand)
	{
		if (!base.PoweredUp)
		{
			return;
		}
		switch (command.Command.CommandName)
		{
		case "scan":
		{
			command.Handled = true;
			if (!ActivateAbility())
			{
				break;
			}
			Room currentRoom = base.drone.CurrentRoom;
			if (!(currentRoom != null))
			{
				break;
			}
			currentRoom.scan(false);
			SendConsoleResponseMessage("Scan Results: ", ConsoleMessageType.Info);
			DroneManager instance = DroneManager.Instance;
			int count = currentRoom.roomItems.Count;
			bool flag = false;
			int count2 = instance.LootableDronesList.Count;
			for (int i = 0; i < count2; i++)
			{
				if (instance.LootableDronesList[i].CurrentRoom == currentRoom)
				{
					flag = true;
					break;
				}
			}
			List<ShipUpgradeInGameObject> shipUpgrades = DungeonManager.Instance.ShipUpgrades;
			if (count > 0 || flag || shipUpgrades.Count > 0)
			{
				int num = 0;
				foreach (RoomItem roomItem in currentRoom.roomItems)
				{
					if (!(roomItem != null) || roomItem is TransporterReceiver)
					{
						continue;
					}
					if (roomItem.GetType() != typeof(LootItem))
					{
						string empty = string.Empty;
						if (roomItem.IsDead)
						{
							empty = " (Destroyed)";
							SendConsoleResponseMessage(string.Format("   {0}{1}", roomItem.ItemName, empty), ConsoleMessageType.Info);
						}
						else
						{
							SendConsoleResponseMessage("   " + roomItem.ItemName, ConsoleMessageType.Info);
						}
					}
					else
					{
						LootItem lootItem = (LootItem)roomItem;
						if (lootItem.gameObject.activeSelf)
						{
							num++;
						}
					}
				}
				if (num > 0)
				{
					SendConsoleResponseMessage(string.Format("   Scrap ({0})", num), ConsoleMessageType.Info);
				}
				if (flag)
				{
					for (int j = 0; j < count2; j++)
					{
						Drone drone = instance.LootableDronesList[j];
						if (drone.CurrentRoom == currentRoom)
						{
							string arg = string.Empty;
							if (drone.IsDead && !drone.CanBeTowed && !drone.IsBeingTowed)
							{
								arg = " (Destroyed)";
							}
							SendConsoleResponseMessage(string.Format("   Drone {0} - {1}{2}", drone.DroneNumber, drone.DroneName, arg), ConsoleMessageType.Info);
						}
					}
				}
				{
					foreach (ShipUpgradeInGameObject item in shipUpgrades)
					{
						if (currentRoom.GetComponent<Collider>().bounds.Intersects(item.GetComponent<Collider>().bounds) && item.ShipUpgradeStatus == ShipUpgradeInGameObject.ShipUpgradeStatusEnum.Loose)
						{
							string empty2 = string.Empty;
							if (item.ThisUpgrade.BrokenState == BrokenStateEnum.Broken)
							{
								empty2 = " (Destroyed)";
								SendConsoleResponseMessage(string.Format("   Ship Upgrade: {0}{1}", item.ThisUpgrade.Name, empty2), ConsoleMessageType.Info);
							}
							else
							{
								SendConsoleResponseMessage("   " + item.ThisUpgrade.Name, ConsoleMessageType.Info);
							}
						}
					}
					break;
				}
			}
			SendConsoleResponseMessage("   No items of interest", ConsoleMessageType.Info);
			break;
		}
		}
	}
}
