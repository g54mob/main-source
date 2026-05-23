using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding.Util
{
	public class PathInterpolator
	{
		public struct Cursor
		{
			private PathInterpolator interpolator;

			private int version;

			private float currentDistance;

			private float distanceToSegmentStart;

			private float currentSegmentLength;

			private int segmentIndex { get; set; }

			public int segmentCount
			{
				get
				{
					AssertValid();
					return interpolator.path.Count - 1;
				}
			}

			public Vector3 endPoint
			{
				get
				{
					AssertValid();
					return interpolator.path[interpolator.path.Count - 1];
				}
			}

			public float fractionAlongCurrentSegment
			{
				get
				{
					if (!(currentSegmentLength > 0f))
					{
						return 1f;
					}
					return (currentDistance - distanceToSegmentStart) / currentSegmentLength;
				}
				set
				{
					currentDistance = distanceToSegmentStart + Mathf.Clamp01(value) * currentSegmentLength;
				}
			}

			public bool valid
			{
				get
				{
					if (interpolator != null)
					{
						return interpolator.version == version;
					}
					return false;
				}
			}

			public Vector3 tangent
			{
				get
				{
					AssertValid();
					return interpolator.path[segmentIndex + 1] - interpolator.path[segmentIndex];
				}
			}

			public float remainingDistance
			{
				get
				{
					AssertValid();
					return interpolator.totalDistance - distance;
				}
				set
				{
					AssertValid();
					distance = interpolator.totalDistance - value;
				}
			}

			public float distance
			{
				get
				{
					return currentDistance;
				}
				set
				{
					AssertValid();
					currentDistance = value;
					while (currentDistance < distanceToSegmentStart && segmentIndex > 0)
					{
						PrevSegment();
					}
					while (currentDistance > distanceToSegmentStart + currentSegmentLength && segmentIndex < interpolator.path.Count - 2)
					{
						NextSegment();
					}
				}
			}

			public Vector3 position
			{
				get
				{
					AssertValid();
					float t = ((currentSegmentLength > 0.0001f) ? ((currentDistance - distanceToSegmentStart) / currentSegmentLength) : 0f);
					return Vector3.Lerp(interpolator.path[segmentIndex], interpolator.path[segmentIndex + 1], t);
				}
			}

			public Vector3 curvatureDirection
			{
				get
				{
					GetTangents(out var t, out var t2);
					Vector3 result = Vector3.Cross(t, t2);
					if (!(result.sqrMagnitude <= 1E-06f))
					{
						return result;
					}
					return Vector3.zero;
				}
			}

			public static Cursor StartOfPath(PathInterpolator interpolator)
			{
				if (!interpolator.valid)
				{
					throw new InvalidOperationException("PathInterpolator has no path set");
				}
				return new Cursor
				{
					interpolator = interpolator,
					version = interpolator.version,
					segmentIndex = 0,
					currentDistance = 0f,
					distanceToSegmentStart = 0f,
					currentSegmentLength = (interpolator.path[1] - interpolator.path[0]).magnitude
				};
			}

			public void GetRemainingPath(List<Vector3> buffer)
			{
				AssertValid();
				buffer.Add(position);
				for (int i = segmentIndex + 1; i < interpolator.path.Count; i++)
				{
					buffer.Add(interpolator.path[i]);
				}
			}

			private void AssertValid()
			{
				if (!valid)
				{
					throw new InvalidOperationException("The cursor has been invalidated because SetPath has been called on the interpolator. Please create a new cursor.");
				}
			}

			public void GetTangents(out Vector3 t1, out Vector3 t2)
			{
				AssertValid();
				bool flag = currentDistance <= distanceToSegmentStart + 0.001f;
				bool flag2 = currentDistance >= distanceToSegmentStart + currentSegmentLength - 0.001f;
				if (flag || flag2)
				{
					int num;
					int num2;
					if (flag)
					{
						num = ((segmentIndex > 0) ? (segmentIndex - 1) : segmentIndex);
						num2 = segmentIndex;
					}
					else
					{
						num = segmentIndex;
						num2 = ((segmentIndex < interpolator.path.Count - 2) ? (segmentIndex + 1) : segmentIndex);
					}
					t1 = interpolator.path[num + 1] - interpolator.path[num];
					t2 = interpolator.path[num2 + 1] - interpolator.path[num2];
				}
				else
				{
					t1 = tangent;
					t2 = t1;
				}
			}

			public void MoveToNextCorner()
			{
				AssertValid();
				List<Vector3> path = interpolator.path;
				while (currentDistance >= distanceToSegmentStart + currentSegmentLength && segmentIndex < path.Count - 2)
				{
					NextSegment();
				}
				while (segmentIndex < path.Count - 2 && VectorMath.IsColinear(path[segmentIndex], path[segmentIndex + 1], path[segmentIndex + 2]))
				{
					NextSegment();
				}
				currentDistance = distanceToSegmentStart + currentSegmentLength;
			}

			public bool MoveToClosestIntersectionWithLineSegment(Vector3 origin, Vector3 direction, Vector2 range)
			{
				AssertValid();
				float num = float.PositiveInfinity;
				float num2 = float.PositiveInfinity;
				float num3 = 0f;
				for (int i = 0; i < interpolator.path.Count - 1; i++)
				{
					Vector3 vector = interpolator.path[i];
					Vector3 vector2 = interpolator.path[i + 1];
					float magnitude = (vector2 - vector).magnitude;
					if (VectorMath.LineLineIntersectionFactors(((float3)vector).xz, ((float3)(vector2 - vector)).xz, ((float3)origin).xz, ((float3)direction).xz, out var factor, out var factor2) && factor >= 0f && factor <= 1f && factor2 >= range.x && factor2 <= range.y)
					{
						float num4 = num3 + factor * magnitude;
						float num5 = Mathf.Abs(num4 - currentDistance);
						if (num5 < num2)
						{
							num = num4;
							num2 = num5;
						}
					}
					num3 += magnitude;
				}
				if (num2 != float.PositiveInfinity)
				{
					distance = num;
					return true;
				}
				return false;
			}

			private void MoveToSegment(int index, float fractionAlongSegment)
			{
				AssertValid();
				if (index < 0 || index >= interpolator.path.Count - 1)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				while (segmentIndex > index)
				{
					PrevSegment();
				}
				while (segmentIndex < index)
				{
					NextSegment();
				}
				currentDistance = distanceToSegmentStart + Mathf.Clamp01(fractionAlongSegment) * currentSegmentLength;
			}

			public void MoveToClosestPoint(Vector3 point)
			{
				AssertValid();
				float num = float.PositiveInfinity;
				float fractionAlongSegment = 0f;
				int index = 0;
				List<Vector3> path = interpolator.path;
				for (int i = 0; i < path.Count - 1; i++)
				{
					float num2 = VectorMath.ClosestPointOnLineFactor(path[i], path[i + 1], point);
					Vector3 vector = Vector3.Lerp(path[i], path[i + 1], num2);
					float sqrMagnitude = (point - vector).sqrMagnitude;
					if (sqrMagnitude < num)
					{
						num = sqrMagnitude;
						fractionAlongSegment = num2;
						index = i;
					}
				}
				MoveToSegment(index, fractionAlongSegment);
			}

			public void MoveToLocallyClosestPoint(Vector3 point, bool allowForwards = true, bool allowBackwards = true)
			{
				AssertValid();
				List<Vector3> path = interpolator.path;
				segmentIndex = Mathf.Min(segmentIndex, path.Count - 2);
				float num2;
				while (true)
				{
					int num = segmentIndex;
					num2 = VectorMath.ClosestPointOnLineFactor(path[num], path[num + 1], point);
					if (num2 > 1f && allowForwards && segmentIndex < path.Count - 2)
					{
						NextSegment();
						allowBackwards = false;
						continue;
					}
					if (!(num2 < 0f && allowBackwards) || segmentIndex <= 0)
					{
						break;
					}
					PrevSegment();
					allowForwards = false;
				}
				if (num2 > 0.5f && segmentIndex < path.Count - 2)
				{
					NextSegment();
				}
				float num3 = 0f;
				float num4 = float.PositiveInfinity;
				if (segmentIndex > 0)
				{
					int num5 = segmentIndex - 1;
					num3 = VectorMath.ClosestPointOnLineFactor(path[num5], path[num5 + 1], point);
					num4 = (Vector3.Lerp(path[num5], path[num5 + 1], num3) - point).sqrMagnitude;
				}
				float num6 = VectorMath.ClosestPointOnLineFactor(path[segmentIndex], path[segmentIndex + 1], point);
				float sqrMagnitude = (Vector3.Lerp(path[segmentIndex], path[segmentIndex + 1], num6) - point).sqrMagnitude;
				if (num4 < sqrMagnitude)
				{
					MoveToSegment(segmentIndex - 1, num3);
				}
				else
				{
					MoveToSegment(segmentIndex, num6);
				}
			}

			public void MoveToCircleIntersection2D<T>(Vector3 circleCenter3D, float radius, T transform) where T : IMovementPlane
			{
				AssertValid();
				List<Vector3> path = interpolator.path;
				while (segmentIndex < path.Count - 2 && VectorMath.ClosestPointOnLineFactor(path[segmentIndex], path[segmentIndex + 1], circleCenter3D) > 1f)
				{
					NextSegment();
				}
				Vector2 vector = transform.ToPlane(circleCenter3D);
				while (segmentIndex < path.Count - 2)
				{
					Vector3 p = path[segmentIndex + 1];
					if (!((transform.ToPlane(p) - vector).sqrMagnitude <= radius * radius))
					{
						break;
					}
					NextSegment();
				}
				Vector3 circleCenter = vector;
				Vector3 p2 = path[segmentIndex];
				Vector3 linePoint = transform.ToPlane(p2);
				Vector3 p3 = path[segmentIndex + 1];
				float fractionAlongSegment = VectorMath.LineCircleIntersectionFactor(circleCenter, linePoint, transform.ToPlane(p3), radius);
				MoveToSegment(segmentIndex, fractionAlongSegment);
			}

			private static float IntegrateSmoothingKernel(float a, float b, float smoothingDistance)
			{
				if (smoothingDistance <= 0f)
				{
					return (a <= 0f && b > 0f) ? 1 : 0;
				}
				float num = ((a < 0f) ? Mathf.Exp(a / smoothingDistance) : (2f - Mathf.Exp((0f - a) / smoothingDistance)));
				float num2 = ((b < 0f) ? Mathf.Exp(b / smoothingDistance) : (2f - Mathf.Exp((0f - b) / smoothingDistance)));
				return 0.5f * (num2 - num);
			}

			private static float IntegrateSmoothingKernel2(float a, float b, float smoothingDistance)
			{
				if (smoothingDistance <= 0f)
				{
					return 0f;
				}
				float num = (0f - Mathf.Exp((0f - a) / smoothingDistance)) * smoothingDistance;
				float num2 = (0f - Mathf.Exp((0f - b) / smoothingDistance)) * (smoothingDistance + b - a);
				return 0.5f * (num2 - num);
			}

			private static Vector3 IntegrateSmoothTangent(Vector3 p1, Vector3 p2, ref Vector3 tangent, ref float distance, float expectedRadius, float smoothingDistance)
			{
				Vector3 vector = p2 - p1;
				float magnitude = vector.magnitude;
				if (magnitude <= 1E-05f)
				{
					return Vector3.zero;
				}
				Vector3 vector2 = vector * (1f / magnitude);
				float f = Vector3.Angle(tangent, vector2) * (MathF.PI / 180f);
				float num = expectedRadius * Mathf.Abs(f);
				Vector3 zero = Vector3.zero;
				if (num > float.Epsilon)
				{
					Vector3 vector3 = tangent * IntegrateSmoothingKernel(distance, distance + num, smoothingDistance) + (vector2 - tangent) * IntegrateSmoothingKernel2(distance, distance + num, smoothingDistance) / num;
					zero += vector3;
					distance += num;
				}
				zero += vector2 * IntegrateSmoothingKernel(distance, distance + magnitude, smoothingDistance);
				tangent = vector2;
				distance += magnitude;
				return zero;
			}

			public Vector3 EstimateSmoothTangent(Vector3 normalizedTangent, float smoothingDistance, float expectedRadius, Vector3 beforePathStartContribution, bool forward = true, bool backward = true)
			{
				AssertValid();
				if (expectedRadius <= float.Epsilon || smoothingDistance <= 0f)
				{
					return normalizedTangent;
				}
				List<Vector3> path = interpolator.path;
				Vector3 zero = Vector3.zero;
				while (currentDistance >= distanceToSegmentStart + currentSegmentLength && segmentIndex < interpolator.path.Count - 2)
				{
					NextSegment();
				}
				if (forward)
				{
					float num = 0f;
					Vector3 p = position;
					Vector3 vector = normalizedTangent;
					for (int i = segmentIndex + 1; i < path.Count; i++)
					{
						zero += IntegrateSmoothTangent(p, path[i], ref vector, ref num, expectedRadius, smoothingDistance);
						p = path[i];
					}
				}
				if (backward)
				{
					float num2 = 0f;
					Vector3 vector2 = -normalizedTangent;
					Vector3 p2 = position;
					for (int num3 = segmentIndex; num3 >= 0; num3--)
					{
						zero -= IntegrateSmoothTangent(p2, path[num3], ref vector2, ref num2, expectedRadius, smoothingDistance);
						p2 = path[num3];
					}
					zero += beforePathStartContribution * IntegrateSmoothingKernel(float.NegativeInfinity, 0f - currentDistance, smoothingDistance);
				}
				return zero;
			}

			public Vector3 EstimateSmoothCurvature(Vector3 tangent, float smoothingDistance, float expectedRadius)
			{
				AssertValid();
				if (expectedRadius <= float.Epsilon)
				{
					return Vector3.zero;
				}
				List<Vector3> path = interpolator.path;
				tangent = tangent.normalized;
				Vector3 zero = Vector3.zero;
				while (currentDistance >= distanceToSegmentStart + currentSegmentLength && segmentIndex < interpolator.path.Count - 2)
				{
					NextSegment();
				}
				float num = 0f;
				Vector3 vector = position;
				Vector3 vector2 = tangent.normalized;
				for (int i = segmentIndex + 1; i < path.Count; i++)
				{
					Vector3 vector3 = path[i] - vector;
					Vector3 normalized = vector3.normalized;
					float f = Vector3.Angle(vector2, normalized) * (MathF.PI / 180f);
					Vector3 normalized2 = Vector3.Cross(vector2, normalized).normalized;
					float num2 = 1f / expectedRadius;
					float num3 = expectedRadius * Mathf.Abs(f);
					float num4 = num2 * IntegrateSmoothingKernel(num, num + num3, smoothingDistance);
					zero -= num4 * normalized2;
					vector2 = normalized;
					num += num3;
					num += vector3.magnitude;
					vector = path[i];
				}
				num = float.Epsilon;
				vector2 = -tangent.normalized;
				vector = position;
				for (int num5 = segmentIndex; num5 >= 0; num5--)
				{
					Vector3 vector4 = path[num5] - vector;
					if (!(vector4 == Vector3.zero))
					{
						Vector3 normalized3 = vector4.normalized;
						float f2 = Vector3.Angle(vector2, normalized3) * (MathF.PI / 180f);
						Vector3 normalized4 = Vector3.Cross(vector2, normalized3).normalized;
						float num6 = 1f / expectedRadius;
						float num7 = expectedRadius * Mathf.Abs(f2);
						float num8 = num6 * IntegrateSmoothingKernel(num, num + num7, smoothingDistance);
						zero += num8 * normalized4;
						vector2 = normalized3;
						num += num7;
						num += vector4.magnitude;
						vector = path[num5];
					}
				}
				return zero;
			}

			public void MoveWithTurningSpeed(float time, float speed, float turningSpeed, ref Vector3 tangent)
			{
				if (turningSpeed <= 0f)
				{
					throw new ArgumentException("turningSpeed must be greater than zero");
				}
				if (speed <= 0f)
				{
					throw new ArgumentException("speed must be greater than zero");
				}
				AssertValid();
				float num = speed / turningSpeed;
				float num2 = time * speed;
				int num3 = 0;
				while (num2 > 0f && currentDistance >= distanceToSegmentStart + currentSegmentLength && segmentIndex < interpolator.path.Count - 2)
				{
					NextSegment();
				}
				while (num2 < 0f && currentDistance <= distanceToSegmentStart && segmentIndex > 0)
				{
					PrevSegment();
				}
				while (num2 != 0f)
				{
					num3++;
					if (num3 > 100)
					{
						throw new Exception("Infinite Loop " + num2 + " " + time);
					}
					Vector3 vector = this.tangent;
					if (tangent != vector && currentSegmentLength > 0f)
					{
						float num4 = Vector3.Angle(tangent, vector) * (MathF.PI / 180f) * num;
						if (!(Mathf.Abs(num2) > num4))
						{
							tangent = Vector3.Slerp(tangent, vector, Mathf.Abs(num2) / num4);
							break;
						}
						num2 -= num4 * Mathf.Sign(num2);
						tangent = vector;
					}
					if (num2 > 0f)
					{
						float num5 = currentSegmentLength - (currentDistance - distanceToSegmentStart);
						if (!(num2 >= num5))
						{
							currentDistance += num2;
							break;
						}
						num2 -= num5;
						if (segmentIndex + 1 >= interpolator.path.Count - 1)
						{
							MoveToSegment(segmentIndex, 1f);
							break;
						}
						MoveToSegment(segmentIndex + 1, 0f);
					}
					else
					{
						float num6 = currentDistance - distanceToSegmentStart;
						if (!(0f - num2 > num6))
						{
							currentDistance += num2;
							break;
						}
						num2 += num6;
						if (segmentIndex - 1 < 0)
						{
							MoveToSegment(segmentIndex, 0f);
							break;
						}
						MoveToSegment(segmentIndex - 1, 1f);
					}
				}
			}

			private void PrevSegment()
			{
				segmentIndex--;
				currentSegmentLength = (interpolator.path[segmentIndex + 1] - interpolator.path[segmentIndex]).magnitude;
				distanceToSegmentStart -= currentSegmentLength;
			}

			private void NextSegment()
			{
				segmentIndex++;
				distanceToSegmentStart += currentSegmentLength;
				currentSegmentLength = (interpolator.path[segmentIndex + 1] - interpolator.path[segmentIndex]).magnitude;
			}
		}

		private List<Vector3> path;

		private int version = 1;

		private float totalDistance;

		public bool valid => path != null;

		public Cursor start => Cursor.StartOfPath(this);

		public Cursor AtDistanceFromStart(float distance)
		{
			Cursor result = start;
			result.distance = distance;
			return result;
		}

		public void SetPath(List<Vector3> path)
		{
			version++;
			if (this.path == null)
			{
				this.path = new List<Vector3>();
			}
			this.path.Clear();
			if (path == null)
			{
				totalDistance = float.PositiveInfinity;
				return;
			}
			if (path.Count < 2)
			{
				throw new ArgumentException("Path must have a length of at least 2");
			}
			Vector3 vector = path[0];
			totalDistance = 0f;
			this.path.Capacity = Mathf.Max(this.path.Capacity, path.Count);
			this.path.Add(path[0]);
			for (int i = 1; i < path.Count; i++)
			{
				Vector3 vector2 = path[i];
				if (vector2 != vector)
				{
					totalDistance += (vector2 - vector).magnitude;
					this.path.Add(vector2);
					vector = vector2;
				}
			}
			if (this.path.Count < 2)
			{
				this.path.Add(path[0]);
			}
			if (!float.IsNaN(totalDistance))
			{
				return;
			}
			throw new ArgumentException("Path contains NaN values");
		}
	}
}
