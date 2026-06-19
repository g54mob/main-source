using System.Collections;
using System.Collections.Generic;

namespace FullSerializerSave.RuntimeTests
{
	public interface IListType : IList<int>, ICollection<int>, IEnumerable<int>, IEnumerable
	{
	}
}
