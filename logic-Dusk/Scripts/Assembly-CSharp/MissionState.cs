using System.Collections.Generic;
using System.Linq;

public class MissionState
{
	public enum StateDataTypeEnum
	{
		DroneStateChanged = 0,
		DroneLost = 1,
		DroneFound = 2,
		DroneLostHealth = 3,
		DroneUpgradeStateChanged = 4,
		DroneUpgradeLost = 5,
		DroneUpgradeFound = 6,
		ShipUpgradeFound = 7,
		ShipCommandeered = 8,
		ShipState = 9,
		DbfPresence = 10
	}

	public struct ChangedDataStruct
	{
		public StateDataTypeEnum dataType;

		public string changeDesc;

		public List<string> additionalInfo;

		public ChangedDataStruct(StateDataTypeEnum dataType, string changeDesc)
			: this(dataType, changeDesc, null)
		{
		}

		public ChangedDataStruct(StateDataTypeEnum dataType, string changeDesc, List<string> additionalInfo)
		{
			this.dataType = dataType;
			this.changeDesc = changeDesc;
			this.additionalInfo = additionalInfo;
		}
	}

	public struct DroneState
	{
		public Drone drone;

		public BrokenStateEnum state;

		public float hitpoints;

		public bool isDead;

		public DroneState(Drone drone)
		{
			this.drone = drone;
			state = drone.BrokenState;
			hitpoints = drone.CurrentHitPoints;
			isDead = drone.IsDead;
		}
	}

	public struct DroneUpgradeState
	{
		public BaseDroneUpgrade upgrade;

		public BrokenStateEnum state;

		public int droneNumber;

		public float breakProbability;

		public DroneUpgradeState(BaseDroneUpgrade upgrade)
		{
			this.upgrade = upgrade;
			state = BrokenStateEnum.None;
			droneNumber = -1;
			breakProbability = 0f;
			if (upgrade != null)
			{
				state = upgrade.BrokenState;
				if (upgrade.drone != null)
				{
					droneNumber = upgrade.drone.DroneNumber;
				}
				breakProbability = upgrade.BreakProbability;
			}
		}
	}

	public struct ShipUpgradeState
	{
		public BaseShipUpgrade upgrade;

		public BrokenStateEnum state;

		public float breakProbability;

		public ShipUpgradeState(BaseShipUpgrade upgrade)
		{
			this.upgrade = upgrade;
			state = BrokenStateEnum.None;
			breakProbability = 0f;
			if (upgrade != null)
			{
				state = upgrade.BrokenState;
				breakProbability = upgrade.BreakProbability;
			}
		}
	}

	public struct SlotState
	{
		public SlotInfo slot;

		public BrokenStateEnum state;

		public float breakProbability;

		public SlotState(SlotInfo slot)
		{
			this.slot = slot;
			state = slot.BrokenState;
			breakProbability = slot.BreakProbability;
		}
	}

	public struct ShipState
	{
		public int scrapMax;

		public int pfuelReserveMax;

		public List<SlotState> slotInfoList;
	}

	public DungeonInfo DungeonInfo;

	private List<DroneState> droneStateList = new List<DroneState>();

	private List<DroneUpgradeState> droneUpgradeStateList = new List<DroneUpgradeState>();

	private List<ShipUpgradeState> shipUpgradeStateList = new List<ShipUpgradeState>();

	public ShipState shipState = default(ShipState);

