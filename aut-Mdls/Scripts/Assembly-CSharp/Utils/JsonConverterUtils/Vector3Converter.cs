using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Utils.JsonConverterUtils
{
	public class Vector3Converter : JsonConverter<Vector3>
	{
		public override void WriteJson(JsonWriter writer, Vector3 value, JsonSerializer serializer)
		{
			JObject jObject = new JObject();
			jObject["x"] = value.x;
			jObject["y"] = value.y;
			jObject["z"] = value.z;
			jObject.WriteTo(writer);
		}

		public override Vector3 ReadJson(JsonReader reader, Type objectType, Vector3 existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			JObject jObject = JObject.Load(reader);
			return new Vector3((float)jObject.GetValue("x"), (float)jObject.GetValue("y"), (float)jObject.GetValue("z"));
		}
	}
}
