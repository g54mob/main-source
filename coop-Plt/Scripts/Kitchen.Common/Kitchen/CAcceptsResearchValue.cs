using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CAcceptsResearchValue : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public int Upgrade;

		public int ResearchProvided;
	}
}
