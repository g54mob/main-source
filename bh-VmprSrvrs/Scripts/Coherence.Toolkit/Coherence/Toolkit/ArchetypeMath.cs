using System;
using System.Collections.Generic;

namespace Coherence.Toolkit
{
	internal static class ArchetypeMath
	{
		private static Dictionary<Type, (double min, double max)> limitsByType;

		private static Dictionary<Type, string> simpleTypeAliasByType;

		internal static ulong GetTotalRangeByBitsAndPrecision(int bits, double precision)
		{
			return 0uL;
		}

		internal static (long, long) GetRangeByBitsAndPrecision(int bits, double precision)
		{
			return default((long, long));
		}

		internal static double GetPrecisionByBitsAndRange(int bits, ulong range)
		{
			return 0.0;
		}

		internal static double GetRoundedPrecisionByBitsAndRange(int bits, ulong range)
		{
			return 0.0;
		}

		internal static double GetTruncatedFloatErrorPercentageByBits(int bits)
		{
			return 0.0;
		}

		internal static int GetBitsMultiplier(SchemaType schemaType)
		{
			return 0;
		}

		internal static int GetBitsForIntValue(long minRangeInclusive, long maxRangeInclusive)
		{
			return 0;
		}

		internal static long ClampWithinTypeLimits(double value, Type valueType, out bool clamped)
		{
			clamped = default(bool);
			return 0L;
		}

		internal static (double, double) GetTypeLimits(Type valueType)
		{
			return default((double, double));
		}

		internal static bool TryGetTypeLimits(Type valueType, out double minRange, out double maxRange)
		{
			minRange = default(double);
			maxRange = default(double);
			return false;
		}

		internal static string GetSimpleTypeAlias(Type valueType)
		{
			return null;
		}

		internal static bool TryGetBitsForFixedFloatValue(long minRange, long maxRange, double precision, out int bits)
		{
			bits = default(int);
			return false;
		}

		internal static bool CanOverride(SchemaType schemaType)
		{
			return false;
		}
	}
}
