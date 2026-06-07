using System;
using System.Collections.Generic;
using Motorways.Models;
using Motorways.Utility;
using UnityEngine;

namespace Motorways.Views
{
	public class MotorwaySpline
	{
		private struct HandleData
		{
			public Vector2 tilePosition;

			public Vector2 splinePosition;

			public Vector2 tileHandlePosition;

			public Vector2 direction;

			public float proxmityToEnd;
		}

		public struct ClosestPointsOnSegment
		{
			public Vector2 AB;

			public Vector2 CD;

			public ClosestPointsOnSegment(Vector2 ab, Vector2 cd)
			{
				AB = ab;
				CD = cd;
			}
		}

		public Spline.PiecewiseBezierSpline spline;

		private const int _rasterizedResolution = 10;

		private const int _splineExtensionLength = 2;

		public List<float> CalculateEvenlySpacedSamples(float distanceBetweenSamples, int resolution = 100)
		{
			float num = spline.Length();
			List<float> list = new List<float>((int)(num / distanceBetweenSamples) + 1) { 0f };
			float num2 = 0f;
			int num3 = Mathf.CeilToInt(num * (float)resolution);
			float num4 = 1f / (float)num3;
			float num5 = num4;
			Vector2 a = spline.segments[0].inPoint;
			for (; num5 <= 1f; num5 += num4)
			{
				Vector2 vector = spline.Evaluate(num5);
				float num6 = num2 + Vector2.Distance(a, vector);
				if (num6 >= distanceBetweenSamples)
				{
					list.Add(num5);
					num6 = 0f;
				}
				num2 = num6;
				a = vector;
			}
			return list;
		}

		public void CalculateLinearDistanceLookupTable(float[] linearDistanceTable)
		{
			float num = 0f;
			linearDistanceTable[0] = 0f;
			Vector2 a = spline.segments[0].inPoint;
			for (int i = 1; i < linearDistanceTable.Length; i++)
			{
				float t = (float)i / (float)(linearDistanceTable.Length - 1);
				Vector2 vector = spline.Evaluate(t);
				float num2 = Vector2.Distance(a, vector);
				num = (linearDistanceTable[i] = num + num2);
				a = vector;
			}
		}

		public void RebuildSegments(TileDirection startDirection, TileDirection endDirection, Vector2 startCoordinatesWorldSpace, Vector2 endCoordinatesWorldSpace, Vector2 splineMidpoint, Vector2 naturalMidpoint, Vector2 naturalTangent, float naturalStartHandleLength, float naturalEndHandleLength)
		{
			HandleData handleData = CalculateHandleData(startDirection, startCoordinatesWorldSpace, splineMidpoint, naturalMidpoint, naturalStartHandleLength);
			HandleData handleData2 = CalculateHandleData(endDirection, endCoordinatesWorldSpace, splineMidpoint, naturalMidpoint, naturalEndHandleLength);
			Vector2 vector = -naturalTangent * (naturalStartHandleLength + naturalEndHandleLength) * 0.25f;
			Vector2 vector2 = -vector;
			spline = new Spline.PiecewiseBezierSpline(new Spline.BezierSpline[2]
			{
				new Spline.BezierSpline(new Vector2(handleData.splinePosition.x, handleData.splinePosition.y), new Vector2(handleData.tileHandlePosition.x, handleData.tileHandlePosition.y), new Vector2((vector + splineMidpoint).x, (vector + splineMidpoint).y), new Vector2(splineMidpoint.x, splineMidpoint.y)),
				new Spline.BezierSpline(new Vector2(splineMidpoint.x, splineMidpoint.y), new Vector2((splineMidpoint + vector2).x, (splineMidpoint + vector2).y), new Vector2(handleData2.tileHandlePosition.x, handleData2.tileHandlePosition.y), new Vector2(handleData2.splinePosition.x, handleData2.splinePosition.y))
			});
		}

