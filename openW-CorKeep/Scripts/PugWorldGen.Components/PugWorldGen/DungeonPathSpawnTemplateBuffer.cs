using Unity.Entities;

namespace PugWorldGen
{
	public struct DungeonPathSpawnTemplateBuffer : IBufferElementData
	{
		public BlobAssetReference<SpawnTemplateBlob> Value;
	}
}
