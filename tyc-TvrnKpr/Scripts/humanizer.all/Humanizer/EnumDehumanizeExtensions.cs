using System;

namespace Humanizer
{
	public static class EnumDehumanizeExtensions
	{
		public static TTargetEnum DehumanizeTo<TTargetEnum>(this string input) where TTargetEnum : struct, IComparable, IFormattable
		{
			return default(TTargetEnum);
		}

		public static Enum DehumanizeTo(this string input, Type targetEnum, OnNoMatch onNoMatch = OnNoMatch.ThrowsException)
		{
			return null;
		}

		private static object DehumanizeToPrivate(string input, Type targetEnum, OnNoMatch onNoMatch)
		{
			return null;
		}
	}
}
