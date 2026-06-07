using AwesomeTechnologies.Vegetation;
using AwesomeTechnologies.VegetationSystem;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace AwesomeTechnologies
{
	public class BeaconMaskArea : BaseMaskArea
	{
		public float Radius;

		public Vector3 Position;

		public NativeArray<float> FalloutCurveArray;

		public void Init()
		{
			MaskBounds = GetMaskBounds();
		}

		public void SetFalloutCurve(float[] curveArray)
		{
			FalloutCurveArray = new NativeArray<float>(curveArray.Length, Allocator.Persistent);
			FalloutCurveArray.CopyFrom(curveArray);
		}

		public override JobHandle SampleMask(VegetationInstanceData instanceData, VegetationType vegetationType, JobHandle dependsOn)
		{
			return dependsOn;
		}

		public override JobHandle SampleIncludeVegetationMask(VegetationInstanceData instanceData, VegetationTypeIndex vegetationTypeIndex, JobHandle dependsOn)
		{
			VegetationTypeSettings vegetationTypeSettings = GetVegetationTypeSettings(vegetationTypeIndex);
			if (vegetationTypeSettings != null)
			{
				dependsOn = new IncludeVegetatiomMaskBeaconJob
				{
					Excluded = instanceData.Excluded.AsDeferredJobArray(),
					Position = instanceData.Position.AsDeferredJobArray(),
					VegetationMaskDensity = instanceData.VegetationMaskDensity.AsDeferredJobArray(),
					VegetationMaskScale = instanceData.VegetationMaskScale.AsDeferredJobArray(),
					Denisty = vegetationTypeSettings.Density,
					Scale = vegetationTypeSettings.Size,
					FalloutCurveArray = FalloutCurveArray,
					MaskPosition = Position,
					Radius = Radius
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
			return new Bounds(Position, new Vector3(Radius * 2f, Radius * 2f, Radius * 2f));
		}

		public override void Dispose()
		{
			base.Dispose();
			if (FalloutCurveArray.IsCreated)
			{
				FalloutCurveArray.Dispose();
			}
		}
	}
}
