using System;

namespace MoonSharp.Interpreter.Interop.Converters
{
	internal static class StringConversions
	{
		internal enum StringSubtype
		{
			None = 0,
			String = 1,
			StringBuilder = 2,
			Char = 3
		}

		internal static StringSubtype GetStringSubtype(Type desiredType)
		{
			return default(StringSubtype);
		}

		internal static object ConvertString(StringSubtype stringSubType, string str, Type desiredType, DataType dataType)
		{
			return null;
		}
	}
}
