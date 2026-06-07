using System.Collections.Generic;
using UnityEngine;

namespace MalbersAnimations.PathCreation.Utility
{
	public static class VertexPathUtility
	{
		public class PathSplitData
		{
			public List<Vector3> vertices = new List<Vector3>();

			public List<Vector3> tangents = new List<Vector3>();

			public List<float> cumulativeLength = new List<float>();

			public List<int> anchorVertexMap = new List<int>();

			public MinMax3D minMax = new MinMax3D();
		}

		public static PathSplitData SplitBezierPathByAngleError(BezierPath bezierPath, float maxAngleError, float minVertexDst, float accuracy)
		{
			PathSplitData pathSplitData = new PathSplitData();
			pathSplitData.vertices.Add(bezierPath[0]);
			pathSplitData.tangents.Add(CubicBezierUtility.EvaluateCurveDerivative(bezierPath.GetPointsInSegment(0), 0f).normalized);
			pathSplitData.cumulativeLength.Add(0f);
			pathSplitData.anchorVertexMap.Add(0);
			pathSplitData.minMax.AddValue(bezierPath[0]);
			Vector3 vector = bezierPath[0];
			Vector3 vector2 = bezierPath[0];
			float num = 0f;
			float num2 = 0f;
			for (int i = 0; i < bezierPath.NumSegments; i++)
			{
				Vector3[] pointsInSegment = bezierPath.GetPointsInSegment(i);
				int num3 = Mathf.CeilToInt(CubicBezierUtility.EstimateCurveLength(pointsInSegment[0], pointsInSegment[1], pointsInSegment[2], pointsInSegment[3]) * accuracy);
				float num4 = 1f / (float)num3;
				for (float num5 = num4; num5 <= 1f; num5 += num4)
				{
					bool flag = num5 + num4 > 1f && i == bezierPath.NumSegments - 1;
					if (flag)
					{
						num5 = 1f;
					}
					Vector3 vector3 = CubicBezierUtility.EvaluateCurve(pointsInSegment, num5);
					Vector3 c = CubicBezierUtility.EvaluateCurve(pointsInSegment, num5 + num4);
					float a = 180f - MathUtility.MinAngle(vector, vector3, c);
					float b = 180f - MathUtility.MinAngle(vector2, vector3, c);
					if ((Mathf.Max(a, b) > maxAngleError && num2 >= minVertexDst) || flag)
					{
						num += (vector2 - vector3).magnitude;
						pathSplitData.cumulativeLength.Add(num);
						pathSplitData.vertices.Add(vector3);
						pathSplitData.tangents.Add(CubicBezierUtility.EvaluateCurveDerivative(pointsInSegment, num5).normalized);
						pathSplitData.minMax.AddValue(vector3);
						num2 = 0f;
						vector2 = vector3;
					}
					else
					{
						num2 += (vector3 - vector).magnitude;
					}
					vector = vector3;
				}
				pathSplitData.anchorVertexMap.Add(pathSplitData.vertices.Count - 1);
			}
			return pathSplitData;
		}

		public static PathSplitData SplitBezierPathEvenly(BezierPath bezierPath, float spacing, float accuracy)
		{
			PathSplitData pathSplitData = new PathSplitData();
			pathSplitData.vertices.Add(bezierPath[0]);
			pathSplitData.tangents.Add(CubicBezierUtility.EvaluateCurveDerivative(bezierPath.GetPointsInSegment(0), 0f).normalized);
			pathSplitData.cumulativeLength.Add(0f);
			pathSplitData.anchorVertexMap.Add(0);
			pathSplitData.minMax.AddValue(bezierPath[0]);
			Vector3 vector = bezierPath[0];
			Vector3 vector2 = bezierPath[0];
			float num = 0f;
			float num2 = 0f;
			for (int i = 0; i < bezierPath.NumSegments; i++)
			{
				Vector3[] pointsInSegment = bezierPath.GetPointsInSegment(i);
				int num3 = Mathf.CeilToInt(CubicBezierUtility.EstimateCurveLength(pointsInSegment[0], pointsInSegment[1], pointsInSegment[2], pointsInSegment[3]) * accuracy);
				float num4 = 1f / (float)num3;
				for (float num5 = num4; num5 <= 1f; num5 += num4)
				{
					bool flag = num5 + num4 > 1f && i == bezierPath.NumSegments - 1;
					if (flag)
					{
						num5 = 1f;
					}
					Vector3 vector3 = CubicBezierUtility.EvaluateCurve(pointsInSegment, num5);
					num2 += (vector3 - vector).magnitude;
					if (num2 > spacing)
					{
						float num6 = num2 - spacing;
						vector3 += (vector - vector3).normalized * num6;
						num5 -= num4;
					}
					if (num2 >= spacing || flag)
					{
						num += (vector2 - vector3).magnitude;
						pathSplitData.cumulativeLength.Add(num);
						pathSplitData.vertices.Add(vector3);
						pathSplitData.tangents.Add(CubicBezierUtility.EvaluateCurveDerivative(pointsInSegment, num5).normalized);
						pathSplitData.minMax.AddValue(vector3);
						num2 = 0f;
						vector2 = vector3;
					}
					vector = vector3;
				}
				pathSplitData.anchorVertexMap.Add(pathSplitData.vertices.Count - 1);
			}
			return pathSplitData;
		}
	}
}
