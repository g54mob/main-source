using System.Collections.Generic;

namespace Coherence.Cloud
{
	public class SecretsCache
	{
		private readonly Dictionary<ulong, string> cache;

		public void Add(ulong serverId, string secret)
		{
		}

		public string Get(ulong serverId)
		{
			return null;
		}

		public void Remove(ulong serverId)
		{
		}
	}
}
