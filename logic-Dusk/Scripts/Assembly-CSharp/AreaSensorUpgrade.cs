using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AreaSensorUpgrade : BaseDroneUpgrade, IStorageUpgrade, IUpdateCameraView
{
	private const string COMMAND_VALUE = "motion";

	private static bool hasTestedHerdHint;

	private static bool hasTestedHerdBlindHint;

	private static List<CommandDefinition> commandList;

	private int guiCapacity;

	private int guiQuantity;

	private string _guiString = string.Empty;

	private List<Room> _roomsWeActivated = new List<Room>();

	private List<Room> _roomsWeCouldntActivate = new List<Room>();

	private Vector3 prevPosition = Vector3.zero;

	private Room hintRoomWatchingForEnemy;

	private Room hintRoomWatchingForBlindEnemy;

	private bool hasRoomBeenOpenedForBlindHint;

	private float timerTimeToCompleteBlindHint;

	private bool tempDisableBlindHintPosibility;

	private List<Door> blindHintCorridors;

	private bool _wasActiveWhenUndocked;

	public override string CommandValue
	{
		get
		{
			return "motion";
		}
	}

	public int Capacity
	{
		get
		{
			return 50;
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

	public AreaSensorUpgrade(DroneUpgradeDefinition definition)
		: base(definition)
	{
		Quantity = Capacity;
		EventManager.Instance.SubscribeInstant(GeneralEventType.Undocking, HandleUndocking);
		EventManager.Instance.SubscribeInstant(GeneralEventType.ReDocked, HandleReDocked);
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

	protected override void OnUpdate()
	{
		if (base.IsActivated)
		{
			if (drone.isMovingForwardBack && !drone.IsBraking)
			{
				CancelAbility();
			}
			else
			{
				Vector3 vector = drone.transform.position - prevPosition;
				if (!drone.IsBraking && ((double)vector.x > 0.01 || (double)vector.x < -0.01 || (double)vector.y > 0.01 || (double)vector.y < -0.01))
				{
					CancelAbility();
				}
				else
				{
					if (!hasTestedHerdHint)
					{
						if (!GameSaveFile.Get("HNT_HERD", false))
						{
							if (hintRoomWatchingForEnemy == null)
							{
								int count = _roomsWeActivated.Count;
								for (int i = 0; i < count; i++)
								{
									List<string> list = null;
									if (_roomsWeActivated[i].AreaSensorVisual.IsEnabled && _roomsWeActivated[i].AreaSensorVisual.EnemiesDetected)
									{
										IEnumerable<Drone> source = DroneManager.Instance.dronesList.Where((Drone x) => x != null && !x.IsDead && x.BrokenState != BrokenStateEnum.ErrorsDetected);
										int num = source.Count();
										IEnumerable<Corridor> source2 = _roomsWeActivated[i].corridors.Where((Corridor x) => x != null && x.isPowered && !x.IsAirlock);
										int num2 = source2.Count();
										if (num2 > 0)
										{
											for (int num3 = 0; num3 < num2; num3++)
											{
												Room otherRoom = source2.ElementAt(num3).getOtherRoom(_roomsWeActivated[i]);
												bool flag = false;
												for (int num4 = 0; num4 < num; num4++)
												{
													if (source.ElementAt(num4).CurrentRoom == otherRoom)
													{
														flag = true;
														break;
													}
												}
												if (flag)
												{
													continue;
												}
												bool flag2 = false;
												int count2 = EnemyManager.Instance.Enemies.Count;
												for (int num5 = 0; num5 < count2; num5++)
												{
													if (EnemyManager.Instance.Enemies[num5].CurrentRoom == otherRoom)
													{
														flag2 = true;
														break;
													}
												}
												if (flag2 || otherRoom.corridors.Any((Corridor x) => x != null && x.door != null && x.door.state == DoorState.Open))
												{
													continue;
												}
												if (list == null)
												{
													list = new List<string>();
												}
												if (!otherRoom.Label.EndsWith("?"))
												{
													if (!list.Contains(otherRoom.Label))
													{
														list.Add(otherRoom.Label);
														Debug.Log(string.Format("Hint can show for moving from room {0} to {1}", _roomsWeActivated[i].Label, otherRoom.Label));
													}
												}
												else if (!list.Contains(source2.ElementAt(num3).door.Label))
												{
													list.Add(source2.ElementAt(num3).door.Label);
													Debug.Log(string.Format("Hint can show for moving from room {0} using door {1}", _roomsWeActivated[i].Label, source2.ElementAt(num3).door.Label));
												}
											}
										}
									}
									if (list == null)
									{
										continue;
									}
									string text = string.Empty;
									string text2 = string.Empty;
									IEnumerable<string> source3 = list.Where((string x) => x.ToLower().StartsWith("r"));
									IEnumerable<string> source4 = list.Where((string x) => x.ToLower().StartsWith("d"));
									int num6 = source3.Count();
									for (int num7 = 0; num7 < num6; num7++)
									{
										if (text.Length > 0 && num6 >= 2)
										{
											text += ", ";
										}
										if (num7 > 0 && num7 == num6 - 1)
										{
											text += "or ";
										}
										text += source3.ElementAt(num7);
									}
									num6 = source4.Count();
									for (int num8 = 0; num8 < num6; num8++)
									{
										if (text2.Length > 0 && num6 >= 2)
										{
											text2 += ", ";
										}
										if (num8 > 0 && num8 == num6 - 1)
										{
											text2 += "or ";
										}
										text2 += source4.ElementAt(num8);
									}
									hintRoomWatchingForEnemy = _roomsWeActivated[i];
									if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(text2))
									{
										HintManager.PushHint(new HerdHint(string.Format("Strategic Option - herd enemies into room(s): {0}\r\nor by opening door(s): {1}", text, text2), string.Empty));
									}
									else if (!string.IsNullOrEmpty(text))
									{
										if (text.Contains(","))
										{
											HintManager.PushHint(new HerdHint("Strategic Option - herd enemies into one of\r\nthese rooms: {0}", text));
										}
										else
										{
											HintManager.PushHint(new HerdHint("Strategic Option - herd enemies into room: {0}", text));
										}
									}
									else if (text2.Contains(","))
									{
										HintManager.PushHint(new HerdHint("Strategic Option - herd enemies by opening of\r\nthese doors: {0}", text2));
									}
									else
									{
										HintManager.PushHint(new HerdHint("Strategic Option - herd enemies by opening door: {0}", text2));
									}
									break;
								}
							}
							else if (hintRoomWatchingForEnemy.AreaSensorVisual.IsEnabled)
							{
								if (!hintRoomWatchingForEnemy.AreaSensorVisual.EnemiesDetected)
								{
									HintManager.HintCompleted(typeof(HerdHint));
									hintRoomWatchingForEnemy = null;
									hasTestedHerdHint = true;
									tempDisableBlindHintPosibility = true;
								}
							}
							else
							{
								hintRoomWatchingForEnemy = null;
								HintManager.HintCanceled(typeof(HerdHint));
							}
						}
						else
						{
							hasTestedHerdHint = true;
						}
					}
					if (!tempDisableBlindHintPosibility && !hasTestedHerdBlindHint && _roomsWeCouldntActivate.Count > 0)
					{
						if (!GameSaveFile.Get("HNT_HERD_BLD", false))
						{
							if (hintRoomWatchingForBlindEnemy == null)
							{
								hasRoomBeenOpenedForBlindHint = false;
								int count3 = _roomsWeCouldntActivate.Count;
								Room room = null;
								for (int num9 = 0; num9 < count3; num9++)
								{
									List<string> list2 = null;
									if (!_roomsWeCouldntActivate[num9].corridors.Any((Corridor x) => x != null && x.door != null && x.door.state == DoorState.Open))
									{
										IEnumerable<Drone> source5 = DroneManager.Instance.dronesList.Where((Drone x) => x != null && !x.IsDead && x.BrokenState != BrokenStateEnum.ErrorsDetected);
										int num10 = source5.Count();
										IEnumerable<Corridor> source6 = _roomsWeCouldntActivate[num9].corridors.Where((Corridor x) => x != null && x.isPowered && !x.IsAirlock);
										int num11 = source6.Count();
										if (num11 > 0)
										{
											for (int num12 = 0; num12 < num11; num12++)
											{
												room = source6.ElementAt(num12).getOtherRoom(_roomsWeCouldntActivate[num9]);
												if (!_roomsWeActivated.Contains(room) || room.motionBroken)
												{
													continue;
												}
												bool flag3 = false;
												for (int num13 = 0; num13 < num10; num13++)
												{
													if (source5.ElementAt(num13).CurrentRoom == room)
													{
														flag3 = true;
														room = null;
														break;
													}
												}
												if (flag3)
												{
													continue;
												}
												bool flag4 = false;
												int count4 = EnemyManager.Instance.Enemies.Count;
												for (int num14 = 0; num14 < count4; num14++)
												{
													if (EnemyManager.Instance.Enemies[num14].CurrentRoom == room)
													{
														flag4 = true;
														break;
													}
												}
												if (flag4)
												{
													continue;
												}
												if (!room.corridors.Any((Corridor x) => x != null && x.door != null && x.door.state == DoorState.Open))
												{
													if (list2 == null)
													{
														list2 = new List<string>();
													}
													foreach (Corridor corridor in room.corridors)
													{
														if (corridor.door.state == DoorState.Open)
														{
															int num15 = 0;
															num15++;
														}
													}
													if (!room.AreaSensorVisual.enabled)
													{
														int num16 = 0;
														num16++;
													}
													if (!list2.Contains(source6.ElementAt(num12).door.Label))
													{
														list2.Add(source6.ElementAt(num12).door.Label);
														if (blindHintCorridors == null)
														{
															blindHintCorridors = new List<Door>();
														}
														blindHintCorridors.Add(source6.ElementAt(num12).door);
														Debug.Log(string.Format("Hint can show for moving from room {0} using door {1}", _roomsWeCouldntActivate[num9].Label, source6.ElementAt(num12).door.Label));
														break;
													}
												}
												else
												{
													room = null;
												}
											}
										}
									}
									if (list2 == null)
									{
										continue;
									}
									string text3 = string.Empty;
									IEnumerable<string> source7 = list2.Where((string x) => x.ToLower().StartsWith("d"));
									int num17 = source7.Count();
									for (int num18 = 0; num18 < num17; num18++)
									{
										if (text3.Length > 0 && num17 >= 2)
										{
											text3 += ", ";
										}
										if (num18 > 0 && num18 == num17 - 1)
										{
											text3 += "or ";
										}
										text3 += source7.ElementAt(num18);
									}
									hintRoomWatchingForBlindEnemy = room;
									if (room != null)
									{
										if (text3.Contains(","))
										{
											HintManager.PushHint(new HerdBlindHint("Strategic Option - open one of these doors\nto try to herd any enemies into a scannable room: {0}", text3));
										}
										else
										{
											HintManager.PushHint(new HerdBlindHint("Strategic Option - open door '{0}' to try to herd any\nenemies out and into the scannable room '" + room.Label + "'", text3));
										}
									}
									else if (text3.Contains(","))
									{
										HintManager.PushHint(new HerdBlindHint("Strategic Option - open one of these doors\nto try to herd any enemies into a scannable room: ", text3));
									}
									else
									{
										HintManager.PushHint(new HerdBlindHint("Strategic Option - open door '{0}' to try to herd any\nenemies out and into a scannable room", text3));
									}
									break;
								}
							}
							else if (!hasRoomBeenOpenedForBlindHint)
							{
								int count5 = blindHintCorridors.Count;
								for (int num19 = 0; num19 < count5; num19++)
								{
									if (blindHintCorridors[num19].state == DoorState.Open)
									{
										hasRoomBeenOpenedForBlindHint = true;
										timerTimeToCompleteBlindHint = 3f;
										break;
									}
								}
							}
							else if (hintRoomWatchingForBlindEnemy != null && hintRoomWatchingForBlindEnemy.AreaSensorVisual.EnemiesDetected)
							{
								HintManager.HintCompleted(typeof(HerdBlindHint));
								hintRoomWatchingForBlindEnemy = null;
								hasRoomBeenOpenedForBlindHint = false;
								hasTestedHerdBlindHint = true;
								hasTestedHerdHint = true;
							}
							else
							{
								timerTimeToCompleteBlindHint -= Time.deltaTime;
								if (timerTimeToCompleteBlindHint <= 0f)
								{
									HintManager.HintCompleted(typeof(HerdBlindHint));
									hasRoomBeenOpenedForBlindHint = false;
									hasTestedHerdBlindHint = true;
									hasTestedHerdHint = true;
								}
							}
						}
						else
						{
							hasTestedHerdBlindHint = true;
						}
					}
				}
				if (GlobalSettings.cameraMode == CameraMode.Schematic)
				{
					HintManager.HintCompleted(typeof(MotionHint));
				}
			}
			prevPosition = drone.transform.position;
		}
		else
		{
			if (hintRoomWatchingForEnemy != null)
			{
				hintRoomWatchingForEnemy = null;
				HintManager.HintCanceled(typeof(HerdHint));
			}
			if (hintRoomWatchingForBlindEnemy != null)
			{
				hintRoomWatchingForBlindEnemy = null;
				HintManager.HintCanceled(typeof(HerdBlindHint));
			}
		}
	}

	public override List<CommandDefinition> QueryAvailableCommands()
	{
		if (commandList == null)
		{
			commandList = new List<CommandDefinition>(CommandHelper.GetCommands("MotionSensorUpgrade"));
		}
		return commandList;
	}

	public override void ExecuteCommand(ExecutedCommand command, bool partOfMultiCommand)
	{
		switch (command.Command.CommandName)
		{
		case "motion":
		{
			bool flag = !base.IsActivated;
			if (command.Arguments.Count == 1)
			{
				if (command.Arguments[0].ToLower() == "on")
				{
					flag = true;
				}
				else if (command.Arguments[0].ToLower() == "off")
				{
					flag = false;
				}
			}
			if (flag)
			{
				if (drone.isMovingForwardBack && !drone.IsBraking)
				{
					drone.StopPriorNavigation();
				}
				if (!base.IsActivated)
				{
					if (Quantity > 0)
					{
						if (drone.CurrentRoom == null)
						{
							SendConsoleResponseMessage("Can only use a motion sensor in a room.", ConsoleMessageType.Warning);
						}
						else
						{
							ActivateAbility();
							Quantity -= 1;
							if (Quantity < 0)
							{
								Quantity = 0;
							}
							if (SchematicViewCanvas.Instance != null)
							{
								SchematicViewCanvas.Instance.RefreshDrone(drone.DroneNumber);
							}
							if (DroneManager.Instance.currentDronePanel != null && DroneManager.Instance.CurrentDrone == drone)
							{
								DroneManager.Instance.currentDronePanel.UpgradesChanged = true;
							}
						}
					}
					else
					{
						if (drone.StorageUpgradeTotalQuantity(base.Definition.Type) > 0)
						{
							return;
						}
						SendConsoleResponseMessage("Motion sensor has plumb wore out", ConsoleMessageType.Warning);
						command.Handled = true;
					}
				}
			}
			else if (base.IsActivated)
			{
				CancelAbility();
			}
			command.Handled = true;
			break;
		}
		}
		base.ExecuteCommand(command, partOfMultiCommand);
	}

	public override bool ActivateAbility()
	{
		_roomsWeActivated.Clear();
		if (drone.CurrentRoom == null)
		{
			SendConsoleResponseMessage("Can only use a motion sensor in a room.", ConsoleMessageType.Warning);
			return false;
		}
		if (!base.ActivateAbility())
		{
			return false;
		}
		if (drone.CurrentRoom != null)
		{
			if (!drone.CurrentRoom.motionBroken)
			{
				drone.CurrentRoom.AreaSensorVisual.Enable();
			}
			else
			{
				drone.CurrentRoom.AreaSensorVisual.Enable(true);
				SendConsoleResponseMessage("   " + drone.CurrentRoom.Label + ": results inconclusive", ConsoleMessageType.Warning);
			}
			_roomsWeActivated.Add(drone.CurrentRoom);
			IEnumerable<AdjacentRoomData> allAdjacentRoomData = NavigationHelper.GetAllAdjacentRoomData(drone.CurrentRoom);
			IEnumerator<AdjacentRoomData> enumerator = allAdjacentRoomData.GetEnumerator();
			while (enumerator.MoveNext())
			{
				bool flag = false;
				Room room = null;
				if (enumerator.Current.Room1 != drone.CurrentRoom)
				{
					if (enumerator.Current.Room1 != null)
					{
						flag = true;
						room = enumerator.Current.Room1;
					}
				}
				else if (enumerator.Current.Room2 != drone.CurrentRoom && enumerator.Current.Room2 != null)
				{
					flag = true;
					room = enumerator.Current.Room2;
				}
				if (flag)
				{
					if (!room.motionBroken)
					{
						room.AreaSensorVisual.Enable();
					}
					else
					{
						room.AreaSensorVisual.Enable(true);
						SendConsoleResponseMessage("   " + room.Label + ": results inconclusive", ConsoleMessageType.Warning);
						_roomsWeCouldntActivate.Add(room);
					}
					_roomsWeActivated.Add(room);
				}
			}
		}
		prevPosition = drone.transform.position;
		if (GlobalSettings.cameraMode == CameraMode.Drone)
		{
			drone.motionSensorSound.Play();
			drone.motionSensorSound.volume = GameAudio.RemoteVolume * 1f;
		}
		SendConsoleResponseMessage("Motion Sensors Activated", ConsoleMessageType.Info);
		return true;
	}

	public override void CancelAbility()
	{
		base.CancelAbility();
		_roomsWeActivated.ForEach(delegate(Room x)
		{
			x.AreaSensorVisual.Disable();
		});
		_roomsWeActivated.Clear();
		_roomsWeCouldntActivate.Clear();
		SendConsoleResponseMessage("Motion Sensors Deactivated", ConsoleMessageType.Info);
		if (hintRoomWatchingForBlindEnemy != null)
		{
			hintRoomWatchingForBlindEnemy = null;
			HintManager.HintCanceled(typeof(HerdBlindHint));
		}
		drone.motionSensorSound.Stop();
	}

	public void UpdateCameraView()
	{
		if (base.IsActivated)
		{
			if (GlobalSettings.cameraMode == CameraMode.Drone)
			{
				drone.motionSensorSound.Play();
				drone.motionSensorSound.volume = GameAudio.RemoteVolume * 1f;
			}
			else
			{
				drone.motionSensorSound.Pause();
			}
		}
	}

	private void HandleUndocking(object sender, EventArgs args)
	{
		if (drone == null)
		{
			return;
		}
		Room room = (Room)((GeneralEventArgs)args).Data;
		if (drone.CurrentRoom == room)
		{
			if (base.IsActivated)
			{
				_wasActiveWhenUndocked = true;
				CancelAbility();
			}
		}
		else if (base.IsActivated)
		{
			if (_roomsWeActivated.Contains(room))
			{
				room.AreaSensorVisual.Disable();
				_roomsWeActivated.Remove(room);
			}
			else if (_roomsWeCouldntActivate.Contains(room))
			{
				_roomsWeCouldntActivate.Remove(room);
			}
		}
	}

	private void HandleReDocked(object sender, EventArgs args)
	{
		if (drone == null)
		{
			return;
		}
		Room room = (Room)((GeneralEventArgs)args).Data;
		if (drone.CurrentRoom == room)
		{
			if (_wasActiveWhenUndocked)
			{
				_wasActiveWhenUndocked = false;
				ActivateAbility();
			}
		}
		else if (base.IsActivated && drone.CurrentRoom != null && drone.CurrentRoom.getAdjacentRooms().Contains(room))
		{
			room.AreaSensorVisual.Enable();
			_roomsWeActivated.Add(room);
		}
	}
}
