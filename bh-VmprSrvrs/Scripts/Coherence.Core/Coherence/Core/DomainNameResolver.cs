using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Coherence.Log;

namespace Coherence.Core
{
	internal class DomainNameResolver : IDomainNameResolver
	{
		public void Resolve(string hostname, CancellationToken cancellationToken, Logger logger, Action<IPAddress> onSuccess, Action onFailure)
		{
		}

		private Task<Task> GetHostEntryAsync(string hostname, CancellationToken cancellationToken)
		{
			return null;
		}

		private bool TryGetFirstIPv4Address(IPAddress[] addressList, out IPAddress firstIPv4Address)
		{
			firstIPv4Address = null;
			return false;
		}
	}
}
