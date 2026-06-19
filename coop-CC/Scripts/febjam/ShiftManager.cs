using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aggro.Core;
using Aggro.Core.Networking;
using DevCmdLine;
using FMOD.Studio;
using FMODUnity;
using Mirror;
using Mirror.RemoteCalls;
using Unity.Mathematics;
using UnityEngine;

public class ShiftManager : NetworkAggroManagerBase<ShiftManager>, IInputController
{
	private struct OrderCountNet
	{
		public uint assetId;

		public byte count;
	}

	[Serializable]
	public struct TimerBonus
	{
		[Range(0f, 100f)]
		public int timePercentage;

		[Range(-100f, 100f)]
		public int payoutPercentage;

		[Min(0f)]
		public float scoreValue;
	}

	public struct EvMoneyTransaction : IEntityEvent, IEntityTyped
	{
		public int amount;
	}

	public struct EvTruckShipped : IEntityEvent, IEntityTyped
	{
		public int moneyMade;

		public int basePay;

		public int timerPay;

		public int damagePay;

		public int boxCount;

		public int wildCardCount;

		public int damageCount;
	}

	[Min(0f)]
	public float organizationalDuration = 60f;

	[Space]
	[Min(0f)]
	public float shiftFinishedPauseBeforeCameraDuration = 1f;

	[Min(0f)]
	public float shiftFinishedWaitAfterCameraDuration = 1f;

	[Min(0f)]
	public float shiftWonCameraMoveDuration = 1f;

	[Min(0f)]
	public float shiftLostCameraMoveDuration = 3f;

	[Space]
	[Min(0f)]
	public float cleanUpWaitDuration = 1f;

	[Min(0f)]
	public int startingMoney = 200;

	[Space]
	[Range(-100f, 0f)]
	public int truckDamageBoxDockPercentage = -50;

	public TimerBonus[] truckBonuses;

	public int[] scoreLetterGradeMaxRange;

	[Range(1f, 2f)]
	public float scoreMultiplierOnePlayer = 1.25f;

	[Range(1f, 2f)]
	public float scoreMultiplierTwoPlayers = 1.125f;

	[Range(1f, 2f)]
	public float scoreMultiplierThreePlayers = 1.05f;

	[Header("Achievements")]
	[Min(1f)]
	public int achievementHoarderAmount = 3000;

	[Min(1f)]
	public int achievementSomeBellsAmount = 50;

	[Header("Music")]
	public EventReference breakRoomMusic;

	public EventReference reportMusic;

	public EventReference lockedInMusic;

	[Header("Test")]
	public int testBoxPayout;

	public int testBoxCount;

	public int testWildCardCount;

	public int testDamageCount;

	[Range(1f, 4f)]
	public int testPlayerCount = 1;

	[Range(0f, 1f)]
	public float testTimerNormalized;

	[SyncVar]
	private int _syncTrucksCompleted;

	private readonly SyncList<OrderCountNet> _syncInboundOrders = new SyncList<OrderCountNet>();

	[SyncVar]
	private int _syncMoney;

	[SyncVar]
	private float _syncSecondsRemaining;

	[SyncVar]
	private sbyte _syncPlayListIndex;

	[SyncVar]
	private bool _syncLockedIn;

	private ShiftPhase _shiftPhase;

	private int _trucksThisShift;

	private int _currentShift;

	private bool _serverTimerDebugPaused;

	private bool _serverFailed;

	private float _serverStrikeOutDuration;

	private int _serverPayPerBox;

	private int _serverPlayerCount;

	private int _serverShiftFrames;

	private Vector3 _serverLastPosition;

	private bool _transitioning;

	private bool _proceeding;

	private int _seed;

	private float _serverShiftScore;

	private float _serverShiftMaxScore;

	private bool _sentHoarderAchievement;

	private int _startingBellCount;

	private List<CostumeObject> _costumesUnlocked = new List<CostumeObject>();

	private ContractScore? _debugScore;

	private ObjectQuery<IShiftChanged> _shiftChangeQuery;

	private ObjectQuery<Shop> _shopQuery;

	private ObjectQuery<PlayerGrabber> _grabbersQuery;

	private Timer _serverTimer;

	private Timer _serverPauseTimer;

	private Timer _serverLockedInTimer;

	private EventInstance _breakRoomMusicInstance;

	private EventInstance _shiftInstance;

	private EventInstance _reportMusicInstance;

	private EventInstance _lockedInMusicInstance;

	private PlayerResult[] _serverPlayerResults;

	private ContractScore[] _shiftScores = new ContractScore[5];

	private List<string> _devScoreShiftResults = new List<string>();

	public const int PAYOUT_INCREMENT = 1;

	public bool serverTimersPaused
	{
		get
		{
			if (!_serverTimerDebugPaused)
			{
				return !_serverPauseTimer.IsFinished();
			}
			return true;
		}
	}

	public bool playersLockedIn => _syncLockedIn;

	public float secondsRemaining => math.min(_syncSecondsRemaining, Mathf.RoundToInt(organizationalDuration));

	public int secondsRemainingInt => Mathf.CeilToInt(secondsRemaining);

	public bool isTransitioning => AggroInputManager.IsControllerInStack(this);

	public bool serverHasShiftPaused { get; private set; }

	public ContractScore[] shiftScores => _shiftScores;

