using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Muna.Converters
{
	public sealed class ArrayToRectConverter : JsonConverter<Rect>
	{
		private readonly BoxFormat format;

		public ArrayToRectConverter(BoxFormat format)
		{
			this.format = format;
		}

		public override void WriteJson(JsonWriter writer, Rect value, JsonSerializer serializer)
		{
			new JArray(ObjectToRectConverter.GetRectValues(in value, format)).WriteTo(writer);
		}

		public override Rect ReadJson(JsonReader reader, Type type, Rect existing, bool hasExisting, JsonSerializer s)
		{
			JArray jArray = JArray.Load(reader);
			int num = ExpectedCount(format);
			if (jArray.Count != num)
			{
				throw new JsonSerializationException($"Expected {num} numbers for {format} box but got {jArray.Count}.");
			}
			float[] array = jArray.ToObject<float[]>();
			return format switch
			{
				BoxFormat.XYXY => Rect.MinMaxRect(array[0], array[1], array[2], array[3]), 
				BoxFormat.XYWH => new Rect(array[0], array[1], array[2], array[3]), 
				BoxFormat.CxCyWH => new Rect(array[0] - 0.5f * array[2], array[1] * 0.5f - array[3], array[2], array[3]), 
				_ => throw new JsonSerializationException($"Failed to read `Rect` from JSON array because of unsupported format: {format}"), 
			};
		}

		private static int ExpectedCount(BoxFormat format)
		{
			return format switch
			{
				BoxFormat.XYXY => 4, 
				BoxFormat.XYWH => 4, 
				BoxFormat.CxCyWH => 4, 
				BoxFormat.XYXYXYXY => 8, 
				_ => throw new ArgumentOutOfRangeException("format"), 
			};
		}
	}
}
