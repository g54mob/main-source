using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CToolInteractionMemory : IItemProperty, IAttachableProperty, IComponentData
	{
		public Entity LastEntity;

		public bool LastWasDrop;
	}
}
