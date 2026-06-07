using System;

namespace EasyRoads3Dv3
{
	[Serializable]
	public struct ERConnectionGUIStatus
	{
		public int id;

		public bool favourite;

		public ERConnectionGUIStatus(int _id, bool value)
		{
			id = _id;
			favourite = value;
		}
	}
}
