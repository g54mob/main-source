using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using Unity.NetCode;

namespace Pug.Conversion
{
	public class BatchedArchetypeChangeECB : IDisposable, GhostPrefabCreation.IEntityManagerWrapper
	{
		private struct EntityBufferType : IEquatable<EntityBufferType>
		{
			public Entity Entity;

			public ComponentType Type;

			public bool Equals(EntityBufferType other)
			{
				if (Entity.Equals(other.Entity))
				{
					return Type.Equals(other.Type);
				}
				return false;
			}

			public override bool Equals(object obj)
			{
				if (obj is EntityBufferType other)
				{
					return Equals(other);
				}
				return false;
			}

			public override int GetHashCode()
			{
				return (Entity.GetHashCode() * 397) ^ Type.GetHashCode();
			}

			public static bool operator ==(EntityBufferType left, EntityBufferType right)
			{
				return left.Equals(right);
			}

			public static bool operator !=(EntityBufferType left, EntityBufferType right)
			{
				return !left.Equals(right);
			}
		}

		private EntityManager _entityManager;

		private EntityCommandBuffer _ecb;

		private Dictionary<Entity, HashSet<ComponentType>> _entityArchetypes = new Dictionary<Entity, HashSet<ComponentType>>();

		private Dictionary<EntityBufferType, int> _bufferLengthLookup = new Dictionary<EntityBufferType, int>();

		public BatchedArchetypeChangeECB(EntityManager entityManager, Allocator allocator)
		{
			_entityManager = entityManager;
			_ecb = new EntityCommandBuffer(allocator);
		}

		public void Dispose()
		{
			_ecb.Dispose();
		}

		public bool HasComponent<T>(Entity entity)
		{
			if (_entityArchetypes.TryGetValue(entity, out var value) && value.Contains(typeof(T)))
			{
				return true;
			}
			return _entityManager.HasComponent<T>(entity);
		}

		public void AddComponent<T>(Entity entity) where T : unmanaged
		{
			AddToArchetype(entity, typeof(T));
		}

		public void AddComponent<T>(Entity entity, T componentData) where T : unmanaged, IComponentData
		{
			AddToArchetype(entity, typeof(T));
			_ecb.SetComponent(entity, componentData);
		}

		public void RemoveComponent<T>(Entity entity) where T : unmanaged, IComponentData
		{
			RemoveFromArchetype(entity, typeof(T));
		}

		public void RemoveComponent(Entity entity, ComponentType type)
		{
			RemoveFromArchetype(entity, type);
		}

		public void AddChunkComponent<T>(Entity entity) where T : unmanaged
		{
			AddToArchetype(entity, ComponentType.ChunkComponent<T>());
		}

		public void AddSharedComponent<T>(Entity entity, T component) where T : unmanaged, ISharedComponentData
		{
			AddToArchetype(entity, typeof(T));
			_ecb.SetSharedComponent(entity, component);
		}

		public void SetComponentEnabled<T>(Entity entity, bool enabled) where T : unmanaged, IComponentData, IEnableableComponent
		{
			_ecb.SetComponentEnabled<T>(entity, enabled);
		}

		public DynamicBuffer<T> GetBuffer<T>(Entity entity) where T : unmanaged, IBufferElementData
		{
			return _entityManager.GetBuffer<T>(entity);
		}

		public void AddBuffer<T>(Entity entity) where T : unmanaged, IBufferElementData
		{
			EnsureHasBuffer<T>(entity);
		}

		public int EnsureHasBuffer<T>(Entity entity) where T : unmanaged, IBufferElementData
		{
			EntityBufferType key = new EntityBufferType
			{
				Entity = entity,
				Type = typeof(T)
			};
			if (_bufferLengthLookup.TryGetValue(key, out var value))
			{
				return value;
			}
			value = 0;
			if ((!_entityArchetypes.TryGetValue(entity, out var value2) || !value2.Contains(typeof(T))) && _entityManager.HasComponent<T>(entity))
			{
				value = _entityManager.GetBuffer<T>(entity).Length;
			}
			AddToArchetype(entity, typeof(T));
			_bufferLengthLookup.Add(key, value);
			return value;
		}

		public int AppendToBuffer<T>(Entity entity, T element) where T : unmanaged, IBufferElementData
		{
			_ecb.AppendToBuffer(entity, element);
			return _bufferLengthLookup[new EntityBufferType
			{
				Entity = entity,
				Type = typeof(T)
			}]++;
		}

		public void Playback(EntityManager entityManager)
		{
			ApplyArchetypeUpdates(entityManager);
			_ecb.Playback(entityManager);
		}

		private void AddToArchetype(Entity entity, ComponentType type)
		{
			if (!_entityArchetypes.TryGetValue(entity, out var value))
			{
				value = InitializeArchetype(entity);
			}
			value.Add(type);
		}

		private void RemoveFromArchetype(Entity entity, ComponentType type)
		{
			if (!_entityArchetypes.TryGetValue(entity, out var value))
			{
				value = InitializeArchetype(entity);
			}
			value.Remove(type);
		}

		private HashSet<ComponentType> InitializeArchetype(Entity entity)
		{
			HashSet<ComponentType> hashSet = new HashSet<ComponentType>();
			using NativeArray<ComponentType> nativeArray = _entityManager.GetComponentTypes(entity);
			foreach (ComponentType item in nativeArray)
			{
				hashSet.Add(item);
			}
			_entityArchetypes.Add(entity, hashSet);
			return hashSet;
		}

		private void ApplyArchetypeUpdates(EntityManager entityManager)
		{
			foreach (KeyValuePair<Entity, HashSet<ComponentType>> entityArchetype in _entityArchetypes)
			{
				Entity key = entityArchetype.Key;
				HashSet<ComponentType> value = entityArchetype.Value;
				NativeArray<ComponentType> types = new NativeArray<ComponentType>(value.Count, Allocator.Temp);
				int num = 0;
				foreach (ComponentType item in value)
				{
					types[num++] = item;
				}
				EntityArchetype archetype = entityManager.CreateArchetype(types);
				entityManager.SetArchetype(key, archetype);
			}
			_entityArchetypes.Clear();
		}

		public NativeArray<ComponentType> GetComponentTypes(Entity entity, Allocator allocator = Allocator.Temp)
		{
			if (_entityArchetypes.TryGetValue(entity, out var value))
			{
				NativeArray<ComponentType> result = new NativeArray<ComponentType>(value.Count, allocator);
				int num = 0;
				{
					foreach (ComponentType item in value)
					{
						result[num++] = item;
					}
					return result;
				}
			}
			return _entityManager.GetComponentTypes(entity, allocator);
		}
	}
}
