using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections;
using UnityEngine;

namespace Aggro.Core
{
	internal class ObjectEntry
	{
		private class Entries
		{
			private struct Entry
			{
				public object obj;

				public EntityTypeManager.TypeFlag typeFlags;
			}

			private readonly List<Entry> _entries;

			private readonly Dictionary<object, int> _objToIndex;

			public int count => _entries.Count;

			public Entries(int capacity)
			{
				_entries = new List<Entry>(capacity);
				_objToIndex = new Dictionary<object, int>(capacity);
			}

			public void AddObject(object obj)
			{
				int value = _entries.Count;
				Entry item = new Entry
				{
					obj = obj
				};
				EntityTypeManager.TypeInfo info = EntityTypeManager.GetInfo(obj.GetType());
				item.typeFlags = info.flags;
				_entries.Add(item);
				_objToIndex[obj] = value;
			}

			public void RemoveObject(object obj)
			{
				if (_objToIndex.TryGetValue(obj, out var value))
				{
					_entries.RemoveAtSwapBack(value);
					_objToIndex.Remove(obj);
					if (value < _entries.Count)
					{
						_objToIndex[_entries[value]] = value;
					}
				}
			}

			public object GetObject(int index)
			{
				return _entries[index].obj;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool IsActive(int index)
			{
				return IsActive(_entries[index]);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private bool IsActive(in Entry entry)
			{
				if ((entry.typeFlags & EntityTypeManager.TypeFlag.CanBeBehaviour) == 0 || (entry.typeFlags & EntityTypeManager.TypeFlag.AlwaysActive) != 0)
				{
					return true;
				}
				if (entry.obj is Behaviour behaviour)
				{
					return behaviour.isActiveAndEnabled;
				}
				return true;
			}

			public void GetObjects(List<object> list, ObjectQueryFlags flags)
			{
				int num = _entries.Count;
				if ((flags & ObjectQueryFlags.AllObjects) == ObjectQueryFlags.AllObjects)
				{
					for (int i = 0; i < num; i++)
					{
						list.Add(_entries[i].obj);
					}
				}
				else if ((flags & ObjectQueryFlags.ActiveAndEnabled) != 0)
				{
					for (int j = 0; j < num; j++)
					{
						Entry entry = _entries[j];
						if (IsActive(in entry))
						{
							list.Add(entry.obj);
						}
					}
				}
				else
				{
					if ((flags & ObjectQueryFlags.InactiveOrDisabled) == 0)
					{
						return;
					}
					for (int k = 0; k < num; k++)
					{
						Entry entry2 = _entries[k];
						if (!IsActive(in entry2))
						{
							list.Add(entry2.obj);
						}
					}
				}
			}

			public void GetObjects<T>(List<T> list, ObjectQueryFlags flags) where T : class
			{
				int num = _entries.Count;
				if ((flags & ObjectQueryFlags.AllObjects) == ObjectQueryFlags.AllObjects)
				{
					for (int i = 0; i < num; i++)
					{
						list.Add((T)_entries[i].obj);
					}
				}
				else if ((flags & ObjectQueryFlags.ActiveAndEnabled) != 0)
				{
					for (int j = 0; j < num; j++)
					{
						Entry entry = _entries[j];
						if (IsActive(in entry))
						{
							list.Add((T)entry.obj);
						}
					}
				}
				else
				{
					if ((flags & ObjectQueryFlags.InactiveOrDisabled) == 0)
					{
						return;
					}
					for (int k = 0; k < num; k++)
					{
						Entry entry2 = _entries[k];
						if (!IsActive(in entry2))
						{
							list.Add((T)entry2.obj);
						}
					}
				}
			}

			public void Clear()
			{
				_entries.Clear();
				_objToIndex.Clear();
			}
		}

		private readonly List<Entries> _entries;

		private readonly List<EntityKey> _keys;

		private readonly int _capacity;

		private readonly EntityTypeManager.TypeInfo _info;

		private readonly Stack<Entries> _pool;

		public ObjectEntry(EntityTypeManager.TypeInfo typeInfo, int capacity)
		{
			_capacity = capacity;
			_info = typeInfo;
			_entries = new List<Entries>(capacity);
			_keys = new List<EntityKey>(capacity);
			_pool = new Stack<Entries>(capacity);
			for (int i = 0; i < capacity; i++)
			{
				_pool.Push(new Entries(capacity));
			}
		}

		public void AddObject(EntityKey key, object obj, ref int entryIndex)
		{
			if (entryIndex >= 0)
			{
				_entries[entryIndex].AddObject(obj);
				return;
			}
			entryIndex = _entries.Count;
			if (!_pool.TryPop(out var result))
			{
				result = new Entries(_capacity);
			}
			result.AddObject(obj);
			_entries.Add(result);
			_keys.Add(key);
		}

