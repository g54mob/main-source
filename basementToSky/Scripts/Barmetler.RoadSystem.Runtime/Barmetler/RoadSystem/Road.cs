using System;
using System.Collections.Generic;
using Barmetler.RoadSystem.Util;
using Unity.Profiling;
using UnityEngine;

namespace Barmetler.RoadSystem
{
	public class Road : MonoBehaviour
	{
		public struct EvenlySpacedPointsContext
		{
			public float spacing;

			public float resolution;

			public EvenlySpacedPointsContext(float _spacing, float _resolution)
			{
				spacing = _spacing;
				resolution = _resolution;
			}

			public override bool Equals(object obj)
			{
				if (obj is EvenlySpacedPointsContext evenlySpacedPointsContext && evenlySpacedPointsContext.spacing == spacing)
				{
					return evenlySpacedPointsContext.resolution == resolution;
				}
				return false;
			}

			public override int GetHashCode()
			{
				return $"{spacing}-{resolution}".GetHashCode();
			}
		}

		public RoadAnchor start;

		public RoadAnchor end;

		[SerializeField]
		[HideInInspector]
		private bool autoSetControlPoints;

		[SerializeField]
		[HideInInspector]
		private List<Vector3> points = new List<Vector3>();

		[SerializeField]
		[HideInInspector]
		private List<Vector3> normals = new List<Vector3>();

		[SerializeField]
		[HideInInspector]
		private List<float> angles = new List<float>();

		[SerializeField]
		[HideInInspector]
		private Bounds bounds;

		[SerializeField]
		[HideInInspector]
		private List<Bounds> boundingBoxes = new List<Bounds>();

		private readonly ContextDataCache<Bezier.OrientedPoint[], EvenlySpacedPointsContext> evenlySpacedPointsCache = new ContextDataCache<Bezier.OrientedPoint[], EvenlySpacedPointsContext>();

		private readonly ContextDataCache<float, EvenlySpacedPointsContext> lengthCache = new ContextDataCache<float, EvenlySpacedPointsContext>();

		private static readonly ProfilerMarker CalculateEvenlySpacedPointsPerfMarker = new ProfilerMarker("Road.cs CalculateEvenlySpacedPoints");

		private static ProfilerMarker _roadMeshGeneratorPerfMarker = new ProfilerMarker("RoadMeshGenerator");

		public Bounds BoundingBox => bounds;

		public List<Bounds> BoundingBoxes => boundingBoxes;

		public bool AutoSetControlPoints
		{
			get
			{
				return autoSetControlPoints;
			}
			set
			{
				if (autoSetControlPoints != value)
				{
					autoSetControlPoints = value;
					if (autoSetControlPoints)
					{
						AutoSetAllControlPoints();
					}
				}
			}
		}

		public Vector3 this[int i]
		{
			get
			{
				return points[LoopIndex(i)];
			}
			private set
			{
				points[LoopIndex(i)] = value;
			}
		}

		public int NumPoints => points.Count;

		public int NumSegments => points.Count / 3;

		public Road()
		{
			evenlySpacedPointsCache.children.Add(lengthCache);
		}

		public void Clear()
		{
			points.Clear();
			normals.Clear();
		}

