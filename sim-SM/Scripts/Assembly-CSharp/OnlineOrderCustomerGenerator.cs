using System.Collections.Generic;
using MyBox;
using UnityEngine;

public class OnlineOrderCustomerGenerator : Singleton<OnlineOrderCustomerGenerator>
{
	[SerializeField]
	public Transform[] SpawningTransforms;

	[SerializeField]
	public Transform[] DespawningTransforms;

	[SerializeField]
	private List<OnlineOrderCustomer> m_MaleCustomerPrefabs;

	[SerializeField]
	private List<OnlineOrderCustomer> m_FemaleCustomerPrefabs;

	private HashSet<int> m_FreeSpawnIndices;

	private List<OnlineOrderCustomer> m_ActiveOnlineCustomers;

	private MiniMap m_MiniMap;

	private static bool m_Registered;

	public IReadOnlyList<OnlineOrderCustomer> ActiveOnlineCustomers => null;

	[RuntimeInitializeOnLoadMethod]
	private static void Reset()
	{
	}

	private void Awake()
	{
	}

	private string GetNetworkName(CustomerGender gender, int index)
	{
		return null;
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private OnlineOrderCustomer Instantiate(CustomerGender gender, int index, Transform spawnTransform, OrderListData data = null)
	{
		return null;
	}

	public bool GetOccupyFreeIndex(out int index)
	{
		index = default(int);
		return false;
	}

	public void RegisterToMinimap(OnlineOrderCustomer customer)
	{
	}

	public void UnregisterFromMinimap(OnlineOrderCustomer customer)
	{
	}

	public int GetPrefabIndex(CustomerGender gender)
	{
		return 0;
	}

	public OnlineOrderCustomer SpawnWithData(OrderListData data)
	{
		return null;
	}

	public OnlineOrderCustomer Load(OrderListData order)
	{
		return null;
	}

	public OnlineOrderCustomer SpawnTutorialCustomer(Vector3 position)
	{
		return null;
	}

	public void DeSpawn(OnlineOrderCustomer customer)
	{
	}

	public OnlineOrderCustomer GetCustomerByOrderId(int orderId)
	{
		return null;
	}

	private List<int> GetNearbySpawnIndexes(int currentIndex, int radius = 2)
	{
		return null;
	}

	public Transform GetDespawnTarget(int currentSpawnIndex, int radius = 2)
	{
		return null;
	}

	private void ShuffleList(List<int> list)
	{
	}

	public Vector3 GetSpawnPosition(int index)
	{
		return default(Vector3);
	}
}
