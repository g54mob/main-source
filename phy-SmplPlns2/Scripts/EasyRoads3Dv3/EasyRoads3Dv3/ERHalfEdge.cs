using System;

namespace EasyRoads3Dv3
{
	[Serializable]
	public struct ERHalfEdge
	{
		public int index;

		public int previous;

		public int next;

		public int constraint;

		public ERHalfEdge(int _index)
		{
			index = _index;
			previous = -1;
			next = -1;
			constraint = -1;
		}
	}
}
