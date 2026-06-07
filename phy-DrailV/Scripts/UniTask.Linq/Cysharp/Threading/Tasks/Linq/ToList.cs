using System.Collections.Generic;
using System.Threading;

namespace Cysharp.Threading.Tasks.Linq
{
	internal static class ToList
	{
		internal static async UniTask<List<TSource>> ToListAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source, CancellationToken cancellationToken)
		{
			List<TSource> list = new List<TSource>();
			IUniTaskAsyncEnumerator<TSource> e = source.GetAsyncEnumerator(cancellationToken);
			try
			{
				while (await e.MoveNextAsync())
				{
					list.Add(e.Current);
				}
			}
			finally
			{
				if (e != null)
				{
					await e.DisposeAsync();
				}
			}
			return list;
		}
	}
}
