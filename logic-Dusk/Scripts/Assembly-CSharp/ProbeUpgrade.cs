using System.Collections.Generic;

public class ProbeUpgrade : BaseDroneUpgrade, IDropperUpgrade, IStorageUpgrade
{
	private const string COMMAND_VALUE = "probe";

	private static List<CommandDefinition> commandList;

	private int guiCapacity;

	private int guiQuantity;

	private string _guiString = string.Empty;

	public override string CommandValue
	{
		get
		{
			return "probe";
		}
	}

	public DropItemType DropType
	{
		get
		{
			return DropItemType.Probe;
		}
	}

	public int DropCost
	{
		get
		{
			return 75;
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

	public bool HasIncreasedHealthMod
	{
		get
		{
			return (AppliedModifications & ModificationStorageIdEnum.ShieldRadiation) != 0;
		}
	}

	public bool HasStealthMod
	{
		get
		{
			return (AppliedModifications & ModificationStorageIdEnum.ProbeStealth) != 0;
		}
	}

	public ProbeUpgrade(DroneUpgradeDefinition definition)
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
		if (DroneItemDropper.KnownProbeCount > 0)
		{
			try
			{
				List<DropableItem> list = DroneItemDropper.DroppedItemDict[DropItemType.Probe];
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					DropableItem dropableItem = list[i];
					if (!dropableItem.IsInSpace && dropableItem.DroppingUpgrade == this)
					{
						ProbeItem probeItem = (ProbeItem)dropableItem;
						if (!probeItem.IsDead)
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
			commandList = new List<CommandDefinition>(CommandHelper.GetCommands("ProbeUpgrade"));
		}
		return commandList;
	}

	public void Drop()
	{
		if (Quantity > 0)
		{
			if (ActivateAbility())
			{
				ProbeItem probeItem = (ProbeItem)drone.Drop(DropType, this);
				if (HasIncreasedHealthMod)
				{
					probeItem.OverrideTotalHitpoints(700f);
					probeItem.OverrideCurrentHitpoints(700f);
				}
				if (HasStealthMod)
				{
					probeItem.SetStealthMode();
				}
				SendConsoleResponseMessage("Probe dropped", ConsoleMessageType.Info);
				GameplayManager.Instance.missionProfitLoss -= DropCost;
				Quantity -= 1;
			}
		}
		else if (drone.StorageUpgradeTotalQuantity(base.Definition.Type) <= 0)
		{
			SendConsoleResponseMessage("No probes available", ConsoleMessageType.Warning);
		}
	}

	public int Pickup()
	{
		int num = 0;
		if (drone.AnyPickupableItemsNearby(DropItemType.Probe, this))
		{
			if (Quantity < Capacity)
			{
				int failedPickupTest = 0;
				List<DropableItem> pickedUpItems;
				num = drone.Pickup(DropType, this, out pickedUpItems, CanPickupProbe, out failedPickupTest);
				if (num > 0)
				{
					SendConsoleResponseMessage("Picked up " + num + " probe(s)", ConsoleMessageType.Benefit);
					Quantity += num;
					foreach (DropableItem item in pickedUpItems)
					{
						GameplayManager.Instance.missionProfitLoss += (int)((float)DropCost * (((ICombatTarget)item).CurrentHitPoints / ((ICombatTarget)item).TotalHitpoints));
					}
				}
			}
			else
			{
				if (drone.StorageUpgradeTotalQuantity(base.Definition.Type) != drone.StorageUpgradeMaxCapacity(base.Definition.Type))
				{
					return -1;
				}
				SendConsoleResponseMessage("No capacity for more probes", ConsoleMessageType.Warning);
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

	private bool CanPickupProbe(DropableItem item)
	{
		ProbeItem probeItem = (ProbeItem)item;
		if (probeItem.IsDead)
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
