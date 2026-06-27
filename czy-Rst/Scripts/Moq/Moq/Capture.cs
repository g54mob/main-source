using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Moq
{
	public static class Capture
	{
		public static T In<T>(ICollection<T> collection)
		{
			CaptureMatch<T> match = new CaptureMatch<T>(collection.Add);
			return With(match);
		}

		public static T In<T>(IList<T> collection, Expression<Func<T, bool>> predicate)
		{
			CaptureMatch<T> match = new CaptureMatch<T>(collection.Add, predicate);
			return With(match);
		}

		public static T With<T>(CaptureMatch<T> match)
		{
			Match.Register(match);
			return default(T);
		}
	}
}
