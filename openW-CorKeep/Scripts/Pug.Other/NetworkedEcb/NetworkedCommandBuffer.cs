using System;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using UnityEngine;

namespace NetworkedEcb
{
	public struct NetworkedCommandBuffer : IDisposable
	{
		public struct ParallelWriter
		{
			internal readonly uint transactionBase;

			internal bool hasCreatedTransaction;

			internal NativeQueue<NetworkedEcbRpc>.ParallelWriter queue;

			public void AddComponent<T>(int sortKey, Entity entity) where T : unmanaged, IComponentData
			{
				queue.Enqueue(PrepareAddComponent(entity, typeof(T)));
			}

			public void AddComponent(int sortKey, Entity entity, ComponentType type)
			{
				queue.Enqueue(PrepareAddComponent(entity, type));
			}

			public void AddComponent<T>(int sortKey, Entity entity, T component) where T : unmanaged, IComponentData
			{
				queue.Enqueue(PrepareSetComponent(entity, component, withAdd: true));
			}

			public void SetComponent<T>(int sortKey, Entity entity, T component) where T : unmanaged, IComponentData
			{
				queue.Enqueue(PrepareSetComponent(entity, component));
			}

			public void RemoveComponent<T>(int sortKey, Entity entity) where T : unmanaged, IComponentData
			{
				queue.Enqueue(PrepareRemoveComponent(entity, typeof(T)));
			}

			public void RemoveComponent(int sortKey, Entity entity, ComponentType type)
			{
				queue.Enqueue(PrepareRemoveComponent(entity, type));
			}
		}

		internal NativeQueue<NetworkedEcbRpc> queue;

		public void Dispose()
		{
			if (queue.IsCreated)
			{
				queue.Dispose();
			}
		}

		public void AddComponent<T>(Entity entity) where T : unmanaged, IComponentData
		{
			queue.Enqueue(PrepareAddComponent(entity, typeof(T)));
		}

		public void AddComponent(Entity entity, ComponentType type)
		{
			queue.Enqueue(PrepareAddComponent(entity, type));
		}

		public void AddComponent<T>(Entity entity, T component) where T : unmanaged, IComponentData
		{
			queue.Enqueue(PrepareSetComponent(entity, component, withAdd: true));
		}

		public void SetComponent<T>(Entity entity, T component) where T : unmanaged, IComponentData
		{
			queue.Enqueue(PrepareSetComponent(entity, component));
		}

		public void RemoveComponent<T>(Entity entity) where T : unmanaged, IComponentData
		{
			queue.Enqueue(PrepareRemoveComponent(entity, typeof(T)));
		}

		public void RemoveComponent(Entity entity, ComponentType type)
		{
			queue.Enqueue(PrepareRemoveComponent(entity, type));
		}

		public ParallelWriter AsParallelWriter()
		{
			return new ParallelWriter
			{
				queue = queue.AsParallelWriter()
			};
		}

		internal static NetworkedEcbRpc CreateRpc(NetworkedEcbCommand command)
		{
			return new NetworkedEcbRpc
			{
				command = command
			};
		}

		internal unsafe static void PrepareComponentData<T>(ref NetworkedEcbRpc rpc, T component) where T : unmanaged, IComponentData
		{
			int num = UnsafeUtility.SizeOf<T>();
			if (num > 64)
			{
				Debug.LogError($"Your component {typeof(T)} is too damn fat");
				return;
			}
			UnsafeUtility.MemCpy(rpc.data.GetUnsafePtr(), &component, num);
			rpc.dataLength = num;
		}

		internal static NetworkedEcbRpc PrepareAddComponent(Entity entity, ComponentType type)
		{
			NetworkedEcbRpc result = CreateRpc(NetworkedEcbCommand.AddComponent);
			result.entity = entity;
			result.componentTypeHash = TypeManager.GetTypeInfo(type.TypeIndex).StableTypeHash;
			return result;
		}

		internal static NetworkedEcbRpc PrepareSetComponent<T>(Entity entity, T component, bool withAdd = false) where T : unmanaged, IComponentData
		{
			NetworkedEcbRpc rpc = CreateRpc((!withAdd) ? NetworkedEcbCommand.SetComponent : NetworkedEcbCommand.AddAndSetComponent);
			rpc.entity = entity;
			rpc.componentTypeHash = TypeManager.GetTypeInfo(((ComponentType)typeof(T)).TypeIndex).StableTypeHash;
			PrepareComponentData(ref rpc, component);
			return rpc;
		}

		internal static NetworkedEcbRpc PrepareRemoveComponent(Entity entity, ComponentType type)
		{
			NetworkedEcbRpc result = CreateRpc(NetworkedEcbCommand.RemoveComponent);
			result.entity = entity;
			result.componentTypeHash = TypeManager.GetTypeInfo(type.TypeIndex).StableTypeHash;
			return result;
		}
	}
}
