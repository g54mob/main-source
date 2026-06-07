using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using Mirror;
using UnityEngine;

public class DynamicObjectSpawner : MonoBehaviour, IGameSave
{
	public enum DynamicObjectType
	{
		Sack = 0,
		BuildingBox = 1,
		Item = 2,
		DeliveryPallet = 3
	}

	[Serializable]
	public class DynamicSpawnData
	{
		public string uniqueId;

		public DynamicObjectType objectType;

		public string prefabId;

		public float posX;

		public float posY;

		public float posZ;

		public float rotX;

		public float rotY;

		public float rotZ;

		public float rotW;

		public bool isOnForklift;

		public uint forkliftNetId;
	}

	[Serializable]
	public class DynamicSpawnListSaveData
	{
		public List<DynamicSpawnData> objects = new List<DynamicSpawnData>();
	}

	private readonly Dictionary<string, T_Sack> registeredSacks = new Dictionary<string, T_Sack>();

	private readonly Dictionary<string, T_Building> registeredBuildingBoxes = new Dictionary<string, T_Building>();

	private readonly Dictionary<string, T_Item> registeredItems = new Dictionary<string, T_Item>();

	private readonly Dictionary<string, T_DeliveryPallet> registeredDeliveryPallets = new Dictionary<string, T_DeliveryPallet>();

	[Header("Prefabs")]
	[SerializeField]
	private GameObject sackPrefab;

	[SerializeField]
	private GameObject buildingBoxPrefab;

	[SerializeField]
	private T_Item itemPrefab;

	[SerializeField]
	private GameObject deliveryPalletPrefab;

	public static DynamicObjectSpawner Instance { get; private set; }

	public string SaveID => "dynamic-object-spawner";

	public bool IsShared => false;

	public Type SaveType => typeof(DynamicSpawnListSaveData);

