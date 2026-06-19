using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Sentry.Extensibility;

namespace Sentry.Protocol.Envelopes
{
	internal sealed class JsonSerializable : ISerializable
	{
		public ISentryJsonSerializable Source { get; }

		public JsonSerializable(ISentryJsonSerializable source)
		{
			Source = source;
		}

		public async Task SerializeAsync(Stream stream, IDiagnosticLogger? logger, CancellationToken cancellationToken = default(CancellationToken))
		{
			Utf8JsonWriter utf8JsonWriter = new Utf8JsonWriter(stream);
			ConfiguredAsyncDisposable I_0 = utf8JsonWriter.ConfigureAwait(continueOnCapturedContext: false);
			try
			{
				Source.WriteTo(utf8JsonWriter, logger);
				await utf8JsonWriter.FlushAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			finally
			{
				IAsyncDisposable asyncDisposable = I_0 as IAsyncDisposable;
				if (asyncDisposable != null)
				{
					await asyncDisposable.DisposeAsync();
				}
			}
		}

		public void Serialize(Stream stream, IDiagnosticLogger? logger)
		{
			using Utf8JsonWriter utf8JsonWriter = new Utf8JsonWriter(stream);
			Source.WriteTo(utf8JsonWriter, logger);
			utf8JsonWriter.Flush();
		}
	}
}
