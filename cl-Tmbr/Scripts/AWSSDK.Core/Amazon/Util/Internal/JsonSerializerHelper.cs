using System.Text.Json;
using System.Text.RegularExpressions;

namespace Amazon.Util.Internal
{
	public static class JsonSerializerHelper
	{
		private static System.Text.Json.JsonSerializerOptions options = new System.Text.Json.JsonSerializerOptions
		{
			AllowTrailingCommas = true
		};

		private static readonly Regex regex = new Regex("(\"[^\"]*\"|\\d+)(\\s*\"[^\"]*\"\\s*:)", RegexOptions.Compiled);

		public static T Deserialize<T>(string json, JsonSerializerContext typeInfo)
		{
			return JsonSerializer.Deserialize<T>(json, options);
		}

		public static string Serialize<T>(object obj, JsonSerializerContext typeInfo)
		{
			System.Text.Json.JsonSerializerOptions jsonSerializerOptions = new System.Text.Json.JsonSerializerOptions
			{
				WriteIndented = (typeInfo?.Options?.WriteIndented == true)
			};
			return JsonSerializer.Serialize(obj, jsonSerializerOptions);
		}
	}
}
