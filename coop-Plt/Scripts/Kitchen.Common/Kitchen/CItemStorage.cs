using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CItemStorage : IApplianceProperty, IAttachableProperty, IComponentData, IAttachmentLogic
	{
		public int ActiveIndex;

		public int Capacity;

		public bool IsStack;

		public bool PreventManualCycling;

		public void Attach(EntityManager em, EntityCommandBuffer ecb, Entity e)
		{
			ecb.AddComponent(e, this);
			ecb.AddBuffer<CItemStored>(e);
		}
	}
}
