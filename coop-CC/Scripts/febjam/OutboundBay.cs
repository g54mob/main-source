using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aggro.Core;
using Aggro.Core.Networking;
using Mirror;
using Mirror.RemoteCalls;
using Unity.Mathematics;
using UnityEngine;

public class OutboundBay : NetworkEntityBehaviourBase, IFloaterPopulator
{
	public enum BayState : byte
	{
		None = 0,
		Outbound = 1,
		OutboundTransitioning = 2,
		OutboundDenyingIntoBay = 3,
		OutboundDenyingFromBay = 4
	}

	private struct Count
	{
		public int total;

		public int current;
	}

	public struct Order
	{
		public GameObject prefab;

		public int total;

		public int current;
	}

	[Min(0f)]
	public float orderDeniedTimerReduction = 5f;

	[Min(0f)]
	public float animationDuration = 2f;

	[Space]
	public Transform cameraTargetLocation;

	[SyncVar]
	private BayState _syncState;

	[SyncVar]
	private bool _syncIsBayOpen;

	[SyncVar]
	private float _syncNormalizedStrikeTime;

	[SyncVar]
	private float _syncSecondsRemaining;

	[SyncVar]
	private bool _syncStrikeTimerPaused;

	[SyncVar]
	private bool _syncHasWildCard;

	[SyncVar]
	private byte _syncIncorrectCount;

	private bool _cachedHasWildCard;

	private readonly SyncDictionary<uint, Count> _outboundOrder = new SyncDictionary<uint, Count>();

	private int _cachedIncorrectCount;

	private Timer _serverTimer;

	private Timer _serverStrikeTimer;

	private Timer _serverPauseTimer;

	private NetworkConnectionToClient _serverSender;

	private List<Entity> _stacks = new List<Entity>();

	private TruckTimerFloaterUI _truckTimerFloaterUI;

	private static List<GrabbableHolder> _holders;

	private static List<Entity> _entities;

	private static Dictionary<uint, int> _idToCount;

	private static readonly int BAY_OPEN_ID;

	private static readonly int ALARM_ON_ID;

	private static readonly int ACCEPTED_ID;

	private static readonly int Alarm;

	public string bayID = "A";

	public Transform timerFloaterTarget;

	public Transform orderFloaterTarget;

	public BayState state => _syncState;

	public float normalizedStrikeTime => _syncNormalizedStrikeTime;

	public float secondsRemaining => _syncSecondsRemaining;

	public int secondsRemainingInt => Mathf.CeilToInt(secondsRemaining);

	public bool hasWildCard => _syncHasWildCard;

	public float serverSecondsRemaining => _serverStrikeTimer.GetSecondsRemaining();

	public bool strikeTimerPaused => _syncStrikeTimerPaused;

	public uint version { get; private set; }

	public bool tutorialOutboundSent { get; private set; }

