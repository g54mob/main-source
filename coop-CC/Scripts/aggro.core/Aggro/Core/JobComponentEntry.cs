using System;
using System.Collections.Generic;
using Unity.Collections;

namespace Aggro.Core
{
	internal class JobComponentEntry<T> : IJobComponentEntry, IDisposable where T : unmanaged, IEntityJobComponent
	{
		private NativeList<T> _comps;

		private NativeList<EntityKey> _keys;

		public int Count => _keys.Length;

		public JobComponentEntry(int capacity, Allocator allocator)
		{
			_comps = new NativeList<T>(capacity, allocator);
			_keys = new NativeList<EntityKey>(capacity, allocator);
		}

		public int AddComponentData(EntityKey key, T data)
		{
			int length = _comps.Length;
			_comps.Add(in data);
			_keys.Add(in key);
			return length;
		}

		public void RemoveComponentData(int index)
		{
			_comps.RemoveAtSwapBack(index);
			_keys.RemoveAtSwapBack(index);
		}

		public bool HasComponentData(int index)
		{
			if (index >= 0)
			{
				return index < _comps.Length;
			}
			return false;
		}

		public T GetComponentData(int index)
		{
			return _comps[index];
		}

		public void SetComponentData(int index, T data)
		{
			_comps[index] = data;
		}

		public int CopyFrom(int copyIndex, IJobComponentEntry from)
		{
			JobComponentEntry<T> jobComponentEntry = (JobComponentEntry<T>)from;
			return AddComponentData(jobComponentEntry._keys[copyIndex], jobComponentEntry._comps[copyIndex]);
		}

		public IJobComponentEntry CreateTypedEntry(int capacity, Allocator allocator)
		{
			return new JobComponentEntry<T>(capacity, allocator);
		}

		public EntityKey GetKey(int index)
		{
			return _keys[index];
		}

		public void GetComponentDatas(List<T> list)
		{
			int length = _comps.Length;
			for (int i = 0; i < length; i++)
			{
				list.Add(_comps[i]);
			}
		}

		public void GetKeys(List<EntityKey> list)
		{
			int length = _keys.Length;
			for (int i = 0; i < length; i++)
			{
				list.Add(_keys[i]);
			}
		}

		public void GetComponentDatas(NativeList<T> list)
		{
			list.AddRange(_comps.AsArray());
		}

		public void GetKeys(NativeList<EntityKey> list)
		{
			list.AddRange(_keys.AsArray());
		}

		public NativeArray<T> GetComponentsRaw()
		{
			return _comps.AsArray();
		}

		public NativeArray<EntityKey> GetKeysRaw()
		{
			return _keys.AsArray();
		}

		public void Dispose()
		{
			_comps.Dispose();
			_keys.Dispose();
		}
	}
}
