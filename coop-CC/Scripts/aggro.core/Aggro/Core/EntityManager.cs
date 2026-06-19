using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using UnityEngine;

namespace Aggro.Core
{
	public class EntityManager : IDisposable
	{
		private List<EntityEntry> _entities;

		private List<int> _available;

		private List<ContextEntry> _contexts;

		private List<ObjectQuery> _objectQueries;

		private uint _nextVersion = 1u;

		private readonly Allocator _allocator;

		private readonly int _capacity;

		public const int INVALID_INDEX = -1;

		public const uint INVALID_VERSION = 0u;

		public JobHandle dependency;

		public EntityWorld world { get; private set; }

		public int entityCount => _entities.Count - _available.Count;

		public uint version { get; private set; }

		public bool isValid { get; private set; }

		internal EntityManager(EntityWorld world, Allocator allocator)
			: this(world, 1, allocator)
		{
		}

		internal EntityManager(EntityWorld world, int capacity, Allocator allocator)
		{
			isValid = true;
			_allocator = allocator;
			_capacity = capacity;
			this.world = world;
			_entities = new List<EntityEntry>(capacity);
			_available = new List<int>(capacity);
			_objectQueries = new List<ObjectQuery>(capacity);
			for (int i = 0; i < capacity; i++)
			{
				_entities.Add(new EntityEntry());
				_available.Add(i);
			}
			_contexts = new List<ContextEntry>();
			_contexts.Add(new ContextEntry(capacity, allocator));
		}

		public EntityContext CreateContext(bool allowedInDefaultContext)
		{
			version++;
			EntityContext result = new EntityContext(_contexts.Count);
			_contexts.Add(new ContextEntry(_capacity, _allocator));
			return result;
		}

		public void GetAllEntities(List<EntityKey> list)
		{
			for (int i = 0; i < _entities.Count; i++)
			{
				EntityEntry entityEntry = _entities[i];
				if (entityEntry.version != 0)
				{
					list.Add(new EntityKey(i, entityEntry.version));
				}
			}
		}

		public EntityKey CreateEntity()
		{
			return CreateEntity(EntityContext.defaultContext, enabled: true, dying: false);
		}

		public EntityKey CreateEntity(EntityContext context, bool enabled, bool dying)
		{
			version++;
			int index;
			if (_available.Count > 0)
			{
				index = _available[0];
				_available.RemoveAtSwapBack(0);
			}
			else
			{
				index = _entities.Count;
				_entities.Add(new EntityEntry());
			}
			EntityEntry entityEntry = _entities[index];
			entityEntry.version = _nextVersion++;
			entityEntry.SetEnabled(enabled);
			if (dying)
			{
				entityEntry.SetDying();
			}
			entityEntry.context = context;
			return new EntityKey(index, entityEntry.version);
		}

		public void DestroyEntity(EntityKey key)
		{
			version++;
			dependency.Complete();
			EntityEntry entityEntry = GetEntityEntry(key);
			EntityStore store = GetStore(entityEntry);
			int index = EntityTypeManager.GetIndex<EntityBehaviour>();
			if (entityEntry.Has(index))
			{
				int objectIndex = entityEntry.GetObjectIndex(index);
				EntityBehaviour entityBehaviour = store.GetObject(objectIndex, index) as EntityBehaviour;
				if (entityBehaviour != null)
				{
					entityBehaviour.DestroyingEntity();
					if (!Exists(key))
					{
						return;
					}
					entityEntry = GetEntityEntry(key);
					store = GetStore(entityEntry);
				}
			}
			RemoveFromStore(entityEntry, store);
			entityEntry.version = 0u;
			entityEntry.name = "";
			entityEntry.Clear();
			_available.Add(key.index);
		}

		public uint GetIndexVersion(int index)
		{
			if (index < 0 || index >= _entities.Count)
			{
				return 0u;
			}
			return _entities[index].version;
		}

		public void SetEnabled(EntityKey key, bool enabled)
		{
			version++;
			dependency.Complete();
			EntityEntry entityEntry = GetEntityEntry(key);
			if (enabled != entityEntry.IsEnabled())
			{
				ContextEntry contextEntry = _contexts[entityEntry.context.GetIndex()];
				EntityStore store = contextEntry.GetStore(!enabled, entityEntry.IsDying());
				EntityStore store2 = contextEntry.GetStore(enabled, entityEntry.IsDying());
				CopyFromStore(entityEntry, store, store2);
				entityEntry.SetEnabled(enabled);
			}
		}

		public bool IsEnabled(EntityKey key)
		{
			return GetEntityEntry(key).IsEnabled();
		}

		public void SetDying(EntityKey key)
		{
			version++;
			dependency.Complete();
			EntityEntry entityEntry = GetEntityEntry(key);
			if (!entityEntry.IsDying())
			{
				ContextEntry contextEntry = _contexts[entityEntry.context.GetIndex()];
				EntityStore store = contextEntry.GetStore(entityEntry.IsEnabled(), dying: false);
				EntityStore store2 = contextEntry.GetStore(entityEntry.IsEnabled(), dying: true);
				CopyFromStore(entityEntry, store, store2);
				entityEntry.SetDying();
			}
		}

		public bool IsDying(EntityKey key)
		{
			return GetEntityEntry(key).IsDying();
		}

		public EntityContext GetContext(EntityKey key)
		{
			return GetEntityEntry(key).context;
		}

		public void MoveContexts(EntityKey key, EntityContext context)
		{
			version++;
			dependency.Complete();
			EntityEntry entityEntry = GetEntityEntry(key);
			if (!(entityEntry.context == context))
			{
				ContextEntry contextEntry = _contexts[entityEntry.context.GetIndex()];
				ContextEntry contextEntry2 = _contexts[context.GetIndex()];
				EntityStore store = contextEntry.GetStore(entityEntry.IsEnabled(), entityEntry.IsDying());
				EntityStore store2 = contextEntry2.GetStore(entityEntry.IsEnabled(), entityEntry.IsDying());
				CopyFromStore(entityEntry, store, store2);
				entityEntry.context = context;
			}
		}

		private void CopyFromStore(EntityEntry entityEntry, EntityStore from, EntityStore to)
		{
			int count = entityEntry.objItems.Count;
			for (int i = 0; i < count; i++)
			{
				EntityEntry.EntityEntryItem value = entityEntry.objItems[i];
				int entryIndex = to.CopyObjectFrom(value.entryIndex, value.typeIndex, from);
				EntityKey entityKey = from.RemoveAllObjects(value.entryIndex, value.typeIndex);
				if (entityKey.isValid)
				{
					_entities[entityKey.index].UpdateObjectIndex(value.typeIndex, value.entryIndex);
				}
				value.entryIndex = entryIndex;
				entityEntry.objItems[i] = value;
			}
			count = entityEntry.compItems.Count;
			for (int j = 0; j < count; j++)
			{
				EntityEntry.EntityEntryItem value2 = entityEntry.compItems[j];
				int entryIndex2 = to.CopyComponentDataFrom(value2.entryIndex, value2.typeIndex, from);
				EntityKey entityKey2 = from.RemoveComponentData(value2.entryIndex, value2.typeIndex);
				if (entityKey2.isValid)
				{
					_entities[entityKey2.index].UpdateComponentDataIndex(value2.typeIndex, value2.entryIndex);
				}
				value2.entryIndex = entryIndex2;
				entityEntry.compItems[j] = value2;
			}
			count = entityEntry.jobCompItems.Count;
			for (int k = 0; k < count; k++)
			{
				EntityEntry.EntityEntryItem value3 = entityEntry.jobCompItems[k];
				int entryIndex3 = to.CopyJobComponentDataFrom(value3.entryIndex, value3.typeIndex, from);
				EntityKey entityKey3 = from.RemoveJobComponentData(value3.entryIndex, value3.typeIndex);
				if (entityKey3.isValid)
				{
					_entities[entityKey3.index].UpdateJobComponentDataIndex(value3.typeIndex, value3.entryIndex);
				}
				value3.entryIndex = entryIndex3;
				entityEntry.jobCompItems[k] = value3;
			}
		}

