using System;
using System.IO;
using System.Text.Json;

namespace Sentry.Internal
{
	internal static class Json
	{
		public static T Parse<T>(byte[] json, Func<JsonElement, T> factory)
		{
			using JsonDocument jsonDocument = JsonDocument.Parse(json);
			return factory(jsonDocument.RootElement);
		}

		public static T Parse<T>(string json, Func<JsonElement, T> factory)
		{
			using JsonDocument jsonDocument = JsonDocument.Parse(json);
			return factory(jsonDocument.RootElement);
		}

		public static T Load<T>(IFileSystem fileSystem, string filePath, Func<JsonElement, T> factory)
		{
			using Stream utf8Json = fileSystem.OpenFileForReading(filePath);
			using JsonDocument jsonDocument = JsonDocument.Parse(utf8Json);
			return factory(jsonDocument.RootElement);
		}
	}
}
