using Unity.Collections;
using Unity.Entities;

namespace PugWorldGen
{
	[InternalBufferCapacity(0)]
	public struct DungeonCustomSceneGroupBuffer : IBufferElementData
	{
		public RoomFlags roomType;

		public int minSpawns;

		public int maxSpawns;

		public FixedList4096Bytes<DungeonCustomScene> customScenes;
	}
}