		private void RemoveFromStore(EntityEntry entityEntry, EntityStore store)
		{
			int count = entityEntry.objItems.Count;
			for (int i = 0; i < count; i++)
			{
				EntityEntry.EntityEntryItem entityEntryItem = entityEntry.objItems[i];
				EntityKey entityKey = store.RemoveAllObjects(entityEntryItem.entryIndex, entityEntryItem.typeIndex);
				if (entityKey.isValid)
				{
					_entities[entityKey.index].UpdateObjectIndex(entityEntryItem.typeIndex, entityEntryItem.entryIndex);
				}
			}
			count = entityEntry.compItems.Count;
			for (int j = 0; j < count; j++)
			{
				EntityEntry.EntityEntryItem entityEntryItem2 = entityEntry.compItems[j];
				EntityKey entityKey2 = store.RemoveComponentData(entityEntryItem2.entryIndex, entityEntryItem2.typeIndex);
				if (entityKey2.isValid)
				{
					_entities[entityKey2.index].UpdateComponentDataIndex(entityEntryItem2.typeIndex, entityEntryItem2.entryIndex);
				}
			}
			count = entityEntry.jobCompItems.Count;
			for (int k = 0; k < count; k++)
			{
				EntityEntry.EntityEntryItem entityEntryItem3 = entityEntry.jobCompItems[k];
				EntityKey entityKey3 = store.RemoveJobComponentData(entityEntryItem3.entryIndex, entityEntryItem3.typeIndex);
				if (entityKey3.isValid)
				{
					_entities[entityKey3.index].UpdateJobComponentDataIndex(entityEntryItem3.typeIndex, entityEntryItem3.entryIndex);
				}
			}
		}

		public void AddComponentData<T>(EntityKey key, T comp) where T : struct, IEntityStruct
		{
			AddComponentData(key, comp, EntityTypeManager.GetIndex<T>());
		}

		public void AddComponentData<T>(EntityKey key, T comp, int typeIndex) where T : struct, IEntityStruct
		{
			version++;
			EntityEntry entityEntry = GetEntityEntry(key);
			int index = GetStore(entityEntry).AddComponentData(key, comp, typeIndex);
			entityEntry.AddComponentData(typeIndex, index);
		}

		public void SetOrAddComponentData<T>(EntityKey key, T comp) where T : struct, IEntityStruct
		{
			SetOrAddComponentData(key, comp, EntityTypeManager.GetIndex<T>());
		}

		public void SetOrAddComponentData<T>(EntityKey key, T comp, int typeIndex) where T : struct, IEntityStruct
		{
			version++;
			EntityEntry entityEntry = GetEntityEntry(key);
			EntityStore store = GetStore(entityEntry);
			if (entityEntry.Has(typeIndex))
			{
				store.SetComponentData(entityEntry.GetComponentDataIndex(typeIndex), comp, typeIndex);
				return;
			}
			int index = store.AddComponentData(key, comp, typeIndex);
			entityEntry.AddComponentData(typeIndex, index);
		}

		public void AddJobComponentData<T>(EntityKey key, T comp) where T : unmanaged, IEntityJobComponent
		{
			AddJobComponentData(key, comp, EntityTypeManager.GetIndex<T>());
		}

		public void AddJobComponentData<T>(EntityKey key, T comp, int typeIndex) where T : unmanaged, IEntityJobComponent
		{
			dependency.Complete();
			version++;
			EntityEntry entityEntry = GetEntityEntry(key);
			int index = GetStore(entityEntry).AddJobComponentData(key, comp, typeIndex);
			entityEntry.AddJobComponentData(typeIndex, index);
		}

		public void AddObject<T>(EntityKey key, T obj) where T : class
		{
			AddObject(key, obj, EntityTypeManager.GetIndex<T>());
		}

		public void AddObject(EntityKey key, object obj, int typeIndex)
		{
			version++;
			EntityEntry entityEntry = GetEntityEntry(key);
			EntityStore store = GetStore(entityEntry);
			int entryIndex = entityEntry.GetObjectIndex(typeIndex);
			store.AddObject(key, obj, typeIndex, ref entryIndex);
			entityEntry.AddObject(typeIndex, entryIndex);
		}

		public T GetComponentData<T>(EntityKey key) where T : struct, IEntityStruct
		{
			return GetComponentData<T>(key, EntityTypeManager.GetIndex<T>());
		}

		public T GetComponentData<T>(EntityKey key, int typeIndex) where T : struct, IEntityStruct
		{
			EntityEntry entityEntry = GetEntityEntry(key);
			return GetStore(entityEntry).GetComponentData<T>(entityEntry.GetComponentDataIndex(typeIndex), typeIndex);
		}

		public T GetJobComponentData<T>(EntityKey key) where T : unmanaged, IEntityJobComponent
		{
			return GetJobComponentData<T>(key, EntityTypeManager.GetIndex<T>());
		}

		public T GetJobComponentData<T>(EntityKey key, int typeIndex) where T : unmanaged, IEntityJobComponent
		{
			dependency.Complete();
			EntityEntry entityEntry = GetEntityEntry(key);
			return GetStore(entityEntry).GetJobComponentData<T>(entityEntry.GetJobComponentDataIndex(typeIndex), typeIndex);
		}

		public T GetObject<T>(EntityKey key) where T : class
		{
			return (T)GetObject(key, EntityTypeManager.GetIndex<T>());
		}

		public T GetObject<T>(EntityKey key, int typeIndex) where T : class
		{
			return (T)GetObject(key, typeIndex);
		}

		public object GetObject(EntityKey key, Type type)
		{
			return GetObject(key, EntityTypeManager.GetIndex(type));
		}

		public object GetObject(EntityKey key, int typeIndex)
		{
			EntityEntry entityEntry = GetEntityEntry(key);
			EntityStore store = GetStore(entityEntry);
			if (entityEntry.Has(typeIndex))
			{
				object obj = store.GetObject(entityEntry.GetObjectIndex(typeIndex), typeIndex);
				if (obj != null)
				{
					return obj;
				}
			}
			EntityTypeManager.TypeInfo infoUpdateInherited = EntityTypeManager.GetInfoUpdateInherited(typeIndex);
			int count = infoUpdateInherited.inheritedTypeIndices.Count;
			for (int i = 0; i < count; i++)
			{
				int typeIndex2 = infoUpdateInherited.inheritedTypeIndices[i];
				if (entityEntry.Has(typeIndex2))
				{
					object obj2 = store.GetObject(entityEntry.GetObjectIndex(typeIndex2), typeIndex2);
					if (obj2 != null)
					{
						return obj2;
					}
				}
			}
			return null;
		}

		public void GetObjects<T>(EntityKey key, List<T> list, ObjectQueryFlags flags = ObjectQueryFlags.AllObjects) where T : class
		{
			GetObjects(key, list, EntityTypeManager.GetIndex<T>(), flags);
		}

		public void GetObjects<T>(EntityKey key, List<T> list, int typeIndex, ObjectQueryFlags flags = ObjectQueryFlags.AllObjects) where T : class
		{
			EntityEntry entityEntry = GetEntityEntry(key);
			EntityStore store = GetStore(entityEntry);
			if (entityEntry.Has(typeIndex))
			{
				store.GetObjects(list, entityEntry.GetObjectIndex(typeIndex), typeIndex, flags);
			}
			EntityTypeManager.TypeInfo infoUpdateInherited = EntityTypeManager.GetInfoUpdateInherited(typeIndex);
			int count = infoUpdateInherited.inheritedTypeIndices.Count;
			for (int i = 0; i < count; i++)
			{
				int typeIndex2 = infoUpdateInherited.inheritedTypeIndices[i];
				if (entityEntry.Has(typeIndex2))
				{
					store.GetObjects(list, entityEntry.GetObjectIndex(typeIndex2), typeIndex2, flags);
				}
			}
		}

		public void GetObjects(EntityKey key, List<object> list, Type type, ObjectQueryFlags flags = ObjectQueryFlags.AllObjects)
		{
			GetObjects(key, list, EntityTypeManager.GetIndex(type), flags);
		}

		public void GetObjects(EntityKey key, List<object> list, int typeIndex, ObjectQueryFlags flags = ObjectQueryFlags.AllObjects)
		{
			EntityEntry entityEntry = GetEntityEntry(key);
			EntityStore store = GetStore(entityEntry);
			if (entityEntry.Has(typeIndex))
			{
				store.GetObjects(list, entityEntry.GetObjectIndex(typeIndex), typeIndex, flags);
			}
			EntityTypeManager.TypeInfo infoUpdateInherited = EntityTypeManager.GetInfoUpdateInherited(typeIndex);
			int count = infoUpdateInherited.inheritedTypeIndices.Count;
			for (int i = 0; i < count; i++)
			{
				int typeIndex2 = infoUpdateInherited.inheritedTypeIndices[i];
				if (entityEntry.Has(typeIndex2))
				{
					store.GetObjects(list, entityEntry.GetObjectIndex(typeIndex2), typeIndex2, flags);
				}
			}
		}

