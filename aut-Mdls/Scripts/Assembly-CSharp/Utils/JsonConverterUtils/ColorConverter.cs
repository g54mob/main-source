using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Utils.JsonConverterUtils
{
	public class ColorConverter : JsonConverter<Color>
	{
		public override void WriteJson(JsonWriter writer, Color value, JsonSerializer serializer)
		{
			JObject jObject = ((value == Color.white) ? new JObject { ["c"] = 1 } : ((value == Color.black) ? new JObject { ["c"] = 2 } : ((!(value == Color.clear)) ? new JObject
			{
				["r"] = value.r,
				["g"] = value.g,
				["b"] = value.b,
				["a"] = value.a
			} : new JObject { ["c"] = 3 })));
			jObject.WriteTo(writer);
		}

		public override Color ReadJson(JsonReader reader, Type objectType, Color existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			JObject jObject = JObject.Load(reader);
			if (jObject.TryGetValue<int>("c", out var value))
			{
				switch (value)
				{
				case 1:
					return Color.white;
				case 2:
					return Color.black;
				case 3:
					return Color.clear;
				}
			}
			return new Color((float)jObject.GetValue("r"), (float)jObject.GetValue("g"), (float)jObject.GetValue("b"), (float)jObject.GetValue("a"));
		}
	}
}
