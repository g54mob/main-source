using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Utils.JsonConverterUtils
{
	public class Vector2Converter : JsonConverter<Vector2>
	{
		public override void WriteJson(JsonWriter writer, Vector2 value, JsonSerializer serializer)
		{
			JObject jObject = new JObject();
			jObject["x"] = value.x;
			jObject["y"] = value.y;
			jObject.WriteTo(writer);
		}

		public override Vector2 ReadJson(JsonReader reader, Type objectType, Vector2 existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			JObject jObject = JObject.Load(reader);
			return new Vector2((float)jObject.GetValue("x"), (float)jObject.GetValue("y"));
		}
	}
}