		public void GetAllObjects<T>(List<T> objects) where T : class
		{
			EntityTypeManager.TypeInfo info = EntityTypeManager.GetInfo<T>();
			while (_objectQueries.Count <= info.typeIndex)
			{
				_objectQueries.Add(null);
			}
			ObjectQuery objectQuery = _objectQueries[info.typeIndex];
			if (objectQuery == null)
			{
				objectQuery = CreateObjectQuery(info.type);
				_objectQueries[info.typeIndex] = objectQuery;
			}
			objectQuery.Run();
			for (int i = 0; i < objectQuery.count; i++)
			{
				objects.Add((T)objectQuery[i]);
			}
		}

		public void GetAllEntitiesWith<T>(List<Entity> entities) where T : class
		{
			EntityTypeManager.TypeInfo info = EntityTypeManager.GetInfo<T>();
			while (_objectQueries.Count <= info.typeIndex)
			{
				_objectQueries.Add(null);
			}
			ObjectQuery objectQuery = _objectQueries[info.typeIndex];
			if (objectQuery == null)
			{
				objectQuery = CreateObjectQuery(info.type);
				_objectQueries[info.typeIndex] = objectQuery;
			}
			objectQuery.Run();
			for (int i = 0; i < objectQuery.count; i++)
			{
				entities.Add(objectQuery.GetEntity(i));
			}
		}

		public void SetComponentData<T>(EntityKey key, T comp) where T : struct, IEntityStruct
		{
			SetComponentData(key, comp, EntityTypeManager.GetIndex<T>());
		}

		public void SetComponentData<T>(EntityKey key, T comp, int typeIndex) where T : struct, IEntityStruct
		{
			EntityEntry entityEntry = GetEntityEntry(key);
			GetStore(entityEntry).SetComponentData(entityEntry.GetComponentDataIndex(typeIndex), comp, typeIndex);
		}

		public void SetJobComponentData<T>(EntityKey key, T comp) where T : unmanaged, IEntityJobComponent
		{
			SetJobComponentData(key, comp, EntityTypeManager.GetIndex<T>());
		}

		public void SetJobComponentData<T>(EntityKey key, T comp, int typeIndex) where T : unmanaged, IEntityJobComponent
		{
			dependency.Complete();
			EntityEntry entityEntry = GetEntityEntry(key);
			GetStore(entityEntry).SetJobComponentData(entityEntry.GetJobComponentDataIndex(typeIndex), comp, typeIndex);
		}

		public bool HasComponentData<T>(EntityKey key) where T : struct, IEntityStruct
		{
			return HasComponentData(key, EntityTypeManager.GetIndex<T>());
		}

		public bool HasComponentData(EntityKey key, int typeIndex)
		{
			return GetEntityEntry(key).Has(typeIndex);
		}

		public bool HasJobComponentData<T>(EntityKey key) where T : unmanaged, IEntityJobComponent
		{
			return HasJobComponentData(key, EntityTypeManager.GetIndex<T>());
		}

		public bool HasJobComponentData(EntityKey key, int typeIndex)
		{
			return GetEntityEntry(key).Has(typeIndex);
		}

		public bool HasObject<T>(EntityKey key) where T : class
		{
			return HasObject(key, EntityTypeManager.GetIndex<T>());
		}

		public bool HasObject(EntityKey key, Type type)
		{
			return HasObject(key, EntityTypeManager.GetIndex(type));
		}

		public bool HasObject(EntityKey key, int typeIndex)
		{
			EntityEntry entityEntry = GetEntityEntry(key);
			EntityTypeManager.TypeInfo info = EntityTypeManager.GetInfo(typeIndex);
			EntityStore store = GetStore(entityEntry);
			if (store.HasObject(entityEntry.GetObjectIndex(typeIndex), typeIndex))
			{
				return true;
			}
			info = EntityTypeManager.GetInfoUpdateInherited(typeIndex);
			int count = info.inheritedTypeIndices.Count;
			for (int i = 0; i < count; i++)
			{
				int typeIndex2 = info.inheritedTypeIndices[i];
				if (store.HasObject(entityEntry.GetObjectIndex(typeIndex2), typeIndex2))
				{
					return true;
				}
			}
			return false;
		}

		public bool TryGetComponentData<T>(EntityKey key, out T data) where T : struct, IEntityStruct
		{
			return TryGetComponentData<T>(key, EntityTypeManager.GetIndex<T>(), out data);
		}

		public bool TryGetComponentData<T>(EntityKey key, int typeIndex, out T data) where T : struct, IEntityStruct
		{
			if (HasComponentData(key, typeIndex))
			{
				data = GetComponentData<T>(key, typeIndex);
				return true;
			}
			data = default(T);
			return false;
		}

		public bool TryGetJobComponentData<T>(EntityKey key, out T data) where T : unmanaged, IEntityJobComponent
		{
			return TryGetJobComponentData<T>(key, EntityTypeManager.GetIndex<T>(), out data);
		}

		public bool TryGetJobComponentData<T>(EntityKey key, int typeIndex, out T data) where T : unmanaged, IEntityJobComponent
		{
			if (HasJobComponentData(key, typeIndex))
			{
				data = GetJobComponentData<T>(key, typeIndex);
				return true;
			}
			data = default(T);
			return false;
		}

		public bool TryGetObject<T>(EntityKey key, out T obj) where T : class
		{
			if (TryGetObject(key, EntityTypeManager.GetIndex<T>(), out obj))
			{
				return true;
			}
			obj = null;
			return false;
		}

		public bool TryGetObject<T>(EntityKey key, int typeIndex, out T obj) where T : class
		{
			if (TryGetObject(key, typeIndex, out var obj2))
			{
				obj = (T)obj2;
				return true;
			}
			obj = null;
			return false;
		}

		public bool TryGetObject(EntityKey key, Type type, out object obj)
		{
			return TryGetObject(key, EntityTypeManager.GetIndex(type), out obj);
		}

		public bool TryGetObject(EntityKey key, int typeIndex, out object obj)
		{
			if (HasObject(key, typeIndex))
			{
				obj = GetObject(key, typeIndex);
				return true;
			}
			obj = null;
			return false;
		}

		public void RemoveComponentData<T>(EntityKey key) where T : struct, IEntityStruct
		{
			RemoveComponentData(key, EntityTypeManager.GetIndex<T>());
		}

		public void RemoveComponentData(EntityKey key, int typeIndex)
		{
			version++;
			EntityEntry entityEntry = GetEntityEntry(key);
			EntityStore store = GetStore(entityEntry);
			int componentDataIndex = entityEntry.GetComponentDataIndex(typeIndex);
			EntityKey entityKey = store.RemoveComponentData(componentDataIndex, typeIndex);
			entityEntry.RemoveComponentDataIndex(typeIndex);
			if (entityKey.isValid)
			{
				_entities[entityKey.index].UpdateComponentDataIndex(typeIndex, componentDataIndex);
			}
		}

		public void RemoveJobComponentData<T>(EntityKey key) where T : unmanaged, IEntityJobComponent
		{
			RemoveJobComponentData(key, EntityTypeManager.GetIndex<T>());
		}

		public void RemoveJobComponentData(EntityKey key, int typeIndex)
		{
			dependency.Complete();
			version++;
			EntityEntry entityEntry = GetEntityEntry(key);
			EntityStore store = GetStore(entityEntry);
			int jobComponentDataIndex = entityEntry.GetJobComponentDataIndex(typeIndex);
			EntityKey entityKey = store.RemoveJobComponentData(jobComponentDataIndex, typeIndex);
			entityEntry.RemoveJobComponentDataIndex(typeIndex);
			if (entityKey.isValid)
			{
				_entities[entityKey.index].UpdateJobComponentDataIndex(typeIndex, jobComponentDataIndex);
			}
		}

		public void RemoveObject<T>(EntityKey key, T obj) where T : class
		{
			RemoveObject(key, obj, EntityTypeManager.GetIndex<T>());
		}

		public void RemoveObject(EntityKey key, object obj, Type type)
		{
			RemoveObject(key, obj, EntityTypeManager.GetIndex(type));
		}

		public void RemoveObject(EntityKey key, object obj, int typeIndex)
		{
			version++;
			EntityEntry entityEntry = GetEntityEntry(key);
			EntityStore store = GetStore(entityEntry);
			int objectIndex = entityEntry.GetObjectIndex(typeIndex);
			EntityKey entityKey = store.RemoveObject(objectIndex, typeIndex, obj);
			if (entityKey != key)
			{
				entityEntry.RemoveObjectIndex(typeIndex);
				if (entityKey.isValid)
				{
					_entities[entityKey.index].UpdateObjectIndex(typeIndex, objectIndex);
				}
			}
		}

