using Unity.Entities;
using Unity.Mathematics;

namespace Pug.Automation
{
	[InternalBufferCapacity(4)]
	public struct MoversWithSharedStateBuffer : IBufferElementData
	{
		public Entity moverEntity;

		public int2 cachedStart;

		public int2 cachedDirection;
	}
}
