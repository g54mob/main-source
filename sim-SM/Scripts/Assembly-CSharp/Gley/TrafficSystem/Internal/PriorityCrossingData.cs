using System;

namespace Gley.TrafficSystem.Internal
{
	[Serializable]
	public struct PriorityCrossingData
	{
		public string Name;

		public PriorityStopWaypoints[] StopWaypoints;

		public int[] ExitWaypoints;

		public PriorityCrossingData(string name, PriorityStopWaypoints[] stopWaypoints, int[] exitWaypoints)
		{
			Name = null;
			StopWaypoints = null;
			ExitWaypoints = null;
		}

		public readonly void AddPedestrianWaypoints(int road, int[] pedestrianWaypoints, int[] directionWaypoints)
		{
		}
	}
}
