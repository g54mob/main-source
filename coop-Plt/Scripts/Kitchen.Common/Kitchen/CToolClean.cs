using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CToolClean : IItemProperty, IAttachableProperty, IComponentData
	{
		public int WaterAppliance;

		public bool CanReplace;

		public bool CanRefresh;
	}
}
