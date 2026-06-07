using UnityEngine;

namespace Motorways.Views
{
	public struct MotorwayPoint
	{
		public Vector2 position;

		public MotorwayPointType type;

		public MotorwayPoint(Vector2 position, MotorwayPointType type)
		{
			this.position = position;
			this.type = type;
		}
	}
}
