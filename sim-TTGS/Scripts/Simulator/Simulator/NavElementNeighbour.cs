using System;

namespace Simulator
{
	[Serializable]
	public struct NavElementNeighbour
	{
		public UINavElement Neighbour;

		public UINavElement BackupNeighbour;
	}
}
