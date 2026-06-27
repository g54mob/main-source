using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions.Common;
using FluentAssertions.Specialized;

namespace FluentAssertions
{
	public class AggregateExceptionExtractor : IExtractExceptions
	{
		public IEnumerable<T> OfType<T>(Exception actualException) where T : Exception
		{
			if (typeof(T).IsSameOrInherits(typeof(AggregateException)))
			{
				if (!(actualException is T item))
				{
					return Array.Empty<T>();
				}
				return new _003C_003Ez__ReadOnlySingleElementList<T>(item);
			}
			return GetExtractedExceptions<T>(actualException);
		}

		private static List<T> GetExtractedExceptions<T>(Exception actualException) where T : Exception
		{
			List<T> list = new List<T>();
			if (actualException is AggregateException ex)
			{
				AggregateException ex2 = ex.Flatten();
				list.AddRange(ex2.InnerExceptions.OfType<T>());
			}
			else if (actualException is T item)
			{
				list.Add(item);
			}
			return list;
		}
	}
}
