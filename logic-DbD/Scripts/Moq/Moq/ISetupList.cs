using System.Collections;
using System.Collections.Generic;

namespace Moq
{
	public interface ISetupList : IReadOnlyList<ISetup>, IEnumerable<ISetup>, IEnumerable, IReadOnlyCollection<ISetup>
	{
	}
}
