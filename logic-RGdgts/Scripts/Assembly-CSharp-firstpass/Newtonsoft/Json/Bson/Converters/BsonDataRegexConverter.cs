using System;
using System.Text.RegularExpressions;

namespace Newtonsoft.Json.Bson.Converters
{
	public class BsonDataRegexConverter : JsonConverter
	{
		private const string PatternName = "Pattern";

		private const string OptionsName = "Options";

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
		}

		private bool HasFlag(RegexOptions options, RegexOptions flag)
		{
			return false;
		}

		private void WriteBson(BsonDataWriter writer, Regex regex)
		{
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			return null;
		}

		private object ReadRegexString(JsonReader reader)
		{
			return null;
		}

		private Regex ReadRegexObject(JsonReader reader, JsonSerializer serializer)
		{
			return null;
		}

		public override bool CanConvert(Type objectType)
		{
			return false;
		}
	}
}
