using System.Collections.Generic;

public class LureUpgrade : BaseDroneUpgrade, IDropperUpgrade, IStorageUpgrade
{
	private const string COMMAND_VALUE = "lure";

	private static List<CommandDefinition> commandList;

	private int guiCapacity;

	private int guiQuantity;

	private string _guiString = string.Empty;

	public override string CommandValue
	{
		get
		{
			return "lure";
		}
	}

	public DropItemType DropType
	{
		get
		{
			return DropItemType.Lure;
		}
	}

	public int DropCost
	{
		get
		{
			return 50;
		}
	}

	public int Capacity
	{
		get
		{
			return 6;
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

	public LureUpgrade(DroneUpgradeDefinition definition)
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
		if (DroneItemDropper.KnownLureCount > 0)
		{
			try
			{
				List<DropableItem> list = DroneItemDropper.DroppedItemDict[DropItemType.Lure];
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					DropableItem dropableItem = list[i];
					if (!dropableItem.IsInSpace && dropableItem.DroppingUpgrade == this)
					{
						LureItem lureItem = (LureItem)dropableItem;
						if (!lureItem.IsDead)
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

	public override void RegisterCommands()
	{
		List<CommandDefinition> commands = CommandHelper.GetCommands("LureUpgrade");
		foreach (CommandDefinition item in commands)
		{
			CommandTree.AddCommand(item, CommandTypeEnum.MultiObjectCommand, this, DroneManager.Instance.CommandProcessVerification);
		}
	}

	public override List<CommandDefinition> QueryAvailableCommands()
	{
		if (commandList == null)
		{
			commandList = new List<CommandDefinition>(CommandHelper.GetCommands("LureUpgrade"));
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
				SendConsoleResponseMessage("Lure dropped", ConsoleMessageType.Info);
				GameplayManager.Instance.missionProfitLoss -= DropCost;
				Quantity -= 1;
			}
		}
		else if (drone.StorageUpgradeTotalQuantity(base.Definition.Type) <= 0)
		{
			SendConsoleResponseMessage("No lures available", ConsoleMessageType.Warning);
		}
	}

	public int Pickup()
	{
		int num = 0;
		if (drone.AnyPickupableItemsNearby(DropItemType.Lure, this))
		{
			if (Quantity < Capacity)
			{
				int failedPickupTest = 0;
				List<DropableItem> pickedUpItems;
				num = drone.Pickup(DropType, this, out pickedUpItems, CanPickupLure, out failedPickupTest);
				if (num > 0)
				{
					SendConsoleResponseMessage("Picked up " + num + " lure(s)", ConsoleMessageType.Benefit);
					Quantity += num;
					foreach (DropableItem item in pickedUpItems)
					{
						GameplayManager.Instance.missionProfitLoss += (int)((float)DropCost * (((ICombatTarget)item).CurrentHitPoints / ((ICombatTarget)item).TotalHitpoints));
					}
				}
				else if (failedPickupTest > 0)
				{
					SendConsoleResponseMessage("Can't pickup: lure damaged.", ConsoleMessageType.Warning);
				}
			}
			else
			{
				if (drone.StorageUpgradeTotalQuantity(base.Definition.Type) != drone.StorageUpgradeMaxCapacity(base.Definition.Type))
				{
					return -1;
				}
				SendConsoleResponseMessage("No capacity for more lures", ConsoleMessageType.Warning);
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

	private bool CanPickupLure(DropableItem item)
	{
		LureItem lureItem = (LureItem)item;
		if (lureItem.IsDead || lureItem.CurrentHitPoints < lureItem.TotalHitpoints)
		{
			return false;
		}
		return true;
	}

	public bool Detonate(bool sendResponseToConsole)
	{
		return false;
	}
}
