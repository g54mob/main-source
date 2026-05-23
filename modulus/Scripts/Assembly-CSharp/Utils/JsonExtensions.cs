#define ENABLE_DEBUG_ERRORS
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Utils
{
	public static class JsonExtensions
	{
		public static bool TryGetValue<T>(this JObject obj, string key, out T value)
		{
			JToken value2 = obj.GetValue(key);
			if (value2 == null)
			{
				value = default(T);
				return false;
			}
			value = value2.ToObject<T>();
			return true;
		}

		public static T GetValue<T>(this JObject obj, string key, T defaultValue = default(T), bool logError = false)
		{
			if (!obj.TryGetValue<T>(key, out var value))
			{
				if (logError)
				{
					typeof(JsonExtensions).LogError("Value of name \"" + key + "\" and type \"T\" doesn't exist", "GetValue", 26);
				}
				return defaultValue;
			}
			return value;
		}

		public static bool TryGetValueWithDeseralize<T>(this JObject obj, string key, out T value, params JsonConverter[] jsonConverters)
		{
			JToken value2 = obj.GetValue(key);
			if (value2 == null)
			{
				value = default(T);
				return false;
			}
			JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
			{
				TypeNameHandling = TypeNameHandling.Auto,
				DefaultValueHandling = DefaultValueHandling.Ignore
			};
			foreach (JsonConverter item in jsonConverters)
			{
				jsonSerializerSettings.Converters.Add(item);
			}
			value = JsonConvert.DeserializeObject<T>(value2.ToString(), jsonSerializerSettings);
			return true;
		}

		public static T GetValueWithDeseralize<T>(this JObject obj, string key, T defaultValue = default(T), params JsonConverter[] jsonConverters)
		{
			if (!obj.TryGetValueWithDeseralize<T>(key, out var value, jsonConverters))
			{
				return defaultValue;
			}
			return value;
		}
	}
}
