using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CToolStorage : IItemProperty, IAttachableProperty, IComponentData
	{
		public int Capacity;
	}
}
