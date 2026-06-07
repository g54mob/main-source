using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Muna.Converters
{
	public sealed class ArrayToColorConverter : JsonConverter<Color>
	{
		public override void WriteJson(JsonWriter writer, Color value, JsonSerializer serializer)
		{
			JArray jArray = new JArray();
			jArray.Add(value.r);
			jArray.Add(value.g);
			jArray.Add(value.b);
			jArray.Add(value.a);
			jArray.WriteTo(writer);
		}

		public override Color ReadJson(JsonReader reader, Type type, Color existing, bool hasExisting, JsonSerializer s)
		{
			JArray jArray = JArray.Load(reader);
			return new Color((float)jArray[0], (float)jArray[1], (float)jArray[2], (jArray.Count > 3) ? ((float)jArray[3]) : 1f);
		}
	}
}
