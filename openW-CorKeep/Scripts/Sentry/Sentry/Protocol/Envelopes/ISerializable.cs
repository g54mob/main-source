using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Sentry.Extensibility;

namespace Sentry.Protocol.Envelopes
{
	public interface ISerializable
	{
		Task SerializeAsync(Stream stream, IDiagnosticLogger? logger, CancellationToken cancellationToken = default(CancellationToken));

		void Serialize(Stream stream, IDiagnosticLogger? logger);
	}
}
