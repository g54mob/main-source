using Unity.Entities;

namespace PugWorldGen
{
	public struct DungeonPathTemplateBuffer : IBufferElementData
	{
		public Entity spawnTemplateBufferEntity;

		public RoomFlags flags;

		public int minimumSizeRequirement;
	}
}
