using System;
using System.Collections.Generic;

namespace Sentry.Internal.Extensions
{
	internal static class DisposableExtensions
	{
		public static void DisposeAll(this IEnumerable<IDisposable> disposables)
		{
			List<Exception> list = null;
			foreach (IDisposable disposable in disposables)
			{
				try
				{
					disposable.Dispose();
				}
				catch (Exception item)
				{
					if (list == null)
					{
						list = new List<Exception>();
					}
					list.Add(item);
				}
			}
			if (list != null && list.Count > 0)
			{
				throw new AggregateException(list);
			}
		}
	}
}
