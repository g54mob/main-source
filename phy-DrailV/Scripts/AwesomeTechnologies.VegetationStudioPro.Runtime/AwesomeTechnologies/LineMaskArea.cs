using AwesomeTechnologies.Utility;
using AwesomeTechnologies.Vegetation;
using AwesomeTechnologies.VegetationSystem;
using Unity.Jobs;
using UnityEngine;

namespace AwesomeTechnologies
{
	public class LineMaskArea : BaseMaskArea
	{
		private LineSegment2D _line2D;

		private Vector3 _point1;

		private Vector3 _point2;

		private Vector3 _centerPoint;

		private float _width;

		public void SetLineData(Vector3 point1, Vector3 point2, float width)
		{
			_centerPoint = Vector3.Lerp(point1, point2, 0.5f);
			_point1 = point1;
			_point2 = point2;
			_width = width;
			_line2D = new LineSegment2D(new Vector3(point1.x, point1.z), new Vector3(point2.x, point2.z));
			MaskBounds = GetMaskBounds();
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

		public override JobHandle SampleMask(VegetationInstanceData instanceData, VegetationType vegetationType, JobHandle dependsOn)
		{
			if (!ExcludeVegetationType(vegetationType))
			{
				return dependsOn;
			}
			dependsOn = new SampleVegetatiomMaskLineJob
			{
				Position = instanceData.Position.AsDeferredJobArray(),
				Excluded = instanceData.Excluded.AsDeferredJobArray(),
				LineSegment2D = _line2D,
				Width = _width,
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
				dependsOn = new IncludeVegetationMaskLineJob
				{
					Excluded = instanceData.Excluded.AsDeferredJobArray(),
					Position = instanceData.Position.AsDeferredJobArray(),
					VegetationMaskDensity = instanceData.VegetationMaskDensity.AsDeferredJobArray(),
					VegetationMaskScale = instanceData.VegetationMaskScale.AsDeferredJobArray(),
					Denisty = vegetationTypeSettings.Density,
					Scale = vegetationTypeSettings.Size,
					LineSegment2D = _line2D,
					Width = _width
				}.Schedule(instanceData.Excluded, 32, dependsOn);
			}
			return dependsOn;
		}

		public Bounds GetMaskBounds()
		{
			Bounds result = new Bounds(_centerPoint, new Vector3(1f, 1f, 1f));
			result.Encapsulate(_point1);
			result.Encapsulate(_point2);
			result.Expand(_width);
			result.Expand(GetMaxAdditionalDistance());
			return result;
		}
	}
}