		private HandleData CalculateHandleData(TileDirection tileDirection, Vector2 tileCoordinatesWorldspace, Vector2 splineMidpoint, Vector2 naturalMidpoint, float naturalHandleLength)
		{
			float num = (float)TilemapModel.HalfTileWidth;
			float num2 = Mathf.Sqrt(2f * (float)TilemapModel.HalfTileWidth) - num;
			HandleData result = default(HandleData);
			result.direction = TileUtilities.GetVectorForDirection(tileDirection);
			result.tilePosition = tileCoordinatesWorldspace + result.direction * num;
			result.splinePosition = result.tilePosition + (TileUtilities.IsDirectionDiagonal(tileDirection) ? (result.direction * num2) : Vector2.zero);
			result.proxmityToEnd = (result.tilePosition - splineMidpoint).magnitude / (result.tilePosition - naturalMidpoint).magnitude;
			result.tileHandlePosition = result.splinePosition + result.direction * naturalHandleLength * 0.5f * result.proxmityToEnd;
			return result;
		}

		public Vector4[] GenerateHazardTapeStripeSamples(float distanceBetweenStripes, float stripeRotationDegrees, float motorwayWidth, float maxHazardStripeWidth, int maxSamples, bool shouldCorrectStripes = true)
		{
			List<float> list = CalculateEvenlySpacedSamples(distanceBetweenStripes);
			Vector4[] array = new Vector4[maxSamples];
			int num = Math.Min(maxSamples, list.Count);
			for (int i = 0; i < num; i++)
			{
				float t = list[i];
				Vector2 vector = spline.Evaluate(t);
				Vector2 normalized = spline.EvaluateTangent(t).Rotated((0f - stripeRotationDegrees) * ((float)Math.PI / 180f)).normalized;
				array[i] = new Vector4(vector.x, vector.y, normalized.x, normalized.y);
			}
			if (shouldCorrectStripes)
			{
				CorrectOverrotatedStripes(array, num, motorwayWidth, maxHazardStripeWidth);
			}
			return array;
		}

		private float StripeEdgeTestLength(float motorwayWidth)
		{
			return 1.5f * motorwayWidth;
		}

		public void CorrectOverrotatedStripes(Vector4[] hazardTapeSamples, int sampleCount, float motorwayWidth, float maxHazardStripeWidth)
		{
			float num = 0.5f * motorwayWidth;
			Spline.RasterizedSpline rasterizedSpline = spline.Offset(num, 10);
			rasterizedSpline.ExtendOutAtEnds(2f);
			Spline.RasterizedSpline rasterizedSpline2 = spline.Offset(0f - num, 10);
			rasterizedSpline2.ExtendOutAtEnds(2f);
			float num2 = StripeEdgeTestLength(motorwayWidth);
			for (int i = 0; i < sampleCount; i++)
			{
				Vector4 vector = hazardTapeSamples[i];
				Vector2 vector2 = new Vector2(vector.x, vector.y);
				Vector2 vector3 = new Vector2(vector.z, vector.w);
				Vector2 normal = vector3.GetNormal();
				Vector2 vector4 = vector2 - vector3 * 0.5f * maxHazardStripeWidth;
				Vector2 vector5 = vector4 - normal * num2;
				Vector2 vector6 = vector4 + normal * num2;
				Vector2 edgeStart = vector5 + vector3 * maxHazardStripeWidth;
				Vector2 edgeEnd = vector6 + vector3 * maxHazardStripeWidth;
				float num3 = ComputeCorrectionRotationForEdge(vector5, vector6, vector2, rasterizedSpline2, rasterizedSpline);
				if ((double)num3 == 0.0)
				{
					num3 = ComputeCorrectionRotationForEdge(edgeStart, edgeEnd, vector2, rasterizedSpline2, rasterizedSpline);
				}
				if ((double)num3 != 0.0)
				{
					Vector2 vector7 = -vector3.Rotated(num3);
					hazardTapeSamples[i].z = vector7.x;
					hazardTapeSamples[i].w = vector7.y;
				}
			}
		}

