using System;
using System.Collections.Generic;
using Unity.Collections;

namespace Aggro.Core
{
	internal class EntityStore : IDisposable
	{
		private List<ObjectEntry> _objEntries = new List<ObjectEntry>();

		private List<IComponentEntry> _compEntries = new List<IComponentEntry>();

		private List<IJobComponentEntry> _jobCompEntries = new List<IJobComponentEntry>();

		private readonly int _capacity;

		private readonly Allocator _allocator;

		public uint version { get; private set; }

		public EntityStore(int capacity, Allocator allocator)
		{
			_capacity = capacity;
			_allocator = allocator;
			int count = EntityTypeManager.count;
			for (int i = 0; i < count; i++)
			{
				EntityTypeManager.TypeInfo info = EntityTypeManager.GetInfo(i);
				if (info.category == EntityTypeManager.TypeCategory.Other)
				{
					_objEntries.Add(new ObjectEntry(info, _capacity));
				}
				else
				{
					_objEntries.Add(null);
				}
			}
		}

		public bool HasObject(int entryIndex, int typeIndex)
		{
			if (typeIndex < _objEntries.Count)
			{
				return _objEntries[typeIndex].HasObject(entryIndex);
			}
			return false;
		}

		public int AddComponentData<T>(EntityKey key, T comp, int typeIndex) where T : struct, IEntityStruct
		{
			version++;
			CreateEntryForComponentData<T>(typeIndex);
			while (_compEntries.Count <= typeIndex)
			{
				_compEntries.Add(null);
			}
			return ((ComponentEntry<T>)_compEntries[typeIndex]).AddComponentData(key, comp);
		}

		private void CreateEntryForComponentData<T>(int typeIndex) where T : struct, IEntityStruct
		{
			while (_compEntries.Count <= typeIndex)
			{
				_compEntries.Add(null);
			}
			if (_compEntries[typeIndex] == null)
			{
				version++;
				_compEntries[typeIndex] = new ComponentEntry<T>(_capacity);
			}
		}

		public int AddJobComponentData<T>(EntityKey key, T comp, int typeIndex) where T : unmanaged, IEntityJobComponent
		{
			version++;
			CreateEntryForJobComponentData<T>(typeIndex);
			return ((JobComponentEntry<T>)_jobCompEntries[typeIndex]).AddComponentData(key, comp);
		}

		private void CreateEntryForJobComponentData<T>(int typeIndex) where T : unmanaged, IEntityJobComponent
		{
			while (_jobCompEntries.Count <= typeIndex)
			{
				_jobCompEntries.Add(null);
			}
			if (_jobCompEntries[typeIndex] == null)
			{
				version++;
				_jobCompEntries[typeIndex] = new JobComponentEntry<T>(_capacity, _allocator);
			}
		}

		public void AddObject(EntityKey key, object obj, int typeIndex, ref int entryIndex)
		{
			version++;
			CreateEntryForObject(typeIndex);
			_objEntries[typeIndex].AddObject(key, obj, ref entryIndex);
		}

		private void CreateEntryForObject(int typeIndex)
		{
			while (_objEntries.Count <= typeIndex)
			{
				EntityTypeManager.TypeInfo info = EntityTypeManager.GetInfo(_objEntries.Count);
				if (info.category == EntityTypeManager.TypeCategory.Other)
				{
					version++;
					_objEntries.Add(new ObjectEntry(info, _capacity));
				}
				else
				{
					_objEntries.Add(null);
				}
			}
		}

		public T GetComponentData<T>(int entryIndex, int typeIndex) where T : struct, IEntityStruct
		{
			return ((ComponentEntry<T>)_compEntries[typeIndex]).GetComponentData(entryIndex);
		}

		public EntityKey GetComponentDataKey(int entryIndex, int typeIndex)
		{
			return _compEntries[typeIndex].GetKey(entryIndex);
		}

		public T GetJobComponentData<T>(int entryIndex, int typeIndex) where T : unmanaged, IEntityJobComponent
		{
			return ((JobComponentEntry<T>)_jobCompEntries[typeIndex]).GetComponentData(entryIndex);
		}

		public EntityKey GetJobComponentDataKey(int entryIndex, int typeIndex)
		{
			return _jobCompEntries[typeIndex].GetKey(entryIndex);
		}

