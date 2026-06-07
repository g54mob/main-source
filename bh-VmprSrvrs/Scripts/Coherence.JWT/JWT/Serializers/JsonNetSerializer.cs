using System;
using Newtonsoft.Json;

namespace JWT.Serializers
{
	public class JsonNetSerializer : IJsonSerializer
	{
		private readonly JsonSerializer _serializer;

		public JsonNetSerializer()
		{
		}

		public JsonNetSerializer(JsonSerializer serializer)
		{
		}

		public string Serialize(object obj)
		{
			return null;
		}

		public object Deserialize(Type type, string json)
		{
			return null;
		}
	}
}
