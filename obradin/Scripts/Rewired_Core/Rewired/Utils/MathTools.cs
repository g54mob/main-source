using System;
using UnityEngine;

namespace Rewired.Utils
{
	public class MathTools
	{
		private const float QHQNDkhlIcAEAeNLMekpdzUFVFG = 1E-10f;

		private const double jIiiNDoSjusGWBovhemihObfNVQ = 1E-10;

		private const float KiANNHCBDoDRmCoLQcLOyCRkdmSH = 0.0001f;

		public const float PI = (float)Math.PI;

		public const float Infinity = float.PositiveInfinity;

		public const float NegativeInfinity = float.NegativeInfinity;

		public const float Deg2Rad = (float)Math.PI / 180f;

		public const float Rad2Deg = 57.29578f;

		public const float Epsilon = float.Epsilon;

		public static sbyte Abs(sbyte value)
		{
			if (value >= 0)
			{
				return value;
			}
			if (value == sbyte.MinValue)
			{
				while (true)
				{
					switch (-139547036 ^ -139547035)
					{
					case 0:
						continue;
					case 1:
						throw new OverflowException("Cannot compute absolute value of sbyte.MinValue");
					}
					break;
				}
			}
			return (sbyte)(-value);
		}

		public static short Abs(short value)
		{
			if (value >= 0)
			{
				return value;
			}
			if (value == short.MinValue)
			{
				throw new OverflowException("Cannot compute absolute value of short.MinValue");
			}
			return (short)(-value);
		}

		public static int Abs(int value)
		{
			if (value >= 0)
			{
				return value;
			}
			if (value == int.MinValue)
			{
				throw new OverflowException("Cannot compute absolute value of int.MinValue");
			}
			return -value;
		}

		public static long Abs(long value)
		{
			if (value >= 0)
			{
				return value;
			}
			if (value == long.MinValue)
			{
				throw new OverflowException("Cannot compute absolute value of long.MinValue");
			}
			return -value;
		}

		public static float Abs(float value)
		{
			if (value >= 0f)
			{
				return value;
			}
			if (value == float.NaN)
			{
				while (true)
				{
					switch (-1661374695 ^ -1661374693)
					{
					case 0:
						continue;
					case 2:
						throw new OverflowException("Cannot compute absolute value of float.NaN");
					}
					break;
				}
			}
			return 0f - value;
		}

		public static double Abs(double value)
		{
			if (value >= 0.0)
			{
				return value;
			}
			if (value == double.NaN)
			{
				throw new OverflowException("Cannot compute absolute value of double.NaN");
			}
			return 0.0 - value;
		}

		public static bool Approximately(float a, float b)
		{
			if (a == b)
			{
				return true;
			}
			float num = b - a;
			if (num < 0f)
			{
				num = 0f - num;
				goto IL_0015;
			}
			goto IL_003b;
			IL_003b:
			int num2;
			if (a < 0f)
			{
				a = 0f - a;
				num2 = -1109947840;
				goto IL_001a;
			}
			goto IL_004e;
			IL_004e:
			int num3;
			if (b >= 0f)
			{
				num2 = -1109947836;
				num3 = num2;
			}
			else
			{
				num2 = -1109947839;
				num3 = num2;
			}
			goto IL_001a;
			IL_0015:
			num2 = -1109947837;
			goto IL_001a;
			IL_001a:
			while (true)
			{
				switch (num2 ^ -1109947840)
				{
				case 2:
					break;
				case 3:
					goto IL_003b;
				case 0:
					goto IL_004e;
				case 1:
					b = 0f - b;
					num2 = -1109947836;
					continue;
				default:
				{
					float num4 = ((a > b) ? a : b) * 1E-06f;
					return num < ((num4 > 1.1E-44f) ? num4 : 1.1E-44f);
				}
				}
				break;
			}
			goto IL_0015;
		}

		public static bool ApproximatelyZero(float a)
		{
			if (a == 0f)
			{
				return true;
			}
			float num = ((a < 0f) ? (0f - a) : a);
			float num2 = num * 1E-06f;
			return num < ((num2 > 1.1E-44f) ? num2 : 1.1E-44f);
		}

		public static bool IsZero(float value)
		{
			if (value < 0f)
			{
				value = 0f - value;
			}
			return value < 1E-10f;
		}

		public static bool IsZero(float value, float threshold)
		{
			if (threshold < 0f)
			{
				threshold = 0f - threshold;
				goto IL_000c;
			}
			goto IL_002a;
			IL_003d:
			return value < threshold;
			IL_000c:
			int num = -1131258287;
			goto IL_0011;
			IL_0011:
			switch (num ^ -1131258288)
			{
			case 0:
				break;
			case 1:
				goto IL_002a;
			default:
				goto IL_003d;
			}
			goto IL_000c;
			IL_002a:
			if (value < 0f)
			{
				value = 0f - value;
				num = -1131258286;
				goto IL_0011;
			}
			goto IL_003d;
		}

		public static bool IsZero(double value)
		{
			if (value < 0.0)
			{
				while (true)
				{
					int num = -674355466;
					while (true)
					{
						switch (num ^ -674355465)
						{
						case 0:
							break;
						case 1:
							value = 0.0 - value;
							num = -674355467;
							continue;
						default:
							goto end_IL_000c;
						}
						break;
					}
					continue;
					end_IL_000c:
					break;
				}
			}
			return value < 1E-10;
		}

		public static bool IsZero(double value, double threshold)
		{
			if (threshold < 0.0)
			{
				threshold = 0.0 - threshold;
				goto IL_0010;
			}
			goto IL_002e;
			IL_0045:
			return value < threshold;
			IL_0010:
			int num = 164170853;
			goto IL_0015;
			IL_0015:
			switch (num ^ 0x9C90C64)
			{
			case 0:
				break;
			case 1:
				goto IL_002e;
			default:
				goto IL_0045;
			}
			goto IL_0010;
			IL_002e:
			if (value < 0.0)
			{
				value = 0.0 - value;
				num = 164170854;
				goto IL_0015;
			}
			goto IL_0045;
		}

		public static bool IsExactlyEqual(float a, float b)
		{
			if (a >= b - float.Epsilon && a <= b + float.Epsilon)
			{
				return true;
			}
			return false;
		}

		public static bool IsExactlyEqual(double a, double b)
		{
			if (a >= b - double.Epsilon && a <= b + double.Epsilon)
			{
				return true;
			}
			return false;
		}

		public static bool IsNear(float value, float targetValue)
		{
			float num = value - targetValue;
			if (!(num < 0f))
			{
				return num <= 0.0001f;
			}
			return 0f - num <= 0.0001f;
		}

		public static bool IsNear(float value, float targetValue, float threshold)
		{
			if (threshold < 0f)
			{
				threshold = 0f - threshold;
			}
			float num = value - targetValue;
			if (!(num < 0f))
			{
				return num <= threshold;
			}
			return 0f - num <= threshold;
		}

		public static bool IsNearZero(float value)
		{
			if (!(value < 0f))
			{
				return value <= 0.0001f;
			}
			return 0f - value <= 0.0001f;
		}

