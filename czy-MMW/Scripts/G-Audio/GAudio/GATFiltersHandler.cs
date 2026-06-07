using System;
using System.Collections.Generic;
using UnityEngine;

namespace GAudio
{
	[Serializable]
	public class GATFiltersHandler : ScriptableObject
	{
		[SerializeField]
		protected List<AGATMonoFilter> _filters;

		[SerializeField]
		protected int _nbOfChannelsToFilter;

		protected object _lock = new object();

		public bool HasFilters => _filters.Count != 0;

		public int NbOfFilteredChannels => _nbOfChannelsToFilter;

		public void InitFiltersHandler(int nbOfChannelsToFilter)
		{
			_nbOfChannelsToFilter = nbOfChannelsToFilter;
			_filters = new List<AGATMonoFilter>(4);
		}

		public bool ApplyFilters(float[] data, int offset, int length, bool emptyData)
		{
			bool result = false;
			lock (_lock)
			{
				for (int i = 0; i < _filters.Count; i++)
				{
					if (!_filters[i].Bypass && _filters[i].ProcessChunk(data, offset, length, emptyData))
					{
						result = true;
					}
				}
				return result;
			}
		}

		public AGATMonoFilter AddFilter<T>(int slotIndex) where T : AGATMonoFilter
		{
			int index;
			if (_filters.Count == 0)
			{
				index = 0;
			}
			else
			{
				index = _filters.Count;
				for (int i = 0; i < _filters.Count; i++)
				{
					if (_filters[i].SlotIndex == slotIndex)
					{
						return null;
					}
					if (_filters[i].SlotIndex > slotIndex)
					{
						index = i;
						break;
					}
				}
			}
			T val = ScriptableObject.CreateInstance<T>();
			if (val == null)
			{
				Debug.LogWarning("Failed to instantiate");
			}
			val.InitFilter(slotIndex);
			if (val.NbOfFilterableChannels == 1 && _nbOfChannelsToFilter > 1)
			{
				AGATMonoFilter multiChannelWrapper = val.GetMultiChannelWrapper<T>(_nbOfChannelsToFilter);
				multiChannelWrapper.InitFilter(slotIndex);
				lock (_lock)
				{
					_filters.Insert(index, multiChannelWrapper);
					return multiChannelWrapper;
				}
			}
			lock (_lock)
			{
				_filters.Insert(index, val);
			}
			return val;
		}

		public void RemoveFilterAtSlot(int slotIndex)
		{
			AGATMonoFilter aGATMonoFilter = null;
			if (_filters.Count == 0)
			{
				return;
			}
			for (int i = 0; i < _filters.Count; i++)
			{
				if (_filters[i].SlotIndex == slotIndex)
				{
					aGATMonoFilter = _filters[i];
					break;
				}
			}
			if (!(aGATMonoFilter == null))
			{
				lock (_lock)
				{
					_filters.Remove(aGATMonoFilter);
				}
				if (Application.isPlaying)
				{
					UnityEngine.Object.Destroy(aGATMonoFilter);
				}
				else
				{
					UnityEngine.Object.DestroyImmediate(aGATMonoFilter);
				}
			}
		}

		public AGATMonoFilter GetFilterAtSlot(int slotIndex)
		{
			if (_filters.Count == 0)
			{
				return null;
			}
			for (int i = 0; i < _filters.Count; i++)
			{
				if (_filters[i].SlotIndex == slotIndex)
				{
					return _filters[i];
				}
			}
			return null;
		}

		private void OnDestroy()
		{
			if (Application.isPlaying)
			{
				lock (_lock)
				{
					for (int i = 0; i < _filters.Count; i++)
					{
						UnityEngine.Object.Destroy(_filters[i]);
					}
					_filters.Clear();
					return;
				}
			}
			lock (_lock)
			{
				for (int i = 0; i < _filters.Count; i++)
				{
					UnityEngine.Object.DestroyImmediate(_filters[i]);
				}
				_filters.Clear();
			}
		}
	}
}
