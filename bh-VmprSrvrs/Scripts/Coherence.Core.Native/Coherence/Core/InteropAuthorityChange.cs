namespace Coherence.Core
{
	public struct InteropAuthorityChange
	{
		public InteropEntity ID;

		public AuthorityType AuthType;

		public AuthorityChange Into()
		{
			return default(AuthorityChange);
		}
	}
}
