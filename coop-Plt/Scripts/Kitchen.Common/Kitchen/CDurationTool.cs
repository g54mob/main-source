using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CDurationTool : IItemProperty, IAttachableProperty, IComponentData
	{
		public DurationToolType Type;

		public float Factor;
	}
}
