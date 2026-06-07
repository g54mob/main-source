using Unity.Entities;

namespace DV.ECS.Components
{
	public struct VelocityParent : IComponentData
	{
		public Entity parent;

		public VelocityEstimate relativeToParentVelocity;
	}
}
