using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;
using UnityEngine.Events;

public class T_DeliveryZone : NetworkBehaviour, IGameSave
{
	[Serializable]
	public class DeliveryZoneSaveData
	{
		public int totalDeliveredCount;

		public int activeVisualCount;

		public string currentContractId;

		public List<string> itemCountKeys = new List<string>();

		public List<int> itemCountValues = new List<int>();
	}

	[Header("References")]
	[Tooltip("Teslimat trigger collider'ı")]
	[SerializeField]
	private Collider deliveryTrigger;

	[Header("Occupancy Detection")]
	[Tooltip("Forklift layer'ı - zone içinde forklift tespiti için")]
	[SerializeField]
	private LayerMask forkliftLayer;

	[Tooltip("Player layer'ı - zone içinde oyuncu tespiti için")]
	[SerializeField]
	private LayerMask playerLayer;

	[Header("Visual Settings")]
	[Tooltip("Önceden spawn edilmiş görsel objeler (max adet kadar)")]
	[SerializeField]
	private List<GameObject> preSpawnedVisuals = new List<GameObject>();

	[Tooltip("Görseller için maksimum item adedi")]
	[SerializeField]
	private int visualsMaxCount = 100;

	[Header("Company Display")]
	[Tooltip("Contract şirket logosunu gösteren SpriteRenderer listesi")]
	[SerializeField]
	private List<SpriteRenderer> companyLogoRenderers = new List<SpriteRenderer>();

	[Header("Forklift Indicator")]
	[Tooltip("Forklift T_DeliveryPallet aldığında ve item delivery zone'da gerekli ise açılan indicator")]
	[SerializeField]
	private GameObject forkliftDeliveryIndicator;

	[Header("Events")]
	[Tooltip("Delivery zone'daki itemler değiştiğinde tetiklenir")]
	public UnityEvent OnItemsChanged = new UnityEvent();

	[Header("Runtime - Synced")]
	[SyncVar(hook = "OnDeliveredCountChanged")]
	private int _totalDeliveredCount;

	[SyncVar(hook = "OnActiveVisualCountChanged")]
	private int _activeVisualCount;

	[SyncVar(hook = "OnCurrentContractIdChanged")]
	private string _currentContractId = "";

	private readonly SyncDictionary<string, int> _itemCounts = new SyncDictionary<string, int>();

	private HashSet<uint> _processedPalletNetIds = new HashSet<uint>();

	private readonly List<Material> _materialInstances = new List<Material>();

	private HashSet<uint> _forkliftsInZone = new HashSet<uint>();

	private HashSet<uint> _playersInZone = new HashSet<uint>();

	[SyncVar]
	private bool _isForkliftInZone;

	[SyncVar]
	private bool _isPlayerInZone;

	[Header("Visual Hide Settings")]
	[Tooltip("Görsellerin kademeli kapanma arasındaki bekleme süresi (saniye)")]
	[SerializeField]
	private float visualHideInterval = 0.15f;

	private Coroutine _hideVisualsCoroutine;

	public Action<int, int> _Mirror_SyncVarHookDelegate__totalDeliveredCount;

	public Action<int, int> _Mirror_SyncVarHookDelegate__activeVisualCount;

	public Action<string, string> _Mirror_SyncVarHookDelegate__currentContractId;

	public static T_DeliveryZone Instance { get; private set; }

	public bool IsForkliftInZone => _isForkliftInZone;

	public bool IsPlayerInZone => _isPlayerInZone;

	public bool HasOccupants
	{
		get
		{
			if (!_isForkliftInZone)
			{
				return _isPlayerInZone;
			}
			return true;
		}
	}

	public int TotalDeliveredCount => _totalDeliveredCount;

	public string CurrentContractId => _currentContractId;

	public string SaveID => "delivery-zone";

	public bool IsShared => false;

	public Type SaveType => typeof(DeliveryZoneSaveData);

