using System;
using UniRx.InternalUtil;

namespace UniRx
{
	internal static class Stubs
	{
		public static readonly Action Nop = delegate
		{
		};

		public static readonly Action<Exception> Throw = delegate(Exception ex)
		{
			ex.Throw();
		};

		public static IObservable<TSource> CatchIgnore<TSource>(Exception ex)
		{
			return Observable.Empty<TSource>();
		}
	}
	internal static class Stubs<T>
	{
		public static readonly Action<T> Ignore = delegate
		{
		};

		public static readonly Func<T, T> Identity = (T t) => t;

		public static readonly Action<Exception, T> Throw = delegate(Exception ex, T _)
		{
			ex.Throw();
		};
	}
	internal static class Stubs<T1, T2>
	{
		public static readonly Action<T1, T2> Ignore = delegate
		{
		};

		public static readonly Action<Exception, T1, T2> Throw = delegate(Exception ex, T1 _, T2 __)
		{
			ex.Throw();
		};
	}
	internal static class Stubs<T1, T2, T3>
	{
		public static readonly Action<T1, T2, T3> Ignore = delegate
		{
		};

		public static readonly Action<Exception, T1, T2, T3> Throw = delegate(Exception ex, T1 _, T2 __, T3 ___)
		{
			ex.Throw();
		};
	}
}
