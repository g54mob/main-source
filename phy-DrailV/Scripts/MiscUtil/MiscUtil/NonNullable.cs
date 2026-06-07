using System;

namespace MiscUtil
{
	public struct NonNullable<T> : IEquatable<NonNullable<T>> where T : class
	{
		private readonly T value;

		public T Value
		{
			get
			{
				if (value == null)
				{
					throw new NullReferenceException();
				}
				return value;
			}
		}

		public NonNullable(T value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			this.value = value;
		}

		public static implicit operator NonNullable<T>(T value)
		{
			return new NonNullable<T>(value);
		}

		public static implicit operator T(NonNullable<T> wrapper)
		{
			return wrapper.Value;
		}

		public static bool operator ==(NonNullable<T> first, NonNullable<T> second)
		{
			return first.value == second.value;
		}

		public static bool operator !=(NonNullable<T> first, NonNullable<T> second)
		{
			return first.value != second.value;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is NonNullable<T>))
			{
				return false;
			}
			return Equals((NonNullable<T>)obj);
		}

		public bool Equals(NonNullable<T> other)
		{
			return object.Equals(value, other.value);
		}

		public static bool Equals(NonNullable<T> first, NonNullable<T> second)
		{
			return object.Equals(first.value, second.value);
		}

		public override int GetHashCode()
		{
			if (value != null)
			{
				T val = value;
				return val.GetHashCode();
			}
			return 0;
		}

		public override string ToString()
		{
			if (value != null)
			{
				T val = value;
				return val.ToString();
			}
			return "";
		}
	}
}