		public void RefreshEndPoints(bool updatemesh = true)
		{
			if (start != null)
			{
				start.SetRoad(this);
			}
			if (end != null)
			{
				end.SetRoad(this, isStart: false);
			}
			if (angles.Count == NumSegments + 1)
			{
				normals.Clear();
				for (int i = 0; i < NumSegments + 1; i++)
				{
					Vector3 forward = ((i == 0) ? (this[1] - this[0]).normalized : (this[i] - this[i - 1]).normalized);
					normals.Add(Bezier.NormalFromAngle(forward, angles[i]));
				}
				angles.Clear();
			}
			if (points.Count == 0 || normals.Count == 0)
			{
				points = new List<Vector3>
				{
					new Vector3(0f, 0f, 0f),
					new Vector3(0f, 0f, 1f),
					new Vector3(0f, 0f, 3f),
					new Vector3(0f, 0f, 4f)
				};
				normals = new List<Vector3>
				{
					Vector3.up,
					Vector3.up
				};
				if (start != null)
				{
					points[0] = base.transform.InverseTransformPoint(start.transform.position);
					normals[0] = base.transform.InverseTransformDirection(start.transform.up);
				}
				if (end != null)
				{
					points[3] = base.transform.InverseTransformPoint(end.transform.position);
					normals[1] = base.transform.InverseTransformDirection(end.transform.up);
				}
				if (start != null)
				{
					points[1] = this[0] + base.transform.InverseTransformDirection(start.transform.forward) * (this[3] - this[0]).magnitude / 2f;
				}
				if (end != null)
				{
					points[2] = this[3] + base.transform.InverseTransformDirection(end.transform.forward) * (this[0] - this[3]).magnitude / 2f;
				}
				if (autoSetControlPoints)
				{
					AutoSetAllControlPoints();
				}
				OnCurveChanged(updatemesh);
			}
			else
			{
				if (NumPoints <= 1)
				{
					return;
				}
				if (start != null)
				{
					Vector3 vector = this[0];
					Vector3 vector2 = this[1];
					Vector3 vector3 = normals[0];
					float magnitude = (this[1] - this[0]).magnitude;
					this[0] = base.transform.InverseTransformPoint(start.transform.position);
					this[1] = this[0] + base.transform.InverseTransformDirection(start.transform.forward) * magnitude;
					normals[0] = base.transform.InverseTransformDirection(start.transform.up);
					if (vector != this[0] || vector2 != this[1] || vector3 != normals[0])
					{
						OnCurveChanged(updatemesh);
					}
				}
				if (end != null)
				{
					Vector3 vector4 = this[-1];
					Vector3 vector5 = this[-2];
					Vector3 vector6 = normals[normals.Count - 1];
					float magnitude2 = (this[-2] - this[-1]).magnitude;
					this[-1] = base.transform.InverseTransformPoint(end.transform.position);
					this[-2] = this[-1] + base.transform.InverseTransformDirection(end.transform.forward) * magnitude2;
					normals[normals.Count - 1] = base.transform.InverseTransformDirection(end.transform.up);
					if (vector4 != this[-1] || vector5 != this[-2] || vector6 == normals[normals.Count - 1])
					{
						OnCurveChanged(updatemesh);
					}
				}
			}
		}

		public Vector3[] GetPointsInSegment(int i)
		{
			return new Vector3[4]
			{
				points[i * 3],
				points[i * 3 + 1],
				points[i * 3 + 2],
				points[LoopIndex(i * 3 + 3)]
			};
		}

		public void AppendSegment(Vector3 pos, bool isStart, Vector3 normal = default(Vector3))
		{
			if ((!isStart || !(start != null)) && (isStart || !(end != null)))
			{
				if (normal == default(Vector3))
				{
					normal = Vector3.up;
				}
				if (isStart)
				{
					points.InsertRange(0, new Vector3[3]
					{
						pos,
						Vector3.zero,
						Vector3.zero
					});
					this[2] = this[3] - (this[4] - this[3]).normalized * (0.5f * (this[0] - this[3]).magnitude);
					this[1] = pos + 0.85f * (this[2] - this[0]);
					this[1] -= Vector3.Dot(normal, this[1] - this[0]) * normal;
					Bezier.AngleFromNormal(this[0] - this[1], normal);
					normals.Insert(0, normal);
				}
				else
				{
					points.AddRange(new Vector3[3]
					{
						Vector3.zero,
						Vector3.zero,
						pos
					});
					this[-3] = this[-4] - (this[-5] - this[-4]).normalized * (0.5f * (this[-1] - this[-4]).magnitude);
					this[-2] = pos + 0.85f * (this[-3] - this[-1]);
					this[-2] -= Vector3.Dot(normal, this[-2] - this[-1]) * normal;
					Bezier.AngleFromNormal(this[-1] - this[-2], normal);
					normals.Add(normal);
				}
				if (autoSetControlPoints)
				{
					AutoSetAllAffectedControlPoints((!isStart) ? (NumPoints - 1) : 0);
				}
				OnCurveChanged();
			}
		}

		[Obsolete("Use InsertSegment(Vector3, int) instead!")]
		public void InsertSegment(Vector3 pos, int segmentIndex)
		{
			points.InsertRange(segmentIndex * 3 + 2, new Vector3[3]
			{
				Vector3.zero,
				pos,
				Vector3.zero
			});
			normals.Insert(segmentIndex + 1, Vector3.up);
			if (autoSetControlPoints)
			{
				AutoSetAllAffectedControlPoints(segmentIndex * 3 + 3);
			}
			else
			{
				AutoSetAnchorControlPoints(segmentIndex * 3 + 3);
			}
			OnCurveChanged();
		}

