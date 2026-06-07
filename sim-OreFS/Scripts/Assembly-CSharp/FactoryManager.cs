using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Enviro;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Variables;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;
using UnityEngine.Events;

public class FactoryManager : NetworkBehaviour, IGameSave
{
	[Serializable]
	public class FactorySaveData
	{
		public int money;

		public int currentXP;

		public int level;
	}

	[Header("Money/XP/Level")]
	[SyncVar(hook = "OnMoneyChangedHook")]
	public int _money = 10000;

	[SyncVar(hook = "OnXPChangedHook")]
	public int _currentXP;

	[SyncVar(hook = "OnLevelChangedHook")]
	public int _level = 1;

	[Header("Company Identity")]
	[SyncVar(hook = "OnCompanyNameChangedHook")]
	public string _companyName = "";

	[SyncVar(hook = "OnCompanyLogoIndexChangedHook")]
	public int _companyLogoIndex;

	[SyncVar(hook = "OnBackgroundColorIndexChangedHook")]
	public int _backgroundColorIndex;

	[SyncVar(hook = "OnFrontColorIndexChangedHook")]
	public int _frontColorIndex = 1;

	[SerializeField]
	private GlobalNameVariables companyVariables;

	[SerializeField]
	private GlobalNameVariables metaVariables;

	private readonly WaitForSeconds _companyNameDelay = new WaitForSeconds(0.25f);

	[Header("Events")]
	public UnityEvent<int, int> onMoneyChanged;

	public UnityEvent<int, int> onXPChanged;

	public UnityEvent<int, int> onLevelChanged;

	public UnityEvent onLevelUp;

	public UnityEvent<int> onRealLevelUp;

	public UnityEvent<string, string> onCompanyNameChanged;

	public UnityEvent<int, int> onCompanyLogoIndexChanged;

	public UnityEvent<int, int> onBackgroundColorIndexChanged;

	public UnityEvent<int, int> onFrontColorIndexChanged;

	public Action<int, int> _Mirror_SyncVarHookDelegate__money;

	public Action<int, int> _Mirror_SyncVarHookDelegate__currentXP;

	public Action<int, int> _Mirror_SyncVarHookDelegate__level;

	public Action<string, string> _Mirror_SyncVarHookDelegate__companyName;

	public Action<int, int> _Mirror_SyncVarHookDelegate__companyLogoIndex;

	public Action<int, int> _Mirror_SyncVarHookDelegate__backgroundColorIndex;

	public Action<int, int> _Mirror_SyncVarHookDelegate__frontColorIndex;

	public static FactoryManager Instance { get; private set; }

	private LevelConfigSO levelConfig
	{
		get
		{
			if (!(ScriptableListManager.Instance != null))
			{
				return null;
			}
			return ScriptableListManager.Instance.LevelConfig;
		}
	}

	private FactoryIdentityConfigSO identityConfig
	{
		get
		{
			if (!(ScriptableListManager.Instance != null))
			{
				return null;
			}
			return ScriptableListManager.Instance.FactoryIdentityConfig;
		}
	}

	public int Money => _money;

	public int CurrentXP => _currentXP;

	public int Level => _level;

	public int RequiredXPForNextLevel
	{
		get
		{
			if (levelConfig == null || levelConfig.IsMaxLevel(_level))
			{
				return 0;
			}
			return levelConfig.GetRequiredXPForLevel(_level + 1);
		}
	}

	public int RemainingXPForNextLevel
	{
		get
		{
			int requiredXPForNextLevel = RequiredXPForNextLevel;
			if (requiredXPForNextLevel == 0)
			{
				return 0;
			}
			return Mathf.Max(0, requiredXPForNextLevel - _currentXP);
		}
	}

	public float XPProgress
	{
		get
		{
			int requiredXPForNextLevel = RequiredXPForNextLevel;
			if (requiredXPForNextLevel == 0)
			{
				return 1f;
			}
			return Mathf.Clamp01((float)_currentXP / (float)requiredXPForNextLevel);
		}
	}

	public bool IsMaxLevel
	{
		get
		{
			if (levelConfig != null)
			{
				return levelConfig.IsMaxLevel(_level);
			}
			return false;
		}
	}

	public string CompanyName => _companyName;

	public int CompanyLogoIndex => _companyLogoIndex;

	public Sprite CompanyLogo => identityConfig?.GetLogoByIndex(_companyLogoIndex);

	public bool HasCompanyIdentity => !string.IsNullOrEmpty(_companyName);

	public int BackgroundColorIndex => _backgroundColorIndex;

	public int FrontColorIndex => _frontColorIndex;

