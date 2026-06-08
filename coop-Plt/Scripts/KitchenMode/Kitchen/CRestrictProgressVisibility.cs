using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CRestrictProgressVisibility : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public bool HideWhenActive;

		public bool HideWhenInactive;

		public bool ObfuscateWhenActive;

		public bool ObfuscateWhenInactive;
	}
}