		public void InsertSegment(int segmentIndex, float t, Vector3 normal)
		{
			if (points.Count >= 4)
			{
				Vector3[] pointsInSegment = GetPointsInSegment(segmentIndex);
				Vector3[] collection = Bezier.SubdivideCubic(pointsInSegment[0], pointsInSegment[1], pointsInSegment[2], pointsInSegment[3], t);
				points.RemoveRange(segmentIndex * 3, 4);
				points.InsertRange(segmentIndex * 3, collection);
				normals.Insert(segmentIndex + 1, normal);
				OnCurveChanged();
			}
		}

		public void DeleteAnchor(int anchorIndex)
		{
			if (anchorIndex % 3 != 0)
			{
				return;
			}
			if (NumSegments > 1)
			{
				if (anchorIndex == 0 && start == null)
				{
					points.RemoveRange(0, 3);
					normals.RemoveRange(0, 1);
				}
				else if (anchorIndex == NumPoints - 1 && end == null)
				{
					points.RemoveRange(anchorIndex - 2, 3);
					normals.RemoveRange(anchorIndex / 3, 1);
				}
				else if (anchorIndex > 0 && anchorIndex < NumPoints - 1)
				{
					normals.RemoveAt(anchorIndex / 3);
					Vector3[] array = Bezier.UnSubdivideCubic(points[anchorIndex - 3], points[anchorIndex - 2], points[anchorIndex - 1], points[anchorIndex], points[anchorIndex + 1], points[anchorIndex + 2], points[anchorIndex + 3]);
					points.RemoveRange(anchorIndex - 1, 3);
					points[anchorIndex - 2] = array[1];
					points[anchorIndex - 1] = array[2];
				}
			}
			OnCurveChanged();
		}

		public void MovePoint(int i, Vector3 pos)
		{
			Vector3 vector = this[i];
			if (i % 3 == 0)
			{
				if ((start != null && i == 0) || (end != null && i == NumPoints - 1))
				{
					return;
				}
				if (i > 0)
				{
					this[i - 1] += pos - vector;
				}
				if (i < NumPoints - 1)
				{
					this[i + 1] += pos - vector;
				}
				this[i] = pos;
				if (autoSetControlPoints)
				{
					AutoSetAllAffectedControlPoints(i);
				}
			}
			else
			{
				if (autoSetControlPoints)
				{
					return;
				}
				bool flag = (i + 1) % 3 == 0;
				int i2 = (flag ? (i + 2) : (i - 2));
				Vector3 vector2 = this[flag ? (i + 1) : (i - 1)];
				if ((start != null && i == 1) || (end != null && i == NumPoints - 2))
				{
					bool flag2 = i == 1;
					Vector3 vector3 = base.transform.InverseTransformDirection((flag2 ? start : end).transform.forward);
					this[i] = this[(!flag2) ? (NumPoints - 1) : 0] + Mathf.Max(0.1f, Vector3.Dot(pos - this[(!flag2) ? (NumPoints - 1) : 0], vector3)) * vector3;
				}
				else if (i > 1 && i < NumPoints - 2)
				{
					float magnitude = (this[i2] - vector2).magnitude;
					this[i] = pos;
					Vector3 normalized = (pos - vector2).normalized;
					this[i2] = vector2 - normalized * magnitude;
				}
				else
				{
					this[i] = pos;
				}
				FixNormal((i + 1) / 3);
			}
			OnCurveChanged();
		}

		private void FixNormal(int index)
		{
			Vector3 planeNormal = ((index == 0) ? (this[1] - this[0]).normalized : (this[index * 3] - this[index * 3 - 1]).normalized);
			normals[index] = Vector3.ProjectOnPlane(normals[index], planeNormal).normalized;
		}

		private void FixNormals()
		{
			for (int i = 0; i <= NumSegments; i++)
			{
				FixNormal(i);
			}
		}

		[Obsolete("Use MoveNormal instead!")]
		public void MoveAngle(int i, float angle)
		{
			if ((i != 0 || !(start != null)) && (i != normals.Count - 1 || !(end != null)))
			{
				Vector3 forward = ((i == 0) ? (points[1] - points[0]) : (points[3 * i] - points[3 * i - 1]));
				MoveNormal(i, Bezier.NormalFromAngle(forward, angle));
				OnCurveChanged();
			}
		}

