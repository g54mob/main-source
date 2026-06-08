using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GathererUpgrade : BaseDroneUpgrade
{
	private const string COMMAND_VALUE = "gather";

	private const CollisionType COLLISION_TYPE = CollisionType.CenterIntersect;

	private static List<CommandDefinition> commandList;

	private bool gathering;

	private bool isNavigatingToFuelPump;

	private FuelAccess currentFuelAccess;

	private Color originalFuelAccessColor = Color.white;

	private int currentFuelObtained;

	private int currentFuelType = -1;

	private int summaryPFuel;

	private int summaryJFuel;

	private float timerTilNextFuel;

	private ExecutedCommand gatheringLootCommand;

	private List<LootItem> lootItems = new List<LootItem>();

	public override string CommandValue
	{
		get
		{
			return "gather";
		}
	}

	public override float UpgradeBreakFactor
	{
		get
		{
			return 0.25f;
		}
	}

	public int propulsionFuel { get; set; }

	public int jumpFuel { get; set; }

	public GathererUpgrade(DroneUpgradeDefinition definition)
		: base(definition)
	{
	}

	public override void Update()
	{
		if (drone != null)
		{
			if (drone.isPumpingFuel)
			{
				if (drone.timerLastPumpingFuelNotification > 0f)
				{
					drone.timerLastPumpingFuelNotification -= Time.deltaTime;
					if (drone.timerLastPumpingFuelNotification <= 0f)
					{
						drone.timerLastPumpingFuelNotification = 0f;
					}
				}
				timerTilNextFuel -= Time.deltaTime;
				if (timerTilNextFuel <= 0f)
				{
					timerTilNextFuel = 1f;
					if (currentFuelType == 0)
					{
						if (currentFuelAccess.countPropulsionFuel > 0)
						{
							summaryPFuel++;
							propulsionFuel++;
							currentFuelObtained++;
							currentFuelAccess.countPropulsionFuel--;
							ConsoleWindow3.SendConsoleResponse(string.Format("   {0} day(s) propulsion acquired (reserve)...", currentFuelObtained), ConsoleMessageType.Info);
						}
						else
						{
							if (currentFuelObtained == 0)
							{
								ConsoleWindow3.SendConsoleResponse(string.Format("   {0} day(s) propulsion acquired (reserve)...", currentFuelObtained), ConsoleMessageType.Info);
							}
							currentFuelType = 1;
							currentFuelObtained = 0;
						}
					}
					else if (currentFuelType == 1)
					{
						if (currentFuelAccess.countJumpFuel > 0)
						{
							summaryJFuel++;
							jumpFuel++;
							currentFuelObtained++;
							currentFuelAccess.countJumpFuel--;
							ConsoleWindow3.SendConsoleResponse(string.Format("   {0} jump cell(s) acquired...", currentFuelObtained), ConsoleMessageType.Info);
						}
						else
						{
							if (currentFuelObtained == 0)
							{
								ConsoleWindow3.SendConsoleResponse(string.Format("   {0} jump cell(s) acquired...", currentFuelObtained), ConsoleMessageType.Info);
							}
							EndPumpFuel(false);
						}
					}
				}
			}
			else if (!isNavigatingToFuelPump && drone.isGatheringLoot)
			{
				if (!gathering && !drone.IsUnderPlayerControl)
				{
					GatherNextRation();
				}
				else if (drone.brain.CurrentState != "MoveAndExecuteCommand")
				{
					if (drone.IsUnderPlayerControl)
					{
						drone.isGatheringLoot = false;
					}
					gathering = false;
				}
			}
		}
		base.Update();
	}

	public override List<CommandDefinition> QueryAvailableCommands()
	{
		if (commandList == null)
		{
			commandList = new List<CommandDefinition>(CommandHelper.GetCommands("GathererUpgrade"));
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
		case "gather":
		case "pickup":
			command.Handled = true;
			if (drone.isPumpingFuel)
			{
				break;
			}
			if (command.Arguments.Count > 0)
			{
				if (command.Arguments.Last().ToLower() == "list" && command.Command.CommandName != "pickup")
				{
					SendConsoleResponseMessage("Scrap count: <color=#8ed0ff>" + lootItems.Count + "</color>", ConsoleMessageType.Info);
					SendConsoleResponseMessage("Propulsion Fuel: <color=#8ed0ff>" + propulsionFuel + "</color>", ConsoleMessageType.Info);
					SendConsoleResponseMessage("Jump Fuel: <color=#8ed0ff>" + jumpFuel + "</color>", ConsoleMessageType.Info);
				}
				else
				{
					if (!(command.Arguments.Last().ToLower() == "all"))
					{
						break;
					}
					if (!GameSaveFile.Get("HNT_GATALL", false))
					{
						GameSaveFile.Save("HNT_GATALL", true);
					}
					HintManager.HintCompleted(typeof(GatherAllHint));
					if (!(drone.CurrentRoom != null))
					{
						break;
					}
					List<LootItem> roomItems = drone.CurrentRoom.GetRoomItems<LootItem>(typeof(LootItem), false);
					if (roomItems.Count > 0)
					{
						drone.isGatheringLoot = true;
					}
					FuelAccess fuelAccess = (FuelAccess)drone.CurrentRoom.GetRoomItem(typeof(FuelAccess), false);
					if (fuelAccess != null && (!drone.isGatheringLoot || fuelAccess.hasFuel || !fuelAccess.hasBeenAccessedAtLeastOnce))
					{
						if (drone.GetComponent<Collider>().bounds.Intersects(fuelAccess.gameObject.GetComponent<Collider>().bounds))
						{
							if (!fuelAccess.IsDead)
							{
								currentFuelAccess = fuelAccess;
								BeginPumpFuel();
							}
							else
							{
								SendConsoleResponseMessage("Fuel access is destroyed", ConsoleMessageType.Warning);
							}
						}
						else
						{
							isNavigatingToFuelPump = true;
							drone.NavigateToAndExecuteCommand(fuelAccess.gameObject, command, CollisionType.CenterIntersect);
						}
					}
					if (!drone.isGatheringLoot && !drone.isPumpingFuel && !isNavigatingToFuelPump)
					{
						SendConsoleResponseMessage("Nothing to gather", ConsoleMessageType.Info);
						break;
					}
					gatheringLootCommand = new ExecutedCommand(command);
					gatheringLootCommand.Arguments.Clear();
					if (!isNavigatingToFuelPump && !drone.isPumpingFuel)
					{
						GatherNextRation();
					}
				}
			}
			else if (drone.CurrentRoom != null)
			{
				List<LootItem> roomItems2 = drone.CurrentRoom.GetRoomItems<LootItem>(typeof(LootItem), false);
				LootItem[] array = null;
				int num = 0;
				if (roomItems2.Count > 0)
				{
					array = new LootItem[10];
					num = 10;
					int num2 = 0;
					int count = roomItems2.Count;
					for (int i = 0; i < count; i++)
					{
						LootItem lootItem = roomItems2[i];
						if (!lootItem.collected && lootItem.CanGather())
						{
							if (num2 < num)
							{
								array[num2] = lootItem;
								num2++;
								continue;
							}
							Array.Resize(ref array, array.Length + 1);
							num2 = array.Length - 1;
							array[num2] = lootItem;
							num = array.Length;
						}
					}
					if (num2 < num)
					{
						Array.Resize(ref array, num2);
						num = array.Length;
					}
				}
				else
				{
					array = new LootItem[0];
				}
				bool flag = false;
				for (int j = 0; j < num; j++)
				{
					LootItem lootItem2 = array[j];
					if (drone.GetComponent<Collider>().bounds.Contains(lootItem2.transform.position))
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					FuelAccess fuelAccess2 = (FuelAccess)drone.CurrentRoom.GetRoomItem(typeof(FuelAccess), false);
					if (fuelAccess2 != null)
					{
						if (drone.GetComponent<Collider>().bounds.Intersects(fuelAccess2.gameObject.GetComponent<Collider>().bounds))
						{
							if (fuelAccess2.hasFuel || !fuelAccess2.hasBeenAccessedAtLeastOnce || array.Length == 0)
							{
								if (!fuelAccess2.IsDead)
								{
									currentFuelAccess = fuelAccess2;
									BeginPumpFuel();
								}
								else
								{
									SendConsoleResponseMessage("Fuel access is destroyed", ConsoleMessageType.Warning);
								}
								if (!GameSaveFile.Get("HNT_GATALL", false) && array.Length > 0)
								{
									HintManager.PushHint(new GatherAllHint());
								}
								break;
							}
						}
						else if (fuelAccess2.hasFuel || !fuelAccess2.hasBeenAccessedAtLeastOnce || array.Length == 0)
						{
							drone.NavigateToAndExecuteCommand(fuelAccess2.gameObject, command, CollisionType.CenterIntersect);
							if (!GameSaveFile.Get("HNT_GATALL", false) && array.Length > 0)
							{
								HintManager.PushHint(new GatherAllHint());
							}
							break;
						}
					}
				}
				if (array.Length > 1 && !GameSaveFile.Get("HNT_GATALL", false))
				{
					int num3 = 0;
					for (int k = 0; k < num; k++)
					{
						LootItem lootItem3 = array[k];
						if (lootItem3.roomLocation == drone.CurrentRoom && lootItem3.CanGather())
						{
							num3++;
							if (num3 >= 2)
							{
								break;
							}
						}
					}
					if (num3 >= 2)
					{
						HintManager.PushHint(new GatherAllHint());
					}
				}
				bool flag2 = false;
				for (int l = 0; l < num; l++)
				{
					LootItem lootItem4 = array[l];
					if (!lootItem4.collected && lootItem4.CanGather() && drone.GetComponent<Collider>().bounds.Contains(lootItem4.transform.position))
					{
						if (!flag2 && !ActivateAbility())
						{
							drone.isGatheringLoot = false;
							return;
						}
						lootItem4.Collect();
						lootItems.Add(lootItem4);
						lootItem4.GetComponent<Renderer>().enabled = false;
						SendConsoleResponseMessage("Scrap acquired", ConsoleMessageType.Benefit);
						GameplayManager.Instance.missionProfitLoss += 100;
						if (GlobalSettings.cameraMode == CameraMode.Schematic)
						{
							DungeonManager.Instance.PlayPickupSound();
						}
						else if (drone != null)
						{
							drone.PlayPickupSound();
						}
						lootItem4.roomLocation.roomItems.Remove(lootItem4);
						flag2 = true;
						lootItem4.roomLocation = null;
					}
				}
				if (flag2)
				{
					break;
				}
				bool flag3 = false;
				List<LootItem> list = new List<LootItem>();
				if (drone.CurrentRoom != null)
				{
					for (int m = 0; m < num; m++)
					{
						LootItem lootItem5 = array[m];
						if (lootItem5.CanGather() && lootItem5.roomLocation == drone.CurrentRoom)
						{
							list.Add(lootItem5);
						}
					}
				}
				if (list.Count > 0)
				{
					flag3 = true;
					IOrderedEnumerable<LootItem> source = list.OrderBy((LootItem x) => Vector3.Distance(drone.Position, x.transform.position));
					RoomItem roomItem = source.First();
					drone.NavigateToAndExecuteCommand(roomItem, command, CollisionType.CenterIntersect);
				}
				if (!flag3)
				{
					SendConsoleResponseMessage("Nothing to gather", ConsoleMessageType.Info);
				}
			}
			else
			{
				if (!(drone.CurrentCorridor != null))
				{
					break;
				}
				bool flag4 = false;
				List<LootItem> list2 = new List<LootItem>();
				if (drone.CurrentCorridor.rooms.Length > 0)
				{
					list2.AddRange(drone.CurrentCorridor.rooms[0].GetRoomItems<LootItem>(typeof(LootItem), false));
				}
				if (drone.CurrentCorridor.rooms.Length > 1)
				{
					list2.AddRange(drone.CurrentCorridor.rooms[1].GetRoomItems<LootItem>(typeof(LootItem), false));
				}
				LootItem[] array2 = null;
				int num4 = 0;
				if (list2.Count <= 0)
				{
					break;
				}
				array2 = new LootItem[10];
				num4 = 10;
				int num5 = 0;
				int count2 = list2.Count;
				for (int num6 = 0; num6 < count2; num6++)
				{
					LootItem lootItem6 = list2[num6];
					if (!lootItem6.collected && lootItem6.CanGather())
					{
						if (num5 < num4)
						{
							array2[num5] = lootItem6;
							num5++;
							continue;
						}
						Array.Resize(ref array2, array2.Length + 1);
						num5 = array2.Length - 1;
						array2[num5] = lootItem6;
						num4 = array2.Length;
					}
				}
				if (num5 < num4)
				{
					Array.Resize(ref array2, num5);
					num4 = array2.Length;
				}
				for (int num7 = 0; num7 < num4; num7++)
				{
					LootItem lootItem7 = array2[num7];
					if (!lootItem7.collected && lootItem7.CanGather() && drone.GetComponent<Collider>().bounds.Contains(lootItem7.transform.position))
					{
						if (!flag4 && !ActivateAbility())
						{
							drone.isGatheringLoot = false;
							return;
						}
						lootItem7.Collect();
						lootItems.Add(lootItem7);
						lootItem7.GetComponent<Renderer>().enabled = false;
						SendConsoleResponseMessage("Scrap acquired", ConsoleMessageType.Benefit);
						GameplayManager.Instance.missionProfitLoss += 100;
						if (GlobalSettings.cameraMode == CameraMode.Schematic)
						{
							DungeonManager.Instance.PlayPickupSound();
						}
						else if (drone != null)
						{
							drone.PlayPickupSound();
						}
						lootItem7.roomLocation.roomItems.Remove(lootItem7);
						flag4 = true;
						lootItem7.roomLocation = null;
					}
				}
				if (flag4)
				{
					break;
				}
				bool flag5 = false;
				List<LootItem> list3 = new List<LootItem>();
				for (int num8 = 0; num8 < num4; num8++)
				{
					LootItem lootItem8 = array2[num8];
					if (lootItem8.CanGather() && drone.CurrentCorridor.containsRoom(lootItem8.roomLocation))
					{
						list3.Add(lootItem8);
					}
				}
				if (list3.Count > 0)
				{
					flag5 = true;
					IOrderedEnumerable<LootItem> source2 = list3.OrderBy((LootItem x) => Vector3.Distance(drone.Position, x.transform.position));
					RoomItem roomItem2 = source2.First();
					drone.NavigateToAndExecuteCommand(roomItem2, command, CollisionType.CenterIntersect);
				}
				if (!flag5)
				{
					SendConsoleResponseMessage("Nothing to gather", ConsoleMessageType.Info);
				}
			}
			break;
		}
	}

	public void ExternalScrapAdd(LootItem lootItem)
	{
		lootItems.Add(lootItem);
	}

	private void BeginPumpFuel()
	{
		isNavigatingToFuelPump = false;
		UpgradeUsed();
		ConsoleWindow3.SendConsoleResponse("Gathering fuel...", ConsoleMessageType.Info);
		if (GlobalSettings.cameraMode == CameraMode.Drone)
		{
			drone.fuelGatherSound.Play();
			drone.fuelGatherSound.volume = GameAudio.RemoteVolume * 1f;
		}
		drone.isPumpingFuel = true;
		drone.UnStealthIfHidden();
		currentFuelObtained = 0;
		currentFuelType = 0;
		summaryPFuel = 0;
		summaryJFuel = 0;
		timerTilNextFuel = 1f;
		originalFuelAccessColor = currentFuelAccess.ActiveColor;
		currentFuelAccess.ActiveColor = Color.blue;
		currentFuelAccess.SetActive();
		currentFuelAccess.hasBeenAccessedAtLeastOnce = true;
	}

	private void EndPumpFuel(bool onTerminate)
	{
		if (!onTerminate)
		{
			if (summaryPFuel + summaryJFuel > 0)
			{
				ConsoleWindow3.SendConsoleResponse(string.Format("   Fuel Total: {0} P-Fuel, {1} J-Fuel", summaryPFuel, summaryJFuel), ConsoleMessageType.Benefit);
			}
			else
			{
				ConsoleWindow3.SendConsoleResponse("   No fuel acquired", ConsoleMessageType.Info);
			}
			ConsoleWindow3.SendConsoleResponse("Done gathering fuel.", ConsoleMessageType.Info);
		}
		else
		{
			ConsoleWindow3.SendConsoleResponse("Fuel gather terminated early", ConsoleMessageType.Warning);
		}
		drone.fuelGatherSound.Stop();
		drone.isPumpingFuel = false;
		currentFuelObtained = 0;
		currentFuelType = -1;
		summaryJFuel = 0;
		summaryPFuel = 0;
		timerTilNextFuel = 0f;
		currentFuelAccess.ActiveColor = currentFuelAccess.InactiveColor;
		currentFuelAccess.SetActive();
		if (!onTerminate && drone.isGatheringLoot)
		{
			GatherNextRation();
		}
	}

	private void GatherNextRation()
	{
		LootItem[] possibleLootItems = DungeonManager.getPossibleLootItems();
		List<LootItem> list = new List<LootItem>();
		LootItem[] array = possibleLootItems;
		foreach (LootItem lootItem in array)
		{
			if (lootItem.CanGather() && lootItem.roomLocation == drone.CurrentRoom)
			{
				list.Add(lootItem);
			}
		}
		if (list.Count > 0)
		{
			gathering = true;
			IOrderedEnumerable<LootItem> source = list.OrderBy((LootItem x) => Vector3.Distance(drone.Position, x.transform.position));
			RoomItem roomItem = source.First();
			drone.NavigateToAndExecuteCommand(roomItem, gatheringLootCommand, CollisionType.CenterIntersect);
		}
		else
		{
			drone.isGatheringLoot = false;
		}
	}

	public int GetLootCount()
	{
		return lootItems.Count;
	}

	public void ClearLoot()
	{
		lootItems.Clear();
	}
}
