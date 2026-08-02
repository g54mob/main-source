using System;
using UnityEngine;

namespace FIMSpace.FGenerating
{
	[Serializable]
	public class FUniversalVariable
	{
		public enum EVariableType
		{
			Number = 0,
			Bool = 1,
			Vector2 = 2,
			Vector3 = 3,
			Color = 4,
			String = 5,
			Curve = 6,
			UnityObject = 7,
			CustomObject = 8
		}

		public string VariableName = "Variable";

		[SerializeField]
		protected string Tooltip = "";

		private bool _tooltipWasSet;

		[SerializeField]
		protected Vector4 _value = Vector4.zero;

		[SerializeField]
		protected string _string = "";

		[SerializeField]
		protected AnimationCurve _curve;

		[SerializeField]
		protected UnityEngine.Object _uObject;

		[SerializeField]
		protected object _object;

		[NonSerialized]
		private int nameHash;

		public EVariableType VariableType;

		[SerializeField]
		private Vector4 _rangeHelper = Vector4.zero;

		[NonSerialized]
		public Texture Icon;

		[NonSerialized]
		public bool _GUI_HideVariable;

		[NonSerialized]
		public string _GUI_DisplayNameReplace = "";

		[NonSerialized]
		public Color _GUI_CurveColor = Color.cyan;

		[NonSerialized]
		private GUILayoutOption[] _GUI_Layout;

		public bool TooltipAssigned => _tooltipWasSet;

		public int GetNameHash
		{
			get
			{
				if (nameHash == 0)
				{
					nameHash = VariableName.GetHashCode();
				}
				return nameHash;
			}
		}

		[HideInInspector]
		public bool IsFloat
		{
			get
			{
				return _value.w != 1f;
			}
			set
			{
				_value.w = ((!value) ? 1 : 0);
			}
		}

		public Vector4 RangesHelperValue => _rangeHelper;

		public void AssignTooltip(string tooltip)
		{
			if (!_tooltipWasSet)
			{
				Tooltip = tooltip;
				_tooltipWasSet = true;
			}
		}

		public FUniversalVariable(string name, object value)
		{
			VariableName = name;
			SetValue(value);
		}

		protected virtual int GetVariableType()
		{
			return (int)VariableType;
		}

		protected virtual void SetVariableType(int id)
		{
			VariableType = (EVariableType)id;
		}

		public virtual void SetValue(object o)
		{
			if (o is int)
			{
				_value = new Vector4((int)o, 0f, 0f, 1f);
				VariableType = EVariableType.Number;
				IsFloat = false;
			}
			else if (o is float)
			{
				_value = new Vector4((float)o, 0f, 0f, 0f);
				VariableType = EVariableType.Number;
				IsFloat = true;
			}
			else if (o is bool)
			{
				if ((bool)o)
				{
					_value.x = 1f;
				}
				else
				{
					_value.x = 0f;
				}
				VariableType = EVariableType.Bool;
			}
			else if (o is Vector2Int vector2Int)
			{
				_value = new Vector4(vector2Int.x, vector2Int.y);
				VariableType = EVariableType.Vector2;
				IsFloat = false;
			}
			else if (o is Vector3Int vector3Int)
			{
				_value = new Vector4(vector3Int.x, vector3Int.y, vector3Int.z);
				VariableType = EVariableType.Vector3;
				IsFloat = false;
			}
			else if (o is Vector2 vector)
			{
				_value = vector;
				VariableType = EVariableType.Vector2;
				IsFloat = true;
			}
			else if (o is Vector3 vector2)
			{
				_value = vector2;
				VariableType = EVariableType.Vector3;
				IsFloat = true;
			}
			else if (o is string)
			{
				_string = o as string;
				VariableType = EVariableType.String;
			}
			else if (o is Color color)
			{
				_value = new Vector4(color.r, color.g, color.b, color.a);
				VariableType = EVariableType.Color;
			}
			else if (o is AnimationCurve)
			{
				_curve = o as AnimationCurve;
				VariableType = EVariableType.Curve;
			}
			else if (o is UnityEngine.Object)
			{
				_uObject = o as UnityEngine.Object;
				VariableType = EVariableType.UnityObject;
			}
			else if (o != null)
			{
				_object = o;
				VariableType = EVariableType.CustomObject;
			}
			else
			{
				_object = o;
				_uObject = null;
				VariableType = EVariableType.CustomObject;
			}
		}

		public int GetInt()
		{
			return (int)_value.x;
		}

		public float GetFloat()
		{
			return _value.x;
		}

		public bool GetBool()
		{
			return _value.x == 1f;
		}

		public Color GetColor()
		{
			return new Color(_value.x, _value.y, _value.z, _value.w);
		}

		public Vector2 GetVector2()
		{
			return new Vector2(_value.x, _value.y);
		}

		public Vector2Int GetVector2Int()
		{
			return new Vector2Int(Mathf.RoundToInt(_value.x), Mathf.RoundToInt(_value.y));
		}

		public Vector3 GetVector3()
		{
			return new Vector3(_value.x, _value.y, _value.z);
		}

		public Vector3Int GetVector3Int()
		{
			return new Vector3Int(Mathf.RoundToInt(_value.x), Mathf.RoundToInt(_value.y), Mathf.RoundToInt(_value.z));
		}

		public string GetString()
		{
			return _string;
		}

		public AnimationCurve GetCurve()
		{
			return _curve;
		}

		public UnityEngine.Object GetUnityObject()
		{
			return _uObject;
		}

		public object GetObject()
		{
			return _object;
		}

		public GameObject GetGameObject()
		{
			return _uObject as GameObject;
		}

		public Material GetMaterial()
		{
			return _uObject as Material;
		}

		public void SetMinMaxSlider(float min, float max)
		{
			_rangeHelper = new Vector4(min, max, 0f, 0f);
		}

		public void SetCurveFixedRange(float startTime, float startValue, float endTime, float endValue)
		{
			_rangeHelper = new Vector4(startTime, startValue, endTime, endValue);
		}

		public virtual object GetValue()
		{
			return VariableType switch
			{
				EVariableType.Number => GetFloat(), 
				EVariableType.Bool => GetBool(), 
				EVariableType.Vector2 => GetVector2(), 
				EVariableType.Vector3 => GetVector3(), 
				EVariableType.Color => GetColor(), 
				EVariableType.String => GetString(), 
				EVariableType.Curve => GetCurve(), 
				EVariableType.UnityObject => GetUnityObject(), 
				EVariableType.CustomObject => _object, 
				_ => null, 
			};
		}

		public virtual FUniversalVariable Copy()
		{
			return (FUniversalVariable)MemberwiseClone();
		}

		public virtual bool Editor_DisplayVariableGUI(GUILayoutOption[] guiLayoutOptions = null)
		{
			return false;
		}
	}
}
