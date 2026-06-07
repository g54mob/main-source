using System;
using Newtonsoft.Json;

namespace Data.Shapes
{
	public class ShapeHashPairConverter : JsonConverter<ShapeHashPair>
	{
		public override void WriteJson(JsonWriter writer, ShapeHashPair value, JsonSerializer serializer)
		{
			writer.WriteValue(value.ToString());
		}

		public override ShapeHashPair ReadJson(JsonReader reader, Type objectType, ShapeHashPair existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			return ShapeHashPair.Parse((string)reader.Value);
		}
	}
}
