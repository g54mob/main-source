using System.Collections.Generic;
using UnityEngine;

public class OverloadPermUpgrade : BaseShipUpgrade, IStorageUpgrade
{
	private static List<CommandDefinition> commandList;

	public override ShipUpgradeType UpgradeType
	{
		get
		{
			return ShipUpgradeType.PermOverload;
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
			return "Overload";
		}
	}

	public override string Description
	{
		get
		{
			return "Overload electronics in room";
		}
	}

	public override string CommandValue
	{
		get
		{
			return "overload";
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

	public OverloadPermUpgrade(int id)
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
			commandList = new List<CommandDefinition>(CommandHelper.GetCommands("PermShipUpgradeOverload"));
		}
		return commandList;
	}

	public override void ExecuteCommand(ExecutedCommand command, bool partOfMultiCommand)
	{
		switch (command.Command.CommandName)
		{
		case "overload":
			if (!GlobalSettings.MissionStarted)
			{
				SendConsoleResponseMessage("Cannot overload a room until after mission starts", ConsoleMessageType.Warning);
				command.Handled = true;
				return;
			}
			if (command.Arguments.Count > 0)
			{
				foreach (string argument in command.Arguments)
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
					else if (Quantity > 0)
					{
						if (room.isPowered)
						{
							List<BaseEnemy> list = null;
							List<Drone> list2 = null;
							if (EnemyManager.Instance.Enemies.Count > 0)
							{
								int count = EnemyManager.Instance.Enemies.Count;
								for (int j = 0; j < count; j++)
								{
									if (EnemyManager.Instance.Enemies[j].CurrentRoom == room && !EnemyManager.Instance.Enemies[j].IsDead)
									{
										if (list == null)
										{
											list = new List<BaseEnemy>();
										}
										list.Add(EnemyManager.Instance.Enemies[j]);
									}
								}
							}
							int count2 = DroneManager.Instance.dronesList.Count;
							for (int k = 0; k < count2; k++)
							{
								if (DroneManager.Instance.dronesList[k].CurrentRoom == room && !DroneManager.Instance.dronesList[k].IsDead)
								{
									if (list2 == null)
									{
										list2 = new List<Drone>();
									}
									list2.Add(DroneManager.Instance.dronesList[k]);
								}
							}
							List<RoomItem> damagableRoomItems = room.GetDamagableRoomItems(true);
							if (damagableRoomItems != null && damagableRoomItems.Count > 0)
							{
								int count3 = damagableRoomItems.Count;
								for (int l = 0; l < count3; l++)
								{
									RoomItem roomItem = damagableRoomItems[l];
									IDamagableObject damagableObject = (IDamagableObject)roomItem;
									float damage = Random.Range(80f, 150f);
									damagableObject.TakeDamage(damage, DamageType.Physical, null);
									if (list != null)
									{
										int count4 = list.Count;
										for (int m = 0; m < count4; m++)
										{
											list[m].TakeDamage(damage, DamageType.Splash, (ICombatTarget)roomItem);
										}
									}
									if (list2 != null)
									{
										int count5 = list2.Count;
										for (int n = 0; n < count5; n++)
										{
											list2[n].TakeDamage(damage, DamageType.Splash, (ICombatTarget)roomItem);
										}
									}
								}
								GameAudio.Play2DSFX(GameAudio.SoundEnum.ShipOverload);
								Quantity -= 1;
								SchematicViewShipPanel.Instance.SetData();
							}
							else
							{
								SendConsoleResponseMessage("No working electronics found in room: " + argument, ConsoleMessageType.Warning);
							}
						}
						else
						{
							SendConsoleResponseMessage("Room isn't powered: " + argument, ConsoleMessageType.Warning);
						}
					}
					else
					{
						SendConsoleResponseMessage("Overload is empty.", ConsoleMessageType.Error);
					}
				}
			}
			else
			{
				SendConsoleResponseMessage("Invalid or missing parameters.  Ex: 'overload r4'", ConsoleMessageType.Error);
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
