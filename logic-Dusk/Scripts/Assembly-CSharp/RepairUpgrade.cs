using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RepairUpgrade : BaseDroneUpgrade, IStorageUpgrade
{
	private const string COMMAND_VALUE = "repair";

	private int guiCapacity;

	private int guiQuantity;

	private string _guiString = string.Empty;

	public override string CommandValue
	{
		get
		{
			return "repair";
		}
	}

	public float RepairRadius
	{
		get
		{
			return 2f;
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

	public RepairUpgrade(DroneUpgradeDefinition definition)
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

	public override List<CommandDefinition> QueryAvailableCommands()
	{
		return CommandHelper.GetCommands("RepairUpgrade");
	}

	public override void ExecuteCommand(ExecutedCommand command, bool partOfMultiCommand)
	{
		if (!base.PoweredUp)
		{
			return;
		}
		switch (command.Command.CommandName)
		{
		case "repair":
			if (Quantity > 0)
			{
				command.Handled = true;
				List<IBreakable> itemsNeedingRepairsInRange = GetItemsNeedingRepairsInRange();
				List<IBreakable> list = new List<IBreakable>();
				if (command.Arguments.Count == 0)
				{
					if (itemsNeedingRepairsInRange.Count == 1)
					{
						list.Add(itemsNeedingRepairsInRange.First());
					}
					else if (itemsNeedingRepairsInRange.Count > 1)
					{
						bool flag = true;
						int num = 0;
						DroneUpgradeType droneUpgradeType = DroneUpgradeType.Undefined;
						foreach (IBreakable item in itemsNeedingRepairsInRange)
						{
							if (!(item is BaseDroneUpgrade))
							{
								flag = false;
								break;
							}
							BaseDroneUpgrade baseDroneUpgrade = (BaseDroneUpgrade)item;
							if (num == 0)
							{
								num = baseDroneUpgrade.drone.DroneNumber;
							}
							else if (num != baseDroneUpgrade.drone.DroneNumber)
							{
								flag = false;
								break;
							}
							if (droneUpgradeType == DroneUpgradeType.Undefined)
							{
								droneUpgradeType = baseDroneUpgrade.Definition.Type;
							}
							else if (droneUpgradeType != baseDroneUpgrade.Definition.Type)
							{
								flag = false;
								break;
							}
						}
						if (flag)
						{
							list.Add(itemsNeedingRepairsInRange.First());
						}
						else
						{
							SendConsoleResponseMessage("Items needing repairs:", ConsoleMessageType.Info);
							itemsNeedingRepairsInRange.ForEach(delegate(IBreakable x)
							{
								SendConsoleResponseMessage("\t" + x.RepairId, ConsoleMessageType.Info);
							});
						}
					}
					else
					{
						SendConsoleResponseMessage("Nothing to repair", ConsoleMessageType.Info);
					}
				}
				else if (command.Arguments.Count == 1 && command.Arguments[0].ToLower() == "all")
				{
					if (itemsNeedingRepairsInRange.Count <= Quantity)
					{
						list.AddRange(itemsNeedingRepairsInRange);
					}
					else
					{
						SendConsoleResponseMessage(string.Format("Not enough repair juice to fix all {0} broken items!", itemsNeedingRepairsInRange.Count), ConsoleMessageType.Warning);
					}
				}
				else if (command.Arguments.Count <= Quantity)
				{
					string argument;
					foreach (string argument2 in command.Arguments)
					{
						argument = argument2;
						int num2 = itemsNeedingRepairsInRange.Where((IBreakable x) => x.RepairId.StartsWith(argument)).Count();
						if (num2 == 1)
						{
							list.Add(itemsNeedingRepairsInRange.First((IBreakable x) => x.RepairId.StartsWith(argument)));
						}
						else
						{
							SendConsoleResponseMessage("No items or too many items found for: " + argument, ConsoleMessageType.Info);
						}
					}
				}
				else
				{
					SendConsoleResponseMessage(string.Format("Not enough repair juice to fix all {0} specified items!", command.Arguments.Count), ConsoleMessageType.Warning);
				}
				if (list.Count <= 0 || !ActivateAbility())
				{
					break;
				}
				bool flag2 = false;
				foreach (IBreakable item2 in list)
				{
					string fixMessage;
					if (item2.Fix(out fixMessage))
					{
						Quantity -= 1;
						flag2 = true;
						if (string.IsNullOrEmpty(fixMessage))
						{
							fixMessage = string.Format("Fixed {0}", item2.RepairId);
						}
						SendConsoleResponseMessage(fixMessage, ConsoleMessageType.Benefit);
					}
				}
				if (Quantity < 0)
				{
					Quantity = 0;
				}
				if (!flag2)
				{
					SendConsoleResponseMessage("Nothing to repair", ConsoleMessageType.Info);
				}
			}
			else if (drone.StorageUpgradeTotalQuantity(base.Definition.Type) <= 0)
			{
				SendConsoleResponseMessage("No more repair juice!", ConsoleMessageType.Warning);
				command.Handled = true;
			}
			break;
		}
	}

	private List<IBreakable> GetItemsNeedingRepairsInRange()
	{
		List<IBreakable> list = new List<IBreakable>();
		List<Drone> list2 = new List<Drone>();
		list2.AddRange(DroneManager.Instance.dronesList);
		list2.AddRange(DroneManager.Instance.LootableDronesList);
		foreach (Drone item in list2)
		{
			float num = Vector3.Distance(drone.Position, item.Position);
			if (!(num <= RepairRadius))
			{
				continue;
			}
			if (item.BrokenState == BrokenStateEnum.ErrorsDetected || item.BrokenState == BrokenStateEnum.Broken)
			{
				list.Add(item);
				continue;
			}
			foreach (BaseDroneUpgrade upgrade in item.Upgrades)
			{
				if (upgrade != null && upgrade.BrokenState == BrokenStateEnum.ErrorsDetected)
				{
					list.Add(upgrade);
				}
			}
		}
		foreach (RoomItem roomItem in drone.CurrentRoom.roomItems)
		{
			IBreakable breakable = roomItem as IBreakable;
			if (breakable != null && breakable.BrokenState != BrokenStateEnum.OK)
			{
				list.Add(breakable);
			}
		}
		return list;
	}
}
