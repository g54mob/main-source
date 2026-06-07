using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniRx.InternalUtil
{
	internal static class PromiseHelper
	{
		internal static void TrySetResultAll<T>(IEnumerable<TaskCompletionSource<T>> source, T value)
		{
			TaskCompletionSource<T>[] array;
			int num = (array = source.ToArray()).Length;
			for (int i = 0; i < num; i++)
			{
				array[i].TrySetResult(value);
				array[i] = null;
			}
		}
	}
}
