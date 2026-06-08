using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CItemHolder : IComponentData, IApplianceProperty, IAttachableProperty
	{
		public Entity HeldItem;

		public static implicit operator CItemHolder(Entity e)
		{
			return new CItemHolder
			{
				HeldItem = e
			};
		}

		public static implicit operator Entity(CItemHolder h)
		{
			return h.HeldItem;
		}
	}
}
