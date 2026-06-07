using System;

namespace Pathfinding
{
	public interface IWorkItemContext : IGraphUpdateContext
	{
		[Obsolete("You no longer need to call this method. Connectivity data is automatically kept up-to-date.")]
		void QueueFloodFill();

		void EnsureValidFloodFill();

		void PreUpdate();

		void SetGraphDirty(NavGraph graph);
	}
}
