using Unity.Entities;

namespace Kitchen
{
	public struct CTransferRequiresUnblockedEntity : IComponentData
	{
		public Entity Entity;
	}
}
