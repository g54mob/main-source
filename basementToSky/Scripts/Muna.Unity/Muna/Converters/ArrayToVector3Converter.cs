using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Muna.Converters
{
	public sealed class ArrayToVector3Converter : JsonConverter<Vector3>
	{
		public override void WriteJson(JsonWriter writer, Vector3 value, JsonSerializer serializer)
		{
			JArray jArray = new JArray();
			jArray.Add(value.x);
			jArray.Add(value.y);
			jArray.Add(value.z);
			jArray.WriteTo(writer);
		}

		public override Vector3 ReadJson(JsonReader reader, Type type, Vector3 existing, bool hasExisting, JsonSerializer s)
		{
			JArray jArray = JArray.Load(reader);
			return new Vector3((float)jArray[0], (float)jArray[1], (float)jArray[2]);
		}
	}
}
