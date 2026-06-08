using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CChangeDecorEvent : IComponentData
	{
		public int RoomID;

		public int DecorID;

		public LayoutMaterialType Type;
	}
}