		public void RemoveObjects<T>(EntityKey key) where T : class
		{
			RemoveObjects(key, EntityTypeManager.GetIndex<T>());
		}

		public void RemoveObjects(EntityKey key, Type type)
		{
			RemoveObjects(key, EntityTypeManager.GetIndex(type));
		}

		public void RemoveObjects(EntityKey key, int typeIndex)
		{
			version++;
			EntityEntry entityEntry = GetEntityEntry(key);
			EntityStore store = GetStore(entityEntry);
			if (entityEntry.Has(typeIndex))
			{
				int objectIndex = entityEntry.GetObjectIndex(typeIndex);
				EntityKey entityKey = store.RemoveAllObjects(objectIndex, typeIndex);
				entityEntry.RemoveObjectIndex(typeIndex);
				if (entityKey.isValid)
				{
					_entities[entityKey.index].UpdateObjectIndex(typeIndex, objectIndex);
				}
			}
			EntityTypeManager.TypeInfo infoUpdateInherited = EntityTypeManager.GetInfoUpdateInherited(typeIndex);
			int count = infoUpdateInherited.inheritedTypeIndices.Count;
			for (int i = 0; i < count; i++)
			{
				int typeIndex2 = infoUpdateInherited.inheritedTypeIndices[i];
				if (entityEntry.Has(typeIndex2))
				{
					int objectIndex2 = entityEntry.GetObjectIndex(typeIndex2);
					EntityKey entityKey2 = store.RemoveAllObjects(objectIndex2, typeIndex2);
					entityEntry.RemoveObjectIndex(typeIndex2);
					if (entityKey2.isValid)
					{
						_entities[entityKey2.index].UpdateObjectIndex(typeIndex2, objectIndex2);
					}
				}
			}
		}

		public bool Exists(EntityKey key)
		{
			return GetEntityEntry(key) != null;
		}

		private EntityEntry GetEntityEntry(EntityKey key)
		{
			if (key.index < 0 || key.index >= _entities.Count)
			{
				return null;
			}
			EntityEntry entityEntry = _entities[key.index];
			if (entityEntry.version == key.version)
			{
				return entityEntry;
			}
			return null;
		}

		private ContextEntry GetContextEntry(EntityContext context)
		{
			int index = context.GetIndex();
			return _contexts[index];
		}

		private EntityStore GetStore(EntityEntry entry)
		{
			return GetContextEntry(entry.context).GetStore(entry.IsEnabled(), entry.IsDying());
		}

		public ObjectQuery CreateObjectQuery(Type type, EntityQueryFlags flags = EntityQueryFlags.Default)
		{
			return new ObjectQuery(this, type, flags);
		}

		public ObjectQuery<T> CreateObjectQuery<T>(EntityQueryFlags flags = EntityQueryFlags.Default) where T : class
		{
			return new ObjectQuery<T>(this, flags);
		}

		internal void RunQuery(ObjectQuery query)
		{
			RunQuery(query, EntityContext.allContexts);
		}

		internal void RunQuery(ObjectQuery query, EntityContext context)
		{
			query.results.Clear();
			AddToQuery(query, context);
		}

		internal void RunQuery(ObjectQuery query, List<EntityContext> contexts)
		{
			query.results.Clear();
			int count = contexts.Count;
			for (int i = 0; i < count; i++)
			{
				AddToQuery(query, contexts[i]);
			}
		}

		private void AddToQuery(ObjectQuery query, EntityContext context)
		{
			bool includeInactive = (query.flags & EntityQueryFlags.InactiveBehaviours) != 0;
			EntityTypeManager.GetInfoUpdateInherited(query.typeInfo.typeIndex);
			int count = query.typeInfo.inheritedTypeIndices.Count;
			if (context.isAllContexts)
			{
				int count2 = _contexts.Count;
				if ((query.flags & EntityQueryFlags.EnabledEntities) != 0)
				{
					if ((query.flags & EntityQueryFlags.AliveEntities) != 0)
					{
						for (int i = 0; i < count2; i++)
						{
							ContextEntry contextEntry = _contexts[i];
							contextEntry.enabledAliveStore.GetObjectQueryResults(query.results, query.typeInfo.typeIndex, includeInactive);
							for (int j = 0; j < count; j++)
							{
								contextEntry.enabledAliveStore.GetObjectQueryResults(query.results, query.typeInfo.inheritedTypeIndices[j], includeInactive);
							}
						}
					}
					if ((query.flags & EntityQueryFlags.DyingEntities) != 0)
					{
						for (int k = 0; k < count2; k++)
						{
							ContextEntry contextEntry2 = _contexts[k];
							contextEntry2.enabledDyingStore.GetObjectQueryResults(query.results, query.typeInfo.typeIndex, includeInactive);
							for (int l = 0; l < count; l++)
							{
								contextEntry2.enabledDyingStore.GetObjectQueryResults(query.results, query.typeInfo.inheritedTypeIndices[l], includeInactive);
							}
						}
					}
				}
				if ((query.flags & EntityQueryFlags.DisabledEntities) == 0)
				{
					return;
				}
				if ((query.flags & EntityQueryFlags.AliveEntities) != 0)
				{
					for (int m = 0; m < count2; m++)
					{
						ContextEntry contextEntry3 = _contexts[m];
						contextEntry3.disableAliveStore.GetObjectQueryResults(query.results, query.typeInfo.typeIndex, includeInactive);
						for (int n = 0; n < count; n++)
						{
							contextEntry3.disableAliveStore.GetObjectQueryResults(query.results, query.typeInfo.inheritedTypeIndices[n], includeInactive);
						}
					}
				}
				if ((query.flags & EntityQueryFlags.DyingEntities) == 0)
				{
					return;
				}
				for (int num = 0; num < count2; num++)
				{
					ContextEntry contextEntry4 = _contexts[num];
					contextEntry4.disableDyingStore.GetObjectQueryResults(query.results, query.typeInfo.typeIndex, includeInactive);
					for (int num2 = 0; num2 < count; num2++)
					{
						contextEntry4.disableDyingStore.GetObjectQueryResults(query.results, query.typeInfo.inheritedTypeIndices[num2], includeInactive);
					}
				}
				return;
			}
			ContextEntry contextEntry5 = GetContextEntry(context);
			if ((query.flags & EntityQueryFlags.EnabledEntities) != 0)
			{
				if ((query.flags & EntityQueryFlags.AliveEntities) != 0)
				{
					contextEntry5.enabledAliveStore.GetObjectQueryResults(query.results, query.typeInfo.typeIndex, includeInactive);
					for (int num3 = 0; num3 < count; num3++)
					{
						contextEntry5.enabledAliveStore.GetObjectQueryResults(query.results, query.typeInfo.inheritedTypeIndices[num3], includeInactive);
					}
				}
				if ((query.flags & EntityQueryFlags.DyingEntities) != 0)
				{
					contextEntry5.enabledDyingStore.GetObjectQueryResults(query.results, query.typeInfo.typeIndex, includeInactive);
					for (int num4 = 0; num4 < count; num4++)
					{
						contextEntry5.enabledDyingStore.GetObjectQueryResults(query.results, query.typeInfo.inheritedTypeIndices[num4], includeInactive);
					}
				}
			}
			if ((query.flags & EntityQueryFlags.DisabledEntities) == 0)
			{
				return;
			}
			if ((query.flags & EntityQueryFlags.AliveEntities) != 0)
			{
				contextEntry5.disableAliveStore.GetObjectQueryResults(query.results, query.typeInfo.typeIndex, includeInactive);
				for (int num5 = 0; num5 < count; num5++)
				{
					contextEntry5.disableAliveStore.GetObjectQueryResults(query.results, query.typeInfo.inheritedTypeIndices[num5], includeInactive);
				}
			}
			if ((query.flags & EntityQueryFlags.DyingEntities) != 0)
			{
				contextEntry5.disableDyingStore.GetObjectQueryResults(query.results, query.typeInfo.typeIndex, includeInactive);
				for (int num6 = 0; num6 < count; num6++)
				{
					contextEntry5.disableDyingStore.GetObjectQueryResults(query.results, query.typeInfo.inheritedTypeIndices[num6], includeInactive);
				}
			}
		}

		internal void RunQuery<T>(ObjectQuery<T> query) where T : class
		{
			RunQuery(query, EntityContext.allContexts);
		}

