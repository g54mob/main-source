using Kitchen.Layouts;
using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CApplyInitialDecor : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public RoomType Type;

		public int Decor;
	}
}
