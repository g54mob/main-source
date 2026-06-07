using System;
using Newtonsoft.Json;

namespace Coherence.Log.Targets
{
	internal class ToStringConverter : JsonConverter
	{
		public ToStringConverter(bool isTrue)
		{
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			return null;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
		}

		public override bool CanConvert(Type objectType)
		{
			return false;
		}
	}
}
