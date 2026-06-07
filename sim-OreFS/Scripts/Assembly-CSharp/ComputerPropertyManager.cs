using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Enviro;
using GameCreator.Runtime.Common;
using I2.Loc;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;
using UnityEngine.Events;

public class ComputerPropertyManager : NetworkBehaviour, IGameSave
{
	[Serializable]
	public class PropertyManagerSaveData
	{
		public PropertyListingData activeProperty;

		public int purchasedPrice;

		public List<PropertyListingData> listedProperties = new List<PropertyListingData>();

		public PropertyNegotiationData currentNegotiation;

		public int currentOfferCount;
	}

	[CompilerGenerated]
	private sealed class _003CServerLoadSceneAfterDelay_003Ed__102 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ComputerPropertyManager _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CServerLoadSceneAfterDelay_003Ed__102(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			ComputerPropertyManager computerPropertyManager = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
			{
				_003C_003E1__state = -1;
				float seconds = UnityEngine.Random.Range(computerPropertyManager.sceneLoadDelayMin, computerPropertyManager.sceneLoadDelayMax);
				_003C_003E2__current = new WaitForSeconds(seconds);
				_003C_003E1__state = 1;
				return true;
			}
			case 1:
				_003C_003E1__state = -1;
				if (computerPropertyManager._hasPendingSceneLoad && PropertyLoader.Instance != null && !string.IsNullOrEmpty(computerPropertyManager._pendingSceneToLoad))
				{
					PropertyLoader.Instance.LoadProperty(computerPropertyManager._pendingSceneToLoad);
					UnityEngine.Debug.Log("[ComputerPropertyManager] Property sahnesi yükleniyor: " + computerPropertyManager._pendingSceneToLoad);
				}
				computerPropertyManager._hasPendingSceneLoad = false;
				computerPropertyManager._pendingSceneToLoad = null;
				return false;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	[Header("Listing Settings")]
	[Tooltip("Toplam maksimum listelenebilir emlak sayısı")]
	[Min(1f)]
	[SerializeField]
	private int maxListedProperties = 2;

	[Tooltip("Tutorial aktifken maksimum listelenebilir emlak sayısı")]
	[Min(1f)]
	[SerializeField]
	private int maxListedPropertiesDuringTutorial = 2;

	[Tooltip("Bir emlağın listede kalma süresi (saniye) - 0 = süresiz")]
	[SerializeField]
	private float listingDuration;

	[Header("Negotiation Settings")]
	[Tooltip("Pazarlık fiyat varyansı minimum")]
	[SerializeField]
	private int priceVarianceMin = 500;

	[Tooltip("Pazarlık fiyat varyansı maximum")]
	[SerializeField]
	private int priceVarianceMax = 1500;

	[Header("Scene Loading Settings")]
	[Tooltip("Scene yükleme gecikmesi minimum (saniye)")]
	[SerializeField]
	private float sceneLoadDelayMin = 1f;

	[Tooltip("Scene yükleme gecikmesi maximum (saniye)")]
	[SerializeField]
	private float sceneLoadDelayMax = 2f;

	[Tooltip("Satın alma onayı gecikmesi minimum (saniye)")]
	[SerializeField]
	private float purchaseConfirmDelayMin = 0.75f;

	[Tooltip("Satın alma onayı gecikmesi maximum (saniye)")]
	[SerializeField]
	private float purchaseConfirmDelayMax = 1.5f;

	[Header("Events")]
	public UnityEvent<PropertyListingData> onPropertyListed;

	public UnityEvent<PropertyListingData> onPropertyDelisted;

	public UnityEvent<PropertyListingData> onPropertyPurchased;

	public UnityEvent onActivePropertyCleared;

	public UnityEvent<PropertyNegotiationData> onNegotiationStarted;

	public UnityEvent<PropertyNegotiationData> onNegotiationUpdated;

	public UnityEvent<PropertyNegotiationData> onNegotiationEnded;

	public UnityEvent onMiningDataUpdated;

	[SyncVar(hook = "OnActivePropertyChanged")]
	private PropertyListingData _activeProperty;

	[SyncVar(hook = "OnCurrentNegotiationChanged")]
	private PropertyNegotiationData _currentNegotiation;

	[SyncVar]
	private int _currentOfferCount;

	[SyncVar]
	private int _purchasedPrice;

	private readonly SyncList<PropertyListingData> _listedProperties = new SyncList<PropertyListingData>();

	private Dictionary<string, PropertyConfigSO> _configCache = new Dictionary<string, PropertyConfigSO>();

	private bool _waitingForPurchaseConfirm;

	private float _purchaseConfirmTimer;

	private PropertyNegotiationData _pendingPurchaseNegotiation;

	private bool _hasPendingSceneLoad;

	private string _pendingSceneToLoad;

	private bool _loadedFromSave;

	private Dictionary<T_ItemAreaSpawner.MiningLayer, Dictionary<string, (int initial, int remaining)>> _cachedMiningDataByLayer = new Dictionary<T_ItemAreaSpawner.MiningLayer, Dictionary<string, (int, int)>>();

	public Action<PropertyListingData, PropertyListingData> _Mirror_SyncVarHookDelegate__activeProperty;

	public Action<PropertyNegotiationData, PropertyNegotiationData> _Mirror_SyncVarHookDelegate__currentNegotiation;

	public static ComputerPropertyManager Instance { get; private set; }

	private IReadOnlyList<PropertyConfigSO> propertyConfigs => ScriptableListManager.Instance.AllPropertyConfigs;

	public PropertyListingData ActiveProperty => _activeProperty;

	public bool HasActiveProperty => _activeProperty.IsValid;

	public int PurchasedPrice => _purchasedPrice;

	public string ActivePropertySpawnerId => _activeProperty.listingId;

	public PropertyNegotiationData CurrentNegotiation => _currentNegotiation;

	public bool HasActiveNegotiation => _currentNegotiation.IsActive;

	public IReadOnlyList<PropertyListingData> ListedProperties => _listedProperties;

	public int ListedPropertyCount => _listedProperties.Count;

	public int MaxListedProperties => EffectiveMaxListedProperties;

	public bool CanListNewProperty => _listedProperties.Count < EffectiveMaxListedProperties;

	private int EffectiveMaxListedProperties
	{
		get
		{
			bool num = TutorialManager.Instance != null && TutorialManager.Instance.IsTutorialRunning;
			bool flag = DayNightManager.Instance != null && DayNightManager.Instance.CurrentGameDay == 1;
			if (!(num || flag))
			{
				return maxListedProperties;
			}
			return maxListedPropertiesDuringTutorial;
		}
	}

	public string SaveID => "computer-property-manager";

	public bool IsShared => false;

	public Type SaveType => typeof(PropertyManagerSaveData);

	public LoadMode LoadMode => LoadMode.Greedy;

	public PropertyListingData Network_activeProperty
	{
		get
		{
			return _activeProperty;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _activeProperty, 1uL, _Mirror_SyncVarHookDelegate__activeProperty);
		}
	}

