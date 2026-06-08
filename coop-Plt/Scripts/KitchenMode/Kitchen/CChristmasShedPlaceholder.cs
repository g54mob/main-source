using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CChristmasShedPlaceholder : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public bool IsOutput;

		public int ShedID;
	}
}
