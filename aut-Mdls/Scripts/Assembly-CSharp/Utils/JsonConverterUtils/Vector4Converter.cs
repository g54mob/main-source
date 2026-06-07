using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Utils.JsonConverterUtils
{
	public class Vector4Converter : JsonConverter<Vector4>
	{
		public override void WriteJson(JsonWriter writer, Vector4 value, JsonSerializer serializer)
		{
			JObject jObject = new JObject();
			jObject["x"] = value.x;
			jObject["y"] = value.y;
			jObject["z"] = value.z;
			jObject["w"] = value.w;
			jObject.WriteTo(writer);
		}

		public override Vector4 ReadJson(JsonReader reader, Type objectType, Vector4 existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			JObject jObject = JObject.Load(reader);
			return new Vector4((float)jObject.GetValue("x"), (float)jObject.GetValue("y"), (float)jObject.GetValue("z"), (float)jObject.GetValue("w"));
		}
	}
}
