using System;

namespace EasyRoads3Dv3
{
	[Serializable]
	public struct ERLane
	{
		public float position;

		public ERLaneDirection direction;

		public ERLane(float position, ERLaneDirection direction)
		{
			this.position = position;
			this.direction = direction;
		}
	}
}