		internal void RunQuery<T>(ObjectQuery<T> query, EntityContext context) where T : class
		{
			query.results.Clear();
			AddToQuery(query, context);
		}

		internal void RunQuery<T>(ObjectQuery<T> query, List<EntityContext> contexts) where T : class
		{
			query.results.Clear();
			int count = contexts.Count;
			for (int i = 0; i < count; i++)
			{
				AddToQuery(query, contexts[i]);
			}
		}

		private void AddToQuery<T>(ObjectQuery<T> query, EntityContext context) where T : class
		{
			bool includeInactive = (query.flags & EntityQueryFlags.InactiveBehaviours) != 0;
			EntityTypeManager.GetInfoUpdateInherited(query.typeInfo.typeIndex);
			int count = query.typeInfo.inheritedTypeIndices.Count;
			if (context.isAllContexts)
			{
				int count2 = _contexts.Count;
				if ((query.flags & EntityQueryFlags.EnabledEntities) != 0)
				{
					if ((query.flags & EntityQueryFlags.AliveEntities) != 0)
					{
						for (int i = 0; i < count2; i++)
						{
							ContextEntry contextEntry = _contexts[i];
							contextEntry.enabledAliveStore.GetObjectQueryResults(query.results, query.typeInfo.typeIndex, includeInactive);
							for (int j = 0; j < count; j++)
							{
								contextEntry.enabledAliveStore.GetObjectQueryResults(query.results, query.typeInfo.inheritedTypeIndices[j], includeInactive);
							}
						}
					}
					if ((query.flags & EntityQueryFlags.DyingEntities) != 0)
					{
						for (int k = 0; k < count2; k++)
						{
							ContextEntry contextEntry2 = _contexts[k];
							contextEntry2.enabledDyingStore.GetObjectQueryResults(query.results, query.typeInfo.typeIndex, includeInactive);
							for (int l = 0; l < count; l++)
							{
								contextEntry2.enabledDyingStore.GetObjectQueryResults(query.results, query.typeInfo.inheritedTypeIndices[l], includeInactive);
							}
						}
					}
				}
				if ((query.flags & EntityQueryFlags.DisabledEntities) == 0)
				{
					return;
				}
				if ((query.flags & EntityQueryFlags.AliveEntities) != 0)
				{
					for (int m = 0; m < count2; m++)
					{
						ContextEntry contextEntry3 = _contexts[m];
						contextEntry3.disableAliveStore.GetObjectQueryResults(query.results, query.typeInfo.typeIndex, includeInactive);
						for (int n = 0; n < count; n++)
						{
							contextEntry3.disableAliveStore.GetObjectQueryResults(query.results, query.typeInfo.inheritedTypeIndices[n], includeInactive);
						}
					}
				}
				if ((query.flags & EntityQueryFlags.DyingEntities) == 0)
				{
					return;
				}
				for (int num = 0; num < count2; num++)
				{
					ContextEntry contextEntry4 = _contexts[num];
					contextEntry4.disableDyingStore.GetObjectQueryResults(query.results, query.typeInfo.typeIndex, includeInactive);
					for (int num2 = 0; num2 < count; num2++)
					{
						contextEntry4.disableDyingStore.GetObjectQueryResults(query.results, query.typeInfo.inheritedTypeIndices[num2], includeInactive);
					}
				}
				return;
			}
			ContextEntry contextEntry5 = GetContextEntry(context);
			if ((query.flags & EntityQueryFlags.EnabledEntities) != 0)
			{
				if ((query.flags & EntityQueryFlags.AliveEntities) != 0)
				{
					contextEntry5.enabledAliveStore.GetObjectQueryResults(query.results, query.typeInfo.typeIndex, includeInactive);
					for (int num3 = 0; num3 < count; num3++)
					{
						contextEntry5.enabledAliveStore.GetObjectQueryResults(query.results, query.typeInfo.inheritedTypeIndices[num3], includeInactive);
					}
				}
				if ((query.flags & EntityQueryFlags.DyingEntities) != 0)
				{
					contextEntry5.enabledDyingStore.GetObjectQueryResults(query.results, query.typeInfo.typeIndex, includeInactive);
					for (int num4 = 0; num4 < count; num4++)
					{
						contextEntry5.enabledDyingStore.GetObjectQueryResults(query.results, query.typeInfo.inheritedTypeIndices[num4], includeInactive);
					}
				}
			}
			if ((query.flags & EntityQueryFlags.DisabledEntities) == 0)
			{
				return;
			}
			if ((query.flags & EntityQueryFlags.AliveEntities) != 0)
			{
				contextEntry5.disableAliveStore.GetObjectQueryResults(query.results, query.typeInfo.typeIndex, includeInactive);
				for (int num5 = 0; num5 < count; num5++)
				{
					contextEntry5.disableAliveStore.GetObjectQueryResults(query.results, query.typeInfo.inheritedTypeIndices[num5], includeInactive);
				}
			}
			if ((query.flags & EntityQueryFlags.DyingEntities) != 0)
			{
				contextEntry5.disableDyingStore.GetObjectQueryResults(query.results, query.typeInfo.typeIndex, includeInactive);
				for (int num6 = 0; num6 < count; num6++)
				{
					contextEntry5.disableDyingStore.GetObjectQueryResults(query.results, query.typeInfo.inheritedTypeIndices[num6], includeInactive);
				}
			}
		}

		public StructQuery<T> CreateStructQuery<T>(EntityQueryFlags flags = EntityQueryFlags.Default) where T : struct, IEntityStruct
		{
			return new StructQuery<T>(this, flags);
		}

		internal void RunQuery<T>(StructQuery<T> query) where T : struct, IEntityStruct
		{
			RunQuery(query, EntityContext.allContexts);
		}

		internal void RunQuery<T>(StructQuery<T> query, EntityContext context) where T : struct, IEntityStruct
		{
			query.keys.Clear();
			AddToQuery(query, context);
		}

		internal void RunQuery<T>(StructQuery<T> query, List<EntityContext> contexts) where T : struct, IEntityStruct
		{
			query.keys.Clear();
			int count = contexts.Count;
			for (int i = 0; i < count; i++)
			{
				AddToQuery(query, contexts[i]);
			}
		}

		private void AddToQuery<T>(StructQuery<T> query, EntityContext context) where T : struct, IEntityStruct
		{
			if (context.isAllContexts)
			{
				int count = _contexts.Count;
				if ((query.flags & EntityQueryFlags.EnabledEntities) != 0)
				{
					if ((query.flags & EntityQueryFlags.AliveEntities) != 0)
					{
						for (int i = 0; i < count; i++)
						{
							_contexts[i].enabledAliveStore.GetComponentKeys<T>(query.keys, query.typeIndex);
						}
					}
					if ((query.flags & EntityQueryFlags.DyingEntities) != 0)
					{
						for (int j = 0; j < count; j++)
						{
							_contexts[j].enabledDyingStore.GetComponentKeys<T>(query.keys, query.typeIndex);
						}
					}
				}
				if ((query.flags & EntityQueryFlags.DisabledEntities) == 0)
				{
					return;
				}
				if ((query.flags & EntityQueryFlags.AliveEntities) != 0)
				{
					for (int k = 0; k < count; k++)
					{
						_contexts[k].disableAliveStore.GetComponentKeys<T>(query.keys, query.typeIndex);
					}
				}
				if ((query.flags & EntityQueryFlags.DyingEntities) != 0)
				{
					for (int l = 0; l < count; l++)
					{
						_contexts[l].disableDyingStore.GetComponentKeys<T>(query.keys, query.typeIndex);
					}
				}
				return;
			}
			ContextEntry contextEntry = GetContextEntry(context);
			if ((query.flags & EntityQueryFlags.EnabledEntities) != 0)
			{
				if ((query.flags & EntityQueryFlags.AliveEntities) != 0)
				{
					contextEntry.enabledAliveStore.GetComponentKeys<T>(query.keys, query.typeIndex);
				}
				if ((query.flags & EntityQueryFlags.DyingEntities) != 0)
				{
					contextEntry.enabledDyingStore.GetComponentKeys<T>(query.keys, query.typeIndex);
				}
			}
			if ((query.flags & EntityQueryFlags.DisabledEntities) != 0)
			{
				if ((query.flags & EntityQueryFlags.AliveEntities) != 0)
				{
					contextEntry.disableAliveStore.GetComponentKeys<T>(query.keys, query.typeIndex);
				}
				if ((query.flags & EntityQueryFlags.DyingEntities) != 0)
				{
					contextEntry.disableDyingStore.GetComponentKeys<T>(query.keys, query.typeIndex);
				}
			}
		}