	public Color BackgroundColor => identityConfig?.GetColorByIndex(_backgroundColorIndex) ?? Color.white;

	public Color FrontColor => identityConfig?.GetColorByIndex(_frontColorIndex) ?? Color.white;

	public string SaveID => "factory-manager";

	public bool IsShared => false;

	public Type SaveType => typeof(FactorySaveData);

	public LoadMode LoadMode => LoadMode.Greedy;

	public int Network_money
	{
		get
		{
			return _money;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _money, 1uL, _Mirror_SyncVarHookDelegate__money);
		}
	}

	public int Network_currentXP
	{
		get
		{
			return _currentXP;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _currentXP, 2uL, _Mirror_SyncVarHookDelegate__currentXP);
		}
	}

	public int Network_level
	{
		get
		{
			return _level;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _level, 4uL, _Mirror_SyncVarHookDelegate__level);
		}
	}

	public string Network_companyName
	{
		get
		{
			return _companyName;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _companyName, 8uL, _Mirror_SyncVarHookDelegate__companyName);
		}
	}

	public int Network_companyLogoIndex
	{
		get
		{
			return _companyLogoIndex;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _companyLogoIndex, 16uL, _Mirror_SyncVarHookDelegate__companyLogoIndex);
		}
	}

	public int Network_backgroundColorIndex
	{
		get
		{
			return _backgroundColorIndex;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _backgroundColorIndex, 32uL, _Mirror_SyncVarHookDelegate__backgroundColorIndex);
		}
	}

	public int Network_frontColorIndex
	{
		get
		{
			return _frontColorIndex;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _frontColorIndex, 64uL, _Mirror_SyncVarHookDelegate__frontColorIndex);
		}
	}

	public event Action<int, EconomyType> OnMoneyTransaction;

	public event Action<int, EconomyType> OnXPTransaction;

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else
		{
			Instance = this;
		}
	}

	private void Start()
	{
		if (base.isServer)
		{
			LoadIdentityFromVariables(newGame: true);
		}
	}

	private void OnDestroy()
	{
		SaveLoadManager.Unsubscribe(this);
		if (Instance == this)
		{
			Instance = null;
		}
	}

	private void OnMoneyChangedHook(int oldValue, int newValue)
	{
		onMoneyChanged?.Invoke(oldValue, newValue);
	}

	private void OnXPChangedHook(int oldValue, int newValue)
	{
		onXPChanged?.Invoke(oldValue, newValue);
	}

	private void OnLevelChangedHook(int oldValue, int newValue)
	{
		onLevelChanged?.Invoke(oldValue, newValue);
		if (newValue > oldValue)
		{
			onLevelUp?.Invoke();
		}
	}

	[ClientRpc]
	private void RpcNotifyLevelUp(int newLevel)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(newLevel);
		SendRPCInternal("System.Void FactoryManager::RpcNotifyLevelUp(System.Int32)", 1814554274, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void OnCompanyNameChangedHook(string oldValue, string newValue)
	{
		onCompanyNameChanged?.Invoke(oldValue, newValue);
		UpdateGameCreatorCompanyName(newValue);
	}

	private void OnCompanyLogoIndexChangedHook(int oldValue, int newValue)
	{
		onCompanyLogoIndexChanged?.Invoke(oldValue, newValue);
		UpdateGameCreatorCompanyIcon(newValue);
	}

	private void OnBackgroundColorIndexChangedHook(int oldValue, int newValue)
	{
		onBackgroundColorIndexChanged?.Invoke(oldValue, newValue);
		UpdateGameCreatorBackgroundColor(newValue);
	}

	private void OnFrontColorIndexChangedHook(int oldValue, int newValue)
	{
		onFrontColorIndexChanged?.Invoke(oldValue, newValue);
		UpdateGameCreatorFrontColor(newValue);
	}

	private void UpdateGameCreatorCompanyName(string name)
	{
		if (companyVariables != null && !string.IsNullOrEmpty(name))
		{
			StartCoroutine(SetCompanyNameDelayed(name));
		}
	}

	private IEnumerator SetCompanyNameDelayed(string name)
	{
		yield return _companyNameDelay;
		companyVariables.Set("Company-Name", name);
	}

	private void UpdateGameCreatorCompanyIcon(int logoIndex)
	{
		if (companyVariables != null && identityConfig != null)
		{
			Sprite logoByIndex = identityConfig.GetLogoByIndex(logoIndex);
			Debug.Log(string.Format("[FactoryManager] UpdateCompanyIcon - logoIndex: {0}, logo: {1}, listCount: {2}", logoIndex, (logoByIndex != null) ? logoByIndex.name : "null", identityConfig.LogoCount));
			companyVariables.Set("Company-LogoIndex", logoIndex);
			if (logoByIndex != null)
			{
				companyVariables.Set("Company-Icon", logoByIndex);
			}
		}
	}

	private void UpdateGameCreatorBackgroundColor(int colorIndex)
	{
		if (!(companyVariables == null))
		{
			Color color = ((identityConfig != null) ? identityConfig.GetColorByIndex(colorIndex) : Color.white);
			companyVariables.Set("Company-Background-Color", color);
			companyVariables.Set("Company-Background-Color-Index", colorIndex);
		}
	}

	private void UpdateGameCreatorFrontColor(int colorIndex)
	{
		if (!(companyVariables == null))
		{
			Color color = ((identityConfig != null) ? identityConfig.GetColorByIndex(colorIndex) : Color.white);
			companyVariables.Set("Company-Front-Color", color);
			companyVariables.Set("Company-Front-Color-Index", colorIndex);
		}
	}

	private void UpdateMetaLevel(int level)
	{
		if (metaVariables != null)
		{
			metaVariables.Set("Meta-Level", (double)level);
		}
	}

	private void UpdateMetaDay(int day)
	{
		if (metaVariables != null)
		{
			metaVariables.Set("Meta-Day", (double)day);
		}
	}

	public void AddMoney(int amount, EconomyType economyType)
	{
		if (amount > 0)
		{
			if (base.isServer)
			{
				ServerAddMoney(amount, economyType);
			}
			else
			{
				CmdAddMoney(amount, economyType);
			}
		}
	}

	public bool ReduceMoney(int amount, EconomyType economyType)
	{
		if (amount <= 0)
		{
			return true;
		}
		if (_money < amount)
		{
			amount = _money;
		}
		if (base.isServer)
		{
			ServerReduceMoney(amount, economyType);
		}
		else
		{
			CmdReduceMoney(amount, economyType);
		}
		return true;
	}

	public void ForceReduceMoney(int amount, EconomyType economyType)
	{
		if (amount > 0)
		{
			if (base.isServer)
			{
				ServerForceReduceMoney(amount, economyType);
			}
			else
			{
				CmdForceReduceMoney(amount, economyType);
			}
		}
	}

	public bool TryPurchase(int cost, EconomyType economyType)
	{
		if (cost <= 0)
		{
			return true;
		}
		if (_money < cost)
		{
			return false;
		}
		if (base.isServer)
		{
			ServerReduceMoney(cost, economyType);
		}
		else
		{
			CmdReduceMoney(cost, economyType);
		}
		return true;
	}

	public void AddXP(int amount, EconomyType economyType)
	{
		if (amount > 0)
		{
			if (base.isServer)
			{
				ServerAddXP(amount, economyType);
			}
			else
			{
				CmdAddXP(amount, economyType);
			}
		}
	}

	public void SetCompanyIdentity(string companyName, int logoIndex, int backgroundColorIndex = 0, int frontColorIndex = 0)
	{
		if (!string.IsNullOrWhiteSpace(companyName))
		{
			if (base.isServer)
			{
				ServerSetCompanyIdentity(companyName, logoIndex, backgroundColorIndex, frontColorIndex);
			}
			else
			{
				CmdSetCompanyIdentity(companyName, logoIndex, backgroundColorIndex, frontColorIndex);
			}
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdAddMoney(int amount, EconomyType economyType)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdAddMoney__Int32__EconomyType(amount, economyType);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(amount);
		GeneratedNetworkCode._Write_EconomyType(writer, economyType);
		SendCommandInternal("System.Void FactoryManager::CmdAddMoney(System.Int32,EconomyType)", -1958916652, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdReduceMoney(int amount, EconomyType economyType)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdReduceMoney__Int32__EconomyType(amount, economyType);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(amount);
		GeneratedNetworkCode._Write_EconomyType(writer, economyType);
		SendCommandInternal("System.Void FactoryManager::CmdReduceMoney(System.Int32,EconomyType)", 999485517, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdForceReduceMoney(int amount, EconomyType economyType)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdForceReduceMoney__Int32__EconomyType(amount, economyType);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(amount);
		GeneratedNetworkCode._Write_EconomyType(writer, economyType);
		SendCommandInternal("System.Void FactoryManager::CmdForceReduceMoney(System.Int32,EconomyType)", 2140976294, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdAddXP(int amount, EconomyType economyType)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdAddXP__Int32__EconomyType(amount, economyType);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(amount);
		GeneratedNetworkCode._Write_EconomyType(writer, economyType);
		SendCommandInternal("System.Void FactoryManager::CmdAddXP(System.Int32,EconomyType)", 1287339372, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdSetCompanyIdentity(string companyName, int logoIndex, int backgroundColorIndex, int frontColorIndex)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdSetCompanyIdentity__String__Int32__Int32__Int32(companyName, logoIndex, backgroundColorIndex, frontColorIndex);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(companyName);
		writer.WriteVarInt(logoIndex);
		writer.WriteVarInt(backgroundColorIndex);
		writer.WriteVarInt(frontColorIndex);
		SendCommandInternal("System.Void FactoryManager::CmdSetCompanyIdentity(System.String,System.Int32,System.Int32,System.Int32)", -218877498, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerAddMoney(int amount, EconomyType economyType)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void FactoryManager::ServerAddMoney(System.Int32,EconomyType)' called when server was not active");
			return;
		}
		int money = _money;
		Network_money = _money + amount;
		if (NetworkServer.active && NetworkClient.isConnected)
		{
			onMoneyChanged?.Invoke(money, _money);
			this.OnMoneyTransaction?.Invoke(amount, economyType);
			ShowMoneyNotificationLocal(amount, economyType);
		}
		RpcShowMoneyNotification(amount, economyType);
	}

	[Server]
	private void ServerReduceMoney(int amount, EconomyType economyType)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void FactoryManager::ServerReduceMoney(System.Int32,EconomyType)' called when server was not active");
			return;
		}
		int money = _money;
		Network_money = _money - amount;
		if (NetworkServer.active && NetworkClient.isConnected)
		{
			onMoneyChanged?.Invoke(money, _money);
			this.OnMoneyTransaction?.Invoke(-amount, economyType);
			ShowMoneyNotificationLocal(-amount, economyType);
		}
		RpcShowMoneyNotification(-amount, economyType);
	}

	[Server]
	private void ServerForceReduceMoney(int amount, EconomyType economyType)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void FactoryManager::ServerForceReduceMoney(System.Int32,EconomyType)' called when server was not active");
			return;
		}
		int money = _money;
		Network_money = _money - amount;
		if (NetworkServer.active && NetworkClient.isConnected)
		{
			onMoneyChanged?.Invoke(money, _money);
			this.OnMoneyTransaction?.Invoke(-amount, economyType);
			ShowMoneyNotificationLocal(-amount, economyType);
		}
		RpcShowMoneyNotification(-amount, economyType);
	}

	[Server]
	private void ServerAddXP(int amount, EconomyType economyType)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void FactoryManager::ServerAddXP(System.Int32,EconomyType)' called when server was not active");
			return;
		}
		if (levelConfig == null)
		{
			Debug.LogError("[FactoryManager] LevelConfig atanmamış!");
			return;
		}
		int currentXP = _currentXP;
		Network_currentXP = _currentXP + amount;
		if (NetworkServer.active && NetworkClient.isConnected)
		{
			onXPChanged?.Invoke(currentXP, _currentXP);
			this.OnXPTransaction?.Invoke(amount, economyType);
			ShowXPNotificationLocal(amount, economyType);
		}
		RpcShowXPNotification(amount, economyType);
		ProcessLevelUp();
	}

	[Server]
	private void ProcessLevelUp()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void FactoryManager::ProcessLevelUp()' called when server was not active");
			return;
		}
		while (!levelConfig.IsMaxLevel(_level))
		{
			int requiredXPForLevel = levelConfig.GetRequiredXPForLevel(_level + 1);
			if (_currentXP < requiredXPForLevel)
			{
				break;
			}
			int level = _level;
			int currentXP = _currentXP;
			Network_currentXP = _currentXP - requiredXPForLevel;
			Network_level = _level + 1;
			if (NetworkServer.active && NetworkClient.isConnected)
			{
				onXPChanged?.Invoke(currentXP, _currentXP);
				onLevelChanged?.Invoke(level, _level);
				onLevelUp?.Invoke();
			}
			RpcNotifyLevelUp(_level);
			Debug.Log($"[FactoryManager] Level atlandı! Yeni level: {_level}");
		}
		if (levelConfig.IsMaxLevel(_level))
		{
			int currentXP2 = _currentXP;
			Network_currentXP = 0;
			if (NetworkServer.active && NetworkClient.isConnected)
			{
				onXPChanged?.Invoke(currentXP2, _currentXP);
			}
		}
	}

	[Server]
	private void ServerSetCompanyIdentity(string companyName, int logoIndex, int backgroundColorIndex, int frontColorIndex)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void FactoryManager::ServerSetCompanyIdentity(System.String,System.Int32,System.Int32,System.Int32)' called when server was not active");
			return;
		}
		if (identityConfig != null)
		{
			logoIndex = Mathf.Clamp(logoIndex, 0, Mathf.Max(0, identityConfig.LogoCount - 1));
			backgroundColorIndex = Mathf.Clamp(backgroundColorIndex, 0, Mathf.Max(0, identityConfig.ColorCount - 1));
			frontColorIndex = Mathf.Clamp(frontColorIndex, 0, Mathf.Max(0, identityConfig.ColorCount - 1));
		}
		string companyName2 = _companyName;
		int companyLogoIndex = _companyLogoIndex;
		int backgroundColorIndex2 = _backgroundColorIndex;
		int frontColorIndex2 = _frontColorIndex;
		Network_companyName = companyName;
		Network_companyLogoIndex = logoIndex;
		Network_backgroundColorIndex = backgroundColorIndex;
		Network_frontColorIndex = frontColorIndex;
		if (NetworkServer.active && NetworkClient.isConnected)
		{
			onCompanyNameChanged?.Invoke(companyName2, _companyName);
			onCompanyLogoIndexChanged?.Invoke(companyLogoIndex, _companyLogoIndex);
			onBackgroundColorIndexChanged?.Invoke(backgroundColorIndex2, _backgroundColorIndex);
			onFrontColorIndexChanged?.Invoke(frontColorIndex2, _frontColorIndex);
			UpdateGameCreatorCompanyName(_companyName);
			UpdateGameCreatorCompanyIcon(_companyLogoIndex);
			UpdateGameCreatorBackgroundColor(_backgroundColorIndex);
			UpdateGameCreatorFrontColor(_frontColorIndex);
		}
		Debug.Log($"[FactoryManager] Şirket kimliği ayarlandı: {companyName} (Logo: {logoIndex}, BgColor: {backgroundColorIndex}, FrontColor: {frontColorIndex})");
	}

	[ClientRpc]
	private void RpcShowMoneyNotification(int delta, EconomyType economyType)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(delta);
		GeneratedNetworkCode._Write_EconomyType(writer, economyType);
		SendRPCInternal("System.Void FactoryManager::RpcShowMoneyNotification(System.Int32,EconomyType)", -1083706554, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcShowXPNotification(int delta, EconomyType economyType)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(delta);
		GeneratedNetworkCode._Write_EconomyType(writer, economyType);
		SendRPCInternal("System.Void FactoryManager::RpcShowXPNotification(System.Int32,EconomyType)", -1064428348, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void ShowMoneyNotificationLocal(int delta, EconomyType economyType)
	{
		if (delta != 0 && ItemNotificationManager.Instance != null)
		{
			ItemNotificationManager.Instance.ShowMoneyNotification(delta, economyType);
		}
	}

	private void ShowXPNotificationLocal(int delta, EconomyType economyType)
	{
		if (delta != 0 && ItemNotificationManager.Instance != null)
		{
			ItemNotificationManager.Instance.ShowXPNotification(delta, economyType);
		}
	}

	[ContextMenu("Test: Add 100 Money (Sale)")]
	private void TestAddMoney()
	{
		AddMoney(100, EconomyType.EconomyType_Sale);
	}

	[ContextMenu("Test: Reduce 50 Money (Purchase)")]
	private void TestReduceMoney()
	{
		ReduceMoney(50, EconomyType.EconomyType_Purchase);
	}

	[ContextMenu("Test: Add 30 XP (Contract)")]
	private void TestAddXP()
	{
		AddXP(30, EconomyType.EconomyType_Contract);
	}

	public object GetSaveData(bool includeNonSavable)
	{
		if (!base.isServer)
		{
			return null;
		}
		UpdateMetaLevel(_level);
		if (DayNightManager.Instance != null)
		{
			UpdateMetaDay(DayNightManager.Instance.CurrentGameDay);
		}
		FactorySaveData factorySaveData = new FactorySaveData
		{
			money = _money,
			currentXP = _currentXP,
			level = _level
		};
		Debug.Log($"[FactoryManager] Save - Para: {factorySaveData.money}, XP: {factorySaveData.currentXP}, Level: {factorySaveData.level}");
		return factorySaveData;
	}

	public Task OnLoad(object value)
	{
		if (!(value is FactorySaveData factorySaveData))
		{
			Debug.LogWarning("[FactoryManager] Load basarisiz - gecersiz data");
			return Task.CompletedTask;
		}
		if (!base.isServer)
		{
			Debug.Log("[FactoryManager] Client - load atlaniyor, SyncVar ile sync olacak");
			return Task.CompletedTask;
		}
		int money = _money;
		int currentXP = _currentXP;
		int level = _level;
		Network_money = factorySaveData.money;
		Network_currentXP = factorySaveData.currentXP;
		Network_level = factorySaveData.level;
		if (NetworkServer.active && NetworkClient.isConnected)
		{
			onMoneyChanged?.Invoke(money, _money);
			onXPChanged?.Invoke(currentXP, _currentXP);
			onLevelChanged?.Invoke(level, _level);
		}
		Debug.Log($"[FactoryManager] Load - Para: {_money}, XP: {_currentXP}, Level: {_level}");
		return Task.CompletedTask;
	}

	private void OnEnable()
	{
		SaveLoadManager.Subscribe(this, 40);
		if (Singleton<SaveLoadManager>.Instance != null)
		{
			Singleton<SaveLoadManager>.Instance.EventAfterLoad += OnAfterLoad;
		}
		Debug.Log("[FactoryManager] SaveLoadManager'a subscribe olundu");
	}

	private void OnDisable()
	{
		if (Singleton<SaveLoadManager>.Instance != null)
		{
			Singleton<SaveLoadManager>.Instance.EventAfterLoad -= OnAfterLoad;
		}
	}

	private void LoadIdentityFromVariables(bool newGame)
	{
		if (companyVariables == null)
		{
			return;
		}
		string companyName = _companyName;
		int companyLogoIndex = _companyLogoIndex;
		int backgroundColorIndex = _backgroundColorIndex;
		int frontColorIndex = _frontColorIndex;
		if (companyVariables.Get("Company-Name") is string text && !string.IsNullOrEmpty(text) && !newGame)
		{
			Network_companyName = text;
		}
		object obj = companyVariables.Get("Company-LogoIndex");
		int num = -1;
		if (obj is int num2)
		{
			num = num2;
		}
		else if (obj is double num3)
		{
			num = (int)num3;
		}
		if (num < 0 && identityConfig != null && companyVariables.Get("Company-Icon") is Sprite item)
		{
			int num4 = identityConfig.companyLogos.IndexOf(item);
			if (num4 >= 0)
			{
				num = num4;
			}
		}
		if (num >= 0)
		{
			Network_companyLogoIndex = num;
		}
		object obj2 = companyVariables.Get("Company-Background-Color-Index");
		if (obj2 is int network_backgroundColorIndex)
		{
			Network_backgroundColorIndex = network_backgroundColorIndex;
		}
		else if (obj2 is double num5)
		{
			Network_backgroundColorIndex = (int)num5;
		}
		object obj3 = companyVariables.Get("Company-Front-Color-Index");
		if (obj3 is int network_frontColorIndex)
		{
			Network_frontColorIndex = network_frontColorIndex;
		}
		else if (obj3 is double num6)
		{
			Network_frontColorIndex = (int)num6;
		}
		if (NetworkServer.active && NetworkClient.isConnected)
		{
			if (!string.IsNullOrEmpty(_companyName))
			{
				onCompanyNameChanged?.Invoke(companyName, _companyName);
				onCompanyLogoIndexChanged?.Invoke(companyLogoIndex, _companyLogoIndex);
			}
			onBackgroundColorIndexChanged?.Invoke(backgroundColorIndex, _backgroundColorIndex);
			onFrontColorIndexChanged?.Invoke(frontColorIndex, _frontColorIndex);
		}
		Debug.Log($"[FactoryManager] LoadIdentityFromVariables - CompanyName: '{_companyName}', LogoIndex: {_companyLogoIndex}, BgColor: {_backgroundColorIndex}, FrontColor: {_frontColorIndex}");
	}

	private void OnAfterLoad(int slot)
	{
		if (base.isServer)
		{
			LoadIdentityFromVariables(newGame: false);
		}
	}

	public FactoryManager()
	{
		_Mirror_SyncVarHookDelegate__money = OnMoneyChangedHook;
		_Mirror_SyncVarHookDelegate__currentXP = OnXPChangedHook;
		_Mirror_SyncVarHookDelegate__level = OnLevelChangedHook;
		_Mirror_SyncVarHookDelegate__companyName = OnCompanyNameChangedHook;
		_Mirror_SyncVarHookDelegate__companyLogoIndex = OnCompanyLogoIndexChangedHook;
		_Mirror_SyncVarHookDelegate__backgroundColorIndex = OnBackgroundColorIndexChangedHook;
		_Mirror_SyncVarHookDelegate__frontColorIndex = OnFrontColorIndexChangedHook;
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_RpcNotifyLevelUp__Int32(int newLevel)
	{
		onRealLevelUp?.Invoke(newLevel);
	}

	protected static void InvokeUserCode_RpcNotifyLevelUp__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcNotifyLevelUp called on server.");
		}
		else
		{
			((FactoryManager)obj).UserCode_RpcNotifyLevelUp__Int32(reader.ReadVarInt());
		}
	}

	protected void UserCode_CmdAddMoney__Int32__EconomyType(int amount, EconomyType economyType)
	{
		ServerAddMoney(amount, economyType);
	}

	protected static void InvokeUserCode_CmdAddMoney__Int32__EconomyType(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdAddMoney called on client.");
		}
		else
		{
			((FactoryManager)obj).UserCode_CmdAddMoney__Int32__EconomyType(reader.ReadVarInt(), GeneratedNetworkCode._Read_EconomyType(reader));
		}
	}

	protected void UserCode_CmdReduceMoney__Int32__EconomyType(int amount, EconomyType economyType)
	{
		if (_money >= amount)
		{
			ServerReduceMoney(amount, economyType);
		}
	}

	protected static void InvokeUserCode_CmdReduceMoney__Int32__EconomyType(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdReduceMoney called on client.");
		}
		else
		{
			((FactoryManager)obj).UserCode_CmdReduceMoney__Int32__EconomyType(reader.ReadVarInt(), GeneratedNetworkCode._Read_EconomyType(reader));
		}
	}

	protected void UserCode_CmdForceReduceMoney__Int32__EconomyType(int amount, EconomyType economyType)
	{
		ServerForceReduceMoney(amount, economyType);
	}

	protected static void InvokeUserCode_CmdForceReduceMoney__Int32__EconomyType(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdForceReduceMoney called on client.");
		}
		else
		{
			((FactoryManager)obj).UserCode_CmdForceReduceMoney__Int32__EconomyType(reader.ReadVarInt(), GeneratedNetworkCode._Read_EconomyType(reader));
		}
	}

	protected void UserCode_CmdAddXP__Int32__EconomyType(int amount, EconomyType economyType)
	{
		ServerAddXP(amount, economyType);
	}

	protected static void InvokeUserCode_CmdAddXP__Int32__EconomyType(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdAddXP called on client.");
		}
		else
		{
			((FactoryManager)obj).UserCode_CmdAddXP__Int32__EconomyType(reader.ReadVarInt(), GeneratedNetworkCode._Read_EconomyType(reader));
		}
	}

	protected void UserCode_CmdSetCompanyIdentity__String__Int32__Int32__Int32(string companyName, int logoIndex, int backgroundColorIndex, int frontColorIndex)
	{
		ServerSetCompanyIdentity(companyName, logoIndex, backgroundColorIndex, frontColorIndex);
	}

	protected static void InvokeUserCode_CmdSetCompanyIdentity__String__Int32__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSetCompanyIdentity called on client.");
		}
		else
		{
			((FactoryManager)obj).UserCode_CmdSetCompanyIdentity__String__Int32__Int32__Int32(reader.ReadString(), reader.ReadVarInt(), reader.ReadVarInt(), reader.ReadVarInt());
		}
	}

	protected void UserCode_RpcShowMoneyNotification__Int32__EconomyType(int delta, EconomyType economyType)
	{
		if (!base.isServer)
		{
			ShowMoneyNotificationLocal(delta, economyType);
		}
	}

	protected static void InvokeUserCode_RpcShowMoneyNotification__Int32__EconomyType(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcShowMoneyNotification called on server.");
		}
		else
		{
			((FactoryManager)obj).UserCode_RpcShowMoneyNotification__Int32__EconomyType(reader.ReadVarInt(), GeneratedNetworkCode._Read_EconomyType(reader));
		}
	}

	protected void UserCode_RpcShowXPNotification__Int32__EconomyType(int delta, EconomyType economyType)
	{
		if (!base.isServer)
		{
			ShowXPNotificationLocal(delta, economyType);
		}
	}

	protected static void InvokeUserCode_RpcShowXPNotification__Int32__EconomyType(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcShowXPNotification called on server.");
		}
		else
		{
			((FactoryManager)obj).UserCode_RpcShowXPNotification__Int32__EconomyType(reader.ReadVarInt(), GeneratedNetworkCode._Read_EconomyType(reader));
		}
	}

	static FactoryManager()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(FactoryManager), "System.Void FactoryManager::CmdAddMoney(System.Int32,EconomyType)", InvokeUserCode_CmdAddMoney__Int32__EconomyType, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(FactoryManager), "System.Void FactoryManager::CmdReduceMoney(System.Int32,EconomyType)", InvokeUserCode_CmdReduceMoney__Int32__EconomyType, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(FactoryManager), "System.Void FactoryManager::CmdForceReduceMoney(System.Int32,EconomyType)", InvokeUserCode_CmdForceReduceMoney__Int32__EconomyType, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(FactoryManager), "System.Void FactoryManager::CmdAddXP(System.Int32,EconomyType)", InvokeUserCode_CmdAddXP__Int32__EconomyType, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(FactoryManager), "System.Void FactoryManager::CmdSetCompanyIdentity(System.String,System.Int32,System.Int32,System.Int32)", InvokeUserCode_CmdSetCompanyIdentity__String__Int32__Int32__Int32, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(FactoryManager), "System.Void FactoryManager::RpcNotifyLevelUp(System.Int32)", InvokeUserCode_RpcNotifyLevelUp__Int32);
		RemoteProcedureCalls.RegisterRpc(typeof(FactoryManager), "System.Void FactoryManager::RpcShowMoneyNotification(System.Int32,EconomyType)", InvokeUserCode_RpcShowMoneyNotification__Int32__EconomyType);
		RemoteProcedureCalls.RegisterRpc(typeof(FactoryManager), "System.Void FactoryManager::RpcShowXPNotification(System.Int32,EconomyType)", InvokeUserCode_RpcShowXPNotification__Int32__EconomyType);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteVarInt(_money);
			writer.WriteVarInt(_currentXP);
			writer.WriteVarInt(_level);
			writer.WriteString(_companyName);
			writer.WriteVarInt(_companyLogoIndex);
			writer.WriteVarInt(_backgroundColorIndex);
			writer.WriteVarInt(_frontColorIndex);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteVarInt(_money);
		}
		if ((syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteVarInt(_currentXP);
		}
		if ((syncVarDirtyBits & 4L) != 0L)
		{
			writer.WriteVarInt(_level);
		}
		if ((syncVarDirtyBits & 8L) != 0L)
		{
			writer.WriteString(_companyName);
		}
		if ((syncVarDirtyBits & 0x10L) != 0L)
		{
			writer.WriteVarInt(_companyLogoIndex);
		}
		if ((syncVarDirtyBits & 0x20L) != 0L)
		{
			writer.WriteVarInt(_backgroundColorIndex);
		}
		if ((syncVarDirtyBits & 0x40L) != 0L)
		{
			writer.WriteVarInt(_frontColorIndex);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _money, _Mirror_SyncVarHookDelegate__money, reader.ReadVarInt());
			GeneratedSyncVarDeserialize(ref _currentXP, _Mirror_SyncVarHookDelegate__currentXP, reader.ReadVarInt());
			GeneratedSyncVarDeserialize(ref _level, _Mirror_SyncVarHookDelegate__level, reader.ReadVarInt());
			GeneratedSyncVarDeserialize(ref _companyName, _Mirror_SyncVarHookDelegate__companyName, reader.ReadString());
			GeneratedSyncVarDeserialize(ref _companyLogoIndex, _Mirror_SyncVarHookDelegate__companyLogoIndex, reader.ReadVarInt());
			GeneratedSyncVarDeserialize(ref _backgroundColorIndex, _Mirror_SyncVarHookDelegate__backgroundColorIndex, reader.ReadVarInt());
			GeneratedSyncVarDeserialize(ref _frontColorIndex, _Mirror_SyncVarHookDelegate__frontColorIndex, reader.ReadVarInt());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _money, _Mirror_SyncVarHookDelegate__money, reader.ReadVarInt());
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _currentXP, _Mirror_SyncVarHookDelegate__currentXP, reader.ReadVarInt());
		}
		if ((num & 4L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _level, _Mirror_SyncVarHookDelegate__level, reader.ReadVarInt());
		}
		if ((num & 8L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _companyName, _Mirror_SyncVarHookDelegate__companyName, reader.ReadString());
		}
		if ((num & 0x10L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _companyLogoIndex, _Mirror_SyncVarHookDelegate__companyLogoIndex, reader.ReadVarInt());
		}
		if ((num & 0x20L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _backgroundColorIndex, _Mirror_SyncVarHookDelegate__backgroundColorIndex, reader.ReadVarInt());
		}
		if ((num & 0x40L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _frontColorIndex, _Mirror_SyncVarHookDelegate__frontColorIndex, reader.ReadVarInt());
		}
	}
}
