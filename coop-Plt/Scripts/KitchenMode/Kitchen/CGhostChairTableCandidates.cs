using Unity.Entities;
using Unity.Mathematics;

namespace Kitchen
{
	[InternalBufferCapacity(4)]
	public struct CGhostChairTableCandidates : IBufferElementData
	{
		public Entity Table;

		public quaternion Rotation;
	}
}
