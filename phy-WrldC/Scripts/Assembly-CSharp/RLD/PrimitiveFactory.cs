using System;
using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public static class PrimitiveFactory
	{
		public enum PolyBorderDirection
		{
			Inward = 0,
			Outward = 1
		}

		public static List<Vector2> Generate2DPolyBorderQuadsCW(List<Vector2> cwPolyPoints, List<Vector2> cwBorderPts, PolyBorderDirection borderDirection, bool isClosed)
		{
			if (cwPolyPoints.Count != cwBorderPts.Count)
			{
				return new List<Vector2>();
			}
			int num = cwPolyPoints.Count - 1;
			if (isClosed && num < 3)
			{
				return new List<Vector2>();
			}
			if (!isClosed && num < 2)
			{
				return new List<Vector2>();
			}
			List<Vector2> list = new List<Vector2>(num * 4);
			if (borderDirection == PolyBorderDirection.Outward)
			{
				for (int i = 0; i < cwPolyPoints.Count - 1; i++)
				{
					list.Add(cwPolyPoints[i]);
					list.Add(cwBorderPts[i]);
					list.Add(cwBorderPts[i + 1]);
					list.Add(cwPolyPoints[i + 1]);
				}
			}
			else
			{
				for (int j = 0; j < cwPolyPoints.Count - 1; j++)
				{
					list.Add(cwPolyPoints[j]);
					list.Add(cwPolyPoints[j + 1]);
					list.Add(cwBorderPts[j + 1]);
					list.Add(cwBorderPts[j]);
				}
			}
			return list;
		}

		public static float PolyBorderDirToSign(PolyBorderDirection borderDirection)
		{
			if (borderDirection != PolyBorderDirection.Inward)
			{
				return 1f;
			}
			return -1f;
		}

		public static List<Vector2> Generate2DPolyBorderPointsCW(List<Vector2> cwPolyPoints, PolyBorderDirection borderDirection, float borderThickness, bool isClosed)
		{
			int num = cwPolyPoints.Count - 1;
			if (isClosed && num < 3)
			{
				return new List<Vector2>();
			}
			if (!isClosed && num < 2)
			{
				return new List<Vector2>();
			}
			float num2 = borderThickness * PolyBorderDirToSign(borderDirection);
			List<Vector2> list = new List<Vector2>(cwPolyPoints.Count);
			if (isClosed)
			{
				Vector2 vector = cwPolyPoints[0];
				Vector2 normal = (cwPolyPoints[1] - vector).GetNormal();
				Vector2 vector2 = cwPolyPoints[cwPolyPoints.Count - 2];
				Vector2 vector3 = cwPolyPoints[cwPolyPoints.Count - 1];
				Vector2 normal2 = (vector3 - vector2).GetNormal();
				Vector2 normalized = (vector3 - vector2).normalized;
				Vector2 vector4 = vector2 + normal2 * num2;
				if (PlaneMath.Raycast2D(vector4, normalized, normal, vector + normal * num2, out var t))
				{
					list.Add(vector4 + normalized * t);
				}
				else
				{
					list.Add(vector);
				}
				for (int i = 0; i < num - 1; i++)
				{
					Vector2 vector5 = cwPolyPoints[i];
					Vector2 vector6 = cwPolyPoints[i + 1];
					Vector2 vector7 = list[i];
					Vector2 vector8 = cwPolyPoints[i + 2];
					Vector2 normal3 = (vector8 - vector6).GetNormal();
					Vector2 ptOnPlane = vector8 + normal3 * num2;
					normalized = (vector6 - vector5).normalized;
					if (PlaneMath.Raycast2D(vector7, normalized, normal3, ptOnPlane, out t))
					{
						list.Add(vector7 + normalized * t);
					}
				}
				list.Add(list[0]);
				return list;
			}
			Vector2 vector9 = cwPolyPoints[0];
			Vector2 vector10 = cwPolyPoints[1];
			Vector2 normal4 = (vector10 - vector9).GetNormal();
			list.Add(vector9 + normal4 * num2);
			for (int j = 0; j < num - 1; j++)
			{
				Vector2 vector11 = cwPolyPoints[j];
				Vector2 vector12 = cwPolyPoints[j + 1];
				Vector2 vector13 = list[j];
				Vector2 vector14 = cwPolyPoints[j + 2];
				Vector2 normal5 = (vector14 - vector12).GetNormal();
				Vector2 ptOnPlane2 = vector14 + normal5 * num2;
				Vector2 normalized2 = (vector12 - vector11).normalized;
				if (PlaneMath.Raycast2D(vector13, normalized2, normal5, ptOnPlane2, out var t2))
				{
					list.Add(vector13 + normalized2 * t2);
				}
			}
			vector9 = cwPolyPoints[cwPolyPoints.Count - 2];
			vector10 = cwPolyPoints[cwPolyPoints.Count - 1];
			normal4 = (vector10 - vector9).GetNormal();
			list.Add(vector10 + normal4 * num2);
			return list;
		}

		public static List<Vector2> Generate2DCircleBorderPointsCW(Vector2 circleCenter, float circleRadius, int numPoints)
		{
			numPoints = Mathf.Max(numPoints, 4);
			List<Vector2> list = new List<Vector2>(numPoints);
			float num = 360f / (float)(numPoints - 1);
			for (int i = 0; i < numPoints; i++)
			{
				float f = num * (float)i * ((float)Math.PI / 180f);
				list.Add(circleCenter + new Vector2(Mathf.Sin(f) * circleRadius, Mathf.Cos(f) * circleRadius));
			}
			return list;
		}

		public static List<Vector3> Generate3DCircleBorderPoints(Vector3 circleCenter, float circleRadius, Vector3 circleRight, Vector3 circleUp, int numPoints)
		{
			numPoints = Mathf.Max(numPoints, 4);
			List<Vector3> list = new List<Vector3>(numPoints);
			float num = 360f / (float)(numPoints - 1);
			for (int i = 0; i < numPoints; i++)
			{
				float f = num * (float)i * ((float)Math.PI / 180f);
				list.Add(circleCenter + circleRight * Mathf.Sin(f) * circleRadius + circleUp * Mathf.Cos(f) * circleRadius);
			}
			return list;
		}

		public static List<Vector3> GenerateSphereBorderPoints(Camera camera, Vector3 sphereCenter, float sphereRadius, int numPoints)
		{
			if (numPoints < 3)
			{
				return new List<Vector3>();
			}
			Transform transform = camera.transform;
			List<Vector3> list = Generate3DCircleBorderPoints(sphereCenter, sphereRadius, transform.right, transform.up, numPoints);
			for (int i = 0; i < numPoints; i++)
			{
				Vector3 vector = list[i];
				Vector3 normalized = (vector - sphereCenter).normalized;
				Vector3 vector2 = (vector - transform.position).normalized;
				if (camera.orthographic)
				{
					vector2 = transform.forward;
				}
				float num = Vector3.Dot(normalized, vector2);
				if (Mathf.Abs(num) > 1E-05f)
				{
					float num2 = MathEx.SafeAcos(num) * 57.29578f;
					Vector3 normalized2 = Vector3.Cross(vector2, normalized).normalized;
					normalized = (Quaternion.AngleAxis(90f - num2, normalized2) * normalized).normalized;
					list[i] = sphereCenter + normalized * sphereRadius;
				}
			}
			return list;
		}

		public static List<Vector2> Generate2DArcBorderPoints(Vector2 arcOrigin, Vector2 arcStartPoint, float degreesFromStart, bool forceShortestArc, int numPoints)
		{
			if (numPoints < 2)
			{
				return new List<Vector2>();
			}
			List<Vector2> list = new List<Vector2>(numPoints);
			degreesFromStart %= 360f;
			Vector2 vector = arcStartPoint - arcOrigin;
			Quaternion.AngleAxis(degreesFromStart, Vector3.forward);
			float magnitude = vector.magnitude;
			vector.Normalize();
			if (forceShortestArc)
			{
				degreesFromStart = ArcMath.ConvertToSh2DArcAngle(arcOrigin, arcStartPoint, degreesFromStart);
			}
			float num = degreesFromStart / (float)(numPoints - 1);
			for (int i = 0; i < numPoints; i++)
			{
				Vector2 vector2 = (Quaternion.AngleAxis((float)i * num, Vector3.forward) * vector).normalized;
				list.Add(arcOrigin + vector2 * magnitude);
			}
			return list;
		}

		public static List<Vector2> ProjectArcPointsOnPoly2DBorder(Vector2 arcOrigin, List<Vector2> arcPoints, List<Vector2> clockwisePolyPoints)
		{
			if (arcPoints.Count < 2 || clockwisePolyPoints.Count < 3)
			{
				return new List<Vector2>();
			}
			int count = clockwisePolyPoints.Count;
			List<Vector2> list = new List<Vector2>(arcPoints.Count);
			foreach (Vector2 arcPoint in arcPoints)
			{
				for (int i = 0; i < count; i++)
				{
					Vector2 vector = clockwisePolyPoints[i];
					Vector2 vec = clockwisePolyPoints[(i + 1) % count] - vector;
					Plane2D plane2D = new Plane2D(vec.GetNormal(), vector);
					Vector2 normalized = (arcPoint - arcOrigin).normalized;
					if (plane2D.Raycast(arcOrigin, normalized, out var t))
					{
						Vector2 vector2 = arcOrigin + normalized * t;
						float num = Vector2.Dot(vector2 - vector, vec.normalized);
						if (num >= 0f && num <= vec.magnitude)
						{
							list.Add(vector2);
							break;
						}
					}
				}
			}
			return list;
		}

		public static List<Vector3> Generate3DArcBorderPoints(Vector3 arcOrigin, Vector3 arcStartPoint, Plane arcPlane, float degreesFromStart, bool forceShortestArc, int numPoints)
		{
			if (numPoints < 2)
			{
				return new List<Vector3>();
			}
			List<Vector3> list = new List<Vector3>(numPoints);
			degreesFromStart %= 360f;
			arcOrigin = arcPlane.ProjectPoint(arcOrigin);
			arcStartPoint = arcPlane.ProjectPoint(arcStartPoint);
			Vector3 vector = arcStartPoint - arcOrigin;
			Quaternion.AngleAxis(degreesFromStart, arcPlane.normal);
			float magnitude = vector.magnitude;
			vector.Normalize();
			if (forceShortestArc)
			{
				degreesFromStart = ArcMath.ConvertToSh3DArcAngle(arcOrigin, arcStartPoint, arcPlane.normal, degreesFromStart);
			}
			float num = degreesFromStart / (float)(numPoints - 1);
			for (int i = 0; i < numPoints; i++)
			{
				Vector3 normalized = (Quaternion.AngleAxis((float)i * num, arcPlane.normal) * vector).normalized;
				list.Add(arcOrigin + normalized * magnitude);
			}
			return list;
		}
	}
}
