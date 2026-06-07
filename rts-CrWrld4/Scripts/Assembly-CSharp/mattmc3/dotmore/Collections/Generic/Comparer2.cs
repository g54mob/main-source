using System;
using System.Collections.Generic;

namespace mattmc3.dotmore.Collections.Generic
{
	public class Comparer2<T> : Comparer<T>
	{
		private readonly Comparison<T> _compareFunction;

		public Comparer2(Comparison<T> comparison)
		{
		}

		public override int Compare(T arg1, T arg2)
		{
			return 0;
		}
	}
}
