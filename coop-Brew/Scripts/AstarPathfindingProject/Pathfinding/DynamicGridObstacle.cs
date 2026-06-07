using System;

namespace Pathfinding
{
	[Obsolete("Has been renamed to DynamicObstacle")]
	public interface DynamicGridObstacle
	{
		bool enabled { get; set; }

		float updateError { get; set; }

		float checkTime { get; set; }

		void DoUpdateGraphs();
	}
}
