using FishNet.Connection;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using FishNet.Serializing;
using FishNet.Transporting;
using UnityEngine;

namespace FishNet.Component.Ownership
{
	public class PredictedOwner : NetworkBehaviour
	{
		[SyncVar(SendRate = 0f)]
		[Tooltip("True if to enable this component.")]
		[SerializeField]
		public bool _allowTakeOwnership;

		public SyncVar<bool> syncVar____allowTakeOwnership;

		private bool NetworkInitialize___EarlyFishNet_002EComponent_002EOwnership_002EPredictedOwnerFishNet_002ERuntime_002Edll_Excuted;

		private bool NetworkInitialize__LateFishNet_002EComponent_002EOwnership_002EPredictedOwnerFishNet_002ERuntime_002Edll_Excuted;

		public bool TakingOwnership { get; private set; }

		public NetworkConnection PreviousOwner { get; private set; }

		public bool SyncAccessor__allowTakeOwnership
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Server]
		public void SetAllowTakeOwnership(bool value)
		{
		}

		public override void OnOwnershipClient(NetworkConnection prevOwner)
		{
		}

		[Client]
		public virtual void TakeOwnership()
		{
		}

		[ServerRpc(RequireOwnership = false)]
		private void ServerTakeOwnership(NetworkConnection caller = null)
		{
		}

		[Server]
		protected virtual void OnTakeOwnership(NetworkConnection caller)
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

		private void RpcWriter___Server_ServerTakeOwnership_328543758(NetworkConnection caller = null)
		{
		}

		private void RpcLogic___ServerTakeOwnership_328543758(NetworkConnection caller = null)
		{
		}

		private void RpcReader___Server_ServerTakeOwnership_328543758(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
		}

		public virtual bool ReadSyncVar___FishNet_002EComponent_002EOwnership_002EPredictedOwner(PooledReader PooledReader0, uint UInt321, bool Boolean2)
		{
			return false;
		}

		public virtual void Awake()
		{
		}
	}
}
