using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Sentry.Extensibility;
using Sentry.Infrastructure;
using Sentry.Protocol.Envelopes;

namespace Sentry.Internal.Http
{
	internal class EnvelopeHttpContent : SerializableHttpContent
	{
		private readonly Envelope _envelope;

		private readonly IDiagnosticLogger? _logger;

		private readonly ISystemClock _clock;

		public EnvelopeHttpContent(Envelope envelope, IDiagnosticLogger? logger, ISystemClock clock)
		{
			_envelope = envelope;
			_logger = logger;
			_clock = clock;
		}

		protected override async Task SerializeToStreamAsync(Stream stream, TransportContext? context)
		{
			try
			{
				await _envelope.SerializeAsync(stream, _logger, _clock).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (Exception exception)
			{
				_logger?.LogError(exception, "Failed to serialize Envelope into the network stream");
				throw;
			}
		}

		protected override void SerializeToStream(Stream stream, TransportContext? context, CancellationToken cancellationToken)
		{
			try
			{
				_envelope.Serialize(stream, _logger, _clock);
			}
			catch (Exception exception)
			{
				_logger?.LogError(exception, "Failed to serialize Envelope into the network stream");
				throw;
			}
		}

		protected override bool TryComputeLength(out long length)
		{
			length = 0L;
			return false;
		}
	}
}
