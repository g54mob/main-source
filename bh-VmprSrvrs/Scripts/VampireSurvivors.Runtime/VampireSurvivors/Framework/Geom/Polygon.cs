using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace VampireSurvivors.Framework.Geom
{
	[Serializable]
	public class Polygon : BaseGeom
	{
		public List<float2> _points;

		public Polygon(List<float2> points)
		{
		}

		public void DrawDebug(Color c)
		{
		}

		public bool IsPointInside(float2 point)
		{
			return false;
		}

		public float2 ClosestPositionOnAnyEdge(float2 point)
		{
			return default(float2);
		}

		public bool LineToPolygonIntersection(float2 lineStart, float2 lineEnd, out float2 intersectionPoint)
		{
			intersectionPoint = default(float2);
			return false;
		}

		private float2 ClosestPositionOnEdge(float2 pointA, float2 pointB, float2 point)
		{
			return default(float2);
		}
	}
}
