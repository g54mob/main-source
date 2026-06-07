using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using Mirror;
using UnityEngine;

[AddComponentMenu("Digging Project/Spawners/T_Item Area Spawner")]
public class T_ItemAreaSpawner : NetworkBehaviour, IGameSave
{
	[Serializable]
	public class ItemAreaSpawnerSaveData
	{
		public List<SpawnedNodeData> nodes = new List<SpawnedNodeData>();

		public bool wasSpawned;
	}

	[Serializable]
	public class SpawnedNodeData
	{
		public string itemId;

		public int layer;

		public float posX;

		public float posY;

		public float posZ;

		public float rotX;

		public float rotY;

		public float rotZ;

		public float rotW;

		public int spawnRuleID;

		public List<int> pieceHealths = new List<int>();
	}

	public enum MiningLayer
	{
		Surface = 0,
		Mid = 1,
		Deep = 2
	}

	public static T_ItemAreaSpawner instance;

	[Header("Prefab")]
	[Tooltip("NetworkIdentity + T_Item i\ufffderen pickup prefab")]
	public T_Item pickupPrefab;

	[Header("Placement Options")]
	public bool randomYawRotation = true;

	[Header("Rules by Layer")]
	public List<T_ItemSpawnRule> surface = new List<T_ItemSpawnRule>();

	public List<T_ItemSpawnRule> mid = new List<T_ItemSpawnRule>();

	public List<T_ItemSpawnRule> deep = new List<T_ItemSpawnRule>();

	[Header("Spawn Profile (SO)")]
	public T_ItemSpawnProfile profile;

	[Header("Capacity Settings")]
	[Min(0.1f)]
	public float referenceEdge = 10f;

	[Min(0f)]
	public int baseCapacityAtReference = 5;

	[Min(0f)]
	public int minCapacityPerRule;

	public bool capacityByArea = true;

	[Header("Distribution Mode")]
	[Tooltip("True: Itemler rule sayısına göre eşit dağıtılır. False: Kapasiteye orantılı dağıtılır.")]
	public bool equalDistributionAcrossRules = true;

	private Dictionary<MiningLayer, Dictionary<string, List<T_Item>>> spawnedNodesByLayer = new Dictionary<MiningLayer, Dictionary<string, List<T_Item>>>();

	private Dictionary<MiningLayer, Dictionary<string, int>> initialNodeCountsByLayer = new Dictionary<MiningLayer, Dictionary<string, int>>();

	private List<Vector3> spawnedGroupCenters = new List<Vector3>();

	private bool _initialCountsCalculated;

	private bool _isRestoringFromSave;

	public string SaveID => "item-area-spawner";

	public bool IsShared => false;

	public Type SaveType => typeof(ItemAreaSpawnerSaveData);

	public LoadMode LoadMode => LoadMode.Lazy;

	public bool IsRestoringFromSave => _isRestoringFromSave;

	private void Awake()
	{
		instance = this;
		int count = 0;
		count = AssignSpawnRuleIDs(surface, count);
		count = AssignSpawnRuleIDs(mid, count);
		AssignSpawnRuleIDs(deep, count);
	}

	private int AssignSpawnRuleIDs(List<T_ItemSpawnRule> rules, int count)
	{
		foreach (T_ItemSpawnRule rule in rules)
		{
			rule.spawnRuleID = ++count;
		}
		return count;
	}

