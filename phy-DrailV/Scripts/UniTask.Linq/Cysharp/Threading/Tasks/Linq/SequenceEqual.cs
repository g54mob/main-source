using System.Collections.Generic;
using System.Threading;

namespace Cysharp.Threading.Tasks.Linq
{
	internal static class SequenceEqual
	{
		internal static async UniTask<bool> SequenceEqualAsync<TSource>(IUniTaskAsyncEnumerable<TSource> first, IUniTaskAsyncEnumerable<TSource> second, IEqualityComparer<TSource> comparer, CancellationToken cancellationToken)
		{
			IUniTaskAsyncEnumerator<TSource> e1 = first.GetAsyncEnumerator(cancellationToken);
			bool result;
			try
			{
				IUniTaskAsyncEnumerator<TSource> e2 = second.GetAsyncEnumerator(cancellationToken);
				bool flag;
				try
				{
					while (true)
					{
						if (await e1.MoveNextAsync())
						{
							if (await e2.MoveNextAsync())
							{
								if (!comparer.Equals(e1.Current, e2.Current))
								{
									flag = false;
									break;
								}
								continue;
							}
							flag = false;
							break;
						}
						flag = !(await e2.MoveNextAsync());
						break;
					}
				}
				finally
				{
					if (e2 != null)
					{
						await e2.DisposeAsync();
					}
				}
				result = flag;
			}
			finally
			{
				if (e1 != null)
				{
					await e1.DisposeAsync();
				}
			}
			return result;
		}
	}
}
