using System;
using Newtonsoft.Json;

namespace FractureField
{
	public class DictionaryNumericEnumKeysConverter : JsonConverter
	{
		public override bool CanRead => false;

		public override bool CanWrite => false;

		public override bool CanConvert(Type objectType)
		{
			return false;
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			return null;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
		}

		private bool TryGetEnumType(Type objectType, out Type keyType)
		{
			keyType = null;
			return false;
		}
	}
}
