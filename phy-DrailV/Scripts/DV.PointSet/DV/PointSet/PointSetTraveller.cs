using System;
using UnityEngine;

namespace DV.PointSet
{
	public class PointSetTraveller
	{
		public Vector3d worldPosition;

		public Vector3 worldForward;

		public Vector3 worldUp;

		public EquiPointSet pointSet;

		public EquiPointSet.Point curPoint;

		public double pointRelativeSpan;

		public bool preciseInterpolation;

		public double Span => curPoint.span + pointRelativeSpan;

		public PointSetTraveller(EquiPointSet pointSet, bool preciseInterpolation = false)
		{
			this.pointSet = pointSet ?? throw new ArgumentNullException("pointSet");
			this.preciseInterpolation = preciseInterpolation;
			curPoint = pointSet.points[0];
			worldPosition = curPoint.position;
			pointRelativeSpan = 0.0;
		}

		public void MoveToStart()
		{
			curPoint = pointSet.points[0];
			pointRelativeSpan = 0.0;
			UpdateWorldPosition();
		}

		public void MoveToEnd()
		{
			curPoint = pointSet.points[pointSet.points.Length - 2];
			pointRelativeSpan = curPoint.spanToNextPoint - 1.401298E-45;
			UpdateWorldPosition();
		}

		public void MoveToSpan(double span)
		{
			if (span < 0.0)
			{
				Debug.LogWarning("PointSetTraveller got negative span, will be clamped to 0");
				span = 0.0;
			}
			else if (span > pointSet.span)
			{
				Debug.LogWarning($"PointSetTraveller got span {span} larger than pointset's span {pointSet.span}, will be clamped");
				span = pointSet.span;
			}
			if (span == 0.0)
			{
				MoveToStart();
				return;
			}
			if (span == pointSet.span)
			{
				MoveToEnd();
				return;
			}
			int num = 0;
			int num2 = pointSet.points.Length - 2;
			while (num <= num2)
			{
				int num3 = num + (num2 - num) / 2;
				EquiPointSet.Point point = pointSet.points[num3];
				double span2 = point.span;
				double num4 = span2 + point.spanToNextPoint;
				if (span >= span2 && span < num4)
				{
					curPoint = point;
					pointRelativeSpan = span - span2;
					UpdateWorldPosition();
					break;
				}
				if (span < span2)
				{
					num2 = num3 - 1;
				}
				else
				{
					num = num3 + 1;
				}
			}
		}

		public double Travel(double offset, int stackDepth = 800)
		{
			if (stackDepth-- <= 0)
			{
				Debug.LogWarning("PointSetTraveller stack too deep, will terminate here. Check bezier curve resolution.\n" + $"number of points: {pointSet.points.Length}\n" + $"last point span: {pointSet.points[pointSet.points.Length - 1].span}\n" + $"current point index: {curPoint.index}\n" + $"current point span to next point: {curPoint.spanToNextPoint}\n" + $"remaining offset to travel: {offset}");
				return offset;
			}
			if (Mathf.Approximately((float)offset, 0f))
			{
				return 0.0;
			}
			if (pointRelativeSpan + offset >= curPoint.spanToNextPoint)
			{
				double num = offset - (curPoint.spanToNextPoint - pointRelativeSpan);
				if (curPoint.index >= pointSet.points.Length - 2)
				{
					MoveToEnd();
					return num;
				}
				curPoint = pointSet.points[curPoint.index + 1];
				pointRelativeSpan = 0.0;
				if (num < 0.0)
				{
					Debug.LogError("PointSetTraveller.Travel remainingOffset should be positive here");
				}
				return Travel(num, stackDepth);
			}
			if (pointRelativeSpan + offset < 0.0)
			{
				double num2 = offset + pointRelativeSpan;
				if (curPoint.index == 0)
				{
					worldPosition = curPoint.position;
					pointRelativeSpan = 0.0;
					return num2;
				}
				curPoint = pointSet.points[curPoint.index - 1];
				pointRelativeSpan = curPoint.spanToNextPoint;
				if (num2 >= 0.0)
				{
					Debug.LogError("PointSetTraveller.Travel remainingOffset should be negative here");
				}
				return Travel(num2, stackDepth);
			}
			if (pointRelativeSpan + offset < 0.0)
			{
				Debug.LogError($"gotcha (pointRelativeSpan will be < 0), offset: {offset}, pointIndex: {curPoint.index}, pointRelativeSpan: {pointRelativeSpan}");
			}
			else if (pointRelativeSpan + offset >= curPoint.spanToNextPoint)
			{
				Debug.LogError($"gotcha (pointRelativeSpan will be >= spanToNextPoint), offset: {offset}, pointIndex: {curPoint.index}, pointRelativeSpan: {pointRelativeSpan}");
			}
			pointRelativeSpan += offset;
			UpdateWorldPosition();
			return 0.0;
		}

