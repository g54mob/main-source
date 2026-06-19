using System;
using UnityEngine;

namespace Loxodon.Framework.Views.Variables
{
	[Serializable]
	public class Variable
	{
		[SerializeField]
		protected string name = "";

		[SerializeField]
		protected UnityEngine.Object objectValue;

		[SerializeField]
		protected string dataValue;

		[SerializeField]
		protected VariableType variableType;

		public virtual string Name
		{
			get
			{
				return name;
			}
			set
			{
				name = value;
			}
		}

		public virtual VariableType VariableType => variableType;

		public virtual Type ValueType
		{
			get
			{
				switch (variableType)
				{
				case VariableType.Boolean:
					return typeof(bool);
				case VariableType.Float:
					return typeof(float);
				case VariableType.Integer:
					return typeof(int);
				case VariableType.String:
					return typeof(string);
				case VariableType.Color:
					return typeof(Color);
				case VariableType.Vector2:
					return typeof(Vector2);
				case VariableType.Vector3:
					return typeof(Vector3);
				case VariableType.Vector4:
					return typeof(Vector4);
				case VariableType.Object:
					if (!(objectValue == null))
					{
						return objectValue.GetType();
					}
					return typeof(UnityEngine.Object);
				case VariableType.GameObject:
					if (!(objectValue == null))
					{
						return objectValue.GetType();
					}
					return typeof(GameObject);
				case VariableType.Component:
					if (!(objectValue == null))
					{
						return objectValue.GetType();
					}
					return typeof(Component);
				default:
					throw new NotSupportedException();
				}
			}
		}

		public virtual void SetValue<T>(T value)
		{
			SetValue(value);
		}

		public virtual T GetValue<T>()
		{
			return (T)GetValue();
		}

		public virtual void SetValue(object value)
		{
			switch (variableType)
			{
			case VariableType.Boolean:
				dataValue = DataConverter.GetString((bool)value);
				break;
			case VariableType.Float:
				dataValue = DataConverter.GetString((float)value);
				break;
			case VariableType.Integer:
				dataValue = DataConverter.GetString((int)value);
				break;
			case VariableType.String:
				dataValue = DataConverter.GetString((string)value);
				break;
			case VariableType.Color:
				dataValue = DataConverter.GetString((Color)value);
				break;
			case VariableType.Vector2:
				dataValue = DataConverter.GetString((Vector2)value);
				break;
			case VariableType.Vector3:
				dataValue = DataConverter.GetString((Vector3)value);
				break;
			case VariableType.Vector4:
				dataValue = DataConverter.GetString((Vector4)value);
				break;
			case VariableType.Object:
				objectValue = (UnityEngine.Object)value;
				break;
			case VariableType.GameObject:
				objectValue = (GameObject)value;
				break;
			case VariableType.Component:
				objectValue = (Component)value;
				break;
			default:
				throw new NotSupportedException();
			}
		}

		public virtual object GetValue()
		{
			return variableType switch
			{
				VariableType.Boolean => DataConverter.ToBoolean(dataValue), 
				VariableType.Float => DataConverter.ToSingle(dataValue), 
				VariableType.Integer => DataConverter.ToInt32(dataValue), 
				VariableType.String => DataConverter.ToString(dataValue), 
				VariableType.Color => DataConverter.ToColor(dataValue), 
				VariableType.Vector2 => DataConverter.ToVector2(dataValue), 
				VariableType.Vector3 => DataConverter.ToVector3(dataValue), 
				VariableType.Vector4 => DataConverter.ToVector4(dataValue), 
				VariableType.Object => objectValue, 
				VariableType.GameObject => objectValue, 
				VariableType.Component => objectValue, 
				_ => throw new NotSupportedException(), 
			};
		}
	}
}
