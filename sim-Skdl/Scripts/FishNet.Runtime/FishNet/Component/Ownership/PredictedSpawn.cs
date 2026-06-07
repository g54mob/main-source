using FishNet.Connection;
using FishNet.Object;
using UnityEngine;

namespace FishNet.Component.Ownership
{
	public class PredictedSpawn : NetworkBehaviour
	{
		[Tooltip("True to allow clients to predicted spawn this object.")]
		[SerializeField]
		private bool _allowSpawning;

		[SerializeField]
		[Tooltip("True to allow clients to predicted despawn this object.")]
		private bool _allowDespawning;

		[SerializeField]
		[Tooltip("True to allow clients to predicted set syncTypes prior to spawning the item. Set values will be applied on the server and sent to other clients.")]
		private bool _allowSyncTypes;

		private bool NetworkInitialize___EarlyFishNet_002EComponent_002EOwnership_002EPredictedSpawnFishNet_002ERuntime_002Edll_Excuted;

		private bool NetworkInitialize__LateFishNet_002EComponent_002EOwnership_002EPredictedSpawnFishNet_002ERuntime_002Edll_Excuted;

		public bool GetAllowSpawning()
		{
			return false;
		}

		public void SetAllowSpawning(bool value)
		{
		}

		public bool GetAllowDespawning()
		{
			return false;
		}

		public void SetAllowDespawning(bool value)
		{
		}

		public bool GetAllowSyncTypes()
		{
			return false;
		}

		public void SetAllowSyncTypes(bool value)
		{
		}

		public virtual bool OnTrySpawnClient(NetworkConnection owner = null)
		{
			return false;
		}

		public virtual bool OnTrySpawnServer(NetworkConnection spawner, NetworkConnection owner = null)
		{
			return false;
		}

		public virtual bool OnTryDespawnClient()
		{
			return false;
		}

		public virtual bool OnTryDepawnServer(NetworkConnection despawner)
		{
			return false;
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

		public virtual void Awake()
		{
		}
	}
}
