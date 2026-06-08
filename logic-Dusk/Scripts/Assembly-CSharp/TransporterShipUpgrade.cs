using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TransporterShipUpgrade : BaseShipUpgrade
{
	public enum ReceiverStrengthEnum
	{
		Strong = 0,
		Weak = 1,
		None = 2
	}

	public class ReceiverData
	{
		public TransporterReceiver receiver;

		public ReceiverStrengthEnum CurrentStrength;

		public float delayUntilEventChange;

		public ReceiverData(TransporterReceiver receiver, float delayUntilEventChange)
		{
			this.receiver = receiver;
			CurrentStrength = ReceiverStrengthEnum.None;
			this.delayUntilEventChange = delayUntilEventChange;
		}
	}

	private const string COMMAND_VALUE = "transport";

	private static List<CommandDefinition> commandList;

	private List<ReceiverData> receiverDataList = new List<ReceiverData>();

	private List<Drone> delayedTransportDroneList = new List<Drone>();

	private Room delayedTransportDestinationRoom;

	private DungeonManager dungeonManager;

	private DroneManager droneManager;

	private bool isProcessingDelayedJump;

	private float delayBeforeJump;

	private float strengthErraticFactor = 1f;

	private bool isDeadAir;

	private float timerForceReceiverOnline;

	private int allowedReceiverUses;

	private bool canJump = true;

	private float timeTilNextJump;

	private bool failSafe;

	private float timerLastAttempt;

	public bool CanTransport { get; private set; }

	public override ShipUpgradeType UpgradeType
	{
		get
		{
			return ShipUpgradeType.Transporter;
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
			return "Transporter";
		}
	}

	public override string CommandValue
	{
		get
		{
			return "transport";
		}
	}

	public TransporterShipUpgrade(int id)
		: base(id)
	{
	}

	protected override void OnInitialize()
	{
		dungeonManager = DungeonManager.Instance;
		droneManager = DroneManager.Instance;
	}

	public void Reset()
	{
		CanTransport = true;
		allowedReceiverUses = Random.Range(1 + DungeonManager.Instance.rooms.Count() / 4, 1 + DungeonManager.Instance.rooms.Count() / 2 + 1);
		float transporterValue = GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.CalculatedDifficultyValues.TransporterValue;
		if (transporterValue <= 0.3333f)
		{
			strengthErraticFactor = 0.5f;
		}
		else if (transporterValue <= 0.6666f)
		{
			strengthErraticFactor = 0.75f;
		}
		else
		{
			strengthErraticFactor = 0.9f;
		}
		receiverDataList.Clear();
		Object[] array = Object.FindObjectsOfType(typeof(TransporterReceiver));
		Object[] array2 = array;
		foreach (Object obj in array2)
		{
			receiverDataList.Add(new ReceiverData((TransporterReceiver)obj, Random.Range(240f, 900f) * strengthErraticFactor));
		}
		foreach (ReceiverData receiverData in receiverDataList)
		{
			receiverData.receiver.Reset();
		}
		isDeadAir = false;
		timerForceReceiverOnline = 0f;
	}

	public void BringReceiverOnline(TransporterReceiver receiver)
	{
		ReceiverData receiverData = InitalizeReceiver(receiver);
		if (receiverData != null)
		{
			receiverData.receiver.BringOnline();
		}
	}

	public ReceiverData InitalizeReceiver(TransporterReceiver receiver)
	{
		ReceiverData receiverData = receiverDataList.FirstOrDefault((ReceiverData x) => x.receiver == receiver);
		if (receiverData != null)
		{
			receiverData.delayUntilEventChange = Random.Range(240f, 600f) * strengthErraticFactor;
			receiverData.CurrentStrength = ReceiverStrengthEnum.Strong;
			receiverData.receiver.roomLocation.UpdateTransporterReceiver(ReceiverStrengthEnum.Strong);
		}
		return receiverData;
	}

	protected override void OnUpdate()
	{
		if (isProcessingDelayedJump)
		{
			delayBeforeJump -= Time.deltaTime;
			if (delayBeforeJump <= 0f)
			{
				foreach (Drone delayedTransportDrone in delayedTransportDroneList)
				{
					JumpDroneToRoom(delayedTransportDrone, delayedTransportDestinationRoom);
				}
				isProcessingDelayedJump = false;
				delayedTransportDestinationRoom = null;
				delayedTransportDroneList.Clear();
			}
		}
		if (GlobalSettings.MissionStarted && !GlobalSettings.IsGamePaused && CanTransport)
		{
			int count = receiverDataList.Count;
			for (int i = 0; i < count; i++)
			{
				ReceiverData receiverData = receiverDataList[i];
				receiverData.delayUntilEventChange -= Time.deltaTime;
				if (!receiverData.receiver.IsOffline)
				{
					switch (receiverData.CurrentStrength)
					{
					case ReceiverStrengthEnum.Strong:
						if (receiverData.delayUntilEventChange <= 0f)
						{
							receiverData.delayUntilEventChange = Random.Range(120f, 300f) * strengthErraticFactor;
							receiverData.CurrentStrength = ReceiverStrengthEnum.Weak;
							receiverData.receiver.SetDamaged();
							receiverData.receiver.roomLocation.UpdateTransporterReceiver(ReceiverStrengthEnum.Weak);
							SystemMessageManager.ShowSystemMessage("Transporter receiver signal in room " + receiverData.receiver.roomLocation.Label + " is weak.", ConsoleMessageType.Warning);
						}
						break;
					case ReceiverStrengthEnum.Weak:
						if (receiverData.delayUntilEventChange <= 0f)
						{
							if (Random.Range(0, 4) == 0)
							{
								receiverData.CurrentStrength = ReceiverStrengthEnum.Strong;
								receiverData.delayUntilEventChange = Random.Range(240f, 600f) * strengthErraticFactor;
								receiverData.receiver.SetActive();
								receiverData.receiver.roomLocation.UpdateTransporterReceiver(ReceiverStrengthEnum.Strong);
								SystemMessageManager.ShowSystemMessage("Transporter receiver signal in room " + receiverData.receiver.roomLocation.Label + " is strong.", ConsoleMessageType.Notification);
							}
							else
							{
								receiverData.CurrentStrength = ReceiverStrengthEnum.None;
								receiverData.delayUntilEventChange = Random.Range(120f, 360f);
								receiverData.receiver.IsResponding = false;
								ReceiverWentOffline();
								receiverData.receiver.roomLocation.UpdateTransporterReceiver(ReceiverStrengthEnum.None);
								SystemMessageManager.ShowSystemMessage("Lost transporter receiver signal in room " + receiverData.receiver.roomLocation.Label + ".", ConsoleMessageType.Warning);
							}
						}
						break;
					case ReceiverStrengthEnum.None:
						if (receiverData.delayUntilEventChange <= 0f)
						{
							if (Random.Range(0, 4) == 0)
							{
								receiverData.CurrentStrength = ReceiverStrengthEnum.Weak;
								receiverData.delayUntilEventChange = Random.Range(120f, 300f) * strengthErraticFactor;
								receiverData.receiver.SetDamaged();
								receiverData.receiver.roomLocation.UpdateTransporterReceiver(ReceiverStrengthEnum.Weak);
								SystemMessageManager.ShowSystemMessage("Reacquired a weak transporter receiver signal in room " + receiverData.receiver.roomLocation.Label + ".", ConsoleMessageType.Benefit);
								receiverData.receiver.IsResponding = true;
								ReceiverCameOnline();
							}
							else
							{
								receiverData.CurrentStrength = ReceiverStrengthEnum.None;
								receiverData.receiver.roomLocation.UpdateTransporterReceiver(ReceiverStrengthEnum.None);
								receiverData.delayUntilEventChange = Random.Range(120f, 360f) * strengthErraticFactor;
							}
						}
						break;
					}
				}
				else if (receiverData.delayUntilEventChange <= 0f)
				{
					receiverData.receiver.BringOnline();
					receiverData.receiver.roomLocation.ExternallyMarkAsOnSchematic();
					receiverData.CurrentStrength = ReceiverStrengthEnum.Weak;
					receiverData.receiver.roomLocation.UpdateTransporterReceiver(ReceiverStrengthEnum.Weak);
					receiverData.delayUntilEventChange = Random.Range(120f, 300f) * strengthErraticFactor;
					receiverData.receiver.SetDamaged();
					receiverData.receiver.RefreshIcon();
					SystemMessageManager.ShowSystemMessage("New transporter receiver signal in room " + receiverData.receiver.roomLocation.Label + " detected.", ConsoleMessageType.Notification);
					ReceiverCameOnline();
				}
			}
			if (isDeadAir)
			{
				timerForceReceiverOnline -= Time.deltaTime;
				if (timerForceReceiverOnline <= 0f)
				{
					Debug.Log("******** Forced Receiver Online ********");
					int index = Random.Range(0, receiverDataList.Count);
					ReceiverData receiverData2 = receiverDataList[index];
					receiverData2.CurrentStrength = ReceiverStrengthEnum.Weak;
					receiverData2.receiver.roomLocation.UpdateTransporterReceiver(ReceiverStrengthEnum.Weak);
					receiverData2.delayUntilEventChange = Random.Range(120f, 300f) * strengthErraticFactor;
					receiverData2.receiver.SetDamaged();
					SystemMessageManager.ShowSystemMessage("Reacquired a weak transporter receiver signal in room " + receiverData2.receiver.roomLocation.Label + ".", ConsoleMessageType.Benefit);
					receiverData2.receiver.IsResponding = true;
					ReceiverCameOnline();
				}
			}
		}
		if (!GlobalSettings.IsGamePaused && !canJump)
		{
			timeTilNextJump -= Time.deltaTime;
			if (timeTilNextJump <= 0f)
			{
				timeTilNextJump = 0f;
				canJump = true;
			}
		}
		if (failSafe)
		{
			timerLastAttempt -= Time.deltaTime;
		}
	}

	private void ReceiverCameOnline()
	{
		if (allowedReceiverUses > 0)
		{
			allowedReceiverUses--;
		}
		if (allowedReceiverUses == 0)
		{
			SystemMessageManager.ShowSystemMessage("Final transporter signal acquired. No remaing signals detected.", ConsoleMessageType.Warning);
		}
		else if (allowedReceiverUses > 0 && allowedReceiverUses < 6)
		{
			SystemMessageManager.ShowSystemMessage(string.Format("{0} transporter signals remaining...", allowedReceiverUses), ConsoleMessageType.Warning);
		}
		isDeadAir = false;
	}

	private void ReceiverWentOffline()
	{
		if (allowedReceiverUses <= 0)
		{
			CanTransport = false;
			SystemMessageManager.ShowSystemMessage("No new signals can be acquired.", ConsoleMessageType.Error);
		}
		else if (!isDeadAir && receiverDataList.Where((ReceiverData x) => x.receiver.IsResponding).Count() == 0)
		{
			isDeadAir = true;
			timerForceReceiverOnline = Random.Range(60f, 120f);
		}
	}

	public override List<CommandDefinition> QueryAvailableCommands()
	{
		if (commandList == null)
		{
			commandList = new List<CommandDefinition>(CommandHelper.GetCommands("ShipUpgradeTransporter"));
		}
		return commandList;
	}

	public override void ExecuteCommand(ExecutedCommand command, bool partOfMultiCommand)
	{
		switch (command.Command.CommandName)
		{
		case "transport":
			if ((command.Arguments.Count > 1 && command.Arguments[0].ToLower() == "all") || command.Arguments.Count > 0 || command.DroneNumbers.Count > 1)
			{
				if (!canJump)
				{
					SendConsoleResponseMessage("Transporter is unable to be used - recharging....", ConsoleMessageType.Warning);
					if (!failSafe)
					{
						failSafe = true;
						timerLastAttempt = 2f;
						command.Handled = true;
						break;
					}
					if (timerLastAttempt > 0f)
					{
						command.Handled = true;
						break;
					}
					canJump = false;
					failSafe = false;
					timerLastAttempt = 0f;
				}
				else if (failSafe)
				{
					failSafe = false;
					timerLastAttempt = 0f;
				}
				Room room = null;
				string arg = string.Empty;
				if (command.Arguments.Count > 0)
				{
					arg = command.Arguments.First().ToLower();
					if (command.DroneNumbers.Count == 0 || (arg == "all" && command.DroneNumbers.Count == 1))
					{
						if (arg == "all")
						{
							bool flag = command.DroneNumbers.Count == 1;
							foreach (Drone drones in droneManager.dronesList)
							{
								if (drones != null && !drones.IsDead && (!flag || drones.DroneNumber != command.DroneNumbers[0]))
								{
									if (!flag)
									{
										command.DroneNumbers.Add(drones.DroneNumber);
									}
									else
									{
										command.DroneNumbers.Insert(0, drones.DroneNumber);
									}
								}
							}
						}
						else
						{
							command.DroneNumbers.Add(droneManager.CurrentDrone.DroneNumber);
						}
					}
					if (arg == "all")
					{
						if (command.Arguments.Count > 1)
						{
							arg = command.Arguments[1];
						}
						else
						{
							arg = string.Empty;
						}
					}
					room = ((!(arg.ToLower() == "home") && !(arg == "r1")) ? dungeonManager.rooms.FirstOrDefault((Room x) => x.Label.ToLower() == arg) : dungeonManager.BoardingVessel);
				}
				if (room == null && command.DroneNumbers.Count > 1)
				{
					int num = command.DroneNumbers.Last();
					int count = droneManager.dronesList.Count;
					for (int num2 = count - 1; num2 >= 0; num2--)
					{
						Drone drone = droneManager.dronesList[num2];
						if (drone != null && drone.DroneNumber == num)
						{
							room = drone.CurrentRoom;
							command.DroneNumbers.Remove(num);
							arg = drone.CurrentRoom.Label.ToLower();
							break;
						}
					}
				}
				if (room != null)
				{
					TransporterReceiver receiver = null;
					if (room == dungeonManager.BoardingVessel || RoomHasRespondingReceiver(room, out receiver))
					{
						foreach (int droneNumber in command.DroneNumbers)
						{
							Drone drone2 = null;
							if (droneNumber <= 4)
							{
								foreach (Drone drones2 in droneManager.dronesList)
								{
									if (drones2.DroneNumber == droneNumber)
									{
										if (!drones2.IsDead || drones2.CanBeTowed)
										{
											drone2 = drones2;
										}
										else if (drones2.IsBeingTowed)
										{
											SendConsoleResponseMessage(string.Format("drone {0} is being towed, and can't be transported", drones2.DroneNumber), ConsoleMessageType.Warning);
										}
										break;
									}
								}
							}
							else
							{
								foreach (Drone lootableDrones in droneManager.LootableDronesList)
								{
									if (lootableDrones.DroneNumber == droneNumber)
									{
										if (lootableDrones.CanBeTowed)
										{
											drone2 = lootableDrones;
										}
										else if (lootableDrones.IsBeingTowed)
										{
											SendConsoleResponseMessage(string.Format("drone {0} is being towed, and can't be transported", lootableDrones.DroneNumber), ConsoleMessageType.Warning);
										}
										break;
									}
								}
							}
							if (!(drone2 != null))
							{
								continue;
							}
							if (drone2.CurrentRoom != room)
							{
								if (drone2.CurrentRoom.boardingVessel || room == dungeonManager.BoardingVessel)
								{
									bool flag2 = true;
									if (room == dungeonManager.BoardingVessel)
									{
										TransporterReceiver receiver2 = null;
										if (!RoomHasRespondingReceiver(drone2.CurrentRoom, out receiver2))
										{
											flag2 = false;
											SendConsoleResponseMessage(string.Format("drone {0} not in a room with a receiver and can't transport out", drone2.DroneNumber), ConsoleMessageType.Info);
										}
									}
									if (flag2)
									{
										JumpDroneToRoom(drone2, room);
									}
									continue;
								}
								TransporterReceiver receiver3 = null;
								if (RoomHasRespondingReceiver(drone2.CurrentRoom, out receiver3))
								{
									JumpDroneToRoom(drone2, dungeonManager.BoardingVessel);
									delayedTransportDestinationRoom = room;
									if (!delayedTransportDroneList.Contains(drone2))
									{
										delayedTransportDroneList.Add(drone2);
									}
									isProcessingDelayedJump = true;
									delayBeforeJump = 1f;
								}
								else
								{
									SendConsoleResponseMessage(string.Format("drone {0} not in a room with a receiver and can't transport out", drone2.DroneNumber), ConsoleMessageType.Info);
								}
							}
							else
							{
								SendConsoleResponseMessage(string.Format("drone {0} already in room {1}", drone2.DroneNumber, arg), ConsoleMessageType.Info);
							}
						}
						command.Handled = true;
						HintManager.HintCompleted(typeof(TransportOutpostHint));
					}
					else
					{
						SendConsoleResponseMessage(string.Format("receiver not found or responding in that room {0}", arg), ConsoleMessageType.Info);
						command.Handled = true;
						HintManager.HintCompleted(typeof(TransportOutpostHint));
					}
					break;
				}
				SendConsoleResponseMessage(string.Format("could not locate room {0}", arg), ConsoleMessageType.Info);
			}
			else
			{
				List<ReceiverData> list = receiverDataList.Where((ReceiverData x) => x.receiver.IsResponding && !x.receiver.IsOffline).ToList();
				if (list.Count > 0)
				{
					foreach (ReceiverData item in list)
					{
						if (item.receiver.IsResponding)
						{
							string arg2 = string.Empty;
							if (item.CurrentStrength == ReceiverStrengthEnum.Weak)
							{
								arg2 = " (weak)";
							}
							SendConsoleResponseMessage(string.Format("signal in room {0}{1}", item.receiver.roomLocation.Label, arg2), ConsoleMessageType.Info);
						}
					}
				}
				else
				{
					SendConsoleResponseMessage("none", ConsoleMessageType.Info);
				}
				SendConsoleResponseMessage(string.Format("Signals remainging: {0}", allowedReceiverUses), ConsoleMessageType.Info);
				command.Handled = true;
			}
			if (command.Handled)
			{
				HintManager.HintCompleted(typeof(TransportOutpostHint));
			}
			break;
		}
	}

	private bool RoomHasRespondingReceiver(Room room, out TransporterReceiver receiver)
	{
		receiver = null;
		ReceiverData receiverData = receiverDataList.FirstOrDefault((ReceiverData x) => x.receiver != null && x.receiver.roomLocation == room && x.receiver.IsResponding);
		if (receiverData != null)
		{
			receiver = receiverData.receiver;
			return true;
		}
		return false;
	}

	private void JumpDroneToRoom(Drone drone, Room room)
	{
		Vector3 safePos = Vector3.zero;
		Vector3 safeTowPos = Vector3.zero;
		if (!room.PickSafeLocationForDrone(drone, out safePos, out safeTowPos))
		{
			SendConsoleResponseMessage(string.Format("No safe place found in room {0} to transport '{1}'.", room.Label, drone.DroneName), ConsoleMessageType.Warning);
			return;
		}
		if (GlobalSettings.cameraMode == CameraMode.Drone)
		{
			drone.transportSound.Play();
			drone.transportSound.volume = GameAudio.RemoteVolume * 1f;
		}
		drone.CurrentRoom = room;
		drone.MoveToPosition(safePos);
		if (drone.ItemBeingTowed != null)
		{
			if (drone.ItemBeingTowed is Drone)
			{
				Drone drone2 = (Drone)drone.ItemBeingTowed;
				drone2.CurrentRoom = room;
				drone2.MoveToPosition(safePos + safeTowPos);
			}
			else if (drone.ItemBeingTowed is ShipUpgradeInGameObject)
			{
				ShipUpgradeInGameObject shipUpgradeInGameObject = (ShipUpgradeInGameObject)drone.ItemBeingTowed;
				shipUpgradeInGameObject.MoveToPosition(safePos + safeTowPos);
			}
		}
		drone.StopPriorNavigation();
		DroneManager.Instance.HideUpgradeSwapUI(true);
		SendConsoleResponseMessage(string.Format("transported drone {0} to {1}", drone.DroneNumber, room.Label), ConsoleMessageType.Info);
		if (!GlobalSettings.MissionStarted)
		{
			GameplayManager.Instance.StartMission();
			SendConsoleResponseMessage("Mission Started", ConsoleMessageType.Healthy);
		}
		HintManager.HintCompleted(typeof(TransportSUHint));
		HintManager.HintCompleted(typeof(TransportOutpostHint));
		UpgradeUsed();
		canJump = false;
		timeTilNextJump = 2f;
	}
}
