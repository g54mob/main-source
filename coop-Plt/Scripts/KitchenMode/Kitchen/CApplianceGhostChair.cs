using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CApplianceGhostChair : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public bool IsPathable;

		public bool IsDisabled;

		public int ReplaceWith;

		public Entity Table;
	}
}
