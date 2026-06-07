using System;

namespace MiscUtil.Linq
{
	public class FutureProxy<T> : IFuture<T>
	{
		private readonly Func<T> fetcher;

		public T Value => fetcher();

		public FutureProxy(Func<T> fetcher)
		{
			this.fetcher = fetcher;
		}

		public static FutureProxy<T> FromFuture<TSource>(IFuture<TSource> future, Func<TSource, T> projection)
		{
			return new FutureProxy<T>(() => projection(future.Value));
		}
	}
}
