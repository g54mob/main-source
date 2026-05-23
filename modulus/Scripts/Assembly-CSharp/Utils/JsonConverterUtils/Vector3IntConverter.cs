using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Utils.JsonConverterUtils
{
	public class Vector3IntConverter : JsonConverter<Vector3Int>
	{
		public override void WriteJson(JsonWriter writer, Vector3Int value, JsonSerializer serializer)
		{
			JObject jObject = new JObject();
			jObject["x"] = value.x;
			jObject["y"] = value.y;
			jObject["z"] = value.z;
			jObject.WriteTo(writer);
		}

		public override Vector3Int ReadJson(JsonReader reader, Type objectType, Vector3Int existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			JObject jObject = JObject.Load(reader);
			return new Vector3Int((int)jObject.GetValue("x"), (int)jObject.GetValue("y"), (int)jObject.GetValue("z"));
		}
	}
}