	public LoadMode LoadMode => LoadMode.Lazy;

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		StartCoroutine(WaitAndSubscribe());
	}

	private IEnumerator WaitAndSubscribe()
	{
		while (!NetworkServer.active)
		{
			yield return null;
		}
		SaveLoadManager.Subscribe(this, 30);
	}

	private void OnDestroy()
	{
		SaveLoadManager.Unsubscribe(this);
	}

	public void RegisterSack(T_Sack sack)
	{
		if (!(sack == null) && !string.IsNullOrEmpty(sack.UniqueId))
		{
			registeredSacks[sack.UniqueId] = sack;
		}
	}

	public void UnregisterSack(string uniqueId)
	{
		if (!string.IsNullOrEmpty(uniqueId))
		{
			registeredSacks.Remove(uniqueId);
		}
	}

	public void RegisterBuildingBox(T_Building building)
	{
		if (!(building == null) && !string.IsNullOrEmpty(building.UniqueId))
		{
			registeredBuildingBoxes[building.UniqueId] = building;
		}
	}

	public void UnregisterBuildingBox(string uniqueId)
	{
		if (!string.IsNullOrEmpty(uniqueId))
		{
			registeredBuildingBoxes.Remove(uniqueId);
		}
	}

	public void RegisterItem(T_Item item)
	{
		if (!(item == null) && !string.IsNullOrEmpty(item.UniqueId) && (!(item.so != null) || !item.so.isNode))
		{
			registeredItems[item.UniqueId] = item;
		}
	}

	public void UnregisterItem(string uniqueId)
	{
		if (!string.IsNullOrEmpty(uniqueId))
		{
			registeredItems.Remove(uniqueId);
		}
	}

	public void RegisterDeliveryPallet(T_DeliveryPallet pallet)
	{
		if (!(pallet == null) && !string.IsNullOrEmpty(pallet.UniqueId))
		{
			registeredDeliveryPallets[pallet.UniqueId] = pallet;
		}
	}

	public void UnregisterDeliveryPallet(string uniqueId)
	{
		if (!string.IsNullOrEmpty(uniqueId))
		{
			registeredDeliveryPallets.Remove(uniqueId);
		}
	}

	public IReadOnlyCollection<T_Sack> GetAllRegisteredSacks()
	{
		return registeredSacks.Values;
	}

	public T_DeliveryPallet GetDeliveryPalletByUniqueId(string uniqueId)
	{
		if (string.IsNullOrEmpty(uniqueId))
		{
			return null;
		}
		registeredDeliveryPallets.TryGetValue(uniqueId, out var value);
		return value;
	}

	public object GetSaveData(bool includeNonSavable)
	{
		if (!NetworkServer.active)
		{
			return null;
		}
		DynamicSpawnListSaveData dynamicSpawnListSaveData = new DynamicSpawnListSaveData();
		foreach (KeyValuePair<string, T_Sack> registeredSack in registeredSacks)
		{
			T_Sack value = registeredSack.Value;
			if (!(value == null))
			{
				Rigidbody component = value.GetComponent<Rigidbody>();
				Vector3 vector = ((component != null) ? component.position : value.transform.position);
				Quaternion quaternion = ((component != null) ? component.rotation : value.transform.rotation);
				dynamicSpawnListSaveData.objects.Add(new DynamicSpawnData
				{
					uniqueId = value.UniqueId,
					objectType = DynamicObjectType.Sack,
					prefabId = "sack",
					posX = vector.x,
					posY = vector.y,
					posZ = vector.z,
					rotX = quaternion.x,
					rotY = quaternion.y,
					rotZ = quaternion.z,
					rotW = quaternion.w
				});
			}
		}
		foreach (KeyValuePair<string, T_Building> registeredBuildingBox in registeredBuildingBoxes)
		{
			T_Building value2 = registeredBuildingBox.Value;
			if (!(value2 == null))
			{
				Rigidbody component2 = value2.GetComponent<Rigidbody>();
				Vector3 vector2 = ((component2 != null) ? component2.position : value2.transform.position);
				Quaternion quaternion2 = ((component2 != null) ? component2.rotation : value2.transform.rotation);
				int buildingSOIndex = GetBuildingSOIndex(value2.BuildingItemSO);
				dynamicSpawnListSaveData.objects.Add(new DynamicSpawnData
				{
					uniqueId = value2.UniqueId,
					objectType = DynamicObjectType.BuildingBox,
					prefabId = buildingSOIndex.ToString(),
					posX = vector2.x,
					posY = vector2.y,
					posZ = vector2.z,
					rotX = quaternion2.x,
					rotY = quaternion2.y,
					rotZ = quaternion2.z,
					rotW = quaternion2.w
				});
			}
		}
		foreach (KeyValuePair<string, T_Item> registeredItem in registeredItems)
		{
			T_Item value3 = registeredItem.Value;
			if (!(value3 == null) && (!(value3.so != null) || !value3.so.isNode))
			{
				Vector3 position = value3.transform.position;
				Quaternion rotation = value3.transform.rotation;
				dynamicSpawnListSaveData.objects.Add(new DynamicSpawnData
				{
					uniqueId = value3.UniqueId,
					objectType = DynamicObjectType.Item,
					prefabId = value3.itemId,
					posX = position.x,
					posY = position.y,
					posZ = position.z,
					rotX = rotation.x,
					rotY = rotation.y,
					rotZ = rotation.z,
					rotW = rotation.w
				});
			}
		}
		foreach (KeyValuePair<string, T_DeliveryPallet> registeredDeliveryPallet in registeredDeliveryPallets)
		{
			T_DeliveryPallet value4 = registeredDeliveryPallet.Value;
			if (!(value4 == null))
			{
				Vector3 position2 = value4.transform.position;
				Quaternion rotation2 = value4.transform.rotation;
				dynamicSpawnListSaveData.objects.Add(new DynamicSpawnData
				{
					uniqueId = value4.UniqueId,
					objectType = DynamicObjectType.DeliveryPallet,
					prefabId = "delivery-pallet",
					posX = position2.x,
					posY = position2.y,
					posZ = position2.z,
					rotX = rotation2.x,
					rotY = rotation2.y,
					rotZ = rotation2.z,
					rotW = rotation2.w,
					isOnForklift = value4.IsLifted,
					forkliftNetId = 0u
				});
			}
		}
		return dynamicSpawnListSaveData;
	}

	public Task OnLoad(object value)
	{
		if (!NetworkServer.active)
		{
			return Task.CompletedTask;
		}
		if (!(value is DynamicSpawnListSaveData data))
		{
			return Task.CompletedTask;
		}
		SaveLoadGameManager.RegisterPendingLoadOperation("Loading_Objects");
		StartCoroutine(Co_SpawnAll(data));
		return Task.CompletedTask;
	}

	private IEnumerator Co_SpawnAll(DynamicSpawnListSaveData data)
	{
		while (ScriptableListManager.Instance == null)
		{
			yield return null;
		}
		foreach (DynamicSpawnData @object in data.objects)
		{
			Vector3 pos = new Vector3(@object.posX, @object.posY, @object.posZ);
			Quaternion rot = new Quaternion(@object.rotX, @object.rotY, @object.rotZ, @object.rotW);
			switch (@object.objectType)
			{
			case DynamicObjectType.Sack:
				SpawnSack(@object, pos, rot);
				break;
			case DynamicObjectType.BuildingBox:
				SpawnBuildingBox(@object, pos, rot);
				break;
			case DynamicObjectType.Item:
				SpawnItem(@object, pos, rot);
				break;
			case DynamicObjectType.DeliveryPallet:
				SpawnDeliveryPallet(@object, pos, rot);
				break;
			}
			yield return null;
		}
		yield return null;
		yield return null;
		SaveLoadGameManager.CompletePendingLoadOperation("Loading_Objects");
	}

	private void SpawnSack(DynamicSpawnData data, Vector3 pos, Quaternion rot)
	{
		if (sackPrefab == null)
		{
			Debug.LogError("[DynamicObjectSpawner] SpawnSack - sackPrefab null!");
			return;
		}
		GameObject gameObject = UnityEngine.Object.Instantiate(sackPrefab, pos, rot);
		T_Sack component = gameObject.GetComponent<T_Sack>();
		if (component != null)
		{
			component.SetSackId(data.uniqueId);
			NetworkServer.Spawn(gameObject);
		}
	}

	private void SpawnBuildingBox(DynamicSpawnData data, Vector3 pos, Quaternion rot)
	{
		if (buildingBoxPrefab == null)
		{
			Debug.LogError("[DynamicObjectSpawner] SpawnBuildingBox - buildingBoxPrefab null!");
			return;
		}
		if (!int.TryParse(data.prefabId, out var result))
		{
			Debug.LogError("[DynamicObjectSpawner] SpawnBuildingBox - Invalid prefabId: " + data.prefabId);
			return;
		}
		IReadOnlyList<T_BuildingItemSO> readOnlyList = ScriptableListManager.Instance?.AllBuildingItemSOs;
		if (readOnlyList == null || result < 0 || result >= readOnlyList.Count)
		{
			Debug.LogError($"[DynamicObjectSpawner] SpawnBuildingBox - Invalid soIndex: {result}");
			return;
		}
		T_BuildingItemSO t_BuildingItemSO = readOnlyList[result];
		if (t_BuildingItemSO == null)
		{
			Debug.LogError($"[DynamicObjectSpawner] SpawnBuildingBox - BuildingSO null at index: {result}");
			return;
		}
		GameObject gameObject = UnityEngine.Object.Instantiate(buildingBoxPrefab, pos, rot);
		T_Building component = gameObject.GetComponent<T_Building>();
		if (component != null)
		{
			component.SetUniqueId(data.uniqueId);
			component.SetBuildingItemSOIndex(result);
			component.SetBuildingItemSO(t_BuildingItemSO);
			component.SetIcon(t_BuildingItemSO.Icon);
			NetworkServer.Spawn(gameObject);
		}
	}

	private void SpawnItem(DynamicSpawnData data, Vector3 pos, Quaternion rot)
	{
		if (itemPrefab == null)
		{
			Debug.LogError("[DynamicObjectSpawner] SpawnItem - itemPrefab null!");
			return;
		}
		if (string.IsNullOrEmpty(data.prefabId))
		{
			Debug.LogError("[DynamicObjectSpawner] SpawnItem - prefabId null/empty!");
			return;
		}
		T_ItemSO t_ItemSO = ItemSOManager.Instance?.GetItemSOById(data.prefabId);
		if (t_ItemSO == null)
		{
			Debug.LogError("[DynamicObjectSpawner] SpawnItem - ItemSO not found for id: " + data.prefabId);
			return;
		}
		GameObject gameObject = UnityEngine.Object.Instantiate(itemPrefab.gameObject, pos, rot);
		T_Item component = gameObject.GetComponent<T_Item>();
		if (component != null)
		{
			component.SetUniqueId(data.uniqueId);
			component.NetworkitemId = data.prefabId;
			component.so = t_ItemSO;
			NetworkServer.Spawn(gameObject);
		}
	}

	private void SpawnDeliveryPallet(DynamicSpawnData data, Vector3 pos, Quaternion rot)
	{
		if (deliveryPalletPrefab == null)
		{
			Debug.LogError("[DynamicObjectSpawner] SpawnDeliveryPallet - deliveryPalletPrefab null!");
			return;
		}
		GameObject gameObject = UnityEngine.Object.Instantiate(deliveryPalletPrefab, pos, rot);
		T_DeliveryPallet component = gameObject.GetComponent<T_DeliveryPallet>();
		if (component != null)
		{
			component.SetUniqueId(data.uniqueId);
			NetworkServer.Spawn(gameObject);
		}
	}

	private int GetBuildingSOIndex(T_BuildingItemSO so)
	{
		if (so == null)
		{
			return -1;
		}
		IReadOnlyList<T_BuildingItemSO> readOnlyList = ScriptableListManager.Instance?.AllBuildingItemSOs;
		if (readOnlyList == null)
		{
			return -1;
		}
		for (int i = 0; i < readOnlyList.Count; i++)
		{
			if (readOnlyList[i] == so)
			{
				return i;
			}
		}
		return -1;
	}
}
