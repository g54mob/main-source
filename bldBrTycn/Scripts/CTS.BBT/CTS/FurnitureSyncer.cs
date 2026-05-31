using System;
using CTS.BBT;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class FurnitureSyncer : CTSBehaviour
	{
		[SerializeField]
		private FurnitureSyncObject[] _syncs;

		[SerializeField]
		[Inject(false)]
		private FurnitureInteractor _furniture;

		[InjectScope(EGetScope.Singleton)]
		[SerializeField]
		[Inject(false)]
		private SyncManager _syncManager;

		[field: SerializeField]
		public StringKey SyncKey { get; private set; }

		public bool IsSynced { get; private set; }

		public event Action SyncingChanged;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			if (SyncKey.IsValid())
			{
				_syncManager.AddListener(SyncKey, OnSyncedValuesChanged);
			}
			SetSyncing(value: true);
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			if (SyncKey.IsValid())
			{
				_syncManager.RemoveListener(SyncKey, OnSyncedValuesChanged);
			}
		}

		public void Sync()
		{
			if (SyncKey.IsValid() && IsSynced)
			{
				FurnitureSyncObject[] syncs = _syncs;
				for (int i = 0; i < syncs.Length; i++)
				{
					syncs[i].Sync(SyncKey, _furniture, _syncManager);
				}
			}
		}

		private void OnSyncedValuesChanged()
		{
			Sync();
		}

		public void SetSyncing(bool value)
		{
			if (value != IsSynced)
			{
				IsSynced = value;
				this.SyncingChanged?.Invoke();
				Sync();
			}
		}
	}
}
