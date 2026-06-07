using System;

namespace EasyRoads3Dv3
{
	[Serializable]
	public struct ERCell
	{
		public int x;

		public int y;

		public ERCell(int _x, int _y)
		{
			x = _x;
			y = _y;
		}
	}
}
