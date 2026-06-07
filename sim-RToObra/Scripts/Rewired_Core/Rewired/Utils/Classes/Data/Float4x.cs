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
					int num = 1258750577;
					while (true)
					{
						switch (num ^ 0x4B070273)
						{
						case 3:
							break;
						case 2:
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
						case 1:
							throw new ArgumentOutOfRangeException("index");
						}
						break;
						IL_003a:
						num = 1258750578;
					}
				}
			}
			set
			{
				switch (index)
				{
				case 1:
					b = value;
					return;
				case 3:
					goto IL_005f;
				case 0:
					goto IL_006e;
				case 2:
					{
						while (true)
						{
							IL_007d:
							c = value;
							int num = -877010625;
							while (true)
							{
								switch (num ^ -877010626)
								{
								case 3:
									num = -877010632;
									continue;
								case 1:
									return;
								case 2:
									break;
								case 4:
									goto IL_005f;
								case 6:
									goto IL_006e;
								case 0:
									goto IL_007d;
								default:
									goto end_IL_0003;
								}
								break;
							}
							break;
						}
						goto case 1;
					}
					IL_006e:
					a = value;
					return;
					IL_005f:
					d = value;
					return;
					end_IL_0003:
					break;
				}
				throw new ArgumentOutOfRangeException("index");
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
			while (true)
			{
				int num = -1947491048;
				while (true)
				{
					switch (num ^ -1947491047)
					{
					case 0:
						break;
					case 1:
						if (float4x.a == a)
						{
							goto IL_003e;
						}
						goto IL_0073;
					default:
						{
							if (float4x.b == b && float4x.c == c)
							{
								return float4x.d == d;
							}
							goto IL_0073;
						}
						IL_0073:
						return false;
					}
					break;
					IL_003e:
					num = -1947491045;
				}
			}
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
			object[] array = new object[7] { a, ", ", b, null, null, null, null };
			while (true)
			{
				int num = 2128389422;
				while (true)
				{
					switch (num ^ 0x7EDCA52F)
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
					num = 2128389421;
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
					int num = 916159720;
					while (true)
					{
						switch (num ^ 0x369B7CEA)
						{
						case 0:
							break;
						case 2:
							_additionDelegate = Add;
							num = 916159723;
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