	public int Network_syncTrucksCompleted
	{
		get
		{
			return _syncTrucksCompleted;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncTrucksCompleted, 1uL, null);
		}
	}

	public int Network_syncMoney
	{
		get
		{
			return _syncMoney;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncMoney, 2uL, null);
		}
	}

	public float Network_syncSecondsRemaining
	{
		get
		{
			return _syncSecondsRemaining;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncSecondsRemaining, 4uL, null);
		}
	}

	public sbyte Network_syncPlayListIndex
	{
		get
		{
			return _syncPlayListIndex;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncPlayListIndex, 8uL, null);
		}
	}

	public bool Network_syncLockedIn
	{
		get
		{
			return _syncLockedIn;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncLockedIn, 16uL, null);
		}
	}

	protected override void OnEntityCreated()
	{
		_shiftChangeQuery = base.entityManager.CreateObjectQuery<IShiftChanged>();
		try
		{
			if (!breakRoomMusic.IsNull)
			{
				_breakRoomMusicInstance = RuntimeManager.CreateInstance(breakRoomMusic);
			}
			if (!reportMusic.IsNull)
			{
				_reportMusicInstance = RuntimeManager.CreateInstance(reportMusic);
			}
			if (!lockedInMusic.IsNull)
			{
				_lockedInMusicInstance = RuntimeManager.CreateInstance(lockedInMusic);
			}
			_breakRoomMusicInstance.start();
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
		}
		SyncList<OrderCountNet> syncInboundOrders = _syncInboundOrders;
		syncInboundOrders.OnChange = (Action<SyncList<OrderCountNet>.Operation, int, OrderCountNet>)Delegate.Combine(syncInboundOrders.OnChange, new Action<SyncList<OrderCountNet>.Operation, int, OrderCountNet>(OnInboundOrdersChanged));
		if (GameUtil.isTutorial || GameUtil.isGym)
		{
			_shiftPhase = ShiftPhase.Shift;
		}
		else
		{
			_shiftPhase = ShiftPhase.BreakRoom;
		}
		Network_syncTrucksCompleted = 0;
		_currentShift = 1;
		if (SaveManager.isInitialized)
		{
			_startingBellCount = SaveManager.data.GetTotalBells();
		}
		AudioManager.StopLobbyTitleMusic();
		if (!base.isServer)
		{
			base.eventManager.QueueGlobalEvent(default(EvInboundOrdersChanged));
			return;
		}
		_seed = Hash.Calculate(GameUtil.seed, Hash.Calculate(GetType()));
		_serverPlayerCount = NetworkServer.connections.Count;
		if (!GameUtil.isTutorial)
		{
			if (!GameUtil.isGym)
			{
				NetworkAggroManagerBase<PlayersManager>.instance.ServerStartProceed(useTimer: true);
			}
			Network_syncMoney = startingMoney;
			ServerPrepareShift();
			_shopQuery = base.entityManager.CreateObjectQuery<Shop>();
			_grabbersQuery = base.entityManager.CreateObjectQuery<PlayerGrabber>();
			NetworkAggroManagerBase<VoiceOverManager>.instance.ServerPlayInitialBreakRoom();
		}
	}

	public override void OnStartServer()
	{
		if (SaveManager.isInitialized)
		{
			Network_syncPlayListIndex = (sbyte)(SaveManager.data.GetContractCount() % GlobalScriptableObject<AudioObject>.instance.contractPlaylists.Length);
		}
		else
		{
			Network_syncPlayListIndex = (sbyte)(GetSeed() % GlobalScriptableObject<AudioObject>.instance.contractPlaylists.Length);
		}
	}

	protected override void OnEntityDestroyed()
	{
		_shiftInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
		_breakRoomMusicInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
		_reportMusicInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
		_shiftInstance.release();
		_breakRoomMusicInstance.release();
		_reportMusicInstance.release();
		_lockedInMusicInstance.release();
	}

	private void OnInboundOrdersChanged(SyncList<OrderCountNet>.Operation op, int index, OrderCountNet value)
	{
		base.eventManager.QueueGlobalEvent(default(EvInboundOrdersChanged));
	}

	protected override void OnEntityStart()
	{
		if (SaveManager.isInitialized)
		{
			SaveManager.data.IncrementContractCount();
		}
		if (!base.isServer)
		{
			return;
		}
		if (GameUtil.isTutorial)
		{
			ShiftChanged(ShiftPhase.Shift, 0, 0);
			return;
		}
		_shopQuery.Run();
		for (int i = 0; i < _shopQuery.count; i++)
		{
			_shopQuery[i].ServerGenerateShopStock();
		}
		if (GameUtil.isGym)
		{
			ShiftChanged(ShiftPhase.Shift, 1, _trucksThisShift);
		}
		else
		{
			ShiftChanged(ShiftPhase.BreakRoom, 1, _trucksThisShift);
		}
	}

	public ShiftPhase GetShiftPhase()
	{
		return _shiftPhase;
	}

	public int GetTrucksCompleted()
	{
		return _syncTrucksCompleted;
	}

	[Server]
	public void ServerTruckCompleted(Vector3 position, float timerNormalized, int boxCount, int damageCount, int wildCardCount, int explosiveCount, int animalCount)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ShiftManager::ServerTruckCompleted(UnityEngine.Vector3,System.Single,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32)' called when server was not active");
			return;
		}
		Network_syncTrucksCompleted = _syncTrucksCompleted + 1;
		bool wasEarlySend = timerNormalized >= (float)truckBonuses[truckBonuses.Length - 1].timePercentage / 100f;
		CalculateMonies(boxCount, wildCardCount, damageCount, timerNormalized, _serverPayPerBox, out var moneyMade, out var basePay, out var timerPay, out var damageDock);
		if (!GameUtil.isTutorial)
		{
			RpcBoxesShipped((short)moneyMade, (short)basePay, (short)timerPay, (short)damageDock, (byte)(boxCount - wildCardCount), (byte)wildCardCount, (byte)explosiveCount, (byte)animalCount, (byte)damageCount, wasEarlySend);
			Network_syncMoney = _syncMoney + moneyMade;
			float rawScore;
			float num = CalculateScore(boxCount, damageCount, timerNormalized, GetScoreMultiplier(_serverPlayerCount), out rawScore);
			_serverShiftScore += num;
			_serverShiftMaxScore += truckBonuses[truckBonuses.Length - 1].scoreValue;
		}
		if (!_serverFailed)
		{
			_serverLastPosition = position;
		}
	}

	private void TestShip()
	{
		CalculateMonies(testBoxCount + testWildCardCount, testWildCardCount, testDamageCount, testTimerNormalized, testBoxPayout, out var moneyMade, out var basePay, out var timerPay, out var damageDock);
		float rawScore;
		float num = CalculateScore(testBoxCount + testWildCardCount, testDamageCount, testTimerNormalized, GetScoreMultiplier(testPlayerCount), out rawScore);
		Debug.Log($"Money Made: {moneyMade} Base Pay: {basePay} Timer: {timerPay} Dmg Pay: {damageDock} RawScore: {rawScore} Score: {num}");
	}

	private void CalculateMonies(int boxCount, int wildCardCount, int damageCount, float timerNormalized, int payPerBox, out int moneyMade, out int basePay, out int timerPay, out int damageDock)
	{
		basePay = payPerBox * (boxCount - wildCardCount);
		damageDock = damageCount * Mathf.RoundToInt(MathUtil.FloorToIncrement((float)(payPerBox * truckDamageBoxDockPercentage) / 100f, 1f));
		int num = basePay + damageDock;
		int num2 = 0;
		for (int i = 0; i < truckBonuses.Length; i++)
		{
			TimerBonus timerBonus = truckBonuses[i];
			if (!(timerNormalized >= (float)timerBonus.timePercentage / 100f))
			{
				break;
			}
			num2 = timerBonus.payoutPercentage;
		}
		timerPay = Mathf.RoundToInt(MathUtil.RoundToIncrement((float)(num * num2) / 100f, 1f));
		timerPay = Mathf.Max(timerPay, -num);
		moneyMade = num + timerPay;
	}

	private float CalculateScore(int boxCount, int damageCount, float timerNormalized, float playerMultiplier, out float rawScore)
	{
		float num = 0f;
		float num2 = 0f;
		for (int i = 0; i < truckBonuses.Length; i++)
		{
			TimerBonus timerBonus = truckBonuses[i];
			if (!(timerNormalized >= (float)timerBonus.timePercentage / 100f))
			{
				break;
			}
			num = timerBonus.scoreValue;
			if (i > 0)
			{
				num2 = truckBonuses[i - 1].scoreValue;
			}
		}
		float num3 = num - num2;
		float num4 = num2;
		num3 *= (float)(boxCount - damageCount) / (float)boxCount;
		rawScore = num4 + num3;
		float x = rawScore * playerMultiplier;
		x = math.min(x, truckBonuses[truckBonuses.Length - 1].scoreValue);
		if (Debug.isDebugBuild && Application.isPlaying)
		{
			string item = $"Truck Sent - Timer: {timerNormalized * 100f:F1}% Boxes: {boxCount} Damaged: {damageCount} RawScore: {rawScore:F2} FinalScore: {x:F2}";
			_devScoreShiftResults.Add(item);
		}
		return x;
	}

	[Server]
	public void ServerFailRun(Vector3 position)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ShiftManager::ServerFailRun(UnityEngine.Vector3)' called when server was not active");
			return;
		}
		_serverFailed = true;
		_serverLastPosition = position;
	}

	public int GetOutboundsTotalThisShift()
	{
		return _trucksThisShift;
	}

	public int GetCurrentShift()
	{
		return _currentShift;
	}

	public int GetMoney()
	{
		return _syncMoney;
	}

	public void GetInboundOrderCounts(List<OrderCount> counts)
	{
		for (int i = 0; i < _syncInboundOrders.Count; i++)
		{
			OrderCount item = default(OrderCount);
			OrderCountNet orderCountNet = _syncInboundOrders[i];
			if (NetworkClient.GetPrefab(orderCountNet.assetId, out var prefab) && NetworkAggroManagerBase<WarehouseManager>.instance.TryGetOrderObject(prefab, out item.order))
			{
				item.count = orderCountNet.count;
				counts.Add(item);
			}
		}
	}

	[Server]
	public void ServerAddMoney(int amount)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ShiftManager::ServerAddMoney(System.Int32)' called when server was not active");
			return;
		}
		RpcMoneyAdded(amount);
		Network_syncMoney = math.max(_syncMoney + amount, 0);
	}

	[ClientRpc]
	private void RpcMoneyAdded(int amount)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(amount);
		SendRPCInternal("System.Void ShiftManager::RpcMoneyAdded(System.Int32)", 1245850438, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcBoxesShipped(short moneyMade, short basePay, short timerPay, short damagePay, byte boxCount, byte wildCardCount, byte explosiveCount, byte animalCount, byte damageCount, bool wasEarlySend)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteShort(moneyMade);
		writer.WriteShort(basePay);
		writer.WriteShort(timerPay);
		writer.WriteShort(damagePay);
		NetworkWriterExtensions.WriteByte(writer, boxCount);
		NetworkWriterExtensions.WriteByte(writer, wildCardCount);
		NetworkWriterExtensions.WriteByte(writer, explosiveCount);
		NetworkWriterExtensions.WriteByte(writer, animalCount);
		NetworkWriterExtensions.WriteByte(writer, damageCount);
		writer.WriteBool(wasEarlySend);
		SendRPCInternal("System.Void ShiftManager::RpcBoxesShipped(System.Int16,System.Int16,System.Int16,System.Int16,System.Byte,System.Byte,System.Byte,System.Byte,System.Byte,System.Boolean)", 232406731, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	public void ServerEndOrganizationalPeriod()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ShiftManager::ServerEndOrganizationalPeriod()' called when server was not active");
		}
		else if (_shiftPhase == ShiftPhase.Organizational)
		{
			_serverTimer.Clear();
		}
	}

	[Server]
	public float ServerGetStrikeOutDuration()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Single ShiftManager::ServerGetStrikeOutDuration()' called when server was not active");
			return default(float);
		}
		return _serverStrikeOutDuration;
	}

	protected override void OnUpdateSimulation()
	{
		if (!_sentHoarderAchievement && _syncMoney >= achievementHoarderAmount)
		{
			_sentHoarderAchievement = true;
			Aggro.Core.Platform.UnlockAchievement("ach_hoarder");
		}
		_lockedInMusicInstance.getPlaybackState(out var state);
		if (_syncLockedIn && state != PLAYBACK_STATE.PLAYING && state != PLAYBACK_STATE.STARTING)
		{
			_lockedInMusicInstance.start();
		}
		if (!_syncLockedIn && state != PLAYBACK_STATE.STOPPING && state != PLAYBACK_STATE.STOPPED)
		{
			_lockedInMusicInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
		}
		if (!base.isServer)
		{
			return;
		}
		_serverLockedInTimer.DecrementTimer();
		if (_shiftPhase != ShiftPhase.BreakRoom && _shiftPhase != ShiftPhase.Organizational && _shiftPhase != ShiftPhase.Shift && _transitioning)
		{
			_serverLockedInTimer.Clear();
		}
		Network_syncLockedIn = !_serverLockedInTimer.IsFinished();
		if (_transitioning)
		{
			return;
		}
		Unity.Mathematics.Random random = MathUtil.GetRandom(_seed, _currentShift, (int)_shiftPhase);
		switch (_shiftPhase)
		{
		case ShiftPhase.BreakRoom:
			if (NetworkAggroManagerBase<PlayersManager>.instance.ServerProcessProceed())
			{
				StartCoroutine(TransitionBreakRoomToShiftCo(random.NextInt()));
			}
			break;
		case ShiftPhase.Organizational:
			if (!serverTimersPaused)
			{
				_serverTimer.DecrementTimer();
			}
			if (_serverTimer.IsFinished())
			{
				_shiftPhase = ShiftPhase.Shift;
				serverHasShiftPaused = false;
				NetworkAggroManagerBase<VoiceOverManager>.instance.ServerShiftStart();
				ServerSendShiftMessageToAll();
			}
			break;
		case ShiftPhase.Shift:
			_serverPauseTimer.DecrementTimer();
			_serverShiftFrames++;
			if (_serverFailed)
			{
				_shiftPhase = ShiftPhase.Failed;
				StartCoroutine(TransitionShiftToQuotaLost(random.NextInt()));
			}
			else if (_syncTrucksCompleted >= _trucksThisShift && !GameUtil.isTutorial && !GameUtil.isGym)
			{
				if (_currentShift >= 5)
				{
					StartCoroutine(TransitionShiftToGameWon(random.NextInt()));
				}
				else
				{
					StartCoroutine(TransitionShiftToShiftWon(random.NextInt()));
				}
			}
			break;
		default:
			throw new InvalidEnumException();
		case ShiftPhase.None:
		case ShiftPhase.Failed:
			break;
		}
	}

	private IEnumerator TransitionBreakRoomToShiftCo(int seed)
	{
		_transitioning = true;
		RpcTransitionBreakRoomToFade();
		yield return NetworkAggroManagerBase<PlayersManager>.instance.ServerPlayerProceedReadyCo(useTimer: false);
		GameUtil.ServerTeleportPlayers(RoomType.Warehouse, seed);
		yield return null;
		_grabbersQuery.Run();
		_shiftPhase = ShiftPhase.Organizational;
		_serverTimer.SetTimer(organizationalDuration);
		ServerSendShiftMessageToAll();
		yield return new WaitForSeconds(cleanUpWaitDuration);
		RpcTransitionFadeToShift();
		if (_currentShift == 1)
		{
			NetworkAggroManagerBase<VoiceOverManager>.instance.ServerOrganizationStartInitial();
		}
		else
		{
			NetworkAggroManagerBase<VoiceOverManager>.instance.ServerOrganizationStart();
		}
		_transitioning = false;
	}

	private IEnumerator TransitionShiftToShiftWon(int seed)
	{
		_transitioning = true;
		NetworkAggroManagerBase<VoiceOverManager>.instance.ServerShiftWon();
		ContractScore contractScore;
		if (!_debugScore.HasValue)
		{
			contractScore = GetScore(_serverShiftScore / _serverShiftMaxScore);
			PrintShiftScore(contractScore);
		}
		else
		{
			contractScore = _debugScore.Value;
			_debugScore = null;
		}
		_serverShiftScore = 0f;
		_serverShiftMaxScore = 0f;
		if (_currentShift == 1 || _currentShift == 3)
		{
			RpcTransitionShiftToShiftWonPhase1((byte)_currentShift, contractScore, _serverLastPosition);
			yield return NetworkAggroManagerBase<PlayersManager>.instance.ServerPlayerProceedReadyCo(useTimer: false);
			yield return NetworkAggroManagerBase<ModifierManager>.instance.ServerSelectModifierCo();
			RpcTransitionShiftToShiftWonPhase2((byte)_currentShift);
			yield return NetworkAggroManagerBase<PlayersManager>.instance.ServerPlayerProceedReadyCo(useTimer: false);
			NetworkAggroManagerBase<ModifierManager>.instance.ServerAlertModifierChanged();
		}
		else
		{
			RpcTransitionShiftToShiftWon((byte)_currentShift, contractScore, _serverLastPosition);
			yield return NetworkAggroManagerBase<PlayersManager>.instance.ServerPlayerProceedReadyCo(useTimer: false);
		}
		GameUtil.ServerPlayersResetState();
		while (!GameUtil.ServerPlayersGrabbersEmpty())
		{
			yield return null;
		}
		yield return new WaitForFixedUpdate();
		yield return new WaitForSeconds(0.1f);
		_shiftPhase = ShiftPhase.BreakRoom;
		_currentShift++;
		ServerPrepareShift();
		Network_syncTrucksCompleted = 0;
		_serverPauseTimer.Clear();
		GameUtil.ServerTeleportPlayers(RoomType.BreakRoom, seed);
		yield return null;
		ServerSendShiftMessageToAll();
		List<PredictedRigidbodyGroup> list = new List<PredictedRigidbodyGroup>();
		base.entityManager.GetAllObjects(list);
		for (int i = 0; i < list.Count; i++)
		{
			list[i].ServerSnap();
		}
		RpcProceed();
		yield return NetworkAggroManagerBase<PlayersManager>.instance.ServerPlayerProceedReadyCo(useTimer: false);
		NetworkAggroManagerBase<PlayersManager>.instance.ServerStartProceed(useTimer: true);
		_shopQuery.Run();
		for (int j = 0; j < _shopQuery.count; j++)
		{
			_shopQuery[j].ServerGenerateShopStock();
		}
		yield return new WaitForSeconds(cleanUpWaitDuration);
		RpcTransitionFadeToBreakRoom();
		NetworkAggroManagerBase<VoiceOverManager>.instance.ServerPlayBreakRoom();
		_transitioning = false;
	}

	[ClientRpc]
	private void RpcProceed()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void ShiftManager::RpcProceed()", 1581742415, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private IEnumerator TransitionShiftToGameWon(int seed)
	{
		_transitioning = true;
		NetworkAggroManagerBase<VoiceOverManager>.instance.ServerGameWon();
		if (!NetworkAggroManagerBase<AutoPlayManager>.instance.autoPlaying)
		{
			yield return ServerCollectPlayerResults();
			ContractScore contractScore;
			if (!_debugScore.HasValue)
			{
				contractScore = GetScore(_serverShiftScore / _serverShiftMaxScore);
			}
			else
			{
				contractScore = _debugScore.Value;
				_debugScore = null;
			}
			if (Debug.isDebugBuild)
			{
				PrintShiftScore(contractScore);
			}
			_shiftScores[_shiftScores.Length - 1] = contractScore;
			float num = 0f;
			for (int i = 0; i < _shiftScores.Length; i++)
			{
				num += (float)(int)_shiftScores[i];
			}
			ContractScore contractScore2;
			if (num == (float)(_shiftScores.Length * 4))
			{
				contractScore2 = ContractScore.S;
			}
			else
			{
				contractScore2 = (ContractScore)Mathf.RoundToInt(num / (float)_shiftScores.Length);
				contractScore2 = (ContractScore)math.min((int)contractScore2, 3);
			}
			if (Debug.isDebugBuild)
			{
				Debug.Log($"Final Score {contractScore2} - Total Points: {num:F2} Shift Avg: {num / (float)_shiftScores.Length:F2}");
			}
			RpcTransitionShiftToGameWon((byte)_currentShift, contractScore2, contractScore, (int)((double)(_serverShiftFrames * 1000) * (1.0 / 60.0)), _serverLastPosition, _serverPlayerResults);
			yield return NetworkAggroManagerBase<PlayersManager>.instance.ServerPlayerProceedReadyCo(useTimer: true);
			yield return new WaitForSeconds(cleanUpWaitDuration);
		}
		RpcTransitionToLobby();
		GameManager.Next(GameNextType.ServerLobby);
	}

	private ContractScore GetScore(float scorePercentage)
	{
		for (int i = 0; i < scoreLetterGradeMaxRange.Length; i++)
		{
			if (scorePercentage <= (float)scoreLetterGradeMaxRange[i] / 100f)
			{
				return (ContractScore)i;
			}
		}
		return ContractScore.S;
	}

	private void PrintShiftScore(ContractScore shiftScore)
	{
		if (Debug.isDebugBuild)
		{
			string text = $"Shift Score: {shiftScore} Percentage: {_serverShiftScore / _serverShiftMaxScore * 100f:F1}%\n";
			for (int i = 0; i < _devScoreShiftResults.Count; i++)
			{
				text = text + "  " + _devScoreShiftResults[i] + "\n";
			}
			Debug.Log(text);
			_devScoreShiftResults.Clear();
		}
	}

	private IEnumerator TransitionShiftToQuotaLost(int seed)
	{
		_transitioning = true;
		NetworkAggroManagerBase<VoiceOverManager>.instance.ServerShiftLost();
		if (!NetworkAggroManagerBase<AutoPlayManager>.instance.autoPlaying)
		{
			yield return ServerCollectPlayerResults();
			RpcTransitionShiftToGameLost((byte)_currentShift, (int)((double)(_serverShiftFrames * 1000) * (1.0 / 60.0)), _serverLastPosition, _serverPlayerResults);
			yield return NetworkAggroManagerBase<PlayersManager>.instance.ServerPlayerProceedReadyCo(useTimer: true);
			yield return new WaitForSeconds(cleanUpWaitDuration);
		}
		RpcTransitionToLobby();
		GameManager.Next(GameNextType.ServerLobby);
	}

	private IEnumerator ServerCollectPlayerResults()
	{
		List<NetworkConnectionToClient> list = new List<NetworkConnectionToClient>(NetworkServer.connections.Values);
		list.Sort((NetworkConnectionToClient x, NetworkConnectionToClient y) => x.connectionId.CompareTo(y.connectionId));
		_serverPlayerResults = new PlayerResult[list.Count];
		for (int num = 0; num < list.Count; num++)
		{
			RpcRequestPlayerResults(list[num], (byte)num);
		}
		yield return NetworkAggroManagerBase<PlayersManager>.instance.ServerPlayerProceedReadyCo(useTimer: false);
	}

	protected override void OnUpdatePresentation()
	{
		if (_shiftPhase == ShiftPhase.BreakRoom)
		{
			_breakRoomMusicInstance.setParameterByName("confirm-hold-BR", NetworkAggroManagerBase<PlayersManager>.instance.GetNormalizedProceedValue());
		}
		if (base.isServer && _shiftPhase == ShiftPhase.Organizational)
		{
			Network_syncSecondsRemaining = _serverTimer.GetSecondsRemaining();
		}
	}

	[Server]
	private void ServerSendShiftMessageToAll()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ShiftManager::ServerSendShiftMessageToAll()' called when server was not active");
		}
		else
		{
			RpcShiftChangedAll(_shiftPhase, _currentShift, _trucksThisShift);
		}
	}

	[ClientRpc]
	private void RpcShiftChangedAll(ShiftPhase phase, int shift, int outboundsRequired)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_ShiftPhase(writer, phase);
		writer.WriteVarInt(shift);
		writer.WriteVarInt(outboundsRequired);
		SendRPCInternal("System.Void ShiftManager::RpcShiftChangedAll(ShiftPhase,System.Int32,System.Int32)", -2064854099, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcTransitionBreakRoomToFade()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void ShiftManager::RpcTransitionBreakRoomToFade()", -1513487917, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private IEnumerator ClientTransitionBreakRoomToFadeCo()
	{
		AggroManagerBase<GameMenuUI>.instance.Close();
		AggroInputManager.PushController(this);
		yield return FadeManager.FadeInCo();
		yield return new WaitForTask(SaveManager.SaveGameAsync());
		_breakRoomMusicInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
		AudioObject.ContractPlaylist contractPlaylist = GlobalScriptableObject<AudioObject>.instance.contractPlaylists[_syncPlayListIndex];
		EventReference eventReference = contractPlaylist.playlist[math.min(_currentShift, contractPlaylist.playlist.Length) - 1];
		if (_shiftInstance.isValid())
		{
			_shiftInstance.release();
		}
		_shiftInstance = RuntimeManager.CreateInstance(eventReference);
		_shiftInstance.start();
		if (GameUtil.TryGetLocalPlayer(out var player))
		{
			player.GetObject<PlayerStress>().RequestClearStress();
		}
		NetworkAggroManagerBase<PlayersManager>.instance.RequestProceed();
	}

	[ClientRpc]
	private void RpcTransitionFadeToShift()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void ShiftManager::RpcTransitionFadeToShift()", -1613423215, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private IEnumerator ClientTransitionFadeToShiftCo()
	{
		GC.Collect();
		yield return FadeManager.FadeOutCo();
		AggroInputManager.RemoveController(this);
	}

	[ClientRpc]
	private void RpcTransitionShiftToShiftWon(byte shiftCount, ContractScore score, Vector3 lastOutboundPos)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		NetworkWriterExtensions.WriteByte(writer, shiftCount);
		GeneratedNetworkCode._Write_ContractScore(writer, score);
		writer.WriteVector3(lastOutboundPos);
		SendRPCInternal("System.Void ShiftManager::RpcTransitionShiftToShiftWon(System.Byte,ContractScore,UnityEngine.Vector3)", 244263247, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcTransitionShiftToShiftWonPhase1(byte shiftCount, ContractScore score, Vector3 lastOutboundPos)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		NetworkWriterExtensions.WriteByte(writer, shiftCount);
		GeneratedNetworkCode._Write_ContractScore(writer, score);
		writer.WriteVector3(lastOutboundPos);
		SendRPCInternal("System.Void ShiftManager::RpcTransitionShiftToShiftWonPhase1(System.Byte,ContractScore,UnityEngine.Vector3)", -711043947, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcTransitionShiftToShiftWonPhase2(byte shiftCount)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		NetworkWriterExtensions.WriteByte(writer, shiftCount);
		SendRPCInternal("System.Void ShiftManager::RpcTransitionShiftToShiftWonPhase2(System.Byte)", 1368357045, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private IEnumerator ClientTransitionShiftToShiftWonCo(byte shiftCount, ContractScore score, Vector3 lastOutboundPos)
	{
		yield return ClientShiftWonPhase1Co(shiftCount, score, lastOutboundPos);
		yield return ClientShiftWonPhase2Co(shiftCount);
		NetworkAggroManagerBase<PlayersManager>.instance.RequestProceed();
	}

	private IEnumerator ClientTransitionShiftToShiftWonPhase1Co(byte shiftCount, ContractScore score, Vector3 lastOutboundPos)
	{
		yield return ClientShiftWonPhase1Co(shiftCount, score, lastOutboundPos);
		NetworkAggroManagerBase<PlayersManager>.instance.RequestProceed();
	}

	private IEnumerator ClientTransitionShiftToShiftWonPhase2Co(byte shiftCount)
	{
		yield return ClientShiftWonPhase2Co(shiftCount);
		NetworkAggroManagerBase<PlayersManager>.instance.RequestProceed();
	}

	private IEnumerator ClientShiftWonPhase1Co(byte shiftCount, ContractScore score, Vector3 lastOutboundPos)
	{
		AggroManagerBase<GameMenuUI>.instance.Close();
		AggroInputManager.PushController(this);
		_shiftScores[shiftCount - 1] = score;
		base.eventManager.QueueGlobalEvent(new EvShiftWon(shiftCount, score));
		yield return new WaitForSeconds(shiftFinishedPauseBeforeCameraDuration);
		if (GameUtil.TryGetLocalPlayer(out var player) && player.GetObject<PlayerStress>().shiftCrashOutCount == 0)
		{
			Aggro.Core.Platform.UnlockAchievement("ach_nocrashout_shift");
		}
		Aggro.Core.Platform.FlushStatsAndAchievements();
		yield return AggroManagerBase<CameraController>.instance.SetFocusPositionCo(lastOutboundPos, shiftWonCameraMoveDuration);
		yield return new WaitForSeconds(shiftFinishedWaitAfterCameraDuration);
	}

	private IEnumerator ClientShiftWonPhase2Co(byte bellCount)
	{
		yield return FadeManager.FadeInCo();
		if (GameUtil.contract.type == ContractType.Explicit)
		{
			SaveManager.data.SetContractBellCountIfHigher(GameUtil.contract, bellCount);
		}
		UnlockCostumes(GameUtil.contract, bellCount);
		NetworkAggroManagerBase<TipTapManager>.instance.ShiftCompleted(contractCompleted: false, wonContract: false);
		yield return new WaitForTask(SaveManager.SaveGameAsync());
		CheckSaveFileAchievements();
		AggroManagerBase<CameraController>.instance.FollowPlayer();
	}

	[ClientRpc]
	private void RpcTransitionShiftToGameWon(byte shiftCount, ContractScore score, ContractScore shiftScore, int shiftMilliseconds, Vector3 lastOutboundPos, PlayerResult[] playerResults)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		NetworkWriterExtensions.WriteByte(writer, shiftCount);
		GeneratedNetworkCode._Write_ContractScore(writer, score);
		GeneratedNetworkCode._Write_ContractScore(writer, shiftScore);
		writer.WriteVarInt(shiftMilliseconds);
		writer.WriteVector3(lastOutboundPos);
		GeneratedNetworkCode._Write_PlayerResult_005B_005D(writer, playerResults);
		SendRPCInternal("System.Void ShiftManager::RpcTransitionShiftToGameWon(System.Byte,ContractScore,ContractScore,System.Int32,UnityEngine.Vector3,PlayerResult[])", 2043270580, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private IEnumerator ClientTransitionShiftToGameWonCo(byte bellCount, ContractScore score, ContractScore shiftScore, int shiftMilliseconds, Vector3 lastOutboundPos, PlayerResult[] playerResults)
	{
		AggroManagerBase<GameMenuUI>.instance.Close();
		AggroInputManager.PushController(this);
		_shiftScores[_shiftScores.Length - 1] = shiftScore;
		base.eventManager.QueueGlobalEvent(new EvShiftWon(bellCount, shiftScore));
		yield return new WaitForSeconds(shiftFinishedPauseBeforeCameraDuration);
		yield return AggroManagerBase<CameraController>.instance.SetFocusPositionCo(lastOutboundPos, shiftWonCameraMoveDuration);
		yield return new WaitForSeconds(shiftFinishedWaitAfterCameraDuration);
		if (GameUtil.contract.type == ContractType.Explicit)
		{
			SaveManager.data.SetContractBellCount(GameUtil.contract, bellCount);
			SaveManager.data.SetContractScoreIfHigher(GameUtil.contract, score);
			SaveManager.data.SetContractTimeIfHigher(GameUtil.contract, shiftMilliseconds);
		}
		UnlockCostumes(GameUtil.contract, bellCount);
		NetworkAggroManagerBase<TipTapManager>.instance.ShiftCompleted(contractCompleted: true, wonContract: true);
		yield return new WaitForTask(SaveManager.SaveGameAsync());
		CheckSaveFileAchievements();
		_shiftInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
		_reportMusicInstance.start();
		GameUtil.LocalPlayerResetState();
		if (!string.IsNullOrEmpty(NetworkAggroManagerBase<ModifierManager>.instance.modifierAchievement1))
		{
			Aggro.Core.Platform.UnlockAchievement(NetworkAggroManagerBase<ModifierManager>.instance.modifierAchievement1);
		}
		if (!string.IsNullOrEmpty(NetworkAggroManagerBase<ModifierManager>.instance.modifierAchievement2))
		{
			Aggro.Core.Platform.UnlockAchievement(NetworkAggroManagerBase<ModifierManager>.instance.modifierAchievement2);
		}
		if (GameUtil.TryGetLocalPlayer(out var player))
		{
			PlayerStress playerStress = player.GetObject<PlayerStress>();
			if (playerStress.shiftCrashOutCount == 0)
			{
				Aggro.Core.Platform.UnlockAchievement("ach_nocrashout_shift");
			}
			if (playerStress.crashOutCount == 0)
			{
				Aggro.Core.Platform.UnlockAchievement("ach_nocrashout_contract");
			}
		}
		Aggro.Core.Platform.FlushStatsAndAchievements();
		yield return AggroManagerBase<ReportUI>.instance.StartSequenceCo(passed: true, bellCount, GameUtil.contract, score, TimeSpan.FromMilliseconds(shiftMilliseconds), _shiftScores, NetworkAggroManagerBase<ModifierManager>.instance.modifierSeen1, NetworkAggroManagerBase<ModifierManager>.instance.modifierSeen2, NetworkAggroManagerBase<WarehouseManager>.instance.ordersSeen, playerResults, _costumesUnlocked.ToArray(), GetUnlockedContracts());
		_proceeding = true;
		while (_proceeding)
		{
			yield return null;
			if (AggroInputManager.input.QuotaReport.Continue.WasPerformedThisFrame())
			{
				if (NetworkAggroManagerBase<PlayersManager>.instance.GetAmIProceeding())
				{
					NetworkAggroManagerBase<PlayersManager>.instance.RequestCancel();
				}
				else
				{
					NetworkAggroManagerBase<PlayersManager>.instance.RequestProceed();
				}
			}
		}
		yield return FadeManager.FadeInCo();
		AggroManagerBase<CameraController>.instance.FollowPlayer();
		_reportMusicInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
	}

	[ClientRpc]
	private void RpcTransitionShiftToGameLost(byte shiftCount, int shiftMilliseconds, Vector3 lastOutboundPos, PlayerResult[] playerResults)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		NetworkWriterExtensions.WriteByte(writer, shiftCount);
		writer.WriteVarInt(shiftMilliseconds);
		writer.WriteVector3(lastOutboundPos);
		GeneratedNetworkCode._Write_PlayerResult_005B_005D(writer, playerResults);
		SendRPCInternal("System.Void ShiftManager::RpcTransitionShiftToGameLost(System.Byte,System.Int32,UnityEngine.Vector3,PlayerResult[])", 1460777398, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private IEnumerator ClientTransitionShiftToGameLostCo(byte shiftCount, int shiftMilliseconds, Vector3 lastOutboundPos, PlayerResult[] playerResults)
	{
		AggroManagerBase<GameMenuUI>.instance.Close();
		AggroInputManager.PushController(this);
		_shiftInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
		base.eventManager.QueueGlobalEvent(new EvShiftLost(shiftCount));
		yield return new WaitForSeconds(shiftFinishedPauseBeforeCameraDuration);
		yield return AggroManagerBase<CameraController>.instance.SetFocusPositionCo(lastOutboundPos, shiftLostCameraMoveDuration);
		_reportMusicInstance.start();
		yield return new WaitForSeconds(shiftFinishedWaitAfterCameraDuration);
		NetworkAggroManagerBase<TipTapManager>.instance.ShiftCompleted(contractCompleted: true, wonContract: false);
		yield return new WaitForTask(SaveManager.SaveGameAsync());
		GameUtil.LocalPlayerResetState();
		_shiftInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
		yield return AggroManagerBase<ReportUI>.instance.StartSequenceCo(passed: false, shiftCount, GameUtil.contract, ContractScore.D, TimeSpan.FromMilliseconds(shiftMilliseconds), _shiftScores, NetworkAggroManagerBase<ModifierManager>.instance.modifierSeen1, NetworkAggroManagerBase<ModifierManager>.instance.modifierSeen2, NetworkAggroManagerBase<WarehouseManager>.instance.ordersSeen, playerResults, _costumesUnlocked.ToArray(), GetUnlockedContracts());
		_proceeding = true;
		while (_proceeding)
		{
			yield return null;
			if (AggroInputManager.input.QuotaReport.Continue.WasPerformedThisFrame())
			{
				if (NetworkAggroManagerBase<PlayersManager>.instance.GetAmIProceeding())
				{
					NetworkAggroManagerBase<PlayersManager>.instance.RequestCancel();
				}
				else
				{
					NetworkAggroManagerBase<PlayersManager>.instance.RequestProceed();
				}
			}
		}
		yield return FadeManager.FadeInCo();
		AggroManagerBase<CameraController>.instance.FollowPlayer();
		_reportMusicInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
	}

	[ClientRpc]
	private void RpcTransitionFadeToBreakRoom()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void ShiftManager::RpcTransitionFadeToBreakRoom()", -336527555, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private IEnumerator ClientTransitionFadeToBreakRoom()
	{
		_proceeding = false;
		AggroManagerBase<ReportUI>.instance.Hide();
		_shiftInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
		_breakRoomMusicInstance.start();
		GC.Collect();
		yield return FadeManager.FadeOutCo();
		AggroInputManager.RemoveController(this);
	}

	[ClientRpc]
	private void RpcTransitionToLobby()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void ShiftManager::RpcTransitionToLobby()", 1561995255, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void ShiftChanged(ShiftPhase phase, int shift, int outboundsRequired)
	{
		_shiftPhase = phase;
		_currentShift = shift;
		_trucksThisShift = outboundsRequired;
		_shiftChangeQuery.Run();
		for (int i = 0; i < _shiftChangeQuery.count; i++)
		{
			_shiftChangeQuery[i].OnShiftChanged(_shiftPhase, _currentShift, _trucksThisShift);
		}
	}

	[Server]
	public void ServerPauseTimers(float duration, bool setShiftPaused)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ShiftManager::ServerPauseTimers(System.Single,System.Boolean)' called when server was not active");
		}
		else if (_shiftPhase == ShiftPhase.Shift)
		{
			_serverPauseTimer.SetTimerIfGreater(duration);
			if (setShiftPaused)
			{
				serverHasShiftPaused = true;
			}
		}
	}

	[Server]
	public void ServerLockIn(float duration)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ShiftManager::ServerLockIn(System.Single)' called when server was not active");
		}
		else if (_shiftPhase == ShiftPhase.Shift || _shiftPhase == ShiftPhase.Organizational || _shiftPhase == ShiftPhase.BreakRoom)
		{
			_serverLockedInTimer.SetTimer(duration);
		}
	}

	[Server]
	private void ServerPrepareShift()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ShiftManager::ServerPrepareShift()' called when server was not active");
			return;
		}
		NetworkAggroManagerBase<WarehouseManager>.instance.ServerPrepareForShift(_currentShift, out _trucksThisShift, out var numberOfBoxesShipped, out var inboundOrders);
		_syncInboundOrders.Clear();
		for (int i = 0; i < inboundOrders.Length; i++)
		{
			OrderCount orderCount = inboundOrders[i];
			OrderCountNet item = default(OrderCountNet);
			if (orderCount.order.TryGetAssetId(out item.assetId))
			{
				item.count = (byte)orderCount.count;
				_syncInboundOrders.Add(item);
			}
		}
		if (GameUtil.isGym)
		{
			_serverStrikeOutDuration = 300f;
			_serverPayPerBox = 50;
			return;
		}
		ContractShift contractShift = GameUtil.contract.GetContractShift(_currentShift);
		_serverStrikeOutDuration = contractShift.truckPatienceDuration * NetworkAggroManagerBase<ModifierManager>.instance.GetPatienceMultiplier();
		float num = (float)contractShift.payOutAmount * GameUtil.contract.GetPlayerMultiplier(_serverPlayerCount) * NetworkAggroManagerBase<ModifierManager>.instance.GetPayoutMultiplier();
		_serverPayPerBox = Mathf.RoundToInt(MathUtil.RoundToIncrement(num / (float)numberOfBoxesShipped, 2f));
		_serverPayPerBox = Mathf.Max(_serverPayPerBox, 2);
	}

	public void OnInputControlGained()
	{
		AggroInputManager.input.QuotaReport.Enable();
	}

	public void OnInputControlLost()
	{
		AggroInputManager.input.QuotaReport.Disable();
	}

	private ContractObject[] GetUnlockedContracts()
	{
		int totalBells = SaveManager.data.GetTotalBells();
		List<ContractObject> list = new List<ContractObject>();
		List<ContractObject> list2 = new List<ContractObject>();
		GameManager.GetAllUnlockedContracts(_startingBellCount, list);
		GameManager.GetAllUnlockedContracts(totalBells, list2);
		list2.RemoveRange(0, list.Count);
		for (int num = list2.Count - 1; num >= 0; num--)
		{
			if (list2[num].type == ContractType.Random)
			{
				list2.RemoveAt(num);
			}
		}
		return list2.ToArray();
	}

	private void UnlockCostumes(ContractObject contract, int bellCount)
	{
		List<CostumeObject> list = new List<CostumeObject>();
		for (int i = 0; i < contract.unlocks.Length; i++)
		{
			ContractObject.Unlock unlock = contract.unlocks[i];
			if ((object)unlock.costume != null && unlock.bellsRequired <= bellCount && !SaveManager.data.IsCostumeUnlocked(unlock.costume))
			{
				SaveManager.data.UnlockCostume(unlock.costume);
				_costumesUnlocked.Add(unlock.costume);
				list.Add(unlock.costume);
			}
		}
	}

	private float GetScoreMultiplier(int playerCount)
	{
		return playerCount switch
		{
			1 => scoreMultiplierOnePlayer, 
			2 => scoreMultiplierTwoPlayers, 
			3 => scoreMultiplierThreePlayers, 
			_ => 1f, 
		};
	}

	[TargetRpc]
	private void RpcRequestPlayerResults(NetworkConnectionToClient target, byte playerIndex)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		NetworkWriterExtensions.WriteByte(writer, playerIndex);
		SendTargetRPCInternal(target, "System.Void ShiftManager::RpcRequestPlayerResults(Mirror.NetworkConnectionToClient,System.Byte)", -1329523951, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdPlayerResults(byte playerIndex, PlayerResult result)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		NetworkWriterExtensions.WriteByte(writer, playerIndex);
		GeneratedNetworkCode._Write_PlayerResult(writer, result);
		SendCommandInternal("System.Void ShiftManager::CmdPlayerResults(System.Byte,PlayerResult)", -1280848806, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	private void CheckSaveFileAchievements()
	{
		int totalBells = SaveManager.data.GetTotalBells();
		ContractObject[] allContracts = GameManager.GetAllContracts();
		if (totalBells >= achievementSomeBellsAmount)
		{
			Aggro.Core.Platform.UnlockAchievement("ach_bells_50");
		}
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		foreach (ContractObject contractObject in allContracts)
		{
			if (contractObject.type == ContractType.DemoLocked)
			{
				continue;
			}
			num++;
			if (contractObject.bellsRequired <= totalBells)
			{
				num3++;
			}
			if (contractObject.type == ContractType.Explicit)
			{
				num2++;
				if (SaveManager.data.TryGetContractScore(contractObject, out var score) && score == ContractScore.S)
				{
					num4++;
				}
			}
		}
		if (totalBells >= num2 * 5)
		{
			Aggro.Core.Platform.UnlockAchievement("ach_bells_all");
		}
		if (SaveManager.data.GetUnlockedCostumes().Length >= GlobalScriptableObject<CosmeticGlobalData>.instance.costumes.Length)
		{
			Aggro.Core.Platform.UnlockAchievement("ach_unlocked_all_costumes");
		}
		if (num3 >= num)
		{
			Aggro.Core.Platform.UnlockAchievement("ach_unlocked_all_contracts");
		}
		if (num4 > 0)
		{
			Aggro.Core.Platform.UnlockAchievement("ach_srank_first");
		}
		if (num4 == num2)
		{
			Aggro.Core.Platform.UnlockAchievement("ach_srank_last");
		}
	}

	[DevCmd("shift", "Interact with the shift and quotas.\r\n\r\nUsage:\r\n    shift -next\r\n        Forces the shift to start or the organization period to end.\r\n\r\n    shift -pause\r\n        Toggles pausing the shift timer.\r\n\r\n    shift -win <D|C|B|A|S>\r\n        Forces the current shift to end in a win.\r\n\r\n    shift -lose\r\n        Forces the current shift to end in a loss.\r\n\r\n    shift -outbound\r\n        Forces the next outbound to arrive immediately.\r\n\r\n    shift -inbound\r\n        Forces the next inbound to arrive immediately.\r\n\r\n    shift -money <amount>\r\n        Sets the current money to the supplied amount.", new string[] { "next", "pause", "win", "lose", "outbound", "inbound", "money" })]
	[DevCmdComplete("win", DevCmdCompleteFlags.ValueCaseInsensitive, typeof(ContractScore))]
	[DevCmdVerify("^-next$")]
	[DevCmdVerify("^-pause$")]
	[DevCmdVerify("^-win [DCBASdcbas]$")]
	[DevCmdVerify("^-lose$")]
	[DevCmdVerify("^-outbound$")]
	[DevCmdVerify("^-inbound$")]
	[DevCmdVerify("^-money [0-9]+$")]
	private static void ShiftDevCmd(DevCmdArg[] args)
	{
		if (GameUtil.isLobby && args[0].name == "next")
		{
			NetworkAggroManagerBase<LobbyManager>.instance.DevCmdStartWarehouse();
			return;
		}
		if (NetworkAggroManagerBase<ShiftManager>.instance == null)
		{
			Debug.LogWarning("ShiftManager instance not set!");
			return;
		}
		switch (args[0].name)
		{
		case "next":
			NetworkAggroManagerBase<ShiftManager>.instance.CmdShiftDevCmdNext();
			break;
		case "pause":
			NetworkAggroManagerBase<ShiftManager>.instance.CmdShiftDevCmdPauseToggle();
			break;
		case "win":
		{
			if (!Enum.TryParse<ContractScore>(args[0].value, ignoreCase: true, out var result2))
			{
				Debug.LogWarning("Invalid score: " + args[0].value);
			}
			else
			{
				NetworkAggroManagerBase<ShiftManager>.instance.CmdShiftDevCmdWinShift(result2);
			}
			break;
		}
		case "lose":
			NetworkAggroManagerBase<ShiftManager>.instance.CmdShiftDevCmdLoseShift();
			break;
		case "outbound":
			NetworkAggroManagerBase<ShiftManager>.instance.CmdShiftOutboundDevCmd();
			break;
		case "inbound":
			NetworkAggroManagerBase<ShiftManager>.instance.CmdShiftInboundDevCmd();
			break;
		case "money":
		{
			if (int.TryParse(args[0].value, out var result))
			{
				NetworkAggroManagerBase<ShiftManager>.instance.CmdShiftDevCmdMoneyAdd(result);
			}
			else
			{
				Debug.LogWarning("Unable to parse money amount! " + args[0].value);
			}
			break;
		}
		default:
			Debug.LogWarning("Unknown argument " + args[0].name);
			break;
		}
	}

	[Server]
	public void ServerForceShiftForward()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ShiftManager::ServerForceShiftForward()' called when server was not active");
		}
		else
		{
			CmdShiftDevCmdNext();
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdShiftDevCmdNext()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void ShiftManager::CmdShiftDevCmdNext()", -248889396, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdShiftDevCmdWinShift(ContractScore score)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_ContractScore(writer, score);
		SendCommandInternal("System.Void ShiftManager::CmdShiftDevCmdWinShift(ContractScore)", -1454288237, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdShiftDevCmdLoseShift()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void ShiftManager::CmdShiftDevCmdLoseShift()", 689735070, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdShiftOutboundDevCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void ShiftManager::CmdShiftOutboundDevCmd()", -1125680907, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdShiftInboundDevCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void ShiftManager::CmdShiftInboundDevCmd()", 1662772434, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdShiftDevCmdMoneyAdd(int amount)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(amount);
		SendCommandInternal("System.Void ShiftManager::CmdShiftDevCmdMoneyAdd(System.Int32)", 1493577531, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdShiftDevCmdPauseToggle()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void ShiftManager::CmdShiftDevCmdPauseToggle()", 500640731, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	public ShiftManager()
	{
		InitSyncObject(_syncInboundOrders);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_RpcMoneyAdded__Int32(int amount)
	{
		EvMoneyTransaction ev = new EvMoneyTransaction
		{
			amount = amount
		};
		base.eventManager.QueueGlobalEvent(ev);
	}

	protected static void InvokeUserCode_RpcMoneyAdded__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcMoneyAdded called on server.");
		}
		else
		{
			((ShiftManager)obj).UserCode_RpcMoneyAdded__Int32(reader.ReadVarInt());
		}
	}

	protected void UserCode_RpcBoxesShipped__Int16__Int16__Int16__Int16__Byte__Byte__Byte__Byte__Byte__Boolean(short moneyMade, short basePay, short timerPay, short damagePay, byte boxCount, byte wildCardCount, byte explosiveCount, byte animalCount, byte damageCount, bool wasEarlySend)
	{
		Aggro.Core.Platform.AddStat("stat_shipped_boxes", boxCount + wildCardCount);
		if (explosiveCount > 0)
		{
			Aggro.Core.Platform.AddStat("stat_shipped_explosives", explosiveCount);
		}
		if (animalCount > 0)
		{
			Aggro.Core.Platform.AddStat("stat_shipped_animals", animalCount);
		}
		if (wasEarlySend)
		{
			Aggro.Core.Platform.AddStat("stat_bonus_shipped", 1);
		}
		EvTruckShipped ev = new EvTruckShipped
		{
			moneyMade = moneyMade,
			basePay = basePay,
			timerPay = timerPay,
			damagePay = damagePay,
			boxCount = boxCount,
			wildCardCount = wildCardCount,
			damageCount = damageCount
		};
		base.eventManager.QueueGlobalEvent(ev);
	}

	protected static void InvokeUserCode_RpcBoxesShipped__Int16__Int16__Int16__Int16__Byte__Byte__Byte__Byte__Byte__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcBoxesShipped called on server.");
		}
		else
		{
			((ShiftManager)obj).UserCode_RpcBoxesShipped__Int16__Int16__Int16__Int16__Byte__Byte__Byte__Byte__Byte__Boolean(reader.ReadShort(), reader.ReadShort(), reader.ReadShort(), reader.ReadShort(), NetworkReaderExtensions.ReadByte(reader), NetworkReaderExtensions.ReadByte(reader), NetworkReaderExtensions.ReadByte(reader), NetworkReaderExtensions.ReadByte(reader), NetworkReaderExtensions.ReadByte(reader), reader.ReadBool());
		}
	}

	protected void UserCode_RpcProceed()
	{
		NetworkAggroManagerBase<PlayersManager>.instance.RequestProceed();
	}

	protected static void InvokeUserCode_RpcProceed(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcProceed called on server.");
		}
		else
		{
			((ShiftManager)obj).UserCode_RpcProceed();
		}
	}

	protected void UserCode_RpcShiftChangedAll__ShiftPhase__Int32__Int32(ShiftPhase phase, int shift, int outboundsRequired)
	{
		switch (phase)
		{
		case ShiftPhase.Organizational:
			_shiftInstance.setParameterByName("start", 0f);
			base.eventManager.QueueGlobalEvent(default(EvOrganizationPeriodStart));
			break;
		case ShiftPhase.Shift:
			_shiftInstance.setParameterByName("start", 1f);
			base.eventManager.QueueGlobalEvent(default(EvShiftStart));
			break;
		}
		ShiftChanged(phase, shift, outboundsRequired);
	}

	protected static void InvokeUserCode_RpcShiftChangedAll__ShiftPhase__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcShiftChangedAll called on server.");
		}
		else
		{
			((ShiftManager)obj).UserCode_RpcShiftChangedAll__ShiftPhase__Int32__Int32(GeneratedNetworkCode._Read_ShiftPhase(reader), reader.ReadVarInt(), reader.ReadVarInt());
		}
	}

	protected void UserCode_RpcTransitionBreakRoomToFade()
	{
		StartCoroutine(ClientTransitionBreakRoomToFadeCo());
	}

	protected static void InvokeUserCode_RpcTransitionBreakRoomToFade(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcTransitionBreakRoomToFade called on server.");
		}
		else
		{
			((ShiftManager)obj).UserCode_RpcTransitionBreakRoomToFade();
		}
	}

	protected void UserCode_RpcTransitionFadeToShift()
	{
		StartCoroutine(ClientTransitionFadeToShiftCo());
	}

	protected static void InvokeUserCode_RpcTransitionFadeToShift(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcTransitionFadeToShift called on server.");
		}
		else
		{
			((ShiftManager)obj).UserCode_RpcTransitionFadeToShift();
		}
	}

	protected void UserCode_RpcTransitionShiftToShiftWon__Byte__ContractScore__Vector3(byte shiftCount, ContractScore score, Vector3 lastOutboundPos)
	{
		StartCoroutine(ClientTransitionShiftToShiftWonCo(shiftCount, score, lastOutboundPos));
	}

	protected static void InvokeUserCode_RpcTransitionShiftToShiftWon__Byte__ContractScore__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcTransitionShiftToShiftWon called on server.");
		}
		else
		{
			((ShiftManager)obj).UserCode_RpcTransitionShiftToShiftWon__Byte__ContractScore__Vector3(NetworkReaderExtensions.ReadByte(reader), GeneratedNetworkCode._Read_ContractScore(reader), reader.ReadVector3());
		}
	}

	protected void UserCode_RpcTransitionShiftToShiftWonPhase1__Byte__ContractScore__Vector3(byte shiftCount, ContractScore score, Vector3 lastOutboundPos)
	{
		StartCoroutine(ClientTransitionShiftToShiftWonPhase1Co(shiftCount, score, lastOutboundPos));
	}

	protected static void InvokeUserCode_RpcTransitionShiftToShiftWonPhase1__Byte__ContractScore__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcTransitionShiftToShiftWonPhase1 called on server.");
		}
		else
		{
			((ShiftManager)obj).UserCode_RpcTransitionShiftToShiftWonPhase1__Byte__ContractScore__Vector3(NetworkReaderExtensions.ReadByte(reader), GeneratedNetworkCode._Read_ContractScore(reader), reader.ReadVector3());
		}
	}

	protected void UserCode_RpcTransitionShiftToShiftWonPhase2__Byte(byte shiftCount)
	{
		StartCoroutine(ClientTransitionShiftToShiftWonPhase2Co(shiftCount));
	}

	protected static void InvokeUserCode_RpcTransitionShiftToShiftWonPhase2__Byte(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcTransitionShiftToShiftWonPhase2 called on server.");
		}
		else
		{
			((ShiftManager)obj).UserCode_RpcTransitionShiftToShiftWonPhase2__Byte(NetworkReaderExtensions.ReadByte(reader));
		}
	}

	protected void UserCode_RpcTransitionShiftToGameWon__Byte__ContractScore__ContractScore__Int32__Vector3__PlayerResult_005B_005D(byte shiftCount, ContractScore score, ContractScore shiftScore, int shiftMilliseconds, Vector3 lastOutboundPos, PlayerResult[] playerResults)
	{
		StartCoroutine(ClientTransitionShiftToGameWonCo(shiftCount, score, shiftScore, shiftMilliseconds, lastOutboundPos, playerResults));
	}

	protected static void InvokeUserCode_RpcTransitionShiftToGameWon__Byte__ContractScore__ContractScore__Int32__Vector3__PlayerResult_005B_005D(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcTransitionShiftToGameWon called on server.");
		}
		else
		{
			((ShiftManager)obj).UserCode_RpcTransitionShiftToGameWon__Byte__ContractScore__ContractScore__Int32__Vector3__PlayerResult_005B_005D(NetworkReaderExtensions.ReadByte(reader), GeneratedNetworkCode._Read_ContractScore(reader), GeneratedNetworkCode._Read_ContractScore(reader), reader.ReadVarInt(), reader.ReadVector3(), GeneratedNetworkCode._Read_PlayerResult_005B_005D(reader));
		}
	}

	protected void UserCode_RpcTransitionShiftToGameLost__Byte__Int32__Vector3__PlayerResult_005B_005D(byte shiftCount, int shiftMilliseconds, Vector3 lastOutboundPos, PlayerResult[] playerResults)
	{
		StartCoroutine(ClientTransitionShiftToGameLostCo(shiftCount, shiftMilliseconds, lastOutboundPos, playerResults));
	}

	protected static void InvokeUserCode_RpcTransitionShiftToGameLost__Byte__Int32__Vector3__PlayerResult_005B_005D(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcTransitionShiftToGameLost called on server.");
		}
		else
		{
			((ShiftManager)obj).UserCode_RpcTransitionShiftToGameLost__Byte__Int32__Vector3__PlayerResult_005B_005D(NetworkReaderExtensions.ReadByte(reader), reader.ReadVarInt(), reader.ReadVector3(), GeneratedNetworkCode._Read_PlayerResult_005B_005D(reader));
		}
	}

	protected void UserCode_RpcTransitionFadeToBreakRoom()
	{
		StartCoroutine(ClientTransitionFadeToBreakRoom());
	}

	protected static void InvokeUserCode_RpcTransitionFadeToBreakRoom(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcTransitionFadeToBreakRoom called on server.");
		}
		else
		{
			((ShiftManager)obj).UserCode_RpcTransitionFadeToBreakRoom();
		}
	}

	protected void UserCode_RpcTransitionToLobby()
	{
		_proceeding = false;
		AggroManagerBase<ReportUI>.instance.Hide();
	}

	protected static void InvokeUserCode_RpcTransitionToLobby(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcTransitionToLobby called on server.");
		}
		else
		{
			((ShiftManager)obj).UserCode_RpcTransitionToLobby();
		}
	}

	protected void UserCode_RpcRequestPlayerResults__NetworkConnectionToClient__Byte(NetworkConnectionToClient target, byte playerIndex)
	{
		PlayerResult result = default(PlayerResult);
		if (GameUtil.TryGetLocalPlayer(out var player))
		{
			result.color = player.GetObject<PlayerColorManager>().GetPlayerColor(ui: true);
			result.crashOuts = (short)player.GetObject<PlayerStress>().crashOutCount;
			result.nitroCount = (short)player.GetObject<NitroController>().nitroUseCount;
			result.upgradeCount = (byte)player.GetObject<PlayerUpgrades>().upgradeCount;
			result.driftDistanceCount = Mathf.CeilToInt(player.GetObject<VehicleController>().distanceDrifted);
			result.name = player.GetObject<NamePlateHandler>().nameText;
		}
		CmdPlayerResults(playerIndex, result);
		NetworkAggroManagerBase<PlayersManager>.instance.RequestProceed();
	}

	protected static void InvokeUserCode_RpcRequestPlayerResults__NetworkConnectionToClient__Byte(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("TargetRPC RpcRequestPlayerResults called on server.");
		}
		else
		{
			((ShiftManager)obj).UserCode_RpcRequestPlayerResults__NetworkConnectionToClient__Byte(null, NetworkReaderExtensions.ReadByte(reader));
		}
	}

	protected void UserCode_CmdPlayerResults__Byte__PlayerResult(byte playerIndex, PlayerResult result)
	{
		_serverPlayerResults[playerIndex] = result;
	}

	protected static void InvokeUserCode_CmdPlayerResults__Byte__PlayerResult(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdPlayerResults called on client.");
		}
		else
		{
			((ShiftManager)obj).UserCode_CmdPlayerResults__Byte__PlayerResult(NetworkReaderExtensions.ReadByte(reader), GeneratedNetworkCode._Read_PlayerResult(reader));
		}
	}

	protected void UserCode_CmdShiftDevCmdNext()
	{
		switch (_shiftPhase)
		{
		case ShiftPhase.BreakRoom:
		{
			Unity.Mathematics.Random random = MathUtil.GetRandom(GameUtil.seed, _currentShift, (int)_shiftPhase);
			NetworkAggroManagerBase<PlayersManager>.instance.ServerResetProceeding();
			StartCoroutine(TransitionBreakRoomToShiftCo(random.NextInt()));
			break;
		}
		case ShiftPhase.Organizational:
			_serverTimer.Clear();
			break;
		default:
			throw new InvalidEnumException();
		case ShiftPhase.None:
		case ShiftPhase.Shift:
		case ShiftPhase.Failed:
			break;
		}
	}

	protected static void InvokeUserCode_CmdShiftDevCmdNext(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdShiftDevCmdNext called on client.");
		}
		else
		{
			((ShiftManager)obj).UserCode_CmdShiftDevCmdNext();
		}
	}

	protected void UserCode_CmdShiftDevCmdWinShift__ContractScore(ContractScore score)
	{
		if (_syncTrucksCompleted < _trucksThisShift)
		{
			NetworkAggroManagerBase<WarehouseManager>.instance.ServerDevCmdCompleteOutbounds();
			for (int i = _syncTrucksCompleted; i < _trucksThisShift; i++)
			{
				ServerTruckCompleted(Vector3.zero, 1f, 0, 0, 0, 0, 0);
			}
			_debugScore = score;
		}
	}

	protected static void InvokeUserCode_CmdShiftDevCmdWinShift__ContractScore(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdShiftDevCmdWinShift called on client.");
		}
		else
		{
			((ShiftManager)obj).UserCode_CmdShiftDevCmdWinShift__ContractScore(GeneratedNetworkCode._Read_ContractScore(reader));
		}
	}

	protected void UserCode_CmdShiftDevCmdLoseShift()
	{
		_serverFailed = true;
	}

	protected static void InvokeUserCode_CmdShiftDevCmdLoseShift(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdShiftDevCmdLoseShift called on client.");
		}
		else
		{
			((ShiftManager)obj).UserCode_CmdShiftDevCmdLoseShift();
		}
	}

	protected void UserCode_CmdShiftOutboundDevCmd()
	{
		NetworkAggroManagerBase<WarehouseManager>.instance.ServerDevCmdBringOutbound();
	}

	protected static void InvokeUserCode_CmdShiftOutboundDevCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdShiftOutboundDevCmd called on client.");
		}
		else
		{
			((ShiftManager)obj).UserCode_CmdShiftOutboundDevCmd();
		}
	}

	protected void UserCode_CmdShiftInboundDevCmd()
	{
		NetworkAggroManagerBase<WarehouseManager>.instance.ServerDevCmdBringInbound();
	}

	protected static void InvokeUserCode_CmdShiftInboundDevCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdShiftInboundDevCmd called on client.");
		}
		else
		{
			((ShiftManager)obj).UserCode_CmdShiftInboundDevCmd();
		}
	}

	protected void UserCode_CmdShiftDevCmdMoneyAdd__Int32(int amount)
	{
		Network_syncMoney = _syncMoney + amount;
	}

	protected static void InvokeUserCode_CmdShiftDevCmdMoneyAdd__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdShiftDevCmdMoneyAdd called on client.");
		}
		else
		{
			((ShiftManager)obj).UserCode_CmdShiftDevCmdMoneyAdd__Int32(reader.ReadVarInt());
		}
	}

	protected void UserCode_CmdShiftDevCmdPauseToggle()
	{
		_serverTimerDebugPaused = !_serverTimerDebugPaused;
	}

	protected static void InvokeUserCode_CmdShiftDevCmdPauseToggle(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdShiftDevCmdPauseToggle called on client.");
		}
		else
		{
			((ShiftManager)obj).UserCode_CmdShiftDevCmdPauseToggle();
		}
	}

	static ShiftManager()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(ShiftManager), "System.Void ShiftManager::CmdPlayerResults(System.Byte,PlayerResult)", InvokeUserCode_CmdPlayerResults__Byte__PlayerResult, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ShiftManager), "System.Void ShiftManager::CmdShiftDevCmdNext()", InvokeUserCode_CmdShiftDevCmdNext, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ShiftManager), "System.Void ShiftManager::CmdShiftDevCmdWinShift(ContractScore)", InvokeUserCode_CmdShiftDevCmdWinShift__ContractScore, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ShiftManager), "System.Void ShiftManager::CmdShiftDevCmdLoseShift()", InvokeUserCode_CmdShiftDevCmdLoseShift, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ShiftManager), "System.Void ShiftManager::CmdShiftOutboundDevCmd()", InvokeUserCode_CmdShiftOutboundDevCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ShiftManager), "System.Void ShiftManager::CmdShiftInboundDevCmd()", InvokeUserCode_CmdShiftInboundDevCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ShiftManager), "System.Void ShiftManager::CmdShiftDevCmdMoneyAdd(System.Int32)", InvokeUserCode_CmdShiftDevCmdMoneyAdd__Int32, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ShiftManager), "System.Void ShiftManager::CmdShiftDevCmdPauseToggle()", InvokeUserCode_CmdShiftDevCmdPauseToggle, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(ShiftManager), "System.Void ShiftManager::RpcMoneyAdded(System.Int32)", InvokeUserCode_RpcMoneyAdded__Int32);
		RemoteProcedureCalls.RegisterRpc(typeof(ShiftManager), "System.Void ShiftManager::RpcBoxesShipped(System.Int16,System.Int16,System.Int16,System.Int16,System.Byte,System.Byte,System.Byte,System.Byte,System.Byte,System.Boolean)", InvokeUserCode_RpcBoxesShipped__Int16__Int16__Int16__Int16__Byte__Byte__Byte__Byte__Byte__Boolean);
		RemoteProcedureCalls.RegisterRpc(typeof(ShiftManager), "System.Void ShiftManager::RpcProceed()", InvokeUserCode_RpcProceed);
		RemoteProcedureCalls.RegisterRpc(typeof(ShiftManager), "System.Void ShiftManager::RpcShiftChangedAll(ShiftPhase,System.Int32,System.Int32)", InvokeUserCode_RpcShiftChangedAll__ShiftPhase__Int32__Int32);
		RemoteProcedureCalls.RegisterRpc(typeof(ShiftManager), "System.Void ShiftManager::RpcTransitionBreakRoomToFade()", InvokeUserCode_RpcTransitionBreakRoomToFade);
		RemoteProcedureCalls.RegisterRpc(typeof(ShiftManager), "System.Void ShiftManager::RpcTransitionFadeToShift()", InvokeUserCode_RpcTransitionFadeToShift);
		RemoteProcedureCalls.RegisterRpc(typeof(ShiftManager), "System.Void ShiftManager::RpcTransitionShiftToShiftWon(System.Byte,ContractScore,UnityEngine.Vector3)", InvokeUserCode_RpcTransitionShiftToShiftWon__Byte__ContractScore__Vector3);
		RemoteProcedureCalls.RegisterRpc(typeof(ShiftManager), "System.Void ShiftManager::RpcTransitionShiftToShiftWonPhase1(System.Byte,ContractScore,UnityEngine.Vector3)", InvokeUserCode_RpcTransitionShiftToShiftWonPhase1__Byte__ContractScore__Vector3);
		RemoteProcedureCalls.RegisterRpc(typeof(ShiftManager), "System.Void ShiftManager::RpcTransitionShiftToShiftWonPhase2(System.Byte)", InvokeUserCode_RpcTransitionShiftToShiftWonPhase2__Byte);
		RemoteProcedureCalls.RegisterRpc(typeof(ShiftManager), "System.Void ShiftManager::RpcTransitionShiftToGameWon(System.Byte,ContractScore,ContractScore,System.Int32,UnityEngine.Vector3,PlayerResult[])", InvokeUserCode_RpcTransitionShiftToGameWon__Byte__ContractScore__ContractScore__Int32__Vector3__PlayerResult_005B_005D);
		RemoteProcedureCalls.RegisterRpc(typeof(ShiftManager), "System.Void ShiftManager::RpcTransitionShiftToGameLost(System.Byte,System.Int32,UnityEngine.Vector3,PlayerResult[])", InvokeUserCode_RpcTransitionShiftToGameLost__Byte__Int32__Vector3__PlayerResult_005B_005D);
		RemoteProcedureCalls.RegisterRpc(typeof(ShiftManager), "System.Void ShiftManager::RpcTransitionFadeToBreakRoom()", InvokeUserCode_RpcTransitionFadeToBreakRoom);
		RemoteProcedureCalls.RegisterRpc(typeof(ShiftManager), "System.Void ShiftManager::RpcTransitionToLobby()", InvokeUserCode_RpcTransitionToLobby);
		RemoteProcedureCalls.RegisterRpc(typeof(ShiftManager), "System.Void ShiftManager::RpcRequestPlayerResults(Mirror.NetworkConnectionToClient,System.Byte)", InvokeUserCode_RpcRequestPlayerResults__NetworkConnectionToClient__Byte);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteVarInt(_syncTrucksCompleted);
			writer.WriteVarInt(_syncMoney);
			writer.WriteFloat(_syncSecondsRemaining);
			writer.WriteSByte(_syncPlayListIndex);
			writer.WriteBool(_syncLockedIn);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteVarInt(_syncTrucksCompleted);
		}
		if ((syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteVarInt(_syncMoney);
		}
		if ((syncVarDirtyBits & 4L) != 0L)
		{
			writer.WriteFloat(_syncSecondsRemaining);
		}
		if ((syncVarDirtyBits & 8L) != 0L)
		{
			writer.WriteSByte(_syncPlayListIndex);
		}
		if ((syncVarDirtyBits & 0x10L) != 0L)
		{
			writer.WriteBool(_syncLockedIn);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _syncTrucksCompleted, null, reader.ReadVarInt());
			GeneratedSyncVarDeserialize(ref _syncMoney, null, reader.ReadVarInt());
			GeneratedSyncVarDeserialize(ref _syncSecondsRemaining, null, reader.ReadFloat());
			GeneratedSyncVarDeserialize(ref _syncPlayListIndex, null, reader.ReadSByte());
			GeneratedSyncVarDeserialize(ref _syncLockedIn, null, reader.ReadBool());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncTrucksCompleted, null, reader.ReadVarInt());
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncMoney, null, reader.ReadVarInt());
		}
		if ((num & 4L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncSecondsRemaining, null, reader.ReadFloat());
		}
		if ((num & 8L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncPlayListIndex, null, reader.ReadSByte());
		}
		if ((num & 0x10L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncLockedIn, null, reader.ReadBool());
		}
	}
}
