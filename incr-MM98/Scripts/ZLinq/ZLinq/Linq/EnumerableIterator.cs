using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ZLinq.Linq
{
	internal sealed class EnumerableIterator<T> : CollectionIterator<T>
	{
		public static readonly EnumerableIterator<T> Instance = new EnumerableIterator<T>();

		private EnumerableIterator()
		{
		}

		public override bool TryGetNonEnumeratedCount(IEnumerable<T> source, out int count)
		{
			if (source is ICollection<T> collection)
			{
				count = collection.Count;
				return true;
			}
			if (source is IReadOnlyCollection<T> readOnlyCollection)
			{
				count = readOnlyCollection.Count;
				return true;
			}
			count = 0;
			return false;
		}

		public override bool TryGetNext(ref FromEnumerableContent content, out T current)
		{
			IEnumerator<T> enumerator = Unsafe.As<IEnumerator<T>>(content.Source);
			if (content.Index == 0)
			{
				enumerator = Initialize(ref content);
			}
			if (enumerator.MoveNext())
			{
				current = enumerator.Current;
				return true;
			}
			Unsafe.SkipInit<T>(out current);
			return false;
			[MethodImpl(MethodImplOptions.NoInlining)]
			static IEnumerator<T> Initialize(ref FromEnumerableContent reference)
			{
				IEnumerator<T> result = (IEnumerator<T>)(reference.Source = Unsafe.As<IEnumerable<T>>(reference.Source).GetEnumerator());
				reference.Index = -1;
				return result;
			}
		}
	}
}
