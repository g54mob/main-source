using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Utils.JsonConverterUtils
{
	public class Vector2IntConverter : JsonConverter<Vector2Int>
	{
		public override void WriteJson(JsonWriter writer, Vector2Int value, JsonSerializer serializer)
		{
			JObject jObject = new JObject();
			jObject["x"] = value.x;
			jObject["y"] = value.y;
			jObject.WriteTo(writer);
		}

		public override Vector2Int ReadJson(JsonReader reader, Type objectType, Vector2Int existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			JObject jObject = JObject.Load(reader);
			return new Vector2Int((int)jObject.GetValue("x"), (int)jObject.GetValue("y"));
		}
	}
}
