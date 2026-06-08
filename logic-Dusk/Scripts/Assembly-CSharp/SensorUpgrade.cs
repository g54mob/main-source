using System.Collections.Generic;
using UnityEngine;

public class SensorUpgrade : BaseDroneUpgrade, IDropperUpgrade, IStorageUpgrade
{
	private const string COMMAND_VALUE = "sensor";

	private static List<CommandDefinition> commandList;

	private int guiCapacity;

	private int guiQuantity;

	private string _guiString = string.Empty;

	public override string CommandValue
	{
		get
		{
			return "sensor";
		}
	}

	public DropItemType DropType
	{
		get
		{
			return DropItemType.Sensor;
		}
	}

	public int DropCost
	{
		get
		{
			return 20;
		}
	}

	public int Capacity
	{
		get
		{
			return 50;
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

	public SensorUpgrade(DroneUpgradeDefinition definition)
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
		try
		{
			if (DroneItemDropper.KnownSensorCount > 0)
			{
				List<DropableItem> list = DroneItemDropper.DroppedItemDict[DropItemType.Sensor];
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					DropableItem dropableItem = list[i];
					if (!dropableItem.IsInSpace && dropableItem.DroppingUpgrade == this)
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
		if (!flag)
		{
			CancelAbility();
		}
	}

	public override List<CommandDefinition> QueryAvailableCommands()
	{
		if (commandList == null)
		{
			commandList = new List<CommandDefinition>(CommandHelper.GetCommands("SensorUpgrade"));
		}
		return commandList;
	}

	public void Drop()
	{
		if (Quantity > 0)
		{
			if (ActivateAbility())
			{
				drone.Drop(DropItemType.Sensor, this);
				Quantity -= 1;
				SendConsoleResponseMessage("Sensor dropped", ConsoleMessageType.Info);
			}
		}
		else if (drone.StorageUpgradeTotalQuantity(base.Definition.Type) <= 0)
		{
			SendConsoleResponseMessage("No sensors available", ConsoleMessageType.Warning);
		}
	}

	public int Pickup()
	{
		return 0;
	}

	public void Teleport(Room room)
	{
		if (Quantity > 0)
		{
			if (ActivateAbility())
			{
				Vector3 safePos = Vector3.zero;
				Bounds destBounds = new Bounds(Vector3.zero, DroneItemDropper.Instance.sensorPrefab.GetComponent<Collider>().bounds.size);
				Waypoint mainRoomWaypoint = NavigationHelper.GetMainRoomWaypoint(room);
				destBounds.center = mainRoomWaypoint.transform.position;
				if (room.PickSafeLocationForBounds(destBounds, out safePos))
				{
					drone.Drop(DropItemType.Sensor, this, safePos, room);
					Quantity -= 1;
					SendConsoleResponseMessage("Sensor sent", ConsoleMessageType.Info);
				}
				else
				{
					SendConsoleResponseMessage("Could not find space in the destination room for a Sensor", ConsoleMessageType.Warning);
				}
			}
		}
		else if (drone.StorageUpgradeTotalQuantity(base.Definition.Type) <= 0)
		{
			SendConsoleResponseMessage("No sensors available", ConsoleMessageType.Warning);
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
		return false;
	}
}
