using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.NetCode;
using UnityEngine;
using UnityEngine.Scripting;

namespace NetworkedEcb
{
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
	[UpdateInGroup(typeof(RunSimulationSystemGroup))]
	public class ServerReceiveSystem : SystemBase
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private struct Transaction
		{
		}

		private EntityQuery query;

		private NativeParallelHashMap<uint, Transaction> transactions;

		[Preserve]
		protected override void OnCreate()
		{
			query = GetEntityQuery(typeof(NetworkedEcbRpc), typeof(ReceiveRpcCommandRequest));
			transactions = new NativeParallelHashMap<uint, Transaction>(256, Allocator.Persistent);
			base.OnCreate();
		}

		[Preserve]
		protected override void OnDestroy()
		{
			transactions.Dispose();
			base.OnDestroy();
		}

		private unsafe void SetComponent(ComponentType componentType, NetworkedEcbRpc ecbRpc)
		{
			if (componentType.IsZeroSized)
			{
				return;
			}
			Entity entity = ecbRpc.entity;
			ArchetypeChunk chunk = base.EntityManager.GetChunk(entity);
			DynamicComponentTypeHandle dynamicComponentTypeHandle = GetDynamicComponentTypeHandle(componentType);
			if (!chunk.Has(dynamicComponentTypeHandle))
			{
				return;
			}
			NativeArray<Entity> nativeArray = chunk.GetNativeArray(GetEntityTypeHandle());
			for (int i = 0; i < nativeArray.Length; i++)
			{
				if (nativeArray[i].Equals(entity))
				{
					NativeArray<byte> dynamicComponentDataArrayReinterpret = chunk.GetDynamicComponentDataArrayReinterpret<byte>(dynamicComponentTypeHandle, ecbRpc.dataLength);
					int num = ecbRpc.dataLength * i;
					if (dynamicComponentDataArrayReinterpret.Length < num + ecbRpc.dataLength)
					{
						Debug.LogError("out of bounds array access");
						break;
					}
					UnsafeUtility.MemCpy((byte*)dynamicComponentDataArrayReinterpret.GetUnsafePtr() + num, ecbRpc.data.GetUnsafePtr(), ecbRpc.dataLength);
				}
			}
		}

		[Preserve]
		protected override void OnUpdate()
		{
			if (query.IsEmpty)
			{
				return;
			}
			base.EntityManager.CompleteAllTrackedJobs();
			NativeArray<Entity> entities = query.ToEntityArray(Allocator.Temp);
			for (int i = 0; i < entities.Length; i++)
			{
				NetworkedEcbRpc component = GetComponent<NetworkedEcbRpc>(entities[i]);
				ComponentType componentType = ComponentType.FromTypeIndex(TypeManager.GetTypeIndexFromStableTypeHash(component.componentTypeHash));
				if (component.entity == Entity.Null || !base.EntityManager.Exists(component.entity) || EntityUtility.EntityIsDeferred(component.entity))
				{
					Debug.LogWarning("got non-existing entity in rpc");
					continue;
				}
				switch (component.command)
				{
				case NetworkedEcbCommand.SetComponent:
					if (base.EntityManager.HasComponent(component.entity, componentType))
					{
						SetComponent(componentType, component);
					}
					else
					{
						Debug.LogWarning("net ecb SetComponent: no such component on entity");
					}
					break;
				case NetworkedEcbCommand.AddComponent:
					if (!base.EntityManager.HasComponent(component.entity, componentType))
					{
						base.EntityManager.AddComponent(component.entity, componentType);
					}
					else
					{
						Debug.LogWarning("net ecb AddComponent: component exists already on entity");
					}
					break;
				case NetworkedEcbCommand.AddAndSetComponent:
					if (!base.EntityManager.HasComponent(component.entity, componentType))
					{
						base.EntityManager.AddComponent(component.entity, componentType);
					}
					else
					{
						Debug.LogWarning("net ecb AddAndSetComponent: component exists already on entity");
					}
					SetComponent(componentType, component);
					break;
				case NetworkedEcbCommand.RemoveComponent:
					if (base.EntityManager.HasComponent(component.entity, componentType))
					{
						base.EntityManager.RemoveComponent(component.entity, componentType);
					}
					else
					{
						Debug.LogWarning("net ecb RemoveComponent: no such component on entity");
					}
					break;
				default:
					Debug.LogError($"unsupported command: {component.command}");
					break;
				}
			}
			base.EntityManager.DestroyEntity(entities);
			entities.Dispose();
		}

		[Preserve]
		public ServerReceiveSystem()
		{
		}
	}
}
