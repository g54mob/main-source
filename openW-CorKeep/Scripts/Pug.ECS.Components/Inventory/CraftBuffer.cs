using Unity.Entities;

namespace Inventory
{
	public struct CraftBuffer : IBufferElementData
	{
		public Entity playerEntity;

		public CraftActionData craftActionData;
	}
}
