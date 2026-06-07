using System.Collections.Generic;
using AwesomeTechnologies.Utility;
using AwesomeTechnologies.Vegetation;
using AwesomeTechnologies.VegetationSystem;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace AwesomeTechnologies
{
	public class PolygonMaskArea : BaseMaskArea
	{
		private Vector2[] _points2D;

		private Vector3[] _points3D;

		private LineSegment2D[] _segments;

		public NativeArray<Vector2> PolygonArray;

		public NativeArray<LineSegment2D> SegmentArray;

		public void AddPolygon(List<Vector3> pointList)
		{
			_points2D = new Vector2[pointList.Count];
			_points3D = new Vector3[pointList.Count];
			for (int i = 0; i <= pointList.Count - 1; i++)
			{
				_points2D[i] = new Vector2(pointList[i].x, pointList[i].z);
				_points3D[i] = pointList[i];
			}
			MaskBounds = GetMaskBounds();
			if (PolygonArray.IsCreated)
			{
				PolygonArray.Dispose();
			}
			PolygonArray = new NativeArray<Vector2>(_points2D.Length, Allocator.Persistent);
			PolygonArray.CopyFromFast(_points2D);
			CreateSegments();
		}

		private void CreateSegments()
		{
			_segments = new LineSegment2D[_points2D.Length];
			for (int i = 0; i <= _points2D.Length - 2; i++)
			{
				LineSegment2D lineSegment2D = new LineSegment2D(_points2D[i], _points2D[i + 1]);
				_segments[i] = lineSegment2D;
			}
			if (_points2D.Length != 0)
			{
				LineSegment2D lineSegment2D2 = new LineSegment2D(_points2D[0], _points2D[_points2D.Length - 1]);
				_segments[_points2D.Length - 1] = lineSegment2D2;
			}
			if (SegmentArray.IsCreated)
			{
				SegmentArray.Dispose();
			}
			SegmentArray = new NativeArray<LineSegment2D>(_segments.Length, Allocator.Persistent);
			SegmentArray.CopyFromFast(_segments);
		}

		public override JobHandle SampleMask(VegetationInstanceData instanceData, VegetationType vegetationType, JobHandle dependsOn)
		{
			if (!ExcludeVegetationType(vegetationType))
			{
				return dependsOn;
			}
			dependsOn = new SampleVegetatiomMaskPolygonJob
			{
				Position = instanceData.Position.AsDeferredJobArray(),
				Excluded = instanceData.Excluded.AsDeferredJobArray(),
				PolygonArray = PolygonArray,
				SegmentArray = SegmentArray,
				AdditionalWidth = GetAdditionalWidth(vegetationType),
				AdditionalWidthMax = GetAdditionalWidthMax(vegetationType),
				NoiseScale = GetPerlinScale(vegetationType)
			}.Schedule(instanceData.Excluded, 32, dependsOn);
			return dependsOn;
		}

		public override JobHandle SampleIncludeVegetationMask(VegetationInstanceData instanceData, VegetationTypeIndex vegetationTypeIndex, JobHandle dependsOn)
		{
			VegetationTypeSettings vegetationTypeSettings = GetVegetationTypeSettings(vegetationTypeIndex);
			if (vegetationTypeSettings != null)
			{
				dependsOn = new IncludeVegetatiomMaskPolygonJob
				{
					Excluded = instanceData.Excluded.AsDeferredJobArray(),
					Position = instanceData.Position.AsDeferredJobArray(),
					VegetationMaskDensity = instanceData.VegetationMaskDensity.AsDeferredJobArray(),
					VegetationMaskScale = instanceData.VegetationMaskScale.AsDeferredJobArray(),
					Denisty = vegetationTypeSettings.Density,
					Scale = vegetationTypeSettings.Size,
					PolygonArray = PolygonArray
				}.Schedule(instanceData.Excluded, 32, dependsOn);
			}
			return dependsOn;
		}

		public override bool HasVegetationTypeIndex(VegetationTypeIndex vegetationTypeIndex)
		{
			for (int i = 0; i <= VegetationTypeList.Count - 1; i++)
			{
				if (VegetationTypeList[i].Index == vegetationTypeIndex)
				{
					return true;
				}
			}
			return false;
		}

		private Bounds GetMaskBounds()
		{
			Bounds result = ((_points3D.Length != 0) ? new Bounds(_points3D[0], new Vector3(1f, 1f, 1f)) : new Bounds(new Vector3(0f, 0f, 0f), new Vector3(1f, 1f, 1f)));
			for (int i = 0; i <= _points3D.Length - 1; i++)
			{
				result.Encapsulate(_points3D[i]);
			}
			result.Expand(GetMaxAdditionalDistance());
			return result;
		}

		public override void Dispose()
		{
			base.Dispose();
			if (PolygonArray.IsCreated)
			{
				PolygonArray.Dispose();
			}
			if (SegmentArray.IsCreated)
			{
				SegmentArray.Dispose();
			}
		}
	}
}
