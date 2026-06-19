using System.Collections.Generic;
using Aggro.Core;
using Aggro.Core.Networking;
using Mirror;
using Mirror.RemoteCalls;
using Unity.Mathematics;
using UnityEngine;

public class InboundBay : NetworkEntityBehaviourBase
{
	private struct Order
	{
		public GameObject prefab;

		public Quaternion rotation;
	}

	public enum BayState : byte
	{
		None = 0,
		Inbound = 1
	}

	public Transform inboundTransform;

	[Min(0f)]
	public float inboundCheckRadius = 1.5f;

	[Space]
	public Transform notifTransform;

	private Queue<Order> _orders = new Queue<Order>();

	private static Collider[] _colliders;

	private static List<Order> _orderList;

	public BayState serverState { get; private set; }

	protected override void OnUpdateSimulation()
	{
		if (!base.isServer)
		{
			return;
		}
		if (_orders.Count > 0)
		{
			if (Physics.OverlapSphereNonAlloc(inboundTransform.position, inboundCheckRadius, _colliders, 16384) == 0)
			{
				Order order = _orders.Dequeue();
				EntityUtil.Instantiate(order.prefab, inboundTransform.position, order.rotation);
			}
		}
		else
		{
			serverState = BayState.None;
		}
	}

	[Server]
	public void ServerBringInOrders(List<ShiftOrderObject> orders, int seed)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void InboundBay::ServerBringInOrders(System.Collections.Generic.List`1<ShiftOrderObject>,System.Int32)' called when server was not active");
			return;
		}
		Unity.Mathematics.Random random = MathUtil.GetRandom(seed);
		_orderList.Clear();
		for (int i = 0; i < orders.Count; i++)
		{
			Order item = new Order
			{
				prefab = orders[i].prefab,
				rotation = Quaternion.AngleAxis(random.NextFloat(0f, 360f), Vector3.up)
			};
			_orderList.Add(item);
		}
		if (NetworkAggroManagerBase<ModifierManager>.instance.TryGetModiferAs<ModifierMoreInbound>(out var modifier))
		{
			int num = Mathf.CeilToInt((float)orders.Count * modifier.inboundCountMultiplier);
			for (int j = 0; j < num; j++)
			{
				Order item2 = new Order
				{
					prefab = modifier.ServerGetInboundPrefab(),
					rotation = Quaternion.AngleAxis(random.NextFloat(0f, 360f), Vector3.up)
				};
				_orderList.Add(item2);
			}
			_orderList.Randomize(random.NextInt());
		}
		for (int k = 0; k < _orderList.Count; k++)
		{
			_orders.Enqueue(_orderList[k]);
		}
		serverState = BayState.Inbound;
		RpcQueueEvInboundArrived();
	}

	[ClientRpc]
	private void RpcQueueEvInboundArrived()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void InboundBay::RpcQueueEvInboundArrived()", -672989145, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void OnDrawGizmos()
	{
		if (!(inboundTransform == null))
		{
			Gizmos.color = Color.cyan;
			Gizmos.DrawWireSphere(inboundTransform.position, inboundCheckRadius);
		}
	}

	static InboundBay()
	{
		_colliders = new Collider[8];
		_orderList = new List<Order>();
		RemoteProcedureCalls.RegisterRpc(typeof(InboundBay), "System.Void InboundBay::RpcQueueEvInboundArrived()", InvokeUserCode_RpcQueueEvInboundArrived);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_RpcQueueEvInboundArrived()
	{
		EvInboundArrived ev = new EvInboundArrived
		{
			worldPosition = notifTransform.position
		};
		base.eventManager.QueueGlobalEvent(ev);
		base.entity.GetObject<FloaterPopulator>().AddFloater();
	}

	protected static void InvokeUserCode_RpcQueueEvInboundArrived(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcQueueEvInboundArrived called on server.");
		}
		else
		{
			((InboundBay)obj).UserCode_RpcQueueEvInboundArrived();
		}
	}
}
