using Unity.Entities;

namespace PugWorldGen
{
	public struct DungeonNodeSpawnTemplateBuffer : IBufferElementData
	{
		public BlobAssetReference<SpawnTemplateBlob> Value;
	}
}
