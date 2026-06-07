using System;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations
{
	[Serializable]
	public class LocalVar
	{
		public enum VarType
		{
			Int = 0,
			Float = 1,
			Bool = 2,
			String = 3,
			Vector3 = 4,
			Vector2 = 5,
			GameObject = 6,
			Transform = 7,
			Material = 8,
			UnityObject = 9
		}

		public string name;

		public VarType type;

		public int intValue;

		public float floatValue;

		public bool boolValue;

		public string stringValue;

		public Vector3 vector3Value;

		public Vector2 vector2Value;

		public GameObjectReference gameObjectValue;

		public TransformReference transformValue;

		public Material materialValue;

		public UnityEngine.Object objectValue;

		public object GetValue()
		{
			return type switch
			{
				VarType.Int => intValue, 
				VarType.Float => floatValue, 
				VarType.Bool => boolValue, 
				VarType.String => stringValue, 
				VarType.Vector3 => vector3Value, 
				VarType.Vector2 => vector2Value, 
				VarType.GameObject => gameObjectValue, 
				VarType.Transform => transformValue, 
				VarType.Material => materialValue, 
				VarType.UnityObject => objectValue, 
				_ => null, 
			};
		}

		public void SetValue(object value)
		{
			switch (type)
			{
			case VarType.Int:
				intValue = (int)value;
				break;
			case VarType.Float:
				floatValue = (float)value;
				break;
			case VarType.Bool:
				boolValue = (bool)value;
				break;
			case VarType.String:
				stringValue = (string)value;
				break;
			case VarType.Vector3:
				vector3Value = (Vector3)value;
				break;
			case VarType.Vector2:
				vector2Value = (Vector2)value;
				break;
			case VarType.GameObject:
				gameObjectValue.Value = (GameObject)value;
				break;
			case VarType.Transform:
				transformValue.Value = (Transform)value;
				break;
			case VarType.Material:
				materialValue = (Material)value;
				break;
			case VarType.UnityObject:
				objectValue = (UnityEngine.Object)value;
				break;
			}
		}

		public void SetValue(VarType type, object value)
		{
			this.type = type;
			SetValue(value);
		}

		public void SetValue<T>(object value)
		{
			Type typeFromHandle = typeof(T);
			if (typeFromHandle == typeof(int))
			{
				SetValue(VarType.Int, (int)value);
			}
			else if (typeFromHandle == typeof(float))
			{
				SetValue(VarType.Float, (float)value);
			}
			else if (typeFromHandle == typeof(bool))
			{
				SetValue(VarType.Bool, (bool)value);
			}
			else if (typeFromHandle == typeof(string))
			{
				SetValue(VarType.String, (string)value);
			}
			else if (typeFromHandle == typeof(Vector3))
			{
				SetValue(VarType.Vector3, (Vector3)value);
			}
			else if (typeFromHandle == typeof(Vector2))
			{
				SetValue(VarType.Vector2, (Vector2)value);
			}
			else if (typeFromHandle == typeof(GameObject))
			{
				SetValue(VarType.GameObject, (GameObject)value);
			}
			else if (typeFromHandle == typeof(Transform))
			{
				SetValue(VarType.Transform, (Transform)value);
			}
			else if (typeFromHandle == typeof(Material))
			{
				SetValue(VarType.Material, (Material)value);
			}
			else if (typeFromHandle == typeof(UnityEngine.Object))
			{
				SetValue(VarType.UnityObject, (UnityEngine.Object)value);
			}
		}
	}
}
