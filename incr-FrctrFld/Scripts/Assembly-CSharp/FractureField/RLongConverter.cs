using System;
using Newtonsoft.Json;
using Reactivity;

namespace FractureField
{
	public class RLongConverter : JsonConverter<RLong>
	{
		public override RLong ReadJson(JsonReader reader, Type objectType, RLong existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			return null;
		}

		public override void WriteJson(JsonWriter writer, RLong value, JsonSerializer serializer)
		{
		}
	}
}
