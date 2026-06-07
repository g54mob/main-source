namespace Coherence.Core
{
	public struct InteropAuthorityRequestRejection
	{
		public InteropEntity ID;

		public AuthorityType AuthType;

		public AuthorityRequestRejection Into()
		{
			return default(AuthorityRequestRejection);
		}
	}
}
