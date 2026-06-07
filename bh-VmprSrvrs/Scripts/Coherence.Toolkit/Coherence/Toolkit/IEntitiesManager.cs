using System.Collections.Generic;

namespace Coherence.Toolkit
{
	public interface IEntitiesManager
	{
		IEnumerable<NetworkEntityState> NetworkEntities { get; }
	}
}
