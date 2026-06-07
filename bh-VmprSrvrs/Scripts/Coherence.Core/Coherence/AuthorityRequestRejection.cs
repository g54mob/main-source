using Coherence.Entities;

namespace Coherence
{
	public struct AuthorityRequestRejection
	{
		public Entity EntityID;

		public AuthorityType AuthorityType;

		public AuthorityRequestRejection(Entity entityID, AuthorityType authorityType)
		{
			EntityID = default(Entity);
			AuthorityType = default(AuthorityType);
		}
	}
}
