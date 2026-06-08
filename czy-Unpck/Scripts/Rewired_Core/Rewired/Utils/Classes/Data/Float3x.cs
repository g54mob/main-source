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
				case 0:
					return a;
				case 1:
					return b;
				case 2:
					return c;
				default:
					throw new ArgumentOutOfRangeException("index");
				}
			}
			set
			{
				while (true)
				{
					int num = 2117848898;
					while (true)
					{
						switch (num ^ 0x7E3BCF41)
						{
						case 5:
							break;
						case 3:
							switch (index)
							{
							case 0:
								goto IL_0045;
							case 1:
								goto IL_0054;
							case 2:
								goto IL_0063;
							}
							goto IL_003e;
						case 0:
							goto IL_0045;
						case 1:
							goto IL_0054;
						case 2:
							goto IL_0063;
						default:
							{
								throw new ArgumentOutOfRangeException("index");
							}
							IL_0063:
							c = value;
							return;
							IL_0054:
							b = value;
							return;
							IL_0045:
							a = value;
							return;
						}
						break;
						IL_003e:
						num = 2117848901;
					}
				}
			}
		}

		public static Float3x Zero => default(Float3x);

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
			if (!(obj is Float3x float3x))
			{
				return false;
			}
			if (float3x.a == a)
			{
				while (true)
				{
					int num = -984023066;
					while (true)
					{
						switch (num ^ -984023065)
						{
						case 0:
							break;
						case 1:
							goto IL_003e;
						default:
							return float3x.c == c;
						}
						break;
						IL_003e:
						if (float3x.b != b)
						{
							goto end_IL_0020;
						}
						num = -984023067;
					}
					continue;
					end_IL_0020:
					break;
				}
			}
			return false;
		}

		public override int GetHashCode()
		{
			int num = 17;
			num = num * 29 + a.GetHashCode();
			num = num * 29 + b.GetHashCode();
			return num * 29 + c.GetHashCode();
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
			object[] array = new object[5] { a, ", ", null, null, null };
			while (true)
			{
				int num = -1803703302;
				while (true)
				{
					switch (num ^ -1803703301)
					{
					case 0:
						break;
					case 1:
						goto IL_003b;
					default:
						array[4] = c;
						return string.Concat(array);
					}
					break;
					IL_003b:
					array[2] = b;
					array[3] = ", ";
					num = -1803703303;
				}
			}
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
				while (true)
				{
					int num = 1283931362;
					while (true)
					{
						switch (num ^ 0x4C873CE3)
						{
						case 2:
							break;
						case 1:
							_divisionDelegate = Multiply;
							num = 1283931363;
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
