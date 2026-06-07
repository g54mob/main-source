using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Muna.Converters
{
	public sealed class ArrayToVector2Converter : JsonConverter<Vector2>
	{
		public override void WriteJson(JsonWriter writer, Vector2 value, JsonSerializer serializer)
		{
			JArray jArray = new JArray();
			jArray.Add(value.x);
			jArray.Add(value.y);
			jArray.WriteTo(writer);
		}

		public override Vector2 ReadJson(JsonReader reader, Type type, Vector2 existing, bool hasExisting, JsonSerializer s)
		{
			JArray jArray = JArray.Load(reader);
			return new Vector2((float)jArray[0], (float)jArray[1]);
		}
	}
}
