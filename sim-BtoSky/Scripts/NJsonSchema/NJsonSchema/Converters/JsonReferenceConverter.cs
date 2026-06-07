using System;
using Newtonsoft.Json;

namespace NJsonSchema.Converters
{
	public class JsonReferenceConverter : JsonConverter
	{
		[ThreadStatic]
		private static bool _isWriting;

		public override bool CanWrite => !_isWriting;

		public override bool CanConvert(Type objectType)
		{
			return true;
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			return serializer.Deserialize(reader, objectType);
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			JsonSchemaReferenceUtilities.UpdateSchemaReferencePaths(value, removeExternalReferences: false, serializer.ContractResolver);
			try
			{
				_isWriting = true;
				string json = JsonConvert.SerializeObject(value, serializer.Formatting);
				if (writer.WriteState == WriteState.Property)
				{
					writer.WriteRawValue(json);
				}
				else
				{
					writer.WriteRaw(json);
				}
			}
			finally
			{
				_isWriting = false;
			}
		}
	}
}
