using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aggro.Core;
using Aggro.Core.Networking;
using FMODUnity;
using Mirror;
using Mirror.RemoteCalls;
using Unity.Mathematics;
using UnityEngine;

public class WarehouseManager : NetworkAggroManagerBase<WarehouseManager>
{
	private struct Step
	{
		public int boxCount;

		public int frames;

		public bool isEmissionStart;

		public bool spawnBingBong;
	}

	[Min(1f)]
	public int cardCountPerBay = 2;

	[Header("Bing Bong")]
	public ShiftOrderObject bingBongOrder;

	[Range(0f, 1f)]
	public float bingBongChance = 0.05f;

	private Timer _serverInboundTimer;

	private Timer _serverOutboundTimer;

	private Inventory _serverInventory;

	private Queue<ShiftOrderObject> _serverDestroyed = new Queue<ShiftOrderObject>();

	private Dictionary<uint, ShiftOrderObject> _idToBoxes = new Dictionary<uint, ShiftOrderObject>();

	private int _serverInvSeed;

	private int _serverInboundSeed;

	private int _serverInboundCount;

	private int _serverOutboundEmissionCount;

	private int _serverPlayerCount;

	private Queue<Step> _serverInboundQueue = new Queue<Step>();

	private Queue<Step> _serverOutboundQueue = new Queue<Step>();

	private Deck<ShiftOrderObject> _serverInboundDeck;

	private Deck<InboundBay> _serverDeckInboundBay;

	private Deck<OutboundBay> _serverDeckOutboundBay;

	private ObjectQuery<OutboundBay> _outboundQuery;

	private HashSet<ShiftOrderObject> _serverOrdersSeen = new HashSet<ShiftOrderObject>();

	private List<ShiftOrderObject> _ordersSeen = new List<ShiftOrderObject>();

	private static List<ShiftOrderObject> _orders1;

	private static List<ShiftOrderObject> _orders2;

	private static List<bool> _bools;

	private static Dictionary<ShiftOrderObject, int> _orderCounts;

	private const float ISSUE_HIT_WAIT_TIME = 3f;

	private const int TRUCK_BAY_SLOTS_MAX = 5;

	[SyncVar]
	public float timerParam;

	public ShiftOrderObject[] ordersSeen => _ordersSeen.ToArray();

	public int serverOutboundEmissionCount => _serverOutboundEmissionCount;

	public bool serverIsFinishedEmittingOutbound => _serverOutboundQueue.Count == 0;