	public BayState Network_syncState
	{
		get
		{
			return _syncState;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncState, 1uL, null);
		}
	}

	public bool Network_syncIsBayOpen
	{
		get
		{
			return _syncIsBayOpen;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncIsBayOpen, 2uL, null);
		}
	}

	public float Network_syncNormalizedStrikeTime
	{
		get
		{
			return _syncNormalizedStrikeTime;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncNormalizedStrikeTime, 4uL, null);
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
			GeneratedSyncVarSetter(value, ref _syncSecondsRemaining, 8uL, null);
		}
	}

	public bool Network_syncStrikeTimerPaused
	{
		get
		{
			return _syncStrikeTimerPaused;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncStrikeTimerPaused, 16uL, null);
		}
	}

	public bool Network_syncHasWildCard
	{
		get
		{
			return _syncHasWildCard;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncHasWildCard, 32uL, null);
		}
	}

	public byte Network_syncIncorrectCount
	{
		get
		{
			return _syncIncorrectCount;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncIncorrectCount, 64uL, null);
		}
	}

	protected override void OnInitializeBehaviour()
	{
		SyncDictionary<uint, Count> outboundOrder = _outboundOrder;
		outboundOrder.OnChange = (Action<SyncIDictionary<uint, Count>.Operation, uint, Count>)Delegate.Combine(outboundOrder.OnChange, new Action<SyncIDictionary<uint, Count>.Operation, uint, Count>(OnOrderChanged));
	}

	protected override void OnUpdateSimulation()
	{
		if (!base.isServer || NetworkAggroManagerBase<ShiftManager>.instance.GetShiftPhase() != ShiftPhase.Shift)
		{
			return;
		}
		switch (_syncState)
		{
		case BayState.None:
			ServerSetInteractable(interactable: false);
			Network_syncIsBayOpen = false;
			break;
		case BayState.Outbound:
		{
			if (_serverTimer.IsFinished())
			{
				if (!GameUtil.isGym && !GameUtil.isTutorial && !_serverStrikeTimer.IsFinished())
				{
					if (!_serverPauseTimer.IsFinished() || NetworkAggroManagerBase<ShiftManager>.instance.serverTimersPaused)
					{
						_serverPauseTimer.DecrementTimer();
					}
					else
					{
						_serverStrikeTimer.DecrementTimer();
					}
					if (_serverStrikeTimer.IsFinished())
					{
						NetworkAggroManagerBase<ShiftManager>.instance.ServerFailRun(cameraTargetLocation.position);
						Network_syncState = BayState.OutboundTransitioning;
						_serverTimer.SetTimer(animationDuration);
					}
				}
			}
			else
			{
				_serverTimer.DecrementTimer();
				if (_serverTimer.IsFinished())
				{
					ServerSetInteractable(interactable: true);
				}
			}
			_idToCount.Clear();
			foreach (KeyValuePair<uint, Count> item in _outboundOrder)
			{
				_idToCount[item.Key] = 0;
			}
			_holders.Clear();
			base.entity.GetObjects(_holders);
			int num = 0;
			for (int j = 0; j < _holders.Count; j++)
			{
				if (!_holders[j].serverHeldEntity.TryGetObject<Grabbable>(out var obj))
				{
					continue;
				}
				_entities.Clear();
				obj.GetStack(_entities);
				for (int k = 0; k < _entities.Count; k++)
				{
					Entity entity = _entities[k];
					int value;
					SpecialDelivery obj3;
					if (entity.TryGetObject<BoxForm>(out var obj2) && !obj2.ServerCanBeShipped())
					{
						num++;
					}
					else if (_idToCount.TryGetValue(entity.netIdentity.assetId, out value))
					{
						value++;
						_idToCount[entity.netIdentity.assetId] = value;
					}
					else if (!entity.TryGetObject<SpecialDelivery>(out obj3) || !obj3.isWildCard)
					{
						num++;
					}
				}
			}
			Network_syncIncorrectCount = (byte)num;
			foreach (KeyValuePair<uint, int> item2 in _idToCount)
			{
				Count value2 = _outboundOrder[item2.Key];
				if (value2.current != item2.Value)
				{
					value2.current = item2.Value;
					_outboundOrder[item2.Key] = value2;
				}
			}
			Network_syncIsBayOpen = true;
			break;
		}
		case BayState.OutboundTransitioning:
			_serverTimer.DecrementTimer();
			if (_serverTimer.IsFinished())
			{
				for (int l = 0; l < _stacks.Count; l++)
				{
					if (_stacks[l].TryGetObject<Grabbable>(out var obj4))
					{
						_entities.Clear();
						obj4.GetStack(_entities);
						for (int m = 0; m < _entities.Count; m++)
						{
							AggroManagerBase<DeathManager>.instance.QueueDeath(_entities[m]);
						}
					}
				}
				Network_syncState = BayState.None;
			}
			Network_syncIsBayOpen = false;
			break;
		case BayState.OutboundDenyingIntoBay:
			Network_syncIsBayOpen = false;
			_serverTimer.DecrementTimer();
			if (_serverTimer.IsFinished())
			{
				RpcOutboundDeniedTargeted(_serverSender);
				RpcOutboundDenied();
				Network_syncState = BayState.OutboundDenyingFromBay;
				_serverTimer.SetTimer(animationDuration);
				_serverStrikeTimer.AddToTimer(0f - orderDeniedTimerReduction);
				if (_serverStrikeTimer.IsFinished() && !GameUtil.isGym && !GameUtil.isTutorial)
				{
					NetworkAggroManagerBase<ShiftManager>.instance.ServerFailRun(cameraTargetLocation.position);
				}
				else
				{
					NetworkAggroManagerBase<VoiceOverManager>.instance.ServerIncorrectOrder();
				}
			}
			break;
		case BayState.OutboundDenyingFromBay:
		{
			Network_syncIsBayOpen = true;
			_serverTimer.DecrementTimer();
			if (!_serverTimer.IsFinished())
			{
				break;
			}
			Network_syncState = BayState.Outbound;
			_holders.Clear();
			base.entity.GetObjects(_holders);
			_holders.Sort(CompareHolders);
			for (int i = 0; i < _holders.Count; i++)
			{
				Entity serverHeldEntity = _holders[i].serverHeldEntity;
				if (serverHeldEntity.Exists())
				{
					serverHeldEntity.GetObject<Grabbable>().ServerBackFromOutbound();
				}
			}
			ServerSetInteractable(interactable: true);
			ServerSetActivatable(activatable: true);
			break;
		}
		default:
			throw new InvalidEnumException();
		}
	}

	protected override void OnUpdatePresentation()
	{
		if (base.entity.TryGetObject<Animator>(out var obj))
		{
			obj.SetBool(BAY_OPEN_ID, _syncIsBayOpen);
		}
		if (_syncHasWildCard != _cachedHasWildCard)
		{
			_cachedHasWildCard = _syncHasWildCard;
			version++;
		}
		if (_syncIncorrectCount != _cachedIncorrectCount)
		{
			_cachedIncorrectCount = _syncIncorrectCount;
			version++;
		}
		if (base.isServer)
		{
			if (GameUtil.isTutorial || GameUtil.isGym)
			{
				Network_syncSecondsRemaining = 60f;
				Network_syncNormalizedStrikeTime = 1f;
				Network_syncStrikeTimerPaused = false;
			}
			else
			{
				Network_syncSecondsRemaining = math.min(_serverStrikeTimer.GetSecondsRemaining(), Mathf.RoundToInt(NetworkAggroManagerBase<ShiftManager>.instance.ServerGetStrikeOutDuration()));
				Network_syncNormalizedStrikeTime = math.saturate(_serverStrikeTimer.GetSecondsRemaining() / NetworkAggroManagerBase<ShiftManager>.instance.ServerGetStrikeOutDuration());
				Network_syncStrikeTimerPaused = !_serverStrikeTimer.IsFinished() || NetworkAggroManagerBase<ShiftManager>.instance.serverTimersPaused;
			}
			if (_syncState == BayState.Outbound)
			{
				Network_syncHasWildCard = ServerHasWildCard();
			}
			else
			{
				Network_syncHasWildCard = false;
			}
		}
	}

	[Server]
	private bool ServerHasWildCard()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Boolean OutboundBay::ServerHasWildCard()' called when server was not active");
			return default(bool);
		}
		_holders.Clear();
		base.entity.GetObjects(_holders);
		for (int i = 0; i < _holders.Count; i++)
		{
			if (!_holders[i].serverHeldEntity.TryGetObject<Grabbable>(out var obj))
			{
				continue;
			}
			_entities.Clear();
			obj.GetStack(_entities);
			for (int j = 0; j < _entities.Count; j++)
			{
				if (_entities[j].TryGetObject<SpecialDelivery>(out var obj2) && obj2.isWildCard)
				{
					return true;
				}
			}
		}
		return false;
	}

	private static int CompareHolders(GrabbableHolder a, GrabbableHolder b)
	{
		return a.id.CompareTo(b.id);
	}

	private void OnOrderChanged(SyncIDictionary<uint, Count>.Operation op, uint k, Count v)
	{
		version++;
	}

	public void GetOutboundOrder(List<Order> orders)
	{
		foreach (KeyValuePair<uint, Count> item in _outboundOrder)
		{
			if (NetworkClient.GetPrefab(item.Key, out var prefab))
			{
				orders.Add(new Order
				{
					prefab = prefab,
					total = item.Value.total,
					current = item.Value.current
				});
			}
		}
	}

	public int GetIncorrectBoxCount()
	{
		return _syncIncorrectCount;
	}

	[Server]
	public void ServerSetOutboundOrder(List<ShiftOrderObject> orders)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void OutboundBay::ServerSetOutboundOrder(System.Collections.Generic.List`1<ShiftOrderObject>)' called when server was not active");
			return;
		}
		_outboundOrder.Clear();
		for (int i = 0; i < orders.Count; i++)
		{
			if (orders[i].TryGetAssetId(out var assetId))
			{
				if (!_outboundOrder.TryGetValue(assetId, out var value))
				{
					value.total = 0;
				}
				value.total++;
				_outboundOrder[assetId] = value;
			}
		}
		if (_outboundOrder.Count > 0)
		{
			_serverTimer.SetTimer(animationDuration);
			if (GameUtil.isGym || GameUtil.isTutorial)
			{
				_serverStrikeTimer.SetTimer(60);
			}
			else
			{
				_serverStrikeTimer.SetTimer(NetworkAggroManagerBase<ShiftManager>.instance.ServerGetStrikeOutDuration());
			}
			ServerSetInteractable(interactable: false);
			Network_syncState = BayState.Outbound;
		}
		else
		{
			Network_syncState = BayState.None;
		}
	}

	[Server]
	public bool ServerIsHandlingOrder()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Boolean OutboundBay::ServerIsHandlingOrder()' called when server was not active");
			return default(bool);
		}
		return _syncState != BayState.None;
	}

	[Server]
	public void ServerRequestSendOutbound(NetworkConnectionToClient conn, bool forceCompleted)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void OutboundBay::ServerRequestSendOutbound(Mirror.NetworkConnectionToClient,System.Boolean)' called when server was not active");
		}
		else
		{
			if (_syncState != BayState.Outbound)
			{
				return;
			}
			_serverSender = conn;
			_idToCount.Clear();
			foreach (KeyValuePair<uint, Count> item in _outboundOrder)
			{
				_idToCount[item.Key] = item.Value.total;
			}
			_holders.Clear();
			base.entity.GetObjects(_holders);
			bool flag = true;
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			for (int i = 0; i < _holders.Count; i++)
			{
				if (!_holders[i].serverHeldEntity.TryGetObject<Grabbable>(out var obj))
				{
					continue;
				}
				_entities.Clear();
				obj.GetStack(_entities);
				num2 += _entities.Count;
				for (int j = 0; j < _entities.Count; j++)
				{
					Entity entity = _entities[j];
					if (entity.tags.Has(CCTags.TAG_ANIMAL))
					{
						num4++;
					}
					if (entity.tags.Has(CCTags.TAG_EXPLOSIVE))
					{
						num3++;
					}
					if (entity.TryGetObject<SpecialDelivery>(out var obj2))
					{
						if (obj2.isWildCard)
						{
							num++;
						}
						continue;
					}
					if (entity.TryGetObject<BoxHealth>(out var obj3) && obj3.isDamaged)
					{
						num5++;
					}
					if (!_idToCount.TryGetValue(entity.netIdentity.assetId, out var value))
					{
						flag = false;
						break;
					}
					if (entity.TryGetObject<BoxForm>(out var obj4) && !obj4.ServerCanBeShipped())
					{
						flag = false;
						break;
					}
					value--;
					if (value > 0)
					{
						_idToCount[entity.netIdentity.assetId] = value;
					}
					else
					{
						_idToCount.Remove(entity.netIdentity.assetId);
					}
				}
			}
			int num6 = num;
			while (_idToCount.Count > 0 && num6 > 0)
			{
				uint num7 = 0u;
				int num8 = 0;
				foreach (KeyValuePair<uint, int> item2 in _idToCount)
				{
					num7 = item2.Key;
					num8 = item2.Value;
				}
				int num9 = math.min(num8, num6);
				num8 -= num9;
				num6 -= num9;
				if (num8 == 0)
				{
					_idToCount.Remove(num7);
				}
			}
			if (_idToCount.Count > 0)
			{
				flag = false;
			}
			ServerSetInteractable(interactable: false);
			ServerSetActivatable(activatable: false);
			if (flag || forceCompleted)
			{
				_stacks.Clear();
				for (int k = 0; k < _holders.Count; k++)
				{
					GrabbableHolder grabbableHolder = _holders[k];
					if (grabbableHolder.serverHeldEntity.Exists())
					{
						_stacks.Add(grabbableHolder.serverHeldEntity);
						grabbableHolder.serverHeldEntity.GetObject<Grabbable>().ServerReadyForOutboundTransition(grabbableHolder);
						grabbableHolder.ServerRemoveItem();
					}
				}
				float num10 = NetworkAggroManagerBase<ShiftManager>.instance.ServerGetStrikeOutDuration();
				float num11 = math.saturate(_serverStrikeTimer.GetSecondsRemaining() / num10);
				if (num11 >= (float)NetworkAggroManagerBase<ShiftManager>.instance.truckBonuses[NetworkAggroManagerBase<ShiftManager>.instance.truckBonuses.Length - 1].timePercentage / 100f)
				{
					RPCPlayBonusParticles();
				}
				NetworkAggroManagerBase<ShiftManager>.instance.ServerTruckCompleted(cameraTargetLocation.position, num11, num2, num5, num, num3, num4);
				Network_syncState = BayState.OutboundTransitioning;
				_serverTimer.SetTimer(animationDuration);
				RpcOutboundAccepted(NetworkAggroManagerBase<ShiftManager>.instance.GetTrucksCompleted());
				tutorialOutboundSent = true;
				return;
			}
			for (int l = 0; l < _holders.Count; l++)
			{
				GrabbableHolder grabbableHolder2 = _holders[l];
				if (grabbableHolder2.serverHeldEntity.Exists())
				{
					grabbableHolder2.serverHeldEntity.GetObject<Grabbable>().ServerReadyForOutboundTransition(grabbableHolder2);
				}
			}
			Network_syncState = BayState.OutboundDenyingIntoBay;
			_serverTimer.SetTimer(animationDuration);
		}
	}

	[ClientRpc]
	public void RPCPlayBonusParticles()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void OutboundBay::RPCPlayBonusParticles()", 1751475900, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	public void ServerDevCmdComplete()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void OutboundBay::ServerDevCmdComplete()' called when server was not active");
		}
		else
		{
			ServerRequestSendOutbound(null, forceCompleted: true);
		}
	}

	[Server]
	private void ServerSetInteractable(bool interactable)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void OutboundBay::ServerSetInteractable(System.Boolean)' called when server was not active");
			return;
		}
		_holders.Clear();
		base.entity.GetObjects(_holders);
		for (int i = 0; i < _holders.Count; i++)
		{
			_holders[i].NetworkisInteractable = interactable;
		}
	}

	[TargetRpc]
	private void RpcOutboundDeniedTargeted(NetworkConnectionToClient target)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendTargetRPCInternal(target, "System.Void OutboundBay::RpcOutboundDeniedTargeted(Mirror.NetworkConnectionToClient)", -953069220, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcOutboundDenied()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void OutboundBay::RpcOutboundDenied()", 940674119, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcOutboundAccepted(int truckCount)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(truckCount);
		SendRPCInternal("System.Void OutboundBay::RpcOutboundAccepted(System.Int32)", -407711460, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerSetActivatable(bool activatable)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void OutboundBay::ServerSetActivatable(System.Boolean)' called when server was not active");
			return;
		}
		_holders.Clear();
		base.entity.GetObjects(_holders);
		for (int i = 0; i < _holders.Count; i++)
		{
			if (!_holders[i].serverHeldEntity.TryGetObject<Grabbable>(out var obj))
			{
				continue;
			}
			_entities.Clear();
			obj.GetStack(_entities);
			for (int j = 0; j < _entities.Count; j++)
			{
				if (_entities[j].TryGetObject<BoxActivator>(out var obj2))
				{
					obj2.ServerSetActivatable(activatable);
				}
			}
		}
	}

	[Server]
	public void ServerPauseTimer(float duration)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void OutboundBay::ServerPauseTimer(System.Single)' called when server was not active");
		}
		else
		{
			_serverPauseTimer.SetTimerIfGreater(duration);
		}
	}

	public void AddedFloater(FloaterUI floaterAdded)
	{
		if (floaterAdded.entity.TryGetObject<TruckTimerFloaterUI>(out var obj))
		{
			obj.assignedOutboundBay = this;
			floaterAdded.targetWorldPosition = timerFloaterTarget.position;
			_truckTimerFloaterUI = obj;
		}
		if (floaterAdded.entity.TryGetObject<TruckOrderFloaterUI>(out var obj2))
		{
			obj2.assignedOutboundBay = this;
			floaterAdded.targetWorldPosition = orderFloaterTarget.position;
		}
	}

	public void RemovedFloater()
	{
	}

	public OutboundBay()
	{
		InitSyncObject(_outboundOrder);
	}

	static OutboundBay()
	{
		_holders = new List<GrabbableHolder>();
		_entities = new List<Entity>();
		_idToCount = new Dictionary<uint, int>();
		BAY_OPEN_ID = Animator.StringToHash("isOpened");
		ALARM_ON_ID = Animator.StringToHash("alarmOn");
		ACCEPTED_ID = Animator.StringToHash("accepted");
		Alarm = Animator.StringToHash("alarm");
		RemoteProcedureCalls.RegisterRpc(typeof(OutboundBay), "System.Void OutboundBay::RPCPlayBonusParticles()", InvokeUserCode_RPCPlayBonusParticles);
		RemoteProcedureCalls.RegisterRpc(typeof(OutboundBay), "System.Void OutboundBay::RpcOutboundDenied()", InvokeUserCode_RpcOutboundDenied);
		RemoteProcedureCalls.RegisterRpc(typeof(OutboundBay), "System.Void OutboundBay::RpcOutboundAccepted(System.Int32)", InvokeUserCode_RpcOutboundAccepted__Int32);
		RemoteProcedureCalls.RegisterRpc(typeof(OutboundBay), "System.Void OutboundBay::RpcOutboundDeniedTargeted(Mirror.NetworkConnectionToClient)", InvokeUserCode_RpcOutboundDeniedTargeted__NetworkConnectionToClient);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_RPCPlayBonusParticles()
	{
		_truckTimerFloaterUI.PlayBonusParticles();
	}

	protected static void InvokeUserCode_RPCPlayBonusParticles(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RPCPlayBonusParticles called on server.");
		}
		else
		{
			((OutboundBay)obj).UserCode_RPCPlayBonusParticles();
		}
	}

	protected void UserCode_RpcOutboundDeniedTargeted__NetworkConnectionToClient(NetworkConnectionToClient target)
	{
		if (GameUtil.TryGetLocalPlayer(out var player) && player.TryGetObject<PlayerStress>(out var obj))
		{
			obj.RequestCrashOut();
		}
	}

	protected static void InvokeUserCode_RpcOutboundDeniedTargeted__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("TargetRPC RpcOutboundDeniedTargeted called on server.");
		}
		else
		{
			((OutboundBay)obj).UserCode_RpcOutboundDeniedTargeted__NetworkConnectionToClient(null);
		}
	}

	protected void UserCode_RpcOutboundDenied()
	{
		if (base.entity.TryGetObject<Animator>(out var obj))
		{
			obj.SetTrigger(Alarm);
		}
		base.eventManager.QueueGlobalEvent(default(EvIncorrectOrderSent));
	}

	protected static void InvokeUserCode_RpcOutboundDenied(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcOutboundDenied called on server.");
		}
		else
		{
			((OutboundBay)obj).UserCode_RpcOutboundDenied();
		}
	}

	protected void UserCode_RpcOutboundAccepted__Int32(int truckCount)
	{
		if (base.entity.TryGetObject<Animator>(out var obj))
		{
			obj.SetTrigger(ACCEPTED_ID);
		}
		if (!GameUtil.isGym)
		{
			EvCorrectOrderSent ev = new EvCorrectOrderSent
			{
				numberOfTrucksCompleted = truckCount
			};
			base.eventManager.QueueGlobalEvent(ev);
		}
	}

	protected static void InvokeUserCode_RpcOutboundAccepted__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcOutboundAccepted called on server.");
		}
		else
		{
			((OutboundBay)obj).UserCode_RpcOutboundAccepted__Int32(reader.ReadVarInt());
		}
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			GeneratedNetworkCode._Write_OutboundBay_002FBayState(writer, _syncState);
			writer.WriteBool(_syncIsBayOpen);
			writer.WriteFloat(_syncNormalizedStrikeTime);
			writer.WriteFloat(_syncSecondsRemaining);
			writer.WriteBool(_syncStrikeTimerPaused);
			writer.WriteBool(_syncHasWildCard);
			NetworkWriterExtensions.WriteByte(writer, _syncIncorrectCount);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			GeneratedNetworkCode._Write_OutboundBay_002FBayState(writer, _syncState);
		}
		if ((syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteBool(_syncIsBayOpen);
		}
		if ((syncVarDirtyBits & 4L) != 0L)
		{
			writer.WriteFloat(_syncNormalizedStrikeTime);
		}
		if ((syncVarDirtyBits & 8L) != 0L)
		{
			writer.WriteFloat(_syncSecondsRemaining);
		}
		if ((syncVarDirtyBits & 0x10L) != 0L)
		{
			writer.WriteBool(_syncStrikeTimerPaused);
		}
		if ((syncVarDirtyBits & 0x20L) != 0L)
		{
			writer.WriteBool(_syncHasWildCard);
		}
		if ((syncVarDirtyBits & 0x40L) != 0L)
		{
			NetworkWriterExtensions.WriteByte(writer, _syncIncorrectCount);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _syncState, null, GeneratedNetworkCode._Read_OutboundBay_002FBayState(reader));
			GeneratedSyncVarDeserialize(ref _syncIsBayOpen, null, reader.ReadBool());
			GeneratedSyncVarDeserialize(ref _syncNormalizedStrikeTime, null, reader.ReadFloat());
			GeneratedSyncVarDeserialize(ref _syncSecondsRemaining, null, reader.ReadFloat());
			GeneratedSyncVarDeserialize(ref _syncStrikeTimerPaused, null, reader.ReadBool());
			GeneratedSyncVarDeserialize(ref _syncHasWildCard, null, reader.ReadBool());
			GeneratedSyncVarDeserialize(ref _syncIncorrectCount, null, NetworkReaderExtensions.ReadByte(reader));
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncState, null, GeneratedNetworkCode._Read_OutboundBay_002FBayState(reader));
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncIsBayOpen, null, reader.ReadBool());
		}
		if ((num & 4L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncNormalizedStrikeTime, null, reader.ReadFloat());
		}
		if ((num & 8L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncSecondsRemaining, null, reader.ReadFloat());
		}
		if ((num & 0x10L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncStrikeTimerPaused, null, reader.ReadBool());
		}
		if ((num & 0x20L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncHasWildCard, null, reader.ReadBool());
		}
		if ((num & 0x40L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncIncorrectCount, null, NetworkReaderExtensions.ReadByte(reader));
		}
	}
}
