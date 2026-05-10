using FishNet.Object;
using FishNet.Object.Synchronizing;

namespace FishNet.Example.ComponentStateSync
{
	public class ComponentSyncStateBehaviour : NetworkBehaviour
	{
		[SyncObject]
		private readonly ComponentStateSync<AMonoScript> _syncScript;

		private bool NetworkInitialize___EarlyFishNet_002EExample_002EComponentStateSync_002EComponentSyncStateBehaviourFishNet_002EDemos_002Edll_Excuted;

		private bool NetworkInitialize__LateFishNet_002EExample_002EComponentStateSync_002EComponentSyncStateBehaviourFishNet_002EDemos_002Edll_Excuted;

		public virtual void Awake()
		{
		}

		private void _syncScript_OnChange(AMonoScript component, bool prevState, bool nextState, bool asServer)
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

		private void Awake_UserLogic_FishNet_002EExample_002EComponentStateSync_002EComponentSyncStateBehaviour_FishNet_002EDemos_002Edll()
		{
		}
	}
}
