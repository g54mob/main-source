using System.Collections.Generic;
using System.Linq;

public class PowerManagerShipUpgrade : BaseShipUpgrade
{
	private static List<CommandDefinition> commandList;

	private DungeonManager dungeonManager;

	public override ShipUpgradeType UpgradeType
	{
		get
		{
			return ShipUpgradeType.PowerManager;
		}
	}

	public override bool IsPermanentUpgrade
	{
		get
		{
			return false;
		}
	}

	public override string Name
	{
		get
		{
			return "Reroute Power";
		}
	}

	public override string Description
	{
		get
		{
			return "Manages a ship's power grid";
		}
	}

	public override string CommandValue
	{
		get
		{
			return "reroute";
		}
	}

	public PowerManagerShipUpgrade(int id)
		: base(id)
	{
	}

	protected override void OnInitialize()
	{
		dungeonManager = DungeonManager.Instance;
		base.OnInitialize();
	}

	public override List<CommandDefinition> QueryAvailableCommands()
	{
		if (commandList == null)
		{
			commandList = new List<CommandDefinition>(CommandHelper.GetCommands("ShipUpgradePowerManager"));
		}
		return commandList;
	}

	public override void ExecuteCommand(ExecutedCommand command, bool partOfMultiCommand)
	{
		if (!GlobalSettings.MissionStarted)
		{
			return;
		}
		switch (command.Command.CommandName)
		{
		case "reroute":
		{
			if (command.Arguments.Count < 2)
			{
				SendConsoleResponseMessage("command is not valid.  ex: reroute r1 r3 r4", ConsoleMessageType.Error);
				command.Handled = true;
				break;
			}
			Room room = dungeonManager.rooms.FirstOrDefault((Room x) => x.Label.ToLower() == command.Arguments.First().ToLower());
			if (room == null)
			{
				SendConsoleResponseMessage("first argument is not a valid room: " + command.Arguments.First(), ConsoleMessageType.Error);
				command.Handled = true;
				break;
			}
			RoomItem roomItem = room.GetRoomItem(typeof(DungeonPowerInlet), false);
			if (roomItem != null)
			{
				if (roomItem.Powered)
				{
					DungeonPowerInlet dungeonPowerInlet = (DungeonPowerInlet)roomItem.GetComponent(typeof(DungeonPowerInlet));
					if ("status".StartsWith(command.Arguments[1].ToLower()))
					{
						int num = 0;
						int num2 = 0;
						foreach (Room room5 in dungeonPowerInlet.rooms)
						{
							if (room5 != null)
							{
								if (room5.isPowered)
								{
									num++;
								}
								if (room5.onSchematic)
								{
									num2++;
								}
							}
						}
						HintManager.HintCompleted(typeof(RerouteSUHint));
						UpgradeUsed();
						SendConsoleResponseMessage("inlet powering " + num + " of " + dungeonPowerInlet.RoomCount + " possible rooms", ConsoleMessageType.Info);
					}
					else if (command.Arguments[1].StartsWith("-"))
					{
						string rmCmd = command.Arguments[1].Substring(1, command.Arguments[1].Length - 1);
						Room room2 = dungeonManager.rooms.FirstOrDefault((Room x) => x.Label.ToLower() == rmCmd.ToLower());
						if (room2 != null)
						{
							if (room2 != dungeonPowerInlet.roomLocation)
							{
								if (room2.isPowered)
								{
									if (dungeonPowerInlet.PowerDownRoom(room2))
									{
										SendConsoleResponseMessage("room " + room2.Label + " powered down", ConsoleMessageType.Info);
										HintManager.HintCompleted(typeof(RerouteSUHint));
										UpgradeUsed();
									}
									else
									{
										SendConsoleResponseMessage("room " + room2.Label + " not controlled by " + room2.Label, ConsoleMessageType.Warning);
									}
								}
								else
								{
									SendConsoleResponseMessage("room " + room2.Label + " already powered down", ConsoleMessageType.Info);
								}
							}
							else
							{
								SendConsoleResponseMessage("can't reroute power away from room with power inlet!", ConsoleMessageType.Info);
							}
						}
						else
						{
							SendConsoleResponseMessage("specified room (" + rmCmd + ") not found.", ConsoleMessageType.Warning);
						}
					}
					else if (command.Arguments[1].StartsWith("+"))
					{
						if (dungeonPowerInlet.rooms.Count == dungeonPowerInlet.RoomCount)
						{
							SendConsoleResponseMessage("inlet in " + dungeonPowerInlet.roomLocation.Label + " is at maximum capacity", ConsoleMessageType.Warning);
						}
						else
						{
							string rmCmd2 = command.Arguments[1].Substring(1, command.Arguments[1].Length - 1);
							Room room3 = dungeonManager.rooms.FirstOrDefault((Room x) => x.Label.ToLower() == rmCmd2.ToLower());
							if (room3 != null)
							{
								if (room3 != dungeonPowerInlet.roomLocation)
								{
									if (!room3.isPowered)
									{
										if (dungeonPowerInlet.PowerUpRoom(room3))
										{
											SendConsoleResponseMessage("room " + room3.Label + " powered up", ConsoleMessageType.Info);
											HintManager.HintCompleted(typeof(RerouteSUHint));
											UpgradeUsed();
										}
										else
										{
											SendConsoleResponseMessage(room3.Label + " not connected to the " + dungeonPowerInlet.roomLocation.Label + " power grid", ConsoleMessageType.Warning);
										}
									}
									else
									{
										SendConsoleResponseMessage("room " + room3.Label + " already powered up", ConsoleMessageType.Info);
									}
								}
								else
								{
									SendConsoleResponseMessage("can't reroute power to room with power inlet!", ConsoleMessageType.Info);
								}
							}
							else
							{
								SendConsoleResponseMessage("specified room (" + rmCmd2 + ") not found.", ConsoleMessageType.Warning);
							}
						}
					}
					else
					{
						dungeonPowerInlet.ClearRooms();
						int count = command.Arguments.Count;
						List<Room> potentialRoomList = new List<Room>();
						for (int i = 1; i < count; i++)
						{
							Room room4 = dungeonManager.rooms.FirstOrDefault((Room x) => x.Label.ToLower() == command.Arguments[i].ToLower());
							if (room4 != null)
							{
								potentialRoomList.Add(room4);
							}
						}
						if (potentialRoomList.Count == 0)
						{
							SendConsoleResponseMessage("no valid arguments were provided for the target rooms.  ex: 'reroute r1 r3 r4'", ConsoleMessageType.Warning);
							command.Handled = true;
							break;
						}
						bool exceededMax = false;
						List<Room> connectedRooms = GetConnectedRooms(dungeonPowerInlet.roomLocation, dungeonPowerInlet.RoomCount - 1, ref potentialRoomList, out exceededMax);
						if (connectedRooms.Count > 0)
						{
							HintManager.HintCompleted(typeof(RerouteSUHint));
							UpgradeUsed();
							foreach (Room item in connectedRooms)
							{
								dungeonPowerInlet.rooms.Add(item);
								item.power(dungeonPowerInlet, true);
							}
							if (exceededMax)
							{
								SendConsoleResponseMessage("specified inlet can only power " + dungeonPowerInlet.RoomCount + " rooms", ConsoleMessageType.Warning);
							}
						}
						else if (potentialRoomList.Count == 1 && potentialRoomList[0] == dungeonPowerInlet.roomLocation)
						{
							SendConsoleResponseMessage("can't reroute power to the room with the power inlet!", ConsoleMessageType.Error);
						}
						else
						{
							SendConsoleResponseMessage("none of the rooms provided were connected to the inet room", ConsoleMessageType.Error);
						}
					}
				}
				else
				{
					SendConsoleResponseMessage("The power inlet in room " + room.Label + " isn't powered - can't reroute", ConsoleMessageType.Warning);
				}
			}
			else
			{
				SendConsoleResponseMessage("There isn't a power inlet in room " + room.Label, ConsoleMessageType.Error);
			}
			command.Handled = true;
			break;
		}
		}
	}

