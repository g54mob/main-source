using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Muna.Converters
{
	public sealed class ArrayToVector4Converter : JsonConverter<Vector4>
	{
		public override void WriteJson(JsonWriter writer, Vector4 value, JsonSerializer serializer)
		{
			JArray jArray = new JArray();
			jArray.Add(value.x);
			jArray.Add(value.y);
			jArray.Add(value.z);
			jArray.Add(value.w);
			jArray.WriteTo(writer);
		}

		public override Vector4 ReadJson(JsonReader reader, Type type, Vector4 existing, bool hasExisting, JsonSerializer s)
		{
			JArray jArray = JArray.Load(reader);
			return new Vector4((float)jArray[0], (float)jArray[1], (float)jArray[2], (float)jArray[3]);
		}
	}
}
