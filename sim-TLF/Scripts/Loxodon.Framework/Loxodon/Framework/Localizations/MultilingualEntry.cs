using System;
using System.Collections.Generic;
using UnityEngine;

namespace Loxodon.Framework.Localizations
{
	[Serializable]
	public class MultilingualEntry : EntryBase
	{
		[SerializeField]
		private List<Value> values;

		public object GetValue(int index)
		{
			if (values == null || values.Count <= 0)
			{
				return null;
			}
			if (index < 0 || index >= values.Count)
			{
				return null;
			}
			Value value = values[index];
			if (value == null)
			{
				return null;
			}
			string dataValue = value.dataValue;
			switch (type)
			{
			case ValueType.Sprite:
			case ValueType.Texture2D:
			case ValueType.Texture3D:
			case ValueType.AudioClip:
			case ValueType.VideoClip:
			case ValueType.Material:
			case ValueType.Font:
			case ValueType.GameObject:
				return value.objectValue;
			case ValueType.String:
				return DataConverter.ToString(dataValue);
			case ValueType.Boolean:
				return DataConverter.ToBoolean(dataValue);
			case ValueType.Float:
				return DataConverter.ToSingle(dataValue);
			case ValueType.Int:
				return DataConverter.ToInt32(dataValue);
			case ValueType.Color:
				return DataConverter.ToColor(dataValue);
			case ValueType.Vector2:
				return DataConverter.ToVector2(dataValue);
			case ValueType.Vector3:
				return DataConverter.ToVector3(dataValue);
			case ValueType.Vector4:
				return DataConverter.ToVector4(dataValue);
			default:
				return null;
			}
		}

		public void SetValue(int index, object obj)
		{
			if (values == null)
			{
				values = new List<Value>();
			}
			if (index >= 0 && index <= values.Count)
			{
				if (index == values.Count)
				{
					values.Add(new Value());
				}
				Value value = values[index];
				if (value == null)
				{
					value = new Value();
					values[index] = value;
				}
				switch (type)
				{
				case ValueType.Sprite:
				case ValueType.Texture2D:
				case ValueType.Texture3D:
				case ValueType.AudioClip:
				case ValueType.VideoClip:
				case ValueType.Material:
				case ValueType.Font:
				case ValueType.GameObject:
					value.objectValue = (UnityEngine.Object)obj;
					break;
				case ValueType.String:
					value.dataValue = DataConverter.GetString((string)obj);
					break;
				case ValueType.Boolean:
					value.dataValue = DataConverter.GetString((bool)obj);
					break;
				case ValueType.Float:
					value.dataValue = DataConverter.GetString((float)obj);
					break;
				case ValueType.Int:
					value.dataValue = DataConverter.GetString((int)obj);
					break;
				case ValueType.Color:
					value.dataValue = DataConverter.GetString((Color)obj);
					break;
				case ValueType.Vector2:
					value.dataValue = DataConverter.GetString((Vector2)obj);
					break;
				case ValueType.Vector3:
					value.dataValue = DataConverter.GetString((Vector3)obj);
					break;
				case ValueType.Vector4:
					value.dataValue = DataConverter.GetString((Vector4)obj);
					break;
				}
			}
		}

		public void RemoveValue(int index)
		{
			if (values != null && values.Count > 0 && index >= 0 && index < values.Count)
			{
				values.RemoveAt(index);
			}
		}
	}
}
