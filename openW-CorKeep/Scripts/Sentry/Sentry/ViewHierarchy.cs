using System.Collections.Generic;
using System.Text.Json;
using Sentry.Extensibility;
using Sentry.Internal.Extensions;

namespace Sentry
{
	public sealed class ViewHierarchy : ISentryJsonSerializable
	{
		public string RenderingSystem { get; set; }

		public List<ViewHierarchyNode> Windows { get; } = new List<ViewHierarchyNode>();

		public ViewHierarchy(string renderingSystem)
		{
			RenderingSystem = renderingSystem;
		}

		public void WriteTo(Utf8JsonWriter writer, IDiagnosticLogger? logger)
		{
			writer.WriteStartObject();
			writer.WriteStringIfNotWhiteSpace("rendering_system", RenderingSystem);
			writer.WriteStartArray("windows");
			foreach (ViewHierarchyNode window in Windows)
			{
				window.WriteTo(writer, logger);
			}
			writer.WriteEndArray();
			writer.WriteEndObject();
		}
	}
}