		public JobComponentQuery<T> CreateJobComponentQuery<T>(Allocator allocator) where T : unmanaged, IEntityJobComponent
		{
			return CreateJobQuery<T>(EntityQueryFlags.Default, EntityTypeManager.GetIndex<T>(), allocator);
		}

		public JobComponentQuery<T> CreateJobQuery<T>(EntityQueryFlags flags, Allocator allocator) where T : unmanaged, IEntityJobComponent
		{
			return CreateJobQuery<T>(flags, EntityTypeManager.GetIndex<T>(), allocator);
		}

		public JobComponentQuery<T> CreateJobQuery<T>(EntityQueryFlags flags, int typeIndex, Allocator allocator) where T : unmanaged, IEntityJobComponent
		{
			return new JobComponentQuery<T>(flags, typeIndex, _capacity, allocator);
		}

		public void RunQuery<T>(ref JobComponentQuery<T> query) where T : unmanaged, IEntityJobComponent
		{
			RunQuery(ref query, EntityContext.allContexts);
		}

		public unsafe void RunQuery<T>(ref JobComponentQuery<T> query, EntityContext context) where T : unmanaged, IEntityJobComponent
		{
			query.Entries->Clear();
			query.Stores->Clear();
			AddToQuery(ref query, context);
			query.m_Length = query.Entries->Length;
		}

		public unsafe void RunQuery<T>(ref JobComponentQuery<T> query, List<EntityContext> contexts) where T : unmanaged, IEntityJobComponent
		{
			query.Entries->Clear();
			query.Stores->Clear();
			int count = contexts.Count;
			for (int i = 0; i < count; i++)
			{
				AddToQuery(ref query, contexts[i]);
			}
			query.m_Length = query.Entries->Length;
		}

		private void AddToQuery<T>(ref JobComponentQuery<T> query, EntityContext context) where T : unmanaged, IEntityJobComponent
		{
			if (context.isAllContexts)
			{
				int count = _contexts.Count;
				if ((query.flags & EntityQueryFlags.EnabledEntities) != 0)
				{
					if ((query.flags & EntityQueryFlags.AliveEntities) != 0)
					{
						for (int i = 0; i < count; i++)
						{
							AddToQuery(ref query, _contexts[i].enabledAliveStore);
						}
					}
					if ((query.flags & EntityQueryFlags.DyingEntities) != 0)
					{
						for (int j = 0; j < count; j++)
						{
							AddToQuery(ref query, _contexts[j].enabledDyingStore);
						}
					}
				}
				if ((query.flags & EntityQueryFlags.DisabledEntities) == 0)
				{
					return;
				}
				if ((query.flags & EntityQueryFlags.AliveEntities) != 0)
				{
					for (int k = 0; k < count; k++)
					{
						AddToQuery(ref query, _contexts[k].disableAliveStore);
					}
				}
				if ((query.flags & EntityQueryFlags.DyingEntities) != 0)
				{
					for (int l = 0; l < count; l++)
					{
						AddToQuery(ref query, _contexts[l].disableDyingStore);
					}
				}
				return;
			}
			ContextEntry contextEntry = GetContextEntry(context);
			if ((query.flags & EntityQueryFlags.EnabledEntities) != 0)
			{
				if ((query.flags & EntityQueryFlags.AliveEntities) != 0)
				{
					AddToQuery(ref query, contextEntry.enabledAliveStore);
				}
				if ((query.flags & EntityQueryFlags.DyingEntities) != 0)
				{
					AddToQuery(ref query, contextEntry.enabledDyingStore);
				}
			}
			if ((query.flags & EntityQueryFlags.DisabledEntities) != 0)
			{
				if ((query.flags & EntityQueryFlags.AliveEntities) != 0)
				{
					AddToQuery(ref query, contextEntry.disableAliveStore);
				}
				if ((query.flags & EntityQueryFlags.DyingEntities) != 0)
				{
					AddToQuery(ref query, contextEntry.disableDyingStore);
				}
			}
		}

		private unsafe void AddToQuery<T>(ref JobComponentQuery<T> query, EntityStore store) where T : unmanaged, IEntityJobComponent
		{
			NativeArray<EntityKey> jobComponentDataKeysRaw = store.GetJobComponentDataKeysRaw<T>(query.TypeIndex);
			NativeArray<T> jobComponentDatasRaw = store.GetJobComponentDatasRaw<T>(query.TypeIndex);
			JobComponentQuery<T>.Store value = new JobComponentQuery<T>.Store
			{
				Keys = new UnsafeList<EntityKey>((EntityKey*)NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(jobComponentDataKeysRaw), jobComponentDataKeysRaw.Length),
				Components = new UnsafeList<T>((T*)NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(jobComponentDatasRaw), jobComponentDatasRaw.Length)
			};
			JobComponentQuery<T>.Entry value2 = new JobComponentQuery<T>.Entry
			{
				StoreIndex = query.Stores->Length
			};
			int length = value.Keys.Length;
			for (int i = 0; i < length; i++)
			{
				value2.ItemIndex = i;
				query.Entries->Add(in value2);
			}
			query.Stores->Add(in value);
		}

		public EntityJobStoreQuery<T> CreateStoreQuery<T>(Allocator allocator) where T : unmanaged, IEntityJobComponent
		{
			return CreateStoreQuery<T>(EntityQueryFlags.Default, EntityTypeManager.GetIndex<T>(), allocator);
		}

		public EntityJobStoreQuery<T> CreateStoreQuery<T>(EntityQueryFlags flags, Allocator allocator) where T : unmanaged, IEntityJobComponent
		{
			return CreateStoreQuery<T>(flags, EntityTypeManager.GetIndex<T>(), allocator);
		}

		public EntityJobStoreQuery<T> CreateStoreQuery<T>(EntityQueryFlags flags, int typeIndex, Allocator allocator) where T : unmanaged, IEntityJobComponent
		{
			return new EntityJobStoreQuery<T>(flags, typeIndex, _capacity, allocator);
		}

		public void RunQuery<T>(ref EntityJobStoreQuery<T> query) where T : unmanaged, IEntityJobComponent
		{
			RunQuery(ref query, EntityContext.allContexts);
		}

		public unsafe void RunQuery<T>(ref EntityJobStoreQuery<T> query, EntityContext context) where T : unmanaged, IEntityJobComponent
		{
			query.Stores->Clear();
			AddToQuery(ref query, context);
			query.m_Length = query.Stores->Length;
		}

		public unsafe void RunQuery<T>(ref EntityJobStoreQuery<T> query, List<EntityContext> contexts) where T : unmanaged, IEntityJobComponent
		{
			query.Stores->Clear();
			int count = contexts.Count;
			for (int i = 0; i < count; i++)
			{
				AddToQuery(ref query, contexts[i]);
			}
			query.m_Length = query.Stores->Length;
		}

		private void AddToQuery<T>(ref EntityJobStoreQuery<T> query, EntityContext context) where T : unmanaged, IEntityJobComponent
		{
			if (context.isAllContexts)
			{
				int count = _contexts.Count;
				if ((query.flags & EntityQueryFlags.EnabledEntities) != 0)
				{
					if ((query.flags & EntityQueryFlags.AliveEntities) != 0)
					{
						for (int i = 0; i < count; i++)
						{
							AddToQuery(ref query, _contexts[i].enabledAliveStore);
						}
					}
					if ((query.flags & EntityQueryFlags.DyingEntities) != 0)
					{
						for (int j = 0; j < count; j++)
						{
							AddToQuery(ref query, _contexts[j].enabledDyingStore);
						}
					}
				}
				if ((query.flags & EntityQueryFlags.DisabledEntities) == 0)
				{
					return;
				}
				if ((query.flags & EntityQueryFlags.AliveEntities) != 0)
				{
					for (int k = 0; k < count; k++)
					{
						AddToQuery(ref query, _contexts[k].disableAliveStore);
					}
				}
				if ((query.flags & EntityQueryFlags.DyingEntities) != 0)
				{
					for (int l = 0; l < count; l++)
					{
						AddToQuery(ref query, _contexts[l].disableDyingStore);
					}
				}
				return;
			}
			ContextEntry contextEntry = GetContextEntry(context);
			if ((query.flags & EntityQueryFlags.EnabledEntities) != 0)
			{
				if ((query.flags & EntityQueryFlags.AliveEntities) != 0)
				{
					AddToQuery(ref query, contextEntry.enabledAliveStore);
				}
				if ((query.flags & EntityQueryFlags.DyingEntities) != 0)
				{
					AddToQuery(ref query, contextEntry.enabledDyingStore);
				}
			}
			if ((query.flags & EntityQueryFlags.DisabledEntities) != 0)
			{
				if ((query.flags & EntityQueryFlags.AliveEntities) != 0)
				{
					AddToQuery(ref query, contextEntry.disableAliveStore);
				}
				if ((query.flags & EntityQueryFlags.DyingEntities) != 0)
				{
					AddToQuery(ref query, contextEntry.disableDyingStore);
				}
			}
		}