	private List<Room> GetConnectedRooms(Room sourceRoom, int maxConnectedRooms, ref List<Room> potentialRoomList, out bool exceededMax)
	{
		exceededMax = false;
		List<Room> adjacentRooms = sourceRoom.getAdjacentRooms();
		List<Room> list = new List<Room>();
		int count = potentialRoomList.Count;
		for (int num = count - 1; num >= 0; num--)
		{
			if (adjacentRooms.Contains(potentialRoomList[num]))
			{
				list.Add(potentialRoomList[num]);
				potentialRoomList.RemoveAt(num);
			}
		}
		if (list.Count > maxConnectedRooms)
		{
			list.RemoveRange(maxConnectedRooms, list.Count - maxConnectedRooms);
			exceededMax = true;
			return list;
		}
		if (list.Count > 0 && potentialRoomList.Count > 0)
		{
			count = list.Count;
			for (int num2 = count - 1; num2 >= 0; num2--)
			{
				List<Room> connectedRooms = GetConnectedRooms(list[num2], maxConnectedRooms, ref potentialRoomList, out exceededMax);
				if (connectedRooms.Count > 0)
				{
					list.AddRange(connectedRooms.ToArray());
					if (list.Count > maxConnectedRooms)
					{
						list.RemoveRange(maxConnectedRooms, list.Count - maxConnectedRooms);
						exceededMax = true;
						return list;
					}
				}
			}
		}
		return list;
	}
}
