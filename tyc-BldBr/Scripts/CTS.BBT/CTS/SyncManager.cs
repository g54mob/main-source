using System;
using System.Collections.Generic;
using CTS.Core;
using CTS.Core.Utilities;

namespace CTS
{
	public class SyncManager : CTSSingleton<SyncManager>
	{
		public class SyncData
		{
			private readonly Dictionary<StringKey, bool> _syncedBools = new Dictionary<StringKey, bool>();

			private readonly Dictionary<StringKey, int> _syncedInts = new Dictionary<StringKey, int>();

			private readonly Dictionary<StringKey, float> _syncedFloats = new Dictionary<StringKey, float>();

			public ReadOnlyDictionary<StringKey, bool> SyncedBools => _syncedBools;

			public ReadOnlyDictionary<StringKey, int> SyncedInts => _syncedInts;

			public ReadOnlyDictionary<StringKey, float> SyncedFloats => _syncedFloats;

			public event Action SyncedValuesChanged;

			public void SetSyncedBool(StringKey key, bool value)
			{
				_syncedBools[key] = value;
				this.SyncedValuesChanged?.Invoke();
			}

			public void SetSyncedInt(StringKey key, int value)
			{
				_syncedInts[key] = value;
				this.SyncedValuesChanged?.Invoke();
			}

			public void SetSyncedFloat(StringKey key, float value)
			{
				_syncedFloats[key] = value;
				this.SyncedValuesChanged?.Invoke();
			}

			public bool GetSyncedBool(StringKey key)
			{
				return _syncedBools.GetValueOrDefault(key);
			}

			public int GetSyncedInt(StringKey key)
			{
				return _syncedInts.GetValueOrDefault(key);
			}

			public float GetSyncedFloat(StringKey key)
			{
				return _syncedFloats.GetValueOrDefault(key);
			}
		}

		private readonly Dictionary<StringKey, SyncData> _syncedData = new Dictionary<StringKey, SyncData>();

		public ReadOnlyDictionary<StringKey, SyncData> SyncedData => _syncedData;

		protected override void SingletonAwake()
		{
		}

		protected override void OnSingletonDestroy()
		{
		}

		public void AddListener(StringKey category, Action action)
		{
			GetCategory(category).SyncedValuesChanged += action;
		}

		public void RemoveListener(StringKey category, Action action)
		{
			GetCategory(category).SyncedValuesChanged -= action;
		}

		public void SetSyncedBool(StringKey cat, StringKey key, bool value)
		{
			GetCategory(cat).SetSyncedBool(key, value);
		}

		public void SetSyncedInt(StringKey cat, StringKey key, int value)
		{
			GetCategory(cat).SetSyncedInt(key, value);
		}

		public void SetSyncedFloat(StringKey cat, StringKey key, float value)
		{
			GetCategory(cat).SetSyncedFloat(key, value);
		}

		public bool GetSyncedBool(StringKey cat, StringKey key)
		{
			return GetCategory(cat).GetSyncedBool(key);
		}

		public int GetSyncedInt(StringKey cat, StringKey key)
		{
			return GetCategory(cat).GetSyncedInt(key);
		}

		public float GetSyncedFloat(StringKey cat, StringKey key)
		{
			return GetCategory(cat).GetSyncedFloat(key);
		}

		public SyncData GetCategory(StringKey cat)
		{
			if (!_syncedData.TryGetValue(cat, out var value))
			{
				value = new SyncData();
				_syncedData[cat] = value;
			}
			return value;
		}
	}
}
