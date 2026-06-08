using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InterfaceUpgrade : BaseDroneUpgrade
{
	private const string COMMAND_VALUE = "interface";

	private const float AUDIO_DELAY_SECONDINTERFACE = 0.35f;

	private static List<CommandDefinition> commandList;

	private DungeonTerminal _terminalRoomItem;

	private bool delayInterfaceSecondSound;

	private float timerInterfaceSecondSound = 0.1f;

	public override string CommandValue
	{
		get
		{
			return "interface";
		}
	}

	public InterfaceUpgrade(DroneUpgradeDefinition definition)
		: base(definition)
	{
	}

	protected override void OnUpdate()
	{
		if (base.IsActivated && (!(_terminalRoomItem != null) || ((drone.isMoving || !(drone.CurrentRoom == _terminalRoomItem.roomLocation)) && (!drone.isMoving || !_terminalRoomItem.roomLocation.RoomItemBoundsIntersect(_terminalRoomItem, drone.GetComponent<Collider>().bounds))) || !_terminalRoomItem.Powered))
		{
			CancelAbility();
			SendConsoleResponseMessage("Interface disabled", ConsoleMessageType.Warning);
		}
		if (!delayInterfaceSecondSound)
		{
			return;
		}
		if (GlobalSettings.CommandeeringShip)
		{
			delayInterfaceSecondSound = false;
			return;
		}
		timerInterfaceSecondSound -= Time.deltaTime;
		if (timerInterfaceSecondSound <= 0f)
		{
			delayInterfaceSecondSound = false;
			GameAudio.Play2DSFX(GameAudio.SoundEnum.Schematic_Interface, GameAudio.InterfaceVolume);
		}
	}

	public override List<CommandDefinition> QueryAvailableCommands()
	{
		if (commandList == null)
		{
			commandList = new List<CommandDefinition>(CommandHelper.GetCommands("InterfaceUpgrade"));
		}
		return commandList;
	}

	public override bool ActivateAbility()
	{
		if (!base.ActivateAbility())
		{
			return false;
		}
		_terminalRoomItem = GetTouchingTerminal();
		if (_terminalRoomItem != null)
		{
			_terminalRoomItem.PowerUp(drone);
		}
		TerminalManager.Instance.TerminalAccessed = true;
		if (!GlobalSettings.InterfaceUsedOnce)
		{
			GlobalSettings.InterfaceUsedOnce = true;
			if (!GameSaveFile.Get("INTERFACE_USED", false))
			{
				GameSaveFile.Save("INTERFACE_USED", true);
			}
		}
		if (TerminalManager.ScavengerHunt_CanTriggerWin)
		{
			GlobalSettings.IsGamePaused = true;
			DialogUI.Instance.ShowDialog("Scavenger Hunt Completed", "Congrats!\r\n\r\nYou have successfully completed our Alpha challenge by commandering an old ship to this research outpost, and logging in to a terminal.\r\n\r\nWhen you have completed this outpost, go to the Main Menu to find an unlocked menu item that you can use to let us know you beat the challenge!", ModalWindowType.OK, delegate
			{
				GlobalSettings.IsGamePaused = false;
				TerminalManager.ScavengerHunt_CanTriggerWin = false;
			});
			GameSaveFile.Save("SCAVENGER", true);
			GalaxyProcessor.ObjectiveFile.SaveValue("COMPLETED", true);
		}
		delayInterfaceSecondSound = true;
		timerInterfaceSecondSound = 0.35f;
		if (!GlobalSettings.CommandeeringShip)
		{
			GameAudio.Play2DSFX(GameAudio.SoundEnum.TerminalOn);
		}
		if (SchematicViewCanvas.Instance != null)
		{
			SchematicViewCanvas.Instance.RefreshDrone(drone.DroneNumber);
		}
		if (DroneManager.Instance.currentDronePanel != null && DroneManager.Instance.CurrentDrone == drone)
		{
			DroneManager.Instance.currentDronePanel.UpgradesChanged = true;
		}
		return true;
	}

	public override void CancelAbility()
	{
		if (base.IsActivated && !GlobalSettings.CommandeeringShip)
		{
			delayInterfaceSecondSound = true;
			timerInterfaceSecondSound = 0.35f;
			GameAudio.Play2DSFX(GameAudio.SoundEnum.TerminalOff);
		}
		base.CancelAbility();
		if (_terminalRoomItem != null)
		{
			_terminalRoomItem.PowerDown(drone);
		}
		_terminalRoomItem = null;
		if (SchematicViewCanvas.Instance != null)
		{
			SchematicViewCanvas.Instance.RefreshDrone(drone.DroneNumber);
		}
		if (DroneManager.Instance.currentDronePanel != null && DroneManager.Instance.CurrentDrone == drone)
		{
			DroneManager.Instance.currentDronePanel.UpgradesChanged = true;
		}
	}

	public override void ExecuteCommand(ExecutedCommand command, bool partOfMultiCommand)
	{
		if (!base.PoweredUp)
		{
			return;
		}
		switch (command.Command.CommandName)
		{
		case "interface":
		{
			DungeonTerminal touchingTerminal = GetTouchingTerminal();
			if (touchingTerminal != null)
			{
				command.Handled = true;
				if (!touchingTerminal.IsDead)
				{
					if (command.Arguments.Count > 0 && "list".StartsWith(command.Arguments.First()))
					{
						TerminalManager.Instance.DisplayTerminalCommands(touchingTerminal);
						break;
					}
					if (drone.isMovingForwardBack && !drone.IsBraking)
					{
						drone.StopPriorNavigation();
					}
					if (!touchingTerminal.roomLocation.isPowered)
					{
						SendConsoleResponseMessage("Interface is not powered", ConsoleMessageType.Warning);
					}
					else if (command.Arguments.Count > 0)
					{
						if (command.Arguments[0].ToLower() == "on")
						{
							if (ActivateAbility())
							{
								SendConsoleResponseMessage("Interface activated", ConsoleMessageType.Info);
							}
						}
						else if (command.Arguments[0].ToLower() == "off")
						{
							CancelAbility();
							SendConsoleResponseMessage("Interface deactivated", ConsoleMessageType.Info);
						}
						else
						{
							SendConsoleResponseMessage("Invalid argument: " + command.Arguments[0], ConsoleMessageType.Warning);
						}
					}
					else
					{
						if (!ActivateAbility())
						{
							break;
						}
						SystemMessageManager.ShowSystemMessage("Interface activated", ConsoleMessageType.Info);
						if (GlobalSettings.GameStartedFromGalaxyMap)
						{
							if (ObjectiveManual.IsObjectiveStepActive("cosmic", "stepC") && GlobalSettings.GameState.ThePlayer.MyShip.Age > 340 && GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Key.name.Contains("Research"))
							{
								LogManager.LogDataFile.SaveValue("cosmic", "stepC", 3);
								LogManager.LogDataFile.SaveValue("cosmic", "stepD", 3);
								SystemMessageManager.ShowSystemMessage("///[JIL]: orbital scan executing, archiving results", ConsoleMessageType.JIL_Good);
							}
							if (ObjectiveManual.IsObjectiveStepActive("war", "stepA") && GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Key.name.ToLower() == "military")
							{
								ObjectiveManual.SetObjectiveStepComplete("war", "stepA");
								ObjectiveManual.MarkCompleted("war", "stepB");
								SystemMessageManager.ShowSystemMessage("Uploading data to mothership...", ConsoleMessageType.Benefit);
							}
							if (ObjectiveManual.IsObjectiveStepActive("war", "stepB") && GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Key.dungeonType == DungeonTypeEnum.Outpost)
							{
								ObjectiveManual.SetObjectiveStepComplete("war", "stepB");
								ObjectiveManual.MarkCompleted("war", "stepC");
								SystemMessageManager.ShowSystemMessage("Uploading data to mothership...", ConsoleMessageType.Benefit);
							}
							if (ObjectiveManual.IsObjectiveStepActive("pandemic", "stepD") && GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Key.dungeonType == DungeonTypeEnum.Outpost && GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Key.name.ToLower() == "research" && GlobalSettings.GameState.ThePlayer.MyShip.Age > 365)
							{
								ObjectiveManual.SetObjectiveStepComplete("pandemic", "stepD");
								ObjectiveManual.MarkCompleted("pandemic", "stepE");
								SystemMessageManager.ShowSystemMessage("Uploading data to mothership...", ConsoleMessageType.Benefit);
							}
						}
					}
				}
				else
				{
					SendConsoleResponseMessage("Interface is Broken", ConsoleMessageType.Warning);
				}
				break;
			}
			command.Handled = true;
			if (drone.CurrentRoom != null && drone.CurrentRoom.roomItems.Any((RoomItem x) => x is DungeonTerminal && x.HasBeenSeen()))
			{
				IEnumerable<RoomItem> source = drone.CurrentRoom.roomItems.Where((RoomItem x) => x is DungeonTerminal && x.HasBeenSeen());
				source = source.OrderBy((RoomItem x) => Vector3.Distance(drone.Position, x.transform.position));
				RoomItem roomItem = source.First();
				drone.NavigateToAndExecuteCommand(roomItem, command, CollisionType.BoundsIntesect);
			}
			else
			{
				SendConsoleResponseMessage("No terminals nearby", ConsoleMessageType.Info);
			}
			break;
		}
		}
	}

	private DungeonTerminal GetTouchingTerminal()
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
				if (roomItem2 is DungeonTerminal)
				{
					roomItem = roomItem2;
					break;
				}
			}
		}
		return roomItem as DungeonTerminal;
	}
}
