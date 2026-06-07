using System;
using System.Collections.Generic;
using System.Threading;

namespace R3
{
	public static class Disposable
	{
		public static readonly IDisposable Empty = new EmptyDisposable();

		public static DisposableBuilder CreateBuilder()
		{
			return new DisposableBuilder();
		}

		public static T AddTo<T>(this T disposable, ref DisposableBuilder builder) where T : IDisposable
		{
			builder.Add(disposable);
			return disposable;
		}

		public static T AddTo<T>(this T disposable, ref DisposableBag bag) where T : IDisposable
		{
			bag.Add(disposable);
			return disposable;
		}

		public static T AddTo<T>(this T disposable, ICollection<IDisposable> disposables) where T : IDisposable
		{
			disposables.Add(disposable);
			return disposable;
		}

		public static CancellationTokenRegistration RegisterTo(this IDisposable disposable, CancellationToken cancellationToken)
		{
			if (!cancellationToken.CanBeCanceled)
			{
				throw new ArgumentException("Require CancellationToken CanBeCanceled");
			}
			if (cancellationToken.IsCancellationRequested)
			{
				disposable.Dispose();
				return default(CancellationTokenRegistration);
			}
			return cancellationToken.UnsafeRegister(delegate(object? state)
			{
				((IDisposable)state).Dispose();
			}, disposable);
		}

		public static IDisposable Create(Action onDisposed)
		{
			return new AnonymousDisposable(onDisposed);
		}

		public static IDisposable Create<T>(T state, Action<T> onDisposed)
		{
			return new AnonymousDisposable<T>(state, onDisposed);
		}

		public static IDisposable Combine(IDisposable disposable1, IDisposable disposable2)
		{
			return new CombinedDisposable2(disposable1, disposable2);
		}

		public static IDisposable Combine(IDisposable disposable1, IDisposable disposable2, IDisposable disposable3)
		{
			return new CombinedDisposable3(disposable1, disposable2, disposable3);
		}

		public static IDisposable Combine(IDisposable disposable1, IDisposable disposable2, IDisposable disposable3, IDisposable disposable4)
		{
			return new CombinedDisposable4(disposable1, disposable2, disposable3, disposable4);
		}

		public static IDisposable Combine(IDisposable disposable1, IDisposable disposable2, IDisposable disposable3, IDisposable disposable4, IDisposable disposable5)
		{
			return new CombinedDisposable5(disposable1, disposable2, disposable3, disposable4, disposable5);
		}

		public static IDisposable Combine(IDisposable disposable1, IDisposable disposable2, IDisposable disposable3, IDisposable disposable4, IDisposable disposable5, IDisposable disposable6)
		{
			return new CombinedDisposable6(disposable1, disposable2, disposable3, disposable4, disposable5, disposable6);
		}

		public static IDisposable Combine(IDisposable disposable1, IDisposable disposable2, IDisposable disposable3, IDisposable disposable4, IDisposable disposable5, IDisposable disposable6, IDisposable disposable7)
		{
			return new CombinedDisposable7(disposable1, disposable2, disposable3, disposable4, disposable5, disposable6, disposable7);
		}

		public static IDisposable Combine(IDisposable disposable1, IDisposable disposable2, IDisposable disposable3, IDisposable disposable4, IDisposable disposable5, IDisposable disposable6, IDisposable disposable7, IDisposable disposable8)
		{
			return new CombinedDisposable8(disposable1, disposable2, disposable3, disposable4, disposable5, disposable6, disposable7, disposable8);
		}

		public static IDisposable Combine(params IDisposable[] disposables)
		{
			return new CombinedDisposable(disposables);
		}

		public static void Dispose(IDisposable disposable1, IDisposable disposable2)
		{
			disposable1.Dispose();
			disposable2.Dispose();
		}

		public static void Dispose(IDisposable disposable1, IDisposable disposable2, IDisposable disposable3)
		{
			disposable1.Dispose();
			disposable2.Dispose();
			disposable3.Dispose();
		}

		public static void Dispose(IDisposable disposable1, IDisposable disposable2, IDisposable disposable3, IDisposable disposable4)
		{
			disposable1.Dispose();
			disposable2.Dispose();
			disposable3.Dispose();
			disposable4.Dispose();
		}

		public static void Dispose(IDisposable disposable1, IDisposable disposable2, IDisposable disposable3, IDisposable disposable4, IDisposable disposable5)
		{
			disposable1.Dispose();
			disposable2.Dispose();
			disposable3.Dispose();
			disposable4.Dispose();
			disposable5.Dispose();
		}

		public static void Dispose(IDisposable disposable1, IDisposable disposable2, IDisposable disposable3, IDisposable disposable4, IDisposable disposable5, IDisposable disposable6)
		{
			disposable1.Dispose();
			disposable2.Dispose();
			disposable3.Dispose();
			disposable4.Dispose();
			disposable5.Dispose();
			disposable6.Dispose();
		}

		public static void Dispose(IDisposable disposable1, IDisposable disposable2, IDisposable disposable3, IDisposable disposable4, IDisposable disposable5, IDisposable disposable6, IDisposable disposable7)
		{
			disposable1.Dispose();
			disposable2.Dispose();
			disposable3.Dispose();
			disposable4.Dispose();
			disposable5.Dispose();
			disposable6.Dispose();
			disposable7.Dispose();
		}

		public static void Dispose(IDisposable disposable1, IDisposable disposable2, IDisposable disposable3, IDisposable disposable4, IDisposable disposable5, IDisposable disposable6, IDisposable disposable7, IDisposable disposable8)
		{
			disposable1.Dispose();
			disposable2.Dispose();
			disposable3.Dispose();
			disposable4.Dispose();
			disposable5.Dispose();
			disposable6.Dispose();
			disposable7.Dispose();
			disposable8.Dispose();
		}

		public static void Dispose(params IDisposable[] disposables)
		{
			for (int i = 0; i < disposables.Length; i++)
			{
				disposables[i].Dispose();
			}
		}
	}
}
