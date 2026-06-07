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
				while (true)
				{
					int num = 1356829169;
					while (true)
					{
						switch (num ^ 0x50DF91F0)
						{
						case 2:
							break;
						case 1:
							switch (index)
							{
							default:
								goto IL_003a;
							case 0:
								break;
							case 1:
								return b;
							case 2:
								return c;
							case 3:
								return d;
							}
							goto default;
						default:
							return a;
						case 0:
							throw new ArgumentOutOfRangeException("index");
						}
						break;
						IL_003a:
						num = 1356829168;
					}
				}
			}
			set
			{
				while (true)
				{
					int num = 490840408;
					while (true)
					{
						switch (num ^ 0x1D41A15B)
						{
						case 7:
							break;
						case 5:
							c = value;
							num = 490840409;
							continue;
						case 4:
							goto IL_0042;
						case 2:
							return;
						case 0:
							goto IL_0059;
						case 1:
							goto IL_0068;
						case 3:
							switch (index)
							{
							case 2:
								break;
							case 1:
								goto IL_0042;
							case 3:
								goto IL_0059;
							case 0:
								goto IL_0068;
							default:
								goto IL_008d;
							}
							goto case 5;
						default:
							{
								throw new ArgumentOutOfRangeException("index");
							}
							IL_008d:
							num = 490840413;
							continue;
							IL_0068:
							a = value;
							return;
							IL_0059:
							d = value;
							return;
							IL_0042:
							b = value;
							return;
						}
						break;
					}
				}
			}
		}

		public static Float4x Zero
		{
			get
			{
				return default(Float4x);
			}
		}

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
			if (!(obj is Float4x))
			{
				return false;
			}
			Float4x float4x = (Float4x)obj;
			if (float4x.a == a)
			{
				while (true)
				{
					int num = -1885596015;
					while (true)
					{
						switch (num ^ -1885596016)
						{
						case 0:
							break;
						case 1:
							goto IL_003e;
						default:
							return float4x.d == d;
						}
						break;
						IL_003e:
						if (float4x.b != b || float4x.c != c)
						{
							goto end_IL_0020;
						}
						num = -1885596014;
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
			while (true)
			{
				int num2 = -529048800;
				while (true)
				{
					switch (num2 ^ -529048798)
					{
					case 4:
						break;
					case 1:
						num = num * 29 + d.GetHashCode();
						num2 = -529048798;
						continue;
					case 3:
						num = num * 29 + c.GetHashCode();
						num2 = -529048797;
						continue;
					case 2:
						num = num * 29 + b.GetHashCode();
						num2 = -529048799;
						continue;
					default:
						return num;
					}
					break;
				}
			}
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
			object[] array = new object[7] { a, ", ", b, null, null, null, null };
			while (true)
			{
				int num = 1751372226;
				while (true)
				{
					switch (num ^ 0x6863D1C3)
					{
					case 0:
						break;
					case 1:
						goto IL_0049;
					default:
						array[6] = d;
						return string.Concat(array);
					}
					break;
					IL_0049:
					array[3] = ", ";
					array[4] = c;
					array[5] = ", ";
					num = 1751372225;
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
					int num = -492334826;
					while (true)
					{
						switch (num ^ -492334825)
						{
						case 0:
							break;
						case 1:
							_additionDelegate = Add;
							num = -492334827;
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
				_subtractionDelegate = Subtract;
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
