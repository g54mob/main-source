using System.Collections;
using System.Collections.Generic;

namespace Moq
{
	public interface IInvocationList : IReadOnlyList<IInvocation>, IEnumerable<IInvocation>, IEnumerable, IReadOnlyCollection<IInvocation>
	{
		void Clear();
	}
}
