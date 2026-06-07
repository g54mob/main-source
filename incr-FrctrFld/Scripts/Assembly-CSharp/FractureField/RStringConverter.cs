using System;
using Newtonsoft.Json;
using Reactivity;

namespace FractureField
{
	public class RStringConverter : JsonConverter<RString>
	{
		public override RString ReadJson(JsonReader reader, Type objectType, RString existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			return null;
		}

		public override void WriteJson(JsonWriter writer, RString value, JsonSerializer serializer)
		{
		}
	}
}
