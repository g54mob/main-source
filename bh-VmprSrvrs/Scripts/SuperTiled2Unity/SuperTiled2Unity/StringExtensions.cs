using UnityEngine;

namespace SuperTiled2Unity
{
	public static class StringExtensions
	{
		public static Color ToColor(this string htmlString)
		{
			return default(Color);
		}

		public static T ToEnum<T>(this string str)
		{
			return default(T);
		}

		public static float ToFloat(this string str)
		{
			return 0f;
		}

		public static int ToInt(this string str)
		{
			return 0;
		}

		public static bool ToBool(this string str)
		{
			return false;
		}
	}
}
