using System.Collections.Generic;
using AwesomeTechnologies.Utility;
using AwesomeTechnologies.Utility.Quadtree;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace AwesomeTechnologies.VegetationSystem.Biomes
{
	public class PolygonBiomeMask
	{
		public delegate void MultionMaskDeleteDelegate(PolygonBiomeMask maskArea);

		public Bounds MaskBounds;

		public BiomeType BiomeType;

		public float BlendDistance;

		public bool UseNoise;

		public float NoiseScale;

		public int BiomeSortOrder;

		private Rect _polygonRect;

		public MultionMaskDeleteDelegate OnMaskDeleteDelegate;

		private Vector2[] _points2D;

		private LineSegment2D[] _segments;

		private Vector3[] _points3D;

		public NativeArray<Vector2> PolygonArray;

		public NativeArray<LineSegment2D> SegmentArray;

		public NativeArray<float> CurveArray;

		public NativeArray<float> InverseCurveArray;

		public NativeArray<float> TextureCurveArray;

		private bool[] _disableEdges;

		public void CallDeleteEvent()
		{
			OnMaskDeleteDelegate?.Invoke(this);
		}

		public void AddPolygon(List<Vector3> pointList, List<bool> disableEdgeList)
		{
			_disableEdges = disableEdgeList.ToArray();
			_points2D = new Vector2[pointList.Count];
			_points3D = new Vector3[pointList.Count];
			for (int i = 0; i <= pointList.Count - 1; i++)
			{
				_points2D[i] = new Vector2(pointList[i].x, pointList[i].z);
				_points3D[i] = pointList[i];
			}
			MaskBounds = GetMaskBounds();
			PolygonArray = new NativeArray<Vector2>(_points2D.Length, Allocator.Persistent);
			PolygonArray.CopyFrom(_points2D);
			CreateSegments();
			_polygonRect = RectExtension.CreateRectFromBounds(MaskBounds);
		}

		public void SetCurve(float[] curveArray)
		{
			CurveArray = new NativeArray<float>(curveArray.Length, Allocator.Persistent);
			CurveArray.CopyFrom(curveArray);
		}

		public void SetInverseCurve(float[] curveArray)
		{
			InverseCurveArray = new NativeArray<float>(curveArray.Length, Allocator.Persistent);
			InverseCurveArray.CopyFrom(curveArray);
		}

		public void SetTextureCurve(float[] curveArray)
		{
			TextureCurveArray = new NativeArray<float>(curveArray.Length, Allocator.Persistent);
			TextureCurveArray.CopyFrom(curveArray);
		}

		private void CreateSegments()
		{
			_segments = new LineSegment2D[_points2D.Length];
			for (int i = 0; i <= _points2D.Length - 2; i++)
			{
				LineSegment2D lineSegment2D = new LineSegment2D(_points2D[i], _points2D[i + 1]);
				_segments[i] = lineSegment2D;
				if (_disableEdges[i] && _disableEdges[i + 1])
				{
					_segments[i].DisableEdge = 1;
				}
			}
			if (_points2D.Length != 0)
			{
				LineSegment2D lineSegment2D2 = new LineSegment2D(_points2D[0], _points2D[_points2D.Length - 1]);
				_segments[_points2D.Length - 1] = lineSegment2D2;
				if (_disableEdges[0] && _disableEdges[_points2D.Length - 1])
				{
					_segments[_points2D.Length - 1].DisableEdge = 1;
				}
			}
			SegmentArray = new NativeArray<LineSegment2D>(_segments.Length, Allocator.Persistent);
			SegmentArray.CopyFrom(_segments);
		}

		public bool Contains(Vector3 point)
		{
			if (!PolygonArray.IsCreated)
			{
				return false;
			}
			Vector2 p = new Vector2(point.x, point.z);
			return IsInPolygon(p);
		}

		public JobHandle FilterSpawnLocations(NativeList<VegetationSpawnLocationInstance> spawnLocationList, BiomeType currentBiomeType, int sampleCount, JobHandle dependsOn)
		{
			dependsOn = new FilterBiomeSpawnLocationsJob
			{
				SpawnLocationList = spawnLocationList.AsDeferredJobArray(),
				PolygonArray = PolygonArray,
				SegmentArray = SegmentArray,
				Include = (currentBiomeType == BiomeType),
				BlendDistance = BlendDistance,
				UseNoise = UseNoise,
				NoiseScale = NoiseScale,
				CurveArray = CurveArray,
				InverseCurveArray = InverseCurveArray,
				PolygonRect = _polygonRect
			}.Schedule(sampleCount, 64, dependsOn);
			return dependsOn;
		}

		private Bounds GetMaskBounds()
		{
			Bounds result = ((_points3D.Length != 0) ? new Bounds(_points3D[0], new Vector3(1f, 1f, 1f)) : new Bounds(new Vector3(0f, 0f, 0f), new Vector3(1f, 1f, 1f)));
			for (int i = 0; i <= _points3D.Length - 1; i++)
			{
				result.Encapsulate(_points3D[i]);
			}
			return result;
		}

		public void Dispose()
		{
			if (PolygonArray.IsCreated)
			{
				PolygonArray.Dispose();
			}
			if (SegmentArray.IsCreated)
			{
				SegmentArray.Dispose();
			}
			if (CurveArray.IsCreated)
			{
				CurveArray.Dispose();
			}
			if (InverseCurveArray.IsCreated)
			{
				InverseCurveArray.Dispose();
			}
			if (TextureCurveArray.IsCreated)
			{
				TextureCurveArray.Dispose();
			}
		}

		private bool IsInPolygon(Vector2 p)
		{
			bool flag = false;
			if (PolygonArray.Length < 3)
			{
				return false;
			}
			Vector2 vector = new Vector2(PolygonArray[PolygonArray.Length - 1].x, PolygonArray[PolygonArray.Length - 1].y);
			for (int i = 0; i < PolygonArray.Length; i++)
			{
				Vector2 vector2 = new Vector2(PolygonArray[i].x, PolygonArray[i].y);
				Vector2 vector3;
				Vector2 vector4;
				if (vector2.x > vector.x)
				{
					vector3 = vector;
					vector4 = vector2;
				}
				else
				{
					vector3 = vector2;
					vector4 = vector;
				}
				if (vector2.x < p.x == p.x <= vector.x && (p.y - (float)(long)vector3.y) * (vector4.x - vector3.x) < (vector4.y - (float)(long)vector3.y) * (p.x - vector3.x))
				{
					flag = !flag;
				}
				vector = vector2;
			}
			return flag;
		}
	}
}
