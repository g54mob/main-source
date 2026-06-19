using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Sentry.Extensibility;
using Sentry.Internal.Extensions;

namespace Sentry.Protocol
{
	internal sealed class DebugMeta : ISentryJsonSerializable
	{
		public List<DebugImage>? Images { get; set; }

		public void WriteTo(Utf8JsonWriter writer, IDiagnosticLogger? logger)
		{
			writer.WriteStartObject();
			writer.WriteArrayIfNotEmpty("images", Images, logger);
			writer.WriteEndObject();
		}

		public static DebugMeta FromJson(JsonElement json)
		{
			JsonElement? propertyOrNull = json.GetPropertyOrNull("images");
			List<DebugImage> images = (propertyOrNull.HasValue ? propertyOrNull.GetValueOrDefault().EnumerateArray().Select(DebugImage.FromJson)
				.ToList() : null);
			return new DebugMeta
			{
				Images = images
			};
		}
	}
}
