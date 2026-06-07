using System;
using UnityEngine;

namespace Rewired.Utils.Classes.Data
{
	[Serializable]
	public struct Float3x : IEquatable<Float3x>
	{
		public const int Length = 3;

		public float a;

		public float b;

		public float c;

		private static Func<Float3x, Float3x, Float3x> _additionDelegate;

		private static Func<Float3x, Float3x, Float3x> _subtractionDelegate;

		private static Func<Float3x, Float3x, Float3x> _multiplicationDelegate;

		private static Func<Float3x, Float3x, Float3x> _divisionDelegate;

		public float this[int index]
		{
			get
			{
				switch (index)
				{
				default:
					while (true)
					{
						switch (-1826267217 ^ -1826267218)
						{
						case 0:
							continue;
						case 1:
							throw new ArgumentOutOfRangeException("index");
						}
						break;
					}
					goto case 0;
				case 0:
					return a;
				case 1:
					return b;
				case 2:
					return c;
				}
			}
			set
			{
				switch (index)
				{
				default:
					while (true)
					{
						int num = 1993745315;
						while (true)
						{
							switch (num ^ 0x76D623A1)
							{
							case 5:
								break;
							case 2:
								num = 1993745313;
								continue;
							case 1:
								goto end_IL_0014;
							case 4:
								goto IL_0054;
							case 3:
								goto end_IL_0003;
							default:
								throw new ArgumentOutOfRangeException("index");
							}
							break;
						}
						continue;
						end_IL_0014:
						break;
					}
					goto case 1;
				case 1:
					b = value;
					return;
				case 2:
					goto IL_0054;
				case 0:
					break;
					IL_0054:
					c = value;
					return;
					end_IL_0003:
					break;
				}
				a = value;
			}
		}

		public static Float3x Zero
		{
			get
			{
				return default(Float3x);
			}
		}

		public Float3x(float x, float y, float z)
		{
			a = x;
			b = y;
			c = z;
		}

		public Float3x Clone()
		{
			return new Float3x(a, b, c);
		}

		public static Float3x Clone(Float3x obj)
		{
			return obj.Clone();
		}

		public override bool Equals(object obj)
		{
			if (!(obj is Float3x))
			{
				return false;
			}
			Float3x float3x = (Float3x)obj;
			if (float3x.a == a && float3x.b == b)
			{
				return float3x.c == c;
			}
			return false;
		}

		public override int GetHashCode()
		{
			int num = 17;
			num = num * 29 + a.GetHashCode();
			num = num * 29 + b.GetHashCode();
			while (true)
			{
				int num2 = 1498276845;
				while (true)
				{
					switch (num2 ^ 0x594DE3EC)
					{
					case 0:
						break;
					case 1:
						goto IL_0043;
					default:
						return num;
					}
					break;
					IL_0043:
					num = num * 29 + c.GetHashCode();
					num2 = 1498276846;
				}
			}
		}

		public bool Equals(Float3x other)
		{
			if (a == other.a && b == other.b)
			{
				return c == other.c;
			}
			return false;
		}

		public override string ToString()
		{
			return a + ", " + b + ", " + c;
		}

		public static Float3x Add(Float3x value1, Float3x value2)
		{
			return value1 + value2;
		}

		public static Float3x Subtract(Float3x value1, Float3x value2)
		{
			return value1 - value2;
		}

		public static Float3x Multiply(Float3x value1, Float3x value2)
		{
			return value1 * value2;
		}

		public static Float3x Divide(Float3x value1, Float3x value2)
		{
			return value1 / value2;
		}

		public static Func<Float3x, Float3x, Float3x> GetAdditionDelegate()
		{
			if (_additionDelegate == null)
			{
				_additionDelegate = Add;
			}
			return _additionDelegate;
		}

		public static Func<Float3x, Float3x, Float3x> GetSubtractionDelegate()
		{
			if (_subtractionDelegate == null)
			{
				_subtractionDelegate = Subtract;
			}
			return _subtractionDelegate;
		}

		public static Func<Float3x, Float3x, Float3x> GetMultiplicationDelegate()
		{
			if (_multiplicationDelegate == null)
			{
				_multiplicationDelegate = Multiply;
			}
			return _multiplicationDelegate;
		}

		public static Func<Float3x, Float3x, Float3x> GetDivisionDelegate()
		{
			if (_divisionDelegate == null)
			{
				_divisionDelegate = Multiply;
			}
			return _divisionDelegate;
		}

		public static implicit operator Float3x(Vector3 obj)
		{
			return new Float3x(obj.x, obj.y, obj.z);
		}

		public static implicit operator Vector3(Float3x obj)
		{
			return new Vector3(obj.a, obj.b, obj.c);
		}

		public static Float3x operator +(Float3x value1, Float3x value2)
		{
			return new Float3x(value1.a + value2.a, value1.b + value2.b, value1.c + value2.c);
		}

		public static Float3x operator -(Float3x value1, Float3x value2)
		{
			return new Float3x(value1.a - value2.a, value1.b - value2.b, value1.c - value2.c);
		}

		public static Float3x operator *(Float3x value1, Float3x value2)
		{
			return new Float3x(value1.a * value2.a, value1.b * value2.b, value1.c * value2.c);
		}

		public static Float3x operator /(Float3x value1, Float3x value2)
		{
			return new Float3x(value1.a / value2.a, value1.b / value2.b, value1.c / value2.c);
		}

		public static Float3x operator +(Float3x value1, float value2)
		{
			return new Float3x(value1.a + value2, value1.b + value2, value1.c + value2);
		}

		public static Float3x operator -(Float3x value1, float value2)
		{
			return new Float3x(value1.a - value2, value1.b - value2, value1.c - value2);
		}

		public static Float3x operator *(Float3x value1, float value2)
		{
			return new Float3x(value1.a * value2, value1.b * value2, value1.c * value2);
		}

		public static Float3x operator /(Float3x value1, float value2)
		{
			return new Float3x(value1.a / value2, value1.b / value2, value1.c / value2);
		}
	}
}
