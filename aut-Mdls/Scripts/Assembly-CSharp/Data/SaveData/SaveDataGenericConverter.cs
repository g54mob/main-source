using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Data.SaveData
{
	public class SaveDataGenericConverter<T> : JsonConverter where T : AbstractSaveData
	{
		private readonly ISaveDataConverter[] _converters;

		public SaveDataGenericConverter(ISaveDataConverter[] behaviourConfigurationConverters)
		{
			_converters = behaviourConfigurationConverters;
		}

		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(T);
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotSupportedException();
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			JObject jObject = JObject.Load(reader);
			string text = jObject["$type"]?.ToString() ?? throw new JsonSerializationException("Missing $type field.");
			jObject.Remove("$type");
			Type type = Type.GetType(text) ?? throw new JsonSerializationException("Unknown type: " + text);
			ISaveDataConverter[] converters = _converters;
			foreach (ISaveDataConverter saveDataConverter in converters)
			{
				if (saveDataConverter.CanConvert(type))
				{
					return saveDataConverter.ReadJsonAlreadyRead(jObject, serializer);
				}
			}
			JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
			{
				TypeNameHandling = TypeNameHandling.Auto,
				DefaultValueHandling = DefaultValueHandling.Ignore
			};
			foreach (JsonConverter converter in serializer.Converters)
			{
				if (converter != this)
				{
					jsonSerializerSettings.Converters.Add(converter);
				}
			}
			return JsonConvert.DeserializeObject(jObject.ToString(), type, jsonSerializerSettings);
		}
	}
}
