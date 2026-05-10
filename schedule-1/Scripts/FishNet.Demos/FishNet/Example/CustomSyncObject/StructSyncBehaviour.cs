using FishNet.Object;
using FishNet.Object.Synchronizing;

namespace FishNet.Example.CustomSyncObject
{
	public class StructSyncBehaviour : NetworkBehaviour
	{
		[SyncObject]
		private readonly StructySync _structy;

		private bool NetworkInitialize___EarlyFishNet_002EExample_002ECustomSyncObject_002EStructSyncBehaviourFishNet_002EDemos_002Edll_Excuted;

		private bool NetworkInitialize__LateFishNet_002EExample_002ECustomSyncObject_002EStructSyncBehaviourFishNet_002EDemos_002Edll_Excuted;

		public virtual void Awake()
		{
		}

		private void _structy_OnChange(StructySync.CustomOperation op, Structy oldItem, Structy newItem, bool asServer)
		{
		}

		private void Update()
		{
		}

		public virtual void NetworkInitialize___Early()
		{
		}

		public virtual void NetworkInitialize__Late()
		{
		}

		public override void NetworkInitializeIfDisabled()
		{
		}

		private void Awake_UserLogic_FishNet_002EExample_002ECustomSyncObject_002EStructSyncBehaviour_FishNet_002EDemos_002Edll()
		{
		}
	}
}
