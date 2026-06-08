using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Castle.Core
{
	public class ReferenceEqualityComparer<T> : IEqualityComparer, IEqualityComparer<T>
	{
		private static readonly ReferenceEqualityComparer<T> instance = new ReferenceEqualityComparer<T>();

		public static ReferenceEqualityComparer<T> Instance => instance;

		private ReferenceEqualityComparer()
		{
		}

		public int GetHashCode(object obj)
		{
			return RuntimeHelpers.GetHashCode(obj);
		}

		bool IEqualityComparer.Equals(object x, object y)
		{
			return x == y;
		}

		bool IEqualityComparer<T>.Equals(T x, T y)
		{
			return (object)x == (object)y;
		}

		int IEqualityComparer<T>.GetHashCode(T obj)
		{
			return RuntimeHelpers.GetHashCode(obj);
		}
	}
}
