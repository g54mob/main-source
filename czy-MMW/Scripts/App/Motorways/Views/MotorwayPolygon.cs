using System.Collections.Generic;
using UnityEngine;

namespace Motorways.Views
{
	public class MotorwayPolygon
	{
		public readonly int motorwayId;

		public readonly IReadOnlyList<MotorwayPoint> points;

		public readonly IReadOnlyList<MotorwayEdge> edges;

		private bool IsClockwise
		{
			get
			{
				float num = 0f;
				for (int i = 0; i < points.Count; i++)
				{
					Vector2 position = points[i].position;
					Vector2 position2 = points[(i + 1) % points.Count].position;
					num += (position2.x - position.x) * (position2.y + position.y);
				}
				return (double)num > 0.0;
			}
		}

		public MotorwayPolygon(int motorwayId, List<MotorwayPoint> points)
		{
			this.motorwayId = motorwayId;
			this.points = points;
			List<MotorwayEdge> list = new List<MotorwayEdge>();
			int num = 0;
			int num2 = points.Count - 1;
			while (num < points.Count)
			{
				MotorwayPoint motorwayPoint = points[num2];
				MotorwayPoint to = points[num];
				MotorwayEdgeType type;
				switch (motorwayPoint.type)
				{
				case MotorwayPointType.LeftEnd:
					if (to.type == MotorwayPointType.RightEnd)
					{
						goto IL_0072;
					}
					if (to.type == MotorwayPointType.Left)
					{
						goto IL_0095;
					}
					goto default;
				case MotorwayPointType.RightEnd:
					if (to.type == MotorwayPointType.LeftEnd)
					{
						goto IL_0072;
					}
					if (to.type == MotorwayPointType.Right)
					{
						goto IL_00ba;
					}
					goto default;
				case MotorwayPointType.Left:
					if (to.type == MotorwayPointType.Left || to.type == MotorwayPointType.LeftEnd)
					{
						goto IL_0095;
					}
					goto default;
				case MotorwayPointType.Right:
					if (to.type == MotorwayPointType.Right || to.type == MotorwayPointType.RightEnd)
					{
						goto IL_00ba;
					}
					goto default;
				default:
					{
						type = MotorwayEdgeType.End;
						Diagnostics.FailAssert("Unknown edge combination {0}, {1}", motorwayPoint.type, to.type);
						break;
					}
					IL_0072:
					type = MotorwayEdgeType.End;
					break;
					IL_0095:
					type = MotorwayEdgeType.Left;
					break;
					IL_00ba:
					type = MotorwayEdgeType.Right;
					break;
				}
				if (motorwayPoint.position == to.position)
				{
					Diagnostics.FailAssert("Edge has same start and end point. current:{0}, previous: {1}", num, num2);
				}
				Vector2 vector = (to.position - motorwayPoint.position).GetNormal().normalized;
				if (IsClockwise)
				{
					vector = -vector;
				}
				list.Add(new MotorwayEdge(motorwayPoint, to, vector, type));
				num2 = num++;
			}
			edges = list;
		}
	}
}
