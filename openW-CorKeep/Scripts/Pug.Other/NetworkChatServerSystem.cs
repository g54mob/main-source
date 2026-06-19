using Unity.Collections;
using Unity.Entities;
using Unity.NetCode;
using UnityEngine;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
[RequireMatchingQueriesForUpdate]
public class NetworkChatServerSystem : SystemBase
{
	private struct RemapData
	{
		public int newMessageNumber;

		public int dataMessagesProcessed;

		public int totalDataMessages;

		public Entity receivedFrom;
	}

	private int messageCount;

	private EntityQuery receiveMessageQ;

	private EntityQuery receiveDataMessageQ;

	private NativeParallelHashMap<int, RemapData> remapDatas;

	[Preserve]
	protected override void OnCreate()
	{
		receiveMessageQ = GetEntityQuery(ComponentType.ReadOnly<NetworkCommMessageRPC>(), ComponentType.Exclude<SendRpcCommandRequest>());
		receiveDataMessageQ = GetEntityQuery(ComponentType.ReadOnly<NetworkCommDataMessageRPC>(), ComponentType.Exclude<SendRpcCommandRequest>());
		remapDatas = new NativeParallelHashMap<int, RemapData>(1024, Allocator.Persistent);
		base.OnCreate();
	}

	[Preserve]
	protected override void OnDestroy()
	{
		remapDatas.Dispose();
		base.OnDestroy();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		using NativeArray<Entity> nativeArray = receiveMessageQ.ToEntityArray(Allocator.Temp);
		using NativeArray<Entity> nativeArray2 = receiveDataMessageQ.ToEntityArray(Allocator.Temp);
		for (int i = 0; i < nativeArray.Length; i++)
		{
			Entity entity = Entity.Null;
			if (HasComponent<ReceiveRpcCommandRequest>(nativeArray[i]))
			{
				entity = GetComponent<ReceiveRpcCommandRequest>(nativeArray[i]).SourceConnection;
				base.EntityManager.RemoveComponent<ReceiveRpcCommandRequest>(nativeArray[i]);
			}
			NetworkCommMessageRPC component = GetComponent<NetworkCommMessageRPC>(nativeArray[i]);
			int num = ++messageCount;
			if (component.totalSize != 0)
			{
				RemapData item = new RemapData
				{
					newMessageNumber = num,
					receivedFrom = entity,
					dataMessagesProcessed = 0,
					totalDataMessages = (component.totalSize - 1) / 64 + 1
				};
				remapDatas.Add(component.messageNumber, item);
			}
			component.messageNumber = num;
			SetComponent(nativeArray[i], component);
			if (entity != Entity.Null)
			{
				base.EntityManager.AddComponentData(nativeArray[i], new SendRpcToNearbyPlayers
				{
					distance = float.PositiveInfinity,
					connection = entity
				});
			}
			else
			{
				base.EntityManager.AddComponent<SendRpcCommandRequest>(nativeArray[i]);
			}
		}
		for (int j = 0; j < nativeArray2.Length; j++)
		{
			NetworkCommDataMessageRPC component2 = GetComponent<NetworkCommDataMessageRPC>(nativeArray2[j]);
			if (!remapDatas.ContainsKey(component2.messageNumber))
			{
				Debug.LogError("data message missing from remap");
				base.EntityManager.DestroyEntity(nativeArray2[j]);
				continue;
			}
			RemapData value = remapDatas[component2.messageNumber];
			value.dataMessagesProcessed++;
			if (value.dataMessagesProcessed == value.totalDataMessages)
			{
				remapDatas.Remove(component2.messageNumber);
			}
			else
			{
				remapDatas[component2.messageNumber] = value;
			}
			component2.messageNumber = value.newMessageNumber;
			SetComponent(nativeArray2[j], component2);
			if (HasComponent<ReceiveRpcCommandRequest>(nativeArray2[j]))
			{
				base.EntityManager.RemoveComponent<ReceiveRpcCommandRequest>(nativeArray2[j]);
			}
			if (!HasComponent<SendRpcCommandRequest>(nativeArray2[j]) && !HasComponent<SendRpcToNearbyPlayers>(nativeArray2[j]))
			{
				if (value.receivedFrom != Entity.Null)
				{
					base.EntityManager.AddComponentData(nativeArray2[j], new SendRpcToNearbyPlayers
					{
						distance = float.PositiveInfinity,
						connection = value.receivedFrom
					});
				}
				else
				{
					base.EntityManager.AddComponent<SendRpcCommandRequest>(nativeArray2[j]);
				}
			}
		}
	}

	[Preserve]
	public NetworkChatServerSystem()
	{
	}
}
