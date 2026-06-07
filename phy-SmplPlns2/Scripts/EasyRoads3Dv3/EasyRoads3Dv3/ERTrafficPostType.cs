using System;

namespace EasyRoads3Dv3
{
	[Serializable]
	public enum ERTrafficPostType
	{
		TrafficLight = 0,
		Priority = 1,
		Stop = 2,
		OneWay = 3,
		OneWayNoEntry = 4,
		LeftTurn = 5,
		NoLeftTurn = 6,
		RightTurn = 7,
		NoRightTurn = 8
	}
}
