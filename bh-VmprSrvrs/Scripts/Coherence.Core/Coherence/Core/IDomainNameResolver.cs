using System;
using System.Net;
using System.Threading;
using Coherence.Log;

namespace Coherence.Core
{
	public interface IDomainNameResolver
	{
		void Resolve(string hostname, CancellationToken cancellationToken, Logger logger, Action<IPAddress> onSuccess, Action onFailure);
	}
}
