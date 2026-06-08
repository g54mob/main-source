using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CCausesSpills : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public int ID;

		public float Rate;

		public bool OverwriteOtherMesses;
	}
}
