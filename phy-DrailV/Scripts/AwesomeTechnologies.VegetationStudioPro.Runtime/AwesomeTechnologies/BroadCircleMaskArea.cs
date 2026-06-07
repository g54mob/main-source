using AwesomeTechnologies.Vegetation;
using AwesomeTechnologies.VegetationSystem;
using Unity.Jobs;

namespace AwesomeTechnologies
{
	public class BroadCircleMaskArea : CircleMaskArea
	{
		public bool MaskGrass;

		public bool MaskPlants;

		public bool MaskTrees;

		public bool MaskObjects;

		public bool MaskLargeObjects;

		public new void Init()
		{
			base.Init();
			RemoveGrass = MaskGrass;
			RemovePlants = MaskPlants;
			RemoveTrees = MaskTrees;
			RemoveObjects = MaskObjects;
			RemoveLargeObjects = MaskLargeObjects;
		}

		public override JobHandle SampleMask(VegetationInstanceData instanceData, VegetationType vegetationType, JobHandle dependsOn)
		{
			if (!ExcludeVegetationType(vegetationType))
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
	}
}
