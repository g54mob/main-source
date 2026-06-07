using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ZLinq.Linq
{
	internal sealed class IReadOnlyListIterator<T> : CollectionIterator<T>
	{
		public static readonly IReadOnlyListIterator<T> Instance = new IReadOnlyListIterator<T>();

		private IReadOnlyListIterator()
		{
		}

		public override bool TryGetNonEnumeratedCount(IEnumerable<T> source, out int count)
		{
			count = Unsafe.As<IEnumerable<T>, IReadOnlyList<T>>(ref source).Count;
			return true;
		}

		public override bool TryGetNext(ref FromEnumerableContent content, out T current)
		{
			int index = content.Index;
			IReadOnlyList<T> readOnlyList = Unsafe.As<IReadOnlyList<T>>(content.Source);
			if ((uint)index < (uint)readOnlyList.Count)
			{
				current = readOnlyList[index];
				content.Index = index + 1;
				return true;
			}
			Unsafe.SkipInit<T>(out current);
			return false;
		}
	}
}
