using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Extensions;
using FMODUnity;
using Mirror;
using Mirror.RemoteCalls;
using MoreMountains.Feedbacks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoneyDisplayAndFeedbacks : NetworkSingleton<MoneyDisplayAndFeedbacks>
{
	private class HistoryEntry
	{
		public Transform root;

		public TextMeshProUGUI profitText;

		public TextMeshProUGUI nameText;

		public double displayedValue;

		public Tween tween;
	}

	private class ActiveMoneyChange
	{
		public MoneyChangeText instance;

		public double displayedValue;

		public double targetValue;

		public Tween valueTween;

		public Tween hideTween;
	}

	[Header("References")]
	[SerializeField]
	private TextMeshProUGUI ticketBalanceLabel;

	[SerializeField]
	private TextMeshProUGUI balanceLabel;

	[SerializeField]
	private TextMeshProUGUI quotaLabel;

	[Header("Feedbacks (Visual)")]
	[Tooltip("Prefabs are instantiated under this transform for the display duration, then destroyed.")]
	[SerializeField]
	private Transform feedbackParent;

	[SerializeField]
	private MMF_Player onBalanceChangedFeedbacks;

	[SerializeField]
	private MoneyChangeText moneyChangePrefab;

	[SerializeField]
	private float disappearTime = 1f;

	[Tooltip("Only show money change popup when |change| is at least this fraction of current quota (e.g. 0.05 = 5%). Big wins/losses only.")]
	[SerializeField]
	[Range(0f, 1f)]
	private float minQuotaFractionToShow = 0.05f;

	[Header("Feedbacks (Audio)")]
	[SerializeField]
	private EventReference sfxMoneyUp;

	[SerializeField]
	private EventReference sfxMoneyDown;

	[SerializeField]
	private EventReference sfxMoneyCountUp;

	[SerializeField]
	private EventReference sfxMoneyCountDown;

	[Header("Profit History")]
	[SerializeField]
	private Transform playerHistoryContainer;

	[SerializeField]
	private Transform playerHistoryEntryPrefab;

	private readonly Dictionary<ulong, HistoryEntry> _historyEntries = new Dictionary<ulong, HistoryEntry>();

	private LobbySettings _lobbySettings;

	[Header("Money lerp")]
	[SerializeField]
	private float moneyLerpDuration = 0.5f;

	[SerializeField]
	private float goalReachedPunchScale = 0.15f;

	[SerializeField]
	private float goalReachedPunchDuration = 0.25f;

	private double _displayedTicketBalance;

	private Tween _ticketTween;

	private double _displayedBalance;

	private double _displayedQuota;

	private Tween _balanceTween;

	private Tween _quotaTween;

	public readonly SyncDictionary<ulong, long> PlayerProfitHistory = new SyncDictionary<ulong, long>();

	private bool _suppressProfitHistoryUi;

	private readonly Dictionary<ulong, ActiveMoneyChange> _activeMoneyChanges = new Dictionary<ulong, ActiveMoneyChange>();

	public override void OnStartClient()
	{
		base.OnStartClient();
		SyncDictionary<ulong, long> playerProfitHistory = PlayerProfitHistory;
		playerProfitHistory.OnChange = (Action<SyncIDictionary<ulong, long>.Operation, ulong, long>)Delegate.Remove(playerProfitHistory.OnChange, new Action<SyncIDictionary<ulong, long>.Operation, ulong, long>(OnProfitHistoryChanged));
		SyncDictionary<ulong, long> playerProfitHistory2 = PlayerProfitHistory;
		playerProfitHistory2.OnChange = (Action<SyncIDictionary<ulong, long>.Operation, ulong, long>)Delegate.Combine(playerProfitHistory2.OnChange, new Action<SyncIDictionary<ulong, long>.Operation, ulong, long>(OnProfitHistoryChanged));
		UpdatePlayerHistoryLabel();
	}

	private void OnEnable()
	{
		SubscribeEvents();
		SubscribeLobbyEvents();
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	private void OnDisable()
	{
		UnsubscribeEvents();
		UnsubscribeLobbyEvents();
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	private void Start()
	{
		_displayedTicketBalance = NetworkSingleton<MoneyManager>.Instance.ticketBalance;
		ticketBalanceLabel.text = ((long)_displayedTicketBalance).ToString("N0");
		_displayedBalance = NetworkSingleton<MoneyManager>.Instance.balance;
		_displayedQuota = ((NetworkSingleton<GameManager>.Instance != null) ? NetworkSingleton<GameManager>.Instance.currentQuota : 0);
		if (balanceLabel != null)
		{
			balanceLabel.text = MoneyFormatter.FormatWithDollar((long)_displayedBalance);
		}
		if (quotaLabel != null)
		{
			quotaLabel.text = "/ " + MoneyFormatter.FormatWithDollar((long)_displayedQuota);
		}
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		DOTween.Kill(this);
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		if (scene.name == "WinStateScene")
		{
			quotaLabel.gameObject.SetActive(value: false);
		}
		else
		{
			quotaLabel.gameObject.SetActive(value: true);
		}
	}

	private static void SetProfitEntryText(HistoryEntry entry)
	{
		long num = (long)entry.displayedValue;
		entry.profitText.text = ((num >= 0) ? ("+" + MoneyFormatter.FormatWithDollar(num)) : MoneyFormatter.FormatWithDollar(num));
		entry.profitText.color = ((num >= 0) ? Color.green : Color.red);
	}

	private void PlayGoalReachedScale(Transform target)
	{
		if (!(target == null))
		{
			target.DOPunchScale(Vector3.one * goalReachedPunchScale, goalReachedPunchDuration).SetTarget(this);
		}
	}

	private void SubscribeEvents()
	{
		if (NetworkSingleton<MoneyManager>.Instance != null)
		{
			MoneyManager instance = NetworkSingleton<MoneyManager>.Instance;
			instance.OnBalanceChanged = (Action<BalanceChangeData>)Delegate.Combine(instance.OnBalanceChanged, new Action<BalanceChangeData>(UpdateDisplay));
			MoneyManager instance2 = NetworkSingleton<MoneyManager>.Instance;
			instance2.OnTicketBalanceChanged = (Action<long>)Delegate.Combine(instance2.OnTicketBalanceChanged, new Action<long>(UpdateTicketDisplay));
		}
		if (NetworkSingleton<GameManager>.Instance != null)
		{
			NetworkSingleton<GameManager>.Instance.OnQuotaChangedEvent += OnQuotaChanged;
		}
	}

	private void UnsubscribeEvents()
	{
		if (NetworkSingleton<MoneyManager>.Instance != null)
		{
			MoneyManager instance = NetworkSingleton<MoneyManager>.Instance;
			instance.OnBalanceChanged = (Action<BalanceChangeData>)Delegate.Remove(instance.OnBalanceChanged, new Action<BalanceChangeData>(UpdateDisplay));
			MoneyManager instance2 = NetworkSingleton<MoneyManager>.Instance;
			instance2.OnTicketBalanceChanged = (Action<long>)Delegate.Remove(instance2.OnTicketBalanceChanged, new Action<long>(UpdateTicketDisplay));
		}
		if (NetworkSingleton<GameManager>.Instance != null)
		{
			NetworkSingleton<GameManager>.Instance.OnQuotaChangedEvent -= OnQuotaChanged;
		}
	}

	private void SubscribeLobbyEvents()
	{
		if (_lobbySettings == null)
		{
			_lobbySettings = Resources.Load<LobbySettings>("LobbySettings");
		}
		LobbySettings.SettingsChanged -= OnLobbySettingsChanged;
		LobbySettings.SettingsChanged += OnLobbySettingsChanged;
	}

	private void UnsubscribeLobbyEvents()
	{
		LobbySettings.SettingsChanged -= OnLobbySettingsChanged;
	}

	private void OnLobbySettingsChanged(LobbySettings _)
	{
		UpdatePlayerHistoryLabel();
	}

	private void OnProfitHistoryChanged(SyncIDictionary<ulong, long>.Operation op, ulong key, long value)
	{
		UpdatePlayerHistoryLabel();
	}

	private void UpdateDisplay(BalanceChangeData balanceChangeData)
	{
		AddEntryToPlayerHistory(balanceChangeData);
		PlayFeedbacks(balanceChangeData);
		LerpBalance();
	}

	private void LerpBalance()
	{
		_balanceTween?.Kill();
		long balance = NetworkSingleton<MoneyManager>.Instance.balance;
		_balanceTween = DOTween.To(() => _displayedBalance, delegate(double x)
		{
			_displayedBalance = x;
			if (balanceLabel != null)
			{
				balanceLabel.text = MoneyFormatter.FormatWithDollar((long)x, floorDecimals: true);
			}
		}, balance, moneyLerpDuration).SetTarget(this).OnComplete(delegate
		{
			PlayGoalReachedScale((balanceLabel != null) ? balanceLabel.transform : null);
		});
	}

	private void OnQuotaChanged(long _, long newQuota)
	{
		_quotaTween?.Kill();
		_quotaTween = DOTween.To(() => _displayedQuota, delegate(double x)
		{
			_displayedQuota = x;
			if (quotaLabel != null)
			{
				quotaLabel.text = "/ " + MoneyFormatter.FormatWithDollar((long)x);
			}
		}, newQuota, moneyLerpDuration).SetTarget(this).OnComplete(delegate
		{
			PlayGoalReachedScale((quotaLabel != null) ? quotaLabel.transform : null);
		});
	}

	private void UpdateTicketDisplay(long change)
	{
		_ticketTween?.Kill();
		long ticketBalance = NetworkSingleton<MoneyManager>.Instance.ticketBalance;
		_ticketTween = DOTween.To(() => _displayedTicketBalance, delegate(double x)
		{
			_displayedTicketBalance = x;
			ticketBalanceLabel.text = ((long)x).ToString("N0");
		}, ticketBalance, moneyLerpDuration).SetTarget(this).OnComplete(delegate
		{
			PlayGoalReachedScale(ticketBalanceLabel.transform);
		});
	}

	private void UpdatePlayerHistoryLabel()
	{
		HashSet<ulong> currentPlayerIds = GetCurrentPlayerIds();
		HashSet<ulong> hashSet = new HashSet<ulong>(currentPlayerIds);
		foreach (ulong key2 in PlayerProfitHistory.Keys)
		{
			if (currentPlayerIds.Contains(key2))
			{
				hashSet.Add(key2);
			}
		}
		List<KeyValuePair<ulong, long>> list = (from e in hashSet.Select(delegate(ulong steamId)
			{
				long value2 = 0L;
				PlayerProfitHistory.TryGetValue(steamId, out value2);
				return new KeyValuePair<ulong, long>(steamId, value2);
			})
			orderby e.Value descending
			select e).ToList();
		foreach (KeyValuePair<ulong, long> item in list)
		{
			ulong key = item.Key;
			long value = item.Value;
			if (!_historyEntries.TryGetValue(key, out var entry))
			{
				Transform transform = UnityEngine.Object.Instantiate(playerHistoryEntryPrefab, playerHistoryContainer);
				TextMeshProUGUI component = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
				TextMeshProUGUI component2 = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
				entry = new HistoryEntry
				{
					root = transform,
					profitText = component,
					nameText = component2,
					displayedValue = value
				};
				_historyEntries[key] = entry;
				SetProfitEntryText(entry);
			}
			else
			{
				entry.tween?.Kill();
				HistoryEntry entryCopy = entry;
				entry.tween = DOTween.To(() => entry.displayedValue, delegate(double x)
				{
					entry.displayedValue = x;
					SetProfitEntryText(entry);
				}, value, moneyLerpDuration).SetTarget(this).OnComplete(delegate
				{
					PlayGoalReachedScale(entryCopy.profitText.transform);
				});
			}
			entry.nameText.text = GetPlayerDisplayName(key);
		}
		HashSet<ulong> hashSet2 = new HashSet<ulong>(list.Select((KeyValuePair<ulong, long> e) => e.Key));
		foreach (ulong item2 in _historyEntries.Keys.ToList())
		{
			if (!hashSet2.Contains(item2))
			{
				_historyEntries[item2].tween?.Kill();
				UnityEngine.Object.Destroy(_historyEntries[item2].root.gameObject);
				_historyEntries.Remove(item2);
			}
		}
		for (int num = 0; num < list.Count; num++)
		{
			_historyEntries[list[num].Key].root.SetSiblingIndex(num);
		}
	}

	private HashSet<ulong> GetCurrentPlayerIds()
	{
		if (_lobbySettings == null)
		{
			_lobbySettings = Resources.Load<LobbySettings>("LobbySettings");
		}
		if (_lobbySettings == null || _lobbySettings.players == null)
		{
			return new HashSet<ulong>();
		}
		return (from p in _lobbySettings.players
			where p.steamId != 0
			select p.steamId).ToHashSet();
	}

	private string GetPlayerDisplayName(ulong steamId)
	{
		if (_lobbySettings == null)
		{
			_lobbySettings = Resources.Load<LobbySettings>("LobbySettings");
		}
		if (!(_lobbySettings != null))
		{
			return steamId.ToString();
		}
		return _lobbySettings.GetPlayerBySteamId(steamId)?.playerName ?? steamId.ToString();
	}

	private void AddEntryToPlayerHistory(BalanceChangeData balanceChangeData)
	{
		if (base.isServer && (bool)balanceChangeData.changer && balanceChangeData.changer.steamId != 0L && balanceChangeData.changeType != ChangeType.Misc)
		{
			ulong steamId = balanceChangeData.changer.steamId;
			if (PlayerProfitHistory.ContainsKey(steamId))
			{
				PlayerProfitHistory[steamId] += balanceChangeData.changeAmount;
			}
			else
			{
				PlayerProfitHistory.TryAdd(steamId, balanceChangeData.changeAmount);
			}
		}
	}

	private void PlayFeedbacks(BalanceChangeData balanceChangeData)
	{
		long num = ((NetworkSingleton<GameManager>.Instance != null) ? NetworkSingleton<GameManager>.Instance.currentQuota : 0);
		if (num > 0)
		{
			long num2 = (long)((float)num * minQuotaFractionToShow);
			if (Math.Abs(balanceChangeData.changeAmount) >= num2)
			{
				SpawnMoneyChangeText(balanceChangeData);
			}
		}
	}

	private void SpawnMoneyChangeText(BalanceChangeData balanceChangeData)
	{
		if (!balanceChangeData.changer || balanceChangeData.changer.steamId == 0L)
		{
			return;
		}
		ulong key = balanceChangeData.changer.steamId;
		if (!_activeMoneyChanges.TryGetValue(key, out var active) || active.instance == null)
		{
			MoneyChangeText instance = UnityEngine.Object.Instantiate(moneyChangePrefab, feedbackParent);
			active = new ActiveMoneyChange
			{
				instance = instance,
				displayedValue = 0.0,
				targetValue = 0.0
			};
			_activeMoneyChanges[key] = active;
		}
		else if (active.hideTween != null && active.hideTween.IsActive())
		{
			active.hideTween.Kill();
			active.hideTween = null;
		}
		active.instance.playerNameText.text = balanceChangeData.changer.playerName;
		active.instance.playerNameText.color = new Color(1f, 1f, 1f, 1f);
		if (active.instance.playerColorImage != null)
		{
			LobbySettings lobbySettings = Resources.Load<LobbySettings>("LobbySettings");
			if (lobbySettings != null)
			{
				PlayerInfo playerBySteamId = lobbySettings.GetPlayerBySteamId(balanceChangeData.changer.steamId);
				if (playerBySteamId != null)
				{
					active.instance.playerColorImage.color = playerBySteamId.playerColor.PastelizeColor(0.6f, 0.3f);
				}
			}
		}
		active.targetValue += balanceChangeData.changeAmount;
		double newTotal = active.targetValue;
		if (active.valueTween != null && active.valueTween.IsActive())
		{
			active.valueTween.Kill();
		}
		SFXManager.SFXOneShot((newTotal > 0.0) ? sfxMoneyCountUp : sfxMoneyCountDown);
		active.valueTween = DOTween.To(() => active.displayedValue, delegate(double x)
		{
			active.displayedValue = x;
			long num = (long)x;
			active.instance.changeAmountText.text = ((num >= 0) ? ("+" + MoneyFormatter.FormatWithDollar(num)) : MoneyFormatter.FormatWithDollar(num));
			active.instance.changeAmountText.color = ((num > 0) ? Color.green : ((num < 0) ? Color.red : Color.white));
			active.instance.GetComponent<Image>().color = active.instance.changeAmountText.color;
		}, newTotal, moneyLerpDuration).SetTarget(this).OnComplete(delegate
		{
			SFXManager.SFXOneShot((newTotal > 0.0) ? sfxMoneyUp : sfxMoneyDown);
			active.hideTween = DOVirtual.DelayedCall(disappearTime, delegate
			{
				_activeMoneyChanges.Remove(key);
				if (active.instance != null)
				{
					UnityEngine.Object.Destroy(active.instance.gameObject);
				}
			}).SetTarget(this);
		});
		onBalanceChangedFeedbacks.PlayFeedbacks();
	}

	public Dictionary<ulong, long> GetProfitHistorySnapshot()
	{
		return new Dictionary<ulong, long>(PlayerProfitHistory);
	}

	[Server]
	public void SetProfitHistory(Dictionary<ulong, long> history)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void MoneyDisplayAndFeedbacks::SetProfitHistory(System.Collections.Generic.Dictionary`2<System.UInt64,System.Int64>)' called when server was not active");
			return;
		}
		RpcBeginProfitHistoryBulkSync();
		PlayerProfitHistory.Clear();
		if (history == null)
		{
			RpcEndProfitHistoryBulkSync();
			return;
		}
		foreach (KeyValuePair<ulong, long> item in history)
		{
			PlayerProfitHistory[item.Key] = item.Value;
		}
		RpcEndProfitHistoryBulkSync();
	}

	[ClientRpc]
	private void RpcBeginProfitHistoryBulkSync()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void MoneyDisplayAndFeedbacks::RpcBeginProfitHistoryBulkSync()", -1089434775, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcEndProfitHistoryBulkSync()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void MoneyDisplayAndFeedbacks::RpcEndProfitHistoryBulkSync()", 1866625689, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	public void ServerResetProfitHistory()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void MoneyDisplayAndFeedbacks::ServerResetProfitHistory()' called when server was not active");
			return;
		}
		PlayerProfitHistory.Clear();
		RpcRefreshProfitHistoryLabel();
	}

	[ClientRpc]
	private void RpcRefreshProfitHistoryLabel()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void MoneyDisplayAndFeedbacks::RpcRefreshProfitHistoryLabel()", -2118369112, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public MoneyDisplayAndFeedbacks()
	{
		InitSyncObject(PlayerProfitHistory);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_RpcBeginProfitHistoryBulkSync()
	{
		_suppressProfitHistoryUi = true;
	}

	protected static void InvokeUserCode_RpcBeginProfitHistoryBulkSync(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcBeginProfitHistoryBulkSync called on server.");
		}
		else
		{
			((MoneyDisplayAndFeedbacks)obj).UserCode_RpcBeginProfitHistoryBulkSync();
		}
	}

	protected void UserCode_RpcEndProfitHistoryBulkSync()
	{
		_suppressProfitHistoryUi = false;
		UpdatePlayerHistoryLabel();
	}

	protected static void InvokeUserCode_RpcEndProfitHistoryBulkSync(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcEndProfitHistoryBulkSync called on server.");
		}
		else
		{
			((MoneyDisplayAndFeedbacks)obj).UserCode_RpcEndProfitHistoryBulkSync();
		}
	}

	protected void UserCode_RpcRefreshProfitHistoryLabel()
	{
		UpdatePlayerHistoryLabel();
	}

	protected static void InvokeUserCode_RpcRefreshProfitHistoryLabel(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcRefreshProfitHistoryLabel called on server.");
		}
		else
		{
			((MoneyDisplayAndFeedbacks)obj).UserCode_RpcRefreshProfitHistoryLabel();
		}
	}

	static MoneyDisplayAndFeedbacks()
	{
		RemoteProcedureCalls.RegisterRpc(typeof(MoneyDisplayAndFeedbacks), "System.Void MoneyDisplayAndFeedbacks::RpcBeginProfitHistoryBulkSync()", InvokeUserCode_RpcBeginProfitHistoryBulkSync);
		RemoteProcedureCalls.RegisterRpc(typeof(MoneyDisplayAndFeedbacks), "System.Void MoneyDisplayAndFeedbacks::RpcEndProfitHistoryBulkSync()", InvokeUserCode_RpcEndProfitHistoryBulkSync);
		RemoteProcedureCalls.RegisterRpc(typeof(MoneyDisplayAndFeedbacks), "System.Void MoneyDisplayAndFeedbacks::RpcRefreshProfitHistoryLabel()", InvokeUserCode_RpcRefreshProfitHistoryLabel);
	}
}
