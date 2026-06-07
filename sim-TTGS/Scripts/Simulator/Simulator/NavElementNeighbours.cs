using System;

namespace Simulator
{
	[Serializable]
	public struct NavElementNeighbours
	{
		public NavElementNeighbour LeftNeighbour;

		public NavElementNeighbour RightNeighbour;

		public NavElementNeighbour UpNeighbour;

		public NavElementNeighbour DownNeighbour;
	}
}
