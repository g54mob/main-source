using System.Buffers;
using System.Text.Json;
using Cysharp.Text;

namespace ZLogger
{
	public static class ZLoggerEntryExtensions
	{
		public static string FormatToString(this IZLoggerEntry entry, ZLoggerOptions options, Utf8JsonWriter? jsonWriter)
		{
			IBufferWriter<byte> bufferWriter = ZString.CreateUtf8StringBuilder();
			try
			{
				entry.FormatUtf8(bufferWriter, options, jsonWriter);
				return bufferWriter.ToString();
			}
			finally
			{
				((Utf8ValueStringBuilder)(object)bufferWriter).Dispose();
			}
		}
	}
}
