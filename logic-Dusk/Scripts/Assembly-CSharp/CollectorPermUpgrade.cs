using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CollectorPermUpgrade : BaseShipUpgrade
{
	public static CollectorPermUpgrade Instance;

	private List<LootItem> collectedScrap;

	private List<ProbeItem> collectedProbes;

	private Dictionary<DropItemType, List<DropableItem>> collectedDroppableItems;

	private int countCollectedFleetDrones;

	private int countCollectedLootableDrones;

	private int countCollectedScrap;

	private int countCollectedProbes;

	private int countCollectedLure;

	private int countCollectedMine;

	private int countCollectedTrap;

	private int countCollectedStun;

	public override ShipUpgradeType UpgradeType
	{
		get
		{
			return ShipUpgradeType.PermCollector;
		}
	}

	public override bool IsPermanentUpgrade
	{
		get
		{
			return true;
		}
	}

	public override string Name
	{
		get
		{
			return "Collector";
		}
	}

	public override string Description
	{
		get
		{
			return "Attempts to collect expelled objects";
		}
	}

	public override string CommandValue
	{
		get
		{
			return "collector";
		}
	}

	public List<Drone> collectedFleetDrones { get; private set; }

	public List<Drone> collectedLootableDrones { get; private set; }

	public List<IDrone> collectedIDrones { get; private set; }

	public CollectorPermUpgrade(int id)
		: base(id)
	{
		Instance = this;
	}

	protected override void OnInitialize()
	{
		collectedScrap = null;
		collectedProbes = null;
		collectedFleetDrones = null;
		collectedLootableDrones = null;
		collectedDroppableItems = null;
		countCollectedFleetDrones = 0;
		countCollectedLootableDrones = 0;
		countCollectedScrap = 0;
		countCollectedProbes = 0;
		countCollectedLure = 0;
		countCollectedMine = 0;
		countCollectedTrap = 0;
		countCollectedStun = 0;
		base.OnInitialize();
	}

	protected override void OnUpdate()
	{
		base.OnUpdate();
	}

	private bool CanCollect()
	{
		if (Random.Range(0, 101) <= 30)
		{
			return true;
		}
		return false;
	}

	public bool CollectProbe(ProbeItem probe)
	{
		if (CanCollect())
		{
			if (collectedProbes == null)
			{
				collectedProbes = new List<ProbeItem>();
			}
			collectedProbes.Add(probe);
			SystemMessageManager.ShowSystemMessage("Probe collected from external environment", ConsoleMessageType.Benefit);
			return true;
		}
		return false;
	}

	public bool CollectFleetDrone(Drone drone)
	{
		if (CanCollect())
		{
			if (!drone.IsDead || drone.CanBeTowed)
			{
				if (collectedFleetDrones == null)
				{
					collectedFleetDrones = new List<Drone>();
				}
				if (collectedIDrones == null)
				{
					collectedIDrones = new List<IDrone>();
				}
				IDrone drone2 = GlobalSettings.GameState.ThePlayer.Drones.FirstOrDefault((IDrone x) => x.DroneNumber == drone.DroneNumber);
				if (drone2 != null)
				{
					collectedIDrones.Add(drone2);
				}
				collectedFleetDrones.Add(drone);
				SystemMessageManager.ShowSystemMessage("Drone collected from external environment", ConsoleMessageType.Benefit);
				return true;
			}
			return false;
		}
		return false;
	}

	public bool CollectLootableDrone(Drone drone)
	{
		if (CanCollect())
		{
			if (!drone.IsDead || drone.CanBeTowed)
			{
				if (collectedLootableDrones == null)
				{
					collectedLootableDrones = new List<Drone>();
				}
				collectedLootableDrones.Add(drone);
				SystemMessageManager.ShowSystemMessage("Drone collected from external environment", ConsoleMessageType.Benefit);
				return true;
			}
			return false;
		}
		return false;
	}

	public bool CollectScrap(LootItem scrap)
	{
		if (CanCollect())
		{
			if (collectedScrap == null)
			{
				collectedScrap = new List<LootItem>();
			}
			collectedScrap.Add(scrap);
			countCollectedScrap++;
			SystemMessageManager.ShowSystemMessage("Scrap collected from external environment", ConsoleMessageType.Benefit);
			return true;
		}
		return false;
	}

	public bool CollectDroppableItem(DropableItem item)
	{
		if (CanCollect())
		{
			if (collectedDroppableItems == null)
			{
				collectedDroppableItems = new Dictionary<DropItemType, List<DropableItem>>();
			}
			if (!collectedDroppableItems.ContainsKey(item.DropType))
			{
				collectedDroppableItems.Add(item.DropType, new List<DropableItem>());
			}
			collectedDroppableItems[item.DropType].Add(item);
			SystemMessageManager.ShowSystemMessage("Item collected from external environment", ConsoleMessageType.Benefit);
			return true;
		}
		return false;
	}

	public void ReclaimCollectedItems()
	{
		if (collectedFleetDrones != null && collectedFleetDrones.Count > 0)
		{
			List<int> list = new List<int>();
			foreach (IDrone collectedIDrone in collectedIDrones)
			{
				int count = collectedFleetDrones.Count;
				for (int num = count - 1; num >= 0; num--)
				{
					if (collectedFleetDrones[num].DroneNumber == collectedIDrone.DroneNumber)
					{
						if (!DroneManager.Instance.dronesList.Contains(collectedFleetDrones[num]))
						{
							DroneManager.Instance.dronesList.Add(collectedFleetDrones[num]);
						}
						GlobalSettings.GameState.ThePlayer.Drones.Add(collectedIDrone);
						list.Add(num);
						countCollectedFleetDrones++;
						break;
					}
				}
			}
		}
		if (collectedLootableDrones != null && collectedLootableDrones.Count > 0)
		{
			int count2 = collectedLootableDrones.Count;
			for (int num2 = count2 - 1; num2 >= 0; num2--)
			{
				Drone item = collectedLootableDrones[num2];
				if (!DroneManager.Instance.LootableDronesList.Contains(item))
				{
					DroneManager.Instance.LootableDronesList.Add(item);
					countCollectedLootableDrones++;
				}
			}
		}
		if (collectedProbes != null && collectedProbes.Count > 0)
		{
			foreach (ProbeItem collectedProbe in collectedProbes)
			{
				ProbeItem probeItem = collectedProbe;
				if (!probeItem.IsDead)
				{
					ProbeUpgrade probeUpgrade = (ProbeUpgrade)probeItem.DroppingUpgrade;
					if (probeUpgrade.Quantity < probeUpgrade.Capacity)
					{
						probeUpgrade.AddItem(1);
						countCollectedProbes++;
					}
				}
			}
		}
		if (collectedScrap != null)
		{
			GathererUpgrade gathererUpgrade = null;
			foreach (Drone drones in DroneManager.Instance.dronesList)
			{
				if (!(drones != null) || (drones.IsDead && !drones.CanBeTowed) || drones.Upgrades == null)
				{
					continue;
				}
				foreach (BaseDroneUpgrade upgrade in drones.Upgrades)
				{
					if (upgrade is GathererUpgrade)
					{
						gathererUpgrade = (GathererUpgrade)upgrade;
						break;
					}
				}
			}
			if (gathererUpgrade != null)
			{
				foreach (LootItem item2 in collectedScrap)
				{
					gathererUpgrade.ExternalScrapAdd(item2);
				}
			}
		}
		if (collectedDroppableItems == null)
		{
			return;
		}
		Dictionary<DropItemType, List<DropableItem>>.Enumerator enumerator6 = collectedDroppableItems.GetEnumerator();
		while (enumerator6.MoveNext())
		{
			foreach (DropableItem item3 in enumerator6.Current.Value)
			{
				item3.DroppingUpgrade.ExternalAdd();
				switch (item3.DropType)
				{
				case DropItemType.Lure:
					countCollectedLure++;
					break;
				case DropItemType.ProximityMine:
					countCollectedMine++;
					break;
				case DropItemType.StunBomb:
					countCollectedStun++;
					break;
				case DropItemType.Trap:
					countCollectedTrap++;
					break;
				}
			}
		}
	}

	public string GetMissionStatusString()
	{
		string text = string.Empty;
		int num = 0;
		if (countCollectedFleetDrones > 0)
		{
			if (!string.IsNullOrEmpty(text))
			{
				if (num >= 3)
				{
					num = 0;
					text += "</color>\r\n>     <color=#8ed0ff>";
				}
				else
				{
					text += ", ";
				}
			}
			text = text + "Fleet Drones: " + countCollectedFleetDrones;
			num++;
		}
		if (countCollectedLootableDrones > 0)
		{
			if (!string.IsNullOrEmpty(text))
			{
				if (num >= 3)
				{
					num = 0;
					text += "</color>\r\n>     <color=#8ed0ff>";
				}
				else
				{
					text += ", ";
				}
			}
			text = text + "Extra Drones: " + countCollectedLootableDrones;
			num++;
		}
		if (countCollectedScrap > 0)
		{
			if (!string.IsNullOrEmpty(text))
			{
				if (num >= 3)
				{
					num = 0;
					text += "</color>\r\n>     <color=#8ed0ff>";
				}
				else
				{
					text += ", ";
				}
			}
			text = text + "Scrap: " + countCollectedScrap;
			num++;
		}
		if (countCollectedLure > 0)
		{
			if (!string.IsNullOrEmpty(text))
			{
				if (num >= 3)
				{
					num = 0;
					text += "</color>\r\n>     <color=#8ed0ff>";
				}
				else
				{
					text += ", ";
				}
			}
			text = text + "Lure: " + countCollectedLure;
			num++;
		}
		if (countCollectedMine > 0)
		{
			if (!string.IsNullOrEmpty(text))
			{
				if (num >= 3)
				{
					num = 0;
					text += "</color>\r\n>     <color=#8ed0ff>";
				}
				else
				{
					text += ", ";
				}
			}
			text = text + "Mine: " + countCollectedMine;
			num++;
		}
		if (countCollectedStun > 0)
		{
			if (!string.IsNullOrEmpty(text))
			{
				if (num >= 3)
				{
					num = 0;
					text += "</color>\r\n>     <color=#8ed0ff>";
				}
				else
				{
					text += ", ";
				}
			}
			text = text + "Stun: " + countCollectedStun;
			num++;
		}
		if (countCollectedTrap > 0)
		{
			if (!string.IsNullOrEmpty(text))
			{
				if (num >= 3)
				{
					num = 0;
					text += "</color>\r\n>     <color=#8ed0ff>";
				}
				else
				{
					text += ", ";
				}
			}
			text = text + "Trap: " + countCollectedTrap;
			num++;
		}
		if (collectedProbes != null && collectedProbes.Count > 0)
		{
			if (!string.IsNullOrEmpty(text))
			{
				if (num >= 3)
				{
					num = 0;
					text += "</color>\r\n>     <color=#8ed0ff>";
				}
				else
				{
					text += ", ";
				}
			}
			text = text + "Probes: " + collectedProbes.Count;
			num++;
		}
		if (!string.IsNullOrEmpty(text))
		{
			text = "> <color=#FFF000>Collector Ship Upgrade prevented the following loss:</color>\r\n>     <color=#8ed0ff>" + text + "</color>\r\n>\r\n";
		}
		return text;
	}
}
