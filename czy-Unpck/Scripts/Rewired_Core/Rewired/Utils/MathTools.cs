using System;
using UnityEngine;

namespace Rewired.Utils
{
	public class MathTools
	{
		private const float SzWmdqzTbmEwezcbbyNmCbJCpBo = 1E-10f;

		private const double nVcnYHkOEgdWcETXSDPxSPTkXBc = 1E-10;

		private const float OrWdXHWHgqbYQtAdvaHTdghbCec = 0.0001f;

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
					switch (-931630872 ^ -931630871)
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
				while (true)
				{
					switch (-234238442 ^ -234238444)
					{
					case 0:
						continue;
					case 2:
						return value;
					}
					break;
				}
			}
			else if (value == short.MinValue)
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
				while (true)
				{
					switch (-1749903629 ^ -1749903631)
					{
					case 0:
						continue;
					case 2:
						throw new OverflowException("Cannot compute absolute value of int.MinValue");
					}
					break;
				}
			}
			return -value;
		}

		public static long Abs(long value)
		{
			if (value >= 0)
			{
				goto IL_0005;
			}
			int num;
			int num2;
			if (value != long.MinValue)
			{
				num = 1671790669;
				num2 = num;
			}
			else
			{
				num = 1671790668;
				num2 = num;
			}
			goto IL_000a;
			IL_0005:
			num = 1671790671;
			goto IL_000a;
			IL_000a:
			switch (num ^ 0x63A5804D)
			{
			case 3:
				break;
			case 2:
				return value;
			case 1:
				throw new OverflowException("Cannot compute absolute value of long.MinValue");
			default:
				return -value;
			}
			goto IL_0005;
		}

		public static float Abs(float value)
		{
			if (value >= 0f)
			{
				while (true)
				{
					switch (-1108108185 ^ -1108108186)
					{
					case 2:
						continue;
					case 1:
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
				goto IL_000c;
			}
			int num;
			int num2;
			if (value == double.NaN)
			{
				num = -1225499520;
				num2 = num;
			}
			else
			{
				num = -1225499519;
				num2 = num;
			}
			goto IL_0011;
			IL_000c:
			num = -1225499517;
			goto IL_0011;
			IL_0011:
			switch (num ^ -1225499519)
			{
			case 3:
				break;
			case 2:
				return value;
			case 1:
				throw new OverflowException("Cannot compute absolute value of double.NaN");
			default:
				return 0.0 - value;
			}
			goto IL_000c;
		}

		public static bool Approximately(float a, float b)
		{
			if (a == b)
			{
				goto IL_0004;
			}
			float num = b - a;
			int num2 = 1144960365;
			goto IL_0009;
			IL_0009:
			float num3 = default(float);
			while (true)
			{
				float num4;
				switch (num2 ^ 0x443EB56C)
				{
				case 0:
					break;
				case 2:
					return true;
				case 4:
					if (a < 0f)
					{
						a = 0f - a;
						num2 = 1144960367;
						continue;
					}
					goto case 3;
				case 6:
					if (!(a > b))
					{
						num2 = 1144960363;
						continue;
					}
					num4 = a;
					goto IL_0078;
				case 3:
					if (b < 0f)
					{
						b = 0f - b;
						num2 = 1144960362;
						continue;
					}
					goto case 6;
				case 7:
					num4 = b;
					goto IL_0078;
				case 1:
					if (num < 0f)
					{
						num = 0f - num;
						num2 = 1144960360;
						continue;
					}
					goto case 4;
				default:
					{
						return num < ((num3 > 1.1E-44f) ? num3 : 1.1E-44f);
					}
					IL_0078:
					num3 = num4 * 1E-06f;
					num2 = 1144960361;
					continue;
				}
				break;
			}
			goto IL_0004;
			IL_0004:
			num2 = 1144960366;
			goto IL_0009;
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
			int num = -599506929;
			goto IL_0011;
			IL_0011:
			switch (num ^ -599506930)
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
			if (value < 0f)
			{
				value = 0f - value;
				num = -599506930;
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
			int num = 554814986;
			goto IL_0015;
			IL_0015:
			switch (num ^ 0x2111CE08)
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
			if (value < 0.0)
			{
				value = 0.0 - value;
				num = 554814985;
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
			int num2 = 1922595380;
			goto IL_0011;
			IL_0011:
			switch (num2 ^ 0x72987A35)
			{
			case 0:
				break;
			case 1:
				goto IL_002a;
			default:
				goto IL_0035;
			}
			goto IL_000c;
			IL_002a:
			num = value - targetValue;
			num2 = 1922595383;
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
				threshold = 0f - threshold;
				goto IL_000c;
			}
			goto IL_002a;
			IL_002a:
			int num;
			if (!(value < 0f))
			{
				num = -768245445;
				goto IL_0011;
			}
			return 0f - value <= threshold;
			IL_000c:
			num = -768245448;
			goto IL_0011;
			IL_0011:
			switch (num ^ -768245447)
			{
			case 0:
				break;
			case 1:
				goto IL_002a;
			default:
				return value <= threshold;
			}
			goto IL_000c;
		}

		public static bool IsNearOrWholeNumber(float value)
		{
			if (!(value < 0f))
			{
				goto IL_0008;
			}
			float num = 0f - value;
			goto IL_002b;
			IL_0033:
			float num2 = default(float);
			if (Ceil(num2) - num2 <= 0.0001f)
			{
				return true;
			}
			return false;
			IL_0008:
			int num3 = -1184742099;
			goto IL_000d;
			IL_000d:
			switch (num3 ^ -1184742097)
			{
			case 0:
				break;
			case 2:
				goto IL_0026;
			default:
				goto IL_0033;
			}
			goto IL_0008;
			IL_0026:
			num = value;
			goto IL_002b;
			IL_002b:
			num2 = num;
			num3 = -1184742098;
			goto IL_000d;
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
			int num2 = RoundToInt(num);
			float num3 = num - (float)num2;
			if (num3 < 0f)
			{
				num3 *= -1f;
			}
			number = ((value < 0f) ? (num2 * -1) : num2);
			if (num3 <= 0.0001f)
			{
				return true;
			}
			return false;
		}

		public static bool IsNearOrWholeNumber(float value, out int number, float threshold)
		{
			if (threshold < 0f)
			{
				goto IL_0008;
			}
			goto IL_004c;
			IL_0008:
			int num = 2016976417;
			goto IL_000d;
			IL_000d:
			float num2 = default(float);
			while (true)
			{
				switch (num ^ 0x78389E20)
				{
				case 5:
					break;
				case 1:
					threshold = 0f - threshold;
					num = 2016976419;
					continue;
				case 2:
					num2 *= -1f;
					num = 2016976416;
					continue;
				case 3:
					goto IL_004c;
				case 4:
					goto IL_0075;
				default:
					goto IL_0091;
				}
				break;
				IL_0075:
				int num3;
				if (num2 < 0f)
				{
					num = 2016976418;
					num3 = num;
				}
				else
				{
					num = 2016976416;
					num3 = num;
				}
			}
			goto IL_0008;
			IL_0091:
			int num4 = default(int);
			number = ((value < 0f) ? (num4 * -1) : num4);
			if (num2 <= threshold)
			{
				return true;
			}
			return false;
			IL_004c:
			float num5 = ((!(value < 0f)) ? value : (value *= -1f));
			num4 = RoundToInt(num5);
			num2 = num5 - (float)num4;
			num = 2016976420;
			goto IL_000d;
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
				threshold = 0f - threshold;
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
			if (oldValue < oldMin)
			{
				goto IL_0004;
			}
			goto IL_0073;
			IL_0004:
			int num = 1844155950;
			goto IL_0009;
			IL_0009:
			float result = default(float);
			float num3 = default(float);
			float num2 = default(float);
			while (true)
			{
				switch (num ^ 0x6DEB962B)
				{
				case 0:
					break;
				case 1:
					goto IL_003a;
				case 6:
					result = (oldValue - oldMin) * num3 / num2 + newMin;
					num = 1844155939;
					continue;
				case 5:
					oldValue = oldMin;
					num = 1844155946;
					continue;
				case 4:
					num3 = newMax - newMin;
					num = 1844155949;
					continue;
				case 3:
					num = 1844155939;
					continue;
				case 7:
					goto IL_0073;
				case 2:
					if (Approximately(num2, 0f))
					{
						result = newMin;
						num = 1844155944;
						continue;
					}
					goto case 4;
				default:
					return result;
				}
				break;
			}
			goto IL_0004;
			IL_0073:
			if (oldValue > oldMax)
			{
				oldValue = oldMax;
				num = 1844155946;
				goto IL_0009;
			}
			goto IL_003a;
			IL_003a:
			num2 = oldMax - oldMin;
			num = 1844155945;
			goto IL_0009;
		}

		public static int ValueInNewRange(int oldValue, int oldMin, int oldMax, int newMin, int newMax)
		{
			if (oldValue >= oldMin)
			{
				goto IL_0037;
			}
			oldValue = oldMin;
			goto IL_0056;
			IL_0037:
			int num;
			if (oldValue > oldMax)
			{
				oldValue = oldMax;
				num = 1509501612;
				goto IL_000e;
			}
			goto IL_0056;
			IL_0056:
			int num2 = oldMax - oldMin;
			num = 1509501615;
			goto IL_000e;
			IL_000e:
			int result = default(int);
			int num3 = default(int);
			while (true)
			{
				switch (num ^ 0x59F92AAA)
				{
				case 0:
					num = 1509501609;
					continue;
				case 3:
					break;
				case 1:
					result = (oldValue - oldMin) * num3 / num2 + newMin;
					num = 1509501608;
					continue;
				case 6:
					goto IL_0056;
				case 4:
					num3 = newMax - newMin;
					num = 1509501611;
					continue;
				case 5:
					if (num2 == 0)
					{
						result = newMin;
						num = 1509501608;
						continue;
					}
					goto case 4;
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
			short num = ((a < 0) ? ((short)(-a)) : a);
			while (true)
			{
				int num2 = -18958292;
				while (true)
				{
					int num3;
					short num4;
					switch (num2 ^ -18958291)
					{
					case 2:
						break;
					case 1:
						if (b >= 0)
						{
							goto IL_002d;
						}
						num3 = (short)(-b);
						goto IL_003a;
					default:
						{
							num3 = b;
							goto IL_003a;
						}
						IL_003a:
						num4 = (short)num3;
						if (num < num4)
						{
							return b;
						}
						return a;
					}
					break;
					IL_002d:
					num2 = -18958291;
				}
			}
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
			goto IL_002b;
			IL_003c:
			int num3;
			int num2 = num3;
			int num4 = 1816260674;
			goto IL_0009;
			IL_0004:
			num4 = 1816260672;
			goto IL_0009;
			IL_0009:
			switch (num4 ^ 0x6C41F042)
			{
			case 3:
				break;
			case 2:
				goto IL_0026;
			case 1:
				goto IL_0037;
			default:
				goto IL_0044;
			}
			goto IL_0004;
			IL_0037:
			num3 = b;
			goto IL_003c;
			IL_0026:
			num = a;
			goto IL_002b;
			IL_002b:
			int num5 = num;
			if (b >= 0)
			{
				num4 = 1816260675;
				goto IL_0009;
			}
			num3 = -b;
			goto IL_003c;
			IL_0044:
			if (num5 < num2)
			{
				return b;
			}
			return a;
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
			if (a >= 0)
			{
				goto IL_0005;
			}
			long num = -a;
			goto IL_002c;
			IL_0027:
			num = a;
			goto IL_002c;
			IL_0005:
			int num2 = -295736208;
			goto IL_000a;
			IL_000a:
			long num3 = default(long);
			while (true)
			{
				switch (num2 ^ -295736205)
				{
				case 0:
					break;
				case 3:
					goto IL_0027;
				case 1:
					num3 = ((b < 0) ? (-b) : b);
					num2 = -295736207;
					continue;
				default:
					goto IL_0046;
				}
				break;
			}
			goto IL_0005;
			IL_002c:
			long num4 = num;
			num2 = -295736206;
			goto IL_000a;
			IL_0046:
			if (num4 < num3)
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
				int num2 = -121009329;
				while (true)
				{
					switch (num2 ^ -121009332)
					{
					case 0:
						break;
					case 3:
						num3 = ((b < 0.0) ? (0.0 - b) : b);
						num2 = -121009331;
						continue;
					case 1:
						if (!(num >= num3))
						{
							num2 = -121009330;
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
			sbyte b2 = ((a < 0) ? ((sbyte)(-a)) : a);
			sbyte b3 = ((b < 0) ? ((sbyte)(-b)) : b);
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
			short num = ((a < 0) ? ((short)(-a)) : a);
			short num2 = ((b < 0) ? ((short)(-b)) : b);
			if (num > num2)
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
			goto IL_0046;
			IL_0046:
			int num;
			int num2;
			if (b < 0)
			{
				num = 1905171050;
				num2 = num;
			}
			else
			{
				num = 1905171048;
				num2 = num;
			}
			goto IL_000e;
			IL_0009:
			num = 1905171051;
			goto IL_000e;
			IL_000e:
			while (true)
			{
				switch (num ^ 0x718E9A69)
				{
				case 4:
					break;
				case 1:
					goto IL_002f;
				case 3:
					b = (sbyte)(-b);
					num = 1905171048;
					continue;
				case 2:
					goto IL_0046;
				default:
					return true;
				}
				break;
				IL_002f:
				if (a >= b)
				{
					num = 1905171049;
					continue;
				}
				return false;
			}
			goto IL_0009;
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
			goto IL_002b;
			IL_003b:
			int num;
			if (a >= b)
			{
				num = 434752116;
				goto IL_000e;
			}
			return false;
			IL_0009:
			num = 434752117;
			goto IL_000e;
			IL_000e:
			switch (num ^ 0x19E9CA76)
			{
			case 0:
				break;
			case 3:
				goto IL_002b;
			case 1:
				goto IL_003b;
			default:
				return true;
			}
			goto IL_0009;
			IL_002b:
			if (b < 0)
			{
				b = (short)(-b);
				num = 434752119;
				goto IL_000e;
			}
			goto IL_003b;
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
			int num = -1333762835;
			goto IL_0009;
			IL_0009:
			while (true)
			{
				switch (num ^ -1333762833)
				{
				case 0:
					break;
				case 2:
					a = -a;
					num = -1333762836;
					continue;
				case 3:
					goto IL_0035;
				case 4:
					goto IL_0044;
				default:
					return true;
				}
				break;
			}
			goto IL_0004;
			IL_0044:
			if (a >= b)
			{
				num = -1333762834;
				goto IL_0009;
			}
			return false;
			IL_0035:
			if (b < 0)
			{
				b = -b;
				num = -1333762837;
				goto IL_0009;
			}
			goto IL_0044;
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
			goto IL_0027;
			IL_0037:
			if (a >= b)
			{
				return true;
			}
			return false;
			IL_0009:
			int num = -872358262;
			goto IL_000e;
			IL_000e:
			switch (num ^ -872358264)
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
				b = -b;
				num = -872358263;
				goto IL_000e;
			}
			goto IL_0037;
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
			goto IL_002e;
			IL_0052:
			if (a >= b)
			{
				return true;
			}
			return false;
			IL_000c:
			int num = -1016217246;
			goto IL_0011;
			IL_0011:
			while (true)
			{
				switch (num ^ -1016217245)
				{
				case 0:
					break;
				case 1:
					goto IL_002e;
				case 3:
					b = 0f - b;
					num = -1016217247;
					continue;
				default:
					goto IL_0052;
				}
				break;
			}
			goto IL_000c;
			IL_002e:
			int num2;
			if (b < 0f)
			{
				num = -1016217248;
				num2 = num;
			}
			else
			{
				num = -1016217247;
				num2 = num;
			}
			goto IL_0011;
		}

		public static bool IsMoreMagnitudeOrEqual(double a, double b)
		{
			if (a < 0.0)
			{
				a = 0.0 - a;
				goto IL_0010;
			}
			goto IL_002e;
			IL_0045:
			if (a >= b)
			{
				return true;
			}
			return false;
			IL_0010:
			int num = 404343737;
			goto IL_0015;
			IL_0015:
			switch (num ^ 0x1819CBBB)
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
				num = 404343738;
				goto IL_0015;
			}
			goto IL_0045;
		}

		public static bool IsLessMagnitudeOrEqual(sbyte a, sbyte b)
		{
			if (a < 0)
			{
				a = (sbyte)(-a);
				goto IL_0009;
			}
			goto IL_002b;
			IL_003b:
			int num;
			if (a <= b)
			{
				num = -1892530799;
				goto IL_000e;
			}
			return false;
			IL_0009:
			num = -1892530797;
			goto IL_000e;
			IL_000e:
			switch (num ^ -1892530800)
			{
			case 0:
				break;
			case 3:
				goto IL_002b;
			case 2:
				goto IL_003b;
			default:
				return true;
			}
			goto IL_0009;
			IL_002b:
			if (b < 0)
			{
				b = (sbyte)(-b);
				num = -1892530798;
				goto IL_000e;
			}
			goto IL_003b;
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
			goto IL_0032;
			IL_0004:
			int num = 894435089;
			goto IL_0009;
			IL_0009:
			while (true)
			{
				switch (num ^ 0x354FFF13)
				{
				case 3:
					break;
				case 2:
					a = (short)(-a);
					num = 894435090;
					continue;
				case 1:
					goto IL_0032;
				default:
					goto IL_0042;
				}
				break;
			}
			goto IL_0004;
			IL_0032:
			if (b < 0)
			{
				b = (short)(-b);
				num = 894435091;
				goto IL_0009;
			}
			goto IL_0042;
			IL_0042:
			if (a <= b)
			{
				return true;
			}
			return false;
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
			int num = 320801264;
			goto IL_0009;
			IL_0009:
			while (true)
			{
				switch (num ^ 0x131F09F2)
				{
				case 3:
					break;
				case 2:
					a = -a;
					num = 320801267;
					continue;
				case 0:
					b = -b;
					num = 320801270;
					continue;
				case 1:
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
				num = 320801266;
				num2 = num;
			}
			else
			{
				num = 320801270;
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
				goto IL_0005;
			}
			goto IL_0032;
			IL_0005:
			int num = 1918051512;
			goto IL_000a;
			IL_000a:
			while (true)
			{
				switch (num ^ 0x725324BB)
				{
				case 0:
					break;
				case 3:
					a = -a;
					num = 1918051513;
					continue;
				case 2:
					goto IL_0032;
				default:
					goto IL_0042;
				}
				break;
			}
			goto IL_0005;
			IL_0032:
			if (b < 0)
			{
				b = -b;
				num = 1918051514;
				goto IL_000a;
			}
			goto IL_0042;
			IL_0042:
			if (a <= b)
			{
				return true;
			}
			return false;
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
			int num = -1305616238;
			goto IL_0011;
			IL_0011:
			switch (num ^ -1305616240)
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
				num = -1305616239;
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
			int num = 1946381971;
			goto IL_0015;
			IL_0015:
			switch (num ^ 0x74036E91)
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
				num = 1946381968;
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
			else
			{
				while (value > max)
				{
					int num = -1052620943;
					while (true)
					{
						switch (num ^ -1052620944)
						{
						case 0:
							goto IL_0009;
						case 2:
							break;
						default:
							return max;
						}
						break;
						IL_0009:
						num = -1052620942;
					}
				}
			}
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
					switch (0x547B852 ^ 0x547B853)
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
			if (value >= min)
			{
				goto IL_002e;
			}
			while (true)
			{
				switch (0x8FC8BA8 ^ 0x8FC8BA9)
				{
				case 2:
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

		public static long Clamp(long value, long min, long max)
		{
			if (value < min)
			{
				value = min;
				goto IL_0007;
			}
			goto IL_0032;
			IL_003f:
			return value;
			IL_0007:
			int num = 887322910;
			goto IL_000c;
			IL_000c:
			switch (num ^ 0x34E3791F)
			{
			case 0:
				break;
			case 3:
				goto IL_0032;
			default:
				return max;
			case 1:
				goto IL_003f;
			}
			goto IL_0007;
			IL_0032:
			if (value > max)
			{
				num = 887322909;
				goto IL_000c;
			}
			goto IL_003f;
		}

		public static ulong Clamp(ulong value, ulong min, ulong max)
		{
			if (value < min)
			{
				value = min;
			}
			else
			{
				while (value > max)
				{
					int num = -434663026;
					while (true)
					{
						switch (num ^ -434663028)
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
						num = -434663027;
					}
				}
			}
			return value;
		}

		public static float Clamp(float value, float min, float max)
		{
			if (value < min)
			{
				value = min;
			}
			else
			{
				while (value > max)
				{
					int num = 1193611021;
					while (true)
					{
						switch (num ^ 0x47250F0D)
						{
						case 2:
							goto IL_0009;
						case 1:
							break;
						default:
							return max;
						}
						break;
						IL_0009:
						num = 1193611020;
					}
				}
			}
			return value;
		}

		public static double Clamp(double value, double min, double max)
		{
			if (value < min)
			{
				value = min;
			}
			else
			{
				while (value > max)
				{
					int num = -1202096315;
					while (true)
					{
						switch (num ^ -1202096315)
						{
						case 2:
							goto IL_0009;
						case 1:
							break;
						default:
							return max;
						}
						break;
						IL_0009:
						num = -1202096316;
					}
				}
			}
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
			float num4 = default(float);
			float num5 = default(float);
			while (true)
			{
				int num2 = 1120545837;
				while (true)
				{
					switch (num2 ^ 0x42CA2C2F)
					{
					case 7:
						break;
					case 4:
						if (angle < 0f)
						{
							angle = 360f + angle;
							num2 = 1120545834;
							continue;
						}
						goto default;
					case 3:
						if (num3 == 0f)
						{
							return 0f;
						}
						if (num3 > 0f)
						{
							num4 = num - num5 * 360f;
							num2 = 1120545839;
							continue;
						}
						goto case 4;
					case 1:
						num3 -= num5;
						num2 = 1120545836;
						continue;
					case 6:
						num5 = Floor(num3);
						num2 = 1120545838;
						continue;
					case 0:
						angle = num4 * Sign(angle);
						num2 = 1120545835;
						continue;
					case 2:
						if (num >= 360f)
						{
							num3 = num / 360f;
							num2 = 1120545833;
							continue;
						}
						goto case 4;
					default:
						return angle;
					}
					break;
				}
			}
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

		internal static bool FwwdXGcJPcBRbGfVAtFMRwPpZqMb(int P_0, int P_1)
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
						num2 = 1436701550;
						goto IL_0009;
					}
					goto IL_0037;
					IL_0009:
					while (true)
					{
						switch (num2 ^ 0x55A2536E)
						{
						case 2:
							num2 = 1436701549;
							continue;
						case 3:
							break;
						case 0:
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
					num2 = 1436701551;
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
				return 1u;
			}
			value--;
			value |= value >> 1;
			value |= value >> 2;
			value |= value >> 4;
			value |= value >> 8;
			value |= value >> 16;
			value++;
			return value;
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
			while (true)
			{
				int num = 594858870;
				while (true)
				{
					switch (num ^ 0x2374D377)
					{
					case 2:
						break;
					case 1:
						if (sqrMagnitude <= sqrMagnitude2)
						{
							goto IL_0032;
						}
						return b;
					default:
						return a;
					}
					break;
					IL_0032:
					num = 594858871;
				}
			}
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
			float x;
			if (!(value.x < min))
			{
				while (true)
				{
					int num = -1561237839;
					while (true)
					{
						switch (num ^ -1561237840)
						{
						case 0:
							break;
						case 1:
							goto IL_0028;
						default:
							goto IL_0039;
						}
						break;
						IL_0028:
						if (!(value.x > max))
						{
							num = -1561237838;
							continue;
						}
						goto IL_0042;
					}
					continue;
					IL_0042:
					x = max;
					break;
					IL_0039:
					x = value.x;
					break;
				}
			}
			else
			{
				x = min;
			}
			return new Vector2(x, (value.y < min) ? min : ((value.y > max) ? max : value.y));
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
			float num7 = default(float);
			float value = default(float);
			float num6 = default(float);
			float num3 = default(float);
			float num4 = default(float);
			while (true)
			{
				int num2 = -1791308772;
				while (true)
				{
					switch (num2 ^ -1791308771)
					{
					case 3:
						break;
					case 1:
						num7 = point.y - center.y;
						value = (float)Math.PI / 180f * ClampAngle360(angle);
						num6 = Cos(value);
						num2 = -1791308769;
						continue;
					case 2:
					{
						float num5 = Sin(value);
						num3 = num * num6 - num7 * num5;
						num4 = num * num5 + num7 * num6;
						num2 = -1791308771;
						continue;
					}
					default:
						return new Vector2(center.x + num3, center.y + num4);
					}
					break;
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
			if (!rect.Contains(point1))
			{
				bool flag3 = default(bool);
				Vector2 intersection4 = default(Vector2);
				bool flag = default(bool);
				Vector2 intersection2 = default(Vector2);
				bool flag2 = default(bool);
				Vector2 intersection3 = default(Vector2);
				Vector2 intersection = default(Vector2);
				bool flag4 = default(bool);
				while (true)
				{
					int num = -812794756;
					while (true)
					{
						switch (num ^ -812794755)
						{
						case 6:
							break;
						case 7:
							if (flag3)
							{
								sqrMagnitude = ((sqrMagnitude != float.PositiveInfinity) ? Min(sqrMagnitude, (intersection4 - point1).sqrMagnitude) : (intersection4 - point1).sqrMagnitude);
								num = -812794760;
								continue;
							}
							goto case 5;
						case 4:
							if (flag)
							{
								sqrMagnitude = ((sqrMagnitude != float.PositiveInfinity) ? Min(sqrMagnitude, (intersection2 - point1).sqrMagnitude) : (intersection2 - point1).sqrMagnitude);
								num = -812794763;
								continue;
							}
							goto default;
						case 3:
							goto IL_00d4;
						case 1:
							goto IL_0150;
						case 5:
							if (flag2)
							{
								sqrMagnitude = ((sqrMagnitude != float.PositiveInfinity) ? Min(sqrMagnitude, (intersection3 - point1).sqrMagnitude) : (intersection3 - point1).sqrMagnitude);
								num = -812794759;
								continue;
							}
							goto case 4;
						case 2:
							sqrMagnitude = ((sqrMagnitude != float.PositiveInfinity) ? Min(sqrMagnitude, (intersection - point1).sqrMagnitude) : (intersection - point1).sqrMagnitude);
							num = -812794758;
							continue;
						case 0:
							goto IL_0257;
						default:
							return true;
						}
						break;
						IL_0257:
						if (!flag2 && !flag)
						{
							return false;
						}
						goto IL_0261;
						IL_0261:
						int num2;
						if (flag4)
						{
							num = -812794753;
							num2 = num;
						}
						else
						{
							num = -812794758;
							num2 = num;
						}
						continue;
						IL_00d4:
						flag2 = LineSegementsIntersect(point1, point2, new Vector2(rect.xMin, rect.yMax), new Vector2(rect.xMax, rect.yMax), out intersection3, collinearIntersects: true);
						flag = LineSegementsIntersect(point1, point2, new Vector2(rect.xMin, rect.yMin), new Vector2(rect.xMax, rect.yMax), out intersection2, collinearIntersects: true);
						if (!flag4 && !flag3)
						{
							num = -812794755;
							continue;
						}
						goto IL_0261;
						IL_0150:
						if (rect.Contains(point2))
						{
							goto end_IL_0014;
						}
						flag4 = LineSegementsIntersect(point1, point2, new Vector2(rect.xMin, rect.yMin), new Vector2(rect.xMin, rect.yMax), out intersection, collinearIntersects: true);
						flag3 = LineSegementsIntersect(point1, point2, new Vector2(rect.xMax, rect.yMin), new Vector2(rect.xMax, rect.yMax), out intersection4, collinearIntersects: true);
						num = -812794754;
					}
					continue;
					end_IL_0014:
					break;
				}
			}
			sqrMagnitude = 0f;
			return true;
		}

		public static bool LineSegementsIntersect(Vector2 line1p1, Vector2 line1p2, Vector2 line2p1, Vector2 line2p2, out Vector2 intersection, bool collinearIntersects = false)
		{
			intersection = default(Vector2);
			Vector2 vector = line1p2 - line1p1;
			Vector2 vector2 = default(Vector2);
			float num5 = default(float);
			float num3 = default(float);
			float num2 = default(float);
			float value = default(float);
			while (true)
			{
				int num = -2102975206;
				while (true)
				{
					switch (num ^ -2102975208)
					{
					case 9:
						break;
					case 2:
						vector2 = line2p2 - line2p1;
						num = -2102975207;
						continue;
					case 8:
						num5 = Cross(line2p1 - line1p1, vector) / num3;
						num = -2102975204;
						continue;
					case 6:
						if (0f <= Multiply(line1p1 - line2p1, vector2) && Multiply(line1p1 - line2p1, vector2) <= Multiply(vector2, vector2))
						{
							num = -2102975208;
							continue;
						}
						goto IL_0101;
					case 4:
						if (!IsZero(num3) && 0f <= num2 && num2 <= 1f && 0f <= num5 && num5 <= 1f)
						{
							num = -2102975201;
							continue;
						}
						return false;
					case 1:
						num3 = Cross(vector, vector2);
						num = -2102975203;
						continue;
					case 0:
						return true;
					case 3:
						if (!IsZero(value))
						{
							return false;
						}
						goto IL_011f;
					case 5:
						value = Cross(line2p1 - line1p1, vector);
						if (!IsZero(num3) || !IsZero(value))
						{
							if (IsZero(num3))
							{
								num = -2102975205;
								continue;
							}
							goto IL_011f;
						}
						if (collinearIntersects)
						{
							if (0f <= Multiply(line2p1 - line1p1, vector))
							{
								int num4;
								if (!(Multiply(line2p1 - line1p1, vector) <= Multiply(vector, vector)))
								{
									num = -2102975202;
									num4 = num;
								}
								else
								{
									num = -2102975208;
									num4 = num;
								}
								continue;
							}
							goto case 6;
						}
						goto IL_0101;
					default:
						{
							intersection = line1p1 + num2 * vector;
							return true;
						}
						IL_011f:
						num2 = Cross(line2p1 - line1p1, vector2) / num3;
						num = -2102975216;
						continue;
						IL_0101:
						return false;
					}
					break;
				}
			}
		}

		private static bool aVBfMEghLFNqcaCMhkpccvHihKZ(Vector2 P_0, Vector2 P_1, Vector2 P_2, Vector2 P_3, out Vector2 P_4)
		{
			float num = P_1.y - P_0.y;
			float num2 = P_0.x - P_1.x;
			while (true)
			{
				int num3 = 1034267701;
				while (true)
				{
					switch (num3 ^ 0x3DA5AC37)
					{
					case 0:
						break;
					case 2:
					{
						float num4 = num * P_0.x + num2 * P_0.y;
						float num5 = P_3.y - P_2.y;
						float num6 = P_2.x - P_3.x;
						float num7 = num5 * P_2.x + num6 * P_2.y;
						float num8 = num * num6 - num5 * num2;
						if (num8 == 0f)
						{
							goto IL_009c;
						}
						P_4 = new Vector2((num6 * num4 - num2 * num7) / num8, (num * num7 - num5 * num4) / num8);
						return true;
					}
					default:
						return false;
					}
					break;
					IL_009c:
					P_4 = Vector2.zero;
					num3 = 1034267702;
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
				num = 1022770034;
				goto IL_0039;
			}
			return true;
			IL_0039:
			switch (num ^ 0x3CF63B73)
			{
			case 0:
				break;
			case 2:
				return false;
			default:
				return false;
			}
			goto IL_0034;
			IL_0034:
			num = 1022770033;
			goto IL_0039;
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
					num = 1156605465;
					goto IL_0032;
				}
				goto IL_007f;
			}
			goto IL_00e8;
			IL_00e8:
			return false;
			IL_007f:
			if (child.xMax > container.xMax)
			{
				offset.x += container.xMax - child.xMax;
				num = 1156605470;
				goto IL_0032;
			}
			goto IL_00b2;
			IL_00b2:
			if (child.yMin < container.yMin)
			{
				offset.y += container.yMin - child.yMin;
				num = 1156605471;
				goto IL_0032;
			}
			goto IL_005e;
			IL_002d:
			num = 1156605467;
			goto IL_0032;
			IL_0032:
			while (true)
			{
				switch (num ^ 0x44F0661A)
				{
				case 6:
					break;
				case 5:
					goto IL_005e;
				case 3:
					goto IL_007f;
				case 4:
					goto IL_00b2;
				case 1:
					goto IL_00e8;
				case 0:
					offset.y += container.yMax - child.yMax;
					num = 1156605464;
					continue;
				default:
					return true;
				}
				break;
			}
			goto IL_002d;
			IL_005e:
			int num2;
			if (child.yMax > container.yMax)
			{
				num = 1156605466;
				num2 = num;
			}
			else
			{
				num = 1156605464;
				num2 = num;
			}
			goto IL_0032;
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
			point = matrix4x.MultiplyPoint(point);
			point2 = matrix4x.MultiplyPoint(point2);
			while (true)
			{
				int num = -852985808;
				while (true)
				{
					switch (num ^ -852985806)
					{
					case 0:
						break;
					case 2:
						goto IL_006a;
					default:
						fromRect.yMax = point2.y;
						return fromRect;
					}
					break;
					IL_006a:
					fromRect.xMin = point.x;
					fromRect.yMin = point.y;
					fromRect.xMax = point2.x;
					num = -852985805;
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
			Quaternion quaternion = default(Quaternion);
			while (true)
			{
				int num3 = -526893368;
				while (true)
				{
					switch (num3 ^ -526893367)
					{
					case 2:
						break;
					case 1:
						goto IL_007b;
					default:
						return quaternion * vector;
					}
					break;
					IL_007b:
					float angle2 = num2 * angle - num;
					Vector3 axis = Vector3.Cross(Vector3.up, vector);
					quaternion = Quaternion.AngleAxis(angle2, axis);
					num3 = -526893367;
				}
			}
		}

		public static float SignedAngle(Vector3 from, Vector3 to, Vector3 axis)
		{
			float num = Vector3.Angle(from, to);
			float num2 = from.y * to.z - from.z * to.y;
			float num3 = from.z * to.x - from.x * to.z;
			float num4 = from.x * to.y - from.y * to.x;
			float num5 = Mathf.Sign(axis.x * num2 + axis.y * num3 + axis.z * num4);
			return num * num5;
		}
	}
}
