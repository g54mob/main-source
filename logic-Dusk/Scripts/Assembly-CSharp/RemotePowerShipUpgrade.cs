using System;
using System.Collections.Generic;
using System.Linq;

public class RemotePowerShipUpgrade : BaseShipUpgrade
{
	private static List<CommandDefinition> commandList;

	private DungeonManager dungeonManager;

	private DungeonPowerInlet previousPowerInlet;

	public override ShipUpgradeType UpgradeType
	{
		get
		{
			return ShipUpgradeType.RemotePower;
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
			return "Remote Power";
		}
	}

	public override string CommandValue
	{
		get
		{
			return "remote";
		}
	}

	public RemotePowerShipUpgrade(int id)
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
			commandList = new List<CommandDefinition>(CommandHelper.GetCommands("ShipUpgradeRemotePower"));
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
		case "remote":
		case "power":
			if (command.Arguments.Count > 0)
			{
				Room room = dungeonManager.rooms.FirstOrDefault((Room x) => x.Label.ToLower() == command.Arguments.First().ToLower());
				if (room != null)
				{
					RoomItem roomItem = room.GetRoomItem(typeof(DungeonPowerInlet), false);
					if (roomItem != null)
					{
						if (((DungeonPowerInlet)roomItem).BrokenState != BrokenStateEnum.Broken)
						{
							if (previousPowerInlet == null)
							{
								if (!roomItem.Powered)
								{
									previousPowerInlet = (DungeonPowerInlet)roomItem;
									DungeonPowerInlet dungeonPowerInlet = previousPowerInlet;
									dungeonPowerInlet.poweredDown = (DungeonPowerInlet.PowerChange)Delegate.Remove(dungeonPowerInlet.poweredDown, new DungeonPowerInlet.PowerChange(InletPoweredDown));
									DungeonPowerInlet dungeonPowerInlet2 = previousPowerInlet;
									dungeonPowerInlet2.poweredDown = (DungeonPowerInlet.PowerChange)Delegate.Combine(dungeonPowerInlet2.poweredDown, new DungeonPowerInlet.PowerChange(InletPoweredDown));
									roomItem.PowerUp(null);
								}
								else
								{
									roomItem.PowerDown(null);
									if (previousPowerInlet != null && previousPowerInlet == roomItem)
									{
										DungeonPowerInlet dungeonPowerInlet3 = previousPowerInlet;
										dungeonPowerInlet3.poweredDown = (DungeonPowerInlet.PowerChange)Delegate.Remove(dungeonPowerInlet3.poweredDown, new DungeonPowerInlet.PowerChange(InletPoweredDown));
										previousPowerInlet = null;
									}
								}
								HintManager.HintCompleted(typeof(RemoteSUHint));
								UpgradeUsed();
							}
							else if (!roomItem.Powered)
							{
								if (previousPowerInlet == roomItem)
								{
									previousPowerInlet = (DungeonPowerInlet)roomItem;
									DungeonPowerInlet dungeonPowerInlet4 = previousPowerInlet;
									dungeonPowerInlet4.poweredDown = (DungeonPowerInlet.PowerChange)Delegate.Remove(dungeonPowerInlet4.poweredDown, new DungeonPowerInlet.PowerChange(InletPoweredDown));
									DungeonPowerInlet dungeonPowerInlet5 = previousPowerInlet;
									dungeonPowerInlet5.poweredDown = (DungeonPowerInlet.PowerChange)Delegate.Combine(dungeonPowerInlet5.poweredDown, new DungeonPowerInlet.PowerChange(InletPoweredDown));
									roomItem.PowerUp(null);
									HintManager.HintCompleted(typeof(RemoteSUHint));
									UpgradeUsed();
								}
								else
								{
									SendConsoleResponseMessage("can only provide power to one inlet at a time", ConsoleMessageType.Warning);
								}
							}
							else
							{
								roomItem.PowerDown(null);
								HintManager.HintCompleted(typeof(RemoteSUHint));
								UpgradeUsed();
								if (previousPowerInlet != null && previousPowerInlet == roomItem)
								{
									DungeonPowerInlet dungeonPowerInlet6 = previousPowerInlet;
									dungeonPowerInlet6.poweredDown = (DungeonPowerInlet.PowerChange)Delegate.Remove(dungeonPowerInlet6.poweredDown, new DungeonPowerInlet.PowerChange(InletPoweredDown));
									previousPowerInlet = null;
								}
							}
						}
						else
						{
							SendConsoleResponseMessage(string.Format("Inlet in room {0} is broken", room.Label), ConsoleMessageType.Warning);
						}
					}
					else
					{
						SendConsoleResponseMessage(string.Format("no power inlet in room: {0}", room.Label), ConsoleMessageType.Warning);
					}
				}
				else
				{
					SendConsoleResponseMessage(string.Format("invalid room argument specified: {0}", command.Arguments.First().ToLower()), ConsoleMessageType.Warning);
				}
			}
			else
			{
				Room[] rooms = dungeonManager.rooms;
				foreach (Room room2 in rooms)
				{
					if (!(room2 != null) || !room2.onSchematic)
					{
						continue;
					}
					RoomItem roomItem2 = room2.GetRoomItem(typeof(DungeonPowerInlet), false);
					if (roomItem2 != null && roomItem2.HasBeenSeen())
					{
						string arg = string.Empty;
						if (roomItem2.Powered)
						{
							arg = " (powered)";
						}
						SendConsoleResponseMessage(string.Format("power inet in room {0}{1}", room2.Label, arg), ConsoleMessageType.Info);
					}
				}
				command.Handled = true;
			}
			command.Handled = true;
			break;
		}
	}

	private void InletPoweredDown()
	{
		if (previousPowerInlet != null)
		{
			DungeonPowerInlet dungeonPowerInlet = previousPowerInlet;
			dungeonPowerInlet.poweredDown = (DungeonPowerInlet.PowerChange)Delegate.Remove(dungeonPowerInlet.poweredDown, new DungeonPowerInlet.PowerChange(InletPoweredDown));
		}
		previousPowerInlet = null;
	}
}