		public void RemoveObject(int entryIndex, object obj)
		{
			Entries entries = _entries[entryIndex];
			entries.RemoveObject(obj);
			if (entries.count == 0)
			{
				_pool.Push(entries);
				_entries.RemoveAtSwapBack(entryIndex);
				_keys.RemoveAtSwapBack(entryIndex);
			}
		}

		public void RemoveAllObjects(int entryIndex)
		{
			Entries entries = _entries[entryIndex];
			entries.Clear();
			_pool.Push(entries);
			_entries.RemoveAtSwapBack(entryIndex);
			_keys.RemoveAtSwapBack(entryIndex);
		}

		public bool HasObject(int entryIndex)
		{
			if (entryIndex >= 0 && entryIndex < _entries.Count)
			{
				return true;
			}
			return false;
		}

		public object GetObject(int entryIndex)
		{
			return _entries[entryIndex].GetObject(0);
		}

		public void GetObjects(List<object> objects, int entryIndex, ObjectQueryFlags flags)
		{
			_entries[entryIndex].GetObjects(objects, flags);
		}

		public void GetObjects<T>(List<T> objects, int entryIndex, ObjectQueryFlags flags) where T : class
		{
			_entries[entryIndex].GetObjects(objects, flags);
		}

		public EntityKey GetKey(int entryIndex)
		{
			return _keys[entryIndex];
		}

		public int CopyFrom(int copyIndex, ObjectEntry from)
		{
			int entryIndex = -1;
			EntityKey key = from._keys[copyIndex];
			Entries entries = from._entries[copyIndex];
			int count = entries.count;
			for (int i = 0; i < count; i++)
			{
				AddObject(key, entries.GetObject(i), ref entryIndex);
			}
			return entryIndex;
		}

		public void GetQueryResults(List<QueryResult> results, bool includeInactive)
		{
			int count = _keys.Count;
			QueryResult item = new QueryResult
			{
				typeIndex = _info.typeIndex
			};
			if (includeInactive || (_info.flags & EntityTypeManager.TypeFlag.CanBeBehaviour) == 0 || (_info.flags & EntityTypeManager.TypeFlag.AlwaysActive) != 0)
			{
				for (int i = 0; i < count; i++)
				{
					item.key = _keys[i];
					Entries entries = _entries[i];
					int count2 = entries.count;
					for (int j = 0; j < count2; j++)
					{
						item.obj = entries.GetObject(j);
						results.Add(item);
					}
				}
				return;
			}
			for (int k = 0; k < count; k++)
			{
				item.key = _keys[k];
				Entries entries2 = _entries[k];
				int count3 = entries2.count;
				for (int l = 0; l < count3; l++)
				{
					if (entries2.IsActive(l))
					{
						item.obj = entries2.GetObject(l);
						results.Add(item);
					}
				}
			}
		}

		public void GetQueryResults<T>(List<QueryResult<T>> results, bool includeInactive) where T : class
		{
			int count = _keys.Count;
			QueryResult<T> item = new QueryResult<T>
			{
				typeIndex = _info.typeIndex
			};
			if (includeInactive || (_info.flags & EntityTypeManager.TypeFlag.CanBeBehaviour) == 0 || (_info.flags & EntityTypeManager.TypeFlag.AlwaysActive) != 0)
			{
				for (int i = 0; i < count; i++)
				{
					item.key = _keys[i];
					Entries entries = _entries[i];
					int count2 = entries.count;
					for (int j = 0; j < count2; j++)
					{
						item.obj = (T)entries.GetObject(j);
						results.Add(item);
					}
				}
				return;
			}
			for (int k = 0; k < count; k++)
			{
				item.key = _keys[k];
				Entries entries2 = _entries[k];
				int count3 = entries2.count;
				for (int l = 0; l < count3; l++)
				{
					if (entries2.IsActive(l))
					{
						item.obj = (T)entries2.GetObject(l);
						results.Add(item);
					}
				}
			}
		}

		public int GetKeyCount()
		{
			return _keys.Count;
		}

		public int GetObjectCount(bool includeInactive)
		{
			int num = 0;
			int count = _entries.Count;
			if (includeInactive || (_info.flags & EntityTypeManager.TypeFlag.CanBeBehaviour) == 0 || (_info.flags & EntityTypeManager.TypeFlag.AlwaysActive) != 0)
			{
				for (int i = 0; i < count; i++)
				{
					num += _entries[i].count;
				}
			}
			else
			{
				for (int j = 0; j < count; j++)
				{
					Entries entries = _entries[j];
					int count2 = entries.count;
					for (int k = 0; k < count2; k++)
					{
						if (entries.IsActive(k))
						{
							num++;
						}
					}
				}
			}
			return num;
		}
	}
}
