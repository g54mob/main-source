using System;
using System.Collections.Generic;
using UnityEngine;

namespace DV.PointSet
{
	public class ClosestPointFinder
	{
		public float queryExtent;

		[NonSerialized]
		public EquiPointSet.Point? closestPoint;

		[NonSerialized]
		public List<EquiPointSet.Point> results = new List<EquiPointSet.Point>();

		private SpatialHash2D<EquiPointSet.Point> spatialHash;

		public ClosestPointFinder(float cellSize, List<EquiPointSet> pointSets)
		{
			if (cellSize <= 0f)
			{
				throw new ArgumentOutOfRangeException("cellSize", "Value must be positive");
			}
			spatialHash = new SpatialHash2D<EquiPointSet.Point>(cellSize);
			results = new List<EquiPointSet.Point>();
			foreach (EquiPointSet pointSet in pointSets)
			{
				EquiPointSet.Point[] points = pointSet.points;
				for (int i = 0; i < points.Length; i++)
				{
					EquiPointSet.Point obj = points[i];
					spatialHash.Add(obj, (Vector3)obj.position);
				}
			}
		}

		public void Search(Vector3 reference)
		{
			spatialHash.FindInRange(reference, queryExtent, ref results);
			EquiPointSet.Point? point = null;
			float num = float.PositiveInfinity;
			for (int i = 0; i < results.Count; i++)
			{
				EquiPointSet.Point value = results[i];
				float num2 = Vector3.SqrMagnitude((Vector3)value.position - reference);
				if (num2 < num)
				{
					num = num2;
					point = value;
				}
			}
			closestPoint = point;
		}
	}
}
