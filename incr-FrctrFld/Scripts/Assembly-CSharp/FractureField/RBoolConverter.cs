using System;
using Newtonsoft.Json;
using Reactivity;

namespace FractureField
{
	public class RBoolConverter : JsonConverter<RBool>
	{
		public override RBool ReadJson(JsonReader reader, Type objectType, RBool existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			return null;
		}

		public override void WriteJson(JsonWriter writer, RBool value, JsonSerializer serializer)
		{
		}
	}
}
