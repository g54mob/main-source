using System;
using Newtonsoft.Json;
using Reactivity;

namespace FractureField
{
	public class RDateTimeConverter : JsonConverter<RDateTime>
	{
		public override RDateTime ReadJson(JsonReader reader, Type objectType, RDateTime existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			return null;
		}

		public override void WriteJson(JsonWriter writer, RDateTime value, JsonSerializer serializer)
		{
		}
	}
}
