using System.Collections.Generic;
using System.Threading;

namespace Cysharp.Threading.Tasks.Linq
{
	internal static class Contains
	{
		internal static async UniTask<bool> ContainsAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source, TSource value, IEqualityComparer<TSource> comparer, CancellationToken cancellationToken)
		{
			IUniTaskAsyncEnumerator<TSource> e = source.GetAsyncEnumerator(cancellationToken);
			bool result;
			try
			{
				while (true)
				{
					if (await e.MoveNextAsync())
					{
						if (comparer.Equals(value, e.Current))
						{
							result = true;
							break;
						}
						continue;
					}
					result = false;
					break;
				}
			}
			finally
			{
				if (e != null)
				{
					await e.DisposeAsync();
				}
			}
			return result;
		}
	}
}
