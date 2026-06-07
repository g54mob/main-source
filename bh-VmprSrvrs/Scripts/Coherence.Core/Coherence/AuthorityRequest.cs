using Coherence.Connection;
using Coherence.Entities;

namespace Coherence
{
	public struct AuthorityRequest
	{
		public Entity EntityID;

		public ClientID RequesterID;

		public AuthorityType AuthorityType;

		public AuthorityRequest(Entity entityID, ClientID requesterID, AuthorityType authorityType)
		{
			EntityID = default(Entity);
			RequesterID = default(ClientID);
			AuthorityType = default(AuthorityType);
		}
	}
}
