using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Enviro;
using GameCreator.Runtime.Common;
using I2.Loc;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;
using UnityEngine.Events;

public class ComputerContractManager : NetworkBehaviour, IGameSave
{
	[Serializable]
	public class ContractManagerSaveData
	{
		public List<ContractListingData> listedContracts = new List<ContractListingData>();

		public List<ActiveContractData> activeContracts = new List<ActiveContractData>();

		public int dailyRefreshCount;

		public int lastRefreshGameDay;

		public string deliveryRequestedContractId;

		public bool deliveryVehicleArrived;
	}

	[Header("Contract Generation Settings")]
	[Tooltip("Aktif property'den kaç contract üretilecek (min)")]
	[Min(1f)]
	[SerializeField]
	private int activePropertyContractMin = 1;

	[Tooltip("Aktif property'den kaç contract üretilecek (max)")]
	[Min(1f)]
	[SerializeField]
	private int activePropertyContractMax = 3;

	[Tooltip("Satın alınabilir property'lerden kaç contract üretilecek (min)")]
	[Min(0f)]
	[SerializeField]
	private int purchasablePropertyContractMin = 1;

	[Tooltip("Satın alınabilir property'lerden kaç contract üretilecek (max)")]
	[Min(1f)]
	[SerializeField]
	private int purchasablePropertyContractMax = 2;

	[Tooltip("Kilitli property'lerden kaç contract üretilecek (min)")]
	[Min(0f)]
	[SerializeField]
	private int lockedPropertyContractMin = 1;

	[Tooltip("Kilitli property'lerden kaç contract üretilecek (max)")]
	[Min(1f)]
	[SerializeField]
	private int lockedPropertyContractMax = 3;

	[Header("Negotiation Settings")]
	[Tooltip("Pazarlık fiyat varyansı minimum")]
	[SerializeField]
	private int priceVarianceMin = 200;

	[Tooltip("Pazarlık fiyat varyansı maximum")]
	[SerializeField]
	private int priceVarianceMax = 500;

	[Header("Contract Limits")]
	[Tooltip("Başlangıç aktif contract kapasitesi (upgrade olmadan)")]
	[SerializeField]
	private int baseContractCapacity = 2;

	[Tooltip("Maksimum aktif contract kapasitesi (full upgrade ile)")]
	[SerializeField]
	private int maxContractCapacity = 5;

	[Tooltip("Günlük contract yenileme hakkı")]
	[SerializeField]
	private int dailyRefreshLimit = 1;

	[Header("Events")]
	public UnityEvent<ContractListingData> onContractListed;

	public UnityEvent<ContractListingData> onContractDelisted;

	public UnityEvent<ActiveContractData> onContractAccepted;

	public UnityEvent<ActiveContractData> onContractCompleted;

	public UnityEvent<ActiveContractData> onContractFailed;

	public UnityEvent<ActiveContractData> onContractUpdated;

	public UnityEvent<ContractNegotiationData> onNegotiationStarted;

	public UnityEvent<ContractNegotiationData> onNegotiationUpdated;

	public UnityEvent<ContractNegotiationData> onNegotiationEnded;

	public UnityEvent onContractsRefreshed;

	public UnityEvent<string> onDeliveryContractChanged;

	[Header("SyncList Events - Client sync için")]
	public UnityEvent<ActiveContractData> onActiveContractSyncAdded;

	public UnityEvent<ActiveContractData> onActiveContractSyncRemoved;

	public UnityEvent<ActiveContractData> onActiveContractSyncUpdated;

	[SyncVar(hook = "OnCurrentNegotiationChanged")]
	private ContractNegotiationData _currentNegotiation;

	[SyncVar]
	private int _currentOfferCount;

	private readonly SyncList<ContractListingData> _listedContracts = new SyncList<ContractListingData>();

	private readonly SyncList<ActiveContractData> _activeContracts = new SyncList<ActiveContractData>();

	private Dictionary<string, ContractSO> _contractConfigCache = new Dictionary<string, ContractSO>();

	private Dictionary<string, PropertyConfigSO> _propertyConfigCache = new Dictionary<string, PropertyConfigSO>();

	[SyncVar]
	private int _dailyRefreshCount;

	[SyncVar]
	private int _lastRefreshGameDay;

	[SyncVar(hook = "OnDeliveryRequestedContractChanged")]
	private string _deliveryRequestedContractId = string.Empty;

	private bool _waitingForContractAccept;

	private float _contractAcceptTimer;

	private ContractNegotiationData _pendingAcceptNegotiation;

	[SyncVar(hook = "OnDeliveryVehicleArrivedChanged")]
	private bool _deliveryVehicleArrived;

	private bool _loadedFromSave;

	[Header("Delivery Vehicle Animation")]
	[Tooltip("Teslimat aracı animatörü")]
	[SerializeField]
	private Animator deliveryVehicleAnimator;

	[Header("Contract Accept Timing")]
	[Tooltip("Contract kabul gecikmesi minimum (saniye)")]
	[SerializeField]
	private float contractAcceptDelayMin = 2f;

	[Tooltip("Contract kabul gecikmesi maximum (saniye)")]
	[SerializeField]
	private float contractAcceptDelayMax = 3f;

	public Action<ContractNegotiationData, ContractNegotiationData> _Mirror_SyncVarHookDelegate__currentNegotiation;

	public Action<string, string> _Mirror_SyncVarHookDelegate__deliveryRequestedContractId;

	public Action<bool, bool> _Mirror_SyncVarHookDelegate__deliveryVehicleArrived;

	public static ComputerContractManager Instance { get; private set; }

	private IReadOnlyList<ContractSO> allContractConfigs => ScriptableListManager.Instance.AllContractConfigs;

	public ContractNegotiationData CurrentNegotiation => _currentNegotiation;

	public bool HasActiveNegotiation => _currentNegotiation.IsActive;

	public IReadOnlyList<ContractListingData> ListedContracts => _listedContracts;

	public int ListedContractCount => _listedContracts.Count;

	public IReadOnlyList<ActiveContractData> ActiveContracts => _activeContracts;

	public int ActiveContractCount => _activeContracts.Count;

	public bool HasActiveContracts => _activeContracts.Count > 0;

	public int MaxActiveContracts => GetCurrentContractCapacity();

	public bool IsContractLimitReached => _activeContracts.Count >= MaxActiveContracts;

	public int RemainingContractCapacity => Mathf.Max(0, MaxActiveContracts - _activeContracts.Count);

	public int DailyRefreshLimit => dailyRefreshLimit;

	public int DailyRefreshCount => _dailyRefreshCount;

	public int RemainingRefreshes => Mathf.Max(0, dailyRefreshLimit - _dailyRefreshCount);

	public bool CanRefresh => RemainingRefreshes > 0;

	public string DeliveryRequestedContractId => _deliveryRequestedContractId;

	public bool HasDeliveryRequest => !string.IsNullOrEmpty(_deliveryRequestedContractId);

	public string SaveID => "computer-contract-manager";

	public bool IsShared => false;

	public Type SaveType => typeof(ContractManagerSaveData);

	public LoadMode LoadMode => LoadMode.Lazy;

