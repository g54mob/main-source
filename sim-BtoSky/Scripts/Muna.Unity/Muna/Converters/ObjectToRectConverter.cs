using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Muna.Converters
{
	public sealed class ObjectToRectConverter : JsonConverter<Rect>
	{
		private readonly BoxFormat format;

		private readonly string[] fieldNames;

		public ObjectToRectConverter(BoxFormat format)
			: this(format, GetReferenceFieldNames(format))
		{
		}

		public ObjectToRectConverter(BoxFormat format, string[] fieldNames)
		{
			this.format = format;
			this.fieldNames = fieldNames;
		}

		public override void WriteJson(JsonWriter writer, Rect value, JsonSerializer serializer)
		{
			float[] rectValues = GetRectValues(in value, format);
			JObject jObject = new JObject();
			for (int i = 0; i < fieldNames.Length; i++)
			{
				jObject[fieldNames[i]] = rectValues[i];
			}
			jObject.WriteTo(writer);
		}

		public override Rect ReadJson(JsonReader reader, Type type, Rect existing, bool hasExisting, JsonSerializer s)
		{
			JObject obj = JObject.Load(reader);
			return format switch
			{
				BoxFormat.XYXY => Rect.MinMaxRect(GetFieldValue(obj, fieldNames[0]), GetFieldValue(obj, fieldNames[1]), GetFieldValue(obj, fieldNames[2]), GetFieldValue(obj, fieldNames[3])), 
				BoxFormat.XYWH => new Rect(GetFieldValue(obj, fieldNames[0]), GetFieldValue(obj, fieldNames[1]), GetFieldValue(obj, fieldNames[2]), GetFieldValue(obj, fieldNames[3])), 
				BoxFormat.CxCyWH => GetCenterRect(obj), 
				BoxFormat.XYXYXYXY => Rect.MinMaxRect(GetFieldValue(obj, fieldNames[0]), GetFieldValue(obj, fieldNames[1]), GetFieldValue(obj, fieldNames[4]), GetFieldValue(obj, fieldNames[5])), 
				_ => throw new JsonSerializationException($"Failed to read `Rect` from JSON object because of unsupported format: {format}"), 
			};
		}

		private Rect GetCenterRect(JObject obj)
		{
			float fieldValue = GetFieldValue(obj, fieldNames[0]);
			float fieldValue2 = GetFieldValue(obj, fieldNames[1]);
			float fieldValue3 = GetFieldValue(obj, fieldNames[2]);
			float fieldValue4 = GetFieldValue(obj, fieldNames[3]);
			Vector2 vector = new Vector2(fieldValue, fieldValue2);
			Vector2 vector2 = new Vector2(fieldValue3, fieldValue4);
			return new Rect(vector - 0.5f * vector2, vector2);
		}

		private float GetFieldValue(JObject obj, string name)
		{
			if (!obj.TryGetValue(name, StringComparison.InvariantCulture, out JToken value))
			{
				throw new JsonSerializationException($"Missing '{name}' field for {format} box.");
			}
			return (float)value;
		}

		internal static float[] GetRectValues(in Rect rect, BoxFormat format)
		{
			return format switch
			{
				BoxFormat.XYXY => new float[4] { rect.xMin, rect.yMin, rect.xMax, rect.yMax }, 
				BoxFormat.XYWH => new float[4] { rect.xMin, rect.yMin, rect.width, rect.height }, 
				BoxFormat.CxCyWH => new float[4]
				{
					rect.center.x,
					rect.center.y,
					rect.width,
					rect.height
				}, 
				BoxFormat.XYXYXYXY => new float[8] { rect.xMin, rect.yMin, rect.xMax, rect.yMin, rect.xMax, rect.yMax, rect.xMin, rect.yMax }, 
				_ => throw new ArgumentOutOfRangeException("format"), 
			};
		}

		private static string[] GetReferenceFieldNames(BoxFormat format)
		{
			return format switch
			{
				BoxFormat.XYXY => new string[4] { "x_min", "y_min", "x_max", "y_max" }, 
				BoxFormat.XYWH => new string[4] { "x", "y", "width", "height" }, 
				BoxFormat.CxCyWH => new string[4] { "x_center", "y_center", "width", "height" }, 
				BoxFormat.XYXYXYXY => new string[8] { "x1", "y1", "x2", "y2", "x3", "y3", "x4", "y4" }, 
				_ => throw new ArgumentOutOfRangeException("format"), 
			};
		}
	}
}
