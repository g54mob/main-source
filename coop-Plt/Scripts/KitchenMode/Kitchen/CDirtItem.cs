using Unity.Entities;

namespace Kitchen
{
	[InternalBufferCapacity(12)]
	public struct CDirtItem : IBufferElementData
	{
		public int ID;
	}
}
