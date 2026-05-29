using System;

namespace Utf8Json.Formatters
{
	public static class EnumFormatterHelper
	{
		public static object GetSerializeDelegate(Type type, out bool isBoxed)
		{
			isBoxed = default(bool);
			return null;
		}

		public static object GetDeserializeDelegate(Type type, out bool isBoxed)
		{
			isBoxed = default(bool);
			return null;
		}
	}
}
