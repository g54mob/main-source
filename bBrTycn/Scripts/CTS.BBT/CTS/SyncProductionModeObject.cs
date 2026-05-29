using CTS.Core;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Furnitures/Syncing/Machine Production Sync")]
	public class SyncProductionModeObject : FurnitureSyncObject<MachineBase>
	{
		[SerializeField]
		private StringKey _productionKey;

		protected override void Sync(StringKey category, MachineBase furniture, SyncManager syncManager)
		{
			furniture.SetProductionMode((EMachineProductionMode)syncManager.GetSyncedInt(category, _productionKey));
		}
	}
}
