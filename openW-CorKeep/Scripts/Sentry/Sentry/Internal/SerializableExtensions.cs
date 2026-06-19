using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Sentry.Extensibility;
using Sentry.Infrastructure;
using Sentry.Protocol.Envelopes;

namespace Sentry.Internal
{
	internal static class SerializableExtensions
	{
		public static async Task<string> SerializeToStringAsync(this ISerializable serializable, IDiagnosticLogger logger, ISystemClock? clock = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			MemoryStream stream = new MemoryStream();
			using (stream)
			{
				if (clock == null || !(serializable is Envelope envelope))
				{
					await serializable.SerializeAsync(stream, logger, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				}
				else
				{
					await envelope.SerializeAsync(stream, logger, clock, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				}
				stream.Seek(0L, SeekOrigin.Begin);
				using StreamReader reader = new StreamReader(stream);
				return await reader.ReadToEndAsync().ConfigureAwait(continueOnCapturedContext: false);
			}
		}

		public static string SerializeToString(this ISerializable serializable, IDiagnosticLogger logger, ISystemClock? clock = null)
		{
			using MemoryStream memoryStream = new MemoryStream();
			if (clock != null && serializable is Envelope envelope)
			{
				envelope.Serialize(memoryStream, logger, clock);
			}
			else
			{
				serializable.Serialize(memoryStream, logger);
			}
			memoryStream.Seek(0L, SeekOrigin.Begin);
			using StreamReader streamReader = new StreamReader(memoryStream);
			return streamReader.ReadToEnd();
		}
	}
}
