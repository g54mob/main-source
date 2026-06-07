using System;
using Jundroo.Common.Utils;

namespace Jundroo.Common.Extensions
{
	public static class EnumExtensions
	{
		public static string DisplayName<T>(this T value) where T : struct, Enum
		{
			return EnumUtility<T>.DisplayName(value);
		}
	}
}
