using System;
using System.Collections.Generic;
using Factory.FieldData;
using Factory.Mech;

namespace Libs
{
	public static class EnumerableExtension
	{
		public static string ToDumpString<T>(this IEnumerable<T> data, string sep = ",")
		{
			return null;
		}

		public static int IndexOf<T>(this IEnumerable<T> source, Func<T, bool> predicate)
		{
			return 0;
		}

		public static bool HasBitFlag(this Dir.DirFlag value, Dir.DirFlag flag)
		{
			return false;
		}

		public static bool HasBitFlag(this eCarrierResultFlag value, eCarrierResultFlag flag)
		{
			return false;
		}

		public static bool HasBitFlag(this eEngineAdditionalEffect value, eEngineAdditionalEffect flag)
		{
			return false;
		}
	}
}
