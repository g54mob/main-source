using System;
using Newtonsoft.Json;

namespace Coherence.Toolkit
{
	public class UnityQuaternionConverter : JsonConverter
	{
		private static readonly char[] Separator;

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			return null;
		}

		public override bool CanConvert(Type objectType)
		{
			return false;
		}
	}
}
