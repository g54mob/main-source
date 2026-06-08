using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CApplyDecor : IItemProperty, IAttachableProperty, IComponentData
	{
		public int ID;

		public LayoutMaterialType Type;
	}
}
