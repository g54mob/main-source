using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections;

namespace Aggro.Core
{
	internal class EntityEntry
	{
		public struct EntityEntryItem
		{
			public int typeIndex;

			public int entryIndex;
		}

		[Flags]
		public enum EntityEntryFlags : byte
		{
			None = 0,
			Enabled = 1,
			Dying = 2
		}

		public uint version;

		public EntityContext context;

		public EntityEntryFlags flags;

		public string name = "";

		private List<int> _typeToIndex = new List<int>();

		private List<EntityEntryItem> _objItems = new List<EntityEntryItem>();

		private List<EntityEntryItem> _compItems = new List<EntityEntryItem>();

		private List<EntityEntryItem> _jobCompItems = new List<EntityEntryItem>();

		public List<EntityEntryItem> objItems => _objItems;

		public List<EntityEntryItem> compItems => _compItems;

		public List<EntityEntryItem> jobCompItems => _jobCompItems;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SetEnabled(bool enabled)
		{
			if (enabled)
			{
				flags |= EntityEntryFlags.Enabled;
			}
			else
			{
				flags &= ~EntityEntryFlags.Enabled;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsEnabled()
		{
			return (flags & EntityEntryFlags.Enabled) != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SetDying()
		{
			flags |= EntityEntryFlags.Dying;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsDying()
		{
			return (flags & EntityEntryFlags.Dying) != 0;
		}

		public void AddComponentData(int typeIndex, int index)
		{
			Add(_compItems, typeIndex, index);
		}

		public void AddJobComponentData(int typeIndex, int index)
		{
			Add(_jobCompItems, typeIndex, index);
		}

		public void AddObject(int typeIndex, int index)
		{
			Add(_objItems, typeIndex, index);
		}

		private void Add(List<EntityEntryItem> items, int typeIndex, int index)
		{
			while (_typeToIndex.Count <= typeIndex)
			{
				_typeToIndex.Add(-1);
			}
			int num = _typeToIndex[typeIndex];
			if (num == -1)
			{
				num = items.Count;
				_typeToIndex[typeIndex] = num;
				items.Add(new EntityEntryItem
				{
					typeIndex = typeIndex,
					entryIndex = index
				});
			}
		}

		public bool Has(int typeIndex)
		{
			if (typeIndex < _typeToIndex.Count)
			{
				return _typeToIndex[typeIndex] != -1;
			}
			return false;
		}

		public int GetComponentDataIndex(int typeIndex)
		{
			return GetIndex(_compItems, typeIndex);
		}

		public int GetJobComponentDataIndex(int typeIndex)
		{
			return GetIndex(_jobCompItems, typeIndex);
		}

		public int GetObjectIndex(int typeIndex)
		{
			return GetIndex(_objItems, typeIndex);
		}

		private int GetIndex(List<EntityEntryItem> items, int typeIndex)
		{
			if (typeIndex >= _typeToIndex.Count)
			{
				return -1;
			}
			int num = _typeToIndex[typeIndex];
			if (num == -1)
			{
				return -1;
			}
			return items[num].entryIndex;
		}

		public void RemoveComponentDataIndex(int typeIndex)
		{
			RemoveIndex(_compItems, typeIndex);
		}

		public void RemoveJobComponentDataIndex(int typeIndex)
		{
			RemoveIndex(_jobCompItems, typeIndex);
		}

		public void RemoveObjectIndex(int typeIndex)
		{
			RemoveIndex(_objItems, typeIndex);
		}

		private void RemoveIndex(List<EntityEntryItem> items, int typeIndex)
		{
			int num = _typeToIndex[typeIndex];
			_typeToIndex[typeIndex] = -1;
			items.RemoveAtSwapBack(num);
			if (num < items.Count)
			{
				EntityEntryItem entityEntryItem = items[num];
				_typeToIndex[entityEntryItem.typeIndex] = num;
			}
		}

		public void UpdateComponentDataIndex(int typeIndex, int dataIndex)
		{
			UpdateIndex(_compItems, typeIndex, dataIndex);
		}

		public void UpdateJobComponentDataIndex(int typeIndex, int dataIndex)
		{
			UpdateIndex(_jobCompItems, typeIndex, dataIndex);
		}

		public void UpdateObjectIndex(int typeIndex, int objIndex)
		{
			UpdateIndex(_objItems, typeIndex, objIndex);
		}

		private void UpdateIndex(List<EntityEntryItem> items, int typeIndex, int entryIndex)
		{
			int index = _typeToIndex[typeIndex];
			EntityEntryItem value = items[index];
			value.entryIndex = entryIndex;
			items[index] = value;
		}

		public void Clear()
		{
			flags = EntityEntryFlags.None;
			_typeToIndex.Clear();
			_objItems.Clear();
			_compItems.Clear();
			_jobCompItems.Clear();
		}
	}
}
