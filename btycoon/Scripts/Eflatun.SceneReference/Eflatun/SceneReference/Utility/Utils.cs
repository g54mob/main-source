using System;
using System.Collections.Generic;
using System.Linq;

namespace Eflatun.SceneReference.Utility
{
	internal static class Utils
	{
		public const string AllZeroGuid = "00000000000000000000000000000000";

		public static bool IsAddressablesPackagePresent => true;

		public static string WithoutExtension(this string path)
		{
			return path.BeforeLast('.');
		}

		public static bool IncludesFlag<T>(this T composite, T flag) where T : Enum
		{
			return composite.HasFlag(flag);
		}

		public static string BeforeLast(this string source, char chr)
		{
			int num = source.LastIndexOf(chr);
			if (num >= 0)
			{
				return source.Substring(0, num);
			}
			return source;
		}

		public static bool IsValidGuid(this string guid)
		{
			if (guid.Length == 32)
			{
				return guid.ToUpper().All("0123456789ABCDEF".Contains);
			}
			return false;
		}

		public static string GuardGuidAgainstNullOrWhitespace(this string guid)
		{
			if (!string.IsNullOrWhiteSpace(guid))
			{
				return guid;
			}
			return "00000000000000000000000000000000";
		}

		public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> readOnly)
		{
			return new Dictionary<TKey, TValue>(readOnly);
		}
	}
}
