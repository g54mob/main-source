using System.Collections.Generic;
using UnityEngine;

public class ProximityMineUpgrade : BaseDroneUpgrade, IDropperUpgrade, IStorageUpgrade
{
	private const string COMMAND_VALUE = "mine";

	private static List<CommandDefinition> commandList;

	private int guiCapacity;

	private int guiQuantity;

	private string _guiString = string.Empty;

	public override string CommandValue
	{
		get
		{
			return "mine";
		}
	}

	public DropItemType DropType
	{
		get
		{
			return DropItemType.ProximityMine;
		}
	}

	public int DropCost
	{
		get
		{
			return 30;
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

	public ProximityMineUpgrade(DroneUpgradeDefinition definition)
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
		if (GlobalSettings.IsGamePaused)
		{
			return;
		}
		int num = 0;
		if (DroneItemDropper.KnownMineCount > 0)
		{
			try
			{
				List<DropableItem> list = DroneItemDropper.DroppedItemDict[DropItemType.ProximityMine];
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					DropableItem dropableItem = list[i];
					if (dropableItem.IsInSpace || dropableItem.DroppingUpgrade != this)
					{
						continue;
					}
					ProximityMineItem proximityMineItem = (ProximityMineItem)dropableItem;
					if (proximityMineItem.Destroyed)
					{
						continue;
					}
					num++;
					if (!proximityMineItem.IsTripped)
					{
						int count2 = EnemyManager.Instance.Enemies.Count;
						for (int j = 0; j < count2; j++)
						{
							BaseEnemy baseEnemy = EnemyManager.Instance.Enemies[j];
							if (!baseEnemy.IsDead && Vector3.Distance(baseEnemy.transform.position, proximityMineItem.transform.position) <= 2f)
							{
								proximityMineItem.IsTripped = true;
							}
						}
					}
					else
					{
						if (!proximityMineItem.IsArmed)
						{
							continue;
						}
						bool flag = false;
						int count3 = DroneManager.Instance.dronesList.Count;
						for (int k = 0; k < count3; k++)
						{
							Drone drone = DroneManager.Instance.dronesList[k];
							if (drone != null && !drone.IsDead && !drone.IsStunned && Vector3.Distance(drone.transform.position, proximityMineItem.transform.position) <= 0.5f)
							{
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							proximityMineItem.Detonate();
						}
					}
				}
			}
			catch
			{
			}
		}
		if (num == 0)
		{
			CancelAbility();
		}
	}

	public override List<CommandDefinition> QueryAvailableCommands()
	{
		if (commandList == null)
		{
			commandList = new List<CommandDefinition>(CommandHelper.GetCommands("ProximityMineUpgrade"));
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
				SendConsoleResponseMessage("Proximity mine dropped", ConsoleMessageType.Info);
				GameplayManager.Instance.missionProfitLoss -= DropCost;
				Quantity -= 1;
			}
		}
		else if (drone.StorageUpgradeTotalQuantity(base.Definition.Type) <= 0)
		{
			SendConsoleResponseMessage("No proximity mines available", ConsoleMessageType.Warning);
		}
	}

	public int Pickup()
	{
		int num = 0;
		if (drone.AnyPickupableItemsNearby(DropItemType.ProximityMine, this))
		{
			if (Quantity < Capacity)
			{
				List<DropableItem> pickedUpItems;
				num = drone.Pickup(DropType, this, out pickedUpItems);
				if (num > 0)
				{
					SendConsoleResponseMessage("Picked up " + num + " proximity mine(s)", ConsoleMessageType.Benefit);
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
				SendConsoleResponseMessage("No capacity for more proximity mines", ConsoleMessageType.Warning);
			}
		}
		return num;
	}

	public void Teleport(Room room)
	{
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
