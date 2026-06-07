using UnityEngine;

namespace Motorways.Views
{
	public struct MotorwayEdge
	{
		public MotorwayPoint from;

		public MotorwayPoint to;

		public Vector2 normal;

		public MotorwayEdgeType type;

		public MotorwayEdge(MotorwayPoint from, MotorwayPoint to, Vector2 normal, MotorwayEdgeType type)
		{
			this.from = from;
			this.to = to;
			this.normal = normal;
			this.type = type;
		}
	}
}
