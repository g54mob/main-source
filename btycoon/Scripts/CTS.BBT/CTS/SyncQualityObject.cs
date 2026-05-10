using CTS.Core;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Furnitures/Syncing/Machine Blood Quality Sync")]
	public class SyncQualityObject : FurnitureSyncObject<MachineBase>
	{
		[SerializeField]
		private StringKey _qualityKey;

		protected override void Sync(StringKey category, MachineBase furniture, SyncManager syncManager)
		{
			furniture.MachineBloodQuality.SetBloodQuality(syncManager.GetSyncedInt(category, _qualityKey));
		}
	}
}
