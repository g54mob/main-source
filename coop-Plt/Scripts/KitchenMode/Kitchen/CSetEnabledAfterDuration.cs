using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CSetEnabledAfterDuration : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public bool Activate;
	}
}
