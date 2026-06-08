using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PryUpgrade : BaseDroneUpgrade
{
	private const string COMMAND_VALUE = "pry";

	private static List<CommandDefinition> commandList;

	public override string CommandValue
	{
		get
		{
			return "pry";
		}
	}

	public PryUpgrade(DroneUpgradeDefinition definition)
		: base(definition)
	{
	}

	public override List<CommandDefinition> QueryAvailableCommands()
	{
		if (commandList == null)
		{
			commandList = new List<CommandDefinition>(CommandHelper.GetCommands("PryUpgrade"));
		}
		return commandList;
	}

	public override void ExecuteCommand(ExecutedCommand command, bool partOfMultiCommand)
	{
		switch (command.Command.CommandName)
		{
		case "pry":
		{
			command.Handled = true;
			if (command.Arguments.Count == 0 || (command.Arguments.Count != 2 && command.Arguments[0].ToLower() == "all") || (command.Arguments.Count != 1 && command.Arguments[0].ToLower() != "all"))
			{
				SendConsoleResponseMessage("invalid command.  Ex: pry 1 d23", ConsoleMessageType.Warning);
				break;
			}
			DungeonManager instance = DungeonManager.Instance;
			Door door = null;
			string text = command.Arguments.Last().ToLower();
			Door[] doors = instance.doors;
			foreach (Door door2 in doors)
			{
				if (door2.LabelSimple.ToLower() == text)
				{
					door = door2;
					break;
				}
			}
			if (door != null && door.corridor.containsRoom(drone.CurrentRoom))
			{
				Bounds bounds = door.corridor.GetComponent<Collider>().bounds;
				bounds.Expand(new Vector3(0.3f, 0.3f, 0.3f));
				if (bounds.Intersects(drone.GetComponent<Collider>().bounds))
				{
					if (door.state == DoorState.Open)
					{
						SendConsoleResponseMessage("door already open: " + text, ConsoleMessageType.Info);
					}
					else if (UpgradeUsed())
					{
						door.PryOpen();
						if (GlobalSettings.cameraMode == CameraMode.Drone)
						{
							drone.prySound.volume = GameAudio.RemoteVolume * 1f;
							drone.prySound.Play();
						}
					}
				}
				else
				{
					drone.NavigateToAndExecuteCommand(door.corridor.gameObject, command, CollisionType.BoundsIntesect);
				}
			}
			else
			{
				SendConsoleResponseMessage("specified door not found: " + text, ConsoleMessageType.Warning);
			}
			break;
		}
		}
	}
}
