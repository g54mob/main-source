namespace Coherence.Core
{
	public struct InteropAuthorityRequest
	{
		public InteropEntity ID;

		public InteropClientID RequesterID;

		public AuthorityType AuthType;

		public AuthorityRequest Into()
		{
			return default(AuthorityRequest);
		}
	}
}
