using System;
using System.Collections;
using System.Collections.Generic;

namespace NSubstitute.Core
{
	public struct Maybe<T> : IEnumerable<T>, IEnumerable
	{
		private readonly bool hasValue;

		private readonly T value;

		public Maybe(T value)
		{
			this = default(Maybe<T>);
			this.value = value;
			hasValue = true;
		}

		public bool HasValue()
		{
			return hasValue;
		}

		public Maybe<T> OrElse(Func<Maybe<T>> other)
		{
			Maybe<T> current = this;
			return Fold(other, (T _) => current);
		}

		public Maybe<T> OrElse(Maybe<T> other)
		{
			return OrElse(() => other);
		}

		public T ValueOr(Func<T> other)
		{
			return Fold(other, (T x) => x);
		}

		public T ValueOr(T other)
		{
			return ValueOr(() => other);
		}

		public T? ValueOrDefault()
		{
			return ValueOr(default(T));
		}

		public TResult Fold<TResult>(Func<TResult> handleNoValue, Func<T, TResult> handleValue)
		{
			if (!HasValue())
			{
				return handleNoValue();
			}
			return handleValue(value);
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			if (hasValue)
			{
				yield return value;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<T>)this).GetEnumerator();
		}
	}
	public static class Maybe
	{
		public static Maybe<T> Just<T>(T value)
		{
			return new Maybe<T>(value);
		}

		public static Maybe<T> Nothing<T>()
		{
			return default(Maybe<T>);
		}
	}
}
