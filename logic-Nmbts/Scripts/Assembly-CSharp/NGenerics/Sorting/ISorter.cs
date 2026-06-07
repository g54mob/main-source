using System.Collections.Generic;

namespace NGenerics.Sorting
{
	public interface ISorter<T>
	{
		void Sort(IList<T> list);

		void Sort(IList<T> list, SortOrder order);
	}
}
