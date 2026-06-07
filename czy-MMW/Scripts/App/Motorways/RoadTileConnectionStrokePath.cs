using System.Collections.Generic;
using Factory;
using Factory.Pools;
using Motorways.Utility;
using UnityEngine;

namespace Motorways
{
	[Serializable(1)]
	public class RoadTileConnectionStrokePath : IReusable
	{
		public readonly List<Vector2> pathPoints = new List<Vector2>();

		public Spline.BezierSpline pathSpline;

		public void Reset()
		{
			pathPoints.Clear();
			pathSpline = null;
		}
	}
}
