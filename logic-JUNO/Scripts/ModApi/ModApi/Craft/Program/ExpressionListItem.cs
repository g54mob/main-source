using System;
using UnityEngine;

namespace ModApi.Craft.Program
{
	public struct ExpressionListItem
	{
		public enum ValueType
		{
			Number = 0,
			Vector = 1,
			Boolean = 2,
			String = 3
		}

		private string _str;

		private ValueType _valueType;

		private Vector3d _vec;

		public bool BooleanValue
		{
			get
			{
				return _valueType switch
				{
					ValueType.String => TryParseBool(_str), 
					ValueType.Vector => _vec.sqrMagnitude != 0.0, 
					ValueType.Number => Number != 0.0, 
					ValueType.Boolean => Boolean, 
					_ => false, 
				};
			}
			set
			{
				Boolean = value;
				_valueType = ValueType.Boolean;
			}
		}

		public double NumberValue
		{
			get
			{
				return _valueType switch
				{
					ValueType.String => TryParseDouble(_str), 
					ValueType.Vector => _vec.magnitude, 
					ValueType.Number => Number, 
					ValueType.Boolean => Boolean ? 1.0 : 0.0, 
					_ => 0.0, 
				};
			}
			set
			{
				Number = value;
				_valueType = ValueType.Number;
			}
		}

		public string StringValue
		{
			get
			{
				return _valueType switch
				{
					ValueType.String => _str, 
					ValueType.Vector => _vec.ToString(), 
					ValueType.Number => Number.ToString(), 
					ValueType.Boolean => Boolean ? "true" : "false", 
					_ => string.Empty, 
				};
			}
			set
			{
				_str = value;
				_valueType = ValueType.String;
			}
		}

		public Vector3d VectorValue
		{
			get
			{
				return _valueType switch
				{
					ValueType.Vector => _vec, 
					ValueType.String => TryParseVector(_str), 
					_ => Vector3d.zero, 
				};
			}
			set
			{
				_vec = value;
				_valueType = ValueType.Number;
			}
		}

		private bool Boolean
		{
			get
			{
				return _vec.x != 0.0;
			}
			set
			{
				_vec.x = (value ? 1.0 : 0.0);
			}
		}

		private double Number
		{
			get
			{
				return _vec.x;
			}
			set
			{
				_vec.x = value;
			}
		}

		public static ExpressionListItem CreateFromSerialised(string str)
		{
			if (double.TryParse(str, out var result))
			{
				return result;
			}
			if ("true".Equals(str, StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
			if ("false".Equals(str, StringComparison.OrdinalIgnoreCase))
			{
				return false;
			}
			if (ExpressionResult.TryParseVector(str, out var result2))
			{
				return result2;
			}
			return str;
		}

		public static explicit operator ExpressionListItem(ExpressionResult result)
		{
			return result.ExpressionType switch
			{
				ExpressionType.Text => result.TextValue, 
				ExpressionType.Number => result.NumberValue, 
				ExpressionType.Boolean => result.BoolValue, 
				ExpressionType.Vector => result.VectorValue, 
				_ => string.Empty, 
			};
		}

		public static implicit operator ExpressionListItem(string s)
		{
			return new ExpressionListItem
			{
				_valueType = ValueType.String,
				_str = s,
				_vec = default(Vector3d)
			};
		}

		public static implicit operator ExpressionListItem(double d)
		{
			return new ExpressionListItem
			{
				_valueType = ValueType.Number,
				_str = null,
				_vec = new Vector3d(d, 0.0, 0.0)
			};
		}

		public static implicit operator ExpressionListItem(bool b)
		{
			return new ExpressionListItem
			{
				_valueType = ValueType.Boolean,
				_str = null,
				_vec = new Vector3d(b ? 1.0 : 0.0, 0.0, 0.0)
			};
		}

		public static implicit operator ExpressionListItem(Vector3d v)
		{
			return new ExpressionListItem
			{
				_valueType = ValueType.Vector,
				_str = null,
				_vec = v
			};
		}

		public void Apply(ExpressionResult to)
		{
			switch (_valueType)
			{
			case ValueType.Number:
				to.NumberValue = Number;
				break;
			case ValueType.Vector:
				to.VectorValue = _vec;
				break;
			case ValueType.Boolean:
				to.BoolValue = Boolean;
				break;
			case ValueType.String:
				to.TextValue = _str;
				break;
			default:
				to.TextValue = string.Empty;
				break;
			}
		}

		public override bool Equals(object obj)
		{
			if (obj is ExpressionListItem expressionListItem)
			{
				return _valueType switch
				{
					ValueType.Number => expressionListItem.NumberValue == Number, 
					ValueType.String => expressionListItem.StringValue == _str, 
					ValueType.Boolean => expressionListItem.BooleanValue == Boolean, 
					ValueType.Vector => expressionListItem.VectorValue == _vec, 
					_ => false, 
				};
			}
			if (obj is string text)
			{
				return StringValue == text;
			}
			if (obj is double num)
			{
				return NumberValue == num;
			}
			if (obj is Vector3d vector3d)
			{
				return VectorValue == vector3d;
			}
			if (obj is bool flag)
			{
				return BooleanValue == flag;
			}
			return false;
		}

		public override int GetHashCode()
		{
			int hashCode = _valueType.GetHashCode();
			return _valueType switch
			{
				ValueType.Number => HashCode.Combine(hashCode, Number), 
				ValueType.String => HashCode.Combine(hashCode, _str.GetHashCode()), 
				ValueType.Boolean => HashCode.Combine(hashCode, Boolean.GetHashCode()), 
				ValueType.Vector => HashCode.Combine(hashCode, _vec.GetHashCode()), 
				_ => hashCode, 
			};
		}

		public override string ToString()
		{
			return StringValue;
		}

		private static bool TryParseBool(string s)
		{
			return string.Equals(s, "true", StringComparison.OrdinalIgnoreCase);
		}

		private static double TryParseDouble(string s)
		{
			double.TryParse(s, out var result);
			return result;
		}

		private static Vector3d TryParseVector(string s)
		{
			ExpressionResult.TryParseVector(s, out var result);
			return result;
		}
	}
}
