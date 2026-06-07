using Coherence.Entities;

namespace Coherence
{
	public struct AuthorityChange
	{
		public Entity EntityID;

		public AuthorityType NewAuthorityType;

		public AuthorityChange(Entity entityID, AuthorityType newAuthorityType)
		{
			EntityID = default(Entity);
			NewAuthorityType = default(AuthorityType);
		}
	}
}
