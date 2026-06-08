using System;
using UnityEngine;

namespace Rewired.Utils.Classes.Data
{
	[Serializable]
	public struct Float4x : IEquatable<Float4x>
	{
		public const int Length = 4;

		public float a;

		public float b;

		public float c;

		public float d;

		private static Func<Float4x, Float4x, Float4x> _additionDelegate;

		private static Func<Float4x, Float4x, Float4x> _subtractionDelegate;

		private static Func<Float4x, Float4x, Float4x> _multiplicationDelegate;

		private static Func<Float4x, Float4x, Float4x> _divisionDelegate;

		public float this[int index]
		{
			get
			{
				switch (index)
				{
				default:
					while (true)
					{
						switch (0x3B9B7FB1 ^ 0x3B9B7FB3)
						{
						case 0:
							continue;
						case 2:
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
				case 3:
					return d;
				}
			}
			set
			{
				int num;
				switch (index)
				{
				default:
					num = 1851958413;
					goto IL_001d;
				case 2:
					goto IL_0065;
				case 3:
					goto IL_0073;
				case 0:
					goto IL_0082;
				case 1:
					break;
					IL_001d:
					while (true)
					{
						switch (num ^ 0x6E62A48F)
						{
						case 0:
							break;
						case 2:
							num = 1851958408;
							continue;
						case 1:
							return;
						case 6:
							return;
						case 3:
							goto IL_0065;
						case 4:
							goto IL_0073;
						case 5:
							goto IL_0082;
						case 8:
							goto end_IL_0003;
						default:
							throw new ArgumentOutOfRangeException("index");
						}
						break;
					}
					goto default;
					IL_0082:
					a = value;
					num = 1851958414;
					goto IL_001d;
					IL_0073:
					d = value;
					return;
					IL_0065:
					c = value;
					num = 1851958409;
					goto IL_001d;
					end_IL_0003:
					break;
				}
				b = value;
			}
		}

		public static Float4x Zero => default(Float4x);

		public Float4x(float a, float b, float c, float d)
		{
			this.a = a;
			this.b = b;
			this.c = c;
			this.d = d;
		}

		public Float4x Clone()
		{
			return new Float4x(a, b, c, d);
		}

		public static Float4x Clone(Float4x obj)
		{
			return obj.Clone();
		}

		public override bool Equals(object obj)
		{
			if (!(obj is Float4x float4x))
			{
				return false;
			}
			if (float4x.a == a && float4x.b == b && float4x.c == c)
			{
				return float4x.d == d;
			}
			return false;
		}

		public override int GetHashCode()
		{
			int num = 17;
			num = num * 29 + a.GetHashCode();
			num = num * 29 + b.GetHashCode();
			num = num * 29 + c.GetHashCode();
			return num * 29 + d.GetHashCode();
		}

		public bool Equals(Float4x other)
		{
			if (a == other.a && b == other.b && c == other.c)
			{
				return d == other.d;
			}
			return false;
		}

		public override string ToString()
		{
			object[] array = new object[7];
			while (true)
			{
				int num = -1212755320;
				while (true)
				{
					switch (num ^ -1212755319)
					{
					case 0:
						break;
					case 1:
						array[0] = a;
						array[1] = ", ";
						array[2] = b;
						array[3] = ", ";
						array[4] = c;
						num = -1212755318;
						continue;
					case 3:
						array[5] = ", ";
						array[6] = d;
						num = -1212755317;
						continue;
					default:
						return string.Concat(array);
					}
					break;
				}
			}
		}

		public static Float4x Add(Float4x value1, Float4x value2)
		{
			return value1 + value2;
		}

		public static Float4x Subtract(Float4x value1, Float4x value2)
		{
			return value1 - value2;
		}

		public static Float4x Multiply(Float4x value1, Float4x value2)
		{
			return value1 * value2;
		}

		public static Float4x Divide(Float4x value1, Float4x value2)
		{
			return value1 / value2;
		}

		public static Func<Float4x, Float4x, Float4x> GetAdditionDelegate()
		{
			if (_additionDelegate == null)
			{
				while (true)
				{
					int num = 1424314531;
					while (true)
					{
						switch (num ^ 0x54E550A2)
						{
						case 0:
							break;
						case 1:
							_additionDelegate = Add;
							num = 1424314528;
							continue;
						default:
							goto end_IL_0007;
						}
						break;
					}
					continue;
					end_IL_0007:
					break;
				}
			}
			return _additionDelegate;
		}

		public static Func<Float4x, Float4x, Float4x> GetSubtractionDelegate()
		{
			if (_subtractionDelegate == null)
			{
				while (true)
				{
					int num = -952554634;
					while (true)
					{
						switch (num ^ -952554636)
						{
						case 0:
							break;
						case 2:
							_subtractionDelegate = Subtract;
							num = -952554635;
							continue;
						default:
							goto end_IL_0007;
						}
						break;
					}
					continue;
					end_IL_0007:
					break;
				}
			}
			return _subtractionDelegate;
		}

		public static Func<Float4x, Float4x, Float4x> GetMultiplicationDelegate()
		{
			if (_multiplicationDelegate == null)
			{
				_multiplicationDelegate = Multiply;
			}
			return _multiplicationDelegate;
		}

		public static Func<Float4x, Float4x, Float4x> GetDivisionDelegate()
		{
			if (_divisionDelegate == null)
			{
				_divisionDelegate = Multiply;
			}
			return _divisionDelegate;
		}

		public static implicit operator Float4x(Vector4 obj)
		{
			return new Float4x(obj.x, obj.y, obj.z, obj.w);
		}

		public static implicit operator Vector4(Float4x obj)
		{
			return new Vector4(obj.a, obj.b, obj.c, obj.d);
		}

		public static Float4x operator +(Float4x value1, Float4x value2)
		{
			return new Float4x(value1.a + value2.a, value1.b + value2.b, value1.c + value2.c, value1.d + value2.d);
		}

		public static Float4x operator -(Float4x value1, Float4x value2)
		{
			return new Float4x(value1.a - value2.a, value1.b - value2.b, value1.c - value2.c, value1.d - value2.d);
		}

		public static Float4x operator *(Float4x value1, Float4x value2)
		{
			return new Float4x(value1.a * value2.a, value1.b * value2.b, value1.c * value2.c, value1.d * value2.d);
		}

		public static Float4x operator /(Float4x value1, Float4x value2)
		{
			return new Float4x(value1.a / value2.a, value1.b / value2.b, value1.c / value2.c, value1.d / value2.d);
		}

		public static Float4x operator +(Float4x value1, float value2)
		{
			return new Float4x(value1.a + value2, value1.b + value2, value1.c + value2, value1.d + value2);
		}

		public static Float4x operator -(Float4x value1, float value2)
		{
			return new Float4x(value1.a - value2, value1.b - value2, value1.c - value2, value1.d - value2);
		}

		public static Float4x operator *(Float4x value1, float value2)
		{
			return new Float4x(value1.a * value2, value1.b * value2, value1.c * value2, value1.d * value2);
		}

		public static Float4x operator /(Float4x value1, float value2)
		{
			return new Float4x(value1.a / value2, value1.b / value2, value1.c / value2, value1.d / value2);
		}
	}
}
