using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TutorialManagerClass
{
	private const float STEP_TRANSITION_TIME_END = 0.5f;

	private const float STEP_TRANSITION_TIME_START = 0.5f;

	private const float JUMP_AHEAD_CHECK_TIME = 1f;

	private const string _allDoneText = "Last thing: You can use ‘help’ to browse commands, and ‘help <command>’ for help on a particular command. \n\nType ‘exit’ to return to your mothership and end the tutorial.";

	public static TutorialManagerClass Instance;

	private bool RunTutorialScript = true;

	private bool _firstUpdate = true;

	private LootItem exampleLootItem;

	private FuelAccess tutorialFuelAccess;

	private Drone exampleDroneObject;

	private List<string> _initialOpenDoorLabels;

	private TutorialStep _currentStep;

	private List<TutorialStep> _tutorialSteps;

	private List<TutorialStep> _endingSteps;

	private float _timerBeforeStepStart;

	private float _timerBeforeStepEnd;

	private bool _swapWindowShownAtLeastOnce;

	private bool _tutorialIsDone;

	private float _jumpAheadStepTimer = 1f;

	private bool _warnedAboutBadSwap;

	private bool _wasPowered;

	private bool _wasWarnedForPower;

	public TutorialManagerClass()
	{
		Instance = this;
		GlobalSettings.IsTutorial = true;
		_initialOpenDoorLabels = new List<string>();
		_initialOpenDoorLabels.Add("D4");
		_endingSteps = new List<TutorialStep>();
		CreateTutorialSteps();
	}

	public void Update()
	{
		if (_firstUpdate)
		{
			_firstUpdate = false;
			InitTutorialScene();
			if (RunTutorialScript)
			{
				SwitchToNextStep(false);
			}
		}
		GlobalCheckForFailConditions();
		if (_timerBeforeStepEnd > 0f)
		{
			_timerBeforeStepEnd -= Time.deltaTime;
			if (_timerBeforeStepEnd <= 0f)
			{
				_endingSteps.ForEach(delegate(TutorialStep x)
				{
					x.EndStep();
				});
				_endingSteps.Clear();
				SwitchToNextStep();
			}
			return;
		}
		if (_timerBeforeStepStart > 0f)
		{
			_timerBeforeStepStart -= Time.deltaTime;
			if (_timerBeforeStepStart <= 0f)
			{
				_currentStep.StartStep();
			}
			return;
		}
		_jumpAheadStepTimer -= Time.deltaTime;
		if (_jumpAheadStepTimer <= 0f)
		{
			_jumpAheadStepTimer = 1f;
			CheckToSeeIfWeCanJumpAheadSteps();
		}
		if (_currentStep != null)
		{
			_currentStep.Update();
			if (_currentStep != null && _currentStep.StepIsDone)
			{
				EndCurrentStepDelayed();
			}
		}
	}

	private void CheckToSeeIfWeCanJumpAheadSteps()
	{
		int num = -1;
		for (int num2 = _tutorialSteps.Count - 1; num2 >= 0; num2--)
		{
			TutorialStep tutorialStep = _tutorialSteps[num2];
			if (tutorialStep.AllowJumpAhead && tutorialStep.IsStepIsDone())
			{
				num = num2;
				break;
			}
		}
		if (num >= 0)
		{
			_currentStep.EndStep();
			for (int i = 0; i <= num; i++)
			{
				_tutorialSteps.RemoveAt(0);
			}
			SwitchToNextStep();
		}
	}

	private void InitTutorialScene()
	{
		PresetManager.LoadPreset("Tutorial", DroneManager.Instance.IDronesList);
		HookupFixedSceneLootItemsToGame();
		HookupPowerInletToRoom();
		HookupFixedSceneDroneObjectToGame();
		Object[] array = Object.FindObjectsOfType(typeof(FuelAccess));
		tutorialFuelAccess = (FuelAccess)array[0];
		OpenInitialDoors();
	}

	private void GenerateTutorialEnemies()
	{
		GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.ClearInfestationType();
		GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.AddInfestationType(ShipInfestationType.Swarm);
		foreach (Waypoint waypoint in NavigationHelper.GetWaypoints(WaypointTypeEnum.Spawn))
		{
			EnemyManager.Instance.CreateSwarm(waypoint);
		}
	}

	private void PlaceTutorialLoot()
	{
		Object[] array = Object.FindObjectsOfType(typeof(LootItem));
		exampleLootItem = (LootItem)array[0];
		exampleLootItem.transform.position = exampleLootItem.roomLocation.transform.position + new Vector3(5f, 0f, exampleLootItem.transform.position.z);
		Vector3 position = exampleLootItem.transform.position;
		exampleLootItem.OverrideInfoLabelPos(new Vector3(position.x + 3.9f, position.y + 2.2f, position.z));
	}

	private void HookupFixedSceneLootItemsToGame()
	{
		Object[] array = Object.FindObjectsOfType(typeof(LootItem));
		DungeonManager.Instance.OverrideLootItems(array);
		exampleLootItem = (LootItem)array[0];
	}

	private void HookupFixedSceneDroneObjectToGame()
	{
		Object[] array = Object.FindObjectsOfType(typeof(Drone));
		exampleDroneObject = (Drone)array[0];
		List<IDrone> lootableIDrones = new List<IDrone>();
		DroneManager.Instance.LootableDronesList.ForEach(delegate(Drone x)
		{
			lootableIDrones.Add(x);
		});
		PresetManager.LoadPreset("Tutorial_DeadDrones", lootableIDrones);
	}

	private void HookupPowerInletToRoom()
	{
		Room room = DungeonManager.Instance.rooms.FirstOrDefault((Room x) => x.roomItems.Any((RoomItem y) => y is DungeonPowerInlet));
		RoomItem roomItem = room.roomItems.First((RoomItem x) => x is DungeonPowerInlet);
		roomItem.roomLocation = room;
	}

	private void PlaceFixedDeadDrones()
	{
		int num = 5;
		List<Waypoint> waypoints = NavigationHelper.GetWaypoints(WaypointTypeEnum.FixedDeadDrone);
		foreach (Waypoint item in waypoints)
		{
			Vector3 position = new Vector3(item.transform.position.x, item.transform.position.y, 0f);
			DroneManager.Instance.PlaceLootableDrone(num++, item.Room, position);
		}
		List<IDrone> lootableIDrones = new List<IDrone>();
		DroneManager.Instance.LootableDronesList.ForEach(delegate(Drone x)
		{
			lootableIDrones.Add(x);
		});
		PresetManager.LoadPreset("Tutorial_DeadDrones", lootableIDrones);
	}

	private void OpenInitialDoors()
	{
		string doorLabel;
		foreach (string initialOpenDoorLabel in _initialOpenDoorLabels)
		{
			doorLabel = initialOpenDoorLabel;
			Door door = DungeonManager.Instance.doors.FirstOrDefault((Door x) => x.LabelSimple.ToLower() == doorLabel.ToLower());
			if (door != null)
			{
				door.open();
			}
		}
	}

	private void EndCurrentStepDelayed()
	{
		_endingSteps.Add(_currentStep);
		_timerBeforeStepEnd = 0.5f;
	}

	private void EndCurrentStepDelayed(float delayTime)
	{
		_endingSteps.Add(_currentStep);
		_timerBeforeStepEnd = delayTime;
	}

	private void SwitchToNextStep()
	{
		SwitchToNextStep(true);
	}

	private void SwitchToNextStep(bool delayed)
	{
		if (_tutorialSteps.Count > 0)
		{
			_currentStep = _tutorialSteps[0];
			_tutorialSteps.RemoveAt(0);
			if (delayed)
			{
				_timerBeforeStepStart = 0.5f;
			}
			else
			{
				_currentStep.StartStep();
			}
		}
		else
		{
			_currentStep = null;
		}
	}

	private void CreateTutorialSteps()
	{
		_tutorialSteps = new List<TutorialStep>();
		Vector2 vector = new Vector2(150f, Screen.height - 400);
		Vector2 textPosition = new Vector2(Screen.width / 2 - 150, 20f);
		Color green = Color.green;
		Color oRANGE = GlobalSettings.Constants.ORANGE;
		Vector3 drone1Position = Vector3.zero;
		Vector3 drone2Position = Vector3.zero;
		_tutorialSteps.Add(new TutorialStep("Welcome to Drone Operator Training \n\nUse arrow keys to pilot drone 1", textPosition, green, delegate
		{
			Drone drone = DroneManager.Instance.dronesList.First((Drone x) => x.DroneNumber == 1);
			if (drone1Position == Vector3.zero)
			{
				drone1Position = drone.Position;
			}
			else if (drone1Position != drone.Position)
			{
				return true;
			}
			Drone drone2 = DroneManager.Instance.dronesList.First((Drone x) => x.DroneNumber == 2);
			if (drone2Position == Vector3.zero)
			{
				drone2Position = drone2.Position;
			}
			else if (drone2Position != drone2.Position)
			{
				return true;
			}
			return false;
		}));
		_tutorialSteps.Add(new TutorialStep("Press 2 to switch to drone 2", textPosition, green, () => DroneManager.Instance.CurrentDrone != null && DroneManager.Instance.CurrentDrone.DroneNumber == 2));
		_tutorialSteps.Add(new TutorialStep("Press SPACE to switch to a Schematic View of the ships", textPosition, green, () => GlobalSettings.cameraMode == CameraMode.Schematic));
		_tutorialSteps.Add(new TutorialStep("Currently the derelict ship is unexplored, so you only see your ship's docking bay.\n\nType 'open a1' (or just 'a1') then ENTER to open Airlock One", textPosition, green, delegate
		{
			Door door = DungeonManager.Instance.doors.First((Door x) => x.LabelSimple.ToLower() == "a1");
			return door.state == DoorState.Open;
		}, true));
		_tutorialSteps.Add(new TutorialStep("Now press SPACE to switch back to drone view.", textPosition, green, () => GlobalSettings.cameraMode == CameraMode.Drone));
		_tutorialSteps.Add(new TutorialStep("Pilot the drone into the derelict ship (through airlock a1)", textPosition, green, () => DroneManager.Instance.dronesList.Any((Drone x) => x.CurrentRoom != null && x.CurrentRoom.Label.ToLower() == "r2"), true));
		_tutorialSteps.Add(new TutorialStep("You found a POWER INLET. \n\nNotice how Drone 2 has a GENERATOR in it's list of Upgrades (upper left corner of screen). \n\nType 'generator'", textPosition, green, () => DroneManager.Instance.dronesList.Any((Drone x) => x.Upgrades.Any((BaseDroneUpgrade u) => u != null && u.Definition.Type == DroneUpgradeType.Generator && u.IsActivated)), true));
		_tutorialSteps.Add(new TutorialStep("Now you’ve powered an area of the derelict ship. \n\nSwitch to the Schematic View with SPACE to see what rooms are powered.", textPosition, green, () => ensurePowerConnected() && GlobalSettings.cameraMode == CameraMode.Schematic));
		_tutorialSteps.Add(new TutorialStep("You can now operate the newly powered doors, however never open doors to unknown rooms. \n\nNotice d4 is open... \n\nType 'navigate 1 r3' to send Drone 1 to Room 3 ", textPosition, green, delegate
		{
			Drone drone = DroneManager.Instance.GetDrone(1);
			return drone.CurrentRoom != null && drone.CurrentRoom.Label.ToLower() == "r3";
		}, delegate
		{
			ensurePowerConnected(true);
		}, true));
		_tutorialSteps.Add(new TutorialStep("Press 1 to switch to Drone 1's view and search Room 3", textPosition, green, delegate
		{
			Drone drone = DroneManager.Instance.GetDrone(1);
			return (drone.CurrentRoom != null && drone.CurrentRoom == tutorialFuelAccess.roomLocation && Vector3.Distance(tutorialFuelAccess.transform.position, drone.Position) < 3f) ? true : false;
		}, delegate
		{
			ensurePowerConnected(true);
		}));
		_tutorialSteps.Add(new TutorialStep("You found a FUEL ACCESS port. \n\nDrone 1 has a GATHER upgrade.\n\nType 'gather' (or 'ga' then SPACE, TAB, or ENTER to auto complete) to gather PROPULSION and JUMP fuel. ", textPosition, green, () => DroneManager.Instance.dronesList.Any((Drone x) => x.Upgrades.Any((BaseDroneUpgrade u) => u != null && u.Definition.Type == DroneUpgradeType.Gatherer && ((GathererUpgrade)u).jumpFuel > 0)), delegate
		{
			ensurePowerConnected(true);
		}, true));
		_tutorialSteps.Add(new TutorialStep("Let’s see if Room 4 is safe. Drone 1 has a MOTION SENSOR upgrade. \n\nSwitch to the Schematic View and type ‘motion’ then ENTER", textPosition, green, delegate
		{
			bool result = false;
			if (!DroneManager.Instance.dronesList.Any((Drone x) => x.Upgrades.Any((BaseDroneUpgrade u) => u != null && u.Definition.Type == DroneUpgradeType.Gatherer && ((GathererUpgrade)u).jumpFuel > 0)))
			{
				return false;
			}
			foreach (Drone drones in DroneManager.Instance.dronesList)
			{
				if (drones.CurrentRoom != null && (drones.CurrentRoom.Label.ToLower() == "r2" || drones.CurrentRoom.Label.ToLower() == "r3") && drones.Upgrades.Any((BaseDroneUpgrade u) => u != null && u.Definition.Type == DroneUpgradeType.AreaSensor && u.IsActivated))
				{
					result = true;
					break;
				}
			}
			return result;
		}, delegate
		{
			ensurePowerConnected(true);
		}, true));
		_tutorialSteps.Add(new TutorialStep("The RED indicator in Room 4, means badness is in there.\n\nLet's see if we can herd them out of Room 4. \n\nFirst, Pilot Drone 1 back to Room 2", textPosition, green, delegate
		{
			Drone drone = DroneManager.Instance.GetDrone(1);
			return drone.CurrentRoom != null && drone.CurrentRoom.Label.ToLower() == "r2";
		}, delegate
		{
			ensurePowerConnected(true);
		}));
		_tutorialSteps.Add(new TutorialStep("Now let's try herding the enemy from Room 4 to Room 3. \n\nFrom the Schematic View use the motion sensor again ('motion').", textPosition, green, delegate
		{
			Drone drone = DroneManager.Instance.GetDrone(1);
			return (DroneManager.Instance.dronesList.Any((Drone x) => x.Upgrades.Any((BaseDroneUpgrade u) => u != null && u.Definition.Type == DroneUpgradeType.AreaSensor && u.IsActivated)) && drone.CurrentRoom != null && drone.CurrentRoom.Label.ToLower() == "r2" && GlobalSettings.cameraMode == CameraMode.Schematic) ? true : false;
		}, delegate
		{
			ensurePowerConnected(true);
		}));
		_tutorialSteps.Add(new TutorialStep("Type 'd4' to close Door 4, then 'd5' to open Door 5. \n\nClose Door 5 when the enemy wanders into Room 3.", textPosition, green, delegate
		{
			if (!DroneManager.Instance.dronesList.Any((Drone x) => x.Upgrades.Any((BaseDroneUpgrade u) => u != null && u.Definition.Type == DroneUpgradeType.Gatherer && ((GathererUpgrade)u).jumpFuel > 0)))
			{
				return false;
			}
			Room room = DungeonManager.Instance.rooms.First((Room x) => x.Label.ToLower() == "r3");
			bool flag = false;
			foreach (BaseEnemy enemy in EnemyManager.Instance.Enemies)
			{
				if (enemy.CurrentRoom == room && !enemy.IsDead)
				{
					flag = true;
					break;
				}
			}
			Door door = DungeonManager.Instance.doors.First((Door x) => x.LabelSimple.ToLower() == "d4");
			Door door2 = DungeonManager.Instance.doors.First((Door x) => x.LabelSimple.ToLower() == "d5");
			return (door.state == DoorState.Closed && door2.state == DoorState.Closed && flag) ? true : false;
		}, delegate
		{
			ensurePowerConnected(true);
		}, true));
		_tutorialSteps.Add(new TutorialStep("Now it’s safe to open Door 2 and explore Room 4", textPosition, green, delegate
		{
			foreach (Drone drones2 in DroneManager.Instance.dronesList)
			{
				if (drones2.CurrentRoom != null && drones2.CurrentRoom.Label.ToLower() == "r4")
				{
					return true;
				}
			}
			return false;
		}, delegate
		{
			ensurePowerConnected(true);
		}));
		_tutorialSteps.Add(new TutorialStep("Use the motion sensor to see if the room on the other side of Door 3 is safe.", textPosition, green, delegate
		{
			if (!DroneManager.Instance.dronesList.Any((Drone x) => x.Upgrades.Any((BaseDroneUpgrade u) => u != null && u.Definition.Type == DroneUpgradeType.Gatherer && ((GathererUpgrade)u).jumpFuel > 0)))
			{
				return false;
			}
			Drone drone = DroneManager.Instance.GetDrone(1);
			return (drone.CurrentRoom != null && drone.CurrentRoom.Label.ToLower() == "r4" && drone.Upgrades.Any((BaseDroneUpgrade u) => u != null && u.Definition.Type == DroneUpgradeType.AreaSensor && u.IsActivated)) ? true : false;
		}, delegate
		{
			ensurePowerConnected(true);
		}, true));
		_tutorialSteps.Add(new TutorialStep("Now it’s safe to open Door 3 and explore the room on the other side", textPosition, green, delegate
		{
			if (!DroneManager.Instance.dronesList.Any((Drone x) => x.Upgrades.Any((BaseDroneUpgrade u) => u != null && u.Definition.Type == DroneUpgradeType.Gatherer && ((GathererUpgrade)u).jumpFuel > 0)))
			{
				return false;
			}
			foreach (Drone drones3 in DroneManager.Instance.dronesList)
			{
				if (drones3.CurrentRoom != null && drones3.CurrentRoom.Label.ToLower() == "r5" && Vector3.Distance(exampleDroneObject.transform.position, drones3.Position) < 4f)
				{
					return true;
				}
			}
			return false;
		}, delegate
		{
			ensurePowerConnected(true);
		}, true));
		_tutorialSteps.Add(new TutorialStep("A destroyed drone! Drive up to it and type the command ‘swap’ to loot its upgrades. \n\nPress [ESC] to close swap window when you’re done.", textPosition, green, delegate
		{
			if (!_swapWindowShownAtLeastOnce && GameplayManager.Instance.WindowState == GameWindowStates.ShowUpgradeSwap)
			{
				_swapWindowShownAtLeastOnce = true;
			}
			if (SwapHappened())
			{
				foreach (Drone drones4 in DroneManager.Instance.dronesList)
				{
					Debug.Log("Drone upgrade count: " + drones4.NumberOfUpgradesInstalled());
				}
				return true;
			}
			return false;
		}, delegate
		{
			ensurePowerConnected(true);
			if (!_warnedAboutBadSwap && SwapFailed())
			{
				_warnedAboutBadSwap = true;
				DialogUI.Instance.ShowDialog("Tip!", "WARNING: you closed the swap window without looting the upgrade off of the destroyed drone.", ModalWindowType.OK, delegate
				{
					DungeonManager.Instance.DisableAllInputForAMoment();
				});
			}
		}));
		_tutorialSteps.Add(new TutorialStep("Switch back to Schematic View. \nLooks like there’s no more ship to explore. \n\nTo leave, let's try a single 'navigate' command to simultaneously send both drones 1 & 2 back to the docking bay (r1). \n\nType 'help navigate' to learn how", textPosition, green, delegate
		{
			int num = 0;
			foreach (Drone drones5 in DroneManager.Instance.dronesList)
			{
				if (!drones5.IsDead)
				{
					num += drones5.GetLootCount();
					num += drones5.GetJumpFuelCount();
					num += drones5.GetPropulsionFuelCount();
				}
			}
			return (BothDronesInDroneBay() && num > 0 && SwapHappened()) ? true : false;
		}, true));
		_tutorialSteps.Add(new TutorialStep("Last thing: You can use ‘help’ to browse commands, and ‘help <command>’ for help on a particular command. \n\nType ‘exit’ to return to your mothership and end the tutorial.", textPosition, green, delegate
		{
			if (!_tutorialIsDone)
			{
				_tutorialIsDone = true;
				GameSaveFile.Save("WS_NEVRVWD_TUT", true);
			}
			return false;
		}));
	}

	private bool ensurePowerConnected()
	{
		return ensurePowerConnected(false);
	}

	private bool ensurePowerConnected(bool showEvenIfNotAlreadyPowered)
	{
		bool flag = DroneManager.Instance.dronesList.Any((Drone x) => x.Upgrades.Any((BaseDroneUpgrade u) => u != null && u.Definition.Type == DroneUpgradeType.Generator && u.IsActivated));
		if (!flag && !_wasWarnedForPower && (_wasPowered || showEvenIfNotAlreadyPowered))
		{
			string arg = ((!(DroneManager.Instance.CurrentDrone != null) || DroneManager.Instance.CurrentDrone.DroneNumber != 2) ? "generator 2" : "generator");
			string message = ((!_wasPowered) ? string.Format("You might need power to continue, consider piloting drone 2 into Room 2 and typing '{0}'.", arg) : string.Format("Your generator has disconnected from the power inlet because the drone is too far away. Type '{0}' to connect to the power inlet again.", arg));
			_wasWarnedForPower = true;
			_wasPowered = false;
			DialogUI.Instance.ShowDialog("Tip!", message, ModalWindowType.OK, delegate
			{
				DungeonManager.Instance.DisableAllInputForAMoment();
			});
		}
		else if (flag)
		{
			_wasPowered = true;
			_wasWarnedForPower = false;
		}
		return flag;
	}

	private bool BothDronesInDroneBay()
	{
		Drone drone = DroneManager.Instance.GetDrone(1);
		Drone drone2 = DroneManager.Instance.GetDrone(2);
		if (drone.CurrentRoom != null && drone.CurrentRoom.Label.ToLower() == "r1" && drone2.CurrentRoom != null && drone2.CurrentRoom.Label.ToLower() == "r1")
		{
			return true;
		}
		return false;
	}

	private bool SwapHappened()
	{
		return DroneManager.Instance.LootableDronesList.All((Drone x) => x.NumberOfUpgradesInstalled() == 0) && GameplayManager.Instance.WindowState != GameWindowStates.ShowUpgradeSwap;
	}

	private bool SwapFailed()
	{
		if (_swapWindowShownAtLeastOnce && GameplayManager.Instance.WindowState != GameWindowStates.ShowUpgradeSwap && !SwapHappened())
		{
			return true;
		}
		return false;
	}

	private void GlobalCheckForFailConditions()
	{
		if (_tutorialIsDone)
		{
			return;
		}
		Drone drone = DroneManager.Instance.GetDrone(1);
		Drone drone2 = DroneManager.Instance.GetDrone(2);
		if (drone.IsDead && drone2.IsDead)
		{
			_tutorialIsDone = true;
			_tutorialSteps.Clear();
			if (_currentStep != null)
			{
				_currentStep.EndStep();
				_currentStep = null;
			}
			HintManager.CancelAllHints();
			DialogUI.Instance.ShowDialog("Oops!", "All your drones died.\r\n\r\nTraining has ended prematurely...", ModalWindowType.OK, delegate
			{
				GameplayManager.Instance.ShowPauseMenuPostDeath(true);
				SystemMessageManager.ClearAllMessages();
			});
		}
	}
}
