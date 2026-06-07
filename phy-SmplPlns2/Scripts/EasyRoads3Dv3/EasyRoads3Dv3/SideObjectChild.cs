using System;

namespace EasyRoads3Dv3
{
	[Serializable]
	public struct SideObjectChild
	{
		public double soid;

		public float offset;

		public SideObjectChild(double _so, float _offset)
		{
			soid = _so;
			offset = _offset;
		}
	}
}
