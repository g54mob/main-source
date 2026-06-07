using Unity.Entities;

namespace DV.ECS.Components
{
	public struct SkipOneVelocityEstimateFrame : IComponentData
	{
		public Entity target;
	}
}
