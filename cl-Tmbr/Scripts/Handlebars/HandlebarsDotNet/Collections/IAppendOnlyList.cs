using System.Collections;
using System.Collections.Generic;

namespace HandlebarsDotNet.Collections
{
	public interface IAppendOnlyList<T> : IReadOnlyList<T>, IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>
	{
		void Add(T value);
	}
}