		private int FindLineSegmentCircleIntersections(Vector2 center, float radius, Vector2 start, Vector2 end, out Vector2 intersectionA, out Vector2 intersectionB)
		{
			Vector2 vector = end - start;
			float num = vector.x * vector.x + vector.y * vector.y;
			float num2 = 2f * (vector.x * (start.x - center.x) + vector.y * (start.y - center.y));
			float num3 = (start.x - center.x) * (start.x - center.x) + (start.y - center.y) * (start.y - center.y) - radius * radius;
			float num4 = num2 * num2 - 4f * num * num3;
			if ((double)num <= 1E-07 || num4 < 0f)
			{
				intersectionA.x = (intersectionA.y = float.NaN);
				intersectionB.x = (intersectionB.y = float.NaN);
				return 0;
			}
			float num5;
			if (num4 == 0f)
			{
				num5 = (0f - num2) / (2f * num);
				intersectionA.x = start.x + num5 * vector.x;
				intersectionA.y = start.y + num5 * vector.y;
				intersectionB.x = (intersectionB.y = float.NaN);
				return 1;
			}
			num5 = (float)(((double)(0f - num2) + Math.Sqrt(num4)) / (double)(2f * num));
			intersectionA.x = start.x + num5 * vector.x;
			intersectionA.y = start.y + num5 * vector.y;
			num5 = (float)(((double)(0f - num2) - Math.Sqrt(num4)) / (double)(2f * num));
			intersectionB.x = start.x + num5 * vector.x;
			intersectionB.y = start.y + num5 * vector.y;
			return 2;
		}

		private float CalculateStripeCorrectionRotation(Spline.RasterizedSpline spline, Vector2 stripeCenter, Vector2 stripeEdgeStart, Vector2 stripeEdgeEnd)
		{
			ClosestPointsOnSegment closestPointsOnSegment = ClosestPointOnSplineToLineSegment(spline, stripeEdgeStart, stripeEdgeEnd);
			float radius = Vector2.Distance(stripeCenter, closestPointsOnSegment.CD);
			Vector2 intersectionA;
			Vector2 intersectionB;
			int num = FindLineSegmentCircleIntersections(stripeCenter, radius, stripeEdgeStart, stripeEdgeEnd, out intersectionA, out intersectionB);
			if (num >= 1)
			{
				Vector2 vector = intersectionA;
				if (num >= 2)
				{
					float sqrMagnitude = (closestPointsOnSegment.CD - intersectionA).sqrMagnitude;
					if ((closestPointsOnSegment.CD - intersectionB).sqrMagnitude < sqrMagnitude)
					{
						vector = intersectionB;
					}
				}
				Vector2 normalized = (vector - stripeCenter).normalized;
				Vector2 normalized2 = (closestPointsOnSegment.CD - stripeCenter).normalized;
				return Mathf.Acos(Vector2.Dot(normalized, normalized2));
			}
			return 0f;
		}

		private float ComputeCorrectionRotationForEdge(Vector2 edgeStart, Vector2 edgeEnd, Vector2 centre, Spline.RasterizedSpline leftSpline, Spline.RasterizedSpline rightSpline)
		{
			Vector2 direction = edgeEnd - edgeStart;
			int num = leftSpline.ComputeIntersectionCountWithLineSegment(edgeStart, direction);
			int num2 = rightSpline.ComputeIntersectionCountWithLineSegment(edgeStart, direction);
			if (num == 0 && num2 != 0)
			{
				return CalculateStripeCorrectionRotation(leftSpline, centre, edgeStart, edgeEnd);
			}
			if (num != 0 && num2 == 0)
			{
				return CalculateStripeCorrectionRotation(rightSpline, centre, edgeStart, edgeEnd);
			}
			return 0f;
		}

		public static (int closestStartIndex, int closestEndIndex) ClosestEdgeOnSplineToPoint(Spline.RasterizedSpline spline, Vector2 point)
		{
			int item = -1;
			int item2 = -1;
			float num = float.MaxValue;
			int num2 = 1;
			int num3 = 0;
			while (num2 < spline.Positions.Count)
			{
				Vector2 vector = spline.Positions[num2];
				float num4 = Vector2.SqrMagnitude((spline.Positions[num3] + vector) / 2f - point);
				if (num4 < num)
				{
					item = num3;
					item2 = num2;
					num = num4;
				}
				num3 = num2++;
			}
			return (closestStartIndex: item, closestEndIndex: item2);
		}

		public static Vector2 ClosestPointOnLineSegmentToPoint(Vector2 P1, Vector2 P2, Vector2 P3)
		{
			float num = ((P3.x - P1.x) * (P2.x - P1.x) + (P3.y - P1.y) * (P2.y - P1.y)) / (P2 - P1).sqrMagnitude;
			if (num <= 0f)
			{
				return P1;
			}
			if (num >= 1f)
			{
				return P2;
			}
			return new Vector2(P1.x + num * (P2.x - P1.x), P1.y + num * (P2.y - P1.y));
		}

