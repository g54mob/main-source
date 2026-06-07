using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ZLinq.Linq
{
	internal sealed class IListIterator<T> : CollectionIterator<T>
	{
		public static readonly IListIterator<T> Instance = new IListIterator<T>();

		private IListIterator()
		{
		}

		public override bool TryGetNonEnumeratedCount(IEnumerable<T> source, out int count)
		{
			count = Unsafe.As<IEnumerable<T>, IList<T>>(ref source).Count;
			return true;
		}

		public override bool TryGetNext(ref FromEnumerableContent content, out T current)
		{
			int index = content.Index;
			IList<T> list = Unsafe.As<IList<T>>(content.Source);
			if ((uint)index < (uint)list.Count)
			{
				current = list[index];
				content.Index = index + 1;
				return true;
			}
			Unsafe.SkipInit<T>(out current);
			return false;
		}
	}
}
