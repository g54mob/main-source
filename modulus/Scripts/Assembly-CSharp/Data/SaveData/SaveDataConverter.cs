#define ENABLE_DEBUG_ERRORS
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Utils;

namespace Data.SaveData
{
	public abstract class SaveDataConverter<T> : JsonConverter<T>, ISaveDataConverter where T : AbstractSaveData
	{
		public int CurrentVersion { get; private set; }

		public SaveDataConverter(int currentVersion)
		{
			CurrentVersion = currentVersion;
		}

		public sealed override void WriteJson(JsonWriter writer, T value, JsonSerializer serializer)
		{
			throw new NotSupportedException();
		}

		public sealed override T ReadJson(JsonReader reader, Type objectType, T existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			JObject jsonObject = JObject.Load(reader);
			return (T)ReadJsonAlreadyRead(jsonObject, serializer);
		}

		public object ReadJsonAlreadyRead(JObject jsonObject, JsonSerializer serializer)
		{
			int value = JsonExtensions.GetValue(jsonObject, "v", 0);
			if (value == CurrentVersion)
			{
				return ReadJsonInternal(serializer, jsonObject, typeof(T));
			}
			Type previousVersion = GetPreviousVersion(value);
			if (previousVersion != null)
			{
				T val = ReadJsonInternal(serializer, jsonObject, previousVersion);
				if (val != null)
				{
					val.Version = CurrentVersion;
				}
				return val;
			}
			this.LogError($"Version {value} is not supported! Trying to default deserialize", "ReadJsonAlreadyRead", 55);
			return ReadJsonInternal(serializer, jsonObject, typeof(T));
		}

		private T ReadJsonInternal(JsonSerializer serializer, JObject obj, Type valueType)
		{
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
			ISaveVersion saveVersion;
			for (saveVersion = (ISaveVersion)JsonConvert.DeserializeObject(obj.ToString(), valueType, jsonSerializerSettings); saveVersion is IPreviousSaveVersion previousSaveVersion; saveVersion = previousSaveVersion.ToNextVersion())
			{
			}
			if (saveVersion == null)
			{
				return null;
			}
			return (saveVersion as T) ?? throw new TypeLoadException($"Resulting version was not of type \"{typeof(T)}\"");
		}

		public abstract Type GetPreviousVersion(int version);
	}
}
