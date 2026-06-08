using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CStackableMess : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public int BaseMess;

		public int NextMess;
	}
}
