using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class CafeShopManager : MonoBehaviour
{
	private string cafeName = "Been Ol Bony";

	public static UnityEvent<string> OnLoadShopName = new UnityEvent<string>();

	[SerializeField]
	private List<ServiceCounterComponent> registeredServiceCounter = new List<ServiceCounterComponent>();

	[SerializeField]
	private List<CustomerUseableComponent> registeredServiceSeatings = new List<CustomerUseableComponent>();

	[SerializeField]
	private List<CustomerUseableComponent> registeredServiceTables = new List<CustomerUseableComponent>();

	[SerializeField]
	private List<AmbientComponent> registeredAmbientObjects = new List<AmbientComponent>();

	[SerializeField]
	private Transform entrancePointInside;

	[SerializeField]
	private Transform entrancePointOutside;

	[SerializeField]
	private int dailyUpkeep = 25;

	private int componentUpkeep;

	private int roomUpkeep;

	public int baseUpkeepPerRoom = 5;

	public int roomBuildCost = 499;

	public int roomCount;

	[SerializeField]
	private List<UpkeepComponent> registeredUpkeepComponents = new List<UpkeepComponent>();

	public static UnityEvent<int> OnUpkeepChanged = new UnityEvent<int>();

	public static UnityEvent<int> OnRoomUpkeepChanged = new UnityEvent<int>();

	public int turnOver;

	public int tips;

	public int deposits;

	public int extensionsAdded;

	public static UnityEvent OnTurnoverChanged = new UnityEvent();

	public static UnityEvent OnTipsChanged = new UnityEvent();

	public static UnityEvent OnDepositsChanged = new UnityEvent();

	public static UnityEvent<int> OnExtensionsChanged = new UnityEvent<int>();

	public static UnityEvent OnResetFinanceStats = new UnityEvent();

	[SerializeField]
	private CustomerRating cafeRating = CustomerRating.Start();

	public static UnityEvent<CustomerRating> OnCafeRatingChanged = new UnityEvent<CustomerRating>();

	private List<CustomerRating> ratings = new List<CustomerRating>();

	[SerializeField]
	private int RatingsNeededToUpdate = 5;

	private List<CustomerRating> lastRatings = new List<CustomerRating>();

	private List<CustomerCore> customersInsideCafe = new List<CustomerCore>();

	private bool cafeIsOpen;

	public static UnityEvent<bool> OnCafeStateChanged = new UnityEvent<bool>();

	public static UnityEvent OnNewCustomerArrived = new UnityEvent();

	public static UnityEvent OnCupWasTakenAway = new UnityEvent();

	public static UnityEvent OnUpdateCustomersInQueue = new UnityEvent();

	public List<TweenPlayer> entranceDoorPlayer = new List<TweenPlayer>();

	private bool entranceDoorOpen;

	private static CafeShopManager instance;

	public static int GetRoomBuildCost()
	{
		return instance.roomBuildCost;
	}

	public static void SetTurnOver(int value)
	{
		instance.turnOver = value;
		OnTurnoverChanged.Invoke();
	}

	public static void SetTips(int value)
	{
		instance.tips = value;
		OnTipsChanged.Invoke();
	}

	public static void SetDeposits(int value)
	{
		instance.deposits = value;
		OnDepositsChanged.Invoke();
	}

	public static void SetExtentionAdditions(int value)
	{
		instance.extensionsAdded = value;
		OnExtensionsChanged.Invoke(instance.extensionsAdded);
	}

	public static void ResetFinanceStats()
	{
		SetTurnOver(0);
		SetTips(0);
		SetDeposits(0);
		SetExtentionAdditions(0);
		OnResetFinanceStats.Invoke();
	}

	public static void AddTurnOver(int value)
	{
		instance.turnOver += value;
		OnTurnoverChanged.Invoke();
	}

	public static void AddTips(int value)
	{
		instance.tips += value;
		OnTipsChanged.Invoke();
	}

	public static void AddDeposits(int value)
	{
		instance.deposits += value;
		OnDepositsChanged.Invoke();
	}

	public static void AddExtensions(int value)
	{
		instance.extensionsAdded += value;
		OnExtensionsChanged.Invoke(instance.extensionsAdded);
	}

	public static string GetTurnOverNoTip()
	{
		return "   +" + instance.turnOver;
	}

	public static string GetTurnOverWithTip()
	{
		return (instance.turnOver + instance.tips).ToString();
	}

	public static string GetTurnoverSubtotal()
	{
		return (instance.turnOver + instance.tips + instance.deposits).ToString();
	}

	public static string GetTurnoverSummary()
	{
		int num = instance.turnOver + instance.tips + instance.deposits - instance.dailyUpkeep;
		if (num >= 0)
		{
			return "+<color=#6BFFE3>" + num + "</color>";
		}
		return "<color=red>" + num + "</color>";
	}

	public static string GetTips()
	{
		return "   +" + instance.tips;
	}

	public static string GetDepositTurnOver()
	{
		return "   +" + instance.deposits;
	}

	public static float GetDifficultyFactor()
	{
		return GameModeManager.GetGameModeValue<float>("gm_cafe_upkeep_factor");
	}

	public static int GetRentUpkeep()
	{
		return instance.roomUpkeep;
	}

	public static int GetSingleRoomRent()
	{
		return instance.baseUpkeepPerRoom;
	}

	public static List<UpkeepComponent> GetUpkeepComponents()
	{
		return instance.registeredUpkeepComponents;
	}

	public void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Object.Destroy(this);
		}
		Object.DontDestroyOnLoad(instance);
	}

	private void Start()
	{
		CustomerManager.OnUpdateCleanupState.AddListener(delegate
		{
			UpdateRating();
		});
		ShopBuilder.OnRoomCountChanged.AddListener(UpdateRoomUpkeep);
		UpdateRoomUpkeep();
		UpdateUpkeepComponentCount();
	}

	public static void ReloadSystem()
	{
		instance.registeredServiceCounter = new List<ServiceCounterComponent>();
		instance.registeredServiceSeatings = new List<CustomerUseableComponent>();
		instance.registeredServiceTables = new List<CustomerUseableComponent>();
		instance.registeredAmbientObjects = new List<AmbientComponent>();
		PlaceableRegisterComponent[] array = Object.FindObjectsByType<PlaceableRegisterComponent>(FindObjectsSortMode.InstanceID).ToArray();
		for (int i = 0; i < array.Length; i++)
		{
			switch (array[i].registrationType)
			{
			case PlaceableRegisterComponent.PlaceableRegistrationType.ServiceCounter:
				RegisterServiceCounter(array[i].GetComponent<ServiceCounterComponent>());
				break;
			case PlaceableRegisterComponent.PlaceableRegistrationType.Seat:
				RegisterSeat(array[i].GetComponent<CustomerUseableComponent>());
				break;
			case PlaceableRegisterComponent.PlaceableRegistrationType.Table:
				RegisterTable(array[i].GetComponent<CustomerUseableComponent>());
				break;
			}
		}
		instance.registeredAmbientObjects = Object.FindObjectsByType<AmbientComponent>(FindObjectsSortMode.InstanceID).ToList();
		instance.registeredUpkeepComponents = Object.FindObjectsByType<UpkeepComponent>(FindObjectsSortMode.InstanceID).ToList();
		UpdateRoomUpkeep();
		instance.UpdateUpkeepComponentCount();
	}

	public static int GetAmbientRating()
	{
		return GetCafeShopRating().ambient;
	}

	public static Transform GetEntrancePointInside()
	{
		return instance.entrancePointInside;
	}

	public static Transform GetEntrancePointOutside()
	{
		return instance.entrancePointOutside;
	}

	public static void UpdateCafeShopName(string name)
	{
		instance.cafeName = name;
		OnLoadShopName.Invoke(name);
	}

	public static string GetCafeShopName()
	{
		return instance.cafeName;
	}

	public static bool IsCafeOpen()
	{
		return instance.cafeIsOpen;
	}

	public static void OpenShop()
	{
		instance.cafeIsOpen = true;
		OnCafeStateChanged.Invoke(instance.cafeIsOpen);
	}

	public static void CloseShop()
	{
		instance.cafeIsOpen = false;
		OnCafeStateChanged.Invoke(instance.cafeIsOpen);
	}

	public static int GetDailyUpkeep()
	{
		return instance.dailyUpkeep;
	}

	public static void RegisterUpkeep(UpkeepComponent upkeep)
	{
		if (!instance.registeredUpkeepComponents.Contains(upkeep))
		{
			instance.registeredUpkeepComponents.Add(upkeep);
			instance.UpdateUpkeepComponentCount();
		}
	}

	public static void UnregisterUpkeep(UpkeepComponent upkeep)
	{
		if (!(instance == null) && instance.registeredUpkeepComponents != null && instance.registeredUpkeepComponents.Contains(upkeep))
		{
			instance.registeredUpkeepComponents.Remove(upkeep);
			instance.UpdateUpkeepComponentCount();
		}
	}

	private void UpdateUpkeepComponentCount()
	{
		componentUpkeep = 0;
		registeredUpkeepComponents = registeredUpkeepComponents.Where((UpkeepComponent x) => x != null).ToList();
		foreach (UpkeepComponent registeredUpkeepComponent in instance.registeredUpkeepComponents)
		{
			componentUpkeep += registeredUpkeepComponent.ampunt;
		}
		UpdateDailyUpkeep();
	}

	public static void UpdateRoomUpkeep()
	{
		instance.roomCount = ShopBuilder.GetRoomCount();
		instance.baseUpkeepPerRoom = GameModeManager.GetGameModeValue<int>("gm_cafe_upkeep_room");
		instance.roomUpkeep = instance.roomCount * instance.baseUpkeepPerRoom;
		OnRoomUpkeepChanged.Invoke(instance.roomUpkeep);
		instance.UpdateDailyUpkeep();
	}

	private void UpdateDailyUpkeep()
	{
		dailyUpkeep = componentUpkeep + roomUpkeep;
		OnUpkeepChanged.Invoke(instance.dailyUpkeep);
	}

	public static void IncreaseRoomUpkeep(int amount)
	{
		instance.roomCount++;
		instance.dailyUpkeep += amount;
		AddExtensions(instance.roomBuildCost);
		OnUpkeepChanged.Invoke(instance.dailyUpkeep);
	}

	public static void DecreaseRoomUpkeep(int amount)
	{
		instance.roomCount--;
		instance.dailyUpkeep -= amount;
		OnUpkeepChanged.Invoke(instance.dailyUpkeep);
	}

	public static void ApplyUpkeep()
	{
		WalletSystem.GetPlayerWallet().ForceRemoveAmount(instance.dailyUpkeep);
	}

	public static void SetCafeShopRating(CustomerRating rating)
	{
		instance.cafeRating = rating;
	}

	public static CustomerRating GetCafeShopRating()
	{
		return instance.cafeRating;
	}

	public void RateCafe(CustomerRating rating)
	{
		if (rating.gotServiced)
		{
			rating.cleanness = CustomerManager.GetCleanupRating();
			rating.ambient = (byte)GetAmbientRating();
			instance.ratings.Add(rating);
			instance.lastRatings.Add(rating);
		}
		if (instance.lastRatings.Count > instance.RatingsNeededToUpdate)
		{
			UpdateRating();
		}
	}

	private void UpdateRating()
	{
		int count = ratings.Count;
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		if (count == 0)
		{
			num = cafeRating.service;
			num2 = cafeRating.product;
			_ = cafeRating.ambient;
			num3 = CustomerManager.GetCleanupRating();
		}
		else
		{
			for (int i = 0; i < ratings.Count; i++)
			{
				num += ratings[i].service;
				num2 += ratings[i].product;
				num3 += ratings[i].cleanness;
			}
			num /= count;
			num2 /= count;
			num3 /= count;
		}
		cafeRating.service = (byte)num;
		cafeRating.product = (byte)num2;
		cafeRating.cleanness = num3;
		instance.lastRatings.Clear();
		OnCafeRatingChanged.Invoke(cafeRating);
	}

	public static void NewCustomerArrived(CustomerCore customer)
	{
		instance.customersInsideCafe.Add(customer);
		OnNewCustomerArrived.Invoke();
	}

	public static void CustomerLeft(CustomerCore customer)
	{
		instance.RateCafe(customer.GetRating());
		instance.customersInsideCafe.Remove(customer);
	}

	public static bool IsCustomerInsideCafe(CustomerCore customer)
	{
		return instance.customersInsideCafe.Find((CustomerCore x) => x == customer);
	}

	public static bool CustomersInCafe()
	{
		instance.customersInsideCafe.RemoveAll((CustomerCore x) => x.Equals(null));
		return instance.customersInsideCafe.Count > 0;
	}

	public static void ClearoutCustomers()
	{
		foreach (CustomerCore item in instance.customersInsideCafe)
		{
			instance.RateCafe(item.GetRating());
			CustomerManager.UnregisterCustomer(item);
		}
		CustomerManager.ResetCustomers();
		instance.customersInsideCafe.Clear();
	}

	public static void RegisterEntranceDoor(TweenPlayer doorPlayer)
	{
		if (!(doorPlayer == null) && !(instance == null))
		{
			instance.entranceDoorPlayer.Add(doorPlayer);
			instance.entranceDoorPlayer.RemoveAll((TweenPlayer x) => x.Equals(null));
		}
	}

	public static TweenPlayer GetNearestEntranceDoor(Vector3 position)
	{
		if (instance.entranceDoorPlayer.Count == 0)
		{
			return null;
		}
		float num = float.PositiveInfinity;
		TweenPlayer result = null;
		for (int i = 0; i < instance.registeredServiceTables.Count; i++)
		{
			float num2 = Vector3.Distance(instance.registeredServiceTables[i].transform.position, position);
			if (num2 < num)
			{
				num = num2;
				result = instance.entranceDoorPlayer[i];
			}
		}
		return result;
	}

	public static void TryOpenEntranceDoor()
	{
		if (instance.entranceDoorPlayer[0].PlayerState())
		{
			TweenerManager.StopTweenWithContainingKey("TryOpenEntranceDoor");
			TweenerManager.TweenTimeAction("TryOpenEntranceDoor", 4f, delegate
			{
				instance.entranceDoorPlayer.ForEach(delegate(TweenPlayer x)
				{
					x.OnReverse();
				});
			});
			return;
		}
		instance.entranceDoorPlayer.ForEach(delegate(TweenPlayer x)
		{
			x.OnPlay();
		});
		TweenerManager.StopTweenWithContainingKey("TryOpenEntranceDoor");
		TweenerManager.TweenTimeAction("TryOpenEntranceDoor", 4f, delegate
		{
			instance.entranceDoorPlayer.ForEach(delegate(TweenPlayer x)
			{
				x.OnReverse();
			});
		});
	}

	public static void OpenEntranceDoor()
	{
		instance.entranceDoorPlayer.ForEach(delegate(TweenPlayer x)
		{
			x.OnPlay();
		});
	}

	public static void CloseEntranceDoor()
	{
		instance.entranceDoorPlayer.ForEach(delegate(TweenPlayer x)
		{
			x.OnReverse();
		});
	}

	public static void RegisterServiceCounter(ServiceCounterComponent serviceCounter)
	{
		if (!(serviceCounter == null) && !(instance == null) && !instance.registeredServiceCounter.Contains(serviceCounter))
		{
			instance.registeredServiceCounter.Add(serviceCounter);
			instance.registeredServiceCounter = instance.registeredServiceCounter.Where((ServiceCounterComponent x) => x != null).ToList();
		}
	}

	public static void UnregisterServiceCounter(ServiceCounterComponent serviceCounter)
	{
		instance.registeredServiceCounter.Remove(serviceCounter);
	}

	public static ServiceCounterComponent GetNextFreeServiceCounter()
	{
		ServiceCounterComponent result = null;
		for (int i = 0; i < instance.registeredServiceCounter.Count; i++)
		{
			if (!(instance.registeredServiceCounter[i] == null) && instance.registeredServiceCounter[i].HasFreeQuelinePoint())
			{
				result = instance.registeredServiceCounter[i];
				break;
			}
		}
		return result;
	}

	public static int GetQueueLineOccupationCount()
	{
		int num = 0;
		for (int i = 0; i < instance.registeredServiceCounter.Count; i++)
		{
			num += instance.registeredServiceCounter[i].GetCustomerCountInQueue();
		}
		return num;
	}

	public static void RegisterSeat(CustomerUseableComponent seat)
	{
		if (!(seat == null) && !(instance == null))
		{
			instance.registeredServiceSeatings.Add(seat);
		}
	}

	public static void UnregisterSeat(CustomerUseableComponent seat)
	{
		instance.registeredServiceSeatings.Remove(seat);
	}

	public static CustomerUseableComponent GetNextFreeSeat()
	{
		if (instance.registeredServiceSeatings.Count == 0)
		{
			return null;
		}
		List<CustomerUseableComponent> list = instance.registeredServiceSeatings.Where((CustomerUseableComponent x) => !x.InUse()).ToList();
		if (list.Count == 0)
		{
			return null;
		}
		if (list.Count == 1)
		{
			return list[0];
		}
		return list[Random.Range(0, list.Count)];
	}

	public static void RegisterTable(CustomerUseableComponent table)
	{
		if (!(table == null) && !(instance == null))
		{
			instance.registeredServiceTables.Add(table);
		}
	}

	public static void UnregisterTable(CustomerUseableComponent table)
	{
		instance.registeredServiceTables.Remove(table);
	}

	public static TableComponent GetNearestTable(Vector3 pos)
	{
		if (instance.registeredServiceTables.Count == 0)
		{
			return null;
		}
		float num = float.PositiveInfinity;
		CustomerUseableComponent customerUseableComponent = null;
		for (int i = 0; i < instance.registeredServiceTables.Count; i++)
		{
			float num2 = Vector3.Distance(instance.registeredServiceTables[i].transform.position, pos);
			if (num2 < num)
			{
				num = num2;
				customerUseableComponent = instance.registeredServiceTables[i];
			}
		}
		return customerUseableComponent.GetComponent<TableComponent>();
	}

	public static void RegisterAmbientObject(AmbientComponent decoration)
	{
		instance.registeredAmbientObjects.Add(decoration);
		instance.CalcualteAmbientRating();
	}

	public static void UnregisterAmbientObject(AmbientComponent decoration)
	{
		instance.registeredAmbientObjects.Remove(decoration);
		instance.CalcualteAmbientRating();
	}

	private void CalcualteAmbientRating()
	{
		int num = 0;
		for (int i = 0; i < registeredAmbientObjects.Count; i++)
		{
			num += registeredAmbientObjects[i].rating;
		}
		if (num > 512)
		{
			num = 512;
		}
		float t = Mathf.InverseLerp(0f, 512f, num);
		byte ambient = (byte)Mathf.Lerp(0f, 255f, t);
		cafeRating.ambient = ambient;
		OnCafeRatingChanged.Invoke(cafeRating);
	}
}
