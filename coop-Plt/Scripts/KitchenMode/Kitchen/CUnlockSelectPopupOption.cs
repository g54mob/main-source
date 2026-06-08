using Unity.Entities;

namespace Kitchen
{
	[InternalBufferCapacity(6)]
	public struct CUnlockSelectPopupOption : IBufferElementData
	{
		public Entity Entity;

		public int ID;
	}
}
