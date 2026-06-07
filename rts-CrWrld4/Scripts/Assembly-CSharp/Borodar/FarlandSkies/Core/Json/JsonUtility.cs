using System.IO;
using System.Text;

namespace Borodar.FarlandSkies.Core.Json
{
	public static class JsonUtility
	{
		public static JsonNode ReadFrom(string json)
		{
			return null;
		}

		public static JsonNode ReadFrom(Stream stream)
		{
			return null;
		}

		public static JsonNode ReadFrom(TextReader reader)
		{
			return null;
		}

		public static JsonNode ConvertFrom(object value)
		{
			return null;
		}

		public static void WriteTo(this JsonNode node, StringBuilder builder)
		{
		}

		public static void WriteTo(this JsonNode node, StringBuilder builder, JsonWriterSettings settings)
		{
		}

		public static void WriteTo(this JsonNode node, Stream stream)
		{
		}

		public static void WriteTo(this JsonNode node, Stream stream, JsonWriterSettings settings)
		{
		}

		public static void WriteTo(this JsonNode node, TextWriter textWriter)
		{
		}

		public static void WriteTo(this JsonNode node, TextWriter textWriter, JsonWriterSettings settings)
		{
		}

		public static string ToJsonString(this JsonNode node)
		{
			return null;
		}

		public static string ToJsonString(this JsonNode node, JsonWriterSettings settings)
		{
			return null;
		}
	}
}
