using System;

namespace ParadoxNotion.Serialization.FullSerializer
{
	public static class fsGlobalConfig
	{
		public static bool SerializeDefaultValues;

		public static bool IsCaseSensitive;

		public static Type[] IgnoreSerializeAttributes;

		public static Type[] SerializeAttributes;

		public static string CustomDateTimeFormatString;

		public static bool Serialize64BitIntegerAsString;

		public static bool SerializeEnumsAsInteger;
	}
}
