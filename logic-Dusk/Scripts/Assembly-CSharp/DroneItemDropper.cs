using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DroneItemDropper : MonoBehaviour
{
	public static DroneItemDropper Instance = null;

	public static Dictionary<DropItemType, List<DropableItem>> DroppedItemDict = new Dictionary<DropItemType, List<DropableItem>>();

	public GameObject sensorPrefab;

	public GameObject trapPrefab;

	public GameObject stunPrefab;

	public GameObject minePrefab;

	public GameObject lurePrefab;

	public GameObject probePrefab;

	private Drone drone;

	public static int KnownSensorCount { get; private set; }

	public static int KnownTrapCount { get; private set; }

	public static int KnownMineCount { get; private set; }

	public static int KnownStunCount { get; private set; }

	public static int KnownLureCount { get; private set; }

	public static int KnownProbeCount { get; private set; }

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		drone = (Drone)GetComponent(typeof(Drone));
	}

	private void Update()
	{
	}

	public DropableItem Drop(DropItemType dropType, IDropperUpgrade dropperUpgrade, Vector3 dropPosition, Room destRoom)
	{
		DropableItem dropableItem = null;
		if (dropPosition == Vector3.zero)
		{
			dropPosition = drone.Position;
		}
		if (destRoom == null)
		{
			destRoom = drone.CurrentRoom;
		}
		switch (dropType)
		{
		case DropItemType.Sensor:
		{
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(sensorPrefab, dropPosition, Quaternion.identity);
			SensorItem sensorItem = (SensorItem)gameObject.GetComponent(typeof(SensorItem));
			sensorItem.Initialize(destRoom);
			dropableItem = sensorItem;
			KnownSensorCount++;
			break;
		}
		case DropItemType.Trap:
		{
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(trapPrefab, dropPosition, Quaternion.identity);
			TrapItem trapItem = (TrapItem)gameObject.GetComponent(typeof(TrapItem));
			trapItem.Initialize(destRoom, drone);
			dropableItem = trapItem;
			KnownTrapCount++;
			break;
		}
		case DropItemType.StunBomb:
		{
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(stunPrefab, dropPosition, Quaternion.identity);
			StunItem stunItem = (StunItem)gameObject.GetComponent(typeof(StunItem));
			stunItem.Initialize(destRoom, drone);
			dropableItem = stunItem;
			KnownStunCount++;
			break;
		}
		case DropItemType.ProximityMine:
		{
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(minePrefab, dropPosition, Quaternion.identity);
			ProximityMineItem proximityMineItem = (ProximityMineItem)gameObject.GetComponent(typeof(ProximityMineItem));
			proximityMineItem.Initialize(destRoom, drone);
			dropableItem = proximityMineItem;
			KnownMineCount++;
			break;
		}
		case DropItemType.Lure:
		{
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(lurePrefab, dropPosition, Quaternion.identity);
			LureItem lureItem = (LureItem)gameObject.GetComponent(typeof(LureItem));
			lureItem.Initialize(destRoom, drone.CurrentCorridor);
			dropableItem = lureItem;
			KnownLureCount++;
			break;
		}
		case DropItemType.Probe:
		{
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(probePrefab, dropPosition, Quaternion.identity);
			ProbeItem probeItem = (ProbeItem)gameObject.GetComponent(typeof(ProbeItem));
			probeItem.Initialize(destRoom, drone.CurrentCorridor);
			dropableItem = probeItem;
			KnownProbeCount++;
			break;
		}
		}
		if (dropableItem != null)
		{
			dropableItem.DroppingUpgrade = dropperUpgrade;
			if (!DroppedItemDict.ContainsKey(dropType))
			{
				DroppedItemDict.Add(dropType, new List<DropableItem>());
			}
			DroppedItemDict[dropType].Add(dropableItem);
			dropableItem.UpdateCameraView();
			if (dropperUpgrade is BaseDroneUpgrade)
			{
				dropableItem.ParentAppliedModifications = ((BaseDroneUpgrade)dropperUpgrade).AppliedModifications;
			}
			dropableItem.DroneItemDropperUpgrade = this;
			if (SchematicViewCanvas.Instance != null)
			{
				SchematicViewCanvas.Instance.RefreshDrone(drone.DroneNumber);
			}
			if (DroneManager.Instance.currentDronePanel != null && DroneManager.Instance.CurrentDrone == drone)
			{
				DroneManager.Instance.currentDronePanel.UpgradesChanged = true;
			}
		}
		return dropableItem;
	}

	public int Pickup(DropItemType dropType, IDropperUpgrade dropperUpgrade, out List<DropableItem> pickedUpItems)
	{
		int failedPickupTest = 0;
		return Pickup(dropType, dropperUpgrade, out pickedUpItems, null, out failedPickupTest);
	}

	public int Pickup(DropItemType dropType, IDropperUpgrade dropperUpgrade, out List<DropableItem> pickedUpItems, Predicate<DropableItem> canPickupItem, out int failedPickupTest)
	{
		pickedUpItems = new List<DropableItem>();
		int num = 0;
		failedPickupTest = 0;
		if (DroppedItemDict.ContainsKey(dropType))
		{
			bool flag = false;
			pickedUpItems = new List<DropableItem>();
			foreach (DropableItem item in DroppedItemDict[dropType].ToList())
			{
				if (item == null)
				{
					Debug.Log("Early null error");
				}
				DropableItem dropableItem = item;
				bool flag2 = canPickupItem == null || canPickupItem(dropableItem);
				flag = ((!flag) ? flag2 : flag);
				if (!dropableItem.Destroyed && flag2)
				{
					float num2 = Vector3.Distance(drone.transform.position, item.transform.position);
					if (num2 < 2f)
					{
						num++;
						item.SetDeactivated();
						if (item is ICombatTarget)
						{
							((ICombatTarget)item).TakeDamage(1000000f, DamageType.Physical, null);
						}
						pickedUpItems.Add(item);
						DroppedItemDict[dropType].Remove(item);
						if (GlobalSettings.cameraMode == CameraMode.Schematic)
						{
							DungeonManager.Instance.PlayPickupSound();
						}
						else if (drone != null)
						{
							drone.PlayPickupSound();
						}
						if (SchematicViewCanvas.Instance != null)
						{
							SchematicViewCanvas.Instance.RefreshDrone(drone.DroneNumber);
						}
						if (DroneManager.Instance.currentDronePanel != null && DroneManager.Instance.CurrentDrone == drone)
						{
							DroneManager.Instance.currentDronePanel.UpgradesChanged = true;
						}
						switch (dropType)
						{
						case DropItemType.Lure:
							KnownLureCount--;
							break;
						case DropItemType.Probe:
							KnownProbeCount--;
							break;
						case DropItemType.ProximityMine:
							KnownMineCount--;
							break;
						case DropItemType.Sensor:
							KnownSensorCount--;
							break;
						case DropItemType.StunBomb:
							KnownStunCount--;
							break;
						case DropItemType.Trap:
							KnownTrapCount--;
							break;
						}
					}
				}
				else
				{
					failedPickupTest++;
				}
			}
			if (num == 0 && !flag)
			{
				drone.SendConsoleMessage("Nothing to pickup", ConsoleMessageType.Info);
			}
		}
		return num;
	}

	public bool AnyItemsInRange(DropItemType dropType, IDropperUpgrade dropperUpgrade)
	{
		if (DroppedItemDict.ContainsKey(dropType))
		{
			foreach (DropableItem item in DroppedItemDict[dropType])
			{
				if (!item.Destroyed && drone != null && item != null)
				{
					float num = Vector3.Distance(drone.transform.position, item.transform.position);
					if (num < 2f)
					{
						return true;
					}
				}
			}
		}
		return false;
	}
}
