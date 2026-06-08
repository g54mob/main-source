using System.Collections.Generic;
using UnityEngine;

public class StunUpgrade : BaseDroneUpgrade, IDropperUpgrade, IStorageUpgrade
{
	private const string COMMAND_VALUE = "stun";

	private static List<CommandDefinition> commandList;

	private int guiCapacity;

	private int guiQuantity;

	private string _guiString = string.Empty;

	public override string CommandValue
	{
		get
		{
			return "stun";
		}
	}

	public DropItemType DropType
	{
		get
		{
			return DropItemType.StunBomb;
		}
	}

	public int DropCost
	{
		get
		{
			return 10;
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

	public StunUpgrade(DroneUpgradeDefinition definition)
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
		if (DroneItemDropper.KnownStunCount > 0)
		{
			try
			{
				List<DropableItem> list = DroneItemDropper.DroppedItemDict[DropItemType.StunBomb];
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					DropableItem dropableItem = list[i];
					if (dropableItem.IsInSpace || dropableItem.DroppingUpgrade != this)
					{
						continue;
					}
					StunItem stunItem = (StunItem)dropableItem;
					if (stunItem.Destroyed)
					{
						continue;
					}
					num++;
					if (!stunItem.IsTripped)
					{
						List<BaseEnemy> enemies = EnemyManager.Instance.Enemies;
						if (enemies == null)
						{
							continue;
						}
						int count2 = enemies.Count;
						for (int j = 0; j < count2; j++)
						{
							BaseEnemy baseEnemy = enemies[j];
							if (!baseEnemy.IsDead && Vector3.Distance(baseEnemy.transform.position, stunItem.transform.position) <= 2f)
							{
								stunItem.IsTripped = true;
							}
						}
					}
					else
					{
						if (!stunItem.IsArmed)
						{
							continue;
						}
						bool flag = false;
						int count3 = DroneManager.Instance.dronesList.Count;
						for (int k = 0; k < count3; k++)
						{
							Drone drone = DroneManager.Instance.dronesList[k];
							if (drone != null && !drone.IsDead && !drone.IsStunned && Vector3.Distance(drone.transform.position, stunItem.transform.position) <= 1f)
							{
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							stunItem.Detonate();
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
			commandList = new List<CommandDefinition>(CommandHelper.GetCommands("StunUpgrade"));
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
				SendConsoleResponseMessage("Stun dropped", ConsoleMessageType.Info);
				GameplayManager.Instance.missionProfitLoss -= DropCost;
				Quantity -= 1;
			}
		}
		else if (drone.StorageUpgradeTotalQuantity(base.Definition.Type) <= 0)
		{
			SendConsoleResponseMessage("No stun bombs available", ConsoleMessageType.Warning);
		}
	}

	public int Pickup()
	{
		int num = 0;
		if (drone.AnyPickupableItemsNearby(DropItemType.StunBomb, this))
		{
			if (Quantity < Capacity)
			{
				List<DropableItem> pickedUpItems;
				num = drone.Pickup(DropType, this, out pickedUpItems);
				if (num > 0)
				{
					SendConsoleResponseMessage("Picked up " + num + " proximity stun(s)", ConsoleMessageType.Benefit);
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
				SendConsoleResponseMessage("No capacity for more proximity stuns", ConsoleMessageType.Warning);
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
		bool result = false;
		if (DroneItemDropper.DroppedItemDict.ContainsKey(DropItemType.StunBomb))
		{
			foreach (DropableItem item in DroneItemDropper.DroppedItemDict[DropItemType.StunBomb])
			{
				if (item.DroppingUpgrade == this)
				{
					result = true;
					((StunItem)item).Detonate();
				}
			}
		}
		CancelAbility();
		return result;
	}
}