	[Server]
	public void ServerSpawnFromRules()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_ItemAreaSpawner::ServerSpawnFromRules()' called when server was not active");
		}
		else if (_isRestoringFromSave || SaveLoadGameManager.isLoadMode)
		{
			Debug.Log("[T_ItemAreaSpawner] Load'dan geliniyor, yeni spawn atlanıyor.");
		}
		else if (ValidateSetup())
		{
			StartCoroutine(Co_ServerSpawnAll());
		}
	}

	private IEnumerator Co_ServerSpawnAll()
	{
		spawnedGroupCenters.Clear();
		ClearTrackingData();
		yield return Co_SpawnForLayer(profile?.surface?.items, surface, isSurface: true, MiningLayer.Surface);
		yield return Co_SpawnForLayer(profile?.mid?.items, mid, isSurface: false, MiningLayer.Mid);
		yield return Co_SpawnForLayer(profile?.deep?.items, deep, isSurface: false, MiningLayer.Deep);
		yield return null;
		yield return null;
		CalculateInitialPieceCounts();
	}

	private IEnumerator Co_SpawnForLayer(List<T_ItemSpawnProfile.WeightedSO> layerList, List<T_ItemSpawnRule> rules, bool isSurface, MiningLayer layer)
	{
		if (layerList == null || layerList.Count == 0 || rules == null || rules.Count == 0)
		{
			yield break;
		}
		int n = rules.Count;
		int[] array = new int[n];
		for (int i = 0; i < n; i++)
		{
			array[i] = ComputeCapacityForRule(rules[i]);
		}
		int num = 0;
		for (int j = 0; j < n; j++)
		{
			num += Mathf.Max(0, array[j]);
		}
		if (num <= 0)
		{
			yield break;
		}
		int[] remaining = new int[n];
		for (int k = 0; k < n; k++)
		{
			remaining[k] = Mathf.Max(0, array[k]);
		}
		foreach (T_ItemSpawnProfile.WeightedSO entry in layerList)
		{
			if (entry == null || entry.so == null || entry.maxCount <= 0)
			{
				continue;
			}
			int num2 = UnityEngine.Random.Range(entry.minCount, entry.maxCount + 1);
			if (num2 <= 0)
			{
				continue;
			}
			int num3 = 0;
			for (int l = 0; l < n; l++)
			{
				num3 += Mathf.Max(0, remaining[l]);
			}
			if (num3 <= 0)
			{
				break;
			}
			num2 = Mathf.Min(num2, num3);
			if (num2 <= 0)
			{
				continue;
			}
			int[] alloc = (equalDistributionAcrossRules ? EqualDistribute(num2, remaining) : ProportionalDistribute(num2, remaining));
			int groupMin = Mathf.Max(1, entry.spawnGroupMin);
			int groupMax = Mathf.Max(groupMin, entry.spawnGroupMax);
			for (int m = 0; m < n; m++)
			{
				int k2 = alloc[m];
				if (k2 <= 0)
				{
					continue;
				}
				T_ItemSpawnRule rule = rules[m];
				if (!rule)
				{
					continue;
				}
				int spawned = 0;
				while (spawned < k2)
				{
					int currentGroupSize = UnityEngine.Random.Range(groupMin, groupMax + 1);
					currentGroupSize = Mathf.Min(currentGroupSize, k2 - spawned);
					Vector3? vector = TryGetValidGroupCenter(rule, profile.minGroupDistance);
					if (!vector.HasValue)
					{
						break;
					}
					Vector3 groupCenter = vector.Value;
					spawnedGroupCenters.Add(groupCenter);
					for (int g = 0; g < currentGroupSize; g++)
					{
						Vector3 pos;
						if (g == 0)
						{
							pos = groupCenter;
						}
						else
						{
							Vector3 vector2 = UnityEngine.Random.insideUnitSphere * profile.groupSpawnRadius;
							if (isSurface && vector2.y > 0f)
							{
								vector2.y = 0f - vector2.y;
							}
							pos = groupCenter + vector2;
						}
						Quaternion rot = (randomYawRotation ? Quaternion.Euler(0f, UnityEngine.Random.Range(0f, 360f), 0f) : Quaternion.identity);
						if (!pickupPrefab)
						{
							Debug.LogError("[T_ItemAreaSpawner] Prefab yok!");
							yield break;
						}
						GameObject gameObject = UnityEngine.Object.Instantiate(pickupPrefab.gameObject, pos, rot);
						gameObject.transform.SetParent(GameManager.Instance.oreSpawnParent, worldPositionStays: true);
						T_Item pickup = gameObject.GetComponent<T_Item>();
						if (!pickup)
						{
							Debug.LogError("[T_ItemAreaSpawner] Prefab üzerinde T_Item yok!");
							UnityEngine.Object.Destroy(gameObject);
							continue;
						}
						pickup.NetworkisNode = true;
						pickup.ServerPreAssignSO(entry.so);
						NetworkServer.Spawn(gameObject);
						yield return null;
						pickup.parentTransform = rule.transform;
						pickup.ServerSnap(pos, rot, zeroVelocity: true, rule.spawnRuleID);
						yield return null;
						RegisterSpawnedNode(layer, entry.so.GetItemID(), pickup);
						spawned++;
					}
				}
				remaining[m] = Mathf.Max(0, remaining[m] - k2);
			}
		}
	}

	private int ComputeCapacityForRule(T_ItemSpawnRule rule)
	{
		if (!rule)
		{
			return 0;
		}
		float num = Mathf.Max(0.0001f, referenceEdge * referenceEdge);
		float num2 = (capacityByArea ? rule.GetFootprintAreaXZ() : rule.GetVolume());
		int num3 = Mathf.RoundToInt((float)baseCapacityAtReference * (num2 / num));
		if (minCapacityPerRule > 0)
		{
			num3 = Mathf.Max(num3, minCapacityPerRule);
		}
		return Mathf.Max(0, num3);
	}

	private int[] EqualDistribute(int total, int[] capsLike)
	{
		int num = capsLike.Length;
		int[] array = new int[num];
		int num2 = 0;
		for (int i = 0; i < num; i++)
		{
			if (capsLike[i] > 0)
			{
				num2++;
			}
		}
		if (num2 <= 0)
		{
			return array;
		}
		int num3 = total;
		int num4 = total / num2;
		int num5 = total % num2;
		for (int j = 0; j < num; j++)
		{
			if (capsLike[j] > 0)
			{
				int a = num4 + ((num5 > 0) ? 1 : 0);
				if (num5 > 0)
				{
					num5--;
				}
				num3 -= (array[j] = Mathf.Min(a, capsLike[j]));
			}
		}
		while (num3 > 0)
		{
			bool flag = false;
			for (int k = 0; k < num; k++)
			{
				if (num3 <= 0)
				{
					break;
				}
				if (array[k] < capsLike[k])
				{
					array[k]++;
					num3--;
					flag = true;
				}
			}
			if (!flag)
			{
				break;
			}
		}
		return array;
	}

	private int[] ProportionalDistribute(int total, int[] capsLike)
	{
		int num = capsLike.Length;
		int[] array = new int[num];
		int num2 = 0;
		for (int i = 0; i < num; i++)
		{
			num2 += Mathf.Max(0, capsLike[i]);
		}
		if (num2 <= 0)
		{
			return array;
		}
		int[] array2 = new int[num];
		float[] fracs = new float[num];
		int num3 = 0;
		for (int j = 0; j < num; j++)
		{
			float num4 = (float)total * ((float)capsLike[j] / (float)num2);
			int num5 = Mathf.FloorToInt(num4);
			array2[j] = Mathf.Min(num5, capsLike[j]);
			fracs[j] = num4 - (float)num5;
			num3 += array2[j];
		}
		int num6 = total - num3;
		List<int> list = new List<int>(num);
		for (int k = 0; k < num; k++)
		{
			list.Add(k);
		}
		list.Sort(delegate(int a, int b)
		{
			int num10 = fracs[b].CompareTo(fracs[a]);
			return (num10 != 0) ? num10 : capsLike[b].CompareTo(capsLike[a]);
		});
		int num7 = 0;
		while (num6 > 0 && num7 < list.Count)
		{
			int num8 = list[num7];
			if (array2[num8] < capsLike[num8])
			{
				array2[num8]++;
				num6--;
			}
			else
			{
				num7++;
			}
		}
		for (int num9 = 0; num9 < num; num9++)
		{
			array[num9] = array2[num9];
		}
		return array;
	}

	private bool ValidateSetup()
	{
		if (!base.isServer)
		{
			Debug.LogWarning("[T_ItemAreaSpawner] ServerSpawnFromRules sadece sunucuda çağrılmalı.");
			return false;
		}
		if (!pickupPrefab)
		{
			Debug.LogError("[T_ItemAreaSpawner] pickupPrefab eksik!");
			return false;
		}
		if (!profile)
		{
			Debug.LogError("[T_ItemAreaSpawner] profile eksik!");
			return false;
		}
		return true;
	}

	private bool IsPositionValid(Vector3 pos, float minDistance)
	{
		if (minDistance <= 0f)
		{
			return true;
		}
		float num = minDistance * minDistance;
		foreach (Vector3 spawnedGroupCenter in spawnedGroupCenters)
		{
			if ((pos - spawnedGroupCenter).sqrMagnitude < num)
			{
				return false;
			}
		}
		return true;
	}

	private Vector3? TryGetValidGroupCenter(T_ItemSpawnRule rule, float minDistance, int maxAttempts = 10)
	{
		for (int i = 0; i < maxAttempts; i++)
		{
			Vector3 randomWorldPositionInDisc = rule.GetRandomWorldPositionInDisc();
			if (IsPositionValid(randomWorldPositionInDisc, minDistance))
			{
				return randomWorldPositionInDisc;
			}
		}
		return null;
	}

	private void RegisterSpawnedNode(MiningLayer layer, string itemId, T_Item node)
	{
		if (!string.IsNullOrEmpty(itemId) && !(node == null))
		{
			if (!spawnedNodesByLayer.ContainsKey(layer))
			{
				spawnedNodesByLayer[layer] = new Dictionary<string, List<T_Item>>();
			}
			if (!spawnedNodesByLayer[layer].ContainsKey(itemId))
			{
				spawnedNodesByLayer[layer][itemId] = new List<T_Item>();
			}
			spawnedNodesByLayer[layer][itemId].Add(node);
		}
	}

	public void ClearTrackingData()
	{
		spawnedNodesByLayer.Clear();
		initialNodeCountsByLayer.Clear();
		_initialCountsCalculated = false;
	}

	private void CalculateInitialPieceCounts()
	{
		initialNodeCountsByLayer.Clear();
		foreach (KeyValuePair<MiningLayer, Dictionary<string, List<T_Item>>> item in spawnedNodesByLayer)
		{
			MiningLayer key = item.Key;
			Dictionary<string, List<T_Item>> value = item.Value;
			initialNodeCountsByLayer[key] = new Dictionary<string, int>();
			foreach (KeyValuePair<string, List<T_Item>> item2 in value)
			{
				string key2 = item2.Key;
				List<T_Item> value2 = item2.Value;
				int num = 0;
				foreach (T_Item item3 in value2)
				{
					if (item3 != null)
					{
						num++;
					}
				}
				initialNodeCountsByLayer[key][key2] = num;
			}
		}
		_initialCountsCalculated = true;
		Debug.Log($"[T_ItemAreaSpawner] Başlangıç node sayıları hesaplandı: {spawnedNodesByLayer.Count} katman");
		if (ComputerPropertyManager.Instance != null)
		{
			ComputerPropertyManager.Instance.BroadcastMiningData();
		}
	}

	public int GetRemainingNodeCount(MiningLayer layer, string itemId)
	{
		if (string.IsNullOrEmpty(itemId))
		{
			return 0;
		}
		if (!spawnedNodesByLayer.TryGetValue(layer, out var value))
		{
			return 0;
		}
		if (!value.TryGetValue(itemId, out var value2))
		{
			return 0;
		}
		int num = 0;
		foreach (T_Item item in value2)
		{
			if (item == null)
			{
				continue;
			}
			int pieceCount = item.GetPieceCount();
			for (int i = 0; i < pieceCount; i++)
			{
				if (item.GetPieceHealth(i) > 0)
				{
					num++;
					break;
				}
			}
		}
		return num;
	}

	public Dictionary<string, (int initial, int remaining)> GetNodeCountsForLayer(MiningLayer layer)
	{
		Dictionary<string, (int, int)> dictionary = new Dictionary<string, (int, int)>();
		if (!initialNodeCountsByLayer.TryGetValue(layer, out var value))
		{
			return dictionary;
		}
		foreach (KeyValuePair<string, int> item in value)
		{
			string key = item.Key;
			int value2 = item.Value;
			int remainingNodeCount = GetRemainingNodeCount(layer, key);
			dictionary[key] = (value2, remainingNodeCount);
		}
		return dictionary;
	}

	public Dictionary<MiningLayer, Dictionary<string, (int initial, int remaining)>> GetAllNodeCountsByLayer()
	{
		Dictionary<MiningLayer, Dictionary<string, (int, int)>> dictionary = new Dictionary<MiningLayer, Dictionary<string, (int, int)>>();
		foreach (MiningLayer value in Enum.GetValues(typeof(MiningLayer)))
		{
			dictionary[value] = GetNodeCountsForLayer(value);
		}
		return dictionary;
	}

	public override void OnStartServer()
	{
		base.OnStartServer();
		SaveLoadManager.Subscribe(this, 30);
	}

	public override void OnStopServer()
	{
		base.OnStopServer();
		SaveLoadManager.Unsubscribe(this);
	}

	public object GetSaveData(bool includeNonSavable)
	{
		if (!base.isServer)
		{
			return null;
		}
		ItemAreaSpawnerSaveData itemAreaSpawnerSaveData = new ItemAreaSpawnerSaveData();
		itemAreaSpawnerSaveData.wasSpawned = spawnedNodesByLayer.Count > 0;
		foreach (KeyValuePair<MiningLayer, Dictionary<string, List<T_Item>>> item2 in spawnedNodesByLayer)
		{
			MiningLayer key = item2.Key;
			foreach (KeyValuePair<string, List<T_Item>> item3 in item2.Value)
			{
				string key2 = item3.Key;
				foreach (T_Item item4 in item3.Value)
				{
					if (!(item4 == null))
					{
						int spawnRuleID = FindRuleIDFromTransform(item4.parentTransform);
						SpawnedNodeData item = new SpawnedNodeData
						{
							itemId = key2,
							layer = (int)key,
							posX = item4.transform.position.x,
							posY = item4.transform.position.y,
							posZ = item4.transform.position.z,
							rotX = item4.transform.rotation.x,
							rotY = item4.transform.rotation.y,
							rotZ = item4.transform.rotation.z,
							rotW = item4.transform.rotation.w,
							spawnRuleID = spawnRuleID,
							pieceHealths = item4.GetAllPieceHealths()
						};
						itemAreaSpawnerSaveData.nodes.Add(item);
					}
				}
			}
		}
		if (itemAreaSpawnerSaveData.nodes.Count > 0)
		{
			Debug.Log($"[T_ItemAreaSpawner] Save - {itemAreaSpawnerSaveData.nodes.Count} node kaydedildi.");
		}
		return itemAreaSpawnerSaveData;
	}

	public Task OnLoad(object value)
	{
		if (!(value is ItemAreaSpawnerSaveData itemAreaSpawnerSaveData))
		{
			return Task.CompletedTask;
		}
		if (!base.isServer)
		{
			Debug.Log("[T_ItemAreaSpawner] Client - load atlanıyor, network üzerinden senkronize olacak");
			return Task.CompletedTask;
		}
		if (!SaveLoadGameManager.isLoadMode)
		{
			Debug.Log("[T_ItemAreaSpawner] Client - load atlanıyor, load mod değil");
			return Task.CompletedTask;
		}
		if (!itemAreaSpawnerSaveData.wasSpawned || itemAreaSpawnerSaveData.nodes == null || itemAreaSpawnerSaveData.nodes.Count == 0)
		{
			Debug.Log("[T_ItemAreaSpawner] Load - Kaydedilmiş node yok, normal spawn yapılacak.");
			return Task.CompletedTask;
		}
		_isRestoringFromSave = true;
		SaveLoadGameManager.RegisterPendingLoadOperation("Loading_Ore");
		StartCoroutine(Co_RestoreNodes(itemAreaSpawnerSaveData));
		Debug.Log($"[T_ItemAreaSpawner] Load - {itemAreaSpawnerSaveData.nodes.Count} node restore ediliyor.");
		return Task.CompletedTask;
	}

	private IEnumerator Co_RestoreNodes(ItemAreaSpawnerSaveData data)
	{
		ClearTrackingData();
		foreach (SpawnedNodeData nodeData in data.nodes)
		{
			if (string.IsNullOrEmpty(nodeData.itemId))
			{
				continue;
			}
			if (ItemSOManager.Instance == null)
			{
				Debug.LogWarning("[T_ItemAreaSpawner] Restore - ItemSOManager bulunamadı!");
				continue;
			}
			T_ItemSO itemSOById = ItemSOManager.Instance.GetItemSOById(nodeData.itemId);
			if (itemSOById == null)
			{
				Debug.LogWarning("[T_ItemAreaSpawner] Restore - SO bulunamadı: " + nodeData.itemId);
				continue;
			}
			Vector3 pos = new Vector3(nodeData.posX, nodeData.posY, nodeData.posZ);
			Quaternion rot = new Quaternion(nodeData.rotX, nodeData.rotY, nodeData.rotZ, nodeData.rotW);
			if (!pickupPrefab)
			{
				Debug.LogError("[T_ItemAreaSpawner] Restore - Prefab yok!");
				yield break;
			}
			GameObject gameObject = UnityEngine.Object.Instantiate(pickupPrefab.gameObject, pos, rot);
			gameObject.transform.SetParent(GameManager.Instance.oreSpawnParent, worldPositionStays: true);
			T_Item pickup = gameObject.GetComponent<T_Item>();
			if (!pickup)
			{
				Debug.LogError("[T_ItemAreaSpawner] Restore - Prefab üzerinde T_Item yok!");
				UnityEngine.Object.Destroy(gameObject);
				continue;
			}
			pickup.NetworkisNode = true;
			if (nodeData.pieceHealths != null && nodeData.pieceHealths.Count > 0)
			{
				pickup.PreFillPieceHealths(nodeData.pieceHealths);
			}
			pickup.ServerPreAssignSO(itemSOById);
			NetworkServer.Spawn(gameObject);
			yield return null;
			T_ItemSpawnRule t_ItemSpawnRule = FindRuleByID(nodeData.spawnRuleID);
			if (t_ItemSpawnRule != null)
			{
				pickup.parentTransform = t_ItemSpawnRule.transform;
			}
			pickup.ServerSnap(pos, rot, zeroVelocity: true, nodeData.spawnRuleID);
			yield return null;
			MiningLayer layer = (MiningLayer)nodeData.layer;
			RegisterSpawnedNode(layer, nodeData.itemId, pickup);
			yield return null;
		}
		yield return null;
		yield return null;
		CalculateInitialPieceCounts();
		Debug.Log($"[T_ItemAreaSpawner] Restore tamamlandı - {data.nodes.Count} node.");
		SaveLoadGameManager.CompletePendingLoadOperation("Loading_Ore");
	}

	private T_ItemSpawnRule FindRuleByID(int spawnRuleID)
	{
		foreach (T_ItemSpawnRule item in surface)
		{
			if (item != null && item.spawnRuleID == spawnRuleID)
			{
				return item;
			}
		}
		foreach (T_ItemSpawnRule item2 in mid)
		{
			if (item2 != null && item2.spawnRuleID == spawnRuleID)
			{
				return item2;
			}
		}
		foreach (T_ItemSpawnRule item3 in deep)
		{
			if (item3 != null && item3.spawnRuleID == spawnRuleID)
			{
				return item3;
			}
		}
		return null;
	}

	private int FindRuleIDFromTransform(Transform parentTransform)
	{
		if (parentTransform == null)
		{
			return -1;
		}
		foreach (T_ItemSpawnRule item in surface)
		{
			if (item != null && item.transform == parentTransform)
			{
				return item.spawnRuleID;
			}
		}
		foreach (T_ItemSpawnRule item2 in mid)
		{
			if (item2 != null && item2.transform == parentTransform)
			{
				return item2.spawnRuleID;
			}
		}
		foreach (T_ItemSpawnRule item3 in deep)
		{
			if (item3 != null && item3.transform == parentTransform)
			{
				return item3.spawnRuleID;
			}
		}
		return -1;
	}

	public void NotifyRestoreComplete()
	{
		_isRestoringFromSave = false;
	}

	public override bool Weaved()
	{
		return true;
	}
}
