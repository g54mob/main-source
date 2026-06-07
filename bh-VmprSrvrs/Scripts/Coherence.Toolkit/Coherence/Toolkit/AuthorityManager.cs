using Coherence.Connection;
using Coherence.Entities;
using Coherence.Log;

namespace Coherence.Toolkit
{
	public sealed class AuthorityManager
	{
		private IClient client;

		private CoherenceBridge bridge;

		private Logger logger;

		internal AuthorityManager(IClient client, CoherenceBridge bridge)
		{
		}

		public bool RequestAuthority(NetworkEntityState state, AuthorityType authorityType)
		{
			return false;
		}

		public bool TransferAuthority(NetworkEntityState state, ClientID clientID, AuthorityType authorityTransferred = AuthorityType.Full)
		{
			return false;
		}

		public bool AbandonAuthority(NetworkEntityState state)
		{
			return false;
		}

		public bool Adopt(NetworkEntityState state)
		{
			return false;
		}

		private void HandleAuthorityRequest(AuthorityRequest request)
		{
		}

		private void HandleAuthorityRequestRejected(AuthorityRequestRejection rejection)
		{
		}

		private void HandleAuthorityChanged(AuthorityChange change)
		{
		}

		private void HandleAuthorityTransferred(Entity entity)
		{
		}

		private bool IsAcceptingAuthorityTransferRequest(NetworkEntityState state, ClientID requesterID, AuthorityType authorityType)
		{
			return false;
		}

		private bool AssertNetworkEntityState(NetworkEntityState state)
		{
			return false;
		}
	}
}
