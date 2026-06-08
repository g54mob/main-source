using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CInstantProcessTool : IItemProperty, IAttachableProperty, IComponentData
	{
		public float CooldownSeconds;
	}
}
