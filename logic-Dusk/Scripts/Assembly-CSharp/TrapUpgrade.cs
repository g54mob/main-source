using System.Collections.Generic;
using UnityEngine;

public class TrapUpgrade : BaseDroneUpgrade, IDropperUpgrade, IStorageUpgrade
{
	private const string COMMAND_VALUE = "trap";

	private static List<CommandDefinition> commandList;

	private int guiCapacity;

	private int guiQuantity;

	private string _guiString = string.Empty;

	public override string CommandValue
	{
		get
		{
			return "trap";
		}
	}

	public DropItemType DropType
	{
		get
		{
			return DropItemType.Trap;
		}
	}

	public int DropCost
	{
		get
		{
			return 100;
		}
	}

	public int Capacity
	{
		get
		{
			return 4;
		}
	}

	public int Quantity { get; private set; }

	public string guiStatus
	{
		get
		{
			if (guiCapacity != Capacity || guiQuantity != Quantity)
			{
				_guiString = " (" + Quantity + "/" + Capacity + ") ";
				guiCapacity = Capacity;
				guiQuantity = Quantity;
			}
			return _guiString;
		}
	}

	public TrapUpgrade(DroneUpgradeDefinition definition)
		: base(definition)
	{
		Quantity = Capacity;
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

	protected override void OnUpdate()
	{
		if (GlobalSettings.IsGamePaused || !base.IsActivated)
		{
			return;
		}
		bool flag = false;
		if (DroneItemDropper.KnownTrapCount > 0)
		{
			try
			{
				List<DropableItem> list = DroneItemDropper.DroppedItemDict[DropItemType.Trap];
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					DropableItem dropableItem = list[i];
					if (!dropableItem.IsInSpace && dropableItem.DroppingUpgrade == this)
					{
						TrapItem trapItem = (TrapItem)dropableItem;
						if (!trapItem.Destroyed)
						{
							flag = true;
							break;
						}
					}
				}
			}
			catch
			{
			}
		}
		if (!flag)
		{
			CancelAbility();
		}
	}

	public override List<CommandDefinition> QueryAvailableCommands()
	{
		if (commandList == null)
		{
			commandList = new List<CommandDefinition>(CommandHelper.GetCommands("TrapUpgrade"));
		}
		return commandList;
	}

	public void Drop()
	{
		if (Quantity > 0)
		{
			if (ActivateAbility())
			{
				drone.Drop(DropType, this);
				SendConsoleResponseMessage("Trap dropped", ConsoleMessageType.Info);
				GameplayManager.Instance.missionProfitLoss -= DropCost;
				Quantity -= 1;
			}
		}
		else if (drone.StorageUpgradeTotalQuantity(base.Definition.Type) <= 0)
		{
			SendConsoleResponseMessage("No traps available", ConsoleMessageType.Warning);
		}
	}

	public int Pickup()
	{
		int num = 0;
		if (drone.AnyPickupableItemsNearby(DropItemType.Trap, this))
		{
			if (Quantity < Capacity)
			{
				List<DropableItem> pickedUpItems;
				num = drone.Pickup(DropType, this, out pickedUpItems);
				if (num > 0)
				{
					SendConsoleResponseMessage("Picked up " + num + " trap(s)", ConsoleMessageType.Benefit);
					Quantity += num;
					GameplayManager.Instance.missionProfitLoss += DropCost * num;
				}
			}
			else
			{
				if (drone.StorageUpgradeTotalQuantity(base.Definition.Type) != drone.StorageUpgradeMaxCapacity(base.Definition.Type))
				{
					return -1;
				}
				SendConsoleResponseMessage("No capacity for more traps", ConsoleMessageType.Warning);
			}
		}
		return num;
	}

	public void Teleport(Room room)
	{
		if (Quantity > 0)
		{
			if (ActivateAbility())
			{
				Vector3 safePos = Vector3.zero;
				Bounds destBounds = new Bounds(Vector3.zero, DroneItemDropper.Instance.trapPrefab.GetComponent<Collider>().bounds.size);
				Waypoint mainRoomWaypoint = NavigationHelper.GetMainRoomWaypoint(room);
				destBounds.center = mainRoomWaypoint.transform.position;
				if (room.PickSafeLocationForBounds(destBounds, out safePos))
				{
					drone.Drop(DropType, this, safePos, room);
					Quantity -= 1;
					SendConsoleResponseMessage("Trap sent", ConsoleMessageType.Info);
				}
				else
				{
					SendConsoleResponseMessage("Could not find space in the destination room for a Trap", ConsoleMessageType.Warning);
				}
			}
		}
		else if (drone.StorageUpgradeTotalQuantity(base.Definition.Type) <= 0)
		{
			SendConsoleResponseMessage("No traps available", ConsoleMessageType.Warning);
		}
	}

	public void ExternalAdd()
	{
		if (Quantity < Capacity)
		{
			Quantity += 1;
		}
	}

	public bool Detonate(bool sendResponseToConsole)
	{
		bool flag = false;
		if (DroneItemDropper.DroppedItemDict.ContainsKey(DropItemType.Trap))
		{
			foreach (DropableItem item in DroneItemDropper.DroppedItemDict[DropItemType.Trap])
			{
				if (item.DroppingUpgrade == this)
				{
					flag = true;
					((TrapItem)item).Detonate();
				}
			}
		}
		CancelAbility();
		if (sendResponseToConsole)
		{
			if (flag)
			{
				SendConsoleResponseMessage("Traps detonated", ConsoleMessageType.Info);
			}
			else
			{
				SendConsoleResponseMessage("No traps detonated", ConsoleMessageType.Info);
			}
		}
		return flag;
	}
}