	public PropertyNegotiationData Network_currentNegotiation
	{
		get
		{
			return _currentNegotiation;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _currentNegotiation, 2uL, _Mirror_SyncVarHookDelegate__currentNegotiation);
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
			GeneratedSyncVarSetter(value, ref _currentOfferCount, 4uL, null);
		}
	}

	public int Network_purchasedPrice
	{
		get
		{
			return _purchasedPrice;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _purchasedPrice, 8uL, null);
		}
	}

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		Instance = this;
		BuildConfigCache();
		SyncList<PropertyListingData> listedProperties = _listedProperties;
		listedProperties.Callback = (Action<SyncList<PropertyListingData>.Operation, int, PropertyListingData, PropertyListingData>)Delegate.Combine(listedProperties.Callback, new Action<SyncList<PropertyListingData>.Operation, int, PropertyListingData, PropertyListingData>(OnListedPropertiesChanged));
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
		SyncList<PropertyListingData> listedProperties = _listedProperties;
		listedProperties.Callback = (Action<SyncList<PropertyListingData>.Operation, int, PropertyListingData, PropertyListingData>)Delegate.Remove(listedProperties.Callback, new Action<SyncList<PropertyListingData>.Operation, int, PropertyListingData, PropertyListingData>(OnListedPropertiesChanged));
	}

	public override void OnStartServer()
	{
		base.OnStartServer();
		if (DayNightManager.Instance != null)
		{
			DayNightManager.Instance.OnDayStarted += OnDayStarted;
		}
		T_Item.OnNodePieceBroken += OnNodePieceBroken;
		if (LoadingManagerUI.Instance != null)
		{
			LoadingManagerUI.Instance.OnLoadingFinished.AddListener(OnLoadingFinished);
		}
		StartCoroutine(WaitForManagersAndGenerateListings());
	}

	private void OnDayStarted()
	{
		if (base.isServer)
		{
			GenerateInitialListings();
		}
	}

	public override void OnStartClient()
	{
		base.OnStartClient();
		if (!base.isServer && HasActiveProperty)
		{
			CmdRequestMiningData();
		}
	}

	public override void OnStopServer()
	{
		base.OnStopServer();
		if (DayNightManager.Instance != null)
		{
			DayNightManager.Instance.OnDayStarted -= OnDayStarted;
		}
		T_Item.OnNodePieceBroken -= OnNodePieceBroken;
		if (LoadingManagerUI.Instance != null)
		{
			LoadingManagerUI.Instance.OnLoadingFinished.RemoveListener(OnLoadingFinished);
		}
		CancelPendingOperations();
	}

	private void OnLoadingFinished(LoadingType loadingType)
	{
		_loadedFromSave = false;
		UnityEngine.Debug.Log("[ComputerPropertyManager] Loading kapandı, _loadedFromSave resetlendi.");
	}

	private void Update()
	{
		if (base.isServer)
		{
			UpdatePurchaseConfirmTimer();
		}
	}

	private void BuildConfigCache()
	{
		_configCache.Clear();
		foreach (PropertyConfigSO propertyConfig in propertyConfigs)
		{
			if (propertyConfig != null && !string.IsNullOrEmpty(propertyConfig.ConfigId))
			{
				_configCache[propertyConfig.ConfigId] = propertyConfig;
			}
		}
		UnityEngine.Debug.Log($"[ComputerPropertyManager] {_configCache.Count} config cache'e eklendi.");
	}

	public PropertyConfigSO GetConfig(string configId)
	{
		if (string.IsNullOrEmpty(configId))
		{
			return null;
		}
		_configCache.TryGetValue(configId, out var value);
		return value;
	}

	public PropertyConfigSO GetConfigForListing(PropertyListingData listing)
	{
		return GetConfig(listing.configId);
	}

	public void RequestGenerateNewListing()
	{
		if (!base.isServer)
		{
			UnityEngine.Debug.LogWarning("[ComputerPropertyManager] Bu işlem sadece host tarafından yapılabilir!");
			NotificationManager.Instance?.ShowNotification(LocalizationManager.GetTranslation("Notification_OnlyFactoryOwnerCanDoThis"), isComputer: true);
		}
		else
		{
			ServerGenerateNewListing();
		}
	}

	public void RequestGenerateListingFromConfig(string configId)
	{
		if (!string.IsNullOrEmpty(configId))
		{
			if (!base.isServer)
			{
				UnityEngine.Debug.LogWarning("[ComputerPropertyManager] Bu işlem sadece host tarafından yapılabilir!");
				NotificationManager.Instance?.ShowNotification(LocalizationManager.GetTranslation("Notification_OnlyFactoryOwnerCanDoThis"), isComputer: true);
			}
			else
			{
				ServerGenerateListingFromConfig(configId);
			}
		}
	}

	public void RequestClearAllListings()
	{
		if (!base.isServer)
		{
			UnityEngine.Debug.LogWarning("[ComputerPropertyManager] Bu işlem sadece host tarafından yapılabilir!");
			NotificationManager.Instance?.ShowNotification(LocalizationManager.GetTranslation("Notification_OnlyFactoryOwnerCanDoThis"), isComputer: true);
		}
		else
		{
			ServerClearAllListings();
		}
	}

	public void RequestClearActiveProperty()
	{
		if (!base.isServer)
		{
			UnityEngine.Debug.LogWarning("[ComputerPropertyManager] Bu işlem sadece host tarafından yapılabilir!");
			NotificationManager.Instance?.ShowNotification(LocalizationManager.GetTranslation("Notification_OnlyFactoryOwnerCanDoThis"), isComputer: true);
		}
		else if (!HasActiveProperty)
		{
			UnityEngine.Debug.LogWarning("[ComputerPropertyManager] Temizlenecek aktif property yok!");
		}
		else
		{
			ServerClearActiveProperty();
		}
	}

	public void RequestStartNegotiation(string listingId)
	{
		if (!string.IsNullOrEmpty(listingId))
		{
			if (!base.isServer)
			{
				UnityEngine.Debug.LogWarning("[ComputerPropertyManager] Bu işlem sadece host tarafından yapılabilir!");
				NotificationManager.Instance?.ShowNotification(LocalizationManager.GetTranslation("Notification_OnlyFactoryOwnerCanDoThis"), isComputer: true);
			}
			else if (HasActiveProperty)
			{
				UnityEngine.Debug.LogWarning("[ComputerPropertyManager] Aktif emlak var, yeni pazarlık başlatılamaz!");
			}
			else if (HasActiveNegotiation)
			{
				UnityEngine.Debug.LogWarning("[ComputerPropertyManager] Zaten aktif bir pazarlık var!");
			}
			else
			{
				uint playerNetId = NetworkClient.localPlayer?.netId ?? 0;
				ServerStartNegotiation(listingId, playerNetId);
			}
		}
	}

	public void RequestMakeOffer(int offerAmount)
	{
		if (!base.isServer)
		{
			UnityEngine.Debug.LogWarning("[ComputerPropertyManager] Bu işlem sadece host tarafından yapılabilir!");
			NotificationManager.Instance?.ShowNotification(LocalizationManager.GetTranslation("Notification_OnlyFactoryOwnerCanDoThis"), isComputer: true);
			return;
		}
		if (!HasActiveNegotiation)
		{
			UnityEngine.Debug.LogWarning("[ComputerPropertyManager] Aktif pazarlık yok!");
			return;
		}
		uint num = NetworkClient.localPlayer?.netId ?? 0;
		if (_currentNegotiation.negotiatorNetId != num)
		{
			UnityEngine.Debug.LogWarning("[ComputerPropertyManager] Bu pazarlık size ait değil!");
		}
		else
		{
			ServerProcessOffer(offerAmount);
		}
	}

	public void RequestAcceptFinalOffer()
	{
		if (!base.isServer)
		{
			UnityEngine.Debug.LogWarning("[ComputerPropertyManager] Bu işlem sadece host tarafından yapılabilir!");
			NotificationManager.Instance?.ShowNotification(LocalizationManager.GetTranslation("Notification_OnlyFactoryOwnerCanDoThis"), isComputer: true);
			return;
		}
		if (!HasActiveNegotiation || _currentNegotiation.state != NegotiationState.FinalOffer)
		{
			UnityEngine.Debug.LogWarning("[ComputerPropertyManager] Final teklif aşamasında değilsiniz!");
			return;
		}
		uint num = NetworkClient.localPlayer?.netId ?? 0;
		if (_currentNegotiation.negotiatorNetId != num)
		{
			UnityEngine.Debug.LogWarning("[ComputerPropertyManager] Bu pazarlık size ait değil!");
		}
		else
		{
			ServerAcceptFinalOffer();
		}
	}

	public void RequestCancelNegotiation()
	{
		if (!base.isServer)
		{
			UnityEngine.Debug.LogWarning("[ComputerPropertyManager] Bu işlem sadece host tarafından yapılabilir!");
			NotificationManager.Instance?.ShowNotification(LocalizationManager.GetTranslation("Notification_OnlyFactoryOwnerCanDoThis"), isComputer: true);
			return;
		}
		if (!HasActiveNegotiation)
		{
			UnityEngine.Debug.LogWarning("[ComputerPropertyManager] Aktif pazarlık yok!");
			return;
		}
		uint num = NetworkClient.localPlayer?.netId ?? 0;
		if (_currentNegotiation.negotiatorNetId != num)
		{
			UnityEngine.Debug.LogWarning("[ComputerPropertyManager] Bu pazarlık size ait değil!");
		}
		else
		{
			ServerCancelNegotiation();
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdRequestGenerateNewListing(NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdRequestGenerateNewListing__NetworkConnectionToClient(sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void ComputerPropertyManager::CmdRequestGenerateNewListing(Mirror.NetworkConnectionToClient)", -1727185081, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdRequestGenerateListingFromConfig(string configId, NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdRequestGenerateListingFromConfig__String__NetworkConnectionToClient(configId, sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(configId);
		SendCommandInternal("System.Void ComputerPropertyManager::CmdRequestGenerateListingFromConfig(System.String,Mirror.NetworkConnectionToClient)", 62311109, writer, 0, requiresAuthority: false);
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
		SendCommandInternal("System.Void ComputerPropertyManager::CmdRequestClearAllListings(Mirror.NetworkConnectionToClient)", -187812285, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdRequestClearActiveProperty(NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdRequestClearActiveProperty__NetworkConnectionToClient(sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void ComputerPropertyManager::CmdRequestClearActiveProperty(Mirror.NetworkConnectionToClient)", 1635434412, writer, 0, requiresAuthority: false);
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
		SendCommandInternal("System.Void ComputerPropertyManager::CmdRequestStartNegotiation(System.String,System.UInt32,Mirror.NetworkConnectionToClient)", -783709541, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdRequestMakeOffer(int offerAmount, NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdRequestMakeOffer__Int32__NetworkConnectionToClient(offerAmount, sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(offerAmount);
		SendCommandInternal("System.Void ComputerPropertyManager::CmdRequestMakeOffer(System.Int32,Mirror.NetworkConnectionToClient)", -1398153303, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdRequestAcceptFinalOffer(NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdRequestAcceptFinalOffer__NetworkConnectionToClient(sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void ComputerPropertyManager::CmdRequestAcceptFinalOffer(Mirror.NetworkConnectionToClient)", -27351476, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdRequestCancelNegotiation(NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdRequestCancelNegotiation__NetworkConnectionToClient(sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void ComputerPropertyManager::CmdRequestCancelNegotiation(Mirror.NetworkConnectionToClient)", -1587415211, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdRequestMiningData(NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdRequestMiningData__NetworkConnectionToClient(sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void ComputerPropertyManager::CmdRequestMiningData(Mirror.NetworkConnectionToClient)", -1549440314, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	private IEnumerator WaitForManagersAndGenerateListings()
	{
		float loadingTimeout = 10f;
		float loadingElapsed = 0f;
		while (loadingElapsed < loadingTimeout)
		{
			if (_loadedFromSave)
			{
				UnityEngine.Debug.Log("[ComputerPropertyManager] Save'den yüklendi, initial listings atlanıyor.");
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
			UnityEngine.Debug.Log("[ComputerPropertyManager] Save'den yüklendi, initial listings atlanıyor.");
			yield break;
		}
		float timeout = 5f;
		float elapsed = 0f;
		while (elapsed < timeout)
		{
			if (_loadedFromSave)
			{
				UnityEngine.Debug.Log("[ComputerPropertyManager] Save'den yüklendi, initial listings atlanıyor.");
				yield break;
			}
			bool num = TutorialManager.Instance != null;
			bool flag = DayNightManager.Instance != null;
			if (num && flag)
			{
				UnityEngine.Debug.Log($"[ComputerPropertyManager] Manager'lar hazır - Tutorial: {TutorialManager.Instance.IsTutorialRunning}, Day: {DayNightManager.Instance.CurrentGameDay}");
				GenerateInitialListings();
				yield break;
			}
			elapsed += 0.1f;
			yield return new WaitForSeconds(0.1f);
		}
		if (_loadedFromSave)
		{
			UnityEngine.Debug.Log("[ComputerPropertyManager] Save'den yüklendi, initial listings atlanıyor.");
			yield break;
		}
		UnityEngine.Debug.LogWarning("[ComputerPropertyManager] Manager'lar timeout - listing üretimi deneniyor...");
		GenerateInitialListings();
	}

	[Server]
	private void GenerateInitialListings()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void ComputerPropertyManager::GenerateInitialListings()' called when server was not active");
			return;
		}
		if (_loadedFromSave)
		{
			UnityEngine.Debug.Log("[ComputerPropertyManager] Save'den yüklendi, initial listings atlanıyor.");
			return;
		}
		if (propertyConfigs.Count == 0)
		{
			UnityEngine.Debug.LogWarning("[ComputerPropertyManager] Config listesi boş!");
			return;
		}
		_listedProperties.Clear();
		for (int i = 0; i < EffectiveMaxListedProperties; i++)
		{
			PropertyConfigSO propertyConfigSO = propertyConfigs[UnityEngine.Random.Range(0, propertyConfigs.Count)];
			PropertyListingData item = PropertyListingData.CreateFromConfig(propertyConfigSO, _listedProperties);
			if (item.IsValid)
			{
				bool num = DayNightManager.Instance != null && DayNightManager.Instance.CurrentGameDay == 1;
				bool flag = TutorialManager.Instance != null && TutorialManager.Instance.IsTutorialRunning;
				if (num && flag && item.basePrice > 950)
				{
					int num2 = UnityEngine.Random.Range(propertyConfigSO.minPrice, 951);
					item.basePrice = Mathf.RoundToInt((float)num2 / (float)propertyConfigSO.priceRoundingStep) * propertyConfigSO.priceRoundingStep;
				}
				_listedProperties.Add(item);
				UnityEngine.Debug.Log($"[ComputerPropertyManager] Emlak listelendi: {item.LocalizedName} - ${item.basePrice:N0}");
			}
		}
		UnityEngine.Debug.Log($"[ComputerPropertyManager] Toplam {_listedProperties.Count} emlak listelendi.");
	}

	[Server]
	private void ServerGenerateNewListing()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void ComputerPropertyManager::ServerGenerateNewListing()' called when server was not active");
			return;
		}
		if (propertyConfigs.Count == 0)
		{
			UnityEngine.Debug.LogWarning("[ComputerPropertyManager] Config listesi boş!");
			return;
		}
		if (_listedProperties.Count >= EffectiveMaxListedProperties)
		{
			UnityEngine.Debug.LogWarning($"[ComputerPropertyManager] Max listing sayısına ulaşıldı! ({EffectiveMaxListedProperties})");
			return;
		}
		PropertyConfigSO propertyConfigSO = propertyConfigs[UnityEngine.Random.Range(0, propertyConfigs.Count)];
		ServerGenerateListingFromConfig(propertyConfigSO.ConfigId);
	}

	[Server]
	private void ServerGenerateListingFromConfig(string configId)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void ComputerPropertyManager::ServerGenerateListingFromConfig(System.String)' called when server was not active");
			return;
		}
		PropertyConfigSO config = GetConfig(configId);
		if (config == null)
		{
			UnityEngine.Debug.LogWarning("[ComputerPropertyManager] Config bulunamadı: " + configId);
			return;
		}
		if (_listedProperties.Count >= EffectiveMaxListedProperties)
		{
			UnityEngine.Debug.LogWarning($"[ComputerPropertyManager] Max listing sayısına ulaşıldı! ({EffectiveMaxListedProperties})");
			return;
		}
		PropertyListingData propertyListingData = PropertyListingData.CreateFromConfig(config, _listedProperties);
		if (propertyListingData.IsValid)
		{
			_listedProperties.Add(propertyListingData);
			UnityEngine.Debug.Log($"[ComputerPropertyManager] Yeni emlak listelendi: {propertyListingData.LocalizedName} - ${propertyListingData.basePrice:N0}");
			if (NetworkServer.active && NetworkClient.isConnected)
			{
				onPropertyListed?.Invoke(propertyListingData);
			}
			RpcOnPropertyListed(propertyListingData);
		}
	}

	[Server]
	private void ServerClearAllListings()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void ComputerPropertyManager::ServerClearAllListings()' called when server was not active");
			return;
		}
		_listedProperties.Clear();
		UnityEngine.Debug.Log("[ComputerPropertyManager] Tüm listeler temizlendi.");
	}

	[Server]
	private void ServerRemoveListing(string listingId)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void ComputerPropertyManager::ServerRemoveListing(System.String)' called when server was not active");
			return;
		}
		for (int i = 0; i < _listedProperties.Count; i++)
		{
			if (_listedProperties[i].listingId == listingId)
			{
				PropertyListingData propertyListingData = _listedProperties[i];
				_listedProperties.RemoveAt(i);
				if (NetworkServer.active && NetworkClient.isConnected)
				{
					onPropertyDelisted?.Invoke(propertyListingData);
				}
				RpcOnPropertyDelisted(propertyListingData);
				break;
			}
		}
	}

	[Server]
	private void ServerStartNegotiation(string listingId, uint playerNetId)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void ComputerPropertyManager::ServerStartNegotiation(System.String,System.UInt32)' called when server was not active");
			return;
		}
		if (HasActiveProperty)
		{
			UnityEngine.Debug.LogWarning("[ComputerPropertyManager] Aktif emlak var, pazarlık başlatılamaz!");
			return;
		}
		if (HasActiveNegotiation)
		{
			UnityEngine.Debug.LogWarning("[ComputerPropertyManager] Zaten aktif pazarlık var!");
			return;
		}
		PropertyListingData? propertyListingData = null;
		foreach (PropertyListingData listedProperty in _listedProperties)
		{
			if (listedProperty.listingId == listingId)
			{
				propertyListingData = listedProperty;
				break;
			}
		}
		if (!propertyListingData.HasValue)
		{
			UnityEngine.Debug.LogWarning("[ComputerPropertyManager] Listing bulunamadı: " + listingId);
			return;
		}
		Network_currentNegotiation = PropertyNegotiationData.Create(propertyListingData.Value, playerNetId, priceVarianceMin, priceVarianceMax);
		Network_currentOfferCount = 0;
		UnityEngine.Debug.Log($"[ComputerPropertyManager] Pazarlık başladı: {propertyListingData.Value.LocalizedName} - Baz: ${propertyListingData.Value.basePrice:N0}, Red Sınırı: ${_currentNegotiation.rejectThreshold:N0}, NPC Hedef: ${_currentNegotiation.npcCurrentTarget:N0}");
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
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void ComputerPropertyManager::ServerProcessOffer(System.Int32)' called when server was not active");
			return;
		}
		if (!HasActiveNegotiation)
		{
			UnityEngine.Debug.LogWarning("[ComputerPropertyManager] Aktif pazarlık yok!");
			return;
		}
		Network_currentOfferCount = _currentOfferCount + 1;
		bool num = TutorialManager.Instance != null && TutorialManager.Instance.IsTutorialRunning;
		PropertyNegotiationData currentNegotiation = _currentNegotiation;
		PropertyNegotiationData propertyNegotiationData;
		if (num && _currentOfferCount == 1)
		{
			propertyNegotiationData = currentNegotiation;
			propertyNegotiationData.offerCount = _currentOfferCount;
			propertyNegotiationData.lastOfferAmount = offerAmount;
			propertyNegotiationData.bestOfferSoFar = offerAmount;
			propertyNegotiationData.state = NegotiationState.Accepted;
			propertyNegotiationData.sellerMessage = PropertyNegotiationData.GetAcceptMessagePublic(offerAmount);
			UnityEngine.Debug.Log($"[ComputerPropertyManager] Tutorial modu - ilk teklif otomatik kabul: ${offerAmount:N0}");
		}
		else
		{
			propertyNegotiationData = currentNegotiation.ProcessOffer(offerAmount, _currentOfferCount);
		}
		Network_currentNegotiation = propertyNegotiationData;
		UnityEngine.Debug.Log($"[ComputerPropertyManager] Teklif işlendi: ${offerAmount:N0} - Durum: {propertyNegotiationData.state} - Mesaj: {propertyNegotiationData.sellerMessage}");
		if (NetworkServer.active && NetworkClient.isConnected)
		{
			onNegotiationUpdated?.Invoke(propertyNegotiationData);
		}
		RpcOnNegotiationUpdated(propertyNegotiationData);
		if (propertyNegotiationData.state == NegotiationState.Accepted)
		{
			ServerSchedulePurchaseConfirmation(propertyNegotiationData);
		}
	}

	[Server]
	private void ServerAcceptFinalOffer()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void ComputerPropertyManager::ServerAcceptFinalOffer()' called when server was not active");
			return;
		}
		if (!HasActiveNegotiation || _currentNegotiation.state != NegotiationState.FinalOffer)
		{
			UnityEngine.Debug.LogWarning("[ComputerPropertyManager] Final teklif aşamasında değil!");
			return;
		}
		PropertyNegotiationData currentNegotiation = _currentNegotiation;
		PropertyNegotiationData propertyNegotiationData = (Network_currentNegotiation = currentNegotiation.AcceptFinalOffer());
		UnityEngine.Debug.Log($"[ComputerPropertyManager] Final teklif kabul edildi: ${propertyNegotiationData.npcCurrentTarget:N0}");
		if (NetworkServer.active && NetworkClient.isConnected)
		{
			onNegotiationUpdated?.Invoke(propertyNegotiationData);
		}
		RpcOnNegotiationUpdated(propertyNegotiationData);
		ServerSchedulePurchaseConfirmation(propertyNegotiationData);
	}

	[Server]
	private void ServerCancelNegotiation()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void ComputerPropertyManager::ServerCancelNegotiation()' called when server was not active");
			return;
		}
		if (!HasActiveNegotiation)
		{
			UnityEngine.Debug.LogWarning("[ComputerPropertyManager] Aktif pazarlık yok!");
			return;
		}
		UnityEngine.Debug.Log("[ComputerPropertyManager] Pazarlık iptal edildi.");
		Network_currentNegotiation = default(PropertyNegotiationData);
	}

	[Server]
	private void ServerCompletePurchase(PropertyNegotiationData negotiationData)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void ComputerPropertyManager::ServerCompletePurchase(PropertyNegotiationData)' called when server was not active");
			return;
		}
		UnityEngine.Debug.Log($"[ComputerPropertyManager] ServerCompletePurchase başladı - State: {negotiationData.state}, ListingId: {negotiationData.listingId}");
		if (negotiationData.state != NegotiationState.Accepted)
		{
			UnityEngine.Debug.LogWarning("[ComputerPropertyManager] Geçerli bir satın alma durumu yok!");
			return;
		}
		PropertyListingData? propertyListingData = null;
		for (int i = 0; i < _listedProperties.Count; i++)
		{
			if (_listedProperties[i].listingId == negotiationData.listingId)
			{
				propertyListingData = _listedProperties[i];
				break;
			}
		}
		if (!propertyListingData.HasValue)
		{
			UnityEngine.Debug.LogWarning("[ComputerPropertyManager] Satın alınacak listing bulunamadı! ListingId: " + negotiationData.listingId);
			return;
		}
		int lastOfferAmount = negotiationData.lastOfferAmount;
		if (FactoryManager.Instance != null)
		{
			if (!FactoryManager.Instance.TryPurchase(lastOfferAmount, EconomyType.EconomyType_Property))
			{
				UnityEngine.Debug.LogWarning($"[ComputerPropertyManager] Yetersiz bakiye! Gerekli: ${lastOfferAmount:N0}");
				NotificationManager.Instance?.ShowNotification(LocalizationManager.GetTranslation("Notification_InsufficientBalance_CannotBuyProperty"), isComputer: true);
				Network_currentNegotiation = default(PropertyNegotiationData);
				return;
			}
			UnityEngine.Debug.Log($"[ComputerPropertyManager] Emlak satın alındı: ${lastOfferAmount:N0}");
		}
		Network_purchasedPrice = lastOfferAmount;
		Network_activeProperty = propertyListingData.Value;
		ServerRemoveListing(propertyListingData.Value.listingId);
		UnityEngine.Debug.Log($"[ComputerPropertyManager] Emlak satın alındı: {propertyListingData.Value.LocalizedName} - ${lastOfferAmount:N0}");
		PropertyNegotiationData propertyNegotiationData = negotiationData;
		Network_currentNegotiation = default(PropertyNegotiationData);
		if (!string.IsNullOrEmpty(propertyListingData.Value.linkedSceneName))
		{
			ServerScheduleSceneLoad(propertyListingData.Value.linkedSceneName);
		}
		if (NetworkServer.active && NetworkClient.isConnected)
		{
			onPropertyPurchased?.Invoke(propertyListingData.Value);
			onNegotiationEnded?.Invoke(propertyNegotiationData);
		}
		RpcOnPropertyPurchased(propertyListingData.Value);
		RpcOnNegotiationEnded(propertyNegotiationData);
	}

	[Server]
	public void ServerClearActiveProperty()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void ComputerPropertyManager::ServerClearActiveProperty()' called when server was not active");
			return;
		}
		if (!HasActiveProperty)
		{
			UnityEngine.Debug.LogWarning("[ComputerPropertyManager] Temizlenecek aktif emlak yok!");
			return;
		}
		PropertyListingData activeProperty = _activeProperty;
		Network_activeProperty = default(PropertyListingData);
		Network_purchasedPrice = 0;
		DestroyAllOreSpawnChildren();
		if (NetworkServer.active && NetworkClient.isConnected)
		{
			onActivePropertyCleared?.Invoke();
		}
		RpcOnActivePropertyCleared();
		UnityEngine.Debug.Log("[ComputerPropertyManager] Aktif emlak temizlendi: " + activeProperty.LocalizedName);
	}

	[Server]
	private void DestroyAllOreSpawnChildren()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void ComputerPropertyManager::DestroyAllOreSpawnChildren()' called when server was not active");
			return;
		}
		if (GameManager.Instance == null || GameManager.Instance.oreSpawnParent == null)
		{
			UnityEngine.Debug.LogWarning("[ComputerPropertyManager] GameManager veya oreSpawnParent bulunamadı!");
			return;
		}
		Transform oreSpawnParent = GameManager.Instance.oreSpawnParent;
		int num = 0;
		for (int num2 = oreSpawnParent.childCount - 1; num2 >= 0; num2--)
		{
			Transform child = oreSpawnParent.GetChild(num2);
			if (!(child == null))
			{
				if (child.GetComponent<NetworkIdentity>() != null)
				{
					NetworkServer.Destroy(child.gameObject);
					num++;
				}
				else
				{
					UnityEngine.Object.Destroy(child.gameObject);
					num++;
				}
			}
		}
		UnityEngine.Debug.Log($"[ComputerPropertyManager] oreSpawnParent altındaki {num} obje destroy edildi.");
	}

	[Server]
	private void UpdatePurchaseConfirmTimer()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void ComputerPropertyManager::UpdatePurchaseConfirmTimer()' called when server was not active");
		}
		else if (_waitingForPurchaseConfirm)
		{
			_purchaseConfirmTimer -= Time.deltaTime;
			if (_purchaseConfirmTimer <= 0f)
			{
				_waitingForPurchaseConfirm = false;
				ServerCompletePurchase(_pendingPurchaseNegotiation);
			}
		}
	}

	[Server]
	private void ServerSchedulePurchaseConfirmation(PropertyNegotiationData negotiation)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void ComputerPropertyManager::ServerSchedulePurchaseConfirmation(PropertyNegotiationData)' called when server was not active");
			return;
		}
		_pendingPurchaseNegotiation = negotiation;
		_waitingForPurchaseConfirm = true;
		_purchaseConfirmTimer = UnityEngine.Random.Range(purchaseConfirmDelayMin, purchaseConfirmDelayMax);
		UnityEngine.Debug.Log($"[ComputerPropertyManager] Satın alma onayı zamanlandı - {_purchaseConfirmTimer:F2}s");
	}

	[Server]
	private void ServerScheduleSceneLoad(string sceneName)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void ComputerPropertyManager::ServerScheduleSceneLoad(System.String)' called when server was not active");
		}
		else if (!string.IsNullOrEmpty(sceneName))
		{
			_pendingSceneToLoad = sceneName;
			_hasPendingSceneLoad = true;
			StartCoroutine(ServerLoadSceneAfterDelay());
		}
	}

	[IteratorStateMachine(typeof(_003CServerLoadSceneAfterDelay_003Ed__102))]
	[Server]
	private IEnumerator ServerLoadSceneAfterDelay()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Collections.IEnumerator ComputerPropertyManager::ServerLoadSceneAfterDelay()' called when server was not active");
			return null;
		}
		return new _003CServerLoadSceneAfterDelay_003Ed__102(0)
		{
			_003C_003E4__this = this
		};
	}

	[Server]
	public void BroadcastMiningData()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void ComputerPropertyManager::BroadcastMiningData()' called when server was not active");
		}
		else if (!(T_ItemAreaSpawner.instance == null))
		{
			Dictionary<T_ItemAreaSpawner.MiningLayer, Dictionary<string, (int, int)>> data = (_cachedMiningDataByLayer = T_ItemAreaSpawner.instance.GetAllNodeCountsByLayer());
			onMiningDataUpdated?.Invoke();
			string miningDataJson = SerializeMiningDataToJson(data);
			RpcOnMiningDataUpdated(miningDataJson);
			UnityEngine.Debug.Log("[ComputerPropertyManager] Mining data broadcast edildi.");
		}
	}

	[Server]
	public void CancelPendingOperations()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void ComputerPropertyManager::CancelPendingOperations()' called when server was not active");
			return;
		}
		_waitingForPurchaseConfirm = false;
		_hasPendingSceneLoad = false;
		_pendingSceneToLoad = null;
		_pendingPurchaseNegotiation = default(PropertyNegotiationData);
		StopAllCoroutines();
		UnityEngine.Debug.Log("[ComputerPropertyManager] Bekleyen işlemler iptal edildi.");
	}

	[ClientRpc]
	private void RpcOnPropertyListed(PropertyListingData listing)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_PropertyListingData(writer, listing);
		SendRPCInternal("System.Void ComputerPropertyManager::RpcOnPropertyListed(PropertyListingData)", 1726587511, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcOnPropertyDelisted(PropertyListingData listing)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_PropertyListingData(writer, listing);
		SendRPCInternal("System.Void ComputerPropertyManager::RpcOnPropertyDelisted(PropertyListingData)", 718281130, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcOnPropertyPurchased(PropertyListingData listing)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_PropertyListingData(writer, listing);
		SendRPCInternal("System.Void ComputerPropertyManager::RpcOnPropertyPurchased(PropertyListingData)", 1098436127, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcOnNegotiationStarted(PropertyNegotiationData negotiation)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_PropertyNegotiationData(writer, negotiation);
		SendRPCInternal("System.Void ComputerPropertyManager::RpcOnNegotiationStarted(PropertyNegotiationData)", -2134792010, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcOnNegotiationUpdated(PropertyNegotiationData negotiation)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_PropertyNegotiationData(writer, negotiation);
		SendRPCInternal("System.Void ComputerPropertyManager::RpcOnNegotiationUpdated(PropertyNegotiationData)", 1441737348, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcOnNegotiationEnded(PropertyNegotiationData negotiation)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_PropertyNegotiationData(writer, negotiation);
		SendRPCInternal("System.Void ComputerPropertyManager::RpcOnNegotiationEnded(PropertyNegotiationData)", 2108775965, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcOnActivePropertyCleared()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void ComputerPropertyManager::RpcOnActivePropertyCleared()", 1787435499, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcOnMiningDataUpdated(string miningDataJson)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(miningDataJson);
		SendRPCInternal("System.Void ComputerPropertyManager::RpcOnMiningDataUpdated(System.String)", 1286829001, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void OnNodePieceBroken(string itemId)
	{
		if (HasActiveProperty && T_ItemAreaSpawner.instance != null)
		{
			Dictionary<T_ItemAreaSpawner.MiningLayer, Dictionary<string, (int, int)>> data = (_cachedMiningDataByLayer = T_ItemAreaSpawner.instance.GetAllNodeCountsByLayer());
			onMiningDataUpdated?.Invoke();
			string miningDataJson = SerializeMiningDataToJson(data);
			RpcOnMiningDataUpdated(miningDataJson);
		}
	}

	private string SerializeMiningDataToJson(Dictionary<T_ItemAreaSpawner.MiningLayer, Dictionary<string, (int initial, int remaining)>> data)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("{");
		bool flag = true;
		foreach (KeyValuePair<T_ItemAreaSpawner.MiningLayer, Dictionary<string, (int, int)>> datum in data)
		{
			if (!flag)
			{
				stringBuilder.Append(",");
			}
			flag = false;
			stringBuilder.Append($"\"{datum.Key}\":{{");
			bool flag2 = true;
			foreach (KeyValuePair<string, (int, int)> item in datum.Value)
			{
				if (!flag2)
				{
					stringBuilder.Append(",");
				}
				flag2 = false;
				stringBuilder.Append($"\"{item.Key}\":[{item.Value.Item1},{item.Value.Item2}]");
			}
			stringBuilder.Append("}");
		}
		stringBuilder.Append("}");
		return stringBuilder.ToString();
	}

	private Dictionary<T_ItemAreaSpawner.MiningLayer, Dictionary<string, (int initial, int remaining)>> ParseMiningDataJson(string json)
	{
		Dictionary<T_ItemAreaSpawner.MiningLayer, Dictionary<string, (int, int)>> dictionary = new Dictionary<T_ItemAreaSpawner.MiningLayer, Dictionary<string, (int, int)>>();
		foreach (T_ItemAreaSpawner.MiningLayer value in Enum.GetValues(typeof(T_ItemAreaSpawner.MiningLayer)))
		{
			dictionary[value] = new Dictionary<string, (int, int)>();
		}
		if (string.IsNullOrEmpty(json) || json == "{}")
		{
			return dictionary;
		}
		try
		{
			foreach (T_ItemAreaSpawner.MiningLayer value2 in Enum.GetValues(typeof(T_ItemAreaSpawner.MiningLayer)))
			{
				string text = value2.ToString();
				string text2 = "\"" + text + "\":{";
				int num = json.IndexOf(text2);
				if (num == -1)
				{
					continue;
				}
				num += text2.Length;
				int num2 = 1;
				int i;
				for (i = num; i < json.Length; i++)
				{
					if (num2 <= 0)
					{
						break;
					}
					if (json[i] == '{')
					{
						num2++;
					}
					else if (json[i] == '}')
					{
						num2--;
					}
				}
				if (num2 != 0)
				{
					continue;
				}
				string text3 = json.Substring(num, i - num - 1);
				if (string.IsNullOrEmpty(text3))
				{
					continue;
				}
				string[] array = text3.Split(new string[1] { "]," }, StringSplitOptions.RemoveEmptyEntries);
				for (int j = 0; j < array.Length; j++)
				{
					string[] array2 = array[j].TrimEnd(']').Split(new string[1] { "\":[" }, StringSplitOptions.RemoveEmptyEntries);
					if (array2.Length == 2)
					{
						string key3 = array2[0].Trim('"', ',');
						string[] array3 = array2[1].Split(',');
						if (array3.Length == 2 && int.TryParse(array3[0], out var result) && int.TryParse(array3[1], out var result2))
						{
							dictionary[value2][key3] = (result, result2);
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			UnityEngine.Debug.LogError("[ComputerPropertyManager] Mining data parse hatası: " + ex.Message);
		}
		return dictionary;
	}

	public Dictionary<string, (int initial, int remaining)> GetMiningDataForLayer(T_ItemAreaSpawner.MiningLayer layer)
	{
		if (base.isServer && T_ItemAreaSpawner.instance != null)
		{
			return T_ItemAreaSpawner.instance.GetNodeCountsForLayer(layer);
		}
		if (_cachedMiningDataByLayer.TryGetValue(layer, out Dictionary<string, (int, int)> value))
		{
			return value;
		}
		return new Dictionary<string, (int, int)>();
	}

	public Dictionary<T_ItemAreaSpawner.MiningLayer, Dictionary<string, (int initial, int remaining)>> GetAllMiningDataByLayer()
	{
		if (base.isServer && T_ItemAreaSpawner.instance != null)
		{
			return T_ItemAreaSpawner.instance.GetAllNodeCountsByLayer();
		}
		return _cachedMiningDataByLayer;
	}

	private void OnActivePropertyChanged(PropertyListingData oldValue, PropertyListingData newValue)
	{
		UnityEngine.Debug.Log("[ComputerPropertyManager] Aktif emlak değişti: " + (newValue.IsValid ? newValue.LocalizedName : "Yok"));
	}

	private void OnCurrentNegotiationChanged(PropertyNegotiationData oldValue, PropertyNegotiationData newValue)
	{
		UnityEngine.Debug.Log($"[ComputerPropertyManager] Pazarlık durumu değişti: {newValue.state}");
	}

	private void OnListedPropertiesChanged(SyncList<PropertyListingData>.Operation op, int index, PropertyListingData oldItem, PropertyListingData newItem)
	{
		UnityEngine.Debug.Log($"[ComputerPropertyManager] Liste değişti: {op} - Toplam: {_listedProperties.Count}");
	}

	public List<T_ItemSO> GetActivePropertyItems()
	{
		List<T_ItemSO> result = new List<T_ItemSO>();
		if (!HasActiveProperty)
		{
			return result;
		}
		PropertyConfigSO configForListing = GetConfigForListing(_activeProperty);
		T_ItemSpawnProfile spawnProfile = _activeProperty.GetSpawnProfile(configForListing);
		if (spawnProfile == null)
		{
			return result;
		}
		AddItemsFromLayer(spawnProfile.surface, result);
		AddItemsFromLayer(spawnProfile.mid, result);
		AddItemsFromLayer(spawnProfile.deep, result);
		return result;
	}

	private void AddItemsFromLayer(T_ItemSpawnProfile.LayerData layerData, List<T_ItemSO> result)
	{
		if (layerData?.items == null)
		{
			return;
		}
		foreach (T_ItemSpawnProfile.WeightedSO item in layerData.items)
		{
			if (item?.so != null)
			{
				result.Add(item.so);
			}
		}
	}

	public List<PropertyListingData> GetListingsSortedByLevel(bool ascending = true)
	{
		List<PropertyListingData> list = _listedProperties.ToList();
		if (ascending)
		{
			list.Sort((PropertyListingData a, PropertyListingData b) => a.propertyLevel.CompareTo(b.propertyLevel));
		}
		else
		{
			list.Sort((PropertyListingData a, PropertyListingData b) => b.propertyLevel.CompareTo(a.propertyLevel));
		}
		return list;
	}

	public List<PropertyListingData> GetListingsSortedByPrice(bool ascending = true)
	{
		List<PropertyListingData> list = _listedProperties.ToList();
		if (ascending)
		{
			list.Sort((PropertyListingData a, PropertyListingData b) => a.basePrice.CompareTo(b.basePrice));
		}
		else
		{
			list.Sort((PropertyListingData a, PropertyListingData b) => b.basePrice.CompareTo(a.basePrice));
		}
		return list;
	}

	public List<PropertyListingData> GetListingsByType(PropertyType type)
	{
		return _listedProperties.Where((PropertyListingData l) => l.propertyType == type).ToList();
	}

	[ContextMenu("Test: Generate New Listing")]
	private void TestGenerateNewListing()
	{
		RequestGenerateNewListing();
	}

	[ContextMenu("Test: Clear All Listings")]
	private void TestClearAllListings()
	{
		RequestClearAllListings();
	}

	[ContextMenu("Test: Start Negotiation (First Listing)")]
	private void TestStartNegotiation()
	{
		if (_listedProperties.Count > 0)
		{
			RequestStartNegotiation(_listedProperties[0].listingId);
		}
	}

	[ContextMenu("Test: Make Offer (Base Price - 500)")]
	private void TestMakeOffer()
	{
		if (HasActiveNegotiation)
		{
			RequestMakeOffer(_currentNegotiation.basePrice - 500);
		}
	}

	[ContextMenu("Debug: Show All Listings")]
	private void DebugShowAllListings()
	{
		UnityEngine.Debug.Log($"=== Listelenen Emlaklar ({_listedProperties.Count}) ===");
		foreach (PropertyListingData listedProperty in _listedProperties)
		{
			UnityEngine.Debug.Log($"  - {listedProperty.LocalizedName} | ${listedProperty.basePrice:N0} | Level {listedProperty.propertyLevel} | {listedProperty.propertyType}");
		}
	}

	[ContextMenu("Debug: Show Negotiation State")]
	private void DebugShowNegotiationState()
	{
		if (HasActiveNegotiation)
		{
			UnityEngine.Debug.Log("=== Aktif Pazarlık ===");
			UnityEngine.Debug.Log("  Listing: " + _currentNegotiation.listingId);
			UnityEngine.Debug.Log($"  Baz Fiyat: ${_currentNegotiation.basePrice:N0}");
			UnityEngine.Debug.Log($"  Red Sınırı: ${_currentNegotiation.rejectThreshold:N0}");
			UnityEngine.Debug.Log($"  NPC Hedef: ${_currentNegotiation.npcCurrentTarget:N0}");
			UnityEngine.Debug.Log($"  Teklif Sayısı: {_currentNegotiation.offerCount}");
			UnityEngine.Debug.Log($"  Son Teklif: ${_currentNegotiation.lastOfferAmount:N0}");
			UnityEngine.Debug.Log($"  Durum: {_currentNegotiation.state}");
			UnityEngine.Debug.Log("  Mesaj: " + _currentNegotiation.sellerMessage);
		}
		else
		{
			UnityEngine.Debug.Log("Aktif pazarlık yok.");
		}
	}

	public object GetSaveData(bool includeNonSavable)
	{
		if (!base.isServer)
		{
			return null;
		}
		PropertyManagerSaveData result = new PropertyManagerSaveData
		{
			activeProperty = _activeProperty,
			purchasedPrice = _purchasedPrice,
			listedProperties = new List<PropertyListingData>(_listedProperties),
			currentNegotiation = _currentNegotiation,
			currentOfferCount = _currentOfferCount
		};
		UnityEngine.Debug.Log(string.Format("[ComputerPropertyManager] Save - ActiveProperty: {0}, ListingId: {1}, ListedProperties: {2}", _activeProperty.IsValid ? _activeProperty.LocalizedName : "Yok", _activeProperty.listingId, _listedProperties.Count));
		return result;
	}

	public Task OnLoad(object value)
	{
		if (!(value is PropertyManagerSaveData propertyManagerSaveData))
		{
			return Task.CompletedTask;
		}
		if (!base.isServer)
		{
			UnityEngine.Debug.Log("[ComputerPropertyManager] Client - load atlanıyor, SyncVar ile senkronize olacak");
			return Task.CompletedTask;
		}
		_loadedFromSave = true;
		_listedProperties.Clear();
		foreach (PropertyListingData listedProperty in propertyManagerSaveData.listedProperties)
		{
			_listedProperties.Add(listedProperty);
		}
		Network_activeProperty = propertyManagerSaveData.activeProperty;
		Network_purchasedPrice = propertyManagerSaveData.purchasedPrice;
		Network_currentNegotiation = propertyManagerSaveData.currentNegotiation;
		Network_currentOfferCount = propertyManagerSaveData.currentOfferCount;
		UnityEngine.Debug.Log(string.Format("[ComputerPropertyManager] Load - ActiveProperty: {0}, ListingId: {1}, ListedProperties: {2}", _activeProperty.IsValid ? _activeProperty.LocalizedName : "Yok", _activeProperty.listingId, _listedProperties.Count));
		if (_activeProperty.IsValid && !string.IsNullOrEmpty(_activeProperty.linkedSceneName))
		{
			SaveLoadGameManager.RegisterPendingLoadOperation("Loading_Property");
			UnityEngine.Debug.Log("[ComputerPropertyManager] Load - Aktif emlak sahnesi yükleniyor: " + _activeProperty.linkedSceneName);
			ServerScheduleSceneLoad(_activeProperty.linkedSceneName);
		}
		return Task.CompletedTask;
	}

	private void OnEnable()
	{
		SaveLoadManager.Subscribe(this, 45);
	}

	private void OnDisable()
	{
		SaveLoadManager.Unsubscribe(this);
	}

	public ComputerPropertyManager()
	{
		InitSyncObject(_listedProperties);
		_Mirror_SyncVarHookDelegate__activeProperty = OnActivePropertyChanged;
		_Mirror_SyncVarHookDelegate__currentNegotiation = OnCurrentNegotiationChanged;
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdRequestGenerateNewListing__NetworkConnectionToClient(NetworkConnectionToClient sender)
	{
		if (sender != null && sender != NetworkServer.localConnection)
		{
			UnityEngine.Debug.LogWarning("[ComputerPropertyManager] Command rejected: Only host!");
		}
		else
		{
			ServerGenerateNewListing();
		}
	}

	protected static void InvokeUserCode_CmdRequestGenerateNewListing__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdRequestGenerateNewListing called on client.");
		}
		else
		{
			((ComputerPropertyManager)obj).UserCode_CmdRequestGenerateNewListing__NetworkConnectionToClient(senderConnection);
		}
	}

	protected void UserCode_CmdRequestGenerateListingFromConfig__String__NetworkConnectionToClient(string configId, NetworkConnectionToClient sender)
	{
		if (sender != null && sender != NetworkServer.localConnection)
		{
			UnityEngine.Debug.LogWarning("[ComputerPropertyManager] Command rejected: Only host!");
		}
		else
		{
			ServerGenerateListingFromConfig(configId);
		}
	}

	protected static void InvokeUserCode_CmdRequestGenerateListingFromConfig__String__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdRequestGenerateListingFromConfig called on client.");
		}
		else
		{
			((ComputerPropertyManager)obj).UserCode_CmdRequestGenerateListingFromConfig__String__NetworkConnectionToClient(reader.ReadString(), senderConnection);
		}
	}

	protected void UserCode_CmdRequestClearAllListings__NetworkConnectionToClient(NetworkConnectionToClient sender)
	{
		if (sender != null && sender != NetworkServer.localConnection)
		{
			UnityEngine.Debug.LogWarning("[ComputerPropertyManager] Command rejected: Only host!");
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
			UnityEngine.Debug.LogError("Command CmdRequestClearAllListings called on client.");
		}
		else
		{
			((ComputerPropertyManager)obj).UserCode_CmdRequestClearAllListings__NetworkConnectionToClient(senderConnection);
		}
	}

	protected void UserCode_CmdRequestClearActiveProperty__NetworkConnectionToClient(NetworkConnectionToClient sender)
	{
		if (sender != null && sender != NetworkServer.localConnection)
		{
			UnityEngine.Debug.LogWarning("[ComputerPropertyManager] Command rejected: Only host!");
		}
		else
		{
			ServerClearActiveProperty();
		}
	}

	protected static void InvokeUserCode_CmdRequestClearActiveProperty__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdRequestClearActiveProperty called on client.");
		}
		else
		{
			((ComputerPropertyManager)obj).UserCode_CmdRequestClearActiveProperty__NetworkConnectionToClient(senderConnection);
		}
	}

	protected void UserCode_CmdRequestStartNegotiation__String__UInt32__NetworkConnectionToClient(string listingId, uint playerNetId, NetworkConnectionToClient sender)
	{
		if (sender != null && sender != NetworkServer.localConnection)
		{
			UnityEngine.Debug.LogWarning("[ComputerPropertyManager] Command rejected: Only host!");
		}
		else
		{
			ServerStartNegotiation(listingId, playerNetId);
		}
	}

	protected static void InvokeUserCode_CmdRequestStartNegotiation__String__UInt32__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdRequestStartNegotiation called on client.");
		}
		else
		{
			((ComputerPropertyManager)obj).UserCode_CmdRequestStartNegotiation__String__UInt32__NetworkConnectionToClient(reader.ReadString(), reader.ReadVarUInt(), senderConnection);
		}
	}

	protected void UserCode_CmdRequestMakeOffer__Int32__NetworkConnectionToClient(int offerAmount, NetworkConnectionToClient sender)
	{
		if (sender != null && sender != NetworkServer.localConnection)
		{
			UnityEngine.Debug.LogWarning("[ComputerPropertyManager] Command rejected: Only host!");
		}
		else
		{
			ServerProcessOffer(offerAmount);
		}
	}

	protected static void InvokeUserCode_CmdRequestMakeOffer__Int32__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdRequestMakeOffer called on client.");
		}
		else
		{
			((ComputerPropertyManager)obj).UserCode_CmdRequestMakeOffer__Int32__NetworkConnectionToClient(reader.ReadVarInt(), senderConnection);
		}
	}

	protected void UserCode_CmdRequestAcceptFinalOffer__NetworkConnectionToClient(NetworkConnectionToClient sender)
	{
		if (sender != null && sender != NetworkServer.localConnection)
		{
			UnityEngine.Debug.LogWarning("[ComputerPropertyManager] Command rejected: Only host!");
		}
		else
		{
			ServerAcceptFinalOffer();
		}
	}

	protected static void InvokeUserCode_CmdRequestAcceptFinalOffer__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdRequestAcceptFinalOffer called on client.");
		}
		else
		{
			((ComputerPropertyManager)obj).UserCode_CmdRequestAcceptFinalOffer__NetworkConnectionToClient(senderConnection);
		}
	}

	protected void UserCode_CmdRequestCancelNegotiation__NetworkConnectionToClient(NetworkConnectionToClient sender)
	{
		if (sender != null && sender != NetworkServer.localConnection)
		{
			UnityEngine.Debug.LogWarning("[ComputerPropertyManager] Command rejected: Only host!");
		}
		else
		{
			ServerCancelNegotiation();
		}
	}

	protected static void InvokeUserCode_CmdRequestCancelNegotiation__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdRequestCancelNegotiation called on client.");
		}
		else
		{
			((ComputerPropertyManager)obj).UserCode_CmdRequestCancelNegotiation__NetworkConnectionToClient(senderConnection);
		}
	}

	protected void UserCode_CmdRequestMiningData__NetworkConnectionToClient(NetworkConnectionToClient sender)
	{
		BroadcastMiningData();
	}

	protected static void InvokeUserCode_CmdRequestMiningData__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdRequestMiningData called on client.");
		}
		else
		{
			((ComputerPropertyManager)obj).UserCode_CmdRequestMiningData__NetworkConnectionToClient(senderConnection);
		}
	}

	protected void UserCode_RpcOnPropertyListed__PropertyListingData(PropertyListingData listing)
	{
		if (!base.isServer)
		{
			onPropertyListed?.Invoke(listing);
		}
	}

	protected static void InvokeUserCode_RpcOnPropertyListed__PropertyListingData(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("RPC RpcOnPropertyListed called on server.");
		}
		else
		{
			((ComputerPropertyManager)obj).UserCode_RpcOnPropertyListed__PropertyListingData(GeneratedNetworkCode._Read_PropertyListingData(reader));
		}
	}

	protected void UserCode_RpcOnPropertyDelisted__PropertyListingData(PropertyListingData listing)
	{
		if (!base.isServer)
		{
			onPropertyDelisted?.Invoke(listing);
		}
	}

	protected static void InvokeUserCode_RpcOnPropertyDelisted__PropertyListingData(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("RPC RpcOnPropertyDelisted called on server.");
		}
		else
		{
			((ComputerPropertyManager)obj).UserCode_RpcOnPropertyDelisted__PropertyListingData(GeneratedNetworkCode._Read_PropertyListingData(reader));
		}
	}

	protected void UserCode_RpcOnPropertyPurchased__PropertyListingData(PropertyListingData listing)
	{
		if (!base.isServer)
		{
			onPropertyPurchased?.Invoke(listing);
		}
	}

	protected static void InvokeUserCode_RpcOnPropertyPurchased__PropertyListingData(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("RPC RpcOnPropertyPurchased called on server.");
		}
		else
		{
			((ComputerPropertyManager)obj).UserCode_RpcOnPropertyPurchased__PropertyListingData(GeneratedNetworkCode._Read_PropertyListingData(reader));
		}
	}

	protected void UserCode_RpcOnNegotiationStarted__PropertyNegotiationData(PropertyNegotiationData negotiation)
	{
		if (!base.isServer)
		{
			onNegotiationStarted?.Invoke(negotiation);
		}
	}

	protected static void InvokeUserCode_RpcOnNegotiationStarted__PropertyNegotiationData(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("RPC RpcOnNegotiationStarted called on server.");
		}
		else
		{
			((ComputerPropertyManager)obj).UserCode_RpcOnNegotiationStarted__PropertyNegotiationData(GeneratedNetworkCode._Read_PropertyNegotiationData(reader));
		}
	}

	protected void UserCode_RpcOnNegotiationUpdated__PropertyNegotiationData(PropertyNegotiationData negotiation)
	{
		if (!base.isServer)
		{
			onNegotiationUpdated?.Invoke(negotiation);
		}
	}

	protected static void InvokeUserCode_RpcOnNegotiationUpdated__PropertyNegotiationData(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("RPC RpcOnNegotiationUpdated called on server.");
		}
		else
		{
			((ComputerPropertyManager)obj).UserCode_RpcOnNegotiationUpdated__PropertyNegotiationData(GeneratedNetworkCode._Read_PropertyNegotiationData(reader));
		}
	}

	protected void UserCode_RpcOnNegotiationEnded__PropertyNegotiationData(PropertyNegotiationData negotiation)
	{
		if (!base.isServer)
		{
			onNegotiationEnded?.Invoke(negotiation);
		}
	}

	protected static void InvokeUserCode_RpcOnNegotiationEnded__PropertyNegotiationData(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("RPC RpcOnNegotiationEnded called on server.");
		}
		else
		{
			((ComputerPropertyManager)obj).UserCode_RpcOnNegotiationEnded__PropertyNegotiationData(GeneratedNetworkCode._Read_PropertyNegotiationData(reader));
		}
	}

	protected void UserCode_RpcOnActivePropertyCleared()
	{
		if (!base.isServer)
		{
			onActivePropertyCleared?.Invoke();
		}
	}

	protected static void InvokeUserCode_RpcOnActivePropertyCleared(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("RPC RpcOnActivePropertyCleared called on server.");
		}
		else
		{
			((ComputerPropertyManager)obj).UserCode_RpcOnActivePropertyCleared();
		}
	}

	protected void UserCode_RpcOnMiningDataUpdated__String(string miningDataJson)
	{
		_cachedMiningDataByLayer = ParseMiningDataJson(miningDataJson);
		onMiningDataUpdated?.Invoke();
	}

	protected static void InvokeUserCode_RpcOnMiningDataUpdated__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("RPC RpcOnMiningDataUpdated called on server.");
		}
		else
		{
			((ComputerPropertyManager)obj).UserCode_RpcOnMiningDataUpdated__String(reader.ReadString());
		}
	}

	static ComputerPropertyManager()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(ComputerPropertyManager), "System.Void ComputerPropertyManager::CmdRequestGenerateNewListing(Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdRequestGenerateNewListing__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ComputerPropertyManager), "System.Void ComputerPropertyManager::CmdRequestGenerateListingFromConfig(System.String,Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdRequestGenerateListingFromConfig__String__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ComputerPropertyManager), "System.Void ComputerPropertyManager::CmdRequestClearAllListings(Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdRequestClearAllListings__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ComputerPropertyManager), "System.Void ComputerPropertyManager::CmdRequestClearActiveProperty(Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdRequestClearActiveProperty__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ComputerPropertyManager), "System.Void ComputerPropertyManager::CmdRequestStartNegotiation(System.String,System.UInt32,Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdRequestStartNegotiation__String__UInt32__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ComputerPropertyManager), "System.Void ComputerPropertyManager::CmdRequestMakeOffer(System.Int32,Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdRequestMakeOffer__Int32__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ComputerPropertyManager), "System.Void ComputerPropertyManager::CmdRequestAcceptFinalOffer(Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdRequestAcceptFinalOffer__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ComputerPropertyManager), "System.Void ComputerPropertyManager::CmdRequestCancelNegotiation(Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdRequestCancelNegotiation__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ComputerPropertyManager), "System.Void ComputerPropertyManager::CmdRequestMiningData(Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdRequestMiningData__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(ComputerPropertyManager), "System.Void ComputerPropertyManager::RpcOnPropertyListed(PropertyListingData)", InvokeUserCode_RpcOnPropertyListed__PropertyListingData);
		RemoteProcedureCalls.RegisterRpc(typeof(ComputerPropertyManager), "System.Void ComputerPropertyManager::RpcOnPropertyDelisted(PropertyListingData)", InvokeUserCode_RpcOnPropertyDelisted__PropertyListingData);
		RemoteProcedureCalls.RegisterRpc(typeof(ComputerPropertyManager), "System.Void ComputerPropertyManager::RpcOnPropertyPurchased(PropertyListingData)", InvokeUserCode_RpcOnPropertyPurchased__PropertyListingData);
		RemoteProcedureCalls.RegisterRpc(typeof(ComputerPropertyManager), "System.Void ComputerPropertyManager::RpcOnNegotiationStarted(PropertyNegotiationData)", InvokeUserCode_RpcOnNegotiationStarted__PropertyNegotiationData);
		RemoteProcedureCalls.RegisterRpc(typeof(ComputerPropertyManager), "System.Void ComputerPropertyManager::RpcOnNegotiationUpdated(PropertyNegotiationData)", InvokeUserCode_RpcOnNegotiationUpdated__PropertyNegotiationData);
		RemoteProcedureCalls.RegisterRpc(typeof(ComputerPropertyManager), "System.Void ComputerPropertyManager::RpcOnNegotiationEnded(PropertyNegotiationData)", InvokeUserCode_RpcOnNegotiationEnded__PropertyNegotiationData);
		RemoteProcedureCalls.RegisterRpc(typeof(ComputerPropertyManager), "System.Void ComputerPropertyManager::RpcOnActivePropertyCleared()", InvokeUserCode_RpcOnActivePropertyCleared);
		RemoteProcedureCalls.RegisterRpc(typeof(ComputerPropertyManager), "System.Void ComputerPropertyManager::RpcOnMiningDataUpdated(System.String)", InvokeUserCode_RpcOnMiningDataUpdated__String);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			GeneratedNetworkCode._Write_PropertyListingData(writer, _activeProperty);
			GeneratedNetworkCode._Write_PropertyNegotiationData(writer, _currentNegotiation);
			writer.WriteVarInt(_currentOfferCount);
			writer.WriteVarInt(_purchasedPrice);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			GeneratedNetworkCode._Write_PropertyListingData(writer, _activeProperty);
		}
		if ((syncVarDirtyBits & 2L) != 0L)
		{
			GeneratedNetworkCode._Write_PropertyNegotiationData(writer, _currentNegotiation);
		}
		if ((syncVarDirtyBits & 4L) != 0L)
		{
			writer.WriteVarInt(_currentOfferCount);
		}
		if ((syncVarDirtyBits & 8L) != 0L)
		{
			writer.WriteVarInt(_purchasedPrice);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _activeProperty, _Mirror_SyncVarHookDelegate__activeProperty, GeneratedNetworkCode._Read_PropertyListingData(reader));
			GeneratedSyncVarDeserialize(ref _currentNegotiation, _Mirror_SyncVarHookDelegate__currentNegotiation, GeneratedNetworkCode._Read_PropertyNegotiationData(reader));
			GeneratedSyncVarDeserialize(ref _currentOfferCount, null, reader.ReadVarInt());
			GeneratedSyncVarDeserialize(ref _purchasedPrice, null, reader.ReadVarInt());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _activeProperty, _Mirror_SyncVarHookDelegate__activeProperty, GeneratedNetworkCode._Read_PropertyListingData(reader));
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _currentNegotiation, _Mirror_SyncVarHookDelegate__currentNegotiation, GeneratedNetworkCode._Read_PropertyNegotiationData(reader));
		}
		if ((num & 4L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _currentOfferCount, null, reader.ReadVarInt());
		}
		if ((num & 8L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _purchasedPrice, null, reader.ReadVarInt());
		}
	}
}
