using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TeleporterUpgrade : BaseDroneUpgrade
{
	private const string COMMAND_VALUE = "teleport";

	private static List<CommandDefinition> commandList;

	private bool canJump = true;

	private float timeTilNextJump;

	public override string CommandValue
	{
		get
		{
			return "teleport";
		}
	}

	public TeleporterUpgrade(DroneUpgradeDefinition definition)
		: base(definition)
	{
	}

	protected override void OnUpdate()
	{
		if (!canJump)
		{
			timeTilNextJump -= Time.deltaTime;
			if (timeTilNextJump <= 0f)
			{
				timeTilNextJump = 0f;
				canJump = true;
			}
		}
		base.OnUpdate();
	}

	public override List<CommandDefinition> QueryAvailableCommands()
	{
		if (commandList == null)
		{
			commandList = new List<CommandDefinition>(CommandHelper.GetCommands("TeleporterUpgrade"));
		}
		return commandList;
	}

	public override void ExecuteCommand(ExecutedCommand command, bool partOfMultiCommand)
	{
		if (!base.PoweredUp)
		{
			return;
		}
		switch (command.Command.CommandName)
		{
		case "teleport":
		{
			command.Handled = true;
			string text = string.Empty;
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			int count = command.Arguments.Count;
			for (int i = 0; i < count; i++)
			{
				if ((AppliedModifications & ModificationStorageIdEnum.TeleportMod) == ModificationStorageIdEnum.TeleportMod && command.Arguments[i][0] == 's' && "sensor".StartsWith(command.Arguments[i]))
				{
					flag2 = true;
					flag = true;
					continue;
				}
				if ((AppliedModifications & ModificationStorageIdEnum.TeleportMod) == ModificationStorageIdEnum.TeleportMod && command.Arguments[i][0] == 't' && "trap".StartsWith(command.Arguments[i]))
				{
					flag3 = true;
					flag = true;
					continue;
				}
				if (command.Arguments[i][0] != 'r')
				{
					SendConsoleResponseMessage("'" + command.Arguments[i] + "' is invalid in a teleport command", ConsoleMessageType.Warning);
					return;
				}
				if (command.Arguments[i][0] == 'r')
				{
					text = command.Arguments[i].ToLower();
				}
			}
			if (!string.IsNullOrEmpty(text))
			{
				if (!canJump)
				{
					SendConsoleResponseMessage("Teleporter is unable to be used - recharging....", ConsoleMessageType.Warning);
					break;
				}
				DungeonManager instance = DungeonManager.Instance;
				Room room = null;
				count = instance.rooms.Length;
				for (int j = 0; j < count; j++)
				{
					Room room2 = instance.rooms[j];
					if (room2.Label == text)
					{
						room = room2;
						break;
					}
				}
				if (room != null && (room.isExplored || room.isScanned || room.onSchematic))
				{
					if (room != drone.CurrentRoom)
					{
						if (drone.isPumpingFuel)
						{
							SendConsoleResponseMessage("Can't teleport - pumping fuel", ConsoleMessageType.Warning);
							break;
						}
						Vector3 safePos = Vector3.zero;
						if (!room.PickSafeLocationForDrone(drone, out safePos))
						{
							SendConsoleResponseMessage(string.Format("No safe place found in room {0} to teleport '{1}'", room.Label, drone.DroneName), ConsoleMessageType.Warning);
						}
						else
						{
							if (!ActivateAbility())
							{
								break;
							}
							if (!GlobalSettings.MissionStarted)
							{
								GameplayManager.Instance.StartMission();
								SendConsoleResponseMessage("Mission Started", ConsoleMessageType.Healthy);
								HintManager.HintCompleted(typeof(OpenD1Hint));
							}
							if (GlobalSettings.cameraMode == CameraMode.Drone)
							{
								drone.teleportSound.Play();
								drone.teleportSound.volume = GameAudio.RemoteVolume * 1f;
							}
							if (!flag)
							{
								drone.CurrentRoom = room;
								drone.MoveToPosition(safePos);
								canJump = false;
								timeTilNextJump = 2f;
								DroneManager.Instance.HideUpgradeSwapUI(true);
								SendConsoleResponseMessage(string.Format("teleported Drone {0} to {1}", drone.DroneNumber, room.Label), ConsoleMessageType.Info);
							}
							else
							{
								if (flag2)
								{
									bool noRoomError = false;
									if (drone.PickupAndTeleport(DropItemType.Sensor, room, out noRoomError))
									{
										SendConsoleResponseMessage("Sensor teleported", ConsoleMessageType.Benefit);
									}
									else if (!noRoomError)
									{
										SendConsoleResponseMessage("No sensor found within range.", ConsoleMessageType.Error);
									}
									else
									{
										SendConsoleResponseMessage("No room for a sensor found in the destination room - could not teleport.", ConsoleMessageType.Warning);
									}
								}
								if (flag3)
								{
									bool noRoomError2 = false;
									if (drone.PickupAndTeleport(DropItemType.Trap, room, out noRoomError2))
									{
										SendConsoleResponseMessage("Trap teleported", ConsoleMessageType.Benefit);
									}
									else if (!noRoomError2)
									{
										SendConsoleResponseMessage("No trap found within range.", ConsoleMessageType.Error);
									}
									else
									{
										SendConsoleResponseMessage("No room for a trap found in the destination room - could not teleport.", ConsoleMessageType.Warning);
									}
								}
							}
							drone.StopPriorNavigation();
						}
					}
					else
					{
						SendConsoleResponseMessage("already in specified room", ConsoleMessageType.Info);
					}
				}
				else
				{
					SendConsoleResponseMessage(string.Format("could not locate room {0}", command.Arguments.Last()), ConsoleMessageType.Info);
				}
			}
			else
			{
				SendConsoleResponseMessage("invalid parameter count (expecting one)", ConsoleMessageType.Info);
			}
			break;
		}
		}
	}
}
