using CTS.BBT;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Furnitures/Syncing/Credibility Sync")]
	public class SyncCredibilityObject : FurnitureSyncObject<IBodyDisposalMachine>
	{
		[SerializeField]
		private StringKey _credibilityKey;

		protected override void Sync(StringKey category, IBodyDisposalMachine furniture, SyncManager syncManager)
		{
			furniture.MachineCredibility.SetCredibility(syncManager.GetSyncedInt(category, _credibilityKey));
		}
	}
}
