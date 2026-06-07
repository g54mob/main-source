using Coherence.Entities;

namespace Coherence.Core
{
	public static class MetaExtensions
	{
		private static AuthorityType GetAuthorityType(bool hasStateAuthority, bool hasInputAuthority)
		{
			return default(AuthorityType);
		}

		public static AuthorityType Authority(this EntityWithMeta meta)
		{
			return default(AuthorityType);
		}

		public static AuthorityType Authority(this SerializedMeta meta)
		{
			return default(AuthorityType);
		}
	}
}
