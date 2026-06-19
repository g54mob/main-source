using System.Collections;
using System.Collections.Generic;

namespace FullSerializer.RuntimeTests
{
	public interface IListType : IList<int>, ICollection<int>, IEnumerable<int>, IEnumerable
	{
	}
}
