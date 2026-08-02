using System.Collections.Generic;

namespace MoonSharp.Interpreter
{
	public static class LinqHelpers
	{
		public static IEnumerable<T> Convert<T>(this IEnumerable<DynValue> enumerable, DataType type)
		{
			return null;
		}

		public static IEnumerable<DynValue> OfDataType(this IEnumerable<DynValue> enumerable, DataType type)
		{
			return null;
		}

		public static IEnumerable<object> AsObjects(this IEnumerable<DynValue> enumerable)
		{
			return null;
		}

		public static IEnumerable<T> AsObjects<T>(this IEnumerable<DynValue> enumerable)
		{
			return null;
		}
	}
}
