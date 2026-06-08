using System;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public struct EntityContext : IDisposable
	{
		private enum EntityContextMode
		{
			EntityManager = 0,
			EntityCommandBuffer = 1,
			Parallel = 2
		}

		private EntityContextMode Mode;

		private EntityManager Manager;

		private EntityCommandBuffer ECB;

		private EntityCommandBuffer.ParallelWriter ECBPW;

		private int SortKey;

		private bool PlaybackOnDispose;

		public EntityContext(EntityManager manager)
		{
			Mode = EntityContextMode.EntityManager;
			Manager = manager;
			ECB = default(EntityCommandBuffer);
			ECBPW = default(EntityCommandBuffer.ParallelWriter);
			SortKey = 0;
			PlaybackOnDispose = false;
		}

		public EntityContext(EntityManager manager, EntityCommandBuffer ecb)
		{
			Mode = EntityContextMode.EntityCommandBuffer;
			Manager = manager;
			ECB = ecb;
			ECBPW = default(EntityCommandBuffer.ParallelWriter);
			SortKey = 0;
			PlaybackOnDispose = false;
		}

		public EntityContext(EntityManager manager, EntityCommandBuffer.ParallelWriter ecbpw, int index)
		{
			Mode = EntityContextMode.Parallel;
			Manager = manager;
			ECB = default(EntityCommandBuffer);
			ECBPW = ecbpw;
			SortKey = index;
			PlaybackOnDispose = false;
		}

		public EntityContext(EntityManager manager, EntityCommandBufferSystem system)
		{
			Mode = EntityContextMode.EntityCommandBuffer;
			Manager = manager;
			ECB = system.CreateCommandBuffer();
			ECBPW = default(EntityCommandBuffer.ParallelWriter);
			SortKey = 0;
			PlaybackOnDispose = false;
		}

		public static EntityContext WithTemporaryBuffer(EntityManager manager)
		{
			EntityContext result = new EntityContext(manager, new EntityCommandBuffer(Allocator.Temp));
			result.PlaybackOnDispose = true;
			return result;
		}

		public Entity CreateEntity()
		{
			return Mode switch
			{
				EntityContextMode.EntityManager => Manager.CreateEntity(), 
				EntityContextMode.EntityCommandBuffer => ECB.CreateEntity(), 
				EntityContextMode.Parallel => ECBPW.CreateEntity(SortKey), 
				_ => default(Entity), 
			};
		}

		public Entity CreateEntity(EntityArchetype archetype)
		{
			return Mode switch
			{
				EntityContextMode.EntityManager => Manager.CreateEntity(archetype), 
				EntityContextMode.EntityCommandBuffer => ECB.CreateEntity(archetype), 
				EntityContextMode.Parallel => ECBPW.CreateEntity(SortKey, archetype), 
				_ => default(Entity), 
			};
		}

		public void Remove<T>(Entity entity) where T : struct, IComponentData
		{
			switch (Mode)
			{
			case EntityContextMode.EntityManager:
				Manager.RemoveComponent<T>(entity);
				break;
			case EntityContextMode.EntityCommandBuffer:
				ECB.RemoveComponent<T>(entity);
				break;
			case EntityContextMode.Parallel:
				ECBPW.RemoveComponent<T>(SortKey, entity);
				break;
			}
		}

		public void Remove<T>(EntityQuery query) where T : struct, IComponentData
		{
			switch (Mode)
			{
			case EntityContextMode.EntityManager:
				Manager.RemoveComponent<T>(query);
				break;
			case EntityContextMode.EntityCommandBuffer:
				ECB.RemoveComponent<T>(query);
				break;
			case EntityContextMode.Parallel:
			{
				Debug.Log("Using a RemoveComponent(EntityQuery) on a PW");
				NativeArray<Entity> nativeArray = query.ToEntityArray(Allocator.TempJob);
				int length = nativeArray.Length;
				for (int i = 0; i < length; i++)
				{
					ECBPW.RemoveComponent<T>(SortKey, nativeArray[i]);
				}
				break;
			}
			}
		}

		public void Add<T>(Entity entity) where T : struct, IComponentData
		{
			switch (Mode)
			{
			case EntityContextMode.EntityManager:
				Manager.AddComponent<T>(entity);
				break;
			case EntityContextMode.EntityCommandBuffer:
				ECB.AddComponent<T>(entity);
				break;
			case EntityContextMode.Parallel:
				ECBPW.AddComponent<T>(SortKey, entity);
				break;
			}
		}

		public void Add<T>(EntityQuery query) where T : struct, IComponentData
		{
			switch (Mode)
			{
			case EntityContextMode.EntityManager:
				Manager.AddComponent<T>(query);
				break;
			case EntityContextMode.EntityCommandBuffer:
				ECB.AddComponent<T>(query);
				break;
			case EntityContextMode.Parallel:
			{
				Debug.Log("Using a AddComponent(EntityQuery) on a PW");
				NativeArray<Entity> nativeArray = query.ToEntityArray(Allocator.TempJob);
				int length = nativeArray.Length;
				for (int i = 0; i < length; i++)
				{
					ECBPW.AddComponent<T>(SortKey, nativeArray[i]);
				}
				break;
			}
			}
		}

		public void Ensure<T>(Entity entity, bool should_exist = true) where T : struct, IComponentData
		{
			if (should_exist)
			{
				if (!Has<T>(entity))
				{
					Add<T>(entity);
				}
			}
			else if (Has<T>(entity))
			{
				Remove<T>(entity);
			}
		}

		public void Ensure<T>(T data, bool should_exist = true) where T : struct, IComponentData
		{
			Entity value;
			bool flag = Manager.World.GetOrCreateSystem<EntityContextUtilitySystem>().TryGetSingletonEntity<T>(out value);
			if (should_exist)
			{
				if (!flag)
				{
					Entity entity = Manager.CreateEntity();
					Manager.AddComponent<T>(entity);
				}
				Set(data);
			}
			else if (flag)
			{
				Destroy(value);
			}
		}

		public T Get<T>() where T : struct, IComponentData
		{
			return Manager.World.GetOrCreateSystem<EntityContextUtilitySystem>().GetSingleton<T>();
		}

		public Entity GetEntity<T>() where T : struct, IComponentData
		{
			return Manager.World.GetOrCreateSystem<EntityContextUtilitySystem>().GetSingletonEntity<T>();
		}

		public void Set<T>(T data) where T : struct, IComponentData
		{
			EntityContextUtilitySystem orCreateSystem = Manager.World.GetOrCreateSystem<EntityContextUtilitySystem>();
			switch (Mode)
			{
			case EntityContextMode.EntityManager:
				orCreateSystem.SetSingleton(data);
				break;
			case EntityContextMode.EntityCommandBuffer:
			case EntityContextMode.Parallel:
			{
				Entity singletonEntity = orCreateSystem.GetSingletonEntity<T>();
				Set(singletonEntity, data);
				break;
			}
			}
		}

		public void Set<T>(Entity entity, T data) where T : struct, IComponentData
		{
			switch (Mode)
			{
			case EntityContextMode.EntityManager:
				if (entity.Index >= 0)
				{
					Ensure<T>(entity);
				}
				if (TypeManager.GetTypeInfo(TypeManager.GetTypeIndex<T>()).IsZeroSized)
				{
					Manager.AddComponent(entity, typeof(T));
				}
				else
				{
					Manager.SetComponentData(entity, data);
				}
				break;
			case EntityContextMode.EntityCommandBuffer:
				ECB.AddComponent(entity, data);
				break;
			case EntityContextMode.Parallel:
				ECBPW.AddComponent(SortKey, entity, data);
				break;
			}
		}

		public DynamicBuffer<T> ClearBuffer<T>(Entity entity) where T : struct, IBufferElementData
		{
			switch (Mode)
			{
			case EntityContextMode.EntityManager:
			{
				DynamicBuffer<T> buffer = Manager.GetBuffer<T>(entity);
				buffer.Clear();
				return buffer;
			}
			case EntityContextMode.EntityCommandBuffer:
				return ECB.SetBuffer<T>(entity);
			case EntityContextMode.Parallel:
				return ECBPW.SetBuffer<T>(SortKey, entity);
			default:
				return default(DynamicBuffer<T>);
			}
		}

		public DynamicBuffer<T> AddBuffer<T>(Entity entity) where T : struct, IBufferElementData
		{
			return Mode switch
			{
				EntityContextMode.EntityManager => Manager.AddBuffer<T>(entity), 
				EntityContextMode.EntityCommandBuffer => ECB.AddBuffer<T>(entity), 
				EntityContextMode.Parallel => ECBPW.AddBuffer<T>(SortKey, entity), 
				_ => default(DynamicBuffer<T>), 
			};
		}

		public void AppendToBuffer<T>(Entity entity, T elem) where T : struct, IBufferElementData
		{
			switch (Mode)
			{
			case EntityContextMode.EntityManager:
				Manager.GetBuffer<T>(entity).Add(elem);
				break;
			case EntityContextMode.EntityCommandBuffer:
				ECB.AppendToBuffer(entity, elem);
				break;
			case EntityContextMode.Parallel:
				ECBPW.AppendToBuffer(SortKey, entity, elem);
				break;
			}
		}

		public void Destroy(Entity entity)
		{
			switch (Mode)
			{
			case EntityContextMode.EntityManager:
				Manager.DestroyEntity(entity);
				break;
			case EntityContextMode.EntityCommandBuffer:
				ECB.DestroyEntity(entity);
				break;
			case EntityContextMode.Parallel:
				ECBPW.DestroyEntity(SortKey, entity);
				break;
			}
		}

		public void Destroy<T>() where T : struct, IComponentData
		{
			if (Manager.World.GetOrCreateSystem<EntityContextUtilitySystem>().TryGetSingletonEntity<T>(out var value))
			{
				Destroy(value);
			}
		}

		public DynamicBuffer<T> GetBuffer<T>(Entity entity) where T : struct, IBufferElementData
		{
			return Manager.GetBuffer<T>(entity);
		}

		public TOut[] GetBufferAs<TBuf, TOut>(Entity entity, Func<TBuf, TOut> map) where TBuf : struct, IBufferElementData
		{
			DynamicBuffer<TBuf> buffer = Manager.GetBuffer<TBuf>(entity);
			TOut[] array = new TOut[buffer.Length];
			for (int i = 0; i < buffer.Length; i++)
			{
				array[i] = map(buffer[i]);
			}
			return array;
		}

		public T Get<T>(Entity entity) where T : struct, IComponentData
		{
			return Manager.GetComponentData<T>(entity);
		}

		public T GetOrDefault<T>(Entity entity) where T : struct, IComponentData
		{
			if (!Manager.HasComponent<T>(entity))
			{
				return default(T);
			}
			return Manager.GetComponentData<T>(entity);
		}

		public bool Has<T>(Entity entity) where T : struct, IComponentData
		{
			return Manager.HasComponent<T>(entity);
		}

		public bool Has<T>() where T : struct, IComponentData
		{
			return Manager.World.GetOrCreateSystem<EntityContextUtilitySystem>().HasSingleton<T>();
		}

		public bool Require<T>(out T comp) where T : struct, IComponentData
		{
			EntityContextUtilitySystem orCreateSystem = Manager.World.GetOrCreateSystem<EntityContextUtilitySystem>();
			if (orCreateSystem.HasSingleton<T>())
			{
				comp = orCreateSystem.GetSingleton<T>();
				return true;
			}
			comp = default(T);
			return false;
		}

		public bool RequireEntity<T>(out Entity comp) where T : struct, IComponentData
		{
			EntityContextUtilitySystem orCreateSystem = Manager.World.GetOrCreateSystem<EntityContextUtilitySystem>();
			if (orCreateSystem.HasSingleton<T>())
			{
				comp = orCreateSystem.GetSingletonEntity<T>();
				return true;
			}
			comp = default(Entity);
			return false;
		}

		public bool Require<T>(Entity entity, out T comp) where T : struct, IComponentData
		{
			if (entity.Index < 0)
			{
				comp = default(T);
				return false;
			}
			if (Manager.HasComponent<T>(entity))
			{
				comp = Get<T>(entity);
				return true;
			}
			comp = default(T);
			return false;
		}

		public bool RequireBuffer<T>(Entity entity, out DynamicBuffer<T> comp) where T : struct, IBufferElementData
		{
			if (entity.Index < 0)
			{
				comp = default(DynamicBuffer<T>);
				return false;
			}
			if (Manager.HasComponent<T>(entity))
			{
				comp = GetBuffer<T>(entity);
				return true;
			}
			comp = default(DynamicBuffer<T>);
			return false;
		}

		public void Playback()
		{
			switch (Mode)
			{
			case EntityContextMode.EntityCommandBuffer:
				ECB.Playback(Manager);
				break;
			case EntityContextMode.Parallel:
				throw new ArgumentException("Can't playback a parallel ECB");
			case EntityContextMode.EntityManager:
				break;
			}
		}

		public void Dispose()
		{
			if (ECB.IsCreated)
			{
				if (PlaybackOnDispose)
				{
					Playback();
				}
				ECB.Dispose();
			}
		}

		public static implicit operator EntityContext(EntityManager em)
		{
			return new EntityContext(em);
		}
	}
}