	public float NetworktimerParam
	{
		get
		{
			return timerParam;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref timerParam, 1uL, null);
		}
	}

	protected override void OnInitializeBehaviour()
	{
		if (GameUtil.isTutorial)
		{
			return;
		}
		if (GameUtil.isGym)
		{
			for (int i = 0; i < GameUtil.orders.Length; i++)
			{
				ShiftOrderObject shiftOrderObject = GameUtil.orders[i];
				if (shiftOrderObject.TryGetAssetId(out var assetId))
				{
					_idToBoxes[assetId] = shiftOrderObject;
				}
			}
		}
		else
		{
			for (int j = 0; j < GameUtil.orders.Length; j++)
			{
				ShiftOrderObject shiftOrderObject2 = GameUtil.orders[j];
				if (shiftOrderObject2.TryGetAssetId(out var assetId2))
				{
					_idToBoxes[assetId2] = shiftOrderObject2;
				}
			}
		}
		if (base.isServer)
		{
			_serverPlayerCount = NetworkServer.connections.Count;
			Unity.Mathematics.Random random = MathUtil.GetRandom(Hash.Calculate(GameUtil.seed, Hash.Calculate(GetType())));
			_serverInventory = new Inventory(random.NextInt());
			_serverInvSeed = random.NextInt();
			_serverInboundSeed = random.NextInt();
			_serverInboundDeck = new Deck<ShiftOrderObject>(random.NextInt());
			_serverDeckInboundBay = new Deck<InboundBay>(random.NextInt());
			_serverDeckOutboundBay = new Deck<OutboundBay>(random.NextInt());
		}
	}

	protected override void OnEntityStart()
	{
		RuntimeManager.StudioSystem.setParameterByName("timer", 0f);
		if (base.isServer && !GameUtil.isTutorial)
		{
			ObjectQuery<InboundBay> objectQuery = base.entityManager.CreateObjectQuery<InboundBay>();
			objectQuery.Run();
			_outboundQuery = base.entityManager.CreateObjectQuery<OutboundBay>();
			_outboundQuery.Run();
			for (int i = 0; i < objectQuery.count; i++)
			{
				_serverDeckInboundBay.AddCard(objectQuery[i], cardCountPerBay);
			}
			_serverDeckInboundBay.Shuffle();
			for (int j = 0; j < _outboundQuery.count; j++)
			{
				_serverDeckOutboundBay.AddCard(_outboundQuery[j], cardCountPerBay);
			}
			_serverDeckOutboundBay.Shuffle();
		}
	}

	protected override void OnUpdateSimulation()
	{
		RuntimeManager.StudioSystem.setParameterByName("timer", timerParam);
		if (!base.isServer || NetworkAggroManagerBase<ShiftManager>.instance.GetShiftPhase() != ShiftPhase.Shift)
		{
			return;
		}
		if (!GameUtil.isTutorial)
		{
			float num = float.PositiveInfinity;
			foreach (OutboundBay item in _outboundQuery)
			{
				float num2 = ((item.state != OutboundBay.BayState.Outbound) ? 1f : item.normalizedStrikeTime);
				if (num2 < num)
				{
					num = num2;
				}
			}
			if ((double)num < 0.25)
			{
				NetworktimerParam = math.remap(0.25f, 0f, 0f, 1f, num);
			}
			else
			{
				NetworktimerParam = 0f;
			}
		}
		ServerUpdateInbound();
		ServerUpdateOutbound();
	}

	[Server]
	private void ServerUpdateInbound()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void WarehouseManager::ServerUpdateInbound()' called when server was not active");
		}
		else
		{
			if (_serverInboundQueue.Count == 0)
			{
				return;
			}
			_serverInboundTimer.DecrementTimer();
			while (_serverInboundQueue.Count > 0 && _serverInboundTimer.IsFinished() && _serverDeckInboundBay.cardCount > 0)
			{
				InboundBay inboundBay;
				try
				{
					using (_serverDeckInboundBay.InfiniteDetection())
					{
						do
						{
							inboundBay = _serverDeckInboundBay.DrawCard();
						}
						while (inboundBay.serverState != InboundBay.BayState.None);
					}
				}
				catch (InfiniteLoopException)
				{
					_serverInboundTimer.SetTimer(3f);
					break;
				}
				Unity.Mathematics.Random random = MathUtil.GetRandom(_serverInboundSeed, ++_serverInboundCount);
				Step step = _serverInboundQueue.Dequeue();
				_bools.Clear();
				_orders1.Clear();
				while (_serverDestroyed.Count > 0)
				{
					_orders1.Add(_serverDestroyed.Dequeue());
					_bools.Add(item: false);
				}
				for (int i = 0; i < step.boxCount; i++)
				{
					if (NetworkAggroManagerBase<ModifierManager>.instance.TryGetModiferAs<ModifierBoxes>(out var modifier) && modifier.TryReplaceOrder(out var replace))
					{
						_orders1.Add(replace);
					}
					else
					{
						_orders1.Add(_serverInboundDeck.DrawCard());
					}
					_bools.Add(item: true);
				}
				for (int j = 0; j < _orders1.Count; j++)
				{
					if (_bools[j])
					{
						ServerOrderAdded(_orders1[j]);
					}
				}
				if (step.spawnBingBong)
				{
					_orders1.Add(bingBongOrder);
				}
				_orders1.Randomize(random.NextInt());
				inboundBay.ServerBringInOrders(_orders1, random.NextInt());
				for (int k = 0; k < _orders1.Count; k++)
				{
					ShiftOrderObject shiftOrderObject = _orders1[k];
					if (!_serverOrdersSeen.Contains(shiftOrderObject))
					{
						_serverOrdersSeen.Add(shiftOrderObject);
						RpcOrderSeen(shiftOrderObject.prefab.GetComponent<NetworkIdentity>().assetId);
					}
				}
				if (_serverInboundQueue.Count > 0)
				{
					_serverInboundTimer.SetTimer(_serverInboundQueue.Peek().frames);
				}
			}
		}
	}

	[Server]
	private void ServerUpdateOutbound()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void WarehouseManager::ServerUpdateOutbound()' called when server was not active");
		}
		else
		{
			if (_serverOutboundQueue.Count == 0)
			{
				return;
			}
			_serverOutboundTimer.DecrementTimer();
			while (_serverOutboundQueue.Count > 0 && _serverOutboundTimer.IsFinished() && _serverDeckOutboundBay.cardCount > 0)
			{
				if (_serverOutboundQueue.Peek().boxCount > _serverInventory.itemCount)
				{
					_serverOutboundTimer.SetTimer(3f);
					_serverInboundTimer.Clear();
					break;
				}
				OutboundBay outboundBay;
				try
				{
					using (_serverDeckOutboundBay.InfiniteDetection())
					{
						do
						{
							outboundBay = _serverDeckOutboundBay.DrawCard();
						}
						while (outboundBay.state != OutboundBay.BayState.None);
					}
				}
				catch (InfiniteLoopException)
				{
					_serverOutboundTimer.SetTimer(3f);
					break;
				}
				Step step = _serverOutboundQueue.Dequeue();
				_orders1.Clear();
				_orders2.Clear();
				_orderCounts.Clear();
				int num = 0;
				for (int i = 0; i < step.boxCount; i++)
				{
					ShiftOrderObject shiftOrderObject = _serverInventory.RemoveRandom();
					if (!shiftOrderObject.GetCanBeStackedOn())
					{
						if (num == 5)
						{
							_orders2.Add(shiftOrderObject);
							continue;
						}
						num++;
					}
					_orderCounts.TryGetValue(shiftOrderObject, out var value);
					if (shiftOrderObject.hasMaxOutboundCount && value >= shiftOrderObject.maxOutboundCount)
					{
						_orders2.Add(shiftOrderObject);
						continue;
					}
					_orders1.Add(shiftOrderObject);
					value++;
					_orderCounts[shiftOrderObject] = value;
				}
				for (int j = 0; j < _orders2.Count; j++)
				{
					_serverInventory.Add(_orders2[j]);
				}
				outboundBay.ServerSetOutboundOrder(_orders1);
				if (_serverOutboundQueue.Count > 0)
				{
					_serverOutboundTimer.SetTimer(_serverOutboundQueue.Peek().frames);
				}
				if (step.isEmissionStart)
				{
					_serverOutboundEmissionCount++;
				}
			}
		}
	}

	[Server]
	public void ServerPrepareForShift(int shift, out int numberOfTrucks, out int numberOfBoxesShipped, out OrderCount[] inboundOrders)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void WarehouseManager::ServerPrepareForShift(System.Int32,System.Int32&,System.Int32&,OrderCount[]&)' called when server was not active");
			numberOfTrucks = default(int);
			numberOfBoxesShipped = default(int);
			inboundOrders = null;
			return;
		}
		Unity.Mathematics.Random random = MathUtil.GetRandom(_serverInvSeed, shift);
		_serverInboundDeck.Clear();
		List<OrderCount> list = new List<OrderCount>();
		float playerMultiplier = GameUtil.contract.GetPlayerMultiplier(_serverPlayerCount);
		ContractShift contractShift = GameUtil.contract.GetContractShift(shift);
		switch (GameUtil.contract.type)
		{
		case ContractType.Explicit:
		{
			for (int j = 0; j < contractShift.orders.Length; j++)
			{
				ContractShift.Order order2 = contractShift.orders[j];
				if (order2 != null)
				{
					_serverInboundDeck.AddCard(order2.order, order2.cardCount);
					list.Add(new OrderCount
					{
						order = order2.order,
						count = order2.cardCount
					});
				}
			}
			break;
		}
		case ContractType.Random:
		{
			for (int i = 0; i < contractShift.orders.Length; i++)
			{
				ContractShift.Order order = contractShift.orders[i];
				if (order != null)
				{
					_serverInboundDeck.AddCard(GameUtil.orders[order.randomOrderIndex], order.cardCount);
					list.Add(new OrderCount
					{
						order = GameUtil.orders[order.randomOrderIndex],
						count = order.cardCount
					});
				}
			}
			break;
		}
		default:
			throw new InvalidEnumException();
		}
		ContractShift.Inbound[] inbound = contractShift.inbound;
		ContractShift.Outbound[] outbound = contractShift.outbound;
		inboundOrders = list.ToArray();
		_serverInboundQueue.Clear();
		_serverOutboundQueue.Clear();
		int outboundMaxNumberOfFrames = ContractUtil.GetOutboundMaxNumberOfFrames(outbound);
		int num = 0;
		bool spawnBingBong = !GameUtil.isGym && !GameUtil.isTutorial && random.NextFloat() <= bingBongChance;
		int num2 = random.NextInt(0, inbound.Length);
		float num3 = 0f;
		for (int k = 0; k < inbound.Length; k++)
		{
			ContractShift.Inbound inbound2 = inbound[k];
			Step item = new Step
			{
				isEmissionStart = true
			};
			int num4 = (int)(inbound2.normalizedTime * (float)outboundMaxNumberOfFrames);
			item.frames = num4 - num;
			num = num4;
			if (playerMultiplier != 1f)
			{
				for (int l = 0; l < inbound2.bayCount; l++)
				{
					if (k == num2 && l == 0)
					{
						item.spawnBingBong = spawnBingBong;
					}
					else
					{
						item.spawnBingBong = false;
					}
					num3 += (float)inbound2.boxCount * playerMultiplier;
					item.boxCount = Mathf.CeilToInt(num3);
					num3 -= (float)item.boxCount;
					_serverInboundQueue.Enqueue(item);
					item.frames = 0;
					item.isEmissionStart = false;
				}
				continue;
			}
			item.boxCount = inbound2.boxCount;
			for (int m = 0; m < inbound2.bayCount; m++)
			{
				if (k == num2 && m == 0)
				{
					item.spawnBingBong = spawnBingBong;
				}
				else
				{
					item.spawnBingBong = false;
				}
				_serverInboundQueue.Enqueue(item);
				item.frames = 0;
				item.isEmissionStart = false;
			}
		}
		num3 = 0f;
		numberOfBoxesShipped = 0;
		foreach (ContractShift.Outbound outbound2 in outbound)
		{
			Step item2 = new Step
			{
				isEmissionStart = true,
				frames = TimeUtil.FramesForTime(outbound2.secondsFromPrevious)
			};
			if (playerMultiplier != 1f)
			{
				for (int num5 = 0; num5 < outbound2.bayCount; num5++)
				{
					num3 += (float)outbound2.boxCount * playerMultiplier;
					item2.boxCount = Mathf.CeilToInt(num3);
					num3 -= (float)item2.boxCount;
					_serverOutboundQueue.Enqueue(item2);
					item2.isEmissionStart = false;
					item2.frames = 0;
				}
			}
			else
			{
				item2.boxCount = outbound2.boxCount;
				for (int num6 = 0; num6 < outbound2.bayCount; num6++)
				{
					_serverOutboundQueue.Enqueue(item2);
					item2.isEmissionStart = false;
					item2.frames = 0;
				}
			}
			numberOfBoxesShipped += item2.boxCount;
		}
		_serverInboundTimer.SetTimer(_serverInboundQueue.Peek().frames);
		_serverOutboundTimer.SetTimer(_serverOutboundQueue.Peek().frames);
		numberOfTrucks = ContractUtil.GetTruckCount(outbound);
	}

	[Server]
	public void ServerDevCmdCompleteOutbounds()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void WarehouseManager::ServerDevCmdCompleteOutbounds()' called when server was not active");
			return;
		}
		_serverOutboundQueue.Clear();
		ObjectQuery<OutboundBay> objectQuery = base.entityManager.CreateObjectQuery<OutboundBay>();
		objectQuery.Run();
		for (int i = 0; i < objectQuery.count; i++)
		{
			objectQuery[i].ServerDevCmdComplete();
		}
	}

	[Server]
	public void ServerDevCmdBringOutbound()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void WarehouseManager::ServerDevCmdBringOutbound()' called when server was not active");
		}
		else
		{
			_serverOutboundTimer.Clear();
		}
	}

	[Server]
	public void ServerDevCmdBringInbound()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void WarehouseManager::ServerDevCmdBringInbound()' called when server was not active");
		}
		else
		{
			_serverInboundTimer.Clear();
		}
	}

	[Server]
	public void ServerBoxCreated(Entity e)
	{
		NetworkIdentity obj;
		ShiftOrderObject value;
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void WarehouseManager::ServerBoxCreated(Aggro.Core.Entity)' called when server was not active");
		}
		else if (e.TryGetObject<NetworkIdentity>(out obj) && _idToBoxes.TryGetValue(obj.assetId, out value))
		{
			ServerOrderAdded(value);
		}
	}

	[Server]
	public void ServerOrderAdded(ShiftOrderObject order)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void WarehouseManager::ServerOrderAdded(ShiftOrderObject)' called when server was not active");
		}
		else
		{
			_serverInventory.Add(order);
		}
	}

	[Server]
	public void ServerBoxDestroyed(Entity e)
	{
		NetworkIdentity obj;
		ShiftOrderObject value;
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void WarehouseManager::ServerBoxDestroyed(Aggro.Core.Entity)' called when server was not active");
		}
		else if (e.TryGetObject<NetworkIdentity>(out obj) && _idToBoxes.TryGetValue(obj.assetId, out value))
		{
			_serverDestroyed.Enqueue(value);
			if (_serverInboundQueue.Count == 0)
			{
				_serverInboundQueue.Enqueue(default(Step));
				_serverInboundTimer.SetTimer(3f);
			}
		}
	}

	[Server]
	public void ServerOrderRemoved(ShiftOrderObject order)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void WarehouseManager::ServerOrderRemoved(ShiftOrderObject)' called when server was not active");
		}
		else
		{
			_serverInventory.Remove(order);
		}
	}

	[Server]
	public bool ServerHasOrder(ShiftOrderObject order)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Boolean WarehouseManager::ServerHasOrder(ShiftOrderObject)' called when server was not active");
			return default(bool);
		}
		return _serverInventory.Has(order);
	}

	[ClientRpc]
	private void RpcOrderSeen(uint id)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarUInt(id);
		SendRPCInternal("System.Void WarehouseManager::RpcOrderSeen(System.UInt32)", 1208164067, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public bool TryGetOrderObject(GameObject obj, out ShiftOrderObject order)
	{
		if (obj != null && obj.TryGetComponent<NetworkIdentity>(out var component))
		{
			return _idToBoxes.TryGetValue(component.assetId, out order);
		}
		order = null;
		return false;
	}

	public void TutorialSetOrders(List<ShiftOrderObject> orders)
	{
		for (int i = 0; i < orders.Count; i++)
		{
			ShiftOrderObject shiftOrderObject = orders[i];
			if (shiftOrderObject.TryGetAssetId(out var assetId))
			{
				_idToBoxes[assetId] = shiftOrderObject;
			}
		}
	}

	public void AddToOrders(ShiftOrderObject order)
	{
		if (order.TryGetAssetId(out var assetId))
		{
			_idToBoxes[assetId] = order;
		}
	}

	static WarehouseManager()
	{
		_orders1 = new List<ShiftOrderObject>();
		_orders2 = new List<ShiftOrderObject>();
		_bools = new List<bool>();
		_orderCounts = new Dictionary<ShiftOrderObject, int>();
		RemoteProcedureCalls.RegisterRpc(typeof(WarehouseManager), "System.Void WarehouseManager::RpcOrderSeen(System.UInt32)", InvokeUserCode_RpcOrderSeen__UInt32);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_RpcOrderSeen__UInt32(uint id)
	{
		if (_idToBoxes.TryGetValue(id, out var value))
		{
			_ordersSeen.Add(value);
		}
	}

	protected static void InvokeUserCode_RpcOrderSeen__UInt32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcOrderSeen called on server.");
		}
		else
		{
			((WarehouseManager)obj).UserCode_RpcOrderSeen__UInt32(reader.ReadVarUInt());
		}
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteFloat(timerParam);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteFloat(timerParam);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref timerParam, null, reader.ReadFloat());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref timerParam, null, reader.ReadFloat());
		}
	}
}
