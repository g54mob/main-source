using System;
using System.Runtime.CompilerServices;

namespace ZLinq.Linq
{
	internal static class _003COrderBy_003EF20F22F0783C758479CC59FC23C7FEAF81F289B10B31CBE866E87C24F818E06F4__UnsafeFunctions<T, U>
	{
		public static readonly Func<T, U> Identity = (T x) => Unsafe.As<T, U>(ref x);
	}
}
