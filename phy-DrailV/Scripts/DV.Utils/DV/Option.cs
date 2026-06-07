using System;
using System.Collections.Generic;
using UnityEngine;

namespace DV
{
	public readonly struct Option<T>
	{
		private readonly bool hasValue;

		private readonly T value;

		public static Option<T> None => new Option<T>(hasValue: false, default(T));

		public static Option<T> Some(T value)
		{
			return new Option<T>(hasValue: true, value);
		}

		public static Option<U> Auto<U>(U value) where U : UnityEngine.Object
		{
			return new Option<U>(value, value);
		}

		private Option(bool hasValue, T value)
		{
			this.hasValue = hasValue;
			this.value = value;
		}

		public bool IsSome(out T value)
		{
			value = this.value;
			return IsSome();
		}

		public bool IsSome()
		{
			return hasValue;
		}

		public bool IsSomeAnd(Func<T, bool> f)
		{
			if (IsSome())
			{
				return f(value);
			}
			return false;
		}

		public bool IsNone()
		{
			return !IsSome();
		}

		public T Expect(string msg)
		{
			if (!IsSome())
			{
				throw new InvalidOperationException(msg);
			}
			return value;
		}

		public T ExpectOrDefault(string msg)
		{
			if (IsSome())
			{
				return value;
			}
			Debug.LogError(msg);
			return default(T);
		}

		public T Unwrap()
		{
			if (!IsSome())
			{
				throw new InvalidOperationException("Option does not contain a value");
			}
			return value;
		}

		public T UnwrapOr(T defaultValue)
		{
			if (!IsSome())
			{
				return defaultValue;
			}
			return value;
		}

		public T UnwrapOrElse(Func<T> f)
		{
			if (!IsSome())
			{
				return f();
			}
			return value;
		}

		public T UnwrapOrDefault()
		{
			return UnwrapOr(default(T));
		}

		public Option<U> Map<U>(Func<T, U> f)
		{
			if (!IsSome())
			{
				return Option<U>.None;
			}
			return Option<U>.Some(f(value));
		}

		public U MapOr<U>(U defaultValue, Func<T, U> f)
		{
			if (!IsSome())
			{
				return defaultValue;
			}
			return f(value);
		}

		public U MapOrElse<U>(Func<U> defaultValue, Func<T, U> f)
		{
			if (!IsSome())
			{
				return defaultValue();
			}
			return f(value);
		}

		public Option<U> And<U>(Option<U> other)
		{
			if (!IsSome())
			{
				return Option<U>.None;
			}
			return other;
		}

		public Option<U> AndThen<U>(Func<T, Option<U>> f)
		{
			if (!IsSome())
			{
				return Option<U>.None;
			}
			return f(value);
		}

		public Option<T> Filter(Func<T, bool> f)
		{
			if (!IsSomeAnd(f))
			{
				return None;
			}
			return this;
		}

		public Option<T> Or(Option<T> other)
		{
			if (!IsSome())
			{
				return other;
			}
			return this;
		}

		public Option<T> OrElse(Func<Option<T>> f)
		{
			if (!IsSome())
			{
				return f();
			}
			return this;
		}

		public Option<(T, U)> Zip<U>(Option<U> other)
		{
			if (!IsSome() || !other.IsSome())
			{
				return Option<(T, U)>.None;
			}
			return Option<(T, U)>.Some((value, other.value));
		}

		public bool Equals(Option<T> other)
		{
			if (hasValue == other.hasValue)
			{
				return EqualityComparer<T>.Default.Equals(value, other.value);
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj is Option<T> other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return EqualityComparer<T>.Default.GetHashCode(value);
		}

		public static implicit operator Option<T>(T value)
		{
			return new Option<T>(value != null, value);
		}

		public static implicit operator bool(Option<T> option)
		{
			return option.hasValue;
		}

		public static bool operator ==(Option<T> a, Option<T> b)
		{
			return a.Equals(b);
		}

		public static bool operator !=(Option<T> a, Option<T> b)
		{
			return !(a == b);
		}
	}
}