	public static Dictionary<StateDataTypeEnum, List<ChangedDataStruct>> CompareMissionStates(ref MissionState missionStateA, ref MissionState missionStateB)
	{
		Dictionary<StateDataTypeEnum, List<ChangedDataStruct>> dictionary = new Dictionary<StateDataTypeEnum, List<ChangedDataStruct>>();
		dictionary.Add(StateDataTypeEnum.ShipState, new List<ChangedDataStruct>());
		dictionary.Add(StateDataTypeEnum.DroneStateChanged, new List<ChangedDataStruct>());
		dictionary.Add(StateDataTypeEnum.DroneLost, new List<ChangedDataStruct>());
		dictionary.Add(StateDataTypeEnum.DroneFound, new List<ChangedDataStruct>());
		dictionary.Add(StateDataTypeEnum.DroneLostHealth, new List<ChangedDataStruct>());
		dictionary.Add(StateDataTypeEnum.DroneUpgradeStateChanged, new List<ChangedDataStruct>());
		dictionary.Add(StateDataTypeEnum.DroneUpgradeLost, new List<ChangedDataStruct>());
		dictionary.Add(StateDataTypeEnum.DroneUpgradeFound, new List<ChangedDataStruct>());
		dictionary.Add(StateDataTypeEnum.ShipUpgradeFound, new List<ChangedDataStruct>());
		dictionary.Add(StateDataTypeEnum.ShipCommandeered, new List<ChangedDataStruct>());
		dictionary.Add(StateDataTypeEnum.DbfPresence, new List<ChangedDataStruct>());
		List<Drone> list = new List<Drone>();
		List<Drone> list2 = new List<Drone>();
		if (GlobalSettings.CommandeeringShip)
		{
			if (missionStateA.shipState.scrapMax != missionStateB.shipState.scrapMax)
			{
				if (missionStateA.shipState.scrapMax > missionStateB.shipState.scrapMax)
				{
					dictionary[StateDataTypeEnum.ShipState].Add(new ChangedDataStruct(StateDataTypeEnum.ShipState, string.Format("<color=#FF0000>New ship contains {0} fewer scrap than your old one</color>", missionStateA.shipState.scrapMax - missionStateB.shipState.scrapMax)));
				}
				else
				{
					dictionary[StateDataTypeEnum.ShipState].Add(new ChangedDataStruct(StateDataTypeEnum.ShipState, string.Format("<color=#8ed0ff>New ship can hold {0} more scrap!</color>", missionStateB.shipState.scrapMax - missionStateA.shipState.scrapMax)));
				}
				dictionary[StateDataTypeEnum.ShipState].Add(new ChangedDataStruct(StateDataTypeEnum.ShipState, string.Format("\tNew Scrap Capacity: {0}", missionStateB.shipState.scrapMax)));
			}
		}
		else if (missionStateA.shipState.slotInfoList != null && missionStateB.shipState.slotInfoList != null)
		{
			foreach (SlotState slotInfo in missionStateA.shipState.slotInfoList)
			{
				foreach (SlotState slotInfo2 in missionStateB.shipState.slotInfoList)
				{
					if (slotInfo.slot.GroupKey == slotInfo2.slot.GroupKey)
					{
						if (slotInfo.breakProbability <= 15f && slotInfo2.breakProbability > 15f)
						{
							string text = "#FFF000";
							dictionary[StateDataTypeEnum.DroneUpgradeStateChanged].Add(new ChangedDataStruct(StateDataTypeEnum.ShipState, string.Format("<color=" + text + ">Ship Slot #{0} is deteriorating.</color> Break prob.: <color=" + text + ">{1:0.00}%</color>", slotInfo2.slot.SlotNumber + 1, slotInfo2.breakProbability)));
						}
						else if (slotInfo.breakProbability <= 25f && slotInfo2.breakProbability > 25f)
						{
							string text2 = "#ff9600";
							dictionary[StateDataTypeEnum.DroneUpgradeStateChanged].Add(new ChangedDataStruct(StateDataTypeEnum.ShipState, string.Format("<color=" + text2 + ">Ship Slot #{0} is deteriorating.</color> Break prob.: <color=" + text2 + ">{1:0.00}%</color>", slotInfo2.slot.SlotNumber + 1, slotInfo2.breakProbability)));
						}
						else if (slotInfo.state != BrokenStateEnum.Broken && slotInfo2.state == BrokenStateEnum.Broken)
						{
							string text3 = "#FF0000";
							dictionary[StateDataTypeEnum.DroneUpgradeStateChanged].Add(new ChangedDataStruct(StateDataTypeEnum.ShipState, string.Format("<color=" + text3 + ">Slot #{0} ceased functioning.</color>", slotInfo2.slot.SlotNumber + 1, slotInfo2.state)));
						}
						break;
					}
				}
			}
		}
		foreach (DroneState droneState in missionStateA.droneStateList)
		{
			bool flag = false;
			foreach (DroneState droneState2 in missionStateB.droneStateList)
			{
				if (droneState2.drone.DroneNumber != droneState.drone.DroneNumber)
				{
					continue;
				}
				if (droneState.state != droneState2.state)
				{
					string text4 = ConvertObjectStateToText(droneState.state);
					string arg = ((!droneState2.drone.IsDead) ? ConvertObjectStateToText(droneState2.state) : ((!droneState2.drone.CanBeTowed && !droneState2.drone.IsBeingTowed) ? "Dead" : "Disabled"));
					string text5 = "#FFF000";
					if (!droneState2.drone.CanBeTowed && !droneState2.drone.IsBeingTowed)
					{
						text5 = "#FF0000";
					}
					dictionary[StateDataTypeEnum.DroneStateChanged].Add(new ChangedDataStruct(StateDataTypeEnum.DroneStateChanged, string.Format("<color=" + text5 + ">'{0}' (Drone {1}) {2}!</color>", droneState.drone.DroneName, droneState.drone.DroneNumber, arg)));
				}
				if (droneState.hitpoints > droneState2.hitpoints && droneState2.hitpoints > 0f)
				{
					float num = droneState2.drone.CurrentHitPoints / droneState2.drone.TotalHitpoints;
					int num2 = (int)(num * 100f);
					dictionary[StateDataTypeEnum.DroneLostHealth].Add(new ChangedDataStruct(StateDataTypeEnum.DroneLostHealth, string.Format("'{0}' <color=#FFF000>Drone's Health Dropped</color> to {2} ({3}% remaining)", droneState.drone.DroneName, droneState.hitpoints, droneState2.hitpoints, num2)));
				}
				flag = true;
				break;
			}
			if (flag)
			{
				continue;
			}
			string arg2 = string.Empty;
			List<string> list3 = new List<string>();
			int num3 = droneState.drone.Upgrades.Where((BaseDroneUpgrade x) => x != null).Count();
			if (num3 > 0)
			{
				if (droneState.drone.CurrentRoom == DungeonManager.Instance.BoardingVessel)
				{
					arg2 = string.Format(" was in docking bay\n>    Stripping {0} upgrades then jettisoning into space:", num3);
				}
				else
				{
					list3.Add(string.Format("<color=#FFF000>{0} Upgrade(s) Lost...</color>", num3));
				}
				foreach (BaseDroneUpgrade upgrade in droneState.drone.Upgrades)
				{
					if (upgrade != null)
					{
						list3.Add("- '" + upgrade.Name + "'");
					}
				}
			}
			dictionary[StateDataTypeEnum.DroneLost].Add(new ChangedDataStruct(StateDataTypeEnum.DroneLost, string.Format("<color=#FF0000>'{0}' (Drone {1}) Lost!</color>{2}", droneState.drone.DroneName, droneState.drone.DroneNumber, arg2), list3));
			list.Add(droneState.drone);
		}
		foreach (DroneState droneState3 in missionStateB.droneStateList)
		{
			bool flag2 = false;
			foreach (DroneState droneState4 in missionStateA.droneStateList)
			{
				if (droneState4.drone.DroneNumber == droneState3.drone.DroneNumber && (!droneState3.drone.IsDead || droneState3.drone.CanBeFullyRepaired))
				{
					flag2 = true;
					break;
				}
			}
			if (flag2)
			{
				continue;
			}
			List<string> list4 = new List<string>();
			int num4 = droneState3.drone.Upgrades.Where((BaseDroneUpgrade x) => x != null).Count();
			if (num4 > 0)
			{
				list4.Add(string.Format("<color=#8ed0ff>{0} Upgrade(s) Acquired...</color>", num4));
				foreach (BaseDroneUpgrade upgrade2 in droneState3.drone.Upgrades)
				{
					if (upgrade2 != null)
					{
						list4.Add("- '" + upgrade2.Name + "'");
					}
				}
			}
			if (droneState3.drone.CanBeFullyRepaired)
			{
				dictionary[StateDataTypeEnum.DroneFound].Add(new ChangedDataStruct(StateDataTypeEnum.DroneFound, string.Format("<color=#8ed0ff>Drone added to fleet!</color> ('{0}')", droneState3.drone.DroneName), list4));
			}
			else
			{
				dictionary[StateDataTypeEnum.DroneFound].Add(new ChangedDataStruct(StateDataTypeEnum.DroneFound, string.Format("Harvesting upgrades off broken Drone ('{0}')...", droneState3.drone.DroneName), list4));
			}
			list2.Add(droneState3.drone);
		}
		foreach (DroneUpgradeState droneUpgradeState in missionStateA.droneUpgradeStateList)
		{
			if (droneUpgradeState.upgrade != null && !(droneUpgradeState.upgrade.drone == null) && list.Contains(droneUpgradeState.upgrade.drone))
			{
				continue;
			}
			bool flag3 = false;
			foreach (DroneUpgradeState droneUpgradeState2 in missionStateB.droneUpgradeStateList)
			{
				if (droneUpgradeState2.upgrade == droneUpgradeState.upgrade)
				{
					if (droneUpgradeState.breakProbability <= 15f && droneUpgradeState2.breakProbability > 15f)
					{
						string text6 = "#FFF000";
						dictionary[StateDataTypeEnum.DroneUpgradeStateChanged].Add(new ChangedDataStruct(StateDataTypeEnum.DroneUpgradeStateChanged, string.Format("<color=" + text6 + ">'{1}' deteriorating</color> on Drone #{0}. Break prob.: <color=" + text6 + ">{2:0.00}%</color>", droneUpgradeState2.droneNumber, droneUpgradeState.upgrade.Name, droneUpgradeState.upgrade.BreakProbability)));
					}
					else if (droneUpgradeState.breakProbability <= 25f && droneUpgradeState2.breakProbability > 25f)
					{
						string text7 = "#ff9600";
						dictionary[StateDataTypeEnum.DroneUpgradeStateChanged].Add(new ChangedDataStruct(StateDataTypeEnum.DroneUpgradeStateChanged, string.Format("<color=" + text7 + ">'{1}' deteriorating</color> on Drone #{0}. Break prob.: <color=" + text7 + ">{2:0.00}%</color>", droneUpgradeState2.droneNumber, droneUpgradeState.upgrade.Name, droneUpgradeState.upgrade.BreakProbability)));
					}
					else if (droneUpgradeState.state != BrokenStateEnum.Broken && droneUpgradeState2.state == BrokenStateEnum.Broken)
					{
						string text8 = "#FF0000";
						dictionary[StateDataTypeEnum.DroneUpgradeStateChanged].Add(new ChangedDataStruct(StateDataTypeEnum.DroneUpgradeStateChanged, string.Format("<color=" + text8 + ">'{1}' ceased functioning</color> on Drone #{0}.", droneUpgradeState2.droneNumber, droneUpgradeState.upgrade.Name, droneUpgradeState.upgrade.BreakProbability)));
					}
					flag3 = true;
					break;
				}
			}
			if (!flag3 && droneUpgradeState.upgrade != null && !list.Contains(droneUpgradeState.upgrade.drone))
			{
				dictionary[StateDataTypeEnum.DroneUpgradeLost].Add(new ChangedDataStruct(StateDataTypeEnum.DroneUpgradeLost, string.Format("<color=#FFF000>Upgrade Left Behind!</color> '{1}' on Drone #{0}'s", droneUpgradeState.droneNumber, (droneUpgradeState.upgrade == null) ? "[error]" : droneUpgradeState.upgrade.Name)));
			}
		}
		foreach (DroneUpgradeState droneUpgradeState3 in missionStateB.droneUpgradeStateList)
		{
			if (droneUpgradeState3.upgrade == null)
			{
				continue;
			}
			bool flag4 = false;
			foreach (DroneUpgradeState droneUpgradeState4 in missionStateA.droneUpgradeStateList)
			{
				if (droneUpgradeState4.upgrade != null && droneUpgradeState4.upgrade.Id == droneUpgradeState3.upgrade.Id)
				{
					flag4 = true;
					break;
				}
			}
			if (!flag4 && !list2.Contains(droneUpgradeState3.upgrade.drone))
			{
				dictionary[StateDataTypeEnum.DroneUpgradeFound].Add(new ChangedDataStruct(StateDataTypeEnum.DroneUpgradeFound, string.Format("<color=#8ed0ff>'{0}' upgrade added to Drone ('{1}')</color>", droneUpgradeState3.upgrade.Name, droneUpgradeState3.upgrade.drone.DroneName)));
			}
		}
		foreach (ShipUpgradeState shipUpgradeState in missionStateA.shipUpgradeStateList)
		{
			foreach (ShipUpgradeState shipUpgradeState2 in missionStateB.shipUpgradeStateList)
			{
				if (shipUpgradeState2.upgrade == shipUpgradeState.upgrade)
				{
					if (shipUpgradeState.breakProbability <= 15f && shipUpgradeState2.breakProbability > 15f)
					{
						string text9 = "#FFF000";
						dictionary[StateDataTypeEnum.DroneUpgradeStateChanged].Add(new ChangedDataStruct(StateDataTypeEnum.DroneUpgradeStateChanged, string.Format("<color=" + text9 + ">'{1}' deteriorating</color> on '{0}' Ship Upgrade. Break prob.: <color=" + text9 + ">{2:0.00}%</color>", shipUpgradeState2.upgrade.Name, shipUpgradeState.upgrade.Name, shipUpgradeState.upgrade.BreakProbability)));
					}
					else if (shipUpgradeState.breakProbability <= 25f && shipUpgradeState2.breakProbability > 25f)
					{
						string text10 = "#ff9600";
						dictionary[StateDataTypeEnum.DroneUpgradeStateChanged].Add(new ChangedDataStruct(StateDataTypeEnum.DroneUpgradeStateChanged, string.Format("<color=" + text10 + ">'{1}' deteriorating</color> on '{0}' Ship Upgrade. Break prob.: <color=" + text10 + ">{2:0.00}%</color>", shipUpgradeState2.upgrade.Name, shipUpgradeState.upgrade.Name, shipUpgradeState.upgrade.BreakProbability)));
					}
					else if (shipUpgradeState.state != BrokenStateEnum.Broken && shipUpgradeState2.state == BrokenStateEnum.Broken)
					{
						string text11 = "#FF0000";
						dictionary[StateDataTypeEnum.DroneUpgradeStateChanged].Add(new ChangedDataStruct(StateDataTypeEnum.DroneUpgradeStateChanged, string.Format("<color=" + text11 + ">'{1}' ceased functioning</color> on '{0}' Ship Upgrade.", shipUpgradeState2.upgrade.Name, shipUpgradeState.upgrade.Name, shipUpgradeState.upgrade.BreakProbability)));
					}
				}
			}
		}
		foreach (ShipUpgradeState shipUpgradeState3 in missionStateB.shipUpgradeStateList)
		{
			if (shipUpgradeState3.upgrade == null)
			{
				continue;
			}
			bool flag5 = false;
			foreach (ShipUpgradeState shipUpgradeState4 in missionStateA.shipUpgradeStateList)
			{
				if (shipUpgradeState4.upgrade != null && shipUpgradeState4.upgrade.Id == shipUpgradeState3.upgrade.Id)
				{
					flag5 = true;
					break;
				}
			}
			if (!flag5)
			{
				dictionary[StateDataTypeEnum.ShipUpgradeFound].Add(new ChangedDataStruct(StateDataTypeEnum.ShipUpgradeFound, string.Format("<color=#8ed0ff>Ship Upgrade Retrieved!</color> ('{0}')  Break prob.: <color=#8ed0ff>{1:0.00}%</color>", shipUpgradeState3.upgrade.Name, shipUpgradeState3.upgrade.BreakProbability)));
			}
		}
		if (missionStateA.DungeonInfo != missionStateB.DungeonInfo && missionStateA.DungeonInfo != null && missionStateB.DungeonInfo != null)
		{
			if (missionStateA.DungeonInfo.ShipUpgradeSlots < missionStateB.DungeonInfo.ShipUpgradeSlots)
			{
				dictionary[StateDataTypeEnum.ShipCommandeered].Add(new ChangedDataStruct(StateDataTypeEnum.ShipCommandeered, string.Format("<color=#8ed0ff>Gained {0} Ship Upgrade Slot(s)!</color>", missionStateB.DungeonInfo.ShipUpgradeSlots - missionStateA.DungeonInfo.ShipUpgradeSlots)));
			}
			else if (missionStateA.DungeonInfo.ShipUpgradeSlots > missionStateB.DungeonInfo.ShipUpgradeSlots)
			{
				dictionary[StateDataTypeEnum.ShipCommandeered].Add(new ChangedDataStruct(StateDataTypeEnum.ShipCommandeered, string.Format("<color=#FFF000>Lost {0} Ship Upgrade Slot(s)</color>", missionStateA.DungeonInfo.ShipUpgradeSlots - missionStateB.DungeonInfo.ShipUpgradeSlots)));
			}
		}
		if (GameplayManager.CheckForDronesBestFriendInDroneBay())
		{
			dictionary[StateDataTypeEnum.DbfPresence].Add(new ChangedDataStruct(StateDataTypeEnum.DbfPresence, "<color=#8ed0ff>Non-hostile life form detected in the docking bay.</color>"));
		}
		return dictionary;
	}

	private static string ConvertObjectStateToText(BrokenStateEnum state)
	{
		switch (state)
		{
		case BrokenStateEnum.ErrorsDetected:
			return "Damaged";
		case BrokenStateEnum.Broken:
			return "Destroyed";
		default:
			return "Working";
		}
	}

	public void AddDrone(Drone drone)
	{
		droneStateList.Add(new DroneState(drone));
		foreach (BaseDroneUpgrade upgrade in drone.Upgrades)
		{
			AddDroneUpgrade(upgrade);
		}
	}

	public void AddDroneUpgrade(BaseDroneUpgrade upgrade)
	{
		droneUpgradeStateList.Add(new DroneUpgradeState(upgrade));
	}

	public void AddShipUpgrade(BaseShipUpgrade upgrade)
	{
		shipUpgradeStateList.Add(new ShipUpgradeState(upgrade));
	}
}
