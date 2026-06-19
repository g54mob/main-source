namespace Sentry.Internal.Extensions
{
	internal sealed class PEDebugImageData
	{
		public string Type => "pe_dotnet";

		public string? ImageAddress { get; set; }

		public long? ImageSize { get; set; }

		public string? DebugId { get; set; }

		public string? DebugChecksum { get; set; }

		public string? DebugFile { get; set; }

		public string? CodeId { get; set; }
	}
}
