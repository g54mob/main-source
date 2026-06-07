using System;

namespace Rewired.Glyphs
{
	public struct Pair<T> : IEquatable<Pair<T>>
	{
		public T a;

		public T b;

		public Pair(T a, T b)
		{
			this.a = default(T);
			this.b = default(T);
		}

		public bool Equals(Pair<T> other)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public static bool operator ==(Pair<T> a, Pair<T> b)
		{
			return false;
		}

		public static bool operator !=(Pair<T> a, Pair<T> b)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
