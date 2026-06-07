using System;
using System.Collections.Generic;
using UnityEngine;

namespace DV.PointSet
{
	public class EquiPointSet
	{
		public struct Point
		{
			public Vector3d position;

			public Vector3 forward;

			public Vector3 up;

			public double span;

			public double spanToNextPoint;

			public int index;

			public Point(Vector3d position, Vector3 forward, Vector3 up, int pointIndex)
			{
				this.position = position;
				this.forward = forward;
				this.up = up;
				index = pointIndex;
				span = -1.0;
				spanToNextPoint = -1.0;
			}
		}

		public Point[] points;

		public double span;

		public static EquiPointSet FromBezierNonEquidistant(BezierCurve curve)
		{
			if (curve == null)
			{
				throw new ArgumentNullException("curve");
			}
			if (curve.pointCount < 2)
			{
				throw new ArgumentException("Curve must have at least 2 points", "curve");
			}
			BezierPoint[] anchorPoints = curve.GetAnchorPoints();
			List<Point> list = new List<Point>();
			Vector3d vector3d = new Vector3d(curve.transform.position);
			Quaternion rotation = curve.transform.rotation;
			for (int i = 0; i < curve.pointCount - 1; i++)
			{
				BezierPoint bezierPoint = anchorPoints[i];
				BezierPoint bezierPoint2 = anchorPoints[i + 1];
				int numPoints = BezierCurve.GetNumPoints(bezierPoint, bezierPoint2, curve.resolution);
				for (int j = 0; j < numPoints; j++)
				{
					float t = 1f / (float)numPoints * (float)j;
					Vector3 v = rotation * BezierCurve.GetPointLocal(bezierPoint, bezierPoint2, t);
					Vector3 forward = rotation * curve.GetLocalTangent(bezierPoint, bezierPoint2, t);
					Point item = new Point(new Vector3d(v) + vector3d, forward, Vector3.up, list.Count);
					list.Add(item);
				}
			}
			BezierPoint bezierPoint3 = curve.Last();
			Point item2 = new Point(new Vector3d(rotation * bezierPoint3.localPosition) + vector3d, Vector3.zero, Vector3.up, list.Count);
			list.Add(item2);
			Point[] array = list.ToArray();
			if (curve[0].handle2 == Vector3.zero)
			{
				array[0].forward = array[1].forward;
			}
			else
			{
				array[0].forward = curve.transform.TransformDirection(curve[0].handle2.normalized);
			}
			if (curve.Last().handle2 == Vector3.zero)
			{
				array[array.Length - 1].forward = array[array.Length - 2].forward;
			}
			else
			{
				array[array.Length - 1].forward = curve.transform.TransformDirection(curve.Last().handle2.normalized);
			}
			EquiPointSet equiPointSet = new EquiPointSet();
			equiPointSet.points = array;
			equiPointSet.RecalculateSpans();
			return equiPointSet;
		}

		public void RotateAroundPoint(Vector3d rotateAnchorWorldPosition, Quaternion rotationToApply)
		{
			for (int i = 0; i < points.Length; i++)
			{
				Vector3d vector3d = points[i].position - rotateAnchorWorldPosition;
				Vector3 v = rotationToApply * (Vector3)vector3d;
				points[i].position = rotateAnchorWorldPosition + new Vector3d(v);
				points[i].forward = rotationToApply * points[i].forward;
			}
		}

		public static EquiPointSet FromBezierEquidistant(BezierCurve curve, float pointSpacing, float startOffset = 0f, bool fitEvenly = false, bool overrideLastPoint = true)
		{
			return ResampleEquidistant(FromBezierNonEquidistant(curve), pointSpacing, startOffset, fitEvenly, overrideLastPoint);
		}

