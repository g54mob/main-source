using Unity.Entities;

namespace PugWorldGen
{
	public struct DungeonPathBuffer : IBufferElementData
	{
		public BlobAssetReference<SpawnTemplateBlob> spawnTemplate;

		public PathCD path;
	}
}
