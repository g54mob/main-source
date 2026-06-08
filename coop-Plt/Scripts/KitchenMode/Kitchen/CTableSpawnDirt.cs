using Unity.Entities;

namespace Kitchen
{
	public struct CTableSpawnDirt : IComponentData
	{
		public bool ReuseConsumables;

		public bool BlockExtendedDirt;
	}
}
