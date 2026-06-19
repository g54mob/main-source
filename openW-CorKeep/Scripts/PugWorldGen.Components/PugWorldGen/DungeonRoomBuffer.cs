using Unity.Collections;
using Unity.Entities;

namespace PugWorldGen
{
	public struct DungeonRoomBuffer : IBufferElementData
	{
		public FixedString64Bytes customSceneName;

		public BlobAssetReference<SpawnTemplateBlob> spawnTemplate;

		public RoomCD room;
	}
}