		public static ClosestPointsOnSegment ClosestPointOnLineSegmentToLineSegment(Vector2 A, Vector2 B, Vector2 C, Vector2 D)
		{
			Vector2 vector = ClosestPointOnLineSegmentToPoint(C, D, A);
			Vector2 vector2 = ClosestPointOnLineSegmentToPoint(C, D, B);
			Vector2 vector3 = ClosestPointOnLineSegmentToPoint(A, B, C);
			Vector2 vector4 = ClosestPointOnLineSegmentToPoint(A, B, D);
			float sqrMagnitude = (A - vector).sqrMagnitude;
			float sqrMagnitude2 = (B - vector2).sqrMagnitude;
			float sqrMagnitude3 = (C - vector3).sqrMagnitude;
			float sqrMagnitude4 = (D - vector4).sqrMagnitude;
			if (sqrMagnitude < sqrMagnitude2 && sqrMagnitude < sqrMagnitude3 && sqrMagnitude < sqrMagnitude4)
			{
				return new ClosestPointsOnSegment(A, vector);
			}
			if (sqrMagnitude2 < sqrMagnitude3 && sqrMagnitude2 < sqrMagnitude4)
			{
				return new ClosestPointsOnSegment(B, vector2);
			}
			if (sqrMagnitude3 < sqrMagnitude4)
			{
				return new ClosestPointsOnSegment(vector3, C);
			}
			return new ClosestPointsOnSegment(vector4, D);
		}

		public static ClosestPointsOnSegment ClosestPointOnSplineToLineSegment(Spline.RasterizedSpline spline, Vector2 A, Vector2 B)
		{
			List<ClosestPointsOnSegment> list = new List<ClosestPointsOnSegment>();
			for (int i = 0; i < spline.Positions.Count - 1; i++)
			{
				Vector2 c = spline.Positions[i];
				Vector2 d = spline.Positions[i + 1];
				list.Add(ClosestPointOnLineSegmentToLineSegment(A, B, c, d));
			}
			float num = float.MaxValue;
			int index = -1;
			for (int j = 0; j < list.Count; j++)
			{
				ClosestPointsOnSegment closestPointsOnSegment = list[j];
				float sqrMagnitude = (closestPointsOnSegment.AB - closestPointsOnSegment.CD).sqrMagnitude;
				if (sqrMagnitude < num)
				{
					index = j;
					num = sqrMagnitude;
				}
			}
			return list[index];
		}

		public Vector4[] PackSplineSegments()
		{
			Spline.BezierSpline[] segments = spline.segments;
			return new Vector4[4]
			{
				new Vector4(segments[0].inPoint.x, segments[0].inPoint.y, segments[0].inHandle.x, segments[0].inHandle.y),
				new Vector4(segments[0].outHandle.x, segments[0].outHandle.y, segments[0].outPoint.x, segments[0].outPoint.y),
				new Vector4(segments[1].inPoint.x, segments[1].inPoint.y, segments[1].inHandle.x, segments[1].inHandle.y),
				new Vector4(segments[1].outHandle.x, segments[1].outHandle.y, segments[1].outPoint.x, segments[1].outPoint.y)
			};
		}

		public Vector4[] AddShadowOffsetToSplineSegments(Vector4[] splineSegments, float shadowOffset)
		{
			Vector4[] array = new Vector4[splineSegments.Length];
			Array.Copy(splineSegments, array, splineSegments.Length);
			Vector4 vector = new Vector4(shadowOffset, 0f - shadowOffset, shadowOffset, 0f - shadowOffset);
			array[1] += vector;
			array[2] += vector;
			return array;
		}

		public MotorwaySpline Clone()
		{
			if (spline?.segments == null)
			{
				return new MotorwaySpline();
			}
			Spline.BezierSpline[] array = new Spline.BezierSpline[spline.segments.Length];
			for (int i = 0; i < spline.segments.Length; i++)
			{
				Spline.BezierSpline bezierSpline = spline.segments[i];
				array[i] = new Spline.BezierSpline(bezierSpline.inPoint, bezierSpline.inHandle, bezierSpline.inHandle, bezierSpline.outPoint);
			}
			Spline.PiecewiseBezierSpline piecewiseBezierSpline = new Spline.PiecewiseBezierSpline(array);
			return new MotorwaySpline
			{
				spline = piecewiseBezierSpline
			};
		}
	}
}