		private unsafe void AddToQuery<T>(ref EntityJobStoreQuery<T> query, EntityStore store) where T : unmanaged, IEntityJobComponent
		{
			NativeArray<EntityKey> jobComponentDataKeysRaw = store.GetJobComponentDataKeysRaw<T>(query.TypeIndex);
			NativeArray<T> jobComponentDatasRaw = store.GetJobComponentDatasRaw<T>(query.TypeIndex);
			EntityJobStoreQuery<T>.Store value = new EntityJobStoreQuery<T>.Store
			{
				Keys = new UnsafeList<EntityKey>((EntityKey*)NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(jobComponentDataKeysRaw), jobComponentDataKeysRaw.Length),
				Components = new UnsafeList<T>((T*)NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(jobComponentDatasRaw), jobComponentDatasRaw.Length)
			};
			query.Stores->Add(in value);
		}

		public bool HasSingletonObject<T>() where T : class
		{
			return HasSingletonObject(EntityTypeManager.GetIndex<T>());
		}

		public bool HasSingletonObject(int typeIndex)
		{
			int count = _contexts.Count;
			for (int i = 0; i < count; i++)
			{
				if (_contexts[i].enabledAliveStore.GetObjectCount(typeIndex, includeInactive: false) > 0)
				{
					return true;
				}
			}
			EntityTypeManager.TypeInfo infoUpdateInherited = EntityTypeManager.GetInfoUpdateInherited(typeIndex);
			int count2 = infoUpdateInherited.inheritedTypeIndices.Count;
			for (int j = 0; j < count2; j++)
			{
				int typeIndex2 = infoUpdateInherited.inheritedTypeIndices[j];
				for (int k = 0; k < count; k++)
				{
					if (_contexts[k].enabledAliveStore.GetObjectCount(typeIndex2, includeInactive: false) > 0)
					{
						return true;
					}
				}
			}
			return false;
		}

		public T GetSingletonObject<T>() where T : class
		{
			return GetSingletonObject<T>(EntityTypeManager.GetIndex<T>());
		}

		public T GetSingletonObject<T>(int typeIndex) where T : class
		{
			int count = _contexts.Count;
			for (int i = 0; i < count; i++)
			{
				ContextEntry contextEntry = _contexts[i];
				if (contextEntry.enabledAliveStore.GetObjectCount(typeIndex, includeInactive: false) > 0)
				{
					return (T)contextEntry.enabledAliveStore.GetObject(0, typeIndex);
				}
			}
			EntityTypeManager.TypeInfo infoUpdateInherited = EntityTypeManager.GetInfoUpdateInherited(typeIndex);
			int count2 = infoUpdateInherited.inheritedTypeIndices.Count;
			for (int j = 0; j < count2; j++)
			{
				int typeIndex2 = infoUpdateInherited.inheritedTypeIndices[j];
				for (int k = 0; k < count; k++)
				{
					ContextEntry contextEntry2 = _contexts[k];
					if (contextEntry2.enabledAliveStore.GetObjectCount(typeIndex2, includeInactive: false) > 0)
					{
						return (T)contextEntry2.enabledAliveStore.GetObject(0, typeIndex2);
					}
				}
			}
			return null;
		}

		public bool TryGetSingletonObject<T>(out T obj) where T : class
		{
			return TryGetSingletonObject<T>(EntityTypeManager.GetIndex<T>(), out obj);
		}

		public bool TryGetSingletonObject<T>(int typeIndex, out T obj) where T : class
		{
			if (HasSingletonObject(typeIndex))
			{
				obj = GetSingletonObject<T>(typeIndex);
				return true;
			}
			obj = null;
			return false;
		}

		public bool HasSingletonComponent<T>() where T : struct, IEntityStruct
		{
			return HasSingletonComponent(EntityTypeManager.GetIndex<T>());
		}

		public bool HasSingletonComponent(int typeIndex)
		{
			int count = _contexts.Count;
			for (int i = 0; i < count; i++)
			{
				if (_contexts[i].enabledAliveStore.GetComponentCount(typeIndex) > 0)
				{
					return true;
				}
			}
			return false;
		}

		public T GetSingletonComponent<T>(int typeIndex) where T : struct, IEntityStruct
		{
			int count = _contexts.Count;
			for (int i = 0; i < count; i++)
			{
				ContextEntry contextEntry = _contexts[i];
				if (contextEntry.enabledAliveStore.GetComponentCount(typeIndex) > 0)
				{
					return contextEntry.enabledAliveStore.GetComponentData<T>(0, typeIndex);
				}
			}
			throw new InvalidOperationException("Could not find singleton component! (" + TypeUtil.GetFriendlyName<T>() + ")");
		}

		public bool TryGetSingletonComponent<T>(out T comp) where T : struct, IEntityStruct
		{
			return TryGetSingletonComponent<T>(EntityTypeManager.GetIndex<T>(), out comp);
		}

		public bool TryGetSingletonComponent<T>(int typeIndex, out T comp) where T : struct, IEntityStruct
		{
			int count = _contexts.Count;
			for (int i = 0; i < count; i++)
			{
				ContextEntry contextEntry = _contexts[i];
				if (contextEntry.enabledAliveStore.GetComponentCount(typeIndex) > 0)
				{
					comp = contextEntry.enabledAliveStore.GetComponentData<T>(0, typeIndex);
					return true;
				}
			}
			comp = default(T);
			return false;
		}

		public bool HasSingletonJobComponent<T>() where T : unmanaged, IEntityJobComponent
		{
			return HasSingletonJobComponent(EntityTypeManager.GetIndex<T>());
		}

		public bool HasSingletonJobComponent(int typeIndex)
		{
			int count = _contexts.Count;
			for (int i = 0; i < count; i++)
			{
				if (_contexts[i].enabledAliveStore.GetJobComponentCount(typeIndex) > 0)
				{
					return true;
				}
			}
			return false;
		}

		public T GetSingletonJobComponent<T>() where T : unmanaged, IEntityJobComponent
		{
			return GetSingletonJobComponent<T>(EntityTypeManager.GetIndex<T>());
		}

		public T GetSingletonJobComponent<T>(int typeIndex) where T : unmanaged, IEntityJobComponent
		{
			int count = _contexts.Count;
			for (int i = 0; i < count; i++)
			{
				ContextEntry contextEntry = _contexts[i];
				if (contextEntry.enabledAliveStore.GetJobComponentCount(typeIndex) > 0)
				{
					return contextEntry.enabledAliveStore.GetJobComponentData<T>(0, typeIndex);
				}
			}
			throw new InvalidOperationException("Could not find singleton job component! (" + TypeUtil.GetFriendlyName<T>() + ")");
		}

		public bool TryGetSingletonJobComponent<T>(out T comp) where T : unmanaged, IEntityJobComponent
		{
			return TryGetSingletonJobComponent<T>(EntityTypeManager.GetIndex<T>(), out comp);
		}

		public bool TryGetSingletonJobComponent<T>(int typeIndex, out T comp) where T : unmanaged, IEntityJobComponent
		{
			int count = _contexts.Count;
			for (int i = 0; i < count; i++)
			{
				ContextEntry contextEntry = _contexts[i];
				if (contextEntry.enabledAliveStore.GetJobComponentCount(typeIndex) > 0)
				{
					comp = contextEntry.enabledAliveStore.GetJobComponentData<T>(0, typeIndex);
					return true;
				}
			}
			comp = default(T);
			return false;
		}

		public bool HasSingletonEntity<T>()
		{
			return HasSingletonEntity(EntityTypeManager.GetIndex<T>());
		}

		public bool HasSingletonEntity(int typeIndex)
		{
			EntityTypeManager.TypeInfo info = EntityTypeManager.GetInfo(typeIndex);
			return info.category switch
			{
				EntityTypeManager.TypeCategory.Component => HasSingletonComponent(typeIndex), 
				EntityTypeManager.TypeCategory.JobComponent => HasSingletonJobComponent(typeIndex), 
				EntityTypeManager.TypeCategory.Other => HasSingletonObject(typeIndex), 
				_ => throw new InvalidCastException("Unexpected type for entity! " + TypeUtil.GetFriendlyName(info.type)), 
			};
		}

