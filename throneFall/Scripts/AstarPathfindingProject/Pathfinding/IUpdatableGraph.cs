using System.Collections.Generic;

namespace Pathfinding
{
	public interface IUpdatableGraph
	{
		IGraphUpdatePromise ScheduleGraphUpdates(List<GraphUpdateObject> graphUpdates);
	}
}
