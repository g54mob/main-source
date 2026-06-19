using System;
using UnityEngine;

namespace Loxodon.Framework.Localizations
{
	[Serializable]
	public class MonolingualEntry : EntryBase
	{
		[SerializeField]
		private Value value;

		public object GetValue()
		{
			if (value == null)
			{
				return null;
			}
			string dataValue = value.dataValue;
			UnityEngine.Object objectValue = value.objectValue;
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
				return objectValue;
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

		public void SetValue(object value)
		{
			if (this.value == null)
			{
				this.value = new Value();
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
				this.value.objectValue = (UnityEngine.Object)value;
				break;
			case ValueType.String:
				this.value.dataValue = DataConverter.GetString((string)value);
				break;
			case ValueType.Boolean:
				this.value.dataValue = DataConverter.GetString((bool)value);
				break;
			case ValueType.Float:
				this.value.dataValue = DataConverter.GetString((float)value);
				break;
			case ValueType.Int:
				this.value.dataValue = DataConverter.GetString((int)value);
				break;
			case ValueType.Color:
				this.value.dataValue = DataConverter.GetString((Color)value);
				break;
			case ValueType.Vector2:
				this.value.dataValue = DataConverter.GetString((Vector2)value);
				break;
			case ValueType.Vector3:
				this.value.dataValue = DataConverter.GetString((Vector3)value);
				break;
			case ValueType.Vector4:
				this.value.dataValue = DataConverter.GetString((Vector4)value);
				break;
			}
		}
	}
}
