using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CAutomatedInteractorProcessRestriction : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public int Process;
	}
}
