using System;
using System.Security.Authentication;

namespace Mono.Security.Interface
{
	public abstract class MonoTlsProvider
	{
		public abstract Guid ID { get; }

		public abstract string Name { get; }

		public abstract bool SupportsSslStream { get; }

		public abstract bool SupportsConnectionInfo { get; }

		public abstract bool SupportsMonoExtensions { get; }

		public abstract SslProtocols SupportedProtocols { get; }

		internal abstract bool SupportsCleanShutdown { get; }

		internal MonoTlsProvider()
		{
		}
	}
}