		public EntityKey GetSingletonEntity<T>()
		{
			return GetSingletonEntity(EntityTypeManager.GetIndex<T>());
		}

		public EntityKey GetSingletonEntity(int typeIndex)
		{
			EntityTypeManager.TypeInfo info = EntityTypeManager.GetInfo(typeIndex);
			switch (info.category)
			{
			case EntityTypeManager.TypeCategory.Component:
			{
				int count2 = _contexts.Count;
				for (int j = 0; j < count2; j++)
				{
					ContextEntry contextEntry2 = _contexts[j];
					if (contextEntry2.enabledAliveStore.GetComponentCount(typeIndex) > 0)
					{
						return contextEntry2.enabledAliveStore.GetComponentDataKey(0, typeIndex);
					}
				}
				break;
			}
			case EntityTypeManager.TypeCategory.JobComponent:
			{
				int count3 = _contexts.Count;
				for (int k = 0; k < count3; k++)
				{
					ContextEntry contextEntry3 = _contexts[k];
					if (contextEntry3.enabledAliveStore.GetJobComponentCount(typeIndex) > 0)
					{
						return contextEntry3.enabledAliveStore.GetJobComponentDataKey(0, typeIndex);
					}
				}
				break;
			}
			case EntityTypeManager.TypeCategory.Other:
			{
				int count = _contexts.Count;
				for (int i = 0; i < count; i++)
				{
					ContextEntry contextEntry = _contexts[i];
					if (contextEntry.enabledAliveStore.GetObjectCount(typeIndex, includeInactive: false) > 0)
					{
						return contextEntry.enabledAliveStore.GetObjectKey(0, typeIndex);
					}
				}
				break;
			}
			default:
				throw new InvalidCastException("Unexpected type for entity! " + TypeUtil.GetFriendlyName(info.type));
			}
			throw new InvalidOperationException("Could not find singleton entity! (" + TypeUtil.GetFriendlyName(info.type) + ")");
		}

		public bool TryGetSingletonEntity<T>(out EntityKey key)
		{
			return TryGetSingletonEntity(EntityTypeManager.GetIndex<T>(), out key);
		}

		public bool TryGetSingletonEntity(int typeIndex, out EntityKey key)
		{
			EntityTypeManager.TypeInfo info = EntityTypeManager.GetInfo(typeIndex);
			switch (info.category)
			{
			case EntityTypeManager.TypeCategory.Component:
			{
				int count2 = _contexts.Count;
				for (int j = 0; j < count2; j++)
				{
					ContextEntry contextEntry2 = _contexts[j];
					if (contextEntry2.enabledAliveStore.GetComponentCount(typeIndex) > 0)
					{
						key = contextEntry2.enabledAliveStore.GetComponentDataKey(0, typeIndex);
						return true;
					}
				}
				break;
			}
			case EntityTypeManager.TypeCategory.JobComponent:
			{
				int count3 = _contexts.Count;
				for (int k = 0; k < count3; k++)
				{
					ContextEntry contextEntry3 = _contexts[k];
					if (contextEntry3.enabledAliveStore.GetJobComponentCount(typeIndex) > 0)
					{
						key = contextEntry3.enabledAliveStore.GetJobComponentDataKey(0, typeIndex);
						return true;
					}
				}
				break;
			}
			case EntityTypeManager.TypeCategory.Other:
			{
				int count = _contexts.Count;
				for (int i = 0; i < count; i++)
				{
					ContextEntry contextEntry = _contexts[i];
					if (contextEntry.enabledAliveStore.GetObjectCount(typeIndex, includeInactive: false) > 0)
					{
						key = contextEntry.enabledAliveStore.GetObjectKey(0, typeIndex);
						return true;
					}
				}
				break;
			}
			default:
				throw new InvalidCastException("Unexpected type for entity! " + TypeUtil.GetFriendlyName(info.type));
			}
			key = EntityKey.invalid;
			return false;
		}

		public void SetName(EntityKey key, string name)
		{
			GetEntityEntry(key).name = name;
		}

		public string GetName(EntityKey key)
		{
			return GetEntityEntry(key).name;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int GetSeed(EntityKey key, int seed = 0)
		{
			return Hash.Calculate(key.index, (int)key.version, seed);
		}

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckWriteAndThrowAll()
		{
		}

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckWriteAndThrow<T>() where T : unmanaged, IEntityJobComponent
		{
		}

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckReadAndThrow<T>() where T : unmanaged, IEntityJobComponent
		{
		}

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void EnsureSafetyExists<T>() where T : unmanaged, IEntityJobComponent
		{
		}

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckEntityExists(EntityKey key)
		{
			if (GetEntityEntry(key) == null)
			{
				throw new InvalidOperationException($"Invalid entity! ({key})");
			}
		}

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckHas(EntityKey key, int typeIndex)
		{
			if (!GetEntityEntry(key).Has(typeIndex))
			{
				EntityTypeManager.TypeInfo info = EntityTypeManager.GetInfo(typeIndex);
				if (!TryGetObject<EntityBehaviour>(key, out var obj))
				{
					throw new InvalidOperationException($"Entity does not have {TypeUtil.GetFriendlyName(info.type)}! ({key})!");
				}
				UnityEngine.Debug.LogError("Entity does not have a " + TypeUtil.GetFriendlyName(info.type) + "! (" + obj.name + ")!", obj);
			}
		}

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckDoesNotHave(EntityKey key, int typeIndex)
		{
			if (GetEntityEntry(key).Has(typeIndex))
			{
				EntityTypeManager.TypeInfo info = EntityTypeManager.GetInfo(typeIndex);
				if (!TryGetObject<EntityBehaviour>(key, out var obj))
				{
					throw new InvalidOperationException($"Entity already has a {TypeUtil.GetFriendlyName(info.type)}! ({key})!");
				}
				UnityEngine.Debug.LogError("Entity already has a " + TypeUtil.GetFriendlyName(info.type) + "! (" + obj.name + ")!", obj);
			}
		}

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckEntityContext(EntityContext context)
		{
			if (!context.isValid)
			{
				throw new InvalidOperationException("EntityContext is invalid!");
			}
		}

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckEntityContextNotAll(EntityContext context)
		{
			if (context.isAllContexts)
			{
				throw new InvalidOperationException("EntityContext cannot be All contexts!");
			}
		}

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckEntityContextIndex(EntityContext context)
		{
			if (context.GetIndex() >= _contexts.Count)
			{
				throw new InvalidOperationException("Context index is out of range!");
			}
		}

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void VerifyIsStruct(Type type)
		{
			if (type == null)
			{
				throw new NullReferenceException();
			}
			if (!type.IsValueType)
			{
				throw new InvalidCastException("Type is not a struct! (" + TypeUtil.GetFriendlyName(type) + ")");
			}
		}

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void VerifyIsUnmanaged(Type type)
		{
			if (type == null)
			{
				throw new NullReferenceException();
			}
			if (!UnsafeUtility.IsUnmanaged(type))
			{
				throw new InvalidCastException("Type is not unmanaged! (" + TypeUtil.GetFriendlyName(type) + ")");
			}
		}

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void VerifyIsClass(Type type)
		{
			if (type == null)
			{
				throw new NullReferenceException();
			}
			if (!type.IsClass)
			{
				throw new InvalidCastException("Type is not a class! (" + TypeUtil.GetFriendlyName(type) + ")");
			}
		}

		internal bool TestIsEmpty()
		{
			if (entityCount > 0)
			{
				return false;
			}
			for (int i = 0; i < _contexts.Count; i++)
			{
				ContextEntry contextEntry = _contexts[i];
				if (!contextEntry.enabledAliveStore.TestIsEmpty())
				{
					return false;
				}
				if (!contextEntry.enabledDyingStore.TestIsEmpty())
				{
					return false;
				}
				if (!contextEntry.disableAliveStore.TestIsEmpty())
				{
					return false;
				}
				if (!contextEntry.disableDyingStore.TestIsEmpty())
				{
					return false;
				}
			}
			return true;
		}

		public void Dispose()
		{
			dependency.Complete();
			isValid = false;
			for (int i = 0; i < _contexts.Count; i++)
			{
				_contexts[i].Dispose();
			}
		}
	}
}
