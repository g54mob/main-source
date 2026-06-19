using System.Collections.Generic;
using Unity.Collections;

namespace Aggro.Core
{
	internal class ComponentEntry<T> : IComponentEntry where T : struct, IEntityStruct
	{
		private readonly List<T> _comps;

		private readonly List<EntityKey> _keys;

		public int Count => _keys.Count;

		public ComponentEntry(int capacity)
		{
			_comps = new List<T>(capacity);
			_keys = new List<EntityKey>(capacity);
		}

		public int AddComponentData(EntityKey key, T data)
		{
			int count = _comps.Count;
			_comps.Add(data);
			_keys.Add(key);
			return count;
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
				return index < _comps.Count;
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

		public int CopyFrom(int copyIndex, IComponentEntry from)
		{
			ComponentEntry<T> componentEntry = (ComponentEntry<T>)from;
			return AddComponentData(componentEntry._keys[copyIndex], componentEntry._comps[copyIndex]);
		}

		public IComponentEntry CreateTypedEntry(int capacity)
		{
			return new ComponentEntry<T>(capacity);
		}

		public EntityKey GetKey(int index)
		{
			return _keys[index];
		}

		public void GetComponentDatas(List<T> list)
		{
			int count = _comps.Count;
			for (int i = 0; i < count; i++)
			{
				list.Add(_comps[i]);
			}
		}

		public void GetKeys(List<EntityKey> list)
		{
			int count = _keys.Count;
			for (int i = 0; i < count; i++)
			{
				list.Add(_keys[i]);
			}
		}
	}
}
