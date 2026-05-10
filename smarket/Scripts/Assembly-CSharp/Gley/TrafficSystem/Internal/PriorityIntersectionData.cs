using System;

namespace Gley.TrafficSystem.Internal
{
	[Serializable]
	public struct PriorityIntersectionData
	{
		public string Name;

		public PriorityStopWaypoints[] StopWaypoints;

		public int[] ExitWaypoints;

		public PriorityIntersectionData(string name, PriorityStopWaypoints[] stopWaypoints, int[] exitWaypoints)
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
