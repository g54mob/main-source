using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Barmetler.RoadSystem
{
	public static class Bezier
	{
		public struct OrientedPoint
		{
			public Vector3 position;

			public Vector3 forward;

			public Vector3 normal;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public OrientedPoint(Vector3 p, Vector3 f, Vector3 n)
			{
				position = p;
				forward = f;
				normal = n;
			}

			public OrientedPoint ToWorldSpace(Transform transform)
			{
				Vector3 p = transform.TransformPoint(position);
				Vector3 f = transform.TransformDirection(forward);
				Vector3 n = transform.TransformDirection(normal);
				return new OrientedPoint(p, f, n);
			}

			public OrientedPoint ToLocalSpace(Transform transform)
			{
				Vector3 p = transform.InverseTransformPoint(position);
				Vector3 f = transform.InverseTransformDirection(forward);
				Vector3 n = transform.InverseTransformDirection(normal);
				return new OrientedPoint(p, f, n);
			}
		}

		[BurstCompile(CompileSynchronously = true)]
		private struct GetEvenlySpacedPointsBurstJob : IJob
		{
			private struct Segment
			{
				public float3 p0;

				public float3 p1;

				public float3 p2;

				public float3 p3;

				public float3 this[int i] => i switch
				{
					0 => p0, 
					1 => p1, 
					2 => p2, 
					3 => p3, 
					_ => throw new ArgumentOutOfRangeException(), 
				};

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public Segment(float3 p0, float3 p1, float3 p2, float3 p3)
				{
					this.p0 = p0;
					this.p1 = p1;
					this.p2 = p2;
					this.p3 = p3;
				}
			}

			[ReadOnly]
			public NativeArray<Vector3> Points;

			[ReadOnly]
			public NativeArray<Vector3> Normals;

			[ReadOnly]
			public float Spacing;

			[ReadOnly]
			public float Resolution;

			public NativeList<OrientedPoint> Result;

			public NativeArray<Bounds> Bounds;

			public NativeList<Bounds> BoundingBoxes;

			public NativeArray<float> LineLength;

			private int _numPoints;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private int LoopIndex(int i)
			{
				return (i % _numPoints + _numPoints) % _numPoints;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private Segment GetPointsInSegment(int i)
			{
				return new Segment(Points[i * 3], Points[i * 3 + 1], Points[i * 3 + 2], Points[LoopIndex(i * 3 + 3)]);
			}

			public void Execute()
			{
				_numPoints = Points.Length;
				int num = _numPoints / 3;
				if (Normals.Length < num + 1)
				{
					throw new ArgumentException("not enough normals!");
				}
				Bounds value = Bounds[0];
				value.min = Vector3.positiveInfinity;
				value.max = Vector3.negativeInfinity;
				BoundingBoxes.Clear();
				LineLength[0] = 0f;
				Vector3 vector = Points[0] - (Points[1] - Points[0]).normalized * Spacing;
				float num2 = 0f;
				for (int i = 0; i < num; i++)
				{
					Bounds value2 = new Bounds
					{
						min = Vector3.positiveInfinity,
						max = Vector3.negativeInfinity
					};
					Segment pointsInSegment = GetPointsInSegment(i);
					Vector3 vector2 = Normals[i];
					value2.Encapsulate(pointsInSegment[0]);
					value2.Encapsulate(pointsInSegment[3]);
					float3 float5 = pointsInSegment[0];
					float num3 = 0f;
					float num4 = Vector3.Distance(pointsInSegment[0], pointsInSegment[1]) + Vector3.Distance(pointsInSegment[1], pointsInSegment[2]) + Vector3.Distance(pointsInSegment[2], pointsInSegment[3]);
					int num5 = Mathf.CeilToInt((Vector3.Distance(pointsInSegment[0], pointsInSegment[3]) + 0.5f * num4) * Resolution * 10f);
					if (num5 > 0)
					{
						int length = Result.Length;
						float num6 = ((length == 0) ? (-1f / (float)num5) : 0f);
						while (num6 <= 1f)
						{
							num6 += 1f / (float)num5;
							Vector3 vector3 = EvaluateCubic(pointsInSegment[0], pointsInSegment[1], pointsInSegment[2], pointsInSegment[3], num6);
							if (num6 > -0.5f / (float)num5)
							{
								num3 += Vector3.Distance(vector3, float5);
							}
							float5 = vector3;
							Vector3 normalized = DeriveCubic(pointsInSegment[0], pointsInSegment[1], pointsInSegment[2], pointsInSegment[3], Mathf.Clamp01(num6)).normalized;
							vector2 = Vector3.Cross(normalized, Vector3.Cross(vector2, normalized)).normalized;
							num2 += Vector3.Distance(vector, vector3);
							while (num2 >= Spacing)
							{
								float num7 = num2 - Spacing;
								Vector3 vector4 = vector3 + (vector - vector3).normalized * num7;
								value2.Encapsulate(vector4);
								Result.Add(new OrientedPoint(vector4, normalized, vector2));
								num2 = num7;
								vector = vector4;
							}
							vector = vector3;
						}
						int length2 = Result.Length;
						if (length != length2)
						{
							num3 += Vector3.Distance(float5, pointsInSegment[3]);
							LineLength[0] += num3;
							Vector3 normalized = DeriveCubic(pointsInSegment[0], pointsInSegment[1], pointsInSegment[2], pointsInSegment[3], 1f).normalized;
							vector2 = Vector3.Cross(normalized, Vector3.Cross(vector2, normalized)).normalized;
							float num8 = Vector3.SignedAngle(vector2, Normals[i + 1], normalized);
							float num9 = Spacing / num3;
							float num10 = Vector3.Distance(Result[length].position, pointsInSegment[0]) / num3;
							for (int j = length; j < length2; j++)
							{
								float angle = ((float)(j - length) * num9 + num10) * num8;
								OrientedPoint value3 = Result[j];
								value3.normal = Quaternion.AngleAxis(angle, value3.forward) * value3.normal;
								Result[j] = value3;
							}
						}
					}
					if (i == 0)
					{
						value = value2;
					}
					else
					{
						value.Encapsulate(value2);
					}
					BoundingBoxes.Add(in value2);
				}
				if (Result.Length > 0)
				{
					OrientedPoint value4 = Result[0];
					value4.position = Points[0];
					value4.normal = Normals[0];
					value4.forward = DeriveCubic(Points[0], Points[1], Points[2], Points[3], 0f).normalized;
					Result[0] = value4;
					if (Result.Length == 1)
					{
						Result.Add(new OrientedPoint(Points[LoopIndex(-1)], DeriveCubic(Points[LoopIndex(-4)], Points[LoopIndex(-3)], Points[LoopIndex(-2)], Points[LoopIndex(-1)], 1f).normalized, Normals[Normals.Length - 1]));
						if (BoundingBoxes.Length > 0)
						{
							BoundingBoxes[BoundingBoxes.Length - 1].Encapsulate(Points[LoopIndex(-1)]);
						}
						value.Encapsulate(Points[LoopIndex(-1)]);
					}
					else
					{
						OrientedPoint value5 = Result[Result.Length - 1];
						value5.position = Points[LoopIndex(-1)];
						value5.normal = Normals[Normals.Length - 1];
						value5.forward = DeriveCubic(Points[LoopIndex(-4)], Points[LoopIndex(-3)], Points[LoopIndex(-2)], Points[LoopIndex(-1)], 1f).normalized;
						Result[Result.Length - 1] = value5;
					}
				}
				Bounds[0] = value;
			}
		}

		public static Vector3 EvaluateQuadratic(Vector3 a, Vector3 b, Vector3 c, float t)
		{
			Vector3 a2 = Vector3.Lerp(a, b, t);
			Vector3 b2 = Vector3.Lerp(b, c, t);
			return Vector3.Lerp(a2, b2, t);
		}

		public static Vector3 EvaluateCubic(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float t)
		{
			return a * ((1f - t) * (1f - t) * (1f - t)) + b * (3f * (1f - t) * (1f - t) * t) + c * (3f * (1f - t) * t * t) + d * (t * t * t);
		}

		public static Vector3 DeriveQuadratic(Vector3 a, Vector3 b, Vector3 c, float t)
		{
			return Vector3.Lerp(2f * (b - a), 2f * (c - b), t);
		}

		public static Vector3 DeriveCubic(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float t)
		{
			return EvaluateQuadratic(3f * (b - a), 3f * (c - b), 3f * (d - c), t);
		}

		public static float InverseCubic(Vector3 a, Vector3 b, Vector3 c, Vector3 d, Vector3 p)
		{
			float num = 0.5f;
			for (int i = 0; i < 100; i++)
			{
				Vector3 vector = EvaluateCubic(a, b, c, d, num);
				Vector3 vector2 = DeriveCubic(a, b, c, d, num);
				Vector3 lhs = vector - p;
				if (Vector3.Dot(lhs, vector2) == 0f)
				{
					break;
				}
				num -= Vector3.Dot(lhs, vector2) / Vector3.Dot(vector2, vector2);
			}
			return num;
		}

		public static Vector3[] SubdivideCubic(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float t)
		{
			Vector3 vector = Vector3.Lerp(a, b, t);
			Vector3 vector2 = Vector3.Lerp(b, c, t);
			Vector3 vector3 = Vector3.Lerp(c, d, t);
			Vector3 vector4 = Vector3.Lerp(vector, vector2, t);
			Vector3 vector5 = Vector3.Lerp(vector2, vector3, t);
			Vector3 vector6 = Vector3.Lerp(vector4, vector5, t);
			return new Vector3[7] { a, vector, vector4, vector6, vector5, vector3, d };
		}

		public static Vector3[] UnSubdivideCubic(Vector3 p0, Vector3 h01, Vector3 h10, Vector3 p1, Vector3 h11, Vector3 h20, Vector3 p2)
		{
			return new Vector3[4]
			{
				p0,
				p0 + Vector3.Distance(p0, h10) / Vector3.Distance(p0, h01) * (h01 - p0),
				p2 + Vector3.Distance(p2, h11) / Vector3.Distance(p2, h20) * (h20 - p2),
				p2
			};
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static OrientedPoint[] GetEvenlySpacedPoints(IEnumerable<Vector3> points, IEnumerable<Vector3> normals, float spacing, float resolution = 1f)
		{
			Bounds bounds;
			return GetEvenlySpacedPoints(points, normals, out bounds, null, spacing, resolution);
		}

		public static OrientedPoint[] GetEvenlySpacedPoints(IEnumerable<Vector3> points, IEnumerable<Vector3> normals, out Bounds bounds, List<Bounds> boundingBoxes, float spacing, float resolution = 1f)
		{
			GetEvenlySpacedPointsBurstJob jobData = new GetEvenlySpacedPointsBurstJob
			{
				Points = new NativeArray<Vector3>(points.ToArray(), Allocator.TempJob),
				Normals = new NativeArray<Vector3>(normals.ToArray(), Allocator.TempJob),
				Spacing = spacing,
				Resolution = resolution,
				Result = new NativeList<OrientedPoint>(Allocator.TempJob),
				Bounds = new NativeArray<Bounds>(1, Allocator.TempJob),
				BoundingBoxes = new NativeList<Bounds>(Allocator.TempJob),
				LineLength = new NativeArray<float>(1, Allocator.TempJob)
			};
			jobData.Run();
			OrientedPoint[] result = jobData.Result.AsArray().ToArray();
			bounds = jobData.Bounds[0];
			boundingBoxes?.Clear();
			boundingBoxes?.AddRange(jobData.BoundingBoxes.AsArray().ToArray());
			jobData.Points.Dispose();
			jobData.Normals.Dispose();
			jobData.Result.Dispose();
			jobData.Bounds.Dispose();
			jobData.BoundingBoxes.Dispose();
			jobData.LineLength.Dispose();
			return result;
		}

		public static float AngleFromNormal(Vector3 forward, Vector3 normal)
		{
			forward = forward.normalized;
			normal = normal.normalized;
			normal = (normal - Vector3.Dot(forward, normal) * forward).normalized;
			Vector3 normalized = Vector3.Cross(Vector3.up, forward).normalized;
			Vector3 normalized2 = Vector3.Cross(forward, normalized).normalized;
			return Vector3.SignedAngle(normal, normalized2, forward);
		}

		public static Vector3 NormalFromAngle(Vector3 forward, float angle)
		{
			Vector3 normalized = Vector3.Cross(Vector3.up, forward).normalized;
			Vector3 normalized2 = Vector3.Cross(forward, normalized).normalized;
			return Quaternion.AngleAxis(0f - angle, forward) * normalized2;
		}
	}
}
