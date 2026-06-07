#define ENABLE_DEBUG_ERRORS
using System;
using Data.Shapes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SaveData.FactoryFloor;

namespace Utils.JsonConverterUtils
{
	public class ShapeDtoToIndexConverter : JsonConverter<ShapeDto>
	{
		private readonly FactoryShapesSaveData _shapesSaveData;

		public ShapeDtoToIndexConverter(FactoryShapesSaveData shapesSaveData)
		{
			_shapesSaveData = shapesSaveData;
		}

		public override void WriteJson(JsonWriter writer, ShapeDto value, JsonSerializer serializer)
		{
			if (TryGetShapeIndex(value, out var shapeIndex))
			{
				JObject jObject = new JObject();
				jObject["s"] = shapeIndex;
				jObject.WriteTo(writer);
			}
			else
			{
				serializer.Converters.Remove(this);
				serializer.Serialize(writer, value, typeof(ShapeDto));
				serializer.Converters.Add(this);
			}
		}

		private bool TryGetShapeIndex(ShapeDto value, out int shapeIndex)
		{
			for (int i = 0; i < _shapesSaveData.Shapes.Length; i++)
			{
				if (!(_shapesSaveData.Shapes[i].Hash != value.Hash))
				{
					shapeIndex = i;
					return true;
				}
			}
			shapeIndex = -1;
			return false;
		}

		public override ShapeDto ReadJson(JsonReader reader, Type objectType, ShapeDto existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			JObject obj = JObject.Load(reader);
			if (!obj.TryGetValue<int>("s", out var value))
			{
				return ReadJsonInternal(serializer, obj, objectType);
			}
			if (value < 0 || value >= _shapesSaveData.Shapes.Length)
			{
				this.LogError(string.Format("{0} {1} is out of bounds of the {2}.{3}, changing to 0 try to recover.", "shapeIndex", value, "_shapesSaveData", "Shapes"), "ReadJson", 61);
				value = 0;
			}
			return _shapesSaveData.Shapes[value];
		}

		private ShapeDto ReadJsonInternal(JsonSerializer serializer, JObject obj, Type valueType)
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
			return (ShapeDto)JsonConvert.DeserializeObject(obj.ToString(), valueType, jsonSerializerSettings);
		}
	}
}
