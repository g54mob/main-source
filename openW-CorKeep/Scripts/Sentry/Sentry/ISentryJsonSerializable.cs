using System.Text.Json;
using Sentry.Extensibility;

namespace Sentry
{
	public interface ISentryJsonSerializable
	{
		void WriteTo(Utf8JsonWriter writer, IDiagnosticLogger? logger);
	}
}