		public object GetObject(int entryIndex, int typeIndex)
		{
			return _objEntries[typeIndex].GetObject(entryIndex);
		}

		public void GetObjects(List<object> objects, int entryIndex, int typeIndex, ObjectQueryFlags flags)
		{
			_objEntries[typeIndex].GetObjects(objects, entryIndex, flags);
		}

		public void GetObjects<T>(List<T> objects, int entryIndex, int typeIndex, ObjectQueryFlags flags) where T : class
		{
			_objEntries[typeIndex].GetObjects(objects, entryIndex, flags);
		}

		public EntityKey GetObjectKey(int entyIndex, int typeIndex)
		{
			return _objEntries[typeIndex].GetKey(entyIndex);
		}

		public void SetComponentData<T>(int entryIndex, T comp, int typeIndex) where T : struct, IEntityStruct
		{
			((ComponentEntry<T>)_compEntries[typeIndex]).SetComponentData(entryIndex, comp);
		}

		public void SetJobComponentData<T>(int entryIndex, T comp, int typeIndex) where T : unmanaged, IEntityJobComponent
		{
			((JobComponentEntry<T>)_jobCompEntries[typeIndex]).SetComponentData(entryIndex, comp);
		}

		public int CopyComponentDataFrom(int entryIndex, int typeIndex, EntityStore from)
		{
			while (_compEntries.Count <= typeIndex)
			{
				_compEntries.Add(null);
			}
			IComponentEntry componentEntry = _compEntries[typeIndex];
			if (componentEntry == null)
			{
				componentEntry = from._compEntries[typeIndex].CreateTypedEntry(_capacity);
				_compEntries[typeIndex] = componentEntry;
			}
			return componentEntry.CopyFrom(entryIndex, from._compEntries[typeIndex]);
		}

		public int CopyJobComponentDataFrom(int entryIndex, int typeIndex, EntityStore from)
		{
			while (_jobCompEntries.Count <= typeIndex)
			{
				_jobCompEntries.Add(null);
			}
			IJobComponentEntry jobComponentEntry = _jobCompEntries[typeIndex];
			if (jobComponentEntry == null)
			{
				jobComponentEntry = from._jobCompEntries[typeIndex].CreateTypedEntry(_capacity, _allocator);
				_jobCompEntries[typeIndex] = jobComponentEntry;
			}
			return jobComponentEntry.CopyFrom(entryIndex, from._jobCompEntries[typeIndex]);
		}

		public int CopyObjectFrom(int entryIndex, int typeIndex, EntityStore from)
		{
			while (_objEntries.Count <= typeIndex)
			{
				EntityTypeManager.TypeInfo info = EntityTypeManager.GetInfo(_objEntries.Count);
				if (info.category == EntityTypeManager.TypeCategory.Other)
				{
					_objEntries.Add(new ObjectEntry(info, _capacity));
				}
				else
				{
					_objEntries.Add(null);
				}
			}
			return _objEntries[typeIndex].CopyFrom(entryIndex, from._objEntries[typeIndex]);
		}

		public EntityKey RemoveComponentData(int entryIndex, int typeIndex)
		{
			IComponentEntry componentEntry = _compEntries[typeIndex];
			componentEntry.RemoveComponentData(entryIndex);
			if (componentEntry.HasComponentData(entryIndex))
			{
				return componentEntry.GetKey(entryIndex);
			}
			return EntityKey.invalid;
		}

		public EntityKey RemoveJobComponentData(int entryIndex, int typeIndex)
		{
			IJobComponentEntry jobComponentEntry = _jobCompEntries[typeIndex];
			jobComponentEntry.RemoveComponentData(entryIndex);
			if (jobComponentEntry.HasComponentData(entryIndex))
			{
				return jobComponentEntry.GetKey(entryIndex);
			}
			return EntityKey.invalid;
		}

		public EntityKey RemoveAllObjects(int entryIndex, int typeIndex)
		{
			ObjectEntry objectEntry = _objEntries[typeIndex];
			objectEntry.RemoveAllObjects(entryIndex);
			if (objectEntry.HasObject(entryIndex))
			{
				return objectEntry.GetKey(entryIndex);
			}
			return EntityKey.invalid;
		}

