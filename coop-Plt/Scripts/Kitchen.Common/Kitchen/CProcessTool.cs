using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CProcessTool : IItemProperty, IAttachableProperty, IComponentData
	{
		public int Process;

		public float Factor;
	}
}
