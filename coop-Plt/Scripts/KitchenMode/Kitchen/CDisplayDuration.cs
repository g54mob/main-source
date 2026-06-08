using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CDisplayDuration : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public bool IsBad;

		public int Process;

		public bool ShowWhenEmpty;
	}
}