		[Obsolete("Use GetNormal instead!")]
		public float GetAngle(int i)
		{
			return Bezier.AngleFromNormal((i == 0) ? (points[1] - points[0]) : (points[3 * i] - points[3 * i - 1]), normals[i]);
		}

		public void MoveNormal(int i, Vector3 normal)
		{
			if ((i != 0 || !(start != null)) && (i != normals.Count - 1 || !(end != null)))
			{
				normals[i] = normal;
				FixNormal(i);
				OnCurveChanged();
			}
		}

		public Vector3 GetNormal(int i)
		{
			return normals[i];
		}

		public void OnValidate()
		{
			RefreshEndPoints(updatemesh: false);
			if (start != null)
			{
				start.SetRoad(this);
			}
			if (end != null)
			{
				end.SetRoad(this, isStart: false);
			}
		}

		private void AutoSetAllAffectedControlPoints(int updatedAnchorIndex)
		{
			for (int i = updatedAnchorIndex - 3; i <= updatedAnchorIndex + 3; i += 3)
			{
				if (i >= 0 && i < NumPoints)
				{
					AutoSetAnchorControlPoints(i);
				}
			}
			AutoSetStartAndEndControls();
			OnCurveChanged();
		}

		public void AutoSetAllControlPoints()
		{
			for (int i = 0; i < NumPoints; i += 3)
			{
				AutoSetAnchorControlPoints(i);
			}
			AutoSetStartAndEndControls();
			OnCurveChanged();
		}

		private void AutoSetAnchorControlPoints(int anchorIndex)
		{
			Vector3 vector = this[anchorIndex];
			Vector3 zero = Vector3.zero;
			float[] array = new float[2];
			if (anchorIndex - 3 >= 0)
			{
				Vector3 vector2 = this[anchorIndex - 3] - vector;
				zero += vector2.normalized;
				array[0] = vector2.magnitude;
			}
			if (anchorIndex + 3 <= NumPoints - 1)
			{
				Vector3 vector3 = this[anchorIndex + 3] - vector;
				zero -= vector3.normalized;
				array[1] = 0f - vector3.magnitude;
			}
			zero.Normalize();
			for (int i = 0; i < 2; i++)
			{
				int num = anchorIndex + i * 2 - 1;
				if (num >= 0 && num < NumPoints)
				{
					this[num] = vector + zero * (array[i] * 0.5f);
				}
			}
			FixNormal(anchorIndex / 3);
			OnCurveChanged();
		}

		private void AutoSetStartAndEndControls()
		{
			if (start == null)
			{
				this[1] = (this[0] + this[2]) * 0.5f;
			}
			else
			{
				this[1] = this[0] + base.transform.InverseTransformDirection(start.transform.forward) * ((this[0] - this[3]) * 0.5f).magnitude;
			}
			if (end == null)
			{
				this[-2] = (this[-1] + this[-3]) * 0.5f;
			}
			else
			{
				this[-2] = this[-1] + base.transform.InverseTransformDirection(end.transform.forward) * ((this[-1] - this[-4]) * 0.5f).magnitude;
			}
			OnCurveChanged();
		}

		public Bezier.OrientedPoint[] GetEvenlySpacedPoints(float spacing, float resolution = 1f)
		{
			CalculateEvenlySpacedPoints(spacing, resolution);
			return evenlySpacedPointsCache.GetData(new EvenlySpacedPointsContext(spacing, resolution));
		}

		private void CalculateEvenlySpacedPoints(float spacing, float resolution = 1f, bool calculateBoundingBoxes = false)
		{
			EvenlySpacedPointsContext context = new EvenlySpacedPointsContext(spacing, resolution);
			if (!evenlySpacedPointsCache.IsValid(context) || calculateBoundingBoxes)
			{
				Bezier.OrientedPoint[] data;
				using (CalculateEvenlySpacedPointsPerfMarker.Auto())
				{
					data = ((!calculateBoundingBoxes) ? Bezier.GetEvenlySpacedPoints(points, normals, spacing, resolution) : Bezier.GetEvenlySpacedPoints(points, normals, out bounds, boundingBoxes, spacing, resolution));
				}
				evenlySpacedPointsCache.SetData(data, context);
			}
		}

