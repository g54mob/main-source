using System;

namespace Gley.UrbanSystem.Internal
{
	[Serializable]
	public class Lane
	{
		public LaneConnectors laneEdges;

		public bool laneDirection;

		public int laneSpeed;

		public bool[] allowedCars;

		public Lane(int nrOfCars, bool laneDirection, int laneSpeed)
		{
		}

		public void UpdateAllowedCars(int nrOfCars)
		{
		}
	}
}
