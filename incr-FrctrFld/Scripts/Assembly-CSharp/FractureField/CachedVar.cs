using System;

namespace FractureField
{
	public class CachedVar<T> : ICachedVar
	{
		private T _value;

		private Func<T> _getValue;

		public T Value
		{
			get
			{
				return default(T);
			}
			private set
			{
			}
		}

		public CachedVar(Func<T> getValue)
		{
		}

		public static implicit operator T(CachedVar<T> value)
		{
			return default(T);
		}

		public void Clear()
		{
		}
	}
}
