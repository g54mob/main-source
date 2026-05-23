using System;
using UnityEngine;

namespace Rewired.Utils.Classes.Data
{
	[Serializable]
	public struct Float2x : IEquatable<Float2x>
	{
		public const int Length = 2;

		public float a;

		public float b;

		private static Func<Float2x, Float2x, Float2x> _additionDelegate;

		private static Func<Float2x, Float2x, Float2x> _subtractionDelegate;

		private static Func<Float2x, Float2x, Float2x> _multiplicationDelegate;

		private static Func<Float2x, Float2x, Float2x> _divisionDelegate;

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
				default:
					throw new ArgumentOutOfRangeException("index");
				}
			}
			set
			{
				while (true)
				{
					int num = -123880043;
					while (true)
					{
						switch (num ^ -123880047)
						{
						case 3:
							break;
						case 4:
							switch (index)
							{
							case 0:
								goto IL_003d;
							case 1:
								goto IL_004c;
							}
							goto IL_0036;
						case 1:
							goto IL_003d;
						case 0:
							goto IL_004c;
						default:
							{
								throw new ArgumentOutOfRangeException("index");
							}
							IL_004c:
							b = value;
							return;
							IL_003d:
							a = value;
							return;
						}
						break;
						IL_0036:
						num = -123880045;
					}
				}
			}
		}

		public static Float2x Zero
		{
			get
			{
				return default(Float2x);
			}
		}

		public Float2x(float a, float b)
		{
			this.a = a;
			this.b = b;
		}

		public Float2x Clone()
		{
			return new Float2x(a, b);
		}

		public static Float2x Clone(Float2x obj)
		{
			return obj.Clone();
		}

		public override bool Equals(object obj)
		{
			if (!(obj is Float2x))
			{
				return false;
			}
			Float2x float2x = (Float2x)obj;
			if (float2x.a == a)
			{
				return float2x.b == b;
			}
			return false;
		}

		public override int GetHashCode()
		{
			int num = 17;
			num = num * 29 + a.GetHashCode();
			return num * 29 + b.GetHashCode();
		}

		public bool Equals(Float2x other)
		{
			if (a == other.a)
			{
				return b == other.b;
			}
			return false;
		}

		public override string ToString()
		{
			return a + ", " + b;
		}

		public static Float2x Add(Float2x value1, Float2x value2)
		{
			return value1 + value2;
		}

		public static Float2x Subtract(Float2x value1, Float2x value2)
		{
			return value1 - value2;
		}

		public static Float2x Multiply(Float2x value1, Float2x value2)
		{
			return value1 * value2;
		}

		public static Float2x Divide(Float2x value1, Float2x value2)
		{
			return value1 / value2;
		}

		public static Func<Float2x, Float2x, Float2x> GetAdditionDelegate()
		{
			if (_additionDelegate == null)
			{
				_additionDelegate = Add;
			}
			return _additionDelegate;
		}

		public static Func<Float2x, Float2x, Float2x> GetSubtractionDelegate()
		{
			if (_subtractionDelegate == null)
			{
				while (true)
				{
					int num = -905668021;
					while (true)
					{
						switch (num ^ -905668022)
						{
						case 2:
							break;
						case 1:
							_subtractionDelegate = Subtract;
							num = -905668022;
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

		public static Func<Float2x, Float2x, Float2x> GetMultiplicationDelegate()
		{
			if (_multiplicationDelegate == null)
			{
				while (true)
				{
					int num = 1821159753;
					while (true)
					{
						switch (num ^ 0x6C8CB14B)
						{
						case 0:
							break;
						case 2:
							_multiplicationDelegate = Multiply;
							num = 1821159754;
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
			return _multiplicationDelegate;
		}

		public static Func<Float2x, Float2x, Float2x> GetDivisionDelegate()
		{
			if (_divisionDelegate == null)
			{
				_divisionDelegate = Multiply;
			}
			return _divisionDelegate;
		}

		public static implicit operator Float2x(Vector2 obj)
		{
			return new Float2x(obj.x, obj.y);
		}

		public static implicit operator Vector2(Float2x obj)
		{
			return new Vector2(obj.a, obj.b);
		}

		public static Float2x operator +(Float2x value1, Float2x value2)
		{
			return new Float2x(value1.a + value2.a, value1.b + value2.b);
		}

		public static Float2x operator -(Float2x value1, Float2x value2)
		{
			return new Float2x(value1.a - value2.a, value1.b - value2.b);
		}

		public static Float2x operator *(Float2x value1, Float2x value2)
		{
			return new Float2x(value1.a * value2.a, value1.b * value2.b);
		}

		public static Float2x operator /(Float2x value1, Float2x value2)
		{
			return new Float2x(value1.a / value2.a, value1.b / value2.b);
		}

		public static Float2x operator +(Float2x value1, float value2)
		{
			return new Float2x(value1.a + value2, value1.b + value2);
		}

		public static Float2x operator -(Float2x value1, float value2)
		{
			return new Float2x(value1.a - value2, value1.b - value2);
		}

		public static Float2x operator *(Float2x value1, float value2)
		{
			return new Float2x(value1.a * value2, value1.b * value2);
		}

		public static Float2x operator /(Float2x value1, float value2)
		{
			return new Float2x(value1.a / value2, value1.b / value2);
		}
	}
}