		public static EquiPointSet ResampleEquidistant(EquiPointSet source, float pointSpacing, float startOffset = 0f, bool fitEvenly = false, bool overrideLastPoint = true)
		{
			if (pointSpacing <= 0f)
			{
				throw new ArgumentOutOfRangeException("Spacing must be positive", "pointSpacing");
			}
			if ((double)pointSpacing > source.span / 2.0)
			{
				throw new ArgumentOutOfRangeException("Spacing must be smaller than half of source's span/length", "pointSpacing");
			}
			if (startOffset < 0f)
			{
				throw new ArgumentOutOfRangeException("Equidistant points' start offset cannot be negative", "startOffset");
			}
			if (startOffset >= pointSpacing)
			{
				throw new ArgumentOutOfRangeException("Equidistant points' start offset must be smaller than point spacing", "startOffset");
			}
			Point[] array = Equidistant(source.points, source.span, pointSpacing, startOffset, fitEvenly, overrideLastPoint);
			EquiPointSet equiPointSet = new EquiPointSet();
			equiPointSet.points = array;
			equiPointSet.RecalculateSpans();
			return equiPointSet;
		}

		private static Point[] Equidistant(Point[] inputPoints, double inputPointSpan, float separation, float startOffset = 0f, bool fitEvenly = false, bool overrideLastPoint = true)
		{
			int num = Mathf.CeilToInt((float)((inputPointSpan - (double)startOffset) / (double)separation));
			if (fitEvenly && startOffset != 0f)
			{
				double num2 = (overrideLastPoint ? startOffset : (startOffset * 2f));
				separation = (float)((inputPointSpan - num2) / (double)num);
				num++;
			}
			Point[] array = new Point[num];
			int num3 = -1;
			double num4 = startOffset;
			if (startOffset == 0f)
			{
				num4 = Mathf.Epsilon;
			}
			double num5 = 0.0;
			double num6 = 0.0;
			Vector3d vector3d = Vector3d.forward;
			for (int i = 0; i < num; i++)
			{
				int num7 = 0;
				while (num4 > num5)
				{
					num3++;
					if (num3 + 1 >= inputPoints.Length)
					{
						break;
					}
					num6 = Vector3d.Distance(inputPoints[num3].position, inputPoints[num3 + 1].position);
					num5 += num6;
					vector3d = (inputPoints[num3 + 1].position - inputPoints[num3].position).normalized;
					if (++num7 > 100)
					{
						throw new InvalidOperationException("Potentially stuck in infinite loop, bailing out");
					}
				}
				double num8 = num4 - (num5 - num6);
				Vector3d position = inputPoints[num3].position + vector3d * num8;
				array[i] = new Point(position, (Vector3)vector3d, Vector3.up, i);
				num4 += (double)separation;
			}
			if (overrideLastPoint)
			{
				Point point = inputPoints[inputPoints.Length - 1];
				Point point2 = new Point(point.position, point.forward, point.up, array.Length - 1);
				point2.span = point.span;
				point2.spanToNextPoint = 0.0;
				array[array.Length - 1] = point2;
			}
			return array;
		}

		public void RecalculateSpans()
		{
			double num = 0.0;
			points[0].span = 0.0;
			for (int i = 0; i < points.Length; i++)
			{
				double num2 = ((i != points.Length - 1) ? Vector3d.Distance(points[i].position, points[i + 1].position) : 0.0);
				points[i].span = num;
				points[i].spanToNextPoint = num2;
				num += num2;
			}
			span = num;
		}

		public int GetPointIndexForSpan(double span)
		{
			if (span < 0.0)
			{
				throw new ArgumentOutOfRangeException("Given span must be positive", "span");
			}
			if (span > this.span)
			{
				throw new ArgumentOutOfRangeException("Given span is larger than pointset's span", "span");
			}
			if (span == 0.0)
			{
				return 0;
			}
			if (span == this.span)
			{
				return points.Length - 2;
			}
			for (int i = 0; i < points.Length; i++)
			{
				if (points[i].span > span)
				{
					return Mathf.Clamp(i - 1, 0, points.Length - 2);
				}
			}
			return points.Length - 2;
		}
	}
}
