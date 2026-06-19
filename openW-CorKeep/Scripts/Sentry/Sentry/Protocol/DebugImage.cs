using System;
using System.Text.Json;
using Sentry.Extensibility;
using Sentry.Internal.Extensions;

namespace Sentry.Protocol
{
	public sealed class DebugImage : ISentryJsonSerializable
	{
		public string? Type { get; set; }

		public long? ImageAddress { get; set; }

		public long? ImageSize { get; set; }

		public string? DebugId { get; set; }

		public string? DebugChecksum { get; set; }

		public string? DebugFile { get; set; }

		public string? CodeId { get; set; }

		public string? CodeFile { get; set; }

		internal Guid? ModuleVersionId { get; set; }

		public void WriteTo(Utf8JsonWriter writer, IDiagnosticLogger? logger)
		{
			writer.WriteStartObject();
			writer.WriteStringIfNotWhiteSpace("type", Type);
			writer.WriteStringIfNotWhiteSpace("image_addr", ImageAddress?.NullIfDefault()?.ToHexString());
			writer.WriteNumberIfNotNull("image_size", ImageSize);
			writer.WriteStringIfNotWhiteSpace("debug_id", DebugId);
			writer.WriteStringIfNotWhiteSpace("debug_checksum", DebugChecksum);
			writer.WriteStringIfNotWhiteSpace("debug_file", DebugFile);
			writer.WriteStringIfNotWhiteSpace("code_id", CodeId);
			writer.WriteStringIfNotWhiteSpace("code_file", CodeFile);
			writer.WriteEndObject();
		}

		public static DebugImage FromJson(JsonElement json)
		{
			string type = json.GetPropertyOrNull("type")?.GetString();
			long? imageAddress = json.GetPropertyOrNull("image_addr")?.GetHexAsLong();
			long? imageSize = json.GetPropertyOrNull("image_size")?.GetInt64();
			string debugId = json.GetPropertyOrNull("debug_id")?.GetString();
			string debugChecksum = json.GetPropertyOrNull("debug_checksum")?.GetString();
			string debugFile = json.GetPropertyOrNull("debug_file")?.GetString();
			string codeId = json.GetPropertyOrNull("code_id")?.GetString();
			string codeFile = json.GetPropertyOrNull("code_file")?.GetString();
			return new DebugImage
			{
				Type = type,
				ImageAddress = imageAddress,
				ImageSize = imageSize,
				DebugId = debugId,
				DebugChecksum = debugChecksum,
				DebugFile = debugFile,
				CodeId = codeId,
				CodeFile = codeFile
			};
		}
	}
}
