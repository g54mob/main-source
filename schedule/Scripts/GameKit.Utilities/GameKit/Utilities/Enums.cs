using System;

namespace GameKit.Utilities
{
	public static class Enums
	{
		public static T FromString<T>(string text, T defaultValue)
		{
			return default(T);
		}

		public static bool Contains(this Enum whole, Enum part)
		{
			return false;
		}

		public static bool ReverseContains(this Enum whole, Enum part)
		{
			return false;
		}

		public static bool Equals(this Enum value, Enum target)
		{
			return false;
		}

		public static bool SameType(Enum a, Enum b)
		{
			return false;
		}

		public static int GetHighestValue<T>()
		{
			return 0;
		}
	}
}
