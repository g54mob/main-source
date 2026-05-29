using System.Collections;
using System.Collections.Generic;

namespace CTS.Core
{
	public interface IEnumerable<out T, out TEnumerator> : IEnumerable<T>, IEnumerable where TEnumerator : IEnumerator<T>
	{
		new TEnumerator GetEnumerator();
	}
}
