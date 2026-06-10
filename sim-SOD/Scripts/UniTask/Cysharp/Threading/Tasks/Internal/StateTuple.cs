using System;

namespace Cysharp.Threading.Tasks.Internal
{
	internal static class StateTuple
	{
		public static StateTuple<T1> Create<T1>(T1 item1)
		{
			return null;
		}
	}
	internal class StateTuple<T1> : IDisposable
	{
		public T1 Item1;

		public void Dispose()
		{
		}
	}
}
