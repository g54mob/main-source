using System;

namespace Pug.UnityExtensions
{
	public static class EnumExtensions
	{
		public static bool TryParseWithIntFallback<T>(string value, out T result) where T : struct
		{
			if (!Enum.TryParse<T>(value, out result))
			{
				if (!int.TryParse(value, out var result2))
				{
					return false;
				}
				result = (T)(object)result2;
			}
			return true;
		}
	}
}
