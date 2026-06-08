using Unity.Entities;

namespace Kitchen
{
	public struct CTemporaryApplianceInfo : IComponentData
	{
		public float RemainingLifetime;

		public Entity Interactor;
	}
}
