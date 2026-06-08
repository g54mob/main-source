using System.Collections.Generic;

namespace Bindito.Core.Internal
{
	public interface IBoundInstanceService
	{
		IEnumerable<object> GetBoundInstances();
	}
}
