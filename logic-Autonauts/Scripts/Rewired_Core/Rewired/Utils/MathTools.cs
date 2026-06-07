using System;
using UnityEngine;

namespace Rewired.Utils
{
	public class MathTools
	{
		private const float baCAAdDaQaoplQuGapwdAVpJkEV = 1E-10f;

		private const double WRylJYAgnqdFlxxoFismIoppqEJ = 1E-10;

		private const float zvKDKUycJyauTdQCaCRYmpDahzDk = 0.0001f;

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
				throw new OverflowException("Cannot compute absolute value of sbyte.MinValue");
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
				goto IL_0004;
			}
			int num;
			int num2;
			if (value == int.MinValue)
			{
				num = -1295919248;
				num2 = num;
			}
			else
			{
				num = -1295919245;
				num2 = num;
			}
			goto IL_0009;
			IL_0004:
			num = -1295919247;
			goto IL_0009;
			IL_0009:
			switch (num ^ -1295919246)
			{
			case 0:
				break;
			case 3:
				return value;
			case 2:
				throw new OverflowException("Cannot compute absolute value of int.MinValue");
			default:
				return -value;
			}
			goto IL_0004;
		}

		public static long Abs(long value)
		{
			if (value >= 0)
			{
				while (true)
				{
					switch (0x18561FD1 ^ 0x18561FD0)
					{
					case 2:
						continue;
					case 1:
						return value;
					}
					break;
				}
			}
			else if (value == long.MinValue)
			{
				throw new OverflowException("Cannot compute absolute value of long.MinValue");
			}
			return -value;
		}

		public static float Abs(float value)
		{
			if (value >= 0f)
			{
				while (true)
				{
					switch (-1879624495 ^ -1879624493)
					{
					case 0:
						continue;
					case 2:
						return value;
					}
					break;
				}
			}
			else if (value == float.NaN)
			{
				throw new OverflowException("Cannot compute absolute value of float.NaN");
			}
			return 0f - value;
		}

		public static double Abs(double value)
		{
			if (value >= 0.0)
			{
				while (true)
				{
					switch (-85385827 ^ -85385828)
					{
					case 0:
						continue;
					case 1:
						return value;
					}
					break;
				}
			}
			else if (value == double.NaN)
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
			goto IL_005f;
			IL_005f:
			int num2;
			if (a < 0f)
			{
				a = 0f - a;
				num2 = 1172002796;
				goto IL_001a;
			}
			goto IL_0046;
			IL_0046:
			int num3;
			if (b >= 0f)
			{
				num2 = 1172002797;
				num3 = num2;
			}
			else
			{
				num2 = 1172002798;
				num3 = num2;
			}
			goto IL_001a;
			IL_0015:
			num2 = 1172002792;
			goto IL_001a;
			IL_001a:
			while (true)
			{
				switch (num2 ^ 0x45DB57EC)
				{
				case 3:
					break;
				case 2:
					b = 0f - b;
					num2 = 1172002797;
					continue;
				case 0:
					goto IL_0046;
				case 4:
					goto IL_005f;
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
			int num = -1953693330;
			goto IL_0011;
			IL_0011:
			switch (num ^ -1953693329)
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
				num = -1953693331;
				goto IL_0011;
			}
			goto IL_003d;
		}

		public static bool IsZero(double value)
		{
			if (value < 0.0)
			{
				value = 0.0 - value;
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
			int num = 834583773;
			goto IL_0015;
			IL_0015:
			switch (num ^ 0x31BEBCDC)
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
				num = 834583774;
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
			while (true)
			{
				int num2 = 829087757;
				while (true)
				{
					switch (num2 ^ 0x316AE00C)
					{
					case 2:
						break;
					case 1:
						if (!(num < 0f))
						{
							goto IL_002a;
						}
						return 0f - num <= 0.0001f;
					default:
						return num <= 0.0001f;
					}
					break;
					IL_002a:
					num2 = 829087756;
				}
			}
		}

		public static bool IsNear(float value, float targetValue, float threshold)
		{
			if (threshold < 0f)
			{
				threshold = 0f - threshold;
				goto IL_000c;
			}
			goto IL_002a;
			IL_0035:
			float num = default(float);
			if (!(num < 0f))
			{
				return num <= threshold;
			}
			return 0f - num <= threshold;
			IL_000c:
			int num2 = 1398250877;
			goto IL_0011;
			IL_0011:
			switch (num2 ^ 0x53579D7C)
			{
			case 2:
				break;
			case 1:
				goto IL_002a;
			default:
				goto IL_0035;
			}
			goto IL_000c;
			IL_002a:
			num = value - targetValue;
			num2 = 1398250876;
			goto IL_0011;
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
				while (true)
				{
					int num = -581104157;
					while (true)
					{
						switch (num ^ -581104159)
						{
						case 0:
							break;
						case 2:
							threshold = 0f - threshold;
							num = -581104160;
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
			if (!(value < 0f))
			{
				return value <= threshold;
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
				while (true)
				{
					int num = -102372341;
					while (true)
					{
						switch (num ^ -102372343)
						{
						case 0:
							break;
						case 2:
							threshold = 0f - threshold;
							num = -102372344;
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
			float num2 = ((value < 0f) ? (0f - value) : value);
			if (Ceil(num2) - num2 <= threshold)
			{
				return true;
			}
			return false;
		}

		public static bool IsNearOrWholeNumber(float value, out int number)
		{
			float num = ((!(value < 0f)) ? value : (value *= -1f));
			int num4 = default(int);
			float num3 = default(float);
			while (true)
			{
				int num2 = 477090625;
				while (true)
				{
					switch (num2 ^ 0x1C6FD340)
					{
					case 0:
						break;
					case 1:
					{
						num4 = RoundToInt(num);
						num3 = num - (float)num4;
						int num5;
						if (num3 >= 0f)
						{
							num2 = 477090626;
							num5 = num2;
						}
						else
						{
							num2 = 477090627;
							num5 = num2;
						}
						continue;
					}
					case 2:
						number = ((value < 0f) ? (num4 * -1) : num4);
						num2 = 477090628;
						continue;
					case 3:
						num3 *= -1f;
						num2 = 477090626;
						continue;
					default:
						if (num3 <= 0.0001f)
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
				goto IL_0008;
			}
			goto IL_0035;
			IL_0008:
			int num = -738872018;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ -738872020)
				{
				case 0:
					break;
				case 2:
					threshold = 0f - threshold;
					num = -738872019;
					continue;
				case 1:
					goto IL_0035;
				default:
					goto IL_006e;
				}
				break;
			}
			goto IL_0008;
			IL_0035:
			float num2 = ((!(value < 0f)) ? value : (value *= -1f));
			int num3 = RoundToInt(num2);
			float num4 = num2 - (float)num3;
			if (num4 < 0f)
			{
				num4 *= -1f;
				num = -738872017;
				goto IL_000d;
			}
			goto IL_006e;
			IL_006e:
			number = ((value < 0f) ? (num3 * -1) : num3);
			if (num4 <= threshold)
			{
				return true;
			}
			return false;
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
				goto IL_0008;
			}
			goto IL_0035;
			IL_0008:
			int num = -2136593479;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ -2136593478)
				{
				case 0:
					break;
				case 3:
					threshold = 0f - threshold;
					num = -2136593477;
					continue;
				case 1:
					goto IL_0035;
				default:
					return Round(value);
				}
				break;
			}
			goto IL_0008;
			IL_0035:
			if (IsNearOrWholeNumber(value, threshold))
			{
				num = -2136593480;
				goto IL_000d;
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
				goto IL_002f;
			}
			oldValue = oldMin;
			goto IL_003d;
			IL_0057:
			float num = newMax - newMin;
			float num2 = default(float);
			float result = (oldValue - oldMin) * num / num2 + newMin;
			int num3 = -290305690;
			goto IL_000e;
			IL_003d:
			num2 = oldMax - oldMin;
			if (Approximately(num2, 0f))
			{
				result = newMin;
				num3 = -290305690;
				goto IL_000e;
			}
			goto IL_0057;
			IL_002f:
			if (oldValue > oldMax)
			{
				oldValue = oldMax;
				num3 = -290305692;
				goto IL_000e;
			}
			goto IL_003d;
			IL_000e:
			while (true)
			{
				switch (num3 ^ -290305692)
				{
				case 4:
					num3 = -290305689;
					continue;
				case 3:
					break;
				case 0:
					goto IL_003d;
				case 1:
					goto IL_0057;
				default:
					return result;
				}
				break;
			}
			goto IL_002f;
		}

		public static int ValueInNewRange(int oldValue, int oldMin, int oldMax, int newMin, int newMax)
		{
			if (oldValue < oldMin)
			{
				oldValue = oldMin;
				goto IL_0037;
			}
			goto IL_0051;
			IL_0051:
			int num;
			int num2;
			if (oldValue <= oldMax)
			{
				num = 473026158;
				num2 = num;
			}
			else
			{
				num = 473026156;
				num2 = num;
			}
			goto IL_000e;
			IL_0037:
			int num3 = oldMax - oldMin;
			int result = default(int);
			if (num3 == 0)
			{
				result = newMin;
				num = 473026152;
				goto IL_000e;
			}
			goto IL_006d;
			IL_006d:
			int num4 = newMax - newMin;
			result = (oldValue - oldMin) * num4 / num3 + newMin;
			num = 473026154;
			goto IL_000e;
			IL_000e:
			while (true)
			{
				switch (num ^ 0x1C31CE6E)
				{
				case 5:
					num = 473026159;
					continue;
				case 0:
					break;
				case 2:
					oldValue = oldMax;
					num = 473026158;
					continue;
				case 1:
					goto IL_0051;
				case 6:
					num = 473026154;
					continue;
				case 3:
					goto IL_006d;
				default:
					return result;
				}
				break;
			}
			goto IL_0037;
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
			if (a >= 0)
			{
				goto IL_0004;
			}
			int num = (sbyte)(-a);
			goto IL_0028;
			IL_003b:
			sbyte b2 = default(sbyte);
			sbyte b3 = default(sbyte);
			if (b2 < b3)
			{
				return b;
			}
			return a;
			IL_0004:
			int num2 = 233631082;
			goto IL_0009;
			IL_0009:
			switch (num2 ^ 0xDECED6B)
			{
			case 2:
				break;
			case 1:
				goto IL_0022;
			default:
				goto IL_003b;
			}
			goto IL_0004;
			IL_0022:
			num = a;
			goto IL_0028;
			IL_0028:
			b2 = (sbyte)num;
			b3 = ((b < 0) ? ((sbyte)(-b)) : b);
			num2 = 233631083;
			goto IL_0009;
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
			short num = ((a < 0) ? ((short)(-a)) : a);
			short num2 = ((b < 0) ? ((short)(-b)) : b);
			if (num < num2)
			{
				return b;
			}
			return a;
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
			goto IL_002f;
			IL_004f:
			int num2 = default(int);
			int num3 = default(int);
			if (num2 < num3)
			{
				return b;
			}
			return a;
			IL_0004:
			int num4 = 1543874963;
			goto IL_0009;
			IL_0009:
			while (true)
			{
				int num5;
				switch (num4 ^ 0x5C05A990)
				{
				case 2:
					break;
				case 3:
					goto IL_002a;
				case 0:
					if (b >= 0)
					{
						num4 = 1543874961;
						continue;
					}
					num5 = -b;
					goto IL_0047;
				case 1:
					num5 = b;
					goto IL_0047;
				default:
					goto IL_004f;
					IL_0047:
					num3 = num5;
					num4 = 1543874964;
					continue;
				}
				break;
			}
			goto IL_0004;
			IL_002a:
			num = a;
			goto IL_002f;
			IL_002f:
			num2 = num;
			num4 = 1543874960;
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
			long num2 = ((b < 0) ? (-b) : b);
			if (num < num2)
			{
				return b;
			}
			return a;
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
			if (!(b < 0f))
			{
				goto IL_0017;
			}
			float num2 = 0f - b;
			goto IL_003b;
			IL_003b:
			float num3 = num2;
			int num4 = 1070668590;
			goto IL_001c;
			IL_0035:
			num2 = b;
			goto IL_003b;
			IL_001c:
			switch (num4 ^ 0x3FD11B2F)
			{
			case 0:
				break;
			case 2:
				goto IL_0035;
			default:
				goto IL_0043;
			}
			goto IL_0017;
			IL_0043:
			if (!(num >= num3))
			{
				return b;
			}
			return a;
			IL_0017:
			num4 = 1070668589;
			goto IL_001c;
		}

		public static double MaxMagnitude(double a, double b)
		{
			double num = ((a < 0.0) ? (0.0 - a) : a);
			if (!(b < 0.0))
			{
				goto IL_001f;
			}
			double num2 = 0.0 - b;
			goto IL_0043;
			IL_003d:
			num2 = b;
			goto IL_0043;
			IL_0024:
			int num3;
			switch (num3 ^ 0x6FCA22FF)
			{
			case 0:
				break;
			case 1:
				goto IL_003d;
			default:
				return b;
			}
			goto IL_001f;
			IL_001f:
			num3 = 1875518206;
			goto IL_0024;
			IL_0043:
			double num4 = num2;
			if (!(num >= num4))
			{
				num3 = 1875518205;
				goto IL_0024;
			}
			return a;
		}

		public static sbyte MinMagnitude(sbyte a, sbyte b)
		{
			if (a >= 0)
			{
				goto IL_0004;
			}
			int num = (sbyte)(-a);
			goto IL_0028;
			IL_0034:
			int num2 = b;
			goto IL_003a;
			IL_0004:
			int num3 = -1088927644;
			goto IL_0009;
			IL_0009:
			switch (num3 ^ -1088927642)
			{
			case 0:
				break;
			case 2:
				goto IL_0022;
			default:
				goto IL_0034;
			}
			goto IL_0004;
			IL_0022:
			num = a;
			goto IL_0028;
			IL_0028:
			sbyte b2 = (sbyte)num;
			if (b >= 0)
			{
				num3 = -1088927641;
				goto IL_0009;
			}
			num2 = (sbyte)(-b);
			goto IL_003a;
			IL_003a:
			sbyte b3 = (sbyte)num2;
			if (b2 > b3)
			{
				return b;
			}
			return a;
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
			if (a >= 0)
			{
				goto IL_0004;
			}
			int num = (short)(-a);
			goto IL_002c;
			IL_0026:
			num = a;
			goto IL_002c;
			IL_0004:
			int num2 = 1525704231;
			goto IL_0009;
			IL_0009:
			short num3 = default(short);
			while (true)
			{
				switch (num2 ^ 0x5AF06625)
				{
				case 0:
					break;
				case 2:
					goto IL_0026;
				case 1:
					num3 = ((b < 0) ? ((short)(-b)) : b);
					num2 = 1525704230;
					continue;
				default:
					goto IL_0046;
				}
				break;
			}
			goto IL_0004;
			IL_002c:
			short num4 = (short)num;
			num2 = 1525704228;
			goto IL_0009;
			IL_0046:
			if (num4 > num3)
			{
				return b;
			}
			return a;
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
			if (b >= 0)
			{
				goto IL_000e;
			}
			int num2 = -b;
			goto IL_0031;
			IL_002c:
			num2 = b;
			goto IL_0031;
			IL_0013:
			int num3;
			switch (num3 ^ 0x4E7E8EC6)
			{
			case 2:
				break;
			case 1:
				goto IL_002c;
			default:
				return b;
			}
			goto IL_000e;
			IL_000e:
			num3 = 1316916935;
			goto IL_0013;
			IL_0031:
			int num4 = num2;
			if (num > num4)
			{
				num3 = 1316916934;
				goto IL_0013;
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
			long num = ((a < 0) ? (-a) : a);
			long num2 = ((b < 0) ? (-b) : b);
			if (num > num2)
			{
				return b;
			}
			return a;
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
			if (!(a < 0.0))
			{
				goto IL_000c;
			}
			double num = 0.0 - a;
			goto IL_0034;
			IL_0034:
			double num2 = num;
			int num3 = 22031463;
			goto IL_0011;
			IL_000c:
			num3 = 22031461;
			goto IL_0011;
			IL_0011:
			while (true)
			{
				switch (num3 ^ 0x1502C64)
				{
				case 0:
					break;
				case 1:
					goto IL_002e;
				case 3:
					goto IL_003c;
				default:
					return b;
				}
				break;
				IL_003c:
				double num4 = ((b < 0.0) ? (0.0 - b) : b);
				if (!(num2 <= num4))
				{
					num3 = 22031462;
					continue;
				}
				return a;
			}
			goto IL_000c;
			IL_002e:
			num = a;
			goto IL_0034;
		}

		public static bool IsMoreMagnitudeOrEqual(sbyte a, sbyte b)
		{
			if (a < 0)
			{
				a = (sbyte)(-a);
				goto IL_0009;
			}
			goto IL_002b;
			IL_004c:
			if (a >= b)
			{
				return true;
			}
			return false;
			IL_0009:
			int num = 37112179;
			goto IL_000e;
			IL_000e:
			while (true)
			{
				switch (num ^ 0x2364972)
				{
				case 0:
					break;
				case 1:
					goto IL_002b;
				case 2:
					b = (sbyte)(-b);
					num = 37112177;
					continue;
				default:
					goto IL_004c;
				}
				break;
			}
			goto IL_0009;
			IL_002b:
			int num2;
			if (b < 0)
			{
				num = 37112176;
				num2 = num;
			}
			else
			{
				num = 37112177;
				num2 = num;
			}
			goto IL_000e;
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
			int num = 1896262959;
			goto IL_000e;
			IL_000e:
			switch (num ^ 0x7106AD2D)
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
				b = (short)(-b);
				num = 1896262956;
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
			int num = -1167488052;
			goto IL_0009;
			IL_0009:
			while (true)
			{
				switch (num ^ -1167488051)
				{
				case 0:
					break;
				case 2:
					b = -b;
					num = -1167488050;
					continue;
				case 4:
					goto IL_0035;
				case 1:
					a = -a;
					num = -1167488055;
					continue;
				default:
					goto IL_0055;
				}
				break;
			}
			goto IL_0004;
			IL_0035:
			int num2;
			if (b < 0)
			{
				num = -1167488049;
				num2 = num;
			}
			else
			{
				num = -1167488050;
				num2 = num;
			}
			goto IL_0009;
			IL_0055:
			if (a >= b)
			{
				return true;
			}
			return false;
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
				goto IL_0005;
			}
			goto IL_0041;
			IL_0005:
			int num = -1975014738;
			goto IL_000a;
			IL_000a:
			while (true)
			{
				switch (num ^ -1975014739)
				{
				case 0:
					break;
				case 3:
					a = -a;
					num = -1975014737;
					continue;
				case 1:
					b = -b;
					num = -1975014743;
					continue;
				case 2:
					goto IL_0041;
				default:
					goto IL_0057;
				}
				break;
			}
			goto IL_0005;
			IL_0057:
			if (a >= b)
			{
				return true;
			}
			return false;
			IL_0041:
			int num2;
			if (b >= 0)
			{
				num = -1975014743;
				num2 = num;
			}
			else
			{
				num = -1975014740;
				num2 = num;
			}
			goto IL_000a;
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
				goto IL_0008;
			}
			goto IL_0035;
			IL_0008:
			int num = -1541102029;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ -1541102030)
				{
				case 0:
					break;
				case 1:
					a = 0f - a;
					num = -1541102032;
					continue;
				case 2:
					goto IL_0035;
				default:
					goto IL_0048;
				}
				break;
			}
			goto IL_0008;
			IL_0048:
			if (a >= b)
			{
				return true;
			}
			return false;
			IL_0035:
			if (b < 0f)
			{
				b = 0f - b;
				num = -1541102031;
				goto IL_000d;
			}
			goto IL_0048;
		}

		public static bool IsMoreMagnitudeOrEqual(double a, double b)
		{
			if (a < 0.0)
			{
				goto IL_000c;
			}
			goto IL_0039;
			IL_000c:
			int num = 137505640;
			goto IL_0011;
			IL_0011:
			while (true)
			{
				switch (num ^ 0x8322B69)
				{
				case 0:
					break;
				case 1:
					a = 0.0 - a;
					num = 137505642;
					continue;
				case 3:
					goto IL_0039;
				default:
					goto IL_0050;
				}
				break;
			}
			goto IL_000c;
			IL_0050:
			if (a >= b)
			{
				return true;
			}
			return false;
			IL_0039:
			if (b < 0.0)
			{
				b = 0.0 - b;
				num = 137505643;
				goto IL_0011;
			}
			goto IL_0050;
		}

		public static bool IsLessMagnitudeOrEqual(sbyte a, sbyte b)
		{
			if (a < 0)
			{
				a = (sbyte)(-a);
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
			int num = -1440641448;
			goto IL_000e;
			IL_000e:
			switch (num ^ -1440641447)
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
				b = (sbyte)(-b);
				num = -1440641447;
				goto IL_000e;
			}
			goto IL_0037;
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
				goto IL_0004;
			}
			goto IL_0039;
			IL_0004:
			int num = 1822202574;
			goto IL_0009;
			IL_0009:
			while (true)
			{
				switch (num ^ 0x6C9C9ACC)
				{
				case 3:
					break;
				case 0:
					goto IL_002e;
				case 1:
					goto IL_0039;
				case 2:
					a = (short)(-a);
					num = 1822202573;
					continue;
				case 4:
					b = (short)(-b);
					num = 1822202572;
					continue;
				default:
					return true;
				}
				break;
				IL_002e:
				if (a <= b)
				{
					num = 1822202569;
					continue;
				}
				return false;
			}
			goto IL_0004;
			IL_0039:
			int num2;
			if (b < 0)
			{
				num = 1822202568;
				num2 = num;
			}
			else
			{
				num = 1822202572;
				num2 = num;
			}
			goto IL_0009;
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
				goto IL_0004;
			}
			goto IL_0040;
			IL_0004:
			int num = 723914299;
			goto IL_0009;
			IL_0009:
			while (true)
			{
				switch (num ^ 0x2B260E3F)
				{
				case 3:
					break;
				case 4:
					a = -a;
					num = 723914301;
					continue;
				case 0:
					b = -b;
					num = 723914302;
					continue;
				case 2:
					goto IL_0040;
				default:
					goto IL_0055;
				}
				break;
			}
			goto IL_0004;
			IL_0055:
			if (a <= b)
			{
				return true;
			}
			return false;
			IL_0040:
			int num2;
			if (b < 0)
			{
				num = 723914303;
				num2 = num;
			}
			else
			{
				num = 723914302;
				num2 = num;
			}
			goto IL_0009;
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
			int num = -1516625696;
			goto IL_000e;
			IL_000e:
			switch (num ^ -1516625695)
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
				b = -b;
				num = -1516625695;
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
				a = 0f - a;
				goto IL_000c;
			}
			goto IL_002a;
			IL_003d:
			if (a <= b)
			{
				return true;
			}
			return false;
			IL_000c:
			int num = 1054325126;
			goto IL_0011;
			IL_0011:
			switch (num ^ 0x3ED7B984)
			{
			case 0:
				break;
			case 2:
				goto IL_002a;
			default:
				goto IL_003d;
			}
			goto IL_000c;
			IL_002a:
			if (b < 0f)
			{
				b = 0f - b;
				num = 1054325125;
				goto IL_0011;
			}
			goto IL_003d;
		}

		public static bool IsLessMagnitudeOrEqual(double a, double b)
		{
			if (a < 0.0)
			{
				a = 0.0 - a;
				goto IL_0010;
			}
			goto IL_002e;
			IL_0045:
			if (a <= b)
			{
				return true;
			}
			return false;
			IL_0010:
			int num = -41404125;
			goto IL_0015;
			IL_0015:
			switch (num ^ -41404127)
			{
			case 0:
				break;
			case 2:
				goto IL_002e;
			default:
				goto IL_0045;
			}
			goto IL_0010;
			IL_002e:
			if (b < 0.0)
			{
				b = 0.0 - b;
				num = -41404128;
				goto IL_0015;
			}
			goto IL_0045;
		}

		public static byte Clamp(byte value, byte min, byte max)
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

		public static sbyte Clamp(sbyte value, sbyte min, sbyte max)
		{
			if (value < min)
			{
				value = min;
				while (true)
				{
					switch (-828927706 ^ -828927705)
					{
					case 0:
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

		public static short Clamp(short value, short min, short max)
		{
			if (value < min)
			{
				while (true)
				{
					int num = 175835364;
					while (true)
					{
						switch (num ^ 0xA7B08E5)
						{
						case 0:
							break;
						case 1:
							value = min;
							num = 175835366;
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

		public static ushort Clamp(ushort value, ushort min, ushort max)
		{
			if (value >= min)
			{
				goto IL_002e;
			}
			while (true)
			{
				switch (0x69CE3AEC ^ 0x69CE3AEE)
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
			else
			{
				while (value > max)
				{
					int num = -42353631;
					while (true)
					{
						switch (num ^ -42353629)
						{
						case 0:
							goto IL_0009;
						case 1:
							break;
						default:
							return max;
						}
						break;
						IL_0009:
						num = -42353630;
					}
				}
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
					int num = 824284023;
					while (true)
					{
						switch (num ^ 0x31219375)
						{
						case 0:
							break;
						case 2:
							value = min;
							num = 824284022;
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
			if (!(value < min))
			{
				goto IL_002e;
			}
			while (true)
			{
				switch (-1677595825 ^ -1677595826)
				{
				case 0:
					break;
				case 1:
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

		public static double Clamp(double value, double min, double max)
		{
			if (value < min)
			{
				goto IL_0004;
			}
			goto IL_0032;
			IL_0004:
			int num = -870756981;
			goto IL_0009;
			IL_0009:
			switch (num ^ -870756982)
			{
			case 0:
				break;
			case 1:
				goto IL_0026;
			case 3:
				goto IL_0032;
			default:
				return max;
			}
			goto IL_0004;
			IL_0026:
			value = min;
			goto IL_003f;
			IL_0032:
			if (value > max)
			{
				num = -870756984;
				goto IL_0009;
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
			float num2 = default(float);
			if (num >= 360f)
			{
				num2 = num / 360f;
				num3 = Floor(num2);
				num2 -= num3;
				goto IL_0022;
			}
			goto IL_0075;
			IL_0075:
			int num4;
			if (angle < 0f)
			{
				angle = 360f + angle;
				num4 = 562701205;
				goto IL_0027;
			}
			goto IL_008d;
			IL_0022:
			num4 = 562701206;
			goto IL_0027;
			IL_0027:
			while (true)
			{
				switch (num4 ^ 0x218A2394)
				{
				case 0:
					break;
				case 2:
					goto IL_0044;
				case 3:
					goto IL_0075;
				default:
					goto IL_008d;
				}
				break;
				IL_0044:
				if (num2 == 0f)
				{
					return 0f;
				}
				if (num2 > 0f)
				{
					float num5 = num - num3 * 360f;
					angle = num5 * Sign(angle);
					num4 = 562701207;
					continue;
				}
				goto IL_0075;
			}
			goto IL_0022;
			IL_008d:
			return angle;
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
				while (true)
				{
					int num = 326849867;
					while (true)
					{
						switch (num ^ 0x137B5549)
						{
						case 0:
							break;
						case 2:
							threshold = Mathf.Abs(threshold);
							num = 326849864;
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
			return AngleIsBetween(angle, targetAngle - threshold, targetAngle + threshold);
		}

		public static bool AngleIsBetween(float angle, float min, float max)
		{
			angle = ClampAngle360(angle);
			while (true)
			{
				int num = 621912614;
				while (true)
				{
					switch (num ^ 0x2511A225)
					{
					case 0:
						break;
					case 3:
						min = ClampAngle360(min);
						max = ClampAngle360(max);
						if (min < max)
						{
							num = 621912615;
							continue;
						}
						if (!(min <= angle))
						{
							return angle <= max;
						}
						return true;
					case 2:
						if (min <= angle)
						{
							num = 621912612;
							continue;
						}
						return false;
					default:
						return angle <= max;
					}
					break;
				}
			}
		}

		internal static bool qOsiFZjqUyWgwKunsmbTkfvCdXp(int P_0, int P_1)
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
			while (pow != 0)
			{
				while (true)
				{
					int num2;
					if ((pow & 1) == 1)
					{
						num *= x;
						num2 = 1779310668;
						goto IL_0009;
					}
					goto IL_0037;
					IL_0009:
					while (true)
					{
						switch (num2 ^ 0x6A0E204F)
						{
						case 0:
							num2 = 1779310670;
							continue;
						case 1:
							break;
						case 3:
							goto IL_0037;
						default:
							goto end_IL_0026;
						}
						break;
					}
					continue;
					IL_0037:
					x *= x;
					pow >>= 1;
					num2 = 1779310669;
					goto IL_0009;
					continue;
					end_IL_0026:
					break;
				}
			}
			return num;
		}

		public static uint RoundUpToPowerOf2(uint value)
		{
			if (value == 0)
			{
				goto IL_0003;
			}
			value--;
			value |= value >> 1;
			value |= value >> 2;
			int num = 4521265;
			goto IL_0008;
			IL_0008:
			while (true)
			{
				switch (num ^ 0x44FD33)
				{
				case 0:
					break;
				case 3:
					return 1u;
				case 1:
					value |= value >> 8;
					value |= value >> 16;
					value++;
					num = 4521271;
					continue;
				case 2:
					value |= value >> 4;
					num = 4521266;
					continue;
				default:
					return value;
				}
				break;
			}
			goto IL_0003;
			IL_0003:
			num = 4521264;
			goto IL_0008;
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
			return new Vector3((value.x < min.x) ? min.x : ((value.x > max.x) ? max.x : value.x), (value.y < min.y) ? min.y : ((value.y > max.y) ? max.y : value.y), (value.z < min.z) ? min.z : ((value.z > max.z) ? max.z : value.z));
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
				return rect.Contains(pos);
			}
			Vector2 point = RotateWorldPoint(pos, rect.center, 0f - rotation);
			return rect.Contains(point);
		}

		public static Vector2 RotateWorldPoint(Vector2 point, Vector2 center, float angle)
		{
			float num = point.x - center.x;
			float num3 = default(float);
			float num4 = default(float);
			while (true)
			{
				int num2 = -2104756128;
				while (true)
				{
					switch (num2 ^ -2104756127)
					{
					case 0:
						break;
					case 1:
						goto IL_002e;
					default:
						return new Vector2(center.x + num3, center.y + num4);
					}
					break;
					IL_002e:
					float num5 = point.y - center.y;
					float value = (float)Math.PI / 180f * ClampAngle360(angle);
					float num6 = Cos(value);
					float num7 = Sin(value);
					num3 = num * num6 - num5 * num7;
					num4 = num * num7 + num5 * num6;
					num2 = -2104756125;
				}
			}
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
				return true;
			}
			Vector2 intersection;
			bool flag = LineSegementsIntersect(point1, point2, new Vector2(rect.xMin, rect.yMin), new Vector2(rect.xMin, rect.yMax), out intersection, true);
			Vector2 intersection2;
			bool flag2 = LineSegementsIntersect(point1, point2, new Vector2(rect.xMax, rect.yMin), new Vector2(rect.xMax, rect.yMax), out intersection2, true);
			Vector2 intersection3;
			bool flag3 = LineSegementsIntersect(point1, point2, new Vector2(rect.xMin, rect.yMax), new Vector2(rect.xMax, rect.yMax), out intersection3, true);
			Vector2 intersection4;
			bool flag4 = LineSegementsIntersect(point1, point2, new Vector2(rect.xMin, rect.yMin), new Vector2(rect.xMax, rect.yMax), out intersection4, true);
			if (!flag)
			{
				goto IL_00f3;
			}
			goto IL_0160;
			IL_0160:
			int num;
			if (flag)
			{
				sqrMagnitude = ((sqrMagnitude != float.PositiveInfinity) ? Min(sqrMagnitude, (intersection - point1).sqrMagnitude) : (intersection - point1).sqrMagnitude);
				num = 950550185;
				goto IL_00f8;
			}
			goto IL_0141;
			IL_0141:
			int num2;
			if (!flag2)
			{
				num = 950550189;
				num2 = num;
			}
			else
			{
				num = 950550191;
				num2 = num;
			}
			goto IL_00f8;
			IL_00f3:
			num = 950550188;
			goto IL_00f8;
			IL_00f8:
			while (true)
			{
				switch (num ^ 0x38A83EA9)
				{
				case 2:
					break;
				case 7:
					goto IL_012c;
				case 0:
					goto IL_0141;
				case 3:
					goto IL_0156;
				case 1:
					sqrMagnitude = ((sqrMagnitude != float.PositiveInfinity) ? Min(sqrMagnitude, (intersection4 - point1).sqrMagnitude) : (intersection4 - point1).sqrMagnitude);
					num = 950550177;
					continue;
				case 5:
					goto IL_01e0;
				case 6:
					sqrMagnitude = ((sqrMagnitude != float.PositiveInfinity) ? Min(sqrMagnitude, (intersection2 - point1).sqrMagnitude) : (intersection2 - point1).sqrMagnitude);
					num = 950550189;
					continue;
				case 4:
					if (flag3)
					{
						sqrMagnitude = ((sqrMagnitude != float.PositiveInfinity) ? Min(sqrMagnitude, (intersection3 - point1).sqrMagnitude) : (intersection3 - point1).sqrMagnitude);
						num = 950550190;
						continue;
					}
					goto IL_012c;
				default:
					return true;
				}
				break;
				IL_01e0:
				if (!flag2)
				{
					num = 950550186;
					continue;
				}
				goto IL_0160;
				IL_012c:
				int num3;
				if (!flag4)
				{
					num = 950550177;
					num3 = num;
				}
				else
				{
					num = 950550184;
					num3 = num;
				}
				continue;
				IL_0156:
				if (!flag3 && !flag4)
				{
					return false;
				}
				goto IL_0160;
			}
			goto IL_00f3;
		}

		public static bool LineSegementsIntersect(Vector2 line1p1, Vector2 line1p2, Vector2 line2p1, Vector2 line2p2, out Vector2 intersection, bool collinearIntersects = false)
		{
			intersection = default(Vector2);
			Vector2 vector = default(Vector2);
			Vector2 vector2 = default(Vector2);
			float num4 = default(float);
			float num3 = default(float);
			float num2 = default(float);
			float value = default(float);
			while (true)
			{
				int num = 341349540;
				while (true)
				{
					switch (num ^ 0x145894A6)
					{
					case 0:
						break;
					case 7:
						if (collinearIntersects)
						{
							int num6;
							if (0f <= Multiply(line2p1 - line1p1, vector))
							{
								num = 341349541;
								num6 = num;
							}
							else
							{
								num = 341349536;
								num6 = num;
							}
							continue;
						}
						goto IL_017a;
					case 8:
						vector2 = line2p2 - line2p1;
						num = 341349548;
						continue;
					case 6:
						if (0f <= Multiply(line1p1 - line2p1, vector2))
						{
							num = 341349549;
							continue;
						}
						goto IL_017a;
					case 2:
						vector = line1p2 - line1p1;
						num = 341349550;
						continue;
					case 3:
					{
						int num5;
						if (!(Multiply(line2p1 - line1p1, vector) <= Multiply(vector, vector)))
						{
							num = 341349536;
							num5 = num;
						}
						else
						{
							num = 341349543;
							num5 = num;
						}
						continue;
					}
					case 11:
						if (Multiply(line1p1 - line2p1, vector2) <= Multiply(vector2, vector2))
						{
							num = 341349543;
							continue;
						}
						goto IL_017a;
					case 9:
						if (!IsZero(num4) && 0f <= num3 && num3 <= 1f && 0f <= num2)
						{
							num = 341349539;
							continue;
						}
						goto IL_01da;
					case 4:
						if (IsZero(value))
						{
							num = 341349537;
							continue;
						}
						goto IL_017c;
					case 10:
						num4 = Cross(vector, vector2);
						value = Cross(line2p1 - line1p1, vector);
						if (IsZero(num4))
						{
							num = 341349538;
							continue;
						}
						goto IL_017c;
					case 1:
						return true;
					default:
						{
							if (num2 <= 1f)
							{
								intersection = line1p1 + num3 * vector;
								return true;
							}
							goto IL_01da;
						}
						IL_01da:
						return false;
						IL_017c:
						if (IsZero(num4) && !IsZero(value))
						{
							return false;
						}
						num3 = Cross(line2p1 - line1p1, vector2) / num4;
						num2 = Cross(line2p1 - line1p1, vector) / num4;
						num = 341349551;
						continue;
						IL_017a:
						return false;
					}
					break;
				}
			}
		}

		private static bool LXVEYBbUmFgOvFPlAyFhEaxvfusi(Vector2 P_0, Vector2 P_1, Vector2 P_2, Vector2 P_3, out Vector2 P_4)
		{
			float num = P_1.y - P_0.y;
			float num7 = default(float);
			float num8 = default(float);
			float num4 = default(float);
			float num5 = default(float);
			while (true)
			{
				int num2 = -1920670785;
				while (true)
				{
					switch (num2 ^ -1920670788)
					{
					case 4:
						break;
					case 3:
						num7 = P_0.x - P_1.x;
						num8 = num * P_0.x + num7 * P_0.y;
						num4 = P_3.y - P_2.y;
						num5 = P_2.x - P_3.x;
						num2 = -1920670787;
						continue;
					case 1:
					{
						float num3 = num4 * P_2.x + num5 * P_2.y;
						float num6 = num * num5 - num4 * num7;
						if (num6 == 0f)
						{
							num2 = -1920670786;
							continue;
						}
						P_4 = new Vector2((num5 * num8 - num7 * num3) / num6, (num * num3 - num4 * num8) / num6);
						return true;
					}
					case 2:
						P_4 = Vector2.zero;
						num2 = -1920670788;
						continue;
					default:
						return false;
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
				goto IL_0034;
			}
			int num;
			if (child.yMax > container.yMax)
			{
				num = -700833397;
				goto IL_0039;
			}
			return true;
			IL_0039:
			switch (num ^ -700833397)
			{
			case 2:
				break;
			case 1:
				return false;
			default:
				return false;
			}
			goto IL_0034;
			IL_0034:
			num = -700833398;
			goto IL_0039;
		}

		public static bool GetOffsetToContainRect(Rect container, Rect child, out Vector2 offset)
		{
			offset = default(Vector2);
			if (!(container.width < child.width))
			{
				while (true)
				{
					int num = -845040908;
					while (true)
					{
						switch (num ^ -845040906)
						{
						case 5:
							break;
						case 2:
							goto IL_004f;
						case 6:
							if (child.yMax > container.yMax)
							{
								offset.y += container.yMax - child.yMax;
								num = -845040906;
								continue;
							}
							goto default;
						case 3:
							goto end_IL_001a;
						case 4:
							goto IL_00d4;
						case 7:
							if (child.yMin < container.yMin)
							{
								offset.y += container.yMin - child.yMin;
								num = -845040912;
								continue;
							}
							goto case 6;
						case 1:
							offset.x += container.xMax - child.xMax;
							num = -845040911;
							continue;
						default:
							return true;
						}
						break;
						IL_004f:
						if (container.height < child.height)
						{
							num = -845040907;
							continue;
						}
						if (child.xMin < container.xMin)
						{
							offset.x += container.xMin - child.xMin;
							num = -845040910;
							continue;
						}
						goto IL_00d4;
						IL_00d4:
						int num2;
						if (child.xMax <= container.xMax)
						{
							num = -845040911;
							num2 = num;
						}
						else
						{
							num = -845040905;
							num2 = num;
						}
					}
					continue;
					end_IL_001a:
					break;
				}
			}
			return false;
		}

		public static Matrix4x4 TransformTo(Transform from, Transform to)
		{
			return to.worldToLocalMatrix * from.localToWorldMatrix;
		}

		public static Rect TransformRect(Rect fromRect, Transform from, Transform to)
		{
			Matrix4x4 matrix4x = TransformTo(from, to);
			Vector3 point = new Vector2(fromRect.xMin, fromRect.yMin);
			Vector3 point2 = new Vector2(fromRect.xMax, fromRect.yMax);
			while (true)
			{
				int num = -1677939562;
				while (true)
				{
					switch (num ^ -1677939564)
					{
					case 0:
						break;
					case 2:
						goto IL_0058;
					default:
						point2 = matrix4x.MultiplyPoint(point2);
						fromRect.xMin = point.x;
						fromRect.yMin = point.y;
						fromRect.xMax = point2.x;
						fromRect.yMax = point2.y;
						return fromRect;
					}
					break;
					IL_0058:
					point = matrix4x.MultiplyPoint(point);
					num = -1677939563;
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
				goto IL_003d;
			}
			float num2 = Mathf.Round(num / angle);
			int num3 = -277909361;
			goto IL_0042;
			IL_0042:
			float angle2 = default(float);
			Vector3 axis = default(Vector3);
			while (true)
			{
				switch (num3 ^ -277909361)
				{
				case 3:
					break;
				case 1:
					return -Vector2.up * vector.magnitude;
				case 0:
					goto IL_0086;
				default:
				{
					Quaternion quaternion = Quaternion.AngleAxis(angle2, axis);
					return quaternion * vector;
				}
				}
				break;
				IL_0086:
				angle2 = num2 * angle - num;
				axis = Vector3.Cross(Vector3.up, vector);
				num3 = -277909363;
			}
			goto IL_003d;
			IL_003d:
			num3 = -277909362;
			goto IL_0042;
		}
	}
}
