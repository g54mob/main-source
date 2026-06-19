using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Sentry.Extensibility;

namespace Sentry.Protocol.Envelopes
{
	internal sealed class StreamSerializable : ISerializable, IDisposable
	{
		public Stream Source { get; }

		public StreamSerializable(Stream source)
		{
			Source = source;
		}

		public Task SerializeAsync(Stream stream, IDiagnosticLogger? logger, CancellationToken cancellationToken = default(CancellationToken))
		{
			return PolyfillExtensions.CopyToAsync(Source, stream, cancellationToken);
		}

		public void Serialize(Stream stream, IDiagnosticLogger? logger)
		{
			Source.CopyTo(stream);
		}

		public void Dispose()
		{
			Source.Dispose();
		}
	}
}
