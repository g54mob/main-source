using System.Collections.Generic;

namespace MiscUtil.Collections.Extensions
{
	public static class SmartEnumerableExt
	{
		public static SmartEnumerable<T> AsSmartEnumerable<T>(this IEnumerable<T> source)
		{
			return new SmartEnumerable<T>(source);
		}
	}
}
