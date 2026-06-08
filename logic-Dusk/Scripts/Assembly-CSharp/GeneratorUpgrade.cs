using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GeneratorUpgrade : BaseDroneUpgrade
{
	private const string COMMAND_VALUE = "generator";

	private static List<CommandDefinition> commandList;

	private DungeonPowerInlet _powerInletRoomItem;

	public override string CommandValue
	{
		get
		{
			return "generator";
		}
	}

	public override float UpgradeBreakFactor
	{
		get
		{
			return 0.25f;
		}
	}

	public GeneratorUpgrade(DroneUpgradeDefinition definition)
		: base(definition)
	{
	}

	protected override void OnUpdate()
	{
		if (base.IsActivated && (!(_powerInletRoomItem != null) || ((drone.isMoving || !(drone.CurrentRoom == _powerInletRoomItem.roomLocation)) && (!drone.isMoving || !_powerInletRoomItem.GetComponent<Collider>().bounds.Intersects(drone.GetComponent<Collider>().bounds)))))
		{
			CancelAbility();
			SendConsoleResponseMessage("Generator deactivated", ConsoleMessageType.Warning);
		}
	}

	public void SwitchToRemoteSounds()
	{
		if (_powerInletRoomItem != null)
		{
			_powerInletRoomItem.SwitchToRemoteSounds();
		}
	}

	public void SwitchToSchematicSounds()
	{
		if (_powerInletRoomItem != null)
		{
			_powerInletRoomItem.SwitchToSchematicSounds();
		}
	}

	public void StopRemoteSounds()
	{
	}

	public void PauseSoundsOnMenuOpen()
	{
		if (_powerInletRoomItem != null)
		{
			_powerInletRoomItem.PauseSoundsOnMenuOpen();
		}
	}

	public void ResumeSoundsOnMenuClose()
	{
		if (_powerInletRoomItem != null)
		{
			_powerInletRoomItem.ResumeSoundsOnMenuClose();
		}
	}

	public override bool ActivateAbility()
	{
		if (!base.ActivateAbility())
		{
			return false;
		}
		if (_powerInletRoomItem != null)
		{
			_powerInletRoomItem.PowerUp(drone);
		}
		return true;
	}

	public override void CancelAbility()
	{
		base.CancelAbility();
		if (_powerInletRoomItem != null)
		{
			_powerInletRoomItem.PowerDown(drone);
		}
		_powerInletRoomItem = null;
	}

	public override List<CommandDefinition> QueryAvailableCommands()
	{
		if (commandList == null)
		{
			commandList = new List<CommandDefinition>(CommandHelper.GetCommands("GeneratorUpgrade"));
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
		case "generator":
		{
			DungeonPowerInlet touchingGenerator = GetTouchingGenerator();
			if (touchingGenerator != null)
			{
				command.Handled = true;
				drone.StopPriorNavigation();
				if (!touchingGenerator.IsDead)
				{
					if (!touchingGenerator.IsStunned)
					{
						if (command.Arguments.Count > 0 && (command.Arguments.Count > 1 || (command.Arguments[0].ToLower() != "all" && command.Arguments.Count > 0)))
						{
							if (command.Arguments.Last().ToLower() == "on")
							{
								if (ActivateAbility())
								{
									SendPowerOnMessage();
								}
							}
							else if (command.Arguments.Last().ToLower() == "off")
							{
								CancelAbility();
								SendConsoleResponseMessage("Generator deactivated", ConsoleMessageType.Info);
							}
							else
							{
								SendConsoleResponseMessage("Invalid argument: " + command.Arguments.Last(), ConsoleMessageType.Warning);
							}
						}
						else if (touchingGenerator.Powered)
						{
							_powerInletRoomItem = touchingGenerator;
							CancelAbility();
							SendConsoleResponseMessage("Generator deactivated", ConsoleMessageType.Info);
						}
						else
						{
							_powerInletRoomItem = touchingGenerator;
							if (!ActivateAbility())
							{
								_powerInletRoomItem = null;
							}
							else
							{
								SendPowerOnMessage();
							}
						}
					}
					else
					{
						SendConsoleResponseMessage("Generator is not responding", ConsoleMessageType.Warning);
					}
				}
				else
				{
					SendConsoleResponseMessage("Generator is non-functional", ConsoleMessageType.Warning);
				}
				break;
			}
			command.Handled = true;
			if (drone.CurrentRoom != null && drone.CurrentRoom.roomItems.Any((RoomItem x) => x is DungeonPowerInlet && x.HasBeenSeen()))
			{
				IEnumerable<RoomItem> source = drone.CurrentRoom.roomItems.Where((RoomItem x) => x is DungeonPowerInlet && x.HasBeenSeen());
				source = source.OrderBy((RoomItem x) => Vector3.Distance(drone.Position, x.transform.position));
				RoomItem roomItem = source.First();
				if (command.Arguments.Count > 0 && command.Arguments[0] == "all")
				{
					command.Arguments.RemoveAt(0);
				}
				drone.NavigateToAndExecuteCommand(roomItem, command, CollisionType.BoundsIntesect);
			}
			else
			{
				SendConsoleResponseMessage("No power inlets nearby", ConsoleMessageType.Info);
			}
			break;
		}
		}
	}

	private void SendPowerOnMessage()
	{
		SendConsoleResponseMessage("Generator activated\nView newly powered areas in schematic view", ConsoleMessageType.Info);
	}

	private DungeonPowerInlet GetTouchingGenerator()
	{
		RoomItem roomItem = null;
		List<RoomItem> itemsContainedIn = new List<RoomItem>();
		List<RoomItem> list = new List<RoomItem>();
		if (drone.CurrentRoom != null && drone.CurrentRoom.RoomItemsBoundsHit(drone.GetComponent<Collider>().bounds, list, itemsContainedIn))
		{
			int count = list.Count;
			for (int i = 0; i < count; i++)
			{
				RoomItem roomItem2 = list[i];
				if (roomItem2 is DungeonPowerInlet)
				{
					roomItem = roomItem2;
					break;
				}
			}
		}
		return roomItem as DungeonPowerInlet;
	}
}
