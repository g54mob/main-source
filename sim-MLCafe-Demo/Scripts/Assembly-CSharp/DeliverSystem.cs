using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class DeliverSystem : MonoBehaviour
{
	[SerializeField]
	private GameObject packagePrefab;

	[SerializeField]
	private Transform spawnPoint;

	[SerializeField]
	private GameTime deliverTime_1;

	[SerializeField]
	private GameTime deliverTime_2;

	[SerializeField]
	private string soundDeliveryArrived;

	private List<DeliveryDepotComponent> deliveryDepotComponents = new List<DeliveryDepotComponent>();

	private int packagesInTransport;

	[SerializeField]
	private int deliveryDurationInHours = 2;

	private List<GameTime> deliveryTimes = new List<GameTime>();

	public static UnityEvent<int> OnActiveDeliveryPackagesChanges = new UnityEvent<int>();

	public static UnityEvent OnDeliveryArrives = new UnityEvent();

	private static DeliverSystem instance;

	public void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			UnityEngine.Object.Destroy(this);
		}
		UnityEngine.Object.DontDestroyOnLoad(instance);
	}

	private void Start()
	{
	}

	public static void ReloadSystem()
	{
		instance.deliveryDepotComponents = UnityEngine.Object.FindObjectsByType<DeliveryDepotComponent>(FindObjectsSortMode.InstanceID).ToList();
		instance.packagesInTransport = 0;
		for (int i = 0; i < instance.deliveryDepotComponents.Count; i++)
		{
			instance.packagesInTransport += instance.deliveryDepotComponents[i].GetCurrentPackageCount();
		}
		OnActiveDeliveryPackagesChanges.Invoke(instance.packagesInTransport);
	}

	public static void RegisterDeliveryDepotSlot(DeliveryDepotComponent slot)
	{
		instance.deliveryDepotComponents.Add(slot);
		OnActiveDeliveryPackagesChanges.Invoke(instance.packagesInTransport);
	}

	public static void UnregisterDeliveryDepotSlot(DeliveryDepotComponent slot)
	{
		instance.deliveryDepotComponents.Remove(slot);
		OnActiveDeliveryPackagesChanges.Invoke(instance.packagesInTransport);
	}

	public static bool IsDepotRegistered(DeliveryDepotComponent slot)
	{
		return instance.deliveryDepotComponents.Contains(slot);
	}

	public static int GetRegisteredDepotCount()
	{
		return instance.deliveryDepotComponents.Count;
	}

	public static int GetMaxPackageCapacity()
	{
		return instance.packagePrefab.GetComponent<DeliveryPackage>().GetPackageCapacity();
	}

	public static int GetCurrentlyActivePackageCount()
	{
		return instance.packagesInTransport;
	}

	public static int GetDepotCapacity()
	{
		int num = 0;
		for (int i = 0; i < instance.deliveryDepotComponents.Count; i++)
		{
			num += instance.deliveryDepotComponents[i].GetSocketCount();
		}
		return num;
	}

	public static GameTime GetNextDayDeliveryTime()
	{
		return instance.deliverTime_1;
	}

	public static GameTime GetNextDeliveryTime()
	{
		if (instance.deliveryTimes.Count > 0)
		{
			return instance.deliveryTimes[0];
		}
		return WorldTime.GetGlobalTime();
	}

	public static void InitDeliveryTimeEvent(GameTime orderTime, PlacedOrder order)
	{
		GameTime deliveryTime = orderTime;
		deliveryTime.hour += (byte)Mathf.RoundToInt((float)instance.deliveryDurationInHours * AnomalyManager.GetAnomalyProperties().shop_delivery_duration);
		if (deliveryTime.hour >= WorldTime.GetStopTime() || (deliveryTime.hour >= 0 && deliveryTime.hour <= WorldTime.instance.startTime.hour) || deliveryTime.hour < (byte)instance.deliveryDurationInHours || GameTime.IsPastTime(orderTime, WorldTime.GetEndOfWorkDayTime()))
		{
			deliveryTime = instance.deliverTime_1;
		}
		instance.deliveryTimes.Add(deliveryTime);
		instance.packagesInTransport += order.packages;
		WorldTime.CreateNewTriggerMoment(new TimeTriggerEvent("Delivery: " + (order.itemIds.Length + order.totalPrice) + orderTime.hour + orderTime.minute, triggerOnce: true, deliveryTime, delegate
		{
			instance.DeliverOrders(order);
			OrderManager.RemoveOrder(order);
			instance.deliveryTimes.Remove(deliveryTime);
			OnDeliveryArrives.Invoke();
		}));
		OnActiveDeliveryPackagesChanges.Invoke(instance.packagesInTransport);
	}

	public static void TakeDeliveredPackage(int amount)
	{
		instance.packagesInTransport -= amount;
		if (instance.packagesInTransport < 0)
		{
			instance.packagesInTransport = 0;
		}
		OnActiveDeliveryPackagesChanges.Invoke(instance.packagesInTransport);
	}

	private void DeliverOrders(PlacedOrder currentOrder)
	{
		DeliveryPackage currentPackage = null;
		Transform transform = null;
		foreach (ItemInfo.ItemType value in Enum.GetValues(typeof(ItemInfo.ItemType)))
		{
			for (int i = 0; i < currentOrder.itemIds.Length; i++)
			{
				DeliveryDepotComponent freeDepot = deliveryDepotComponents.FirstOrDefault((DeliveryDepotComponent x) => !x.DepotIsFull());
				if (freeDepot == null)
				{
					return;
				}
				if (transform == null)
				{
					transform = freeDepot.transform;
				}
				if (InventorySystem.GetItemLibrary().itemInfos[currentOrder.itemIds[i]].itemType != value)
				{
					continue;
				}
				if (currentPackage == null || currentPackage.IsFull())
				{
					currentPackage = SpawnPackage(ref currentPackage, ref freeDepot);
				}
				for (int num = 0; num < currentOrder.amounts[i]; num++)
				{
					if (!currentPackage.SpawnItemInsidePackage(currentOrder.itemIds[i], currentOrder.amounts[i]))
					{
						currentPackage = SpawnPackage(ref currentPackage, ref freeDepot, spawnInsidePackage: true, currentOrder.itemIds[i], currentOrder.amounts[i]);
					}
				}
			}
		}
		SoundManager.PlaySoundOnce(soundDeliveryArrived, (transform != null) ? transform : base.transform);
	}

	private DeliveryPackage SpawnPackage(ref DeliveryPackage currentPackage, ref DeliveryDepotComponent freeDepot, bool spawnInsidePackage = false, int itemId = -1, int amount = -1)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(packagePrefab, freeDepot.transform);
		gameObject.transform.position = freeDepot.transform.position;
		currentPackage = gameObject.GetComponent<DeliveryPackage>();
		if (spawnInsidePackage)
		{
			currentPackage.SpawnItemInsidePackage(itemId, amount);
		}
		gameObject.SetActive(value: false);
		Debug.Log("Spawn Package!");
		if (!freeDepot.TryDeliverPackage(currentPackage))
		{
			Debug.LogError("DELIVERY FAILED - Could not deliver properly");
			return null;
		}
		return currentPackage;
	}
}
