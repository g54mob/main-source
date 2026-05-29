using CTS.BBT;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Furnitures/Syncing/Morgue Count Sync")]
	public class SyncMorgueCount : FurnitureSyncObject<StationMorgue>
	{
		[SerializeField]
		private StringKey _syncKey;

		protected override void Sync(StringKey category, StationMorgue furniture, SyncManager syncManager)
		{
			furniture.SetMaxBodies(syncManager.GetSyncedInt(category, _syncKey));
		}
	}
}
