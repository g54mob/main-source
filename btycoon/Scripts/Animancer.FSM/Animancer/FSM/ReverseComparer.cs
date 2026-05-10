using System.Collections.Generic;

namespace Animancer.FSM
{
	public class ReverseComparer<T> : IComparer<T>
	{
		public static readonly ReverseComparer<T> Instance = new ReverseComparer<T>();

		private ReverseComparer()
		{
		}

		public int Compare(T x, T y)
		{
			return Comparer<T>.Default.Compare(y, x);
		}
	}
}