		private void UpdateWorldPosition()
		{
			float num = (float)(pointRelativeSpan / curPoint.spanToNextPoint);
			if (preciseInterpolation)
			{
				Vector3d vector3d = new Vector3d(curPoint.forward);
				Vector3d p = ((curPoint.index == 0) ? (curPoint.position - vector3d) : pointSet.points[curPoint.index - 1].position);
				Vector3d position = curPoint.position;
				Vector3d p2 = ((curPoint.index == pointSet.points.Length - 1) ? (curPoint.position + vector3d) : pointSet.points[curPoint.index + 1].position);
				Vector3d p3 = ((curPoint.index >= pointSet.points.Length - 2) ? (curPoint.position + vector3d * 2.0) : pointSet.points[curPoint.index + 2].position);
				worldPosition = CatmulRom(p, position, p2, p3, num);
			}
			else
			{
				EquiPointSet.Point point = pointSet.points[curPoint.index + 1];
				worldPosition = Vector3d.Lerp(curPoint.position, point.position, num);
			}
			worldForward = Vector3.Lerp(curPoint.forward, pointSet.points[curPoint.index + 1].forward, num);
			worldUp = Vector3.Lerp(curPoint.up, pointSet.points[curPoint.index + 1].up, num);
		}

		public void RefreshTraveler()
		{
			curPoint = pointSet.points[curPoint.index];
			UpdateWorldPosition();
		}

		private static Vector3d CatmulRom(Vector3d p1, Vector3d p2, Vector3d p3, Vector3d p4, float t)
		{
			float num = 0f;
			float t2 = GetT(num, p1, p2);
			float t3 = GetT(t2, p2, p3);
			float t4 = GetT(t3, p3, p4);
			t = Mathf.Lerp(t2, t3, t);
			Vector3d vector3d = (t2 - t) / (t2 - num) * p1 + (t - num) / (t2 - num) * p2;
			Vector3d vector3d2 = (t3 - t) / (t3 - t2) * p2 + (t - t2) / (t3 - t2) * p3;
			Vector3d vector3d3 = (t4 - t) / (t4 - t3) * p3 + (t - t3) / (t4 - t3) * p4;
			Vector3d vector3d4 = (t3 - t) / (t3 - num) * vector3d + (t - num) / (t3 - num) * vector3d2;
			Vector3d vector3d5 = (t4 - t) / (t4 - t2) * vector3d2 + (t - t2) / (t4 - t2) * vector3d3;
			return (t3 - t) / (t3 - t2) * vector3d4 + (t - t2) / (t3 - t2) * vector3d5;
		}

		private static float GetT(float t, Vector3d p0, Vector3d p1)
		{
			return Mathf.Pow(Mathf.Pow(Mathf.Pow((float)(p1.x - p0.x), 2f) + Mathf.Pow((float)(p1.y - p0.y), 2f) + Mathf.Pow((float)(p1.z - p0.z), 2f), 0.5f), 0.5f) + t;
		}
	}
}
