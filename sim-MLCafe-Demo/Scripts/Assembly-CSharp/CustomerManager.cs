using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class CustomerManager : MonoBehaviour
{
	public enum CleanupState
	{
		Clean = 0,
		Normal = 1,
		Average = 2,
		Dirty = 3,
		Rotten = 4
	}

	[SerializeField]
	private CustomerLibrary library;

	[SerializeField]
	private Transform entityContainer;

	[SerializeField]
	private Transform[] spawnPoints;

	[SerializeField]
	private Transform fallbackSpawnPoint;

	[SerializeField]
	[Range(1f, 6f)]
	private int spawnsPerHours = 3;

	[SerializeField]
	[Range(1f, 100f)]
	private float spawnCustomerChance = 50f;

	private int spawnedThisHour;

	[SerializeField]
	private int maxCustomerCount;

	private int currentCount;

	public static UnityEvent<int> OnUpdateMaxCustomerCapacity = new UnityEvent<int>();

	public static UnityEvent<CleanupState> OnUpdateCleanupState = new UnityEvent<CleanupState>();

	public static UnityEvent<CustomerCore> OnCustomerSpawned = new UnityEvent<CustomerCore>();

	public static UnityEvent<CustomerCore> OnCustomerDestroyed = new UnityEvent<CustomerCore>();

	private List<CustomerCore> customerInstances = new List<CustomerCore>();

	private static CustomerManager instance;

	public CleanupState cleanupState;

	private List<DirtComponent> dirtInstances = new List<DirtComponent>();

	private List<Dirt> dirtStats = new List<Dirt>();

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
		WorldTime.instance.OnTick.AddListener(EvaluateCustomerSpawn);
		WorldTime.instance.OnHourlyTick.AddListener(ResetHourlySpawn);
		spawnsPerHours = Mathf.RoundToInt((float)GameModeManager.GetGameModeValue<int>("gm_customer_spawn_rate") * AnomalyManager.GetAnomalyProperties().customer_spawnrate_multiplier);
		spawnCustomerChance = GameModeManager.GetGameModeValue<float>("gm_customer_spawn_chance") * AnomalyManager.GetAnomalyProperties().customer_spawnrate_multiplier;
		OnUpdateMaxCustomerCapacity.Invoke(maxCustomerCount);
	}

	public static void ReloadSystem()
	{
		instance.dirtInstances.Clear();
		instance.dirtStats.Clear();
		List<DirtComponent> list = Object.FindObjectsByType<DirtComponent>(FindObjectsSortMode.InstanceID).ToList();
		for (int i = 0; i < list.Count; i++)
		{
			RegisterDirtObstacle(list[i]);
		}
		CupComponent[] array = (from x in Object.FindObjectsByType<CupComponent>(FindObjectsSortMode.InstanceID).ToList()
			where x.IsDirty()
			select x).ToArray();
		for (int num = 0; num < array.Length; num++)
		{
			array[num].MarkDirty();
		}
		instance.EvaluateCleanupState();
	}

	public static string GetRandomNameKey()
	{
		return "";
	}

	public static Color GetCustomerNameColor()
	{
		return Color.white;
	}

	public static int GetMaxCapacity()
	{
		return instance.maxCustomerCount;
	}

	public static int GetCleanupMax()
	{
		return 64;
	}

	public static int GetCleanupMin()
	{
		return -64;
	}

	public static int GetCleanupRating()
	{
		return instance.cleanupState switch
		{
			CleanupState.Clean => 64, 
			CleanupState.Normal => 32, 
			CleanupState.Average => 0, 
			CleanupState.Dirty => -32, 
			CleanupState.Rotten => -64, 
			_ => 0, 
		};
	}

	public static CleanupState GetCleanupState()
	{
		return instance.cleanupState;
	}

	public static int GetDirtStat(Dirt.DirtType dirtType)
	{
		if (instance == null)
		{
			return 0;
		}
		if (instance.dirtStats == null)
		{
			return 0;
		}
		if (instance.dirtStats.Count == 0)
		{
			return 0;
		}
		return instance.dirtStats.Where((Dirt x) => x != null && x.dirtType == dirtType).ToArray().Length;
	}

	public static void AddDirtStat(Dirt dirt)
	{
		instance.dirtStats.Add(dirt);
		instance.EvaluateCleanupState();
	}

	public static void RemoveDirtStat(Dirt dirt)
	{
		instance.dirtStats.Remove(dirt);
		instance.EvaluateCleanupState();
	}

	private void EvaluateCleanupState()
	{
		if (GetSensitivity(instance.dirtStats.Count, 5))
		{
			cleanupState = CleanupState.Clean;
		}
		else if (GetSensitivity(instance.dirtStats.Count, 10))
		{
			cleanupState = CleanupState.Normal;
		}
		else if (GetSensitivity(instance.dirtStats.Count, 15))
		{
			cleanupState = CleanupState.Average;
		}
		else if (GetSensitivity(instance.dirtStats.Count, 25))
		{
			cleanupState = CleanupState.Dirty;
		}
		else if (GetSensitivity(instance.dirtStats.Count, 40))
		{
			cleanupState = CleanupState.Rotten;
		}
		OnUpdateCleanupState.Invoke(cleanupState);
		static bool GetSensitivity(int current, int compare)
		{
			return current <= Mathf.RoundToInt((float)compare * GameModeManager.GetGameModeValue<float>("gm_cafe_hygiene_sensitivity"));
		}
	}

	private void ResetHourlySpawn()
	{
		spawnedThisHour = 0;
	}

	public void EvaluateCustomerSpawn()
	{
		if (!CafeShopManager.IsCafeOpen() || ProductManager.GetSellingProductList().Count == 0)
		{
			return;
		}
		float t = Mathf.InverseLerp(0f, 5f, CafeShopManager.GetCafeShopRating().GetStarRating());
		float num = Mathf.Lerp(-5f, 5f, t);
		int num2 = maxCustomerCount + (int)((float)maxCustomerCount * (num * 0.5f));
		if (num2 < (int)((float)maxCustomerCount * 0.5f))
		{
			num2 = (int)((float)maxCustomerCount * 0.5f);
		}
		if (currentCount >= num2)
		{
			return;
		}
		int num3 = spawnsPerHours + (int)((float)spawnsPerHours * (num * 0.5f));
		if (num3 < (int)((float)spawnsPerHours * 0.5f))
		{
			num3 = (int)((float)spawnsPerHours * 0.5f);
		}
		if (spawnedThisHour <= num3)
		{
			int num4 = Random.Range(0, 100);
			if (!(spawnCustomerChance + Mathf.Lerp(-25f, 25f, t) < (float)num4))
			{
				SpawnCustomer();
			}
		}
	}

	private void SpawnCustomer()
	{
		List<Customer> validCustomersByProgress = library.GetValidCustomersByProgress(1);
		int num = Random.Range(0, 100);
		Customer customer = null;
		foreach (Customer item in validCustomersByProgress)
		{
			if (customer == null)
			{
				customer = item;
			}
			else if (item.spawnChance < (float)num && item.spawnChance > customer.spawnChance)
			{
				customer = item;
			}
		}
		GameObject gameObject = Object.Instantiate(customer.prefab, entityContainer);
		CustomerCore component = gameObject.GetComponent<CustomerCore>();
		if (spawnPoints.Length != 0)
		{
			int num2 = Random.Range(0, spawnPoints.Length);
			gameObject.transform.position = spawnPoints[num2].position;
			component.ApplySpawnPoint(spawnPoints[num2]);
		}
		else
		{
			gameObject.transform.position = fallbackSpawnPoint.position;
			component.ApplySpawnPoint(fallbackSpawnPoint);
		}
		component.Init();
		RegisterCustomer(component);
		OnCustomerSpawned.Invoke(component);
		currentCount++;
		spawnedThisHour++;
	}

	public static void ResetCustomers()
	{
		foreach (CustomerCore customerInstance in instance.customerInstances)
		{
			if (!(customerInstance == null))
			{
				OnCustomerDestroyed.Invoke(customerInstance);
				Object.Destroy(customerInstance.gameObject);
			}
		}
		instance.customerInstances.Clear();
	}

	public static void RegisterCustomer(CustomerCore customer)
	{
		if (!(instance == null))
		{
			instance.customerInstances.Add(customer);
		}
	}

	public static void UnregisterCustomer(CustomerCore customer)
	{
		instance.customerInstances.Remove(customer);
		OnCustomerDestroyed.Invoke(customer);
		Object.Destroy(customer.gameObject);
		instance.currentCount--;
	}

	public static void RegisterDirtObstacle(DirtComponent dirtObject)
	{
		if (!(instance == null))
		{
			instance.dirtInstances.Add(dirtObject);
			instance.dirtStats.Add(dirtObject.GetDirt());
			instance.EvaluateCleanupState();
		}
	}

	public static void UnregisterDirtObstacle(DirtComponent dirtObject)
	{
		if (instance == null)
		{
			return;
		}
		if (instance.dirtInstances == null)
		{
			instance.dirtInstances = new List<DirtComponent>();
		}
		if (dirtObject == null)
		{
			instance.dirtInstances = instance.dirtInstances.Where((DirtComponent x) => x != null).ToList();
			instance.EvaluateCleanupState();
		}
		else
		{
			instance.dirtInstances.Remove(dirtObject);
			instance.dirtStats.Remove(dirtObject.GetDirt());
			instance.EvaluateCleanupState();
		}
	}

	public static void IncreaseMaxCustomerCapacity(int amount)
	{
		instance.maxCustomerCount += amount;
		OnUpdateMaxCustomerCapacity.Invoke(instance.maxCustomerCount);
	}

	public static void DecreaseMaxCustomerCapacity(int amount)
	{
		instance.maxCustomerCount -= amount;
		OnUpdateMaxCustomerCapacity.Invoke(instance.maxCustomerCount);
	}
}
