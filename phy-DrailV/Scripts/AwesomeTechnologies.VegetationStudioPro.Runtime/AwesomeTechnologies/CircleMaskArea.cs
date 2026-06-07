using AwesomeTechnologies.Vegetation;
using AwesomeTechnologies.VegetationSystem;
using Unity.Jobs;
using UnityEngine;

namespace AwesomeTechnologies
{
	public class CircleMaskArea : BaseMaskArea
	{
		public float Radius = 0.1f;

		public Vector3 Position;

		public VegetationType VegetationType;

		public void Init()
		{
			MaskBounds = GetMaskBounds();
		}

		public override JobHandle SampleMask(VegetationInstanceData instanceData, VegetationType vegetationType, JobHandle dependsOn)
		{
			if (VegetationType != vegetationType)
			{
				return dependsOn;
			}
			dependsOn = new SampleVegetatiomMaskCircleJob
			{
				MaskPosition = Position,
				Radius = Radius,
				Position = instanceData.Position.AsDeferredJobArray(),
				Excluded = instanceData.Excluded.AsDeferredJobArray()
			}.Schedule(instanceData.Excluded, 32, dependsOn);
			return dependsOn;
		}

		private Bounds GetMaskBounds()
		{
			return new Bounds(Position, new Vector3(Radius * 2f, Radius * 2f, Radius * 2f));
		}
	}
}
