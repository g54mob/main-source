using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CApplianceOrderMachine : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public bool IsReorderMachine;
	}
}