		public float GetLength(float spacing = 1f, float resolution = 1f)
		{
			EvenlySpacedPointsContext context = new EvenlySpacedPointsContext(spacing, resolution);
			if (lengthCache.IsValid(context))
			{
				return lengthCache.GetData(context);
			}
			Bezier.OrientedPoint[] evenlySpacedPoints = GetEvenlySpacedPoints(spacing, resolution);
			float num = 0f;
			Vector3 vector = Vector3.zero;
			for (int i = 0; i < evenlySpacedPoints.Length; i++)
			{
				if (i > 0)
				{
					num += (evenlySpacedPoints[i].position - vector).magnitude;
				}
				vector = evenlySpacedPoints[i].position;
			}
			lengthCache.SetData(num, context);
			return num;
		}

		public bool IsMaybeCloser(Vector3 worldPosition, float minDistance, float yScale)
		{
			Vector3 a = base.transform.InverseTransformPoint(worldPosition);
			float num = bounds.SqrDistance(Vector3.Scale(a, new Vector3(1f, yScale, 1f)));
			if (!bounds.Contains(Vector3.Scale(a, new Vector3(1f, yScale, 1f))) && num >= minDistance * minDistance)
			{
				return false;
			}
			num = float.PositiveInfinity;
			foreach (Bounds boundingBox in boundingBoxes)
			{
				if (boundingBox.Contains(new Vector3(a.x, boundingBox.center.y + yScale * (a.y - boundingBox.center.y), a.z)))
				{
					return true;
				}
				num = Mathf.Min(num, boundingBox.SqrDistance(new Vector3(a.x, boundingBox.center.y + yScale * (a.y - boundingBox.center.y), a.z)));
			}
			if (num >= minDistance * minDistance)
			{
				return false;
			}
			return true;
		}

		public float GetMinDistance(Vector3 worldPosition, float stepSize, float yScale, out Vector3 closestPoint, out float distanceAlongRoad)
		{
			float num = 0f;
			Vector3 vector = base.transform.InverseTransformPoint(worldPosition);
			Vector3 position = Vector3.zero;
			distanceAlongRoad = 0f;
			float num2 = float.PositiveInfinity;
			Bezier.OrientedPoint[] evenlySpacedPoints = GetEvenlySpacedPoints(stepSize);
			for (int i = 0; i < evenlySpacedPoints.Length; i++)
			{
				Bezier.OrientedPoint orientedPoint = evenlySpacedPoints[i];
				float magnitude = Vector3.Scale(orientedPoint.position - vector, new Vector3(1f, yScale, 1f)).magnitude;
				if (magnitude < num2)
				{
					Vector3 position2 = orientedPoint.position;
					Vector3 vector2 = Vector3.zero;
					bool flag = false;
					bool flag2 = false;
					float num3 = 0f;
					if (i < evenlySpacedPoints.Length - 1)
					{
						Vector3 position3 = evenlySpacedPoints[i + 1].position;
						float magnitude2 = (position3 - position2).magnitude;
						vector2 = (position3 - position2).normalized;
						float num4;
						if ((num4 = Vector3.Dot(vector - position2, vector2)) > 0f && num4 < magnitude2)
						{
							num3 = num4;
							flag = true;
						}
					}
					if (i > 0 && !flag)
					{
						Vector3 position4 = evenlySpacedPoints[i - 1].position;
						float magnitude2 = (position4 - position2).magnitude;
						vector2 = (position4 - position2).normalized;
						float num5;
						if ((num5 = Vector3.Dot(vector - position2, vector2)) > 0f && num5 < magnitude2)
						{
							num3 = num5;
							flag = true;
							flag2 = true;
						}
					}
					Vector3 vector3 = orientedPoint.position;
					if (flag)
					{
						vector3 = position2 + num3 * vector2;
					}
					magnitude = Vector3.Scale(vector3 - vector, new Vector3(1f, yScale, 1f)).magnitude;
					if (magnitude < num2)
					{
						num2 = magnitude;
						distanceAlongRoad = num + (flag2 ? (0f - num3) : num3);
						position = vector3;
					}
				}
				num += stepSize;
			}
			closestPoint = base.transform.TransformPoint(position);
			return num2;
		}

		public void OnCurveChanged(bool updateMesh = true)
		{
			evenlySpacedPointsCache.Invalidate();
			CalculateEvenlySpacedPoints(1f, 1f, calculateBoundingBoxes: true);
			if ((bool)GetComponent<RoadMeshGenerator>().Let(out var result))
			{
				using (_roadMeshGeneratorPerfMarker.Auto())
				{
					result.Invalidate(updateMesh);
				}
			}
		}

		public int LoopIndex(int i)
		{
			return (i % NumPoints + NumPoints) % NumPoints;
		}
	}
}