		public EntityKey RemoveObject(int entryIndex, int typeIndex, object obj)
		{
			ObjectEntry objectEntry = _objEntries[typeIndex];
			objectEntry.RemoveObject(entryIndex, obj);
			if (objectEntry.HasObject(entryIndex))
			{
				return objectEntry.GetKey(entryIndex);
			}
			return EntityKey.invalid;
		}

		public void GetComponentDataKeys(List<EntityKey> keys, int typeIndex)
		{
			if (typeIndex < _compEntries.Count)
			{
				_compEntries[typeIndex]?.GetKeys(keys);
			}
		}

		public void GetJobComponentDataKeys(List<EntityKey> keys, int typeIndex)
		{
			if (typeIndex < _jobCompEntries.Count)
			{
				_jobCompEntries[typeIndex]?.GetKeys(keys);
			}
		}

		public NativeArray<EntityKey> GetJobComponentDataKeysRaw<T>(int typeIndex) where T : unmanaged, IEntityJobComponent
		{
			CreateEntryForJobComponentData<T>(typeIndex);
			return _jobCompEntries[typeIndex].GetKeysRaw();
		}

		public NativeArray<T> GetJobComponentDatasRaw<T>(int typeIndex) where T : unmanaged, IEntityJobComponent
		{
			CreateEntryForJobComponentData<T>(typeIndex);
			return ((JobComponentEntry<T>)_jobCompEntries[typeIndex]).GetComponentsRaw();
		}

		public void GetObjectQueryResults(List<QueryResult> results, int typeIndex, bool includeInactive)
		{
			CreateEntryForObject(typeIndex);
			_objEntries[typeIndex].GetQueryResults(results, includeInactive);
		}

		public void GetObjectQueryResults<T>(List<QueryResult<T>> results, int typeIndex, bool includeInactive) where T : class
		{
			CreateEntryForObject(typeIndex);
			_objEntries[typeIndex].GetQueryResults(results, includeInactive);
		}

		public void GetComponentKeys<T>(List<EntityKey> keys, int typeIndex) where T : struct, IEntityStruct
		{
			CreateEntryForComponentData<T>(typeIndex);
			_compEntries[typeIndex].GetKeys(keys);
		}

		public void GetComponents<T>(List<T> components, int typeIndex) where T : struct, IEntityStruct
		{
			CreateEntryForComponentData<T>(typeIndex);
			ComponentEntry<T> componentEntry = (ComponentEntry<T>)_compEntries[typeIndex];
			int count = componentEntry.Count;
			for (int i = 0; i < count; i++)
			{
				components.Add(componentEntry.GetComponentData(i));
			}
		}

		public int GetObjectCount(int typeIndex, bool includeInactive)
		{
			if (typeIndex < _objEntries.Count)
			{
				return _objEntries[typeIndex].GetObjectCount(includeInactive);
			}
			return 0;
		}

		public int GetComponentCount(int typeIndex)
		{
			if (typeIndex < _compEntries.Count)
			{
				IComponentEntry componentEntry = _compEntries[typeIndex];
				if (componentEntry != null)
				{
					return componentEntry.Count;
				}
			}
			return 0;
		}

		public int GetJobComponentCount(int typeIndex)
		{
			if (typeIndex < _jobCompEntries.Count)
			{
				IJobComponentEntry jobComponentEntry = _jobCompEntries[typeIndex];
				if (jobComponentEntry != null)
				{
					return jobComponentEntry.Count;
				}
			}
			return 0;
		}

		internal bool TestIsEmpty()
		{
			for (int i = 0; i < _objEntries.Count; i++)
			{
				ObjectEntry objectEntry = _objEntries[i];
				if (objectEntry != null && objectEntry.GetObjectCount(includeInactive: true) > 0)
				{
					return false;
				}
			}
			for (int j = 0; j < _jobCompEntries.Count; j++)
			{
				IJobComponentEntry jobComponentEntry = _jobCompEntries[j];
				if (jobComponentEntry != null && jobComponentEntry.Count > 0)
				{
					return false;
				}
			}
			return true;
		}

		public void Dispose()
		{
			for (int i = 0; i < _jobCompEntries.Count; i++)
			{
				if (_jobCompEntries[i] is IDisposable disposable)
				{
					disposable.Dispose();
				}
			}
		}
	}
}