		public static bool IsNearZero(float value, float threshold)
		{
			if (threshold < 0f)
			{
				goto IL_0008;
			}
			goto IL_0035;
			IL_0008:
			int num = 1283091260;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ 0x4C7A6B3D)
				{
				case 2:
					break;
				case 1:
					threshold = 0f - threshold;
					num = 1283091261;
					continue;
				case 0:
					goto IL_0035;
				default:
					return value <= threshold;
				}
				break;
			}
			goto IL_0008;
			IL_0035:
			if (!(value < 0f))
			{
				num = 1283091262;
				goto IL_000d;
			}
			return 0f - value <= threshold;
		}

		public static bool IsNearOrWholeNumber(float value)
		{
			float num = ((value < 0f) ? (0f - value) : value);
			if (Ceil(num) - num <= 0.0001f)
			{
				return true;
			}
			return false;
		}

		public static bool IsNearOrWholeNumber(float value, float threshold)
		{
			if (threshold < 0f)
			{
				threshold = 0f - threshold;
			}
			float num = ((value < 0f) ? (0f - value) : value);
			if (Ceil(num) - num <= threshold)
			{
				return true;
			}
			return false;
		}

		public static bool IsNearOrWholeNumber(float value, out int number)
		{
			float num = ((!(value < 0f)) ? value : (value *= -1f));
			int num3 = default(int);
			float num4 = default(float);
			while (true)
			{
				int num2 = 617299593;
				while (true)
				{
					switch (num2 ^ 0x24CB3E88)
					{
					case 3:
						break;
					case 1:
					{
						num3 = RoundToInt(num);
						num4 = num - (float)num3;
						int num5;
						if (num4 >= 0f)
						{
							num2 = 617299594;
							num5 = num2;
						}
						else
						{
							num2 = 617299592;
							num5 = num2;
						}
						continue;
					}
					case 0:
						num4 *= -1f;
						num2 = 617299594;
						continue;
					default:
						number = ((value < 0f) ? (num3 * -1) : num3);
						if (num4 <= 0.0001f)
						{
							return true;
						}
						return false;
					}
					break;
				}
			}
		}

		public static bool IsNearOrWholeNumber(float value, out int number, float threshold)
		{
			if (threshold < 0f)
			{
				threshold = 0f - threshold;
				goto IL_000c;
			}
			goto IL_0036;
			IL_0097:
			float num = default(float);
			if (num <= threshold)
			{
				return true;
			}
			return false;
			IL_000c:
			int num2 = -1337692723;
			goto IL_0011;
			IL_0011:
			int num3 = default(int);
			while (true)
			{
				switch (num2 ^ -1337692724)
				{
				case 5:
					break;
				case 1:
					goto IL_0036;
				case 4:
					goto IL_0045;
				case 0:
					if (num < 0f)
					{
						num *= -1f;
						num2 = -1337692721;
						continue;
					}
					goto case 3;
				case 3:
					number = ((value < 0f) ? (num3 * -1) : num3);
					num2 = -1337692722;
					continue;
				default:
					goto IL_0097;
				}
				break;
			}
			goto IL_000c;
			IL_0045:
			float num4 = value;
			goto IL_0052;
			IL_0052:
			float num5 = num4;
			num3 = RoundToInt(num5);
			num = num5 - (float)num3;
			num2 = -1337692724;
			goto IL_0011;
			IL_0036:
			if (!(value < 0f))
			{
				num2 = -1337692728;
				goto IL_0011;
			}
			num4 = (value *= -1f);
			goto IL_0052;
		}

		public static float RoundOffIfNearWholeNumber(float value)
		{
			if (IsNearOrWholeNumber(value))
			{
				return Round(value);
			}
			return value;
		}

		public static float RoundOffIfNearWholeNumber(float value, float threshold)
		{
			if (threshold < 0f)
			{
				while (true)
				{
					int num = -1967836321;
					while (true)
					{
						switch (num ^ -1967836322)
						{
						case 0:
							break;
						case 1:
							threshold = 0f - threshold;
							num = -1967836324;
							continue;
						default:
							goto end_IL_0008;
						}
						break;
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			if (IsNearOrWholeNumber(value, threshold))
			{
				return Round(value);
			}
			return value;
		}

		public static bool IsEven(int value)
		{
			if (value % 2 == 0)
			{
				return true;
			}
			return false;
		}

		public static float ValueInNewRange(float oldValue, float oldMin, float oldMax, float newMin, float newMax)
		{
			if (!(oldValue < oldMin))
			{
				goto IL_0033;
			}
			oldValue = oldMin;
			goto IL_0060;
			IL_000e:
			int num;
			float result = default(float);
			float num3 = default(float);
			while (true)
			{
				switch (num ^ -665198531)
				{
				case 2:
					num = -665198532;
					continue;
				case 1:
					break;
				case 0:
				{
					float num2 = newMax - newMin;
					result = (oldValue - oldMin) * num2 / num3 + newMin;
					num = -665198535;
					continue;
				}
				case 3:
					result = newMin;
					num = -665198535;
					continue;
				case 5:
					goto IL_0060;
				default:
					return result;
				}
				break;
			}
			goto IL_0033;
			IL_0060:
			num3 = oldMax - oldMin;
			int num4;
			if (!Approximately(num3, 0f))
			{
				num = -665198531;
				num4 = num;
			}
			else
			{
				num = -665198530;
				num4 = num;
			}
			goto IL_000e;
			IL_0033:
			if (oldValue > oldMax)
			{
				oldValue = oldMax;
				num = -665198536;
				goto IL_000e;
			}
			goto IL_0060;
		}

		public static int ValueInNewRange(int oldValue, int oldMin, int oldMax, int newMin, int newMax)
		{
			if (oldValue < oldMin)
			{
				oldValue = oldMin;
				goto IL_0007;
			}
			goto IL_0056;
			IL_0056:
			int num;
			if (oldValue > oldMax)
			{
				oldValue = oldMax;
				num = -418943746;
				goto IL_000c;
			}
			goto IL_0064;
			IL_0007:
			num = -418943749;
			goto IL_000c;
			IL_000c:
			int result = default(int);
			int num2 = default(int);
			int num3 = default(int);
			while (true)
			{
				switch (num ^ -418943745)
				{
				case 2:
					break;
				case 0:
					result = (oldValue - oldMin) * num2 / num3 + newMin;
					num = -418943750;
					continue;
				case 7:
					num2 = newMax - newMin;
					num = -418943745;
					continue;
				case 6:
					goto IL_0056;
				case 1:
					goto IL_0064;
				case 3:
					result = newMin;
					num = -418943750;
					continue;
				case 4:
					num = -418943746;
					continue;
				default:
					return result;
				}
				break;
			}
			goto IL_0007;
			IL_0064:
			num3 = oldMax - oldMin;
			int num4;
			if (num3 == 0)
			{
				num = -418943748;
				num4 = num;
			}
			else
			{
				num = -418943752;
				num4 = num;
			}
			goto IL_000c;
		}

		public static sbyte Max(sbyte a, sbyte b)
		{
			if (a < b)
			{
				return b;
			}
			return a;
		}

		public static byte Max(byte a, byte b)
		{
			if (a < b)
			{
				return b;
			}
			return a;
		}

		public static short Max(short a, short b)
		{
			if (a < b)
			{
				return b;
			}
			return a;
		}

		public static ushort Max(ushort a, ushort b)
		{
			if (a < b)
			{
				return b;
			}
			return a;
		}

		public static int Max(int a, int b)
		{
			if (a < b)
			{
				return b;
			}
			return a;
		}

		public static uint Max(uint a, uint b)
		{
			if (a < b)
			{
				return b;
			}
			return a;
		}

		public static long Max(long a, long b)
		{
			if (a < b)
			{
				return b;
			}
			return a;
		}

		public static ulong Max(ulong a, ulong b)
		{
			if (a < b)
			{
				return b;
			}
			return a;
		}

		public static float Max(float a, float b)
		{
			if (!(a >= b))
			{
				return b;
			}
			return a;
		}

		public static double Max(double a, double b)
		{
			if (!(a >= b))
			{
				return b;
			}
			return a;
		}

		public static sbyte Min(sbyte a, sbyte b)
		{
			if (a > b)
			{
				return b;
			}
			return a;
		}

		public static byte Min(byte a, byte b)
		{
			if (a > b)
			{
				return b;
			}
			return a;
		}

		public static short Min(short a, short b)
		{
			if (a > b)
			{
				return b;
			}
			return a;
		}

		public static ushort Min(ushort a, ushort b)
		{
			if (a > b)
			{
				return b;
			}
			return a;
		}

		public static int Min(int a, int b)
		{
			if (a > b)
			{
				return b;
			}
			return a;
		}

		public static uint Min(uint a, uint b)
		{
			if (a > b)
			{
				return b;
			}
			return a;
		}

		public static long Min(long a, long b)
		{
			if (a > b)
			{
				return b;
			}
			return a;
		}

		public static ulong Min(ulong a, ulong b)
		{
			if (a > b)
			{
				return b;
			}
			return a;
		}

		public static float Min(float a, float b)
		{
			if (!(a <= b))
			{
				return b;
			}
			return a;
		}

		public static double Min(double a, double b)
		{
			if (!(a <= b))
			{
				return b;
			}
			return a;
		}

		public static sbyte MaxMagnitude(sbyte a, sbyte b)
		{
			sbyte b2 = ((a < 0) ? ((sbyte)(-a)) : a);
			sbyte b3 = ((b < 0) ? ((sbyte)(-b)) : b);
			if (b2 < b3)
			{
				return b;
			}
			return a;
		}

		public static byte MaxMagnitude(byte a, byte b)
		{
			if (a < b)
			{
				return b;
			}
			return a;
		}

		public static short MaxMagnitude(short a, short b)
		{
			if (a >= 0)
			{
				goto IL_0004;
			}
			int num = (short)(-a);
			goto IL_0030;
			IL_0051:
			short num2 = default(short);
			short num3 = default(short);
			if (num2 < num3)
			{
				return b;
			}
			return a;
			IL_0004:
			int num4 = 1725643337;
			goto IL_0009;
			IL_0009:
			while (true)
			{
				int num5;
				switch (num4 ^ 0x66DB3A4A)
				{
				case 0:
					break;
				case 3:
					goto IL_002a;
				case 1:
					if (b >= 0)
					{
						num4 = 1725643336;
						continue;
					}
					num5 = (short)(-b);
					goto IL_0049;
				case 2:
					num5 = b;
					goto IL_0049;
				default:
					goto IL_0051;
					IL_0049:
					num3 = (short)num5;
					num4 = 1725643342;
					continue;
				}
				break;
			}
			goto IL_0004;
			IL_002a:
			num = a;
			goto IL_0030;
			IL_0030:
			num2 = (short)num;
			num4 = 1725643339;
			goto IL_0009;
		}

		public static ushort MaxMagnitude(ushort a, ushort b)
		{
			if (a < b)
			{
				return b;
			}
			return a;
		}

		public static int MaxMagnitude(int a, int b)
		{
			if (a >= 0)
			{
				goto IL_0004;
			}
			int num = -a;
			goto IL_0027;
			IL_0039:
			int num2 = default(int);
			int num3 = default(int);
			if (num2 < num3)
			{
				return b;
			}
			return a;
			IL_0004:
			int num4 = 2113530710;
			goto IL_0009;
			IL_0009:
			switch (num4 ^ 0x7DF9EB54)
			{
			case 0:
				break;
			case 2:
				goto IL_0022;
			default:
				goto IL_0039;
			}
			goto IL_0004;
			IL_0022:
			num = a;
			goto IL_0027;
			IL_0027:
			num2 = num;
			num3 = ((b < 0) ? (-b) : b);
			num4 = 2113530709;
			goto IL_0009;
		}

		public static uint MaxMagnitude(uint a, uint b)
		{
			if (a < b)
			{
				return b;
			}
			return a;
		}

		public static long MaxMagnitude(long a, long b)
		{
			long num = ((a < 0) ? (-a) : a);
			while (true)
			{
				int num2 = 452492609;
				while (true)
				{
					long num3;
					long num4;
					switch (num2 ^ 0x1AF87D40)
					{
					case 2:
						break;
					case 1:
						if (b >= 0)
						{
							goto IL_002e;
						}
						num3 = -b;
						goto IL_003a;
					default:
						{
							num3 = b;
							goto IL_003a;
						}
						IL_003a:
						num4 = num3;
						if (num < num4)
						{
							return b;
						}
						return a;
					}
					break;
					IL_002e:
					num2 = 452492608;
				}
			}
		}

		public static ulong MaxMagnitude(ulong a, ulong b)
		{
			if (a < b)
			{
				return b;
			}
			return a;
		}

		public static float MaxMagnitude(float a, float b)
		{
			float num = ((a < 0f) ? (0f - a) : a);
			float num2 = ((b < 0f) ? (0f - b) : b);
			if (!(num >= num2))
			{
				return b;
			}
			return a;
		}

		public static double MaxMagnitude(double a, double b)
		{
			double num = ((a < 0.0) ? (0.0 - a) : a);
			double num3 = default(double);
			while (true)
			{
				int num2 = -1172538706;
				while (true)
				{
					switch (num2 ^ -1172538705)
					{
					case 3:
						break;
					case 1:
						num3 = ((b < 0.0) ? (0.0 - b) : b);
						num2 = -1172538705;
						continue;
					case 0:
						if (!(num >= num3))
						{
							num2 = -1172538707;
							continue;
						}
						return a;
					default:
						return b;
					}
					break;
				}
			}
		}

		public static sbyte MinMagnitude(sbyte a, sbyte b)
		{
			if (a >= 0)
			{
				goto IL_0004;
			}
			int num = (sbyte)(-a);
			goto IL_0030;
			IL_004d:
			int num2;
			sbyte b2 = (sbyte)num2;
			int num3 = -1276767285;
			goto IL_0009;
			IL_0004:
			num3 = -1276767286;
			goto IL_0009;
			IL_0009:
			sbyte b3 = default(sbyte);
			while (true)
			{
				switch (num3 ^ -1276767288)
				{
				case 4:
					break;
				case 2:
					goto IL_002a;
				case 3:
					goto IL_003c;
				case 1:
					goto IL_0047;
				default:
					return b;
				}
				break;
				IL_003c:
				if (b3 > b2)
				{
					num3 = -1276767288;
					continue;
				}
				return a;
			}
			goto IL_0004;
			IL_0047:
			num2 = b;
			goto IL_004d;
			IL_002a:
			num = a;
			goto IL_0030;
			IL_0030:
			b3 = (sbyte)num;
			if (b >= 0)
			{
				num3 = -1276767287;
				goto IL_0009;
			}
			num2 = (sbyte)(-b);
			goto IL_004d;
		}

		public static byte MinMagnitude(byte a, byte b)
		{
			if (a > b)
			{
				return b;
			}
			return a;
		}

		public static short MinMagnitude(short a, short b)
		{
			short num = ((a < 0) ? ((short)(-a)) : a);
			short num3 = default(short);
			while (true)
			{
				int num2 = -182705681;
				while (true)
				{
					short num4;
					switch (num2 ^ -182705682)
					{
					case 0:
						break;
					case 1:
						num4 = ((b < 0) ? ((short)(-b)) : b);
						goto IL_0033;
					default:
						if (num > num3)
						{
							return b;
						}
						return a;
					}
					break;
					IL_0033:
					num3 = num4;
					num2 = -182705684;
				}
			}
		}

		public static ushort MinMagnitude(ushort a, ushort b)
		{
			if (a > b)
			{
				return b;
			}
			return a;
		}

		public static int MinMagnitude(int a, int b)
		{
			int num = ((a < 0) ? (-a) : a);
			int num2 = ((b < 0) ? (-b) : b);
			if (num > num2)
			{
				return b;
			}
			return a;
		}

		public static uint MinMagnitude(uint a, uint b)
		{
			if (a > b)
			{
				return b;
			}
			return a;
		}

		public static long MinMagnitude(long a, long b)
		{
			if (a >= 0)
			{
				goto IL_0005;
			}
			long num = -a;
			goto IL_002c;
			IL_003e:
			long num3;
			long num2 = num3;
			long num4 = default(long);
			int num5;
			if (num4 > num2)
			{
				num5 = -2033899443;
				goto IL_000a;
			}
			return a;
			IL_0005:
			num5 = -2033899441;
			goto IL_000a;
			IL_000a:
			switch (num5 ^ -2033899442)
			{
			case 2:
				break;
			case 1:
				goto IL_0027;
			case 0:
				goto IL_0039;
			default:
				return b;
			}
			goto IL_0005;
			IL_0039:
			num3 = b;
			goto IL_003e;
			IL_0027:
			num = a;
			goto IL_002c;
			IL_002c:
			num4 = num;
			if (b >= 0)
			{
				num5 = -2033899442;
				goto IL_000a;
			}
			num3 = -b;
			goto IL_003e;
		}

		public static ulong MinMagnitude(ulong a, ulong b)
		{
			if (a > b)
			{
				return b;
			}
			return a;
		}

		public static float MinMagnitude(float a, float b)
		{
			float num = ((a < 0f) ? (0f - a) : a);
			float num2 = ((b < 0f) ? (0f - b) : b);
			if (!(num <= num2))
			{
				return b;
			}
			return a;
		}

		public static double MinMagnitude(double a, double b)
		{
			double num = ((a < 0.0) ? (0.0 - a) : a);
			double num2 = ((b < 0.0) ? (0.0 - b) : b);
			if (!(num <= num2))
			{
				return b;
			}
			return a;
		}

		public static bool IsMoreMagnitudeOrEqual(sbyte a, sbyte b)
		{
			if (a < 0)
			{
				a = (sbyte)(-a);
				goto IL_0009;
			}
			goto IL_0027;
			IL_0037:
			if (a >= b)
			{
				return true;
			}
			return false;
			IL_0009:
			int num = -1652999895;
			goto IL_000e;
			IL_000e:
			switch (num ^ -1652999893)
			{
			case 0:
				break;
			case 2:
				goto IL_0027;
			default:
				goto IL_0037;
			}
			goto IL_0009;
			IL_0027:
			if (b < 0)
			{
				b = (sbyte)(-b);
				num = -1652999894;
				goto IL_000e;
			}
			goto IL_0037;
		}

		public static bool IsMoreMagnitudeOrEqual(byte a, byte b)
		{
			if (a >= b)
			{
				return true;
			}
			return false;
		}

		public static bool IsMoreMagnitudeOrEqual(short a, short b)
		{
			if (a < 0)
			{
				a = (short)(-a);
				goto IL_0009;
			}
			goto IL_0027;
			IL_0037:
			if (a >= b)
			{
				return true;
			}
			return false;
			IL_0009:
			int num = 1847208693;
			goto IL_000e;
			IL_000e:
			switch (num ^ 0x6E1A2AF4)
			{
			case 2:
				break;
			case 1:
				goto IL_0027;
			default:
				goto IL_0037;
			}
			goto IL_0009;
			IL_0027:
			if (b < 0)
			{
				b = (short)(-b);
				num = 1847208692;
				goto IL_000e;
			}
			goto IL_0037;
		}

		public static bool IsMoreMagnitudeOrEqual(ushort a, ushort b)
		{
			if (a >= b)
			{
				return true;
			}
			return false;
		}

		public static bool IsMoreMagnitudeOrEqual(int a, int b)
		{
			if (a < 0)
			{
				goto IL_0004;
			}
			goto IL_0035;
			IL_0004:
			int num = -311624266;
			goto IL_0009;
			IL_0009:
			while (true)
			{
				switch (num ^ -311624268)
				{
				case 0:
					break;
				case 4:
					b = -b;
					num = -311624267;
					continue;
				case 3:
					goto IL_0035;
				case 2:
					a = -a;
					num = -311624265;
					continue;
				default:
					goto IL_0055;
				}
				break;
			}
			goto IL_0004;
			IL_0055:
			if (a >= b)
			{
				return true;
			}
			return false;
			IL_0035:
			int num2;
			if (b < 0)
			{
				num = -311624272;
				num2 = num;
			}
			else
			{
				num = -311624267;
				num2 = num;
			}
			goto IL_0009;
		}

		public static bool IsMoreMagnitudeOrEqual(uint a, uint b)
		{
			if (a >= b)
			{
				return true;
			}
			return false;
		}

		public static bool IsMoreMagnitudeOrEqual(long a, long b)
		{
			if (a < 0)
			{
				a = -a;
				goto IL_0009;
			}
			goto IL_002f;
			IL_002f:
			int num;
			int num2;
			if (b >= 0)
			{
				num = -794510755;
				num2 = num;
			}
			else
			{
				num = -794510756;
				num2 = num;
			}
			goto IL_000e;
			IL_0009:
			num = -794510753;
			goto IL_000e;
			IL_000e:
			while (true)
			{
				switch (num ^ -794510755)
				{
				case 4:
					break;
				case 2:
					goto IL_002f;
				case 0:
					goto IL_0045;
				case 1:
					b = -b;
					num = -794510755;
					continue;
				default:
					return true;
				}
				break;
				IL_0045:
				if (a >= b)
				{
					num = -794510754;
					continue;
				}
				return false;
			}
			goto IL_0009;
		}

		public static bool IsMoreMagnitudeOrEqual(ulong a, ulong b)
		{
			if (a >= b)
			{
				return true;
			}
			return false;
		}

		public static bool IsMoreMagnitudeOrEqual(float a, float b)
		{
			if (a < 0f)
			{
				a = 0f - a;
				goto IL_000c;
			}
			goto IL_002a;
			IL_003d:
			if (a >= b)
			{
				return true;
			}
			return false;
			IL_000c:
			int num = 88101851;
			goto IL_0011;
			IL_0011:
			switch (num ^ 0x54053DA)
			{
			case 2:
				break;
			case 1:
				goto IL_002a;
			default:
				goto IL_003d;
			}
			goto IL_000c;
			IL_002a:
			if (b < 0f)
			{
				b = 0f - b;
				num = 88101850;
				goto IL_0011;
			}
			goto IL_003d;
		}

		public static bool IsMoreMagnitudeOrEqual(double a, double b)
		{
			if (a < 0.0)
			{
				a = 0.0 - a;
				goto IL_0010;
			}
			goto IL_0032;
			IL_0032:
			int num;
			int num2;
			if (b >= 0.0)
			{
				num = -877691877;
				num2 = num;
			}
			else
			{
				num = -877691880;
				num2 = num;
			}
			goto IL_0015;
			IL_0010:
			num = -877691879;
			goto IL_0015;
			IL_0015:
			while (true)
			{
				switch (num ^ -877691880)
				{
				case 2:
					break;
				case 1:
					goto IL_0032;
				case 0:
					b = 0.0 - b;
					num = -877691877;
					continue;
				default:
					goto IL_005a;
				}
				break;
			}
			goto IL_0010;
			IL_005a:
			if (a >= b)
			{
				return true;
			}
			return false;
		}

		public static bool IsLessMagnitudeOrEqual(sbyte a, sbyte b)
		{
			if (a < 0)
			{
				goto IL_0004;
			}
			goto IL_0051;
			IL_0004:
			int num = 873594520;
			goto IL_0009;
			IL_0009:
			while (true)
			{
				switch (num ^ 0x3411FE99)
				{
				case 5:
					break;
				case 0:
					b = (sbyte)(-b);
					num = 873594522;
					continue;
				case 3:
					goto IL_003a;
				case 1:
					a = (sbyte)(-a);
					num = 873594523;
					continue;
				case 2:
					goto IL_0051;
				default:
					return true;
				}
				break;
				IL_003a:
				if (a <= b)
				{
					num = 873594525;
					continue;
				}
				return false;
			}
			goto IL_0004;
			IL_0051:
			int num2;
			if (b < 0)
			{
				num = 873594521;
				num2 = num;
			}
			else
			{
				num = 873594522;
				num2 = num;
			}
			goto IL_0009;
		}

		public static bool IsLessMagnitudeOrEqual(byte a, byte b)
		{
			if (a <= b)
			{
				return true;
			}
			return false;
		}

		public static bool IsLessMagnitudeOrEqual(short a, short b)
		{
			if (a < 0)
			{
				a = (short)(-a);
				goto IL_0009;
			}
			goto IL_002b;
			IL_004c:
			if (a <= b)
			{
				return true;
			}
			return false;
			IL_0009:
			int num = -1715825123;
			goto IL_000e;
			IL_000e:
			while (true)
			{
				switch (num ^ -1715825121)
				{
				case 0:
					break;
				case 2:
					goto IL_002b;
				case 3:
					b = (short)(-b);
					num = -1715825122;
					continue;
				default:
					goto IL_004c;
				}
				break;
			}
			goto IL_0009;
			IL_002b:
			int num2;
			if (b >= 0)
			{
				num = -1715825122;
				num2 = num;
			}
			else
			{
				num = -1715825124;
				num2 = num;
			}
			goto IL_000e;
		}

		public static bool IsLessMagnitudeOrEqual(ushort a, ushort b)
		{
			if (a <= b)
			{
				return true;
			}
			return false;
		}

		public static bool IsLessMagnitudeOrEqual(int a, int b)
		{
			if (a < 0)
			{
				a = -a;
				goto IL_0008;
			}
			goto IL_002a;
			IL_0039:
			int num;
			if (a <= b)
			{
				num = -1255634556;
				goto IL_000d;
			}
			return false;
			IL_0008:
			num = -1255634554;
			goto IL_000d;
			IL_000d:
			switch (num ^ -1255634555)
			{
			case 2:
				break;
			case 3:
				goto IL_002a;
			case 0:
				goto IL_0039;
			default:
				return true;
			}
			goto IL_0008;
			IL_002a:
			if (b < 0)
			{
				b = -b;
				num = -1255634555;
				goto IL_000d;
			}
			goto IL_0039;
		}

		public static bool IsLessMagnitudeOrEqual(uint a, uint b)
		{
			if (a <= b)
			{
				return true;
			}
			return false;
		}

		public static bool IsLessMagnitudeOrEqual(long a, long b)
		{
			if (a < 0)
			{
				a = -a;
				goto IL_0009;
			}
			goto IL_0027;
			IL_0037:
			if (a <= b)
			{
				return true;
			}
			return false;
			IL_0009:
			int num = 330293670;
			goto IL_000e;
			IL_000e:
			switch (num ^ 0x13AFE1A7)
			{
			case 0:
				break;
			case 1:
				goto IL_0027;
			default:
				goto IL_0037;
			}
			goto IL_0009;
			IL_0027:
			if (b < 0)
			{
				b = -b;
				num = 330293669;
				goto IL_000e;
			}
			goto IL_0037;
		}

		public static bool IsLessMagnitudeOrEqual(ulong a, ulong b)
		{
			if (a <= b)
			{
				return true;
			}
			return false;
		}

		public static bool IsLessMagnitudeOrEqual(float a, float b)
		{
			if (a < 0f)
			{
				goto IL_0008;
			}
			goto IL_0035;
			IL_0008:
			int num = -495566446;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ -495566447)
				{
				case 0:
					break;
				case 3:
					a = 0f - a;
					num = -495566445;
					continue;
				case 2:
					goto IL_0035;
				default:
					goto IL_0048;
				}
				break;
			}
			goto IL_0008;
			IL_0035:
			if (b < 0f)
			{
				b = 0f - b;
				num = -495566448;
				goto IL_000d;
			}
			goto IL_0048;
			IL_0048:
			if (a <= b)
			{
				return true;
			}
			return false;
		}

		public static bool IsLessMagnitudeOrEqual(double a, double b)
		{
			if (a < 0.0)
			{
				goto IL_000c;
			}
			goto IL_0039;
			IL_000c:
			int num = 1257262087;
			goto IL_0011;
			IL_0011:
			while (true)
			{
				switch (num ^ 0x4AF04C04)
				{
				case 2:
					break;
				case 3:
					a = 0.0 - a;
					num = 1257262084;
					continue;
				case 0:
					goto IL_0039;
				default:
					goto IL_0050;
				}
				break;
			}
			goto IL_000c;
			IL_0039:
			if (b < 0.0)
			{
				b = 0.0 - b;
				num = 1257262085;
				goto IL_0011;
			}
			goto IL_0050;
			IL_0050:
			if (a <= b)
			{
				return true;
			}
			return false;
		}

		public static byte Clamp(byte value, byte min, byte max)
		{
			if (value >= min)
			{
				goto IL_002e;
			}
			while (true)
			{
				switch (-1823184641 ^ -1823184643)
				{
				case 0:
					break;
				case 2:
					goto end_IL_0004;
				default:
					goto IL_002e;
				}
				continue;
				end_IL_0004:
				break;
			}
			value = min;
			goto IL_0034;
			IL_002e:
			if (value > max)
			{
				return max;
			}
			goto IL_0034;
			IL_0034:
			return value;
		}

		public static sbyte Clamp(sbyte value, sbyte min, sbyte max)
		{
			if (value < min)
			{
				value = min;
			}
			else if (value > max)
			{
				return max;
			}
			return value;
		}

		public static short Clamp(short value, short min, short max)
		{
			if (value < min)
			{
				value = min;
				while (true)
				{
					switch (0x48F47061 ^ 0x48F47060)
					{
					case 2:
						break;
					default:
						goto end_IL_0007;
					case 1:
						goto IL_0034;
					}
					continue;
					end_IL_0007:
					break;
				}
			}
			if (value > max)
			{
				return max;
			}
			goto IL_0034;
			IL_0034:
			return value;
		}

		public static ushort Clamp(ushort value, ushort min, ushort max)
		{
			if (value >= min)
			{
				goto IL_002e;
			}
			while (true)
			{
				switch (0x71C4ABE4 ^ 0x71C4ABE6)
				{
				case 0:
					break;
				case 2:
					goto end_IL_0004;
				default:
					goto IL_002e;
				}
				continue;
				end_IL_0004:
				break;
			}
			value = min;
			goto IL_0034;
			IL_002e:
			if (value > max)
			{
				return max;
			}
			goto IL_0034;
			IL_0034:
			return value;
		}

		public static int Clamp(int value, int min, int max)
		{
			if (value < min)
			{
				value = min;
			}
			else if (value > max)
			{
				return max;
			}
			return value;
		}

		public static uint Clamp(uint value, uint min, uint max)
		{
			if (value < min)
			{
				value = min;
			}
			else if (value > max)
			{
				return max;
			}
			return value;
		}

		public static long Clamp(long value, long min, long max)
		{
			if (value < min)
			{
				value = min;
			}
			else if (value > max)
			{
				return max;
			}
			return value;
		}

		public static ulong Clamp(ulong value, ulong min, ulong max)
		{
			if (value < min)
			{
				while (true)
				{
					int num = -18181672;
					while (true)
					{
						switch (num ^ -18181671)
						{
						case 2:
							break;
						case 1:
							value = min;
							num = -18181670;
							continue;
						default:
							goto end_IL_0004;
						case 3:
							goto IL_003f;
						}
						break;
					}
					continue;
					end_IL_0004:
					break;
				}
			}
			if (value > max)
			{
				return max;
			}
			goto IL_003f;
			IL_003f:
			return value;
		}

		public static float Clamp(float value, float min, float max)
		{
			if (value < min)
			{
				goto IL_0004;
			}
			goto IL_0032;
			IL_0004:
			int num = 1747116423;
			goto IL_0009;
			IL_0009:
			switch (num ^ 0x6822E185)
			{
			case 3:
				break;
			case 2:
				goto IL_0026;
			case 1:
				goto IL_0032;
			default:
				return max;
			}
			goto IL_0004;
			IL_0032:
			if (value > max)
			{
				num = 1747116421;
				goto IL_0009;
			}
			goto IL_003f;
			IL_003f:
			return value;
			IL_0026:
			value = min;
			goto IL_003f;
		}

		public static double Clamp(double value, double min, double max)
		{
			if (value < min)
			{
				while (true)
				{
					int num = 2001256623;
					while (true)
					{
						switch (num ^ 0x7748C0AE)
						{
						case 2:
							break;
						case 1:
							value = min;
							num = 2001256621;
							continue;
						default:
							goto end_IL_0004;
						case 3:
							goto IL_003f;
						}
						break;
					}
					continue;
					end_IL_0004:
					break;
				}
			}
			if (value > max)
			{
				return max;
			}
			goto IL_003f;
			IL_003f:
			return value;
		}

		public static float Clamp01(float value)
		{
			if (value < 0f)
			{
				return 0f;
			}
			if (value > 1f)
			{
				return 1f;
			}
			return value;
		}

		public static float ClampAngle360(float angle)
		{
			float num = Abs(angle);
			float num3 = default(float);
			if (num >= 360f)
			{
				float num2 = num / 360f;
				num3 = Floor(num2);
				num2 -= num3;
				if (num2 == 0f)
				{
					return 0f;
				}
				if (num2 > 0f)
				{
					goto IL_0038;
				}
			}
			goto IL_0075;
			IL_0075:
			int num4;
			if (angle < 0f)
			{
				angle = 360f + angle;
				num4 = 1737091074;
				goto IL_003d;
			}
			goto IL_008d;
			IL_008d:
			return angle;
			IL_0038:
			num4 = 1737091075;
			goto IL_003d;
			IL_003d:
			while (true)
			{
				switch (num4 ^ 0x6789E800)
				{
				case 0:
					break;
				case 3:
				{
					float num5 = num - num3 * 360f;
					angle = num5 * Sign(angle);
					num4 = 1737091073;
					continue;
				}
				case 1:
					goto IL_0075;
				default:
					goto IL_008d;
				}
				break;
			}
			goto IL_0038;
		}

		public static float ReverseAngleRotationDirection(float angle)
		{
			if (angle == 0f)
			{
				return 180f;
			}
			if (angle == 180f)
			{
				return 0f;
			}
			return 360f - angle + 180f;
		}

		public static bool AngleIsNear(float angle, float targetAngle, float threshold)
		{
			if (threshold < 0f)
			{
				threshold = Mathf.Abs(threshold);
			}
			return AngleIsBetween(angle, targetAngle - threshold, targetAngle + threshold);
		}

		public static bool AngleIsBetween(float angle, float min, float max)
		{
			angle = ClampAngle360(angle);
			min = ClampAngle360(min);
			max = ClampAngle360(max);
			if (min < max)
			{
				if (min <= angle)
				{
					return angle <= max;
				}
				return false;
			}
			if (!(min <= angle))
			{
				return angle <= max;
			}
			return true;
		}

		internal static bool ZpuxGINocmlmFwdyKekRJfzImeT(int P_0, int P_1)
		{
			if (P_0 == 0 && P_1 == 0)
			{
				return false;
			}
			return (P_0 & P_1) != 0;
		}

		public static int IntPow(int x, uint pow)
		{
			int num = 1;
			while (true)
			{
				int num2 = 1270859469;
				while (true)
				{
					switch (num2 ^ 0x4BBFC6C9)
					{
					case 3:
						break;
					case 4:
						num2 = 1270859467;
						continue;
					case 1:
						if ((pow & 1) == 1)
						{
							num *= x;
							num2 = 1270859465;
							continue;
						}
						goto case 0;
					case 0:
						x *= x;
						pow >>= 1;
						num2 = 1270859467;
						continue;
					default:
						if (pow == 0)
						{
							return num;
						}
						goto case 1;
					}
					break;
				}
			}
		}

		public static uint RoundUpToPowerOf2(uint value)
		{
			if (value == 0)
			{
				return 1u;
			}
			value--;
			value |= value >> 1;
			value |= value >> 2;
			while (true)
			{
				int num = -831978454;
				while (true)
				{
					switch (num ^ -831978453)
					{
					case 0:
						break;
					case 1:
						goto IL_0036;
					default:
						value |= value >> 16;
						value++;
						return value;
					}
					break;
					IL_0036:
					value |= value >> 4;
					value |= value >> 8;
					num = -831978455;
				}
			}
		}

		public static float BooleanToSign(bool b)
		{
			if (b)
			{
				return 1f;
			}
			return -1f;
		}

		public static bool SignToBoolean(float sign)
		{
			if (sign >= 1f)
			{
				return true;
			}
			return false;
		}

		public static float Sin(float value)
		{
			return (float)Math.Sin(value);
		}

		public static float Cos(float value)
		{
			return (float)Math.Cos(value);
		}

		public static float Tan(float value)
		{
			return (float)Math.Tan(value);
		}

		public static float Asin(float value)
		{
			return (float)Math.Asin(value);
		}

		public static float Acos(float value)
		{
			return (float)Math.Acos(value);
		}

		public static float Atan(float value)
		{
			return (float)Math.Atan(value);
		}

		public static float Atan2(float y, float x)
		{
			return (float)Math.Atan2(y, x);
		}

		public static float Sqrt(float value)
		{
			return (float)Math.Sqrt(value);
		}

		public static float Pow(float value, float p)
		{
			return (float)Math.Pow(value, p);
		}

		public static float Exp(float power)
		{
			return (float)Math.Exp(power);
		}

		public static float Log(float value, float p)
		{
			return (float)Math.Log(value, p);
		}

		public static float Log(float value)
		{
			return (float)Math.Log(value);
		}

		public static float Log10(float value)
		{
			return (float)Math.Log10(value);
		}

		public static float Ceil(float value)
		{
			return (float)Math.Ceiling(value);
		}

		public static float Floor(float value)
		{
			return (float)Math.Floor(value);
		}

		public static float Round(float value)
		{
			return (float)Math.Round(value);
		}

		public static int CeilToInt(float value)
		{
			return (int)Math.Ceiling(value);
		}

		public static int FloorToInt(float value)
		{
			return (int)Math.Floor(value);
		}

		public static int RoundToInt(float value)
		{
			return (int)Math.Round(value);
		}

		public static float Sign(float value)
		{
			if (!(value < 0f))
			{
				return 1f;
			}
			return -1f;
		}

		public static int Sign(int value)
		{
			if (value >= 0)
			{
				return 1;
			}
			return -1;
		}

		public static float Repeat(float t, float length)
		{
			return t - Floor(t / length) * length;
		}

		public static float DeltaAngle(float current, float target)
		{
			float num = Repeat(target - current, 360f);
			if (num > 180f)
			{
				num -= 360f;
			}
			return num;
		}

		public static Vector2 MaxMagnitude(Vector2 a, Vector2 b)
		{
			float sqrMagnitude = a.sqrMagnitude;
			float sqrMagnitude2 = b.sqrMagnitude;
			if (sqrMagnitude >= sqrMagnitude2)
			{
				return a;
			}
			return b;
		}

		public static Vector3 MaxMagnitude(Vector3 a, Vector3 b)
		{
			float sqrMagnitude = a.sqrMagnitude;
			float sqrMagnitude2 = b.sqrMagnitude;
			if (sqrMagnitude >= sqrMagnitude2)
			{
				return a;
			}
			return b;
		}

		public static Vector2 MinMagnitude(Vector2 a, Vector2 b)
		{
			float sqrMagnitude = a.sqrMagnitude;
			float sqrMagnitude2 = b.sqrMagnitude;
			if (sqrMagnitude <= sqrMagnitude2)
			{
				return a;
			}
			return b;
		}

		public static Vector3 MinMagnitude(Vector3 a, Vector3 b)
		{
			float sqrMagnitude = a.sqrMagnitude;
			float sqrMagnitude2 = b.sqrMagnitude;
			if (sqrMagnitude <= sqrMagnitude2)
			{
				return a;
			}
			return b;
		}

		public static Vector2 Clamp(Vector2 value, Vector2 min, Vector2 max)
		{
			return new Vector2((value.x < min.x) ? min.x : ((value.x > max.x) ? max.x : value.x), (value.y < min.y) ? min.y : ((value.y > max.y) ? max.y : value.y));
		}

		public static Vector2 Clamp(Vector2 value, float min, float max)
		{
			return new Vector2((value.x < min) ? min : ((value.x > max) ? max : value.x), (value.y < min) ? min : ((value.y > max) ? max : value.y));
		}

		public static Vector2 Clamp(Vector3 value, Vector3 min, Vector3 max)
		{
			float x;
			if (!(value.x < min.x))
			{
				while (true)
				{
					int num = -1098952892;
					while (true)
					{
						switch (num ^ -1098952891)
						{
						case 2:
							break;
						case 1:
							goto IL_002e;
						default:
							goto IL_0045;
						}
						break;
						IL_002e:
						if (!(value.x > max.x))
						{
							num = -1098952891;
							continue;
						}
						goto IL_004e;
					}
					continue;
					IL_004e:
					x = max.x;
					break;
					IL_0045:
					x = value.x;
					break;
				}
			}
			else
			{
				x = min.x;
			}
			return new Vector3(x, (value.y < min.y) ? min.y : ((value.y > max.y) ? max.y : value.y), (value.z < min.z) ? min.z : ((value.z > max.z) ? max.z : value.z));
		}

		public static Vector2 Clamp(Vector3 value, float min, float max)
		{
			return new Vector3((value.x < min) ? min : ((value.x > max) ? max : value.x), (value.y < min) ? min : ((value.y > max) ? max : value.y), (value.z < min) ? min : ((value.z > max) ? max : value.z));
		}

		public static float Cross(Vector2 a, Vector2 b)
		{
			return a.x * b.y - a.y * b.x;
		}

		public static float Multiply(Vector2 a, Vector2 b)
		{
			return a.x * b.x + a.y * b.y;
		}

		public static bool RectContains(Rect rect, Vector2 pos, float rotation = 0f)
		{
			if (rotation == 0f)
			{
				goto IL_0008;
			}
			Vector2 point = RotateWorldPoint(pos, rect.center, 0f - rotation);
			int num = -1365259101;
			goto IL_000d;
			IL_000d:
			switch (num ^ -1365259101)
			{
			case 2:
				break;
			case 1:
				return rect.Contains(pos);
			default:
				return rect.Contains(point);
			}
			goto IL_0008;
			IL_0008:
			num = -1365259102;
			goto IL_000d;
		}

		public static Vector2 RotateWorldPoint(Vector2 point, Vector2 center, float angle)
		{
			float num = point.x - center.x;
			float num2 = point.y - center.y;
			float value = (float)Math.PI / 180f * ClampAngle360(angle);
			float num3 = Cos(value);
			float num4 = Sin(value);
			float num5 = num * num3 - num2 * num4;
			float num6 = num * num4 + num2 * num3;
			return new Vector2(center.x + num5, center.y + num6);
		}

		public static Vector2 RotateLocalPoint(Vector2 point, float angle)
		{
			float x = point.x;
			float y = point.y;
			float value = (float)Math.PI / 180f * ClampAngle360(angle);
			float num = Cos(value);
			float num2 = Sin(value);
			float x2 = x * num - y * num2;
			float y2 = x * num2 + y * num;
			return new Vector2(x2, y2);
		}

		public static bool LineIntersectsRect(Vector2 point1, Vector2 point2, Rect rect, out float sqrMagnitude)
		{
			sqrMagnitude = float.PositiveInfinity;
			if (rect.Contains(point1) || rect.Contains(point2))
			{
				sqrMagnitude = 0f;
				goto IL_0025;
			}
			Vector2 intersection = default(Vector2);
			bool flag = LineSegementsIntersect(point1, point2, new Vector2(rect.xMin, rect.yMin), new Vector2(rect.xMin, rect.yMax), out intersection, true);
			int num = 838394103;
			goto IL_002a;
			IL_0025:
			num = 838394098;
			goto IL_002a;
			IL_002a:
			bool flag4 = default(bool);
			Vector2 intersection3 = default(Vector2);
			bool flag2 = default(bool);
			Vector2 intersection2 = default(Vector2);
			bool flag3 = default(bool);
			Vector2 intersection4 = default(Vector2);
			while (true)
			{
				switch (num ^ 0x31F8E0F0)
				{
				case 6:
					break;
				case 2:
					return true;
				case 8:
					if (flag4)
					{
						sqrMagnitude = ((sqrMagnitude != float.PositiveInfinity) ? Min(sqrMagnitude, (intersection3 - point1).sqrMagnitude) : (intersection3 - point1).sqrMagnitude);
						num = 838394097;
						continue;
					}
					goto default;
				case 7:
					flag2 = LineSegementsIntersect(point1, point2, new Vector2(rect.xMax, rect.yMin), new Vector2(rect.xMax, rect.yMax), out intersection2, true);
					flag3 = LineSegementsIntersect(point1, point2, new Vector2(rect.xMin, rect.yMax), new Vector2(rect.xMax, rect.yMax), out intersection4, true);
					flag4 = LineSegementsIntersect(point1, point2, new Vector2(rect.xMin, rect.yMin), new Vector2(rect.xMax, rect.yMax), out intersection3, true);
					num = 838394100;
					continue;
				case 5:
					return false;
				case 3:
					if (flag3)
					{
						sqrMagnitude = ((sqrMagnitude != float.PositiveInfinity) ? Min(sqrMagnitude, (intersection4 - point1).sqrMagnitude) : (intersection4 - point1).sqrMagnitude);
						num = 838394104;
						continue;
					}
					goto case 8;
				case 4:
					if (flag || flag2 || flag3 || flag4)
					{
						if (flag)
						{
							sqrMagnitude = ((sqrMagnitude != float.PositiveInfinity) ? Min(sqrMagnitude, (intersection - point1).sqrMagnitude) : (intersection - point1).sqrMagnitude);
							num = 838394096;
							continue;
						}
						goto case 0;
					}
					num = 838394101;
					continue;
				case 0:
					if (flag2)
					{
						sqrMagnitude = ((sqrMagnitude != float.PositiveInfinity) ? Min(sqrMagnitude, (intersection2 - point1).sqrMagnitude) : (intersection2 - point1).sqrMagnitude);
						num = 838394099;
						continue;
					}
					goto case 3;
				default:
					return true;
				}
				break;
			}
			goto IL_0025;
		}

		public static bool LineSegementsIntersect(Vector2 line1p1, Vector2 line1p2, Vector2 line2p1, Vector2 line2p2, out Vector2 intersection, bool collinearIntersects = false)
		{
			intersection = default(Vector2);
			Vector2 vector = line1p2 - line1p1;
			Vector2 vector2 = line2p2 - line2p1;
			float num = Cross(vector, vector2);
			float value = Cross(line2p1 - line1p1, vector);
			if (IsZero(num) && IsZero(value))
			{
				if (collinearIntersects)
				{
					if (!(0f <= Multiply(line2p1 - line1p1, vector)))
					{
						goto IL_009e;
					}
					if (!(Multiply(line2p1 - line1p1, vector) <= Multiply(vector, vector)))
					{
						goto IL_0075;
					}
					goto IL_00cf;
				}
				goto IL_00d1;
			}
			int num2;
			if (IsZero(num) && !IsZero(value))
			{
				num2 = 1643075726;
			}
			else
			{
				float num3 = Cross(line2p1 - line1p1, vector2) / num;
				float num4 = Cross(line2p1 - line1p1, vector) / num;
				if (IsZero(num) || !(0f <= num3) || !(num3 <= 1f) || !(0f <= num4) || !(num4 <= 1f))
				{
					return false;
				}
				intersection = line1p1 + num3 * vector;
				num2 = 1643075722;
			}
			goto IL_007a;
			IL_00cf:
			return true;
			IL_007a:
			switch (num2 ^ 0x61EF588E)
			{
			case 3:
				break;
			case 1:
				goto IL_009e;
			case 2:
				goto IL_00cf;
			case 0:
				return false;
			default:
				return true;
			}
			goto IL_0075;
			IL_009e:
			if (0f <= Multiply(line1p1 - line2p1, vector2) && Multiply(line1p1 - line2p1, vector2) <= Multiply(vector2, vector2))
			{
				num2 = 1643075724;
				goto IL_007a;
			}
			goto IL_00d1;
			IL_00d1:
			return false;
			IL_0075:
			num2 = 1643075727;
			goto IL_007a;
		}

		private static bool clNxZGspmNvvMzgoQFLfTxbxQlt(Vector2 P_0, Vector2 P_1, Vector2 P_2, Vector2 P_3, out Vector2 P_4)
		{
			float num = P_1.y - P_0.y;
			float num7 = default(float);
			float num8 = default(float);
			while (true)
			{
				int num2 = 737717188;
				while (true)
				{
					switch (num2 ^ 0x2BF8ABC6)
					{
					case 0:
						break;
					case 2:
						num7 = P_0.x - P_1.x;
						num8 = num * P_0.x + num7 * P_0.y;
						num2 = 737717191;
						continue;
					case 1:
					{
						float num3 = P_3.y - P_2.y;
						float num4 = P_2.x - P_3.x;
						float num5 = num3 * P_2.x + num4 * P_2.y;
						float num6 = num * num4 - num3 * num7;
						if (num6 == 0f)
						{
							P_4 = Vector2.zero;
							return false;
						}
						P_4 = new Vector2((num4 * num8 - num7 * num5) / num6, (num * num5 - num3 * num8) / num6);
						num2 = 737717189;
						continue;
					}
					default:
						return true;
					}
					break;
				}
			}
		}

		public static bool RectContains(Rect container, Rect child)
		{
			if (child.xMin < container.xMin)
			{
				return false;
			}
			if (child.xMax > container.xMax)
			{
				return false;
			}
			if (child.yMin < container.yMin)
			{
				return false;
			}
			if (child.yMax > container.yMax)
			{
				return false;
			}
			return true;
		}

		public static bool GetOffsetToContainRect(Rect container, Rect child, out Vector2 offset)
		{
			offset = default(Vector2);
			int num;
			if (!(container.width < child.width))
			{
				if (container.height < child.height)
				{
					goto IL_002d;
				}
				if (child.xMin < container.xMin)
				{
					offset.x += container.xMin - child.xMin;
					num = 67209202;
					goto IL_0032;
				}
				goto IL_00a8;
			}
			goto IL_0126;
			IL_0032:
			while (true)
			{
				switch (num ^ 0x40187F2)
				{
				case 4:
					break;
				case 1:
					offset.y += container.yMax - child.yMax;
					num = 67209201;
					continue;
				case 6:
					offset.x += container.xMax - child.xMax;
					num = 67209200;
					continue;
				case 0:
					goto IL_00a8;
				case 2:
					if (child.yMin < container.yMin)
					{
						offset.y += container.yMin - child.yMin;
						num = 67209207;
						continue;
					}
					goto IL_0102;
				case 5:
					goto IL_0102;
				case 7:
					goto IL_0126;
				default:
					return true;
				}
				break;
				IL_0102:
				int num2;
				if (child.yMax > container.yMax)
				{
					num = 67209203;
					num2 = num;
				}
				else
				{
					num = 67209201;
					num2 = num;
				}
			}
			goto IL_002d;
			IL_00a8:
			int num3;
			if (child.xMax <= container.xMax)
			{
				num = 67209200;
				num3 = num;
			}
			else
			{
				num = 67209204;
				num3 = num;
			}
			goto IL_0032;
			IL_0126:
			return false;
			IL_002d:
			num = 67209205;
			goto IL_0032;
		}

		public static Matrix4x4 TransformTo(Transform from, Transform to)
		{
			return to.worldToLocalMatrix * from.localToWorldMatrix;
		}

		public static Rect TransformRect(Rect fromRect, Transform from, Transform to)
		{
			Matrix4x4 matrix4x = TransformTo(from, to);
			Vector3 vector = default(Vector3);
			Vector3 vector2 = default(Vector3);
			while (true)
			{
				int num = -790524898;
				while (true)
				{
					switch (num ^ -790524897)
					{
					case 2:
						break;
					case 1:
						vector = new Vector2(fromRect.xMin, fromRect.yMin);
						vector2 = new Vector2(fromRect.xMax, fromRect.yMax);
						vector = matrix4x.MultiplyPoint(vector);
						vector2 = matrix4x.MultiplyPoint(vector2);
						num = -790524900;
						continue;
					case 3:
						fromRect.xMin = vector.x;
						fromRect.yMin = vector.y;
						fromRect.xMax = vector2.x;
						fromRect.yMax = vector2.y;
						num = -790524897;
						continue;
					default:
						return fromRect;
					}
					break;
				}
			}
		}

		public static Vector2 SnapVectorToNearestAngle(Vector2 vector, float angle)
		{
			float num = Vector2.Angle(vector, Vector3.up);
			if (num < angle / 2f)
			{
				return Vector2.up * vector.magnitude;
			}
			if (num > 180f - angle / 2f)
			{
				return -Vector2.up * vector.magnitude;
			}
			float num2 = Mathf.Round(num / angle);
			float angle2 = num2 * angle - num;
			Vector3 axis = Vector3.Cross(Vector3.up, vector);
			Quaternion quaternion = Quaternion.AngleAxis(angle2, axis);
			return quaternion * vector;
		}
	}
}
