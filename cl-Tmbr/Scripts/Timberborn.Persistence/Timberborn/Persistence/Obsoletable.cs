using System;

namespace Timberborn.Persistence
{
	public readonly struct Obsoletable<T>
	{
		private readonly T _value;

		private readonly bool _upToDate;

		public T Value
		{
			get
			{
				if (!Obsolete)
				{
					return _value;
				}
				throw new InvalidOperationException("Can't access Value, value's obsolete");
			}
		}

		public bool Obsolete => !_upToDate;

		public Obsoletable(T value)
		{
			_value = value;
			_upToDate = true;
		}

		public static implicit operator Obsoletable<T>(T value)
		{
			return new Obsoletable<T>(value);
		}

		public static explicit operator T(Obsoletable<T> obsoletable)
		{
			if (!obsoletable.Obsolete)
			{
				return obsoletable.Value;
			}
			throw new InvalidOperationException($"Can't convert to {typeof(T)}, value's obsolete");
		}
	}
}