	public LoadMode LoadMode => LoadMode.Lazy;

	public int Network_totalDeliveredCount
	{
		get
		{
			return _totalDeliveredCount;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _totalDeliveredCount, 1uL, _Mirror_SyncVarHookDelegate__totalDeliveredCount);
		}
	}

	public int Network_activeVisualCount
	{
		get
		{
			return _activeVisualCount;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _activeVisualCount, 2uL, _Mirror_SyncVarHookDelegate__activeVisualCount);
		}
	}

	public string Network_currentContractId
	{
		get
		{
			return _currentContractId;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _currentContractId, 4uL, _Mirror_SyncVarHookDelegate__currentContractId);
		}
	}

	public bool Network_isForkliftInZone
	{
		get
		{
			return _isForkliftInZone;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _isForkliftInZone, 8uL, null);
		}
	}

	public bool Network_isPlayerInZone
	{
		get
		{
			return _isPlayerInZone;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _isPlayerInZone, 16uL, null);
		}
	}

	private void Awake()
	{
		Instance = this;
		SyncDictionary<string, int> itemCounts = _itemCounts;
		itemCounts.OnChange = (Action<SyncIDictionary<string, int>.Operation, string, int>)Delegate.Combine(itemCounts.OnChange, new Action<SyncIDictionary<string, int>.Operation, string, int>(OnItemCountsChanged));
		if (deliveryTrigger != null && !deliveryTrigger.isTrigger)
		{
			deliveryTrigger.isTrigger = true;
		}
		HideAllVisuals();
		if (forkliftDeliveryIndicator != null)
		{
			forkliftDeliveryIndicator.SetActive(value: false);
		}
	}

	private void OnItemCountsChanged(SyncIDictionary<string, int>.Operation op, string key, int item)
	{
		OnItemsChanged?.Invoke();
	}

	private void OnDestroy()
	{
		CleanupMaterialInstances();
		if (Instance == this)
		{
			Instance = null;
		}
	}

	private void CleanupMaterialInstances()
	{
		foreach (Material materialInstance in _materialInstances)
		{
			if (materialInstance != null)
			{
				UnityEngine.Object.Destroy(materialInstance);
			}
		}
		_materialInstances.Clear();
	}

	public int GetItemCount(string itemId)
	{
		if (string.IsNullOrEmpty(itemId))
		{
			return 0;
		}
		if (!_itemCounts.TryGetValue(itemId, out var value))
		{
			return 0;
		}
		return value;
	}

	[ClientRpc]
	private void RpcNotifyItemsChanged()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void T_DeliveryZone::RpcNotifyItemsChanged()", -1440598520, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public override void OnStartServer()
	{
		base.OnStartServer();
		if (ComputerContractManager.Instance != null)
		{
			ComputerContractManager.Instance.onDeliveryContractChanged.AddListener(OnDeliveryContractChanged);
		}
		SaveLoadManager.Subscribe(this, 55);
	}

	public override void OnStopServer()
	{
		base.OnStopServer();
		if (ComputerContractManager.Instance != null)
		{
			ComputerContractManager.Instance.onDeliveryContractChanged.RemoveListener(OnDeliveryContractChanged);
		}
		SaveLoadManager.Unsubscribe(this);
	}

	private void OnDeliveryContractChanged(string contractId)
	{
		if (base.isServer && _currentContractId != contractId)
		{
			Network_currentContractId = contractId;
			Network_totalDeliveredCount = 0;
			Network_activeVisualCount = 0;
			_processedPalletNetIds.Clear();
			_itemCounts.Clear();
			RpcHideAllVisuals();
			RpcNotifyItemsChanged();
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (!base.isServer)
		{
			return;
		}
		int num = 1 << other.gameObject.layer;
		if ((forkliftLayer.value & num) != 0)
		{
			T_Forklift componentInParent = other.GetComponentInParent<T_Forklift>();
			if (componentInParent != null)
			{
				NetworkIdentity component = componentInParent.GetComponent<NetworkIdentity>();
				if (component != null)
				{
					_forkliftsInZone.Add(component.netId);
					Network_isForkliftInZone = _forkliftsInZone.Count > 0;
				}
			}
		}
		else if ((playerLayer.value & num) != 0)
		{
			GamePlayer componentInParent2 = other.GetComponentInParent<GamePlayer>();
			if (componentInParent2 != null)
			{
				NetworkIdentity component2 = componentInParent2.GetComponent<NetworkIdentity>();
				if (component2 != null)
				{
					_playersInZone.Add(component2.netId);
					Network_isPlayerInZone = _playersInZone.Count > 0;
				}
			}
		}
		else
		{
			T_DeliveryPallet componentInParent3 = other.GetComponentInParent<T_DeliveryPallet>();
			if (!(componentInParent3 == null) && !componentInParent3.IsLifted)
			{
				ProcessDeliveryPallet(componentInParent3);
			}
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (!base.isServer)
		{
			return;
		}
		int num = 1 << other.gameObject.layer;
		if ((forkliftLayer.value & num) == 0 && (playerLayer.value & num) == 0)
		{
			T_DeliveryPallet componentInParent = other.GetComponentInParent<T_DeliveryPallet>();
			if (!(componentInParent == null) && !componentInParent.IsLifted)
			{
				ProcessDeliveryPallet(componentInParent);
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (!base.isServer)
		{
			return;
		}
		int num = 1 << other.gameObject.layer;
		if ((forkliftLayer.value & num) != 0)
		{
			T_Forklift componentInParent = other.GetComponentInParent<T_Forklift>();
			if (componentInParent != null)
			{
				NetworkIdentity component = componentInParent.GetComponent<NetworkIdentity>();
				if (component != null)
				{
					_forkliftsInZone.Remove(component.netId);
					Network_isForkliftInZone = _forkliftsInZone.Count > 0;
				}
			}
		}
		else
		{
			if ((playerLayer.value & num) == 0)
			{
				return;
			}
			GamePlayer componentInParent2 = other.GetComponentInParent<GamePlayer>();
			if (componentInParent2 != null)
			{
				NetworkIdentity component2 = componentInParent2.GetComponent<NetworkIdentity>();
				if (component2 != null)
				{
					_playersInZone.Remove(component2.netId);
					Network_isPlayerInZone = _playersInZone.Count > 0;
				}
			}
		}
	}

	[Server]
	private void ProcessDeliveryPallet(T_DeliveryPallet deliveryPallet)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_DeliveryZone::ProcessDeliveryPallet(T_DeliveryPallet)' called when server was not active");
		}
		else
		{
			if (deliveryPallet == null)
			{
				return;
			}
			NetworkIdentity component = deliveryPallet.GetComponent<NetworkIdentity>();
			if (component == null || _processedPalletNetIds.Contains(component.netId))
			{
				return;
			}
			_processedPalletNetIds.Add(component.netId);
			string activeContractId = deliveryPallet.ActiveContractId;
			if (string.IsNullOrEmpty(activeContractId) || ComputerContractManager.Instance == null)
			{
				return;
			}
			ActiveContractData? deliveryRequestedContract = ComputerContractManager.Instance.GetDeliveryRequestedContract();
			if (!deliveryRequestedContract.HasValue)
			{
				return;
			}
			int num = 0;
			ActiveContractData value = deliveryRequestedContract.Value;
			for (int i = 0; i < deliveryPallet.MaterialCount; i++)
			{
				string itemId = deliveryPallet.GetItemId(i);
				int itemCount = deliveryPallet.GetItemCount(i);
				deliveryPallet.GetMaxCount(i);
				if (itemCount <= 0)
				{
					continue;
				}
				int num2 = FindMaterialIndex(value, itemId);
				if (num2 != -1)
				{
					int num3 = value.materialCounts[num2];
					int num4 = ((value.deliveredCounts != null && num2 < value.deliveredCounts.Length) ? value.deliveredCounts[num2] : 0);
					int b = Mathf.Max(0, num3 - num4);
					int num5 = Mathf.Min(itemCount, b);
					if (num5 > 0)
					{
						ComputerContractManager.Instance.ServerDeliverItems(activeContractId, itemId, num5);
						num += num5;
						int value2;
						int num6 = (_itemCounts.TryGetValue(itemId, out value2) ? value2 : 0);
						_itemCounts[itemId] = Mathf.Min(num6 + num5, num3);
						Debug.Log($"[DeliveryZone] Teslim edildi: {itemId} x{num5} (Contract: {activeContractId})");
					}
				}
			}
			if (num > 0)
			{
				Network_totalDeliveredCount = _totalDeliveredCount + num;
				int num7 = 0;
				for (int j = 0; j < deliveryPallet.MaterialCount; j++)
				{
					num7 += deliveryPallet.GetItemCount(j);
				}
				int num8 = deliveryPallet.ActiveVisualCount;
				if (num7 > 0 && num < num7)
				{
					float num9 = (float)num / (float)num7;
					num8 = Mathf.Max(1, Mathf.RoundToInt((float)deliveryPallet.ActiveVisualCount * num9));
				}
				int b2 = ((preSpawnedVisuals != null) ? preSpawnedVisuals.Count : 0);
				Network_activeVisualCount = Mathf.Min(_activeVisualCount + num8, b2);
				RpcNotifyItemsChanged();
			}
			NetworkServer.Destroy(deliveryPallet.gameObject);
			Debug.Log($"[DeliveryZone] DeliveryPallet silindi, toplam teslim: {_totalDeliveredCount}");
		}
	}

	private int FindMaterialIndex(ActiveContractData contractData, string itemId)
	{
		if (contractData.materialIds == null)
		{
			return -1;
		}
		for (int i = 0; i < contractData.materialIds.Length; i++)
		{
			if (contractData.materialIds[i] == itemId)
			{
				return i;
			}
		}
		return -1;
	}

	private void OnDeliveredCountChanged(int oldValue, int newValue)
	{
		Debug.Log($"[DeliveryZone] Delivered count değişti: {oldValue} -> {newValue}");
	}

	private void OnCurrentContractIdChanged(string oldValue, string newValue)
	{
		UpdateCompanyDisplay();
	}

	private void UpdateCompanyDisplay()
	{
		if (string.IsNullOrEmpty(_currentContractId) || ComputerContractManager.Instance == null)
		{
			return;
		}
		ActiveContractData? deliveryRequestedContract = ComputerContractManager.Instance.GetDeliveryRequestedContract();
		if (!deliveryRequestedContract.HasValue)
		{
			return;
		}
		ContractSO contractConfig = ComputerContractManager.Instance.GetContractConfig(deliveryRequestedContract.Value.contractId);
		if (contractConfig == null || contractConfig.company == null)
		{
			return;
		}
		CleanupMaterialInstances();
		foreach (SpriteRenderer companyLogoRenderer in companyLogoRenderers)
		{
			if (companyLogoRenderer != null)
			{
				companyLogoRenderer.sprite = contractConfig.company.companyLogo;
				Material material = new Material(companyLogoRenderer.sharedMaterial);
				material.color = contractConfig.company.logoColor;
				companyLogoRenderer.material = material;
				_materialInstances.Add(material);
			}
		}
	}

	private void OnActiveVisualCountChanged(int oldValue, int newValue)
	{
		if (newValue == 0)
		{
			StartCoroutine(ApplyVisualInterval(1f, newValue));
		}
		else
		{
			StartCoroutine(ApplyVisualInterval(0f, newValue));
		}
	}

	private IEnumerator ApplyVisualInterval(float time, int visualsToShow)
	{
		yield return new WaitForSeconds(time);
		ApplyVisuals(visualsToShow);
	}

	private void ApplyVisuals(int visualsToShow)
	{
		if (preSpawnedVisuals == null)
		{
			return;
		}
		for (int i = 0; i < preSpawnedVisuals.Count; i++)
		{
			if (preSpawnedVisuals[i] != null)
			{
				preSpawnedVisuals[i].SetActive(i < visualsToShow);
			}
		}
	}

	[ClientRpc]
	private void RpcHideAllVisuals()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void T_DeliveryZone::RpcHideAllVisuals()", -1207192583, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void HideAllVisualsGradually()
	{
		if (preSpawnedVisuals != null)
		{
			if (_hideVisualsCoroutine != null)
			{
				StopCoroutine(_hideVisualsCoroutine);
			}
			_hideVisualsCoroutine = StartCoroutine(HideVisualsCoroutine());
		}
	}

	private IEnumerator HideVisualsCoroutine()
	{
		yield return new WaitForSeconds(visualHideInterval);
		for (int num = preSpawnedVisuals.Count - 1; num >= 0; num--)
		{
			if (preSpawnedVisuals[num] != null && preSpawnedVisuals[num].activeSelf)
			{
				preSpawnedVisuals[num].SetActive(value: false);
			}
		}
		_hideVisualsCoroutine = null;
	}

	private void HideAllVisuals()
	{
		if (preSpawnedVisuals == null)
		{
			return;
		}
		foreach (GameObject preSpawnedVisual in preSpawnedVisuals)
		{
			if (preSpawnedVisual != null)
			{
				preSpawnedVisual.SetActive(value: false);
			}
		}
	}

	[Server]
	public void ResetZone()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_DeliveryZone::ResetZone()' called when server was not active");
			return;
		}
		Network_totalDeliveredCount = 0;
		Network_activeVisualCount = 0;
		Network_currentContractId = "";
		_processedPalletNetIds.Clear();
		_itemCounts.Clear();
		_forkliftsInZone.Clear();
		_playersInZone.Clear();
		Network_isForkliftInZone = false;
		Network_isPlayerInZone = false;
		RpcHideAllVisuals();
		RpcNotifyItemsChanged();
	}

	public float GetCompletionPercentage()
	{
		if (ComputerContractManager.Instance == null)
		{
			return 0f;
		}
		ActiveContractData? deliveryRequestedContract = ComputerContractManager.Instance.GetDeliveryRequestedContract();
		if (!deliveryRequestedContract.HasValue)
		{
			return 0f;
		}
		ActiveContractData value = deliveryRequestedContract.Value;
		if (value.materialCounts == null)
		{
			return 0f;
		}
		int num = 0;
		int[] materialCounts = value.materialCounts;
		foreach (int num2 in materialCounts)
		{
			num += num2;
		}
		if (num <= 0)
		{
			return 0f;
		}
		return Mathf.Clamp01((float)_totalDeliveredCount / (float)num);
	}

	public bool IsContractFullyCompleted()
	{
		if (ComputerContractManager.Instance == null)
		{
			return false;
		}
		ActiveContractData? deliveryRequestedContract = ComputerContractManager.Instance.GetDeliveryRequestedContract();
		if (!deliveryRequestedContract.HasValue)
		{
			return false;
		}
		ActiveContractData value = deliveryRequestedContract.Value;
		if (value.materialCounts == null || value.deliveredCounts == null)
		{
			return false;
		}
		for (int i = 0; i < value.materialCounts.Length; i++)
		{
			int num = value.materialCounts[i];
			if (((i < value.deliveredCounts.Length) ? value.deliveredCounts[i] : 0) < num)
			{
				return false;
			}
		}
		return true;
	}

	public bool IsZoneItemsMatchContract()
	{
		if (ComputerContractManager.Instance == null)
		{
			return false;
		}
		ActiveContractData? deliveryRequestedContract = ComputerContractManager.Instance.GetDeliveryRequestedContract();
		if (!deliveryRequestedContract.HasValue)
		{
			return false;
		}
		ActiveContractData value = deliveryRequestedContract.Value;
		if (value.materialIds == null || value.materialCounts == null)
		{
			return false;
		}
		for (int i = 0; i < value.materialIds.Length; i++)
		{
			string itemId = value.materialIds[i];
			int num = value.materialCounts[i];
			if (GetItemCount(itemId) < num)
			{
				return false;
			}
		}
		return true;
	}

	public void ShowForkliftIndicator()
	{
		if (forkliftDeliveryIndicator != null)
		{
			forkliftDeliveryIndicator.SetActive(value: true);
		}
	}

	public void HideForkliftIndicator()
	{
		if (forkliftDeliveryIndicator != null)
		{
			forkliftDeliveryIndicator.SetActive(value: false);
		}
	}

	public bool IsDeliveryPalletNeeded(T_DeliveryPallet deliveryPallet)
	{
		if (deliveryPallet == null || deliveryPallet.IsEmpty)
		{
			return false;
		}
		if (ComputerContractManager.Instance == null)
		{
			return false;
		}
		ActiveContractData? deliveryRequestedContract = ComputerContractManager.Instance.GetDeliveryRequestedContract();
		if (!deliveryRequestedContract.HasValue)
		{
			return false;
		}
		for (int i = 0; i < deliveryPallet.MaterialCount; i++)
		{
			string itemId = deliveryPallet.GetItemId(i);
			if (deliveryPallet.GetItemCount(i) <= 0)
			{
				continue;
			}
			int num = FindMaterialIndex(deliveryRequestedContract.Value, itemId);
			if (num != -1)
			{
				int num2 = deliveryRequestedContract.Value.materialCounts[num];
				int num3 = deliveryRequestedContract.Value.deliveredCounts[num];
				int itemCount = GetItemCount(itemId);
				if (num3 + itemCount < num2)
				{
					return true;
				}
			}
		}
		return false;
	}

	public object GetSaveData(bool includeNonSavable)
	{
		if (!base.isServer)
		{
			return null;
		}
		DeliveryZoneSaveData deliveryZoneSaveData = new DeliveryZoneSaveData
		{
			totalDeliveredCount = _totalDeliveredCount,
			activeVisualCount = _activeVisualCount,
			currentContractId = (_currentContractId ?? string.Empty)
		};
		foreach (KeyValuePair<string, int> itemCount in _itemCounts)
		{
			deliveryZoneSaveData.itemCountKeys.Add(itemCount.Key);
			deliveryZoneSaveData.itemCountValues.Add(itemCount.Value);
		}
		Debug.Log($"[T_DeliveryZone] GetSaveData - TotalDelivered: {_totalDeliveredCount}, VisualCount: {_activeVisualCount}, ContractId: {_currentContractId}");
		return deliveryZoneSaveData;
	}

	public Task OnLoad(object value)
	{
		if (!base.isServer)
		{
			return Task.CompletedTask;
		}
		if (!(value is DeliveryZoneSaveData deliveryZoneSaveData))
		{
			Debug.LogWarning("[T_DeliveryZone] OnLoad - Invalid data type");
			return Task.CompletedTask;
		}
		Network_totalDeliveredCount = deliveryZoneSaveData.totalDeliveredCount;
		Network_activeVisualCount = deliveryZoneSaveData.activeVisualCount;
		Network_currentContractId = deliveryZoneSaveData.currentContractId ?? string.Empty;
		_itemCounts.Clear();
		for (int i = 0; i < deliveryZoneSaveData.itemCountKeys.Count && i < deliveryZoneSaveData.itemCountValues.Count; i++)
		{
			_itemCounts[deliveryZoneSaveData.itemCountKeys[i]] = deliveryZoneSaveData.itemCountValues[i];
		}
		ApplyVisuals(_activeVisualCount);
		Debug.Log($"[T_DeliveryZone] OnLoad - TotalDelivered: {_totalDeliveredCount}, VisualCount: {_activeVisualCount}, ContractId: {_currentContractId}");
		return Task.CompletedTask;
	}

	public T_DeliveryZone()
	{
		InitSyncObject(_itemCounts);
		_Mirror_SyncVarHookDelegate__totalDeliveredCount = OnDeliveredCountChanged;
		_Mirror_SyncVarHookDelegate__activeVisualCount = OnActiveVisualCountChanged;
		_Mirror_SyncVarHookDelegate__currentContractId = OnCurrentContractIdChanged;
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_RpcNotifyItemsChanged()
	{
		OnItemsChanged?.Invoke();
	}

	protected static void InvokeUserCode_RpcNotifyItemsChanged(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcNotifyItemsChanged called on server.");
		}
		else
		{
			((T_DeliveryZone)obj).UserCode_RpcNotifyItemsChanged();
		}
	}

	protected void UserCode_RpcHideAllVisuals()
	{
		HideAllVisualsGradually();
	}

	protected static void InvokeUserCode_RpcHideAllVisuals(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcHideAllVisuals called on server.");
		}
		else
		{
			((T_DeliveryZone)obj).UserCode_RpcHideAllVisuals();
		}
	}

	static T_DeliveryZone()
	{
		RemoteProcedureCalls.RegisterRpc(typeof(T_DeliveryZone), "System.Void T_DeliveryZone::RpcNotifyItemsChanged()", InvokeUserCode_RpcNotifyItemsChanged);
		RemoteProcedureCalls.RegisterRpc(typeof(T_DeliveryZone), "System.Void T_DeliveryZone::RpcHideAllVisuals()", InvokeUserCode_RpcHideAllVisuals);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteVarInt(_totalDeliveredCount);
			writer.WriteVarInt(_activeVisualCount);
			writer.WriteString(_currentContractId);
			writer.WriteBool(_isForkliftInZone);
			writer.WriteBool(_isPlayerInZone);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteVarInt(_totalDeliveredCount);
		}
		if ((syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteVarInt(_activeVisualCount);
		}
		if ((syncVarDirtyBits & 4L) != 0L)
		{
			writer.WriteString(_currentContractId);
		}
		if ((syncVarDirtyBits & 8L) != 0L)
		{
			writer.WriteBool(_isForkliftInZone);
		}
		if ((syncVarDirtyBits & 0x10L) != 0L)
		{
			writer.WriteBool(_isPlayerInZone);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _totalDeliveredCount, _Mirror_SyncVarHookDelegate__totalDeliveredCount, reader.ReadVarInt());
			GeneratedSyncVarDeserialize(ref _activeVisualCount, _Mirror_SyncVarHookDelegate__activeVisualCount, reader.ReadVarInt());
			GeneratedSyncVarDeserialize(ref _currentContractId, _Mirror_SyncVarHookDelegate__currentContractId, reader.ReadString());
			GeneratedSyncVarDeserialize(ref _isForkliftInZone, null, reader.ReadBool());
			GeneratedSyncVarDeserialize(ref _isPlayerInZone, null, reader.ReadBool());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _totalDeliveredCount, _Mirror_SyncVarHookDelegate__totalDeliveredCount, reader.ReadVarInt());
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _activeVisualCount, _Mirror_SyncVarHookDelegate__activeVisualCount, reader.ReadVarInt());
		}
		if ((num & 4L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _currentContractId, _Mirror_SyncVarHookDelegate__currentContractId, reader.ReadString());
		}
		if ((num & 8L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _isForkliftInZone, null, reader.ReadBool());
		}
		if ((num & 0x10L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _isPlayerInZone, null, reader.ReadBool());
		}
	}
}
