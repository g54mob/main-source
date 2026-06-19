using Unity.Entities;

namespace PugWorldGen
{
	public struct DungeonNodeTemplateBuffer : IBufferElementData
	{
		public Entity spawnTemplateBufferEntity;

		public RoomFlags flags;

		public int minimumSizeRequirement;
	}
}