	public ContractNegotiationData Network_currentNegotiation
	{
		get
		{
			return _currentNegotiation;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _currentNegotiation, 1uL, _Mirror_SyncVarHookDelegate__currentNegotiation);
		}
	}

	public int Network_currentOfferCount
	{
		get
		{
			return _currentOfferCount;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _currentOfferCount, 2uL, null);
		}
	}

	public int Network_dailyRefreshCount
	{
		get
		{
			return _dailyRefreshCount;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _dailyRefreshCount, 4uL, null);
		}
	}

	public int Network_lastRefreshGameDay
	{
		get
		{
			return _lastRefreshGameDay;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _lastRefreshGameDay, 8uL, null);
		}
	}

	public string Network_deliveryRequestedContractId
	{
		get
		{
			return _deliveryRequestedContractId;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _deliveryRequestedContractId, 16uL, _Mirror_SyncVarHookDelegate__deliveryRequestedContractId);
		}
	}

	public bool Network_deliveryVehicleArrived
	{
		get
		{
			return _deliveryVehicleArrived;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _deliveryVehicleArrived, 32uL, _Mirror_SyncVarHookDelegate__deliveryVehicleArrived);
		}
	}

	public ActiveContractData? GetDeliveryRequestedContract()
	{
		if (string.IsNullOrEmpty(_deliveryRequestedContractId))
		{
			return null;
		}
		foreach (ActiveContractData activeContract in _activeContracts)
		{
			if (activeContract.activeId == _deliveryRequestedContractId)
			{
				return activeContract;
			}
		}
		return null;
	}

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		Instance = this;
		SyncList<ContractListingData> listedContracts = _listedContracts;
		listedContracts.Callback = (Action<SyncList<ContractListingData>.Operation, int, ContractListingData, ContractListingData>)Delegate.Combine(listedContracts.Callback, new Action<SyncList<ContractListingData>.Operation, int, ContractListingData, ContractListingData>(OnListedContractsChanged));
		SyncList<ActiveContractData> activeContracts = _activeContracts;
		activeContracts.Callback = (Action<SyncList<ActiveContractData>.Operation, int, ActiveContractData, ActiveContractData>)Delegate.Combine(activeContracts.Callback, new Action<SyncList<ActiveContractData>.Operation, int, ActiveContractData, ActiveContractData>(OnActiveContractsChanged));
	}

	private void OnDestroy()
	{
		SaveLoadManager.Unsubscribe(this);
		if (Instance == this)
		{
			Instance = null;
		}
		SyncList<ContractListingData> listedContracts = _listedContracts;
		listedContracts.Callback = (Action<SyncList<ContractListingData>.Operation, int, ContractListingData, ContractListingData>)Delegate.Remove(listedContracts.Callback, new Action<SyncList<ContractListingData>.Operation, int, ContractListingData, ContractListingData>(OnListedContractsChanged));
		SyncList<ActiveContractData> activeContracts = _activeContracts;
		activeContracts.Callback = (Action<SyncList<ActiveContractData>.Operation, int, ActiveContractData, ActiveContractData>)Delegate.Remove(activeContracts.Callback, new Action<SyncList<ActiveContractData>.Operation, int, ActiveContractData, ActiveContractData>(OnActiveContractsChanged));
	}

	public override void OnStartServer()
	{
		base.OnStartServer();
		BuildConfigCaches();
		if (DayNightManager.Instance != null)
		{
			DayNightManager.Instance.OnDayStarted += OnDayStarted;
		}
		if (ComputerPropertyManager.Instance != null)
		{
			ComputerPropertyManager.Instance.onPropertyPurchased.AddListener(OnPropertyPurchased);
		}
		CheckAndResetDailyRefresh();
		StartCoroutine(WaitForPropertyManagerAndGenerateContracts());
		if (LoadingManagerUI.Instance != null)
		{
			LoadingManagerUI.Instance.OnLoadingFinished.AddListener(OnLoadingFinished);
		}
		SaveLoadManager.Subscribe(this, 50);
	}

	public override void OnStopServer()
	{
		base.OnStopServer();
		if (DayNightManager.Instance != null)
		{
			DayNightManager.Instance.OnDayStarted -= OnDayStarted;
		}
		if (ComputerPropertyManager.Instance != null)
		{
			ComputerPropertyManager.Instance.onPropertyPurchased.RemoveListener(OnPropertyPurchased);
		}
		if (LoadingManagerUI.Instance != null)
		{
			LoadingManagerUI.Instance.OnLoadingFinished.RemoveListener(OnLoadingFinished);
		}
	}

	private void OnLoadingFinished(LoadingType loadingType)
	{
		_loadedFromSave = false;
		Debug.Log("[ComputerContractManager] Loading kapandı, _loadedFromSave resetlendi.");
	}

	private void OnDayStarted()
	{
		if (base.isServer)
		{
			CheckAndResetDailyRefresh();
			CheckActiveContractDeadlines();
			ServerRefreshContracts(useRefreshLimit: false);
		}
	}

	private void OnPropertyPurchased(PropertyListingData purchasedProperty)
	{
		if (base.isServer)
		{
			if (((FactoryManager.Instance != null && FactoryManager.Instance.Level != 0) ? 1 : 0) <= (false ? 1 : 0))
			{
				Debug.Log("[ComputerContractManager] Property satın alındı ama factory level 0 - contract üretimi atlanıyor.");
				return;
			}
			Debug.Log("[ComputerContractManager] Property satın alındı: " + purchasedProperty.LocalizedName + " - Aktif property contract'ları ekleniyor...");
			BuildConfigCaches();
			GenerateContractsFromActiveProperty();
			Debug.Log($"[ComputerContractManager] Property satın alındı - Toplam {_listedContracts.Count} contract listelendi.");
		}
	}

	private IEnumerator WaitForPropertyManagerAndGenerateContracts()
	{
		float loadingTimeout = 10f;
		float loadingElapsed = 0f;
		while (loadingElapsed < loadingTimeout)
		{
			if (_loadedFromSave)
			{
				Debug.Log("[ComputerContractManager] Save'den yüklendi, initial contracts atlanıyor.");
				yield break;
			}
			if (LoadingManagerUI.Instance == null || !LoadingManagerUI.Instance.IsLoading)
			{
				break;
			}
			loadingElapsed += 0.2f;
			yield return new WaitForSeconds(0.2f);
		}
		if (_loadedFromSave)
		{
			Debug.Log("[ComputerContractManager] Save'den yüklendi, initial contracts atlanıyor.");
			yield break;
		}
		float timeout = 5f;
		float elapsed = 0f;
		while (elapsed < timeout)
		{
			if (_loadedFromSave)
			{
				Debug.Log("[ComputerContractManager] Save'den yüklendi, initial contracts atlanıyor.");
				yield break;
			}
			if (ComputerPropertyManager.Instance != null && ComputerPropertyManager.Instance.ListedProperties.Count > 0)
			{
				Debug.Log($"[ComputerContractManager] PropertyManager hazır - {ComputerPropertyManager.Instance.ListedProperties.Count} property bulundu.");
				GenerateInitialContracts();
				yield break;
			}
			elapsed += 0.1f;
			yield return new WaitForSeconds(0.1f);
		}
		if (_loadedFromSave)
		{
			Debug.Log("[ComputerContractManager] Save'den yüklendi, initial contracts atlanıyor.");
			yield break;
		}
		Debug.Log("[ComputerContractManager] PropertyManager timeout - contract üretimi deneniyor...");
		GenerateInitialContracts();
	}

	public override void OnStartClient()
	{
		base.OnStartClient();
		if (!base.isServer)
		{
			BuildConfigCaches();
			StartCoroutine(WaitForSyncListAndBuildCaches());
		}
	}

	private IEnumerator WaitForSyncListAndBuildCaches()
	{
		float timeout = 5f;
		float elapsed = 0f;
		while (elapsed < timeout)
		{
			if (_listedContracts.Count > 0)
			{
				BuildConfigCaches();
				Debug.Log($"[ComputerContractManager] Client cache'ler güncellendi - {_contractConfigCache.Count} contract config.");
				yield break;
			}
			elapsed += 0.2f;
			yield return new WaitForSeconds(0.2f);
		}
		Debug.Log("[ComputerContractManager] Client cache timeout - listedContracts boş olabilir.");
	}

	private void Update()
	{
		if (base.isServer)
		{
			UpdateContractAcceptTimer();
		}
	}

	[Server]
	private void CheckAndResetDailyRefresh()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ComputerContractManager::CheckAndResetDailyRefresh()' called when server was not active");
			return;
		}
		int num = ((!(DayNightManager.Instance != null)) ? 1 : DayNightManager.Instance.CurrentGameDay);
		if (_lastRefreshGameDay != num)
		{
			Network_lastRefreshGameDay = num;
			Network_dailyRefreshCount = 0;
			Debug.Log($"[ComputerContractManager] Yeni oyun günü ({num}) - yenileme hakkı sıfırlandı.");
		}
	}

	private void BuildConfigCaches()
	{
		_contractConfigCache.Clear();
		_propertyConfigCache.Clear();
		foreach (ContractSO allContractConfig in allContractConfigs)
		{
			if (allContractConfig != null && !string.IsNullOrEmpty(allContractConfig.ContractId))
			{
				_contractConfigCache[allContractConfig.ContractId] = allContractConfig;
			}
		}
		if (ComputerPropertyManager.Instance != null)
		{
			foreach (PropertyConfigSO allPropertyConfig in GetAllPropertyConfigs())
			{
				if (!(allPropertyConfig != null) || string.IsNullOrEmpty(allPropertyConfig.ConfigId))
				{
					continue;
				}
				_propertyConfigCache[allPropertyConfig.ConfigId] = allPropertyConfig;
				if (allPropertyConfig.contracts == null)
				{
					continue;
				}
				foreach (ContractSO contract in allPropertyConfig.contracts)
				{
					if (contract != null && !string.IsNullOrEmpty(contract.ContractId) && !_contractConfigCache.ContainsKey(contract.ContractId))
					{
						_contractConfigCache[contract.ContractId] = contract;
					}
				}
			}
		}
		Debug.Log($"[ComputerContractManager] {_propertyConfigCache.Count} property config, {_contractConfigCache.Count} contract config cache'e eklendi.");
	}

	private List<PropertyConfigSO> GetAllPropertyConfigs()
	{
		List<PropertyConfigSO> list = new List<PropertyConfigSO>();
		if (ComputerPropertyManager.Instance != null)
		{
			if (ComputerPropertyManager.Instance.HasActiveProperty)
			{
				PropertyConfigSO configForListing = ComputerPropertyManager.Instance.GetConfigForListing(ComputerPropertyManager.Instance.ActiveProperty);
				if (configForListing != null && !list.Contains(configForListing))
				{
					list.Add(configForListing);
				}
			}
			foreach (PropertyListingData listedProperty in ComputerPropertyManager.Instance.ListedProperties)
			{
				PropertyConfigSO config = ComputerPropertyManager.Instance.GetConfig(listedProperty.configId);
				if (config != null && !list.Contains(config))
				{
					list.Add(config);
				}
			}
		}
		return list;
	}

	public ContractSO GetContractConfig(string contractId)
	{
		if (string.IsNullOrEmpty(contractId))
		{
			return null;
		}
		_contractConfigCache.TryGetValue(contractId, out var value);
		return value;
	}

	public PropertyConfigSO GetPropertyConfig(string propertyConfigId)
	{
		if (string.IsNullOrEmpty(propertyConfigId))
		{
			return null;
		}
		_propertyConfigCache.TryGetValue(propertyConfigId, out var value);
		return value;
	}

	public ContractSO GetConfigForListing(ContractListingData listing)
	{
		return GetContractConfig(listing.contractId);
	}

	public void RequestRefreshContracts(bool useRefreshLimit = true)
	{
		if (!base.isServer)
		{
			Debug.Log("[ComputerContractManager] Bu işlem sadece host tarafından yapılabilir!");
			NotificationManager.Instance?.ShowNotification(LocalizationManager.GetTranslation("Notification_OnlyFactoryOwnerCanDoThis"), isComputer: true);
		}
		else
		{
			ServerRefreshContracts(useRefreshLimit);
		}
	}

	public void RequestClearAllListings()
	{
		if (!base.isServer)
		{
			Debug.Log("[ComputerContractManager] Bu işlem sadece host tarafından yapılabilir!");
			NotificationManager.Instance?.ShowNotification(LocalizationManager.GetTranslation("Notification_OnlyFactoryOwnerCanDoThis"), isComputer: true);
		}
		else
		{
			ServerClearAllListings();
		}
	}

	public void RequestStartNegotiation(string listingId)
	{
		if (!string.IsNullOrEmpty(listingId))
		{
			uint playerNetId = NetworkClient.localPlayer?.netId ?? 0;
			if (base.isServer)
			{
				ServerStartNegotiation(listingId, playerNetId, NetworkServer.localConnection);
			}
			else
			{
				CmdRequestStartNegotiation(listingId, playerNetId);
			}
		}
	}

	public void RequestMakeOffer(int offerAmount)
	{
		if (!HasActiveNegotiation)
		{
			Debug.Log("[ComputerContractManager] Aktif pazarlık yok!");
			return;
		}
		uint num = NetworkClient.localPlayer?.netId ?? 0;
		if (_currentNegotiation.negotiatorNetId != num)
		{
			Debug.Log("[ComputerContractManager] Bu pazarlık size ait değil!");
		}
		else if (base.isServer)
		{
			ServerProcessOffer(offerAmount);
		}
		else
		{
			CmdRequestMakeOffer(offerAmount);
		}
	}

	public void RequestAcceptFinalOffer()
	{
		if (!HasActiveNegotiation || _currentNegotiation.state != NegotiationState.FinalOffer)
		{
			Debug.Log("[ComputerContractManager] Final teklif aşamasında değilsiniz!");
			return;
		}
		uint num = NetworkClient.localPlayer?.netId ?? 0;
		if (_currentNegotiation.negotiatorNetId != num)
		{
			Debug.Log("[ComputerContractManager] Bu pazarlık size ait değil!");
		}
		else if (base.isServer)
		{
			ServerAcceptFinalOffer();
		}
		else
		{
			CmdRequestAcceptFinalOffer();
		}
	}

	public void RequestCancelNegotiation()
	{
		if (!HasActiveNegotiation)
		{
			Debug.Log("[ComputerContractManager] Aktif pazarlık yok!");
			return;
		}
		uint num = NetworkClient.localPlayer?.netId ?? 0;
		if (_currentNegotiation.negotiatorNetId != num)
		{
			Debug.Log("[ComputerContractManager] Bu pazarlık size ait değil!");
		}
		else if (base.isServer)
		{
			ServerCancelNegotiation();
		}
		else
		{
			CmdRequestCancelNegotiation();
		}
	}

	public void RequestDeliverMaterial(string activeContractId, string materialId, int amount)
	{
		if (string.IsNullOrEmpty(activeContractId) || string.IsNullOrEmpty(materialId) || amount <= 0)
		{
			Debug.Log("[ComputerContractManager] Geçersiz teslimat parametreleri!");
		}
		else if (base.isServer)
		{
			ServerDeliverMaterial(activeContractId, materialId, amount);
		}
		else
		{
			CmdRequestDeliverMaterial(activeContractId, materialId, amount);
		}
	}

	public void RequestCancelContract(string activeContractId)
	{
		if (string.IsNullOrEmpty(activeContractId))
		{
			Debug.Log("[ComputerContractManager] Geçersiz contract ID!");
		}
		else if (base.isServer)
		{
			ServerCancelContract(activeContractId);
		}
		else
		{
			CmdRequestCancelContract(activeContractId);
		}
	}

	public void RequestSetDeliveryContract(string activeContractId)
	{
		if (string.IsNullOrEmpty(activeContractId))
		{
			Debug.Log("[ComputerContractManager] Geçersiz contract ID!");
			return;
		}
		bool flag = false;
		foreach (ActiveContractData activeContract in _activeContracts)
		{
			if (activeContract.activeId == activeContractId)
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			Debug.Log("[ComputerContractManager] Aktif contract bulunamadı: " + activeContractId);
		}
		else if (base.isServer)
		{
			ServerSetDeliveryContract(activeContractId);
		}
		else
		{
			CmdRequestSetDeliveryContract(activeContractId);
		}
	}

	public void RequestClearDeliveryContract()
	{
		if (base.isServer)
		{
			ServerClearDeliveryContract(NetworkServer.localConnection);
		}
		else
		{
			CmdRequestClearDeliveryContract();
		}
	}

	public void RequestCancelDeliveryOnly()
	{
		if (base.isServer)
		{
			ServerCancelDeliveryOnly();
		}
		else
		{
			CmdRequestCancelDeliveryOnly();
		}
	}

	public void RequestSendDeliveryVehicle(string activeContractId)
	{
		if (base.isServer)
		{
			ServerSendDeliveryVehicle(activeContractId);
		}
		else
		{
			CmdRequestSendDeliveryVehicle(activeContractId);
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdRequestRefreshContracts(bool useRefreshLimit, NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdRequestRefreshContracts__Boolean__NetworkConnectionToClient(useRefreshLimit, sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(useRefreshLimit);
		SendCommandInternal("System.Void ComputerContractManager::CmdRequestRefreshContracts(System.Boolean,Mirror.NetworkConnectionToClient)", -253872436, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdRequestClearAllListings(NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdRequestClearAllListings__NetworkConnectionToClient(sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void ComputerContractManager::CmdRequestClearAllListings(Mirror.NetworkConnectionToClient)", -1795483022, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdRequestStartNegotiation(string listingId, uint playerNetId, NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdRequestStartNegotiation__String__UInt32__NetworkConnectionToClient(listingId, playerNetId, sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(listingId);
		writer.WriteVarUInt(playerNetId);
		SendCommandInternal("System.Void ComputerContractManager::CmdRequestStartNegotiation(System.String,System.UInt32,Mirror.NetworkConnectionToClient)", 656195874, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdRequestMakeOffer(int offerAmount)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdRequestMakeOffer__Int32(offerAmount);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(offerAmount);
		SendCommandInternal("System.Void ComputerContractManager::CmdRequestMakeOffer(System.Int32)", 1510468911, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdRequestAcceptFinalOffer()
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdRequestAcceptFinalOffer();
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void ComputerContractManager::CmdRequestAcceptFinalOffer()", 1678899126, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdRequestCancelNegotiation()
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdRequestCancelNegotiation();
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void ComputerContractManager::CmdRequestCancelNegotiation()", 830672969, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdRequestDeliverMaterial(string activeContractId, string materialId, int amount)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdRequestDeliverMaterial__String__String__Int32(activeContractId, materialId, amount);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(activeContractId);
		writer.WriteString(materialId);
		writer.WriteVarInt(amount);
		SendCommandInternal("System.Void ComputerContractManager::CmdRequestDeliverMaterial(System.String,System.String,System.Int32)", -304121377, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdRequestCancelContract(string activeContractId)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdRequestCancelContract__String(activeContractId);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(activeContractId);
		SendCommandInternal("System.Void ComputerContractManager::CmdRequestCancelContract(System.String)", 1216229418, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdRequestSetDeliveryContract(string activeContractId)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdRequestSetDeliveryContract__String(activeContractId);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(activeContractId);
		SendCommandInternal("System.Void ComputerContractManager::CmdRequestSetDeliveryContract(System.String)", 347110678, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdRequestClearDeliveryContract(NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdRequestClearDeliveryContract__NetworkConnectionToClient(sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void ComputerContractManager::CmdRequestClearDeliveryContract(Mirror.NetworkConnectionToClient)", -1455816254, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdRequestCancelDeliveryOnly()
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdRequestCancelDeliveryOnly();
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void ComputerContractManager::CmdRequestCancelDeliveryOnly()", 80995128, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdRequestSendDeliveryVehicle(string activeContractId)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdRequestSendDeliveryVehicle__String(activeContractId);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(activeContractId);
		SendCommandInternal("System.Void ComputerContractManager::CmdRequestSendDeliveryVehicle(System.String)", 686681270, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void GenerateInitialContracts()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ComputerContractManager::GenerateInitialContracts()' called when server was not active");
		}
		else
		{
			ServerRefreshContracts(useRefreshLimit: false);
		}
	}

	[Server]
	private void ServerRefreshContracts(bool useRefreshLimit = true)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ComputerContractManager::ServerRefreshContracts(System.Boolean)' called when server was not active");
			return;
		}
		Debug.Log("[ComputerContractManager] ServerRefreshContracts başlatılıyor...");
		if (((FactoryManager.Instance != null && FactoryManager.Instance.Level != 0) ? 1 : 0) <= (false ? 1 : 0))
		{
			Debug.Log("[ComputerContractManager] Factory level 0 - contract üretimi atlanıyor.");
			return;
		}
		if (useRefreshLimit)
		{
			CheckAndResetDailyRefresh();
			if (_dailyRefreshCount >= dailyRefreshLimit)
			{
				Debug.Log("[ComputerContractManager] Günlük yenileme limiti doldu!");
				return;
			}
			Network_dailyRefreshCount = _dailyRefreshCount + 1;
			Debug.Log($"[ComputerContractManager] Yenileme kullanıldı: {_dailyRefreshCount}/{dailyRefreshLimit}");
		}
		_listedContracts.Clear();
		BuildConfigCaches();
		if (ComputerPropertyManager.Instance == null)
		{
			Debug.Log("[ComputerContractManager] ComputerPropertyManager.Instance NULL!");
		}
		else
		{
			Debug.Log($"[ComputerContractManager] PropertyManager OK - HasActiveProperty: {ComputerPropertyManager.Instance.HasActiveProperty}, ListedCount: {ComputerPropertyManager.Instance.ListedProperties.Count}");
		}
		GenerateContractsFromActiveProperty();
		GenerateContractsFromPurchasableProperties();
		GenerateContractsFromLockedProperties();
		Debug.Log($"[ComputerContractManager] Toplam {_listedContracts.Count} contract listelendi.");
		if (NetworkServer.active && NetworkClient.isConnected)
		{
			onContractsRefreshed?.Invoke();
		}
		RpcOnContractsRefreshed();
	}

	[Server]
	private void GenerateContractsFromActiveProperty()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ComputerContractManager::GenerateContractsFromActiveProperty()' called when server was not active");
			return;
		}
		if (ComputerPropertyManager.Instance == null || !ComputerPropertyManager.Instance.HasActiveProperty)
		{
			Debug.Log("[ComputerContractManager] Aktif property yok, contract üretilemiyor.");
			return;
		}
		PropertyListingData activeProperty = ComputerPropertyManager.Instance.ActiveProperty;
		PropertyConfigSO config = ComputerPropertyManager.Instance.GetConfig(activeProperty.configId);
		if (config == null)
		{
			Debug.Log("[ComputerContractManager] Aktif property config NULL: " + activeProperty.configId);
			return;
		}
		if (config.contracts == null || config.contracts.Count == 0)
		{
			Debug.Log("[ComputerContractManager] Aktif property'nin contract listesi boş: " + activeProperty.LocalizedName + " (ConfigId: " + config.ConfigId + ")");
			return;
		}
		Debug.Log($"[ComputerContractManager] Aktif property'de {config.contracts.Count} contract bulundu: {activeProperty.LocalizedName}");
		int num = FactoryManager.Instance?.Level ?? 1;
		int a = UnityEngine.Random.Range(activePropertyContractMin, activePropertyContractMax + 1);
		a = Mathf.Min(a, config.contracts.Count);
		List<ContractSO> list = new List<ContractSO>(config.contracts);
		ShuffleList(list);
		int num2 = 0;
		for (int i = 0; i < list.Count; i++)
		{
			if (num2 >= a)
			{
				break;
			}
			ContractSO contractSO = list[i];
			if (contractSO == null || !contractSO.HasValidMaterials())
			{
				continue;
			}
			if (contractSO.requiredLevel > num)
			{
				Debug.Log($"[ComputerContractManager] Aktif property contract atlandı (level yetersiz): {contractSO.company?.companyName} (required: {contractSO.requiredLevel}, current: {num})");
				continue;
			}
			ContractListingData item = ContractListingData.CreateFromConfig(contractSO, config, ContractSourceType.ActiveProperty, _listedContracts, _activeContracts);
			if (item.IsValid)
			{
				_listedContracts.Add(item);
				num2++;
				Debug.Log($"[ComputerContractManager] Aktif property contract listelendi: {contractSO.company?.companyName} - ${item.price:N0}");
			}
		}
	}

	[Server]
	private void GenerateContractsFromPurchasableProperties()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ComputerContractManager::GenerateContractsFromPurchasableProperties()' called when server was not active");
			return;
		}
		if (ComputerPropertyManager.Instance == null)
		{
			Debug.Log("[ComputerContractManager] GenerateContractsFromPurchasableProperties - PropertyManager NULL!");
			return;
		}
		int num = FactoryManager.Instance?.Level ?? 1;
		Debug.Log($"[ComputerContractManager] GenerateContractsFromPurchasableProperties - ListedProperties count: {ComputerPropertyManager.Instance.ListedProperties.Count}, CurrentLevel: {num}");
		int num2 = UnityEngine.Random.Range(purchasablePropertyContractMin, purchasablePropertyContractMax + 1);
		int num3 = 0;
		Debug.Log($"[ComputerContractManager] Toplam {num2} purchasable contract üretilecek");
		List<(ContractSO, PropertyConfigSO, string)> list = new List<(ContractSO, PropertyConfigSO, string)>();
		foreach (PropertyListingData listedProperty in ComputerPropertyManager.Instance.ListedProperties)
		{
			PropertyConfigSO config = ComputerPropertyManager.Instance.GetConfig(listedProperty.configId);
			if (config == null || config.contracts == null || config.contracts.Count == 0)
			{
				Debug.Log("[ComputerContractManager] Property " + listedProperty.LocalizedName + " - contracts boş veya config null");
				continue;
			}
			if (listedProperty.propertyLevel > num)
			{
				Debug.Log($"[ComputerContractManager] Property {listedProperty.LocalizedName} - level yetersiz (required: {listedProperty.propertyLevel}, current: {num})");
				continue;
			}
			foreach (ContractSO contract in config.contracts)
			{
				if (!(contract == null) && contract.HasValidMaterials() && contract.requiredLevel <= num)
				{
					list.Add((contract, config, listedProperty.LocalizedName));
				}
			}
		}
		ShuffleList(list);
		for (int i = 0; i < list.Count; i++)
		{
			if (num3 >= num2)
			{
				break;
			}
			(ContractSO, PropertyConfigSO, string) tuple = list[i];
			ContractSO item = tuple.Item1;
			PropertyConfigSO item2 = tuple.Item2;
			string item3 = tuple.Item3;
			ContractListingData item4 = ContractListingData.CreateFromConfig(item, item2, ContractSourceType.PurchasableProperty, _listedContracts, _activeContracts);
			if (item4.IsValid)
			{
				_listedContracts.Add(item4);
				num3++;
				Debug.Log($"[ComputerContractManager] Satın alınabilir property contract listelendi: {item.company?.companyName} ({item3}) - ${item4.price:N0}");
			}
			else
			{
				Debug.Log("[ComputerContractManager] Contract atlandı (zaten mevcut veya geçersiz): " + item.company?.companyName);
			}
		}
		Debug.Log($"[ComputerContractManager] Purchasable contracts: {num3}/{num2} eklendi");
	}

	[Server]
	private void GenerateContractsFromLockedProperties()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ComputerContractManager::GenerateContractsFromLockedProperties()' called when server was not active");
		}
		else
		{
			if (ComputerPropertyManager.Instance == null)
			{
				return;
			}
			int num = FactoryManager.Instance?.Level ?? 1;
			List<(ContractSO, PropertyConfigSO)> list = new List<(ContractSO, PropertyConfigSO)>();
			if (ComputerPropertyManager.Instance.HasActiveProperty)
			{
				PropertyListingData activeProperty = ComputerPropertyManager.Instance.ActiveProperty;
				PropertyConfigSO config = ComputerPropertyManager.Instance.GetConfig(activeProperty.configId);
				if (config?.contracts != null)
				{
					foreach (ContractSO contract in config.contracts)
					{
						if (contract != null && contract.HasValidMaterials() && contract.requiredLevel > num)
						{
							list.Add((contract, config));
						}
					}
				}
			}
			foreach (PropertyListingData listedProperty in ComputerPropertyManager.Instance.ListedProperties)
			{
				PropertyConfigSO config2 = ComputerPropertyManager.Instance.GetConfig(listedProperty.configId);
				if (config2 == null || config2.contracts == null || config2.contracts.Count == 0)
				{
					continue;
				}
				bool flag = listedProperty.propertyLevel > num;
				foreach (ContractSO contract2 in config2.contracts)
				{
					if (!(contract2 == null) && contract2.HasValidMaterials() && (flag || contract2.requiredLevel > num))
					{
						list.Add((contract2, config2));
					}
				}
			}
			if (list.Count == 0)
			{
				return;
			}
			int a = UnityEngine.Random.Range(lockedPropertyContractMin, lockedPropertyContractMax + 1);
			a = Mathf.Min(a, list.Count);
			ShuffleList(list);
			int num2 = 0;
			for (int i = 0; i < list.Count; i++)
			{
				if (num2 >= a)
				{
					break;
				}
				(ContractSO, PropertyConfigSO) tuple = list[i];
				ContractSO item = tuple.Item1;
				PropertyConfigSO item2 = tuple.Item2;
				ContractListingData item3 = ContractListingData.CreateFromConfig(item, item2, ContractSourceType.LockedProperty, _listedContracts, _activeContracts);
				if (item3.IsValid)
				{
					_listedContracts.Add(item3);
					num2++;
					Debug.Log($"[ComputerContractManager] Kilitli contract listelendi: {item.company?.companyName} - ${item3.price:N0} (requiredLevel: {item.requiredLevel})");
				}
			}
		}
	}

	[Server]
	private void ServerClearAllListings()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ComputerContractManager::ServerClearAllListings()' called when server was not active");
			return;
		}
		_listedContracts.Clear();
		Debug.Log("[ComputerContractManager] Tüm contract listeleri temizlendi.");
	}

	[Server]
	private void ServerRemoveListing(string listingId)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ComputerContractManager::ServerRemoveListing(System.String)' called when server was not active");
			return;
		}
		for (int i = 0; i < _listedContracts.Count; i++)
		{
			if (_listedContracts[i].listingId == listingId)
			{
				ContractListingData contractListingData = _listedContracts[i];
				_listedContracts.RemoveAt(i);
				if (NetworkServer.active && NetworkClient.isConnected)
				{
					onContractDelisted?.Invoke(contractListingData);
				}
				RpcOnContractDelisted(contractListingData);
				break;
			}
		}
	}

	[Server]
	private void ServerStartNegotiation(string listingId, uint playerNetId, NetworkConnectionToClient requestingClient = null)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ComputerContractManager::ServerStartNegotiation(System.String,System.UInt32,Mirror.NetworkConnectionToClient)' called when server was not active");
			return;
		}
		if (HasActiveNegotiation)
		{
			Debug.Log("[ComputerContractManager] Zaten aktif pazarlık var!");
			if (requestingClient != null)
			{
				TargetShowNegotiationRejected(requestingClient, "Notification_HasActiveNegotiation");
			}
			return;
		}
		if (IsContractLimitReached)
		{
			Debug.Log("[ComputerContractManager] Contract limiti doldu!");
			if (requestingClient != null)
			{
				TargetShowNegotiationRejected(requestingClient, "Contract Limit Reached");
			}
			return;
		}
		ContractListingData? contractListingData = null;
		foreach (ContractListingData listedContract in _listedContracts)
		{
			if (listedContract.listingId == listingId)
			{
				contractListingData = listedContract;
				break;
			}
		}
		if (!contractListingData.HasValue)
		{
			Debug.Log("[ComputerContractManager] Listing bulunamadı: " + listingId);
			return;
		}
		Network_currentNegotiation = ContractNegotiationData.Create(contractListingData.Value, playerNetId, priceVarianceMin, priceVarianceMax);
		Network_currentOfferCount = 0;
		Debug.Log($"[ComputerContractManager] Pazarlık başladı: {contractListingData.Value.companyName} - Baz: ${contractListingData.Value.price:N0}, Red Sınırı: ${_currentNegotiation.rejectThreshold:N0}, NPC Hedef: ${_currentNegotiation.npcCurrentTarget:N0}");
		if (NetworkServer.active && NetworkClient.isConnected)
		{
			onNegotiationStarted?.Invoke(_currentNegotiation);
		}
		RpcOnNegotiationStarted(_currentNegotiation);
	}

	[Server]
	private void ServerProcessOffer(int offerAmount)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ComputerContractManager::ServerProcessOffer(System.Int32)' called when server was not active");
			return;
		}
		if (!HasActiveNegotiation)
		{
			Debug.Log("[ComputerContractManager] Aktif pazarlık yok!");
			return;
		}
		Network_currentOfferCount = _currentOfferCount + 1;
		ContractNegotiationData currentNegotiation = _currentNegotiation;
		ContractNegotiationData contractNegotiationData = (Network_currentNegotiation = currentNegotiation.ProcessOffer(offerAmount, _currentOfferCount));
		Debug.Log($"[ComputerContractManager] Teklif işlendi: ${offerAmount:N0} - Durum: {contractNegotiationData.state} - Mesaj: {contractNegotiationData.buyerMessage}");
		if (NetworkServer.active && NetworkClient.isConnected)
		{
			onNegotiationUpdated?.Invoke(contractNegotiationData);
		}
		RpcOnNegotiationUpdated(contractNegotiationData);
		if (contractNegotiationData.state == NegotiationState.Accepted)
		{
			ServerScheduleContractAcceptance(contractNegotiationData);
		}
	}

	[Server]
	private void ServerAcceptFinalOffer()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ComputerContractManager::ServerAcceptFinalOffer()' called when server was not active");
			return;
		}
		if (!HasActiveNegotiation || _currentNegotiation.state != NegotiationState.FinalOffer)
		{
			Debug.Log("[ComputerContractManager] Final teklif aşamasında değil!");
			return;
		}
		ContractNegotiationData currentNegotiation = _currentNegotiation;
		ContractNegotiationData contractNegotiationData = (Network_currentNegotiation = currentNegotiation.AcceptFinalOffer());
		Debug.Log($"[ComputerContractManager] Final teklif kabul edildi: ${contractNegotiationData.npcCurrentTarget:N0}");
		if (NetworkServer.active && NetworkClient.isConnected)
		{
			onNegotiationUpdated?.Invoke(contractNegotiationData);
		}
		RpcOnNegotiationUpdated(contractNegotiationData);
		ServerScheduleContractAcceptance(contractNegotiationData);
	}

	[Server]
	private void ServerCancelNegotiation()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ComputerContractManager::ServerCancelNegotiation()' called when server was not active");
			return;
		}
		if (!HasActiveNegotiation)
		{
			Debug.Log("[ComputerContractManager] Aktif pazarlık yok!");
			return;
		}
		Debug.Log("[ComputerContractManager] Pazarlık iptal edildi.");
		Network_currentNegotiation = default(ContractNegotiationData);
	}

	[Server]
	private void UpdateContractAcceptTimer()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ComputerContractManager::UpdateContractAcceptTimer()' called when server was not active");
		}
		else if (_waitingForContractAccept)
		{
			_contractAcceptTimer -= Time.deltaTime;
			if (_contractAcceptTimer <= 0f)
			{
				_waitingForContractAccept = false;
				ServerCompleteContractAcceptance(_pendingAcceptNegotiation);
			}
		}
	}

	[Server]
	private void ServerScheduleContractAcceptance(ContractNegotiationData negotiation)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ComputerContractManager::ServerScheduleContractAcceptance(ContractNegotiationData)' called when server was not active");
			return;
		}
		_pendingAcceptNegotiation = negotiation;
		_waitingForContractAccept = true;
		_contractAcceptTimer = UnityEngine.Random.Range(contractAcceptDelayMin, contractAcceptDelayMax);
		Debug.Log($"[ComputerContractManager] Contract kabul işlemi zamanlandı - {_contractAcceptTimer:F2}s");
	}

	[Server]
	private void ServerCompleteContractAcceptance(ContractNegotiationData negotiationData)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ComputerContractManager::ServerCompleteContractAcceptance(ContractNegotiationData)' called when server was not active");
			return;
		}
		Debug.Log($"[ComputerContractManager] Contract kabul edildi - State: {negotiationData.state}, ListingId: {negotiationData.listingId}");
		if (negotiationData.state != NegotiationState.Accepted)
		{
			Debug.Log("[ComputerContractManager] Geçerli bir kabul durumu yok!");
			return;
		}
		ContractListingData? contractListingData = null;
		for (int i = 0; i < _listedContracts.Count; i++)
		{
			if (_listedContracts[i].listingId == negotiationData.listingId)
			{
				contractListingData = _listedContracts[i];
				break;
			}
		}
		if (!contractListingData.HasValue)
		{
			Debug.Log("[ComputerContractManager] Kabul edilecek listing bulunamadı! ListingId: " + negotiationData.listingId);
			return;
		}
		int lastOfferAmount = negotiationData.lastOfferAmount;
		ActiveContractData activeContractData = ActiveContractData.CreateFromListing(contractListingData.Value, lastOfferAmount);
		_activeContracts.Add(activeContractData);
		ServerRemoveListing(contractListingData.Value.listingId);
		Debug.Log($"[ComputerContractManager] Contract aktif edildi: {contractListingData.Value.companyName} - ${lastOfferAmount:N0}");
		ContractNegotiationData contractNegotiationData = negotiationData;
		Network_currentNegotiation = default(ContractNegotiationData);
		if (NetworkServer.active && NetworkClient.isConnected)
		{
			onContractAccepted?.Invoke(activeContractData);
			onNegotiationEnded?.Invoke(contractNegotiationData);
		}
		RpcOnContractAccepted(activeContractData);
		RpcOnNegotiationEnded(contractNegotiationData);
		TutorialManager.Instance?.TryCompleteSubStep(TutorialConfigType.Day2, TutorialStepType.Contracts, TutorialSubStepType.AcceptContract);
	}

	[Server]
	private void ServerDeliverMaterial(string activeContractId, string materialId, int amount)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ComputerContractManager::ServerDeliverMaterial(System.String,System.String,System.Int32)' called when server was not active");
			return;
		}
		int num = -1;
		for (int i = 0; i < _activeContracts.Count; i++)
		{
			if (_activeContracts[i].activeId == activeContractId)
			{
				num = i;
				break;
			}
		}
		if (num == -1)
		{
			Debug.Log("[ComputerContractManager] Aktif contract bulunamadı: " + activeContractId);
			return;
		}
		ActiveContractData activeContractData = _activeContracts[num];
		if (!activeContractData.IsActive)
		{
			Debug.Log("[ComputerContractManager] Contract aktif değil!");
			return;
		}
		int num2 = -1;
		for (int j = 0; j < activeContractData.materialIds.Length; j++)
		{
			if (activeContractData.materialIds[j] == materialId)
			{
				num2 = j;
				break;
			}
		}
		if (num2 == -1)
		{
			Debug.Log("[ComputerContractManager] Material bulunamadı: " + materialId);
			return;
		}
		ActiveContractData activeContractData2 = activeContractData.DeliverMaterial(num2, amount);
		_activeContracts[num] = activeContractData2;
		Debug.Log($"[ComputerContractManager] Malzeme teslim edildi: {materialId} x{amount}");
		if (NetworkServer.active && NetworkClient.isConnected)
		{
			onContractUpdated?.Invoke(activeContractData2);
		}
		RpcOnContractUpdated(activeContractData2);
		if (activeContractData2.state == ActiveContractState.Completed)
		{
			ServerCompleteContract(num);
		}
	}

	[Server]
	private void ServerCompleteContract(int contractIndex)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ComputerContractManager::ServerCompleteContract(System.Int32)' called when server was not active");
		}
		else if (contractIndex >= 0 && contractIndex < _activeContracts.Count)
		{
			ActiveContractData activeContractData = _activeContracts[contractIndex];
			if (_deliveryRequestedContractId == activeContractData.activeId)
			{
				ServerClearDeliveryContract();
			}
			if (FactoryManager.Instance != null)
			{
				FactoryManager.Instance.AddMoney(activeContractData.agreedPrice, EconomyType.EconomyType_Contract);
				Debug.Log($"[ComputerContractManager] Contract tamamlandı, para alındı: ${activeContractData.agreedPrice:N0}");
			}
			if (NetworkServer.active && NetworkClient.isConnected)
			{
				onContractCompleted?.Invoke(activeContractData);
			}
			RpcOnContractCompleted(activeContractData);
			_activeContracts.RemoveAt(contractIndex);
		}
	}

	[Server]
	private void ServerCancelContract(string activeContractId)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ComputerContractManager::ServerCancelContract(System.String)' called when server was not active");
			return;
		}
		int num = -1;
		for (int i = 0; i < _activeContracts.Count; i++)
		{
			if (_activeContracts[i].activeId == activeContractId)
			{
				num = i;
				break;
			}
		}
		if (num == -1)
		{
			Debug.Log("[ComputerContractManager] İptal edilecek contract bulunamadı: " + activeContractId);
			return;
		}
		ActiveContractData activeContractData = _activeContracts[num];
		if (_deliveryRequestedContractId == activeContractData.activeId)
		{
			ServerClearDeliveryContract();
		}
		ActiveContractData activeContractData2 = activeContractData.Cancel();
		Debug.Log("[ComputerContractManager] Contract iptal edildi: " + activeContractData.companyName);
		if (NetworkServer.active && NetworkClient.isConnected)
		{
			onContractFailed?.Invoke(activeContractData2);
		}
		RpcOnContractFailed(activeContractData2);
		_activeContracts.RemoveAt(num);
	}

	[Server]
	private void CheckActiveContractDeadlines()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ComputerContractManager::CheckActiveContractDeadlines()' called when server was not active");
			return;
		}
		for (int num = _activeContracts.Count - 1; num >= 0; num--)
		{
			ActiveContractData activeContractData = _activeContracts[num];
			if (activeContractData.IsActive && activeContractData.IsExpired)
			{
				if (_deliveryRequestedContractId == activeContractData.activeId)
				{
					ServerClearDeliveryContract();
				}
				ActiveContractData activeContractData2 = activeContractData.MarkAsFailed();
				_activeContracts[num] = activeContractData2;
				Debug.Log("[ComputerContractManager] Contract süresi doldu: " + activeContractData.companyName);
				if (NetworkServer.active && NetworkClient.isConnected)
				{
					onContractFailed?.Invoke(activeContractData2);
				}
				RpcOnContractFailed(activeContractData2);
				_activeContracts.RemoveAt(num);
			}
		}
	}

	[Server]
	private void ServerSetDeliveryContract(string activeContractId)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ComputerContractManager::ServerSetDeliveryContract(System.String)' called when server was not active");
			return;
		}
		bool flag = false;
		foreach (ActiveContractData activeContract in _activeContracts)
		{
			if (activeContract.activeId == activeContractId)
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			Debug.Log("[ComputerContractManager] Aktif contract bulunamadı: " + activeContractId);
			return;
		}
		Network_deliveryRequestedContractId = activeContractId;
		Debug.Log("[ComputerContractManager] Delivery request ayarlandı: " + activeContractId);
		Network_deliveryVehicleArrived = true;
		RpcTriggerDeliveryAnimation("Arrival");
		if (NetworkServer.active && NetworkClient.isConnected)
		{
			onDeliveryContractChanged?.Invoke(activeContractId);
		}
	}

	[Server]
	public void ServerClearDeliveryContract(NetworkConnectionToClient completingPlayer = null)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ComputerContractManager::ServerClearDeliveryContract(Mirror.NetworkConnectionToClient)' called when server was not active");
		}
		else
		{
			if (string.IsNullOrEmpty(_deliveryRequestedContractId))
			{
				return;
			}
			Network_deliveryVehicleArrived = false;
			RpcTriggerDeliveryAnimation("Departure");
			string deliveryRequestedContractId = _deliveryRequestedContractId;
			int num = -1;
			for (int i = 0; i < _activeContracts.Count; i++)
			{
				if (_activeContracts[i].activeId == deliveryRequestedContractId)
				{
					num = i;
					break;
				}
			}
			Network_deliveryRequestedContractId = string.Empty;
			if (num != -1)
			{
				ActiveContractData activeContractData = _activeContracts[num];
				bool flag = false;
				if (activeContractData.deliveredCounts != null)
				{
					int[] deliveredCounts = activeContractData.deliveredCounts;
					for (int j = 0; j < deliveredCounts.Length; j++)
					{
						if (deliveredCounts[j] > 0)
						{
							flag = true;
							break;
						}
					}
				}
				if (!flag && T_DeliveryZone.Instance != null && T_DeliveryZone.Instance.TotalDeliveredCount > 0)
				{
					flag = true;
				}
				if (flag)
				{
					ContractCompletionResult result = CalculateCompletionResult(activeContractData);
					if (FactoryManager.Instance != null && result.totalEarnings > 0)
					{
						FactoryManager.Instance.AddMoney(result.totalEarnings, EconomyType.EconomyType_Contract);
					}
					if (FactoryManager.Instance != null && result.earnedXP > 0)
					{
						FactoryManager.Instance.AddXP(result.earnedXP, EconomyType.EconomyType_Contract);
					}
					ActiveContractData activeContractData2 = activeContractData;
					activeContractData2.state = ActiveContractState.Completed;
					if (NetworkServer.active && NetworkClient.isConnected)
					{
						onContractCompleted?.Invoke(activeContractData2);
					}
					RpcOnContractCompleted(activeContractData2);
					if (completingPlayer != null)
					{
						TargetShowContractCompletedUI(completingPlayer, result);
					}
					else if (NetworkServer.localConnection != null)
					{
						TargetShowContractCompletedUI(NetworkServer.localConnection, result);
					}
					_activeContracts.RemoveAt(num);
				}
			}
			if (T_DeliveryZone.Instance != null)
			{
				T_DeliveryZone.Instance.ResetZone();
			}
			if (NetworkServer.active && NetworkClient.isConnected)
			{
				onDeliveryContractChanged?.Invoke(string.Empty);
			}
		}
	}

	[Server]
	public void ServerCancelDeliveryOnly()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ComputerContractManager::ServerCancelDeliveryOnly()' called when server was not active");
		}
		else if (!string.IsNullOrEmpty(_deliveryRequestedContractId))
		{
			Network_deliveryVehicleArrived = false;
			RpcTriggerDeliveryAnimation("Departure");
			string deliveryRequestedContractId = _deliveryRequestedContractId;
			Network_deliveryRequestedContractId = string.Empty;
			Debug.Log("[ComputerContractManager] Delivery sadece iptal edildi (ödeme yok): " + deliveryRequestedContractId);
			if (T_DeliveryZone.Instance != null)
			{
				T_DeliveryZone.Instance.ResetZone();
			}
			if (NetworkServer.active && NetworkClient.isConnected)
			{
				onDeliveryContractChanged?.Invoke(string.Empty);
			}
		}
	}

	[Server]
	public void ServerDeliverItems(string activeContractId, string itemId, int amount)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ComputerContractManager::ServerDeliverItems(System.String,System.String,System.Int32)' called when server was not active");
		}
		else
		{
			if (string.IsNullOrEmpty(activeContractId) || string.IsNullOrEmpty(itemId) || amount <= 0)
			{
				return;
			}
			int num = -1;
			for (int i = 0; i < _activeContracts.Count; i++)
			{
				if (_activeContracts[i].activeId == activeContractId)
				{
					num = i;
					break;
				}
			}
			if (num == -1)
			{
				Debug.Log("[ComputerContractManager] Teslimat için contract bulunamadı: " + activeContractId);
				return;
			}
			ActiveContractData activeContractData = _activeContracts[num];
			int num2 = -1;
			if (activeContractData.materialIds != null)
			{
				for (int j = 0; j < activeContractData.materialIds.Length; j++)
				{
					if (activeContractData.materialIds[j] == itemId)
					{
						num2 = j;
						break;
					}
				}
			}
			if (num2 == -1)
			{
				Debug.Log("[ComputerContractManager] Contract'ta bu item bulunamadı: " + itemId);
				return;
			}
			ActiveContractData value = activeContractData.DeliverMaterial(num2, amount);
			_activeContracts[num] = value;
			Debug.Log($"[ComputerContractManager] Teslimat yapıldı: {itemId} x{amount} (Contract: {activeContractId})");
		}
	}

	[Server]
	public void ServerSendDeliveryVehicle(string activeContractId)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ComputerContractManager::ServerSendDeliveryVehicle(System.String)' called when server was not active");
		}
		else
		{
			if (string.IsNullOrEmpty(activeContractId))
			{
				return;
			}
			int num = -1;
			for (int i = 0; i < _activeContracts.Count; i++)
			{
				if (_activeContracts[i].activeId == activeContractId)
				{
					num = i;
					break;
				}
			}
			if (num == -1)
			{
				Debug.Log("[ComputerContractManager] Araç göndermek için contract bulunamadı: " + activeContractId);
				return;
			}
			ActiveContractData activeContractData = _activeContracts[num];
			int num2 = CalculatePayment(activeContractData);
			if (_deliveryRequestedContractId == activeContractId)
			{
				Network_deliveryRequestedContractId = string.Empty;
				if (NetworkServer.active && NetworkClient.isConnected)
				{
					onDeliveryContractChanged?.Invoke(string.Empty);
				}
			}
			if (FactoryManager.Instance != null && num2 > 0)
			{
				FactoryManager.Instance.AddMoney(num2, EconomyType.EconomyType_Contract);
				Debug.Log($"[ComputerContractManager] Teslimat tamamlandı, ödeme: ${num2:N0} (Tam fiyat: ${activeContractData.agreedPrice:N0})");
			}
			ActiveContractData activeContractData2 = activeContractData;
			activeContractData2.state = ActiveContractState.Completed;
			if (NetworkServer.active && NetworkClient.isConnected)
			{
				onContractCompleted?.Invoke(activeContractData2);
			}
			RpcOnContractCompleted(activeContractData2);
			_activeContracts.RemoveAt(num);
			Debug.Log("[ComputerContractManager] Contract teslim edildi ve tamamlandı: " + activeContractData.companyName);
		}
	}

	private ContractCompletionResult CalculateCompletionResult(ActiveContractData contract)
	{
		ContractCompletionResult result = new ContractCompletionResult
		{
			contract = contract,
			basePrice = contract.agreedPrice,
			earlyDeliveryBonus = 0,
			missingDeliveryPenalty = 0,
			totalEarnings = 0,
			earnedXP = 0,
			isFullDelivery = false,
			isEarlyDelivery = false,
			remainingDays = 0,
			totalDays = contract.deliveryDays,
			deliveryCompletionRatio = 0f
		};
		if (contract.materialCounts == null)
		{
			return result;
		}
		int num = 0;
		int num2 = 0;
		int[] array = new int[contract.materialCounts.Length];
		for (int i = 0; i < contract.materialCounts.Length; i++)
		{
			num += contract.materialCounts[i];
			int a = 0;
			if (contract.deliveredCounts != null && i < contract.deliveredCounts.Length)
			{
				a = contract.deliveredCounts[i];
			}
			int b = 0;
			if (T_DeliveryZone.Instance != null && contract.materialIds != null && i < contract.materialIds.Length)
			{
				b = T_DeliveryZone.Instance.GetItemCount(contract.materialIds[i]);
			}
			num2 += Mathf.Min(array[i] = Mathf.Max(a, b), contract.materialCounts[i]);
		}
		result.finalDeliveredCounts = array;
		if (num <= 0)
		{
			return result;
		}
		result.deliveryCompletionRatio = (float)num2 / (float)num;
		result.isFullDelivery = num2 >= num;
		int num3 = ((DayNightManager.Instance != null) ? DayNightManager.Instance.CurrentGameDay : contract.acceptedDay);
		result.remainingDays = Mathf.Max(0, contract.deadlineDay - num3);
		result.isEarlyDelivery = result.remainingDays > 0;
		int basePrice = ((!result.isFullDelivery) ? Mathf.FloorToInt((float)contract.agreedPrice / (float)num * (float)num2) : contract.agreedPrice);
		result.basePrice = basePrice;
		if (result.isFullDelivery && result.isEarlyDelivery && result.totalDays > 0)
		{
			float t = (float)result.remainingDays / (float)result.totalDays;
			float num4 = Mathf.Lerp(0.05f, 0.1f, t);
			result.earlyDeliveryBonus = Mathf.FloorToInt((float)contract.agreedPrice * num4);
		}
		if (!result.isFullDelivery)
		{
			float t2 = 1f - result.deliveryCompletionRatio;
			float num5 = Mathf.Lerp(0.05f, 0.1f, t2);
			result.missingDeliveryPenalty = -Mathf.FloorToInt((float)contract.agreedPrice * num5);
		}
		result.totalEarnings = result.basePrice + result.earlyDeliveryBonus + result.missingDeliveryPenalty;
		result.totalEarnings = Mathf.Max(0, result.totalEarnings);
		int num6 = 200;
		ContractSO contractConfig = GetContractConfig(contract.contractId);
		if (contractConfig != null)
		{
			num6 = contractConfig.TierXP;
		}
		int b2 = (result.isFullDelivery ? num6 : Mathf.FloorToInt((float)num6 * result.deliveryCompletionRatio));
		result.earnedXP = Mathf.Max(1, b2);
		return result;
	}

	private int CalculatePayment(ActiveContractData contract)
	{
		if (contract.materialCounts == null)
		{
			return 0;
		}
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < contract.materialCounts.Length; i++)
		{
			num += contract.materialCounts[i];
			int a = 0;
			if (contract.deliveredCounts != null && i < contract.deliveredCounts.Length)
			{
				a = contract.deliveredCounts[i];
			}
			int b = 0;
			if (T_DeliveryZone.Instance != null && contract.materialIds != null && i < contract.materialIds.Length)
			{
				b = T_DeliveryZone.Instance.GetItemCount(contract.materialIds[i]);
			}
			int a2 = Mathf.Max(a, b);
			num2 += Mathf.Min(a2, contract.materialCounts[i]);
		}
		if (num <= 0)
		{
			return 0;
		}
		if (contract.AllMaterialsDelivered())
		{
			return contract.agreedPrice;
		}
		float num3 = (float)contract.agreedPrice / (float)num * (float)num2;
		float num4 = 0.9f;
		int num5 = Mathf.FloorToInt(num3 * num4);
		Debug.Log($"[ComputerContractManager] Kısmi teslimat: {num2}/{num} item, " + $"Tam fiyat: ${contract.agreedPrice:N0}, Kısmi: ${num3:N0}, " + $"Ceza sonrası: ${num5:N0}");
		return num5;
	}

	[ClientRpc]
	private void RpcOnContractListed(ContractListingData listing)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_ContractListingData(writer, listing);
		SendRPCInternal("System.Void ComputerContractManager::RpcOnContractListed(ContractListingData)", -1151570536, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcOnContractDelisted(ContractListingData listing)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_ContractListingData(writer, listing);
		SendRPCInternal("System.Void ComputerContractManager::RpcOnContractDelisted(ContractListingData)", 910686557, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcOnContractAccepted(ActiveContractData contract)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_ActiveContractData(writer, contract);
		SendRPCInternal("System.Void ComputerContractManager::RpcOnContractAccepted(ActiveContractData)", -956850408, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcOnContractCompleted(ActiveContractData contract)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_ActiveContractData(writer, contract);
		SendRPCInternal("System.Void ComputerContractManager::RpcOnContractCompleted(ActiveContractData)", -15879452, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcOnContractFailed(ActiveContractData contract)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_ActiveContractData(writer, contract);
		SendRPCInternal("System.Void ComputerContractManager::RpcOnContractFailed(ActiveContractData)", -652008664, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcOnContractUpdated(ActiveContractData contract)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_ActiveContractData(writer, contract);
		SendRPCInternal("System.Void ComputerContractManager::RpcOnContractUpdated(ActiveContractData)", -221454234, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcOnNegotiationStarted(ContractNegotiationData negotiation)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_ContractNegotiationData(writer, negotiation);
		SendRPCInternal("System.Void ComputerContractManager::RpcOnNegotiationStarted(ContractNegotiationData)", -2112735088, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcOnNegotiationUpdated(ContractNegotiationData negotiation)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_ContractNegotiationData(writer, negotiation);
		SendRPCInternal("System.Void ComputerContractManager::RpcOnNegotiationUpdated(ContractNegotiationData)", -1888081746, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcOnNegotiationEnded(ContractNegotiationData negotiation)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_ContractNegotiationData(writer, negotiation);
		SendRPCInternal("System.Void ComputerContractManager::RpcOnNegotiationEnded(ContractNegotiationData)", 547026879, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcTriggerDeliveryAnimation(string triggerName)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(triggerName);
		SendRPCInternal("System.Void ComputerContractManager::RpcTriggerDeliveryAnimation(System.String)", -1735678542, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcOnContractsRefreshed()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void ComputerContractManager::RpcOnContractsRefreshed()", -61497448, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[TargetRpc]
	private void TargetShowNegotiationRejected(NetworkConnectionToClient target, string localizationKey)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(localizationKey);
		SendTargetRPCInternal(target, "System.Void ComputerContractManager::TargetShowNegotiationRejected(Mirror.NetworkConnectionToClient,System.String)", 1584535381, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[TargetRpc]
	private void TargetShowContractCompletedUI(NetworkConnectionToClient target, ContractCompletionResult result)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_ContractCompletionResult(writer, result);
		SendTargetRPCInternal(target, "System.Void ComputerContractManager::TargetShowContractCompletedUI(Mirror.NetworkConnectionToClient,ContractCompletionResult)", 1594872916, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	private void OnCurrentNegotiationChanged(ContractNegotiationData oldValue, ContractNegotiationData newValue)
	{
		Debug.Log($"[ComputerContractManager] Pazarlık durumu değişti: {newValue.state}");
	}

	private void OnDeliveryRequestedContractChanged(string oldValue, string newValue)
	{
		Debug.Log("[ComputerContractManager] Delivery request değişti: " + oldValue + " -> " + newValue);
		if (!base.isServer)
		{
			onDeliveryContractChanged?.Invoke(newValue);
		}
	}

	private void OnDeliveryVehicleArrivedChanged(bool oldValue, bool newValue)
	{
		if (newValue && deliveryVehicleAnimator != null)
		{
			deliveryVehicleAnimator.SetTrigger("Arrival");
		}
	}

	private void OnListedContractsChanged(SyncList<ContractListingData>.Operation op, int index, ContractListingData oldItem, ContractListingData newItem)
	{
		Debug.Log($"[ComputerContractManager] Contract listesi değişti: {op} - Toplam: {_listedContracts.Count}");
		if (!base.isServer && (uint)op == 0u)
		{
			BuildConfigCaches();
		}
	}

	private void OnActiveContractsChanged(SyncList<ActiveContractData>.Operation op, int index, ActiveContractData oldItem, ActiveContractData newItem)
	{
		Debug.Log($"[ComputerContractManager] Aktif contract listesi değişti: {op} - Toplam: {_activeContracts.Count}");
		switch (op)
		{
		case SyncList<ActiveContractData>.Operation.OP_ADD:
			onActiveContractSyncAdded?.Invoke(newItem);
			break;
		case SyncList<ActiveContractData>.Operation.OP_REMOVEAT:
			onActiveContractSyncRemoved?.Invoke(oldItem);
			break;
		case SyncList<ActiveContractData>.Operation.OP_SET:
			onActiveContractSyncUpdated?.Invoke(newItem);
			break;
		case SyncList<ActiveContractData>.Operation.OP_CLEAR:
			onActiveContractSyncRemoved?.Invoke(oldItem);
			break;
		case SyncList<ActiveContractData>.Operation.OP_INSERT:
			break;
		}
	}

	private int GetCurrentContractCapacity()
	{
		if (UpgradeManager.Instance == null)
		{
			return baseContractCapacity;
		}
		int upgradeLevel = UpgradeManager.Instance.GetUpgradeLevel(UpgradeType.TradingAbility);
		return Mathf.Clamp(baseContractCapacity + upgradeLevel, baseContractCapacity, maxContractCapacity);
	}

	private void ShuffleList<T>(List<T> list)
	{
		int num = list.Count;
		while (num > 1)
		{
			num--;
			int index = UnityEngine.Random.Range(0, num + 1);
			T value = list[index];
			list[index] = list[num];
			list[num] = value;
		}
	}

	public ContractListingData? GetListing(string listingId)
	{
		foreach (ContractListingData listedContract in _listedContracts)
		{
			if (listedContract.listingId == listingId)
			{
				return listedContract;
			}
		}
		return null;
	}

	public ActiveContractData? GetActiveContract(string activeId)
	{
		foreach (ActiveContractData activeContract in _activeContracts)
		{
			if (activeContract.activeId == activeId)
			{
				return activeContract;
			}
		}
		return null;
	}

	public List<ContractListingData> GetListingsBySource(ContractSourceType sourceType)
	{
		return _listedContracts.Where((ContractListingData l) => l.sourceType == sourceType).ToList();
	}

	public List<ContractListingData> GetListingsSortedByPrice(bool ascending = true)
	{
		List<ContractListingData> list = _listedContracts.ToList();
		if (ascending)
		{
			list.Sort((ContractListingData a, ContractListingData b) => a.price.CompareTo(b.price));
		}
		else
		{
			list.Sort((ContractListingData a, ContractListingData b) => b.price.CompareTo(a.price));
		}
		return list;
	}

	[ContextMenu("Test: Refresh Contracts")]
	private void TestRefreshContracts()
	{
		RequestRefreshContracts();
	}

	[ContextMenu("Test: Clear All Listings")]
	private void TestClearAllListings()
	{
		RequestClearAllListings();
	}

	[ContextMenu("Test: Start Negotiation (First Listing)")]
	private void TestStartNegotiation()
	{
		if (_listedContracts.Count > 0)
		{
			RequestStartNegotiation(_listedContracts[0].listingId);
		}
	}

	[ContextMenu("Test: Make Offer (Base Price + 500)")]
	private void TestMakeOffer()
	{
		if (HasActiveNegotiation)
		{
			RequestMakeOffer(_currentNegotiation.basePrice + 500);
		}
	}

	[ContextMenu("Debug: Show All Listings")]
	private void DebugShowAllListings()
	{
		Debug.Log($"=== Listelenen Contract'lar ({_listedContracts.Count}) ===");
		foreach (ContractListingData listedContract in _listedContracts)
		{
			Debug.Log($"  - {listedContract.companyName} | ${listedContract.price:N0} | {listedContract.sourceType} | Materials: {listedContract.MaterialCount}");
		}
	}

	[ContextMenu("Debug: Show Active Contracts")]
	private void DebugShowActiveContracts()
	{
		Debug.Log($"=== Aktif Contract'lar ({_activeContracts.Count}) ===");
		foreach (ActiveContractData activeContract in _activeContracts)
		{
			Debug.Log($"  - {activeContract.companyName} | ${activeContract.agreedPrice:N0} | Progress: {activeContract.GetTotalProgress():P0} | Remaining: {activeContract.RemainingDays} days");
		}
	}

	[ContextMenu("Debug: Show Negotiation State")]
	private void DebugShowNegotiationState()
	{
		if (HasActiveNegotiation)
		{
			Debug.Log("=== Aktif Pazarlık ===");
			Debug.Log("  Listing: " + _currentNegotiation.listingId);
			Debug.Log($"  Baz Fiyat: ${_currentNegotiation.basePrice:N0}");
			Debug.Log($"  Red Sınırı: ${_currentNegotiation.rejectThreshold:N0}");
			Debug.Log($"  NPC Hedef: ${_currentNegotiation.npcCurrentTarget:N0}");
			Debug.Log($"  Teklif Sayısı: {_currentNegotiation.offerCount}");
			Debug.Log($"  Son Teklif: ${_currentNegotiation.lastOfferAmount:N0}");
			Debug.Log($"  Durum: {_currentNegotiation.state}");
			Debug.Log("  Mesaj: " + _currentNegotiation.buyerMessage);
		}
		else
		{
			Debug.Log("Aktif pazarlık yok.");
		}
	}

	public object GetSaveData(bool includeNonSavable)
	{
		if (!base.isServer)
		{
			return null;
		}
		ContractManagerSaveData contractManagerSaveData = new ContractManagerSaveData
		{
			dailyRefreshCount = _dailyRefreshCount,
			lastRefreshGameDay = _lastRefreshGameDay,
			deliveryRequestedContractId = _deliveryRequestedContractId,
			deliveryVehicleArrived = _deliveryVehicleArrived
		};
		foreach (ContractListingData listedContract in _listedContracts)
		{
			contractManagerSaveData.listedContracts.Add(listedContract);
		}
		foreach (ActiveContractData activeContract in _activeContracts)
		{
			contractManagerSaveData.activeContracts.Add(activeContract);
		}
		Debug.Log($"[ComputerContractManager] GetSaveData - Listed: {contractManagerSaveData.listedContracts.Count}, Active: {contractManagerSaveData.activeContracts.Count}");
		return contractManagerSaveData;
	}

	public Task OnLoad(object value)
	{
		if (!base.isServer)
		{
			return Task.CompletedTask;
		}
		if (!(value is ContractManagerSaveData contractManagerSaveData))
		{
			Debug.LogWarning("[ComputerContractManager] OnLoad - Invalid data type");
			return Task.CompletedTask;
		}
		_loadedFromSave = true;
		_listedContracts.Clear();
		_activeContracts.Clear();
		foreach (ContractListingData listedContract in contractManagerSaveData.listedContracts)
		{
			_listedContracts.Add(listedContract);
		}
		foreach (ActiveContractData activeContract in contractManagerSaveData.activeContracts)
		{
			_activeContracts.Add(activeContract);
		}
		Network_dailyRefreshCount = contractManagerSaveData.dailyRefreshCount;
		Network_lastRefreshGameDay = contractManagerSaveData.lastRefreshGameDay;
		Network_deliveryRequestedContractId = contractManagerSaveData.deliveryRequestedContractId ?? string.Empty;
		Network_deliveryVehicleArrived = contractManagerSaveData.deliveryVehicleArrived;
		Debug.Log($"[ComputerContractManager] OnLoad - Listed: {_listedContracts.Count}, Active: {_activeContracts.Count}, DeliveryRequest: {_deliveryRequestedContractId}");
		return Task.CompletedTask;
	}

	public ComputerContractManager()
	{
		InitSyncObject(_listedContracts);
		InitSyncObject(_activeContracts);
		_Mirror_SyncVarHookDelegate__currentNegotiation = OnCurrentNegotiationChanged;
		_Mirror_SyncVarHookDelegate__deliveryRequestedContractId = OnDeliveryRequestedContractChanged;
		_Mirror_SyncVarHookDelegate__deliveryVehicleArrived = OnDeliveryVehicleArrivedChanged;
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdRequestRefreshContracts__Boolean__NetworkConnectionToClient(bool useRefreshLimit, NetworkConnectionToClient sender)
	{
		if (sender != null && sender != NetworkServer.localConnection)
		{
			Debug.Log("[ComputerContractManager] Command rejected: Only host!");
		}
		else
		{
			ServerRefreshContracts(useRefreshLimit);
		}
	}

	protected static void InvokeUserCode_CmdRequestRefreshContracts__Boolean__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRequestRefreshContracts called on client.");
		}
		else
		{
			((ComputerContractManager)obj).UserCode_CmdRequestRefreshContracts__Boolean__NetworkConnectionToClient(reader.ReadBool(), senderConnection);
		}
	}

	protected void UserCode_CmdRequestClearAllListings__NetworkConnectionToClient(NetworkConnectionToClient sender)
	{
		if (sender != null && sender != NetworkServer.localConnection)
		{
			Debug.Log("[ComputerContractManager] Command rejected: Only host!");
		}
		else
		{
			ServerClearAllListings();
		}
	}

	protected static void InvokeUserCode_CmdRequestClearAllListings__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRequestClearAllListings called on client.");
		}
		else
		{
			((ComputerContractManager)obj).UserCode_CmdRequestClearAllListings__NetworkConnectionToClient(senderConnection);
		}
	}

	protected void UserCode_CmdRequestStartNegotiation__String__UInt32__NetworkConnectionToClient(string listingId, uint playerNetId, NetworkConnectionToClient sender)
	{
		ServerStartNegotiation(listingId, playerNetId, sender);
	}

	protected static void InvokeUserCode_CmdRequestStartNegotiation__String__UInt32__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRequestStartNegotiation called on client.");
		}
		else
		{
			((ComputerContractManager)obj).UserCode_CmdRequestStartNegotiation__String__UInt32__NetworkConnectionToClient(reader.ReadString(), reader.ReadVarUInt(), senderConnection);
		}
	}

	protected void UserCode_CmdRequestMakeOffer__Int32(int offerAmount)
	{
		ServerProcessOffer(offerAmount);
	}

	protected static void InvokeUserCode_CmdRequestMakeOffer__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRequestMakeOffer called on client.");
		}
		else
		{
			((ComputerContractManager)obj).UserCode_CmdRequestMakeOffer__Int32(reader.ReadVarInt());
		}
	}

	protected void UserCode_CmdRequestAcceptFinalOffer()
	{
		ServerAcceptFinalOffer();
	}

	protected static void InvokeUserCode_CmdRequestAcceptFinalOffer(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRequestAcceptFinalOffer called on client.");
		}
		else
		{
			((ComputerContractManager)obj).UserCode_CmdRequestAcceptFinalOffer();
		}
	}

	protected void UserCode_CmdRequestCancelNegotiation()
	{
		ServerCancelNegotiation();
	}

	protected static void InvokeUserCode_CmdRequestCancelNegotiation(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRequestCancelNegotiation called on client.");
		}
		else
		{
			((ComputerContractManager)obj).UserCode_CmdRequestCancelNegotiation();
		}
	}

	protected void UserCode_CmdRequestDeliverMaterial__String__String__Int32(string activeContractId, string materialId, int amount)
	{
		ServerDeliverMaterial(activeContractId, materialId, amount);
	}

	protected static void InvokeUserCode_CmdRequestDeliverMaterial__String__String__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRequestDeliverMaterial called on client.");
		}
		else
		{
			((ComputerContractManager)obj).UserCode_CmdRequestDeliverMaterial__String__String__Int32(reader.ReadString(), reader.ReadString(), reader.ReadVarInt());
		}
	}

	protected void UserCode_CmdRequestCancelContract__String(string activeContractId)
	{
		ServerCancelContract(activeContractId);
	}

	protected static void InvokeUserCode_CmdRequestCancelContract__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRequestCancelContract called on client.");
		}
		else
		{
			((ComputerContractManager)obj).UserCode_CmdRequestCancelContract__String(reader.ReadString());
		}
	}

	protected void UserCode_CmdRequestSetDeliveryContract__String(string activeContractId)
	{
		ServerSetDeliveryContract(activeContractId);
	}

	protected static void InvokeUserCode_CmdRequestSetDeliveryContract__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRequestSetDeliveryContract called on client.");
		}
		else
		{
			((ComputerContractManager)obj).UserCode_CmdRequestSetDeliveryContract__String(reader.ReadString());
		}
	}

	protected void UserCode_CmdRequestClearDeliveryContract__NetworkConnectionToClient(NetworkConnectionToClient sender)
	{
		ServerClearDeliveryContract(sender);
	}

	protected static void InvokeUserCode_CmdRequestClearDeliveryContract__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRequestClearDeliveryContract called on client.");
		}
		else
		{
			((ComputerContractManager)obj).UserCode_CmdRequestClearDeliveryContract__NetworkConnectionToClient(senderConnection);
		}
	}

	protected void UserCode_CmdRequestCancelDeliveryOnly()
	{
		ServerCancelDeliveryOnly();
	}

	protected static void InvokeUserCode_CmdRequestCancelDeliveryOnly(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRequestCancelDeliveryOnly called on client.");
		}
		else
		{
			((ComputerContractManager)obj).UserCode_CmdRequestCancelDeliveryOnly();
		}
	}

	protected void UserCode_CmdRequestSendDeliveryVehicle__String(string activeContractId)
	{
		ServerSendDeliveryVehicle(activeContractId);
	}

	protected static void InvokeUserCode_CmdRequestSendDeliveryVehicle__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRequestSendDeliveryVehicle called on client.");
		}
		else
		{
			((ComputerContractManager)obj).UserCode_CmdRequestSendDeliveryVehicle__String(reader.ReadString());
		}
	}

	protected void UserCode_RpcOnContractListed__ContractListingData(ContractListingData listing)
	{
		if (!base.isServer)
		{
			onContractListed?.Invoke(listing);
		}
	}

	protected static void InvokeUserCode_RpcOnContractListed__ContractListingData(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcOnContractListed called on server.");
		}
		else
		{
			((ComputerContractManager)obj).UserCode_RpcOnContractListed__ContractListingData(GeneratedNetworkCode._Read_ContractListingData(reader));
		}
	}

	protected void UserCode_RpcOnContractDelisted__ContractListingData(ContractListingData listing)
	{
		if (!base.isServer)
		{
			onContractDelisted?.Invoke(listing);
		}
	}

	protected static void InvokeUserCode_RpcOnContractDelisted__ContractListingData(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcOnContractDelisted called on server.");
		}
		else
		{
			((ComputerContractManager)obj).UserCode_RpcOnContractDelisted__ContractListingData(GeneratedNetworkCode._Read_ContractListingData(reader));
		}
	}

	protected void UserCode_RpcOnContractAccepted__ActiveContractData(ActiveContractData contract)
	{
		if (!base.isServer)
		{
			onContractAccepted?.Invoke(contract);
		}
	}

	protected static void InvokeUserCode_RpcOnContractAccepted__ActiveContractData(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcOnContractAccepted called on server.");
		}
		else
		{
			((ComputerContractManager)obj).UserCode_RpcOnContractAccepted__ActiveContractData(GeneratedNetworkCode._Read_ActiveContractData(reader));
		}
	}

	protected void UserCode_RpcOnContractCompleted__ActiveContractData(ActiveContractData contract)
	{
		if (!base.isServer)
		{
			onContractCompleted?.Invoke(contract);
		}
	}

	protected static void InvokeUserCode_RpcOnContractCompleted__ActiveContractData(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcOnContractCompleted called on server.");
		}
		else
		{
			((ComputerContractManager)obj).UserCode_RpcOnContractCompleted__ActiveContractData(GeneratedNetworkCode._Read_ActiveContractData(reader));
		}
	}

	protected void UserCode_RpcOnContractFailed__ActiveContractData(ActiveContractData contract)
	{
		if (!base.isServer)
		{
			onContractFailed?.Invoke(contract);
		}
	}

	protected static void InvokeUserCode_RpcOnContractFailed__ActiveContractData(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcOnContractFailed called on server.");
		}
		else
		{
			((ComputerContractManager)obj).UserCode_RpcOnContractFailed__ActiveContractData(GeneratedNetworkCode._Read_ActiveContractData(reader));
		}
	}

	protected void UserCode_RpcOnContractUpdated__ActiveContractData(ActiveContractData contract)
	{
		if (!base.isServer)
		{
			onContractUpdated?.Invoke(contract);
		}
	}

	protected static void InvokeUserCode_RpcOnContractUpdated__ActiveContractData(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcOnContractUpdated called on server.");
		}
		else
		{
			((ComputerContractManager)obj).UserCode_RpcOnContractUpdated__ActiveContractData(GeneratedNetworkCode._Read_ActiveContractData(reader));
		}
	}

	protected void UserCode_RpcOnNegotiationStarted__ContractNegotiationData(ContractNegotiationData negotiation)
	{
		if (!base.isServer)
		{
			onNegotiationStarted?.Invoke(negotiation);
		}
	}

	protected static void InvokeUserCode_RpcOnNegotiationStarted__ContractNegotiationData(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcOnNegotiationStarted called on server.");
		}
		else
		{
			((ComputerContractManager)obj).UserCode_RpcOnNegotiationStarted__ContractNegotiationData(GeneratedNetworkCode._Read_ContractNegotiationData(reader));
		}
	}

	protected void UserCode_RpcOnNegotiationUpdated__ContractNegotiationData(ContractNegotiationData negotiation)
	{
		if (!base.isServer)
		{
			onNegotiationUpdated?.Invoke(negotiation);
		}
	}

	protected static void InvokeUserCode_RpcOnNegotiationUpdated__ContractNegotiationData(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcOnNegotiationUpdated called on server.");
		}
		else
		{
			((ComputerContractManager)obj).UserCode_RpcOnNegotiationUpdated__ContractNegotiationData(GeneratedNetworkCode._Read_ContractNegotiationData(reader));
		}
	}

	protected void UserCode_RpcOnNegotiationEnded__ContractNegotiationData(ContractNegotiationData negotiation)
	{
		if (!base.isServer)
		{
			onNegotiationEnded?.Invoke(negotiation);
		}
	}

	protected static void InvokeUserCode_RpcOnNegotiationEnded__ContractNegotiationData(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcOnNegotiationEnded called on server.");
		}
		else
		{
			((ComputerContractManager)obj).UserCode_RpcOnNegotiationEnded__ContractNegotiationData(GeneratedNetworkCode._Read_ContractNegotiationData(reader));
		}
	}

	protected void UserCode_RpcTriggerDeliveryAnimation__String(string triggerName)
	{
		if (deliveryVehicleAnimator != null)
		{
			deliveryVehicleAnimator.SetTrigger(triggerName);
		}
	}

	protected static void InvokeUserCode_RpcTriggerDeliveryAnimation__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcTriggerDeliveryAnimation called on server.");
		}
		else
		{
			((ComputerContractManager)obj).UserCode_RpcTriggerDeliveryAnimation__String(reader.ReadString());
		}
	}

	protected void UserCode_RpcOnContractsRefreshed()
	{
		if (!base.isServer)
		{
			BuildConfigCaches();
			onContractsRefreshed?.Invoke();
		}
	}

	protected static void InvokeUserCode_RpcOnContractsRefreshed(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcOnContractsRefreshed called on server.");
		}
		else
		{
			((ComputerContractManager)obj).UserCode_RpcOnContractsRefreshed();
		}
	}

	protected void UserCode_TargetShowNegotiationRejected__NetworkConnectionToClient__String(NetworkConnectionToClient target, string localizationKey)
	{
		if (NotificationManager.Instance != null)
		{
			NotificationManager.Instance.ShowNotification(LocalizationManager.GetTranslation(localizationKey), isComputer: true);
		}
	}

	protected static void InvokeUserCode_TargetShowNegotiationRejected__NetworkConnectionToClient__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("TargetRPC TargetShowNegotiationRejected called on server.");
		}
		else
		{
			((ComputerContractManager)obj).UserCode_TargetShowNegotiationRejected__NetworkConnectionToClient__String(null, reader.ReadString());
		}
	}

	protected void UserCode_TargetShowContractCompletedUI__NetworkConnectionToClient__ContractCompletionResult(NetworkConnectionToClient target, ContractCompletionResult result)
	{
		if (GameManager.Instance != null && GameManager.Instance.UImanager != null && GameManager.Instance.UImanager.computerUI != null)
		{
			GameManager.Instance.UImanager.computerUI.ShowContractCompletedUI(result);
		}
	}

	protected static void InvokeUserCode_TargetShowContractCompletedUI__NetworkConnectionToClient__ContractCompletionResult(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("TargetRPC TargetShowContractCompletedUI called on server.");
		}
		else
		{
			((ComputerContractManager)obj).UserCode_TargetShowContractCompletedUI__NetworkConnectionToClient__ContractCompletionResult(null, GeneratedNetworkCode._Read_ContractCompletionResult(reader));
		}
	}

	static ComputerContractManager()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(ComputerContractManager), "System.Void ComputerContractManager::CmdRequestRefreshContracts(System.Boolean,Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdRequestRefreshContracts__Boolean__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ComputerContractManager), "System.Void ComputerContractManager::CmdRequestClearAllListings(Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdRequestClearAllListings__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ComputerContractManager), "System.Void ComputerContractManager::CmdRequestStartNegotiation(System.String,System.UInt32,Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdRequestStartNegotiation__String__UInt32__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ComputerContractManager), "System.Void ComputerContractManager::CmdRequestMakeOffer(System.Int32)", InvokeUserCode_CmdRequestMakeOffer__Int32, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ComputerContractManager), "System.Void ComputerContractManager::CmdRequestAcceptFinalOffer()", InvokeUserCode_CmdRequestAcceptFinalOffer, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ComputerContractManager), "System.Void ComputerContractManager::CmdRequestCancelNegotiation()", InvokeUserCode_CmdRequestCancelNegotiation, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ComputerContractManager), "System.Void ComputerContractManager::CmdRequestDeliverMaterial(System.String,System.String,System.Int32)", InvokeUserCode_CmdRequestDeliverMaterial__String__String__Int32, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ComputerContractManager), "System.Void ComputerContractManager::CmdRequestCancelContract(System.String)", InvokeUserCode_CmdRequestCancelContract__String, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ComputerContractManager), "System.Void ComputerContractManager::CmdRequestSetDeliveryContract(System.String)", InvokeUserCode_CmdRequestSetDeliveryContract__String, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ComputerContractManager), "System.Void ComputerContractManager::CmdRequestClearDeliveryContract(Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdRequestClearDeliveryContract__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ComputerContractManager), "System.Void ComputerContractManager::CmdRequestCancelDeliveryOnly()", InvokeUserCode_CmdRequestCancelDeliveryOnly, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ComputerContractManager), "System.Void ComputerContractManager::CmdRequestSendDeliveryVehicle(System.String)", InvokeUserCode_CmdRequestSendDeliveryVehicle__String, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(ComputerContractManager), "System.Void ComputerContractManager::RpcOnContractListed(ContractListingData)", InvokeUserCode_RpcOnContractListed__ContractListingData);
		RemoteProcedureCalls.RegisterRpc(typeof(ComputerContractManager), "System.Void ComputerContractManager::RpcOnContractDelisted(ContractListingData)", InvokeUserCode_RpcOnContractDelisted__ContractListingData);
		RemoteProcedureCalls.RegisterRpc(typeof(ComputerContractManager), "System.Void ComputerContractManager::RpcOnContractAccepted(ActiveContractData)", InvokeUserCode_RpcOnContractAccepted__ActiveContractData);
		RemoteProcedureCalls.RegisterRpc(typeof(ComputerContractManager), "System.Void ComputerContractManager::RpcOnContractCompleted(ActiveContractData)", InvokeUserCode_RpcOnContractCompleted__ActiveContractData);
		RemoteProcedureCalls.RegisterRpc(typeof(ComputerContractManager), "System.Void ComputerContractManager::RpcOnContractFailed(ActiveContractData)", InvokeUserCode_RpcOnContractFailed__ActiveContractData);
		RemoteProcedureCalls.RegisterRpc(typeof(ComputerContractManager), "System.Void ComputerContractManager::RpcOnContractUpdated(ActiveContractData)", InvokeUserCode_RpcOnContractUpdated__ActiveContractData);
		RemoteProcedureCalls.RegisterRpc(typeof(ComputerContractManager), "System.Void ComputerContractManager::RpcOnNegotiationStarted(ContractNegotiationData)", InvokeUserCode_RpcOnNegotiationStarted__ContractNegotiationData);
		RemoteProcedureCalls.RegisterRpc(typeof(ComputerContractManager), "System.Void ComputerContractManager::RpcOnNegotiationUpdated(ContractNegotiationData)", InvokeUserCode_RpcOnNegotiationUpdated__ContractNegotiationData);
		RemoteProcedureCalls.RegisterRpc(typeof(ComputerContractManager), "System.Void ComputerContractManager::RpcOnNegotiationEnded(ContractNegotiationData)", InvokeUserCode_RpcOnNegotiationEnded__ContractNegotiationData);
		RemoteProcedureCalls.RegisterRpc(typeof(ComputerContractManager), "System.Void ComputerContractManager::RpcTriggerDeliveryAnimation(System.String)", InvokeUserCode_RpcTriggerDeliveryAnimation__String);
		RemoteProcedureCalls.RegisterRpc(typeof(ComputerContractManager), "System.Void ComputerContractManager::RpcOnContractsRefreshed()", InvokeUserCode_RpcOnContractsRefreshed);
		RemoteProcedureCalls.RegisterRpc(typeof(ComputerContractManager), "System.Void ComputerContractManager::TargetShowNegotiationRejected(Mirror.NetworkConnectionToClient,System.String)", InvokeUserCode_TargetShowNegotiationRejected__NetworkConnectionToClient__String);
		RemoteProcedureCalls.RegisterRpc(typeof(ComputerContractManager), "System.Void ComputerContractManager::TargetShowContractCompletedUI(Mirror.NetworkConnectionToClient,ContractCompletionResult)", InvokeUserCode_TargetShowContractCompletedUI__NetworkConnectionToClient__ContractCompletionResult);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			GeneratedNetworkCode._Write_ContractNegotiationData(writer, _currentNegotiation);
			writer.WriteVarInt(_currentOfferCount);
			writer.WriteVarInt(_dailyRefreshCount);
			writer.WriteVarInt(_lastRefreshGameDay);
			writer.WriteString(_deliveryRequestedContractId);
			writer.WriteBool(_deliveryVehicleArrived);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			GeneratedNetworkCode._Write_ContractNegotiationData(writer, _currentNegotiation);
		}
		if ((syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteVarInt(_currentOfferCount);
		}
		if ((syncVarDirtyBits & 4L) != 0L)
		{
			writer.WriteVarInt(_dailyRefreshCount);
		}
		if ((syncVarDirtyBits & 8L) != 0L)
		{
			writer.WriteVarInt(_lastRefreshGameDay);
		}
		if ((syncVarDirtyBits & 0x10L) != 0L)
		{
			writer.WriteString(_deliveryRequestedContractId);
		}
		if ((syncVarDirtyBits & 0x20L) != 0L)
		{
			writer.WriteBool(_deliveryVehicleArrived);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _currentNegotiation, _Mirror_SyncVarHookDelegate__currentNegotiation, GeneratedNetworkCode._Read_ContractNegotiationData(reader));
			GeneratedSyncVarDeserialize(ref _currentOfferCount, null, reader.ReadVarInt());
			GeneratedSyncVarDeserialize(ref _dailyRefreshCount, null, reader.ReadVarInt());
			GeneratedSyncVarDeserialize(ref _lastRefreshGameDay, null, reader.ReadVarInt());
			GeneratedSyncVarDeserialize(ref _deliveryRequestedContractId, _Mirror_SyncVarHookDelegate__deliveryRequestedContractId, reader.ReadString());
			GeneratedSyncVarDeserialize(ref _deliveryVehicleArrived, _Mirror_SyncVarHookDelegate__deliveryVehicleArrived, reader.ReadBool());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _currentNegotiation, _Mirror_SyncVarHookDelegate__currentNegotiation, GeneratedNetworkCode._Read_ContractNegotiationData(reader));
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _currentOfferCount, null, reader.ReadVarInt());
		}
		if ((num & 4L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _dailyRefreshCount, null, reader.ReadVarInt());
		}
		if ((num & 8L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _lastRefreshGameDay, null, reader.ReadVarInt());
		}
		if ((num & 0x10L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _deliveryRequestedContractId, _Mirror_SyncVarHookDelegate__deliveryRequestedContractId, reader.ReadString());
		}
		if ((num & 0x20L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _deliveryVehicleArrived, _Mirror_SyncVarHookDelegate__deliveryVehicleArrived, reader.ReadBool());
		}
	}
}
